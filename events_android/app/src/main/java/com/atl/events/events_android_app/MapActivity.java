package com.atl.events.events_android_app;

import android.app.Activity;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;

/**
 * Created by Murad on 04-Nov-15.
 */
public class MapActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.map);

        final Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        toolbar.setTitleTextColor(getResources().getColor(android.R.color.white));
        toolbar.setTitle("Full Map View");
        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);


        double lat = Double.parseDouble(getIntent().getExtras().getString("lat"));
        double lon = Double.parseDouble(getIntent().getExtras().getString("lon"));
        String address = getIntent().getExtras().getString("address");

        final LatLng position = new LatLng(lat,lon);
        final GoogleMap map = ((MapFragment) getFragmentManager().findFragmentById(R.id.map)).getMap();
        MarkerOptions markerOptions = new MarkerOptions().position(position).title(address);
        Marker marker = map.addMarker(markerOptions);
        // zoom in the camera to Davao city
        map.moveCamera(CameraUpdateFactory.newLatLngZoom(position, 5));
        // animate the zoom process
        map.animateCamera(CameraUpdateFactory.zoomTo(5), 5000, null);
        map.setMyLocationEnabled(true);

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home){
            this.finish();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
