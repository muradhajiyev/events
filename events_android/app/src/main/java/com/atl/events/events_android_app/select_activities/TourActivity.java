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
import com.atl.events.events_android_app.model.Tour;
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
public class TourActivity extends AppCompatActivity{

    ImageView logo;
    TextView tv_description, tv_start_date, tv_end_date, tv_price,
            tv_address,tv_organizer,tv_destination, tv_assemblingpoint, tv_transportation, tv_more;
    CollapsingToolbarLayout collapsingToolbarLayout;
    boolean flag = false;

    private GoogleMap map;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.select_tour_layout);

        map = ((MapFragment) getFragmentManager().findFragmentById(R.id.map)).getMap();
        logo = (ImageView) findViewById(R.id.bgheader);
        tv_description = (TextView) findViewById(R.id.description_textview);
        tv_start_date = (TextView) findViewById(R.id.startdate_textview);
        tv_end_date = (TextView) findViewById(R.id.enddate_textview);
        tv_price = (TextView) findViewById(R.id.price_textview);
        tv_address = (TextView) findViewById(R.id.address_textview);
        tv_destination = (TextView) findViewById(R.id.destination_textview);
        tv_organizer = (TextView) findViewById(R.id.organizer_textview);
        tv_assemblingpoint = (TextView) findViewById(R.id.assemblingpoint_textview);
        tv_transportation = (TextView) findViewById(R.id.transportation_textview);
        tv_more = (TextView) findViewById(R.id.more);

        collapsingToolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.collapse_toolbar);
        collapsingToolbarLayout.setCollapsedTitleTextColor(getResources().getColor(android.R.color.white));
        collapsingToolbarLayout.setExpandedTitleColor(getResources().getColor(android.R.color.white));

        final Toolbar toolbar = (Toolbar) findViewById(R.id.MyToolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        String ID = getIntent().getExtras().getString("eventID");
        select_from_tour(ID);

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


    private void select_from_tour(String id) {
        new AsyncTask<String, Void, Tour>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
            }

            @Override
            protected Tour doInBackground(String... params) {
                return Request.getData().selectTour(params[0]);
            }

            @Override
            protected void onPostExecute(final Tour tour) {
                super.onPostExecute(tour);
                Picasso.with(getApplication())
                        .load(Request.image_url + tour.getLOGO_NAME())
                        .into(logo);
                tv_description.setText(tour.getDESCRIPTION());
                tv_start_date.setText(tour.getSTART_DATE());
                tv_end_date.setText(tour.getEND_DATE());
                tv_price.setText(tour.getPRICE() + " " + tour.getPRICE_COST()+ " AZN");
                tv_address.setText(tour.getADDRESS());
                tv_organizer.setText(tour.getORGANIZER());
                tv_destination.setText(tour.getDESTINATION());
                tv_assemblingpoint.setText(tour.getASSEMBLING_POINT());
                tv_transportation.setText(tour.getTRANSPORTATION());
                collapsingToolbarLayout.setTitle(tour.getTITLE());

                final LatLng position = new LatLng(tour.getLATITUDE(), tour.getLONGITUDE());
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
                        i.putExtra("lat", String.valueOf(tour.getLATITUDE()));
                        i.putExtra("lon", String.valueOf(tour.getLONGITUDE()));
                        i.putExtra("adress", tour.getADDRESS());
                        startActivity(i);
                    }
                });
            }


        }.execute(id);


    }
}
