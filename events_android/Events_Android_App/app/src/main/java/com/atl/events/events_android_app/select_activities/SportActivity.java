package com.atl.events.events_android_app.select_activities;

import android.content.Intent;
import android.media.Image;
import android.os.Bundle;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;


import com.atl.events.events_android_app.R;
import com.atl.events.events_android_app.business_logic.Webservice_urls;
import com.atl.events.events_android_app.domain.select_domain;
import com.atl.events.events_android_app.model.Concert;
import com.atl.events.events_android_app.model.Event;
import com.atl.events.events_android_app.model.Sport;
import com.atl.events.events_android_app.network.api;
import com.squareup.picasso.Picasso;


import retrofit.Callback;
import retrofit.RestAdapter;
import retrofit.RetrofitError;
import retrofit.client.Response;

/**
 * Created by Murad on 22-Oct-15.
 */
public class SportActivity extends AppCompatActivity {
    ImageView logo;
    CollapsingToolbarLayout collapsingToolbar;
    TextView tv_description, tv_start_date, tv_end_date, tv_price, tv_address, tv_more;
    boolean flag = false;

    final RestAdapter restAdapter = new RestAdapter.Builder()
            .setEndpoint("http://10.50.93.110/events").build();
    api eventsapi = restAdapter.create(api.class);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.select_sport_layout);

        final Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        //setSupportActionBar(toolbar);
        //getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        collapsingToolbar =
                (CollapsingToolbarLayout) findViewById(R.id.collapse_toolbar);
        logo = (ImageView) findViewById(R.id.bgheader);
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

        eventsapi.selectSport(new select_domain(eventID), new Callback<Sport>() {
            @Override
            public void success(Sport sport, Response response) {
                Log.d("Check", "Success" + sport.getLOGO_NAME());
                Picasso.with(getApplication())
                        .load(Webservice_urls.image_url + sport.getLOGO_NAME())
                        .into(logo);
                tv_description.setText(sport.getDESCRIPTION());
                tv_start_date.setText(sport.getSTART_DATE());
                tv_end_date.setText(sport.getEND_DATE());
                tv_price.setText(sport.getPRICE() + " " + sport.getPRICE_COST());
                tv_address.setText(sport.getADDRESS());
            }

            @Override
            public void failure(RetrofitError error) {
                Log.d("Check", "Error");
            }
        });


    }


}
