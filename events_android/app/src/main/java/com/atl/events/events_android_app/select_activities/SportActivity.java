package com.atl.events.events_android_app.select_activities;

import android.content.Intent;
import android.media.Image;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;


import com.atl.events.events_android_app.MapActivity;
import com.atl.events.events_android_app.R;
import com.atl.events.events_android_app.model.Sport;
import com.atl.events.events_android_app.network.Request;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.squareup.picasso.Picasso;


/**
 * Created by Murad on 22-Oct-15.
 */
public class SportActivity extends AppCompatActivity {
    ImageView logo, refresh;
    CollapsingToolbarLayout collapsingToolbar;
    TextView tv_description, tv_start_date, tv_end_date, tv_price, tv_address, tv_more;
    boolean flag = false;


    private GoogleMap map;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.select_sport_layout);

        map = ((MapFragment) getFragmentManager().findFragmentById(R.id.map)).getMap();

        final Toolbar toolbar = (Toolbar) findViewById(R.id.MyToolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        collapsingToolbar =
                (CollapsingToolbarLayout) findViewById(R.id.collapse_toolbar);
        collapsingToolbar.setCollapsedTitleTextColor(getResources().getColor(android.R.color.white));
        collapsingToolbar.setExpandedTitleColor(getResources().getColor(android.R.color.white));

        logo = (ImageView) findViewById(R.id.bgheader);
        refresh = (ImageView) findViewById(R.id.refresh);
        tv_description = (TextView) findViewById(R.id.description_textview);
        tv_start_date = (TextView) findViewById(R.id.startdate_textview);
        tv_end_date = (TextView) findViewById(R.id.enddate_textview);
        tv_price = (TextView) findViewById(R.id.price_textview);
        tv_address = (TextView) findViewById(R.id.address_textview);
        tv_more = (TextView) findViewById(R.id.more);

        String ID = getIntent().getExtras().getString("eventID");
        select_from_sport(ID);

        tv_more.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (flag) {
                    tv_description.setMaxLines(2);
                    flag=false;
                    tv_more.setText("More");
                }else {
                    tv_description.setMaxLines(2000);
                    flag = true;
                    tv_more.setText("Less");
                }
            }
        });




    }

    private void select_from_sport(final String eventID) {

        new AsyncTask<String, Void, Sport>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
            }

            @Override
            protected Sport doInBackground(String... params) {
                return Request.getData().selectSport(params[0]);
            }

            @Override
            protected void onPostExecute(final Sport sport) {
                Picasso.with(getApplication())
                        .load(Request.image_url + sport.getLOGO_NAME())
                        .into(logo);
                tv_description.setText(sport.getDESCRIPTION());
                tv_start_date.setText(sport.getSTART_DATE());
                tv_end_date.setText(sport.getEND_DATE());
                tv_price.setText(sport.getPRICE() + " " + sport.getPRICE_COST());
                tv_address.setText(sport.getADDRESS());
                collapsingToolbar.setTitle(sport.getTITLE());

                final LatLng position = new LatLng(sport.getLATITUDE(), sport.getLONGITUDE());
                MarkerOptions markerOptions = new MarkerOptions().position(position);
                Marker marker = map.addMarker(markerOptions);

                // zoom in the camera to Davao city
                map.moveCamera(CameraUpdateFactory.newLatLngZoom(position, 8));

                // animate the zoom process
                map.animateCamera(CameraUpdateFactory.zoomTo(8), 2000, null);

                map.setMyLocationEnabled(true);

                map.setOnMapClickListener(new GoogleMap.OnMapClickListener() {
                    @Override
                    public void onMapClick(LatLng latLng) {
                        Intent i = new Intent(getApplicationContext(), MapActivity.class);
                        i.putExtra("lat", String.valueOf(sport.getLATITUDE()));
                        i.putExtra("lon", String.valueOf(sport.getLONGITUDE()));
                        i.putExtra("adress", sport.getADDRESS());
                        startActivity(i);
                    }
                });
            }


        }.execute(eventID);

    }



}
