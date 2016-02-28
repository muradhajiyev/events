package com.atl.events.events_android_app.domain;

/**
 * Created by Murad on 27-Oct-15.
 */
public class allevents_domain {

    final int startPosition;
    final int pageSize;


    public allevents_domain(int startPosition, int pageSize) {
        this.startPosition = startPosition;
        this.pageSize = pageSize;
    }
}
