package com.atl.events.events_android_app.business_logic;

/**
 * Created by Murad on 19-Oct-15.
 */
public class Webservice_urls {

    public static final String server_ip = "http://10.50.93.110/events/";

    public static String image_url = "http://10.50.93.110/images/";

    // Events json url
    public static final String url_events = server_ip + "/api/Events/get_all_events";

    public static final String sport_events_url = server_ip + "api/Events/get_sport_events";
    public static final String concert_events_url = server_ip + "api/Events/select_concert_event";
    public static final String seminar_events_url = server_ip + "api/Events/select_seminar_event";
    public static final String exhibition_events_url = server_ip + "api/Events/select_exhibition_event";
    public static final String presentation_events_url = server_ip + "api/Events/select_presentation_event";
    public static final String tour_events_url = server_ip + "api/Events/select_tour_event";
    public static final String theatre_events_url = server_ip + "api/Events/select_theatre_event";

    public static final String sport_kinds_events_url = server_ip + "api/Events/kind_sport";
    public static final String concert_kinds_events_url = server_ip + "api/Events/kind_concert";
    public static final String exhibition_kinds_events_url = server_ip + "api/Events/kind_exhibition";
    public static final String theatre_kinds_events_url = server_ip + "api/Events/kind_theatre";
    public static final String seminar_kinds_events_url = server_ip + "api/Events/kind_seminar";
    public static final String tour_kinds_events_url = server_ip + "api/Events/kind_tour";
    public static final String presentation_kinds_events_url = server_ip + "api/Events/kind_presentation";

    public static final String select_sport_event_url = server_ip + "api/Events/select_sport_event";

}
