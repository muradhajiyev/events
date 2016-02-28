package com.atl.events.events_android_app;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Toast;


import com.atl.events.events_android_app.adapter.CustomListAdapter;
import com.atl.events.events_android_app.domain.allevents_domain;
import com.atl.events.events_android_app.domain.kindevents_domain;
import com.atl.events.events_android_app.listview.CustomListviewItemClickListener;
import com.atl.events.events_android_app.model.Event;
import com.atl.events.events_android_app.network.api;
import com.orangegangsters.github.swipyrefreshlayout.library.SwipyRefreshLayout;
import com.orangegangsters.github.swipyrefreshlayout.library.SwipyRefreshLayoutDirection;


import java.util.ArrayList;
import java.util.List;

import retrofit.Callback;
import retrofit.RestAdapter;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * Created by Murad on 13-Oct-15.
 */
public class EventsFragment extends Fragment {

    // Log tag
    private static final String TAG = MainActivity.class.getSimpleName();
    private View root;
    private ProgressDialog pDialog;
    private SwipyRefreshLayout mSwipyRefreshLayout;
    private ListView listView;
    private CustomListAdapter adapter;
    private Spinner spinner2;
    private List<Event> eventList = new ArrayList<Event>();
    private String category;
    private final int pageSize = 9;
    private int startPos = 1,  lastPos = pageSize, kind;

    public int currentFirstVisibleItem, currentVisibleItemCount, currentScrollState;

    final RestAdapter restAdapter = new RestAdapter.Builder()
            .setEndpoint("http://10.50.93.110/events").build();
    api eventsapi = restAdapter.create(api.class);

    public EventsFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        root = inflater.inflate(R.layout.fragment_events, container, false);
        listView = (ListView) root.findViewById(R.id.list);
        spinner2 = (Spinner) root.findViewById(R.id.spinner2);
        pDialog = new ProgressDialog(getActivity());
        pDialog.setMessage("Loading...");
        pDialog.setCancelable(false);

        Spinner spinner1 = (Spinner) root.findViewById(R.id.spinner1);
        ArrayAdapter<CharSequence> adp = ArrayAdapter.createFromResource(getActivity(),
                R.array.categories_array, R.layout.spinner_layout);
        adp.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner1.setAdapter(adp);

