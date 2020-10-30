package com.example.ejercicio1seleccion;

import android.content.Context;
import android.view.ViewGroup;
import android.widget.BaseAdapter;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

public class CustomAdapter extends RecyclerView.Adapter<ListTeam> {

    private Context context;
    //Choose the most appropriate structure given your data
    private String[] dataset;


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
}
