package com.atl.events.events_android_app.network;

import com.atl.events.events_android_app.model.Concert;
import com.atl.events.events_android_app.model.Exhibition;
import com.atl.events.events_android_app.model.Presentation;
import com.atl.events.events_android_app.model.Seminar;
import com.atl.events.events_android_app.model.Sport;
import com.atl.events.events_android_app.model.Theatre;
import com.atl.events.events_android_app.model.Tour;

import java.util.List;

import retrofit.RestAdapter;
import retrofit.http.Field;
import retrofit.http.FormUrlEncoded;
import retrofit.http.POST;
import retrofit.http.Query;

/**
 * Created by Murad on 03-Nov-15.
 */
public class Request {

    //events api url
    private static final String API_URL = "http://10.50.3.83/eventservices/";

    // events image url
    public static String image_url = "http://10.50.3.83/eventservices/UploadedFiles/";


    static public class Event {

        public int ID;
        public int CATEGORY_ID;
        public String LOGO_NAME;
        public String START_DATE;
        public String CREATED_DATE;
        public String TITLE;
    }

    static public class CoreModel {
        public int events_count;
        public List<Event> events;
    }

    public interface webservices {
        @FormUrlEncoded
        @POST("/api/Events/get_all_events")
        CoreModel getAll(@Field("PAGE") int page);

        @FormUrlEncoded
        @POST("/api/Events/kind_sport")
        CoreModel getSport(@Field("PAGE") int page,
                             @Field("KIND_ID") int kind);

        @FormUrlEncoded
        @POST("/api/Events/kind_concert")
        CoreModel getConcert(@Field("PAGE") int page,
                             @Field("KIND_ID") int kind);

        @FormUrlEncoded
        @POST("/api/Events/kind_seminar")
        CoreModel getSeminar(@Field("PAGE") int page,
                               @Field("KIND_ID") int kind);

        @FormUrlEncoded
        @POST("/api/Events/kind_exhibition")
        CoreModel getExhibition(@Field("PAGE") int page,
                               @Field("KIND_ID") int kind);

        @FormUrlEncoded
        @POST("/api/Events/kind_presentation")
        CoreModel getPresentation(@Field("PAGE") int page,
                               @Field("KIND_ID") int kind);

        @FormUrlEncoded
        @POST("/api/Events/kind_theatre")
        CoreModel getTheatre(@Field("PAGE") int page,
                               @Field("KIND_ID") int kind);

        @FormUrlEncoded
        @POST("/api/Events/kind_tour")
        CoreModel getTour(@Field("PAGE") int page,
                               @Field("KIND_ID") int kind);

        @FormUrlEncoded
        @POST("/api/Events/select_sport_event")
        Sport selectSport(@Field("ID") String id);

        @FormUrlEncoded
        @POST("/api/Events/select_concert_event")
        Concert selectConcert(@Field("ID") String id);

        @FormUrlEncoded
        @POST("/api/Events/select_exhibition_event")
        Exhibition selectExhibition(@Field("ID") String id);

        @FormUrlEncoded
        @POST("/api/Events/select_theatre_event")
        Theatre selectTheatre(@Field("ID") String id);

        @FormUrlEncoded
        @POST("/api/Events/select_tour_event")
        Tour selectTour(@Field("ID") String id);

        @FormUrlEncoded
        @POST("/api/Events/select_seminar_event")
        Seminar selectSeminar(@Field("ID") String id);

        @FormUrlEncoded
        @POST("/api/Events/select_presentation_event")
        Presentation selectPresentation(@Field("ID") String id);

    }

    public static webservices getData() {
        RestAdapter restAdapter = new RestAdapter.Builder()
                .setEndpoint(API_URL)
                .setLogLevel(RestAdapter.LogLevel.BASIC)
                .build();

        return restAdapter.create(webservices.class);
    }
}