        spinner1.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                category = parent.getItemAtPosition(position).toString();
                startPos=1; lastPos = pageSize;
                showKindsInSpinner(category, startPos, pageSize);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        listView.setOnItemClickListener(new CustomListviewItemClickListener());
        listView.setOnScrollListener(new AbsListView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(AbsListView view, int scrollState) {
                currentScrollState = scrollState;
                //isScrollCompleted();
            }

            @Override
            public void onScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount) {
                currentFirstVisibleItem = firstVisibleItem;
                currentVisibleItemCount = visibleItemCount;
            }
        });

        mSwipyRefreshLayout = (SwipyRefreshLayout) root.findViewById(R.id.swipyrefreshlayout);
        mSwipyRefreshLayout.setDirection(SwipyRefreshLayoutDirection.BOTTOM);
        mSwipyRefreshLayout.setOnRefreshListener(new SwipyRefreshLayout.OnRefreshListener() {
            @Override
            public void onRefresh(SwipyRefreshLayoutDirection swipyRefreshLayoutDirection) {
                loadMore();
            }
        });

        return root;
    }

    private void isScrollCompleted() {
        if (currentFirstVisibleItem >0 && currentScrollState == AbsListView.OnScrollListener.SCROLL_STATE_IDLE)
            loadMore();
    }


    public void showKindsInSpinner(String category, final int startPos, final int pageSize) {
        switch (category) {
            case "All Events": getAllEvents(startPos, pageSize);
                spinner2.setAdapter(null);
                break;
            case "Sport":
                ArrayAdapter<CharSequence> adp_sport = ArrayAdapter.createFromResource(getActivity(),
                        R.array.sport_kinds_array, R.layout.spinner_layout);
                adp_sport.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner2.setAdapter(adp_sport);
                spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                        kind = position+1;
                        get_sport_kind_events(kind, startPos, pageSize);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });

                break;
            case "Concert":
                ArrayAdapter<CharSequence> adp_concert = ArrayAdapter.createFromResource(getActivity(),
                        R.array.concert_kinds_array, R.layout.spinner_layout);
                adp_concert.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner2.setAdapter(adp_concert);
                spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                        kind = position+21;
                        get_concert_kind_events(kind,startPos,pageSize);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });
                break;
            case "Exhibition":
                ArrayAdapter<CharSequence> adp_exhibition = ArrayAdapter.createFromResource(getActivity(),
                        R.array.exhibition_kinds_array, R.layout.spinner_layout);
                adp_exhibition.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner2.setAdapter(adp_exhibition);
                spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                        kind = position+1;
                        get_exhibition_kind_events(kind,startPos,pageSize);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });
                break;
            case "Theatre":
                ArrayAdapter<CharSequence> adp_theatre = ArrayAdapter.createFromResource(getActivity(),
                        R.array.theatre_kinds_array, R.layout.spinner_layout);
                adp_theatre.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner2.setAdapter(adp_theatre);
                spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                        kind = position+1;
                        get_theatre_kind_events(kind,startPos,pageSize);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });
                break;
            case "Seminar":
                ArrayAdapter<CharSequence> adp_seminar = ArrayAdapter.createFromResource(getActivity(),
                        R.array.seminar_kinds_array, R.layout.spinner_layout);
                adp_seminar.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner2.setAdapter(adp_seminar);
                spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                        kind = position+1;
                        get_seminar_kind_events(kind,startPos,pageSize);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });
                break;
            case "Tour":
                ArrayAdapter<CharSequence> adp_tour = ArrayAdapter.createFromResource(getActivity(),
                        R.array.tour_kinds_array, R.layout.spinner_layout);
                adp_tour.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner2.setAdapter(adp_tour);
                spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                        kind = position+1;
                        get_tour_kind_events(kind,startPos,pageSize);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });
                break;
            case "Presentation":
                ArrayAdapter<CharSequence> adp_presentation = ArrayAdapter.createFromResource(getActivity(),
                        R.array.presentation_kinds_array, R.layout.spinner_layout);
                adp_presentation.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner2.setAdapter(adp_presentation);
                spinner2.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                        kind = position+1;
                        get_presentation_kind_events(kind,startPos,pageSize);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });
                break;
        }

    }

    private void loadMore() {
        switch (category) {
            case "All Events":  startPos=lastPos+1; lastPos +=pageSize;
                        getAllEvents(startPos, pageSize);
                break;
            case "Sport":
                        startPos=lastPos+1; lastPos +=pageSize;
                        get_sport_kind_events(kind,startPos,pageSize);
                break;
            case "Concert": startPos=lastPos+1; lastPos +=pageSize;
                        get_concert_kind_events(kind,startPos,pageSize);
                break;
            case "Exhibition": startPos=lastPos+1; lastPos +=pageSize;
                        get_exhibition_kind_events(kind,startPos, pageSize);
                break;
            case "Theatre": startPos=lastPos+1; lastPos +=pageSize;
                        get_theatre_kind_events(kind,startPos, pageSize);
                break;
            case "Seminar": startPos=lastPos+1; lastPos +=pageSize;
                        get_seminar_kind_events(kind,startPos, pageSize);
                break;
            case "Tour": startPos=lastPos+1; lastPos +=pageSize;;
                        get_tour_kind_events(kind,startPos, pageSize);
                break;
            case "Presentation": startPos=lastPos+1; lastPos +=pageSize;
                        get_presentation_kind_events(kind,startPos, pageSize);
                break;
        }
    }

    public void getAllEvents(int startPos, int pageSize) {
        showpDialog();
        eventsapi.getAllEvents(new allevents_domain(startPos, pageSize), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                for (int i=0; i<events.size(); i++) {
                    eventList.add(events.get(i));
                }
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, eventList);
                listView.setAdapter(adapter);
                listView.setSelectionFromTop(lastPos, 0);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(),"Failed",Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });
        
        

    }

    public void get_sport_kind_events(int kindID, int startPos, int pageSize) {
        showpDialog();
        eventsapi.getSportEvents(new kindevents_domain(startPos, pageSize, kindID), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, events);
                listView.setAdapter(adapter);
                listView.setSelectionFromTop(lastPos,3);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(),"Failed",Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });

    }
    public void get_concert_kind_events(int kindID, int startPos, int pageSize) {
        showpDialog();
        eventsapi.getConcertEvents(new kindevents_domain(startPos, pageSize, kindID), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, events);
                listView.setAdapter(adapter);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(), "Failed", Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });

    }
    public void get_exhibition_kind_events(int kindID, int startPos, int pageSize) {
        showpDialog();
        eventsapi.getExhibitionEvents(new kindevents_domain(startPos, pageSize, kindID), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, events);
                listView.setAdapter(adapter);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(), "Failed", Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });


    }
    public void get_theatre_kind_events(int kindID, int startPos, int pageSize) {
        showpDialog();
        eventsapi.getTheatreEvents(new kindevents_domain(startPos, pageSize, kindID), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, events);
                listView.setAdapter(adapter);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(), "Failed", Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });
    }
    public void get_seminar_kind_events(int kindID, int startPos, int pageSize) {
        showpDialog();
        eventsapi.getSeminarEvents(new kindevents_domain(startPos, pageSize, kindID), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, events);
                listView.setAdapter(adapter);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(), "Failed", Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });
    }
    public void get_tour_kind_events(int kindID, int startPos, int pageSize) {
        showpDialog();
        eventsapi.getTourEvents(new kindevents_domain(startPos, pageSize, kindID), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, events);
                listView.setAdapter(adapter);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(), "Failed", Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });
    }
    public void get_presentation_kind_events(int kindID, int startPos, int pageSize) {
        showpDialog();
        eventsapi.getPresentationEvents(new kindevents_domain(startPos, pageSize, kindID), new Callback<List<Event>>() {
            @Override
            public void success(List<Event> events, Response response) {
                CustomListAdapter adapter = new CustomListAdapter(getContext(), R.layout.list_row, events);
                listView.setAdapter(adapter);
                Log.d("CHECK", "Success");
                hidepDialog();
            }

            @Override
            public void failure(RetrofitError error) {
                Toast.makeText(getContext(), "Failed", Toast.LENGTH_SHORT).show();
                Log.d("CHECK", "ERROR");
                hidepDialog();
            }
        });
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        hidepDialog();

    }

    private void showpDialog() {
        if(!pDialog.isShowing()) {
            pDialog.show();
        }
    }

    private void hidepDialog(){
        if (pDialog.isShowing())
            pDialog.dismiss();
    }

    private void showErrorDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setTitle("Error");
        builder.setMessage("Something went wrong. Please try again");
            builder.create().show();
    }


}
