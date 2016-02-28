package com.atl.events.events_android_app.listview;

import android.app.Activity;
import android.content.Intent;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.TextView;

import com.atl.events.events_android_app.model.Seminar;
import com.atl.events.events_android_app.select_activities.ConcertActivity;
import com.atl.events.events_android_app.R;
import com.atl.events.events_android_app.select_activities.ExhibitionActivity;
import com.atl.events.events_android_app.select_activities.PresentationActivity;
import com.atl.events.events_android_app.select_activities.SeminarActivity;
import com.atl.events.events_android_app.select_activities.SportActivity;
import com.atl.events.events_android_app.select_activities.TheatreActivity;
import com.atl.events.events_android_app.select_activities.TourActivity;

/**
 * Created by Murad on 21-Oct-15.
 */
public class CustomListviewItemClickListener extends Activity implements AdapterView.OnItemClickListener {

    Intent i;

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        String title = ((TextView) view.findViewById(R.id.title)).getText().toString();
        String category_id = ((TextView) view.findViewById(R.id.category_id)).getText().toString();
        String event_id = ((TextView) view.findViewById(R.id.event_id)).getText().toString();
        Log.d("Title: ", title);
        Log.d("Category ID: ", category_id);
        Log.d("Event ID: ", event_id);
        switch (category_id) {
            case "1":  i = new Intent(parent.getContext(),SportActivity.class); break;
            case "2":  i = new Intent(parent.getContext(),ConcertActivity.class); break;
            case "3":  i = new Intent(parent.getContext(),SeminarActivity.class); break;
            case "4":  i = new Intent(parent.getContext(),ExhibitionActivity.class); break;
            case "5":  i = new Intent(parent.getContext(),PresentationActivity.class); break;
            case "6":  i = new Intent(parent.getContext(),TourActivity.class); break;
            case "8":  i = new Intent(parent.getContext(),TheatreActivity.class); break;
        }

        i.putExtra("eventID", event_id);
        parent.getContext().startActivity(i);
    }
}
