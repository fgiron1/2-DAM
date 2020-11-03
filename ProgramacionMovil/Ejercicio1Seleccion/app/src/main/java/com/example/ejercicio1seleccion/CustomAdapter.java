package com.example.ejercicio1seleccion;

import android.content.Context;
import android.view.*;
import android.widget.BaseAdapter;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class CustomAdapter extends RecyclerView.Adapter<ListTeam> {

    private Context context;
    //Choose the most appropriate structure given your dataset
    private String[] dataset;

    //We can define as many viewholders as the total number of view types
    // that our list items' contain.


    //ViewHolder0
    private static class ViewHolder0 extends RecyclerView.ViewHolder{
        private View view0;

        public ViewHolder0(View itemView){
            super(itemView);
            this.view0 = itemView;
        }
    }

    //ViewHolder1
    private static class ViewHolder1 extends RecyclerView.ViewHolder{
        private View view1;

        public ViewHolder1(View itemView){
            super(itemView);
            this.view1 = itemView;
        }
    }

    @NonNull
    @Override
    //
    public ListTeam onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        return null;
    }

    @Override
    //El layout manager invoca este método cuando se ordena reemplazar el contenido
    //de una vista.
    public void onBindViewHolder(@NonNull ListTeam holder, int position) {

    }

    @Override
    public int getItemCount() {
        return dataset.length;
    }

    @Override
    public int getViewTypeCount(){
        return 2;
    }

    @Override
    public int getItemViewType(int position){
        return position % 2;
    }

}
