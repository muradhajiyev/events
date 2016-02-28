package com.atl.events.events_android_app.network;

import com.atl.events.events_android_app.domain.allevents_domain;
import com.atl.events.events_android_app.domain.kindevents_domain;
import com.atl.events.events_android_app.domain.select_domain;
import com.atl.events.events_android_app.model.Concert;
import com.atl.events.events_android_app.model.Event;
import com.atl.events.events_android_app.model.Exhibition;
import com.atl.events.events_android_app.model.Presentation;
import com.atl.events.events_android_app.model.Seminar;
import com.atl.events.events_android_app.model.Sport;
import com.atl.events.events_android_app.model.Theatre;
import com.atl.events.events_android_app.model.Tour;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.POST;

/**
 * Created by Murad on 27-Oct-15.
 */
public interface api {

    // get All Events
    @POST("/api/Events/get_all_events")
    public void getAllEvents(@Body allevents_domain obj, Callback<List<Event>> response);

    // get Events by kind
    @POST("/api/Events/kind_sport")
    public void getSportEvents(@Body kindevents_domain obj, Callback<List<Event>> response);

    @POST("/api/Events/kind_concert")
    public void getConcertEvents(@Body kindevents_domain obj, Callback<List<Event>> response);

    @POST("/api/Events/kind_exhibition")
    public void getExhibitionEvents(@Body kindevents_domain obj, Callback<List<Event>> response);

    @POST("/api/Events/kind_presentation")
    public void getPresentationEvents(@Body kindevents_domain obj, Callback<List<Event>> response);

    @POST("/api/Events/kind_theatre")
    public void getTheatreEvents(@Body kindevents_domain obj, Callback<List<Event>> response);

    @POST("/api/Events/kind_seminar")
    public void getSeminarEvents(@Body kindevents_domain obj, Callback<List<Event>> response);

    @POST("/api/Events/kind_tour")
    public void getTourEvents(@Body kindevents_domain obj, Callback<List<Event>> response);



    // Select Events

    @POST("/api/Events/select_sport_event")
    public void selectSport(@Body select_domain obj, Callback<Sport> response);

    @POST("/api/Events/select_concert_event")
    public void selectConcert(@Body select_domain obj, Callback<Concert> response);

    @POST("/api/Events/select_exhibition_event")
    public void selectExhibition(@Body select_domain obj, Callback<Exhibition> response);

    @POST("/api/Events/select_presentation_event")
    public void selectPresentation(@Body select_domain obj, Callback<Presentation> response);

    @POST("/api/Events/select_seminar_event")
    public void selectSeminar(@Body select_domain obj, Callback<Seminar> response);

    @POST("/api/Events/select_theatre_event")
    public void selectTheatre(@Body select_domain obj, Callback<Theatre> response);

    @POST("/api/Events/select_tour_event")
    public void selectTour(@Body select_domain obj, Callback<Tour> response);
}
