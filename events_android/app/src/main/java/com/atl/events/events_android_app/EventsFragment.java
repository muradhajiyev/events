package com.atl.events.events_android_app;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;


import com.atl.events.events_android_app.adapter.SimpleAdapter;
import com.atl.events.events_android_app.network.ConnectionDetector;
import com.atl.events.events_android_app.network.OnLoadingListener;
import com.atl.events.events_android_app.network.Request;

import com.mugen.Mugen;
import com.mugen.MugenCallbacks;
import com.mugen.attachers.BaseAttacher;


import org.w3c.dom.Text;

import java.util.List;

import retrofit.RestAdapter;
import retrofit.RetrofitError;


/**
 * Created by Murad on 13-Oct-15.
 */
public class EventsFragment extends Fragment {

    private BaseAttacher mBaseAttacher;
    OnLoadingListener mListener;
    boolean isLoading = false;
    private View root;
    private SimpleAdapter madapter;
    private Spinner spinner1, spinner2;
    private String category;
    private RecyclerView recyclerView;
    private int page = 1, currentPage = 1, kind;
    private Boolean checkConnection = false;
    ConnectionDetector cd;

    public EventsFragment() {
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnLoadingListener) {
            mListener = (OnLoadingListener) context;
        }
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        root = inflater.inflate(R.layout.fragment_events, container, false);
        spinner1 = (Spinner) root.findViewById(R.id.spinner1);
        spinner2 = (Spinner) root.findViewById(R.id.spinner2);
        recyclerView = (RecyclerView) root.findViewById(R.id.ultimate_recycler_view);
        cd = new ConnectionDetector(getContext());
        checkConnection = cd.isConnectionToInternet();

        LinearLayoutManager layoutManager = new LinearLayoutManager(getActivity());
        layoutManager.setOrientation(LinearLayoutManager.VERTICAL);
        recyclerView.setHasFixedSize(false);
        recyclerView.setLayoutManager(layoutManager);
        recyclerView.setAdapter(madapter = new SimpleAdapter(getContext()));



        ArrayAdapter<CharSequence> adp = ArrayAdapter.createFromResource(getActivity(),
                R.array.categories_array, R.layout.spinner_layout);
        adp.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner1.setAdapter(adp);

        spinner1.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                category = parent.getItemAtPosition(position).toString();
                page = 1; currentPage=1; madapter.reset();
                if (checkConnection){
                    showKindsInSpinner(category, page);
                }else {
                    Toast.makeText(getView().getContext(), "There is no internet connection", Toast.LENGTH_SHORT).show();
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });



        return root;
    }

    @Override
    public void onViewCreated(View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        mBaseAttacher = Mugen.with(recyclerView, new MugenCallbacks() {
            @Override
            public void onLoadMore() {
                switch (category) {
                    case "All Events": getAllEvents(currentPage+1); break;
                    case "Sport": get_sport_kind_events(kind, currentPage + 1); break;
                    case "Concert": get_concert_kind_events(kind, currentPage + 1); break;
                    case "Seminar": get_seminar_kind_events(kind, currentPage + 1); break;
                    case "Exhibition": get_exhibition_kind_events(kind, currentPage + 1); break;
                    case "Presentation": get_presentation_kind_events(kind, currentPage + 1); break;
                    case "Tour": get_tour_kind_events(kind, currentPage + 1); break;
                    case "Theatre": get_theatre_kind_events(kind, currentPage + 1); break;
                }

            }

            @Override
            public boolean isLoading() {
                return isLoading;
            }

            @Override
            public boolean hasLoadedAllItems() {
                return false;
            }
        }).start();


    }



    public void showKindsInSpinner(String category, final int page) {
        switch (category) {
            case "All Events":  //madapter.reset();
                getAllEvents(page);
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
                        kind = position+1; madapter.reset();
                        get_sport_kind_events(kind, page);
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
                        kind = position+21; madapter.reset();
                        get_concert_kind_events(kind,page);
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
                        kind = position+1;  madapter.reset();
                        get_exhibition_kind_events(kind,page);
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
                        kind = position+1; madapter.reset();
                        get_theatre_kind_events(kind,page);
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
                        kind = position+1; madapter.reset();
                        get_seminar_kind_events(kind,page);
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
                        kind = position+1;  madapter.reset();
                        get_tour_kind_events(kind,page);
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
                        kind = position+1; madapter.reset();
                        get_presentation_kind_events(kind,page);
                    }

                    @Override
                    public void onNothingSelected(AdapterView<?> parent) {

                    }
                });
                break;
        }

    }


    public void getAllEvents(final int page) {

        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }
            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                try {
                    return Request.getData().getAll(params[0]);
                }catch(RetrofitError ex){

                    return null;
                }

            }

            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null){
                    madapter.onNext(events,page); }
                else{
                    Toast.makeText(getView().getContext(), "Couldn't load feed", Toast.LENGTH_SHORT).show();
                }

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }


        }.execute(page);

    }


    public void get_sport_kind_events(final int kindID, final int page) {
        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }


            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                return Request.getData().getSport(params[0], kindID);
            }

            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null)
                    madapter.onNext(events,page);

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }
        }.execute(page);

    }
    public void get_concert_kind_events(final int kindID, final int page) {
        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }


            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                return Request.getData().getConcert(params[0], kindID);
            }

            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null)
                    madapter.onNext(events,page);

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }
        }.execute(page);

    }
    public void get_exhibition_kind_events(final int kindID, final int page) {
        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }


            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                return Request.getData().getExhibition(params[0], kindID);
            }

            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null)
                    madapter.onNext(events,page);

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }
        }.execute(page);

    }
    public void get_theatre_kind_events(final int kindID, final int page) {
        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }


            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                return Request.getData().getTheatre(params[0], kindID);
            }

            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null)
                    madapter.onNext(events,page);

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }
        }.execute(page);

    }
    public void get_seminar_kind_events(final int kindID, final int page) {
        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }


            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                return Request.getData().getSeminar(params[0], kindID);
            }

            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null)
                    madapter.onNext(events,page);

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }
        }.execute(page);

    }
    public void get_tour_kind_events(final int kindID, final int page) {
        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }


            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                return Request.getData().getTour(params[0], kindID);
            }


            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null)
                    madapter.onNext(events,page);

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }
        }.execute(page);

    }
    public void get_presentation_kind_events(final int kindID, final int page) {
        new AsyncTask<Integer, Void, Request.CoreModel>() {
            @Override
            protected void onPreExecute() {
                super.onPreExecute();
                if (mListener != null) {
                    // to demo loading
                    mListener.onLoadingStarted();
                }


            }

            @Override
            protected Request.CoreModel doInBackground(Integer... params) {
                isLoading = true;

                return Request.getData().getPresentation(params[0], kindID);
            }

            @Override
            protected void onPostExecute(Request.CoreModel events) {
                isLoading=false;
                if (events!=null)
                    madapter.onNext(events,page);

                if (mListener!=null)
                    mListener.onLoadingFinished();

                currentPage=page;
            }
        }.execute(page);

    }






}
