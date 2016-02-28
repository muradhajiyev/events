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
import com.atl.events.events_android_app.model.Seminar;
import com.atl.events.events_android_app.network.api;
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
    boolean flag = false;

    final RestAdapter restAdapter = new RestAdapter.Builder()
            .setEndpoint("http://10.50.93.110/events").build();
    api eventsapi = restAdapter.create(api.class);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.select_seminar_layout);

        logo = (ImageView) findViewById(R.id.bgheader);
        tv_description = (TextView) findViewById(R.id.description_textview);
        tv_start_date = (TextView) findViewById(R.id.startdate_textview);
        tv_end_date = (TextView) findViewById(R.id.enddate_textview);
        tv_price = (TextView) findViewById(R.id.price_textview);
        tv_address = (TextView) findViewById(R.id.address_textview);
        tv_author = (TextView) findViewById(R.id.author_textview);
        tv_subject = (TextView) findViewById(R.id.subject_textview);
        tv_more = (TextView) findViewById(R.id.more);

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
        eventsapi.selectSeminar(new select_domain(id), new Callback<Seminar>() {
            @Override
            public void success(Seminar seminar, Response response) {
                Picasso.with(getApplication())
                        .load(Webservice_urls.image_url + seminar.getLOGO_NAME())
                        .into(logo);
                tv_description.setText(seminar.getDESCRIPTION());
                tv_start_date.setText(seminar.getSTART_DATE());
                tv_end_date.setText(seminar.getEND_DATE());
                tv_price.setText(seminar.getPRICE() + " " + seminar.getPRICE_COST()+ " AZN");
                tv_address.setText(seminar.getADDRESS());
                tv_author.setText(seminar.getAUTHOR());
                tv_subject.setText(seminar.getSUBJECT());
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

    }
}
