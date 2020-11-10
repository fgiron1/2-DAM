package com.example.ejercicio1seleccion;

import android.content.Context;
import android.view.*;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class CustomAdapter extends RecyclerView.Adapter<RecyclerView.ViewHolder> {

    private Context context;
    //Choose the most appropriate structure given your dataset
    //A Object[] array is unsafe. Only when a view is recycled and the
    //onBindViewHolder method is called is an object of the array casted
    //as the specific data type (Strings and ints -> TextView.setText() and ImageView.setImageResource())
    private Object[] dataset;



    public CustomAdapter(String[] dataset){
        this.dataset = dataset;
    }

    //We can define as many viewholders as the total number of view types
    // that our list items' contain.

    //I think that the View type on both ViewHolders should be changed to a
    //specific type of view. Otherwise, it would defeat the purpose of
    //having specialized ViewHolders


    //ViewHolder0 - TextView
    public static class ViewHolder0 extends RecyclerView.ViewHolder{
        private TextView view0;

        public ViewHolder0(TextView itemView){
            super(itemView);
            this.view0 = itemView;
        }
    }

    //ViewHolder1 - ImageView
    public static class ViewHolder1 extends RecyclerView.ViewHolder{
        private ImageView view1;

        public ViewHolder1(ImageView itemView){
            super(itemView);
            this.view1 = itemView;
        }
    }

    @NonNull
    @Override
    //
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        RecyclerView.ViewHolder viewHolder = null;
        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        //Views are inflated according to their type, but hold no content yet.
        switch(viewType) {
            case 0:
                                                    //TODO: CUSTOM LAYOUT FOR ViewHolder0 types
                TextView v0 = (TextView) inflater.inflate(R.layout.activity_main2, parent, false);
                viewHolder = new ViewHolder0(v0);
                break;
            case 1:                                //TODO: CUSTOM LAYOUT FOR ViewHolder1 types
                ImageView v1 = (ImageView) inflater.inflate(R.layout.activity_main2, parent, false);
                viewHolder = new ViewHolder1(v1);
                break;
        }
        //viewHolder evaluates to null (despite its annotation) when this method is called
        //with unknown viewType value (Maybe it would help to create a general purpose ViewHolder
        //to handle cases such as this one? -> It would defeat the purpose of creating specialized
        // ViewHolders)
        return viewHolder;
    }

    @Override
    //The layout manager invokes this method when a view needs to be recycled:
    //holder variable is gonna contain new data (thus, recycling the view), located
    //at position
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        //We cast our view holder to the corresponding, more specific, view holder type
        switch(holder.getItemViewType()){ //<- This method is NOT CustomAdapter's, it's RecyclerView.ViewHolder.getItemViewType()
            case 0:
                ViewHolder0 viewHolder0 = (ViewHolder0) holder;
                viewHolder0.view0.setText((String) dataset[position]);

                break;
            case 1:
                ViewHolder1 viewHolder1 = (ViewHolder1) holder;
                viewHolder1.view1.setImageResource((int) dataset[position]);
                break;
        }
    }

    @Override
    public int getItemCount() {
        return dataset.length;
    }

    @Override
    public int getViewTypeCount(){
        return 2;
    }

    //In the design there are 2 types of views. Even rows contain type 0 views
    //and odd rows contain type 1 views, never mixing together in the same row.
    //So if position is 0, 0 % 2 = 0, thus, row #0 contains a type 0 view.
    //      position is 1, 1 % 2 > 0 (I believe there's some logic that assigns
    //      values >0 to 1), thus, row #1 contains a type 1 view.
    // Note that unlike in ListView adapters, TYPES DON'T HAVE TO BE CONTIGUOUS
    @Override
    public int getItemViewType(int position){
        return position % 2;
    }

}
