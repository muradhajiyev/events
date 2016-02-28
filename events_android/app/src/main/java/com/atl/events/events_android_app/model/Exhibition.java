package com.atl.events.events_android_app.model;

/**
 * Created by Murad on 27-Oct-15.
 */
public class Exhibition {


    /**
     * ID : 41
     * CATEGORY_ID : 4
     * AUTHOR : test
     * ADDRESS : test
     * DESCRIPTION : test
     * PRICE : test
     * PRICE_COST : 12
     * LOGO_NAME : test
     * LONGITUDE : 12.0
     * LATITUDE : 12.0
     * START_DATE : 1212
     * END_DATE : 1212
     * CREATED_DATE : null
     * UPDATED_DATE : null
     * DELETED_DATE : null
     * KIND_ID : 1
     * TITLE : test
     * CREATED_BY : 0
     * STATUS : 0
     * UPDATED_BY : 0
     * NAME_CREATED_BY : Murad
     * EXHIBITION_KIND : Education
     * CATEGORY : Exhibition
     * startPosition : null
     * pageSize : null
     */

    private int ID;
    private int CATEGORY_ID;
    private String AUTHOR;
    private String ADDRESS;
    private String DESCRIPTION;
    private String PRICE;
    private String PRICE_COST;
    private String LOGO_NAME;
    private double LONGITUDE;
    private double LATITUDE;
    private String START_DATE;
    private String END_DATE;
    private Object CREATED_DATE;
    private Object UPDATED_DATE;
    private Object DELETED_DATE;
    private int KIND_ID;
    private String TITLE;
    private int CREATED_BY;
    private int STATUS;
    private int UPDATED_BY;
    private String NAME_CREATED_BY;
    private String EXHIBITION_KIND;
    private String CATEGORY;
    private Object startPosition;
    private Object pageSize;

    public void setID(int ID) {
        this.ID = ID;
    }

    public void setCATEGORY_ID(int CATEGORY_ID) {
        this.CATEGORY_ID = CATEGORY_ID;
    }

    public void setAUTHOR(String AUTHOR) {
        this.AUTHOR = AUTHOR;
    }

    public void setADDRESS(String ADDRESS) {
        this.ADDRESS = ADDRESS;
    }

    public void setDESCRIPTION(String DESCRIPTION) {
        this.DESCRIPTION = DESCRIPTION;
    }

    public void setPRICE(String PRICE) {
        this.PRICE = PRICE;
    }

    public void setPRICE_COST(String PRICE_COST) {
        this.PRICE_COST = PRICE_COST;
    }

    public void setLOGO_NAME(String LOGO_NAME) {
        this.LOGO_NAME = LOGO_NAME;
    }

    public void setLONGITUDE(double LONGITUDE) {
        this.LONGITUDE = LONGITUDE;
    }

    public void setLATITUDE(double LATITUDE) {
        this.LATITUDE = LATITUDE;
    }

    public void setSTART_DATE(String START_DATE) {
        this.START_DATE = START_DATE;
    }

    public void setEND_DATE(String END_DATE) {
        this.END_DATE = END_DATE;
    }

    public void setCREATED_DATE(Object CREATED_DATE) {
        this.CREATED_DATE = CREATED_DATE;
    }

    public void setUPDATED_DATE(Object UPDATED_DATE) {
        this.UPDATED_DATE = UPDATED_DATE;
    }

    public void setDELETED_DATE(Object DELETED_DATE) {
        this.DELETED_DATE = DELETED_DATE;
    }

    public void setKIND_ID(int KIND_ID) {
        this.KIND_ID = KIND_ID;
    }

    public void setTITLE(String TITLE) {
        this.TITLE = TITLE;
    }

    public void setCREATED_BY(int CREATED_BY) {
        this.CREATED_BY = CREATED_BY;
    }

    public void setSTATUS(int STATUS) {
        this.STATUS = STATUS;
    }

    public void setUPDATED_BY(int UPDATED_BY) {
        this.UPDATED_BY = UPDATED_BY;
    }

    public void setNAME_CREATED_BY(String NAME_CREATED_BY) {
        this.NAME_CREATED_BY = NAME_CREATED_BY;
    }

    public void setEXHIBITION_KIND(String EXHIBITION_KIND) {
        this.EXHIBITION_KIND = EXHIBITION_KIND;
    }

    public void setCATEGORY(String CATEGORY) {
        this.CATEGORY = CATEGORY;
    }

    public void setStartPosition(Object startPosition) {
        this.startPosition = startPosition;
    }

    public void setPageSize(Object pageSize) {
        this.pageSize = pageSize;
    }

    public int getID() {
        return ID;
    }

    public int getCATEGORY_ID() {
        return CATEGORY_ID;
    }

    public String getAUTHOR() {
        return AUTHOR;
    }

    public String getADDRESS() {
        return ADDRESS;
    }

    public String getDESCRIPTION() {
        return DESCRIPTION;
    }

    public String getPRICE() {
        return PRICE;
    }

    public String getPRICE_COST() {
        return PRICE_COST;
    }

    public String getLOGO_NAME() {
        return LOGO_NAME;
    }

    public double getLONGITUDE() {
        return LONGITUDE;
    }

    public double getLATITUDE() {
        return LATITUDE;
    }

    public String getSTART_DATE() {
        return START_DATE;
    }

    public String getEND_DATE() {
        return END_DATE;
    }

    public Object getCREATED_DATE() {
        return CREATED_DATE;
    }

    public Object getUPDATED_DATE() {
        return UPDATED_DATE;
    }

    public Object getDELETED_DATE() {
        return DELETED_DATE;
    }

    public int getKIND_ID() {
        return KIND_ID;
    }

    public String getTITLE() {
        return TITLE;
    }

    public int getCREATED_BY() {
        return CREATED_BY;
    }

    public int getSTATUS() {
        return STATUS;
    }

    public int getUPDATED_BY() {
        return UPDATED_BY;
    }

    public String getNAME_CREATED_BY() {
        return NAME_CREATED_BY;
    }

    public String getEXHIBITION_KIND() {
        return EXHIBITION_KIND;
    }

    public String getCATEGORY() {
        return CATEGORY;
    }

    public Object getStartPosition() {
        return startPosition;
    }

    public Object getPageSize() {
        return pageSize;
    }
}
