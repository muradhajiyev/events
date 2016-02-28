package com.atl.events.events_android_app.adapter;

import android.app.Activity;
import android.content.Context;
import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;


import com.atl.events.events_android_app.R;
import com.atl.events.events_android_app.business_logic.Webservice_urls;
import com.atl.events.events_android_app.model.Event;
import com.squareup.picasso.Picasso;

import org.w3c.dom.Text;

import java.util.List;

/**
 * Created by Murad on 18-Oct-15.
 */
public class CustomListAdapter extends ArrayAdapter<Event> {

    private Context context;
    private LayoutInflater inflater;
    public List<Event> eventList;


    public CustomListAdapter(Context context, int resource,  List<Event> eventList) {
        super(context,resource, eventList);
        this.context = context;
        this.eventList = eventList;
    }



    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        if (inflater == null)
            inflater = (LayoutInflater) context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        if (convertView == null)
            convertView = inflater.inflate(R.layout.list_row, null);
        ImageView image = (ImageView) convertView.findViewById(R.id.thumbnail);
        TextView title = (TextView) convertView.findViewById(R.id.title);
        TextView startDate = (TextView) convertView.findViewById(R.id.startDate);
        TextView categoryID = (TextView) convertView.findViewById(R.id.category_id);
        TextView eventID = (TextView) convertView.findViewById(R.id.event_id);


        // getting event data for the row
        Event event = (Event) getItem(position);

        // title
        title.setText(event.getTITLE());

        // logo image
        Picasso.with(parent.getContext()).load(Webservice_urls.image_url+event.getLOGO_NAME()).resize(100,100).into(image);

        // startDate year
        startDate.setText(event.getSTART_DATE());

        // categoryID
        categoryID.setText(String.valueOf(event.getCATEGORY_ID()));

        // eventID
        eventID.setText(String.valueOf(event.getID()));

        return convertView;
    }
}
