package com.atl.events.events_android_app.adapter;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.atl.events.events_android_app.R;
import com.atl.events.events_android_app.network.Request;
import com.atl.events.events_android_app.select_activities.ConcertActivity;
import com.atl.events.events_android_app.select_activities.ExhibitionActivity;
import com.atl.events.events_android_app.select_activities.PresentationActivity;
import com.atl.events.events_android_app.select_activities.SeminarActivity;
import com.atl.events.events_android_app.select_activities.SportActivity;
import com.atl.events.events_android_app.select_activities.TheatreActivity;
import com.atl.events.events_android_app.select_activities.TourActivity;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;

/**
 * Created by Murad on 03-Nov-15.
 */
public class SimpleAdapter extends RecyclerView.Adapter<SimpleAdapter.EventHolder> {

    LinkedHashMap<Integer, List<Request.Event>> Map;
    List<Request.Event> eventList;
    Context context;
    LayoutInflater inflater;
    private int lastPosition = -1;
    Intent i;

    public SimpleAdapter(Context context) {
        Map = new LinkedHashMap<Integer, List<Request.Event>>();
        eventList = new ArrayList<Request.Event>();
        this.context = context;
        inflater = LayoutInflater.from(context);
    }

    public class EventHolder extends RecyclerView.ViewHolder {

        TextView title, startDate, categoryID, eventID;
        ImageView image;
        RelativeLayout container;

        public EventHolder(final View itemView) {
            super(itemView);

            image = (ImageView) itemView.findViewById(R.id.thumbnail);
            title = (TextView) itemView.findViewById(R.id.title);
            startDate = (TextView) itemView.findViewById(R.id.startDate);
            categoryID = (TextView) itemView.findViewById(R.id.category_id);
            eventID = (TextView) itemView.findViewById(R.id.event_id);
            container = (RelativeLayout) itemView.findViewById(R.id.container);

            itemView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {

                    switch (categoryID.getText().toString()) {
                        case "1":  i = new Intent(v.getContext(),SportActivity.class); break;
                        case "2":  i = new Intent(v.getContext(),ConcertActivity.class); break;
                        case "3":  i = new Intent(v.getContext(),SeminarActivity.class); break;
                        case "4":  i = new Intent(v.getContext(),ExhibitionActivity.class); break;
                        case "5":  i = new Intent(v.getContext(),PresentationActivity.class); break;
                        case "6":  i = new Intent(v.getContext(),TourActivity.class); break;
                        case "8":  i = new Intent(v.getContext(),TheatreActivity.class); break;
                    }

                    i.putExtra("eventID", eventID.getText());
                    v.getContext().startActivity(i);

                }
            });
        }

        public void loadEvent(Request.Event event){
            title.setText(event.TITLE);
            startDate.setText(event.START_DATE);
            categoryID.setText(String.valueOf(event.CATEGORY_ID));
            eventID.setText(String.valueOf(event.ID));

            Picasso.with(image.getContext())
                    .load(Request.image_url+event.LOGO_NAME)
                    .resize(200,200)
                    .error(R.drawable.error)
                    .placeholder(R.drawable.ic_github_placeholder)
                    .centerCrop()
                    .into(image);
        }
    }

    @Override
    public void onBindViewHolder(EventHolder holder, int position) {
        Request.Event event = getItem(position);
        if (event == null)
            return;
        holder.loadEvent(event);
        //setAnimation(holder.container, position);
    }


    @Override
    public EventHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = inflater.inflate(R.layout.list_row, parent, false);
        return new EventHolder(view);
    }

    @Override
    public int getItemCount() {
        int count = 0;

        for (List<Request.Event> list : Map.values()) {
            count = count + list.size();
        }

        return count;
    }

    private Request.Event getItem(int position) {
        int listSize = 0;

        if (eventList.size()>position)
        return eventList.get(position);

        eventList = new ArrayList<Request.Event>();
        for (List<Request.Event> list : Map.values()) {
            eventList.addAll(list);
            listSize = listSize + list.size();
            if (listSize>position)
                break;
        }

        if (eventList.size()>0)
            return eventList.get(position);

            return null;
    }

    public void onNext(Request.CoreModel events, int page) {
        if (events == null)
            return;

        Map.put(page, events.events);
        notifyDataSetChanged();
    }

    public void reset(){
        Map.clear();
        eventList.clear();
    }

    private void setAnimation(View viewToAnimate, int position)
    {
        // If the bound view wasn't previously displayed on screen, it's animated
        if (position > lastPosition)
        {
            Animation animation = AnimationUtils.loadAnimation(context, android.R.anim.slide_in_left);
            viewToAnimate.startAnimation(animation);
            lastPosition = position;
        }
    }
}
