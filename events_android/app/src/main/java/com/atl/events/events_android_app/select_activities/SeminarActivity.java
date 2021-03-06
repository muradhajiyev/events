package com.atl.events.events_android_app.select_activities;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.atl.events.events_android_app.MapActivity;
import com.atl.events.events_android_app.R;
import com.atl.events.events_android_app.model.Seminar;
import com.atl.events.events_android_app.network.Request;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.squareup.picasso.Picasso;

import retrofit.Callback;
import retrofit.RestAdapter;
import retrofit.RetrofitError;
import retrofit.client.Response;

/**
 * Created by Murad on 27-Oct-15.
 */
public class SeminarActivity  extends AppCompatActivity{

    ImageView logo;
    TextView tv_description, tv_start_date, tv_end_date, tv_price,
            tv_address,tv_author,tv_subject, tv_more;
    CollapsingToolbarLayout collapsingToolbarLayout;
    boolean flag = false;

    private GoogleMap map;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.select_seminar_layout);

        map = ((MapFragment) getFragmentManager().findFragmentById(R.id.map)).getMap();
        logo = (ImageView) findViewById(R.id.bgheader);
        tv_description = (TextView) findViewById(R.id.description_textview);
        tv_start_date = (TextView) findViewById(R.id.startdate_textview);
        tv_end_date = (TextView) findViewById(R.id.enddate_textview);
        tv_price = (TextView) findViewById(R.id.price_textview);
        tv_address = (TextView) findViewById(R.id.address_textview);
        tv_author = (TextView) findViewById(R.id.author_textview);
        tv_subject = (TextView) findViewById(R.id.subject_textview);
        tv_more = (TextView) findViewById(R.id.more);

        collapsingToolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.collapse_toolbar);
        collapsingToolbarLayout.setCollapsedTitleTextColor(getResources().getColor(android.R.color.white));
        collapsingToolbarLayout.setExpandedTitleColor(getResources().getColor(android.R.color.white));

        final Toolbar toolbar = (Toolbar) findViewById(R.id.MyToolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        String ID = getIntent().getExtras().getString("eventID");
        select_from_seminar(ID);

        tv_more.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (flag) {
                    tv_description.setMaxLines(2);
                    flag = false;
                    tv_more.setText("More");
                } else {
                    tv_description.setMaxLines(2000);
                    flag = true;
                    tv_more.setText("Less");
                }
            }
        });
    }


    private void select_from_seminar(String id) {
        new AsyncTask<String, Void, Seminar>() {

            @Override
            protected void onPreExecute() {
                super.onPreExecute();
            }

            @Override
            protected Seminar doInBackground(String... params) {
                return Request.getData().selectSeminar(params[0]);
            }

            @Override
            protected void onPostExecute(final Seminar seminar) {
                super.onPostExecute(seminar);
                Picasso.with(getApplication())
                        .load(Request.image_url + seminar.getLOGO_NAME())
                        .into(logo);
                tv_description.setText(seminar.getDESCRIPTION());
                tv_start_date.setText(seminar.getSTART_DATE());
                tv_end_date.setText(seminar.getEND_DATE());
                tv_price.setText(seminar.getPRICE() + " " + seminar.getPRICE_COST()+ " AZN");
                tv_address.setText(seminar.getADDRESS());
                tv_author.setText(seminar.getAUTHOR());
                tv_subject.setText(seminar.getSUBJECT());
                collapsingToolbarLayout.setTitle(seminar.getTITLE());

                final LatLng position = new LatLng(seminar.getLATITUDE(), seminar.getLONGITUDE());
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
                        i.putExtra("lat", String.valueOf(seminar.getLATITUDE()));
                        i.putExtra("lon", String.valueOf(seminar.getLONGITUDE()));
                        i.putExtra("adress", seminar.getADDRESS());
                        startActivity(i);
                    }
                });
            }


        }.execute(id);

    }
}
