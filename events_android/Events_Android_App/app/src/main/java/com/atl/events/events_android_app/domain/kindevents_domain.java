package com.atl.events.events_android_app.domain;

/**
 * Created by Murad on 27-Oct-15.
 */
public class kindevents_domain {

    final int startPosition;
    final int pageSize;
    final int KIND_ID;

    public kindevents_domain(int startPosition, int pageSize, int KIND_ID) {
        this.startPosition = startPosition;
        this.pageSize = pageSize;
        this.KIND_ID = KIND_ID;
    }
}
