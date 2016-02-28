package com.atl.events.events_android_app;
import android.os.Bundle;

import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.view.ViewParent;
import android.widget.ProgressBar;

import com.atl.events.events_android_app.network.OnLoadingListener;


/**
 * Created by Murad on 13-Oct-15.
 */
public class MainActivity extends AppCompatActivity implements OnLoadingListener{

    private static final String TAG = "MainActivity.class";

    //horizontal progressbar to show while loading..
    private ProgressBar mProgressBar;

    private Toolbar toolbar;
    private TabLayout tabLayout;
    private ViewPager viewPager;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_activity);

        mProgressBar = (ProgressBar) findViewById(R.id.progressBar);

        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(false);

        viewPager = (ViewPager) findViewById(R.id.viewpager);
        setupViewPager(viewPager);
        //viewPager.setCurrentItem(1);

        tabLayout = (TabLayout) findViewById(R.id.tabs);
        tabLayout.setupWithViewPager(viewPager);
    }

    private void setupViewPager(ViewPager viewPager) {
        ViewPagerAdapter adapter = new ViewPagerAdapter(getSupportFragmentManager());
        //adapter.addFragment(new NewsFragment(), "News");
        adapter.addFragment(new EventsFragment(), "Events");
        adapter.addFragment(new AboutFragment(), "Contact");
        viewPager.setAdapter(adapter);
    }


    @Override
    public void onLoadingStarted() {
        mProgressBar.setVisibility(View.VISIBLE);
    }

    @Override
    public void onLoadingFinished() {
        mProgressBar.setVisibility(View.GONE);
    }
}
