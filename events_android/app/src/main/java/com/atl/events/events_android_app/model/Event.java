package com.atl.events.events_android_app.model;



import java.util.ArrayList;

/**
 * Created by Murad on 18-Oct-15.
 */
public class Event {

    /**
     * ID : 18
     * CATEGORY_ID : 2
     * LOGO_NAME : concert.jpeg
     * START_DATE : 12/12/2012 11:21
     * CREATED_DATE : 10/9/2015 2:42:23 PM
     * TITLE : test Concert title
     */

    private int ID;
    private int CATEGORY_ID;
    private String LOGO_NAME;
    private String START_DATE;
    private String CREATED_DATE;
    private String TITLE;

    public void setID(int ID) {
        this.ID = ID;
    }

    public void setCATEGORY_ID(int CATEGORY_ID) {
        this.CATEGORY_ID = CATEGORY_ID;
    }

    public void setLOGO_NAME(String LOGO_NAME) {
        this.LOGO_NAME = LOGO_NAME;
    }

    public void setSTART_DATE(String START_DATE) {
        this.START_DATE = START_DATE;
    }

    public void setCREATED_DATE(String CREATED_DATE) {
        this.CREATED_DATE = CREATED_DATE;
    }

    public void setTITLE(String TITLE) {
        this.TITLE = TITLE;
    }

    public int getID() {
        return ID;
    }

    public int getCATEGORY_ID() {
        return CATEGORY_ID;
    }

    public String getLOGO_NAME() {
        return LOGO_NAME;
    }

    public String getSTART_DATE() {
        return START_DATE;
    }

    public String getCREATED_DATE() {
        return CREATED_DATE;
    }

    public String getTITLE() {
        return TITLE;
    }
}
