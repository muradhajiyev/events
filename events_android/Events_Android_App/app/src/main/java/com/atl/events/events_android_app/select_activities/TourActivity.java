package com.atl.events.events_android_app.select_activities;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.atl.events.events_android_app.R;
import com.atl.events.events_android_app.business_logic.Webservice_urls;
import com.atl.events.events_android_app.domain.select_domain;
import com.atl.events.events_android_app.model.Concert;
import com.atl.events.events_android_app.model.Tour;
import com.atl.events.events_android_app.network.api;
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
    boolean flag = false;

    final RestAdapter restAdapter = new RestAdapter.Builder()
            .setEndpoint("http://10.50.93.110/events").build();
    api eventsapi = restAdapter.create(api.class);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.select_tour_layout);

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
        eventsapi.selectTour(new select_domain(id), new Callback<Tour>() {
            @Override
            public void success(Tour tour, Response response) {
                Picasso.with(getApplication())
                        .load(Webservice_urls.image_url + tour.getLOGO_NAME())
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
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(TourActivity.this, "Something went wrong, Please try again.", Toast.LENGTH_LONG).show();
            }
        });

    }
}
