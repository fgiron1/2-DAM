package com.example.fernandogirondominguezandroid.fragments;

import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.fernandogirondominguezandroid.R;
import com.example.fernandogirondominguezandroid.adapters.bugListAdapter;
import com.example.fernandogirondominguezandroid.models.Bug;
import com.example.fernandogirondominguezandroid.viewmodels.SharedVM;

import java.util.ArrayList;


public class Listado extends Fragment implements bugListAdapter.onItemClickListener {

    private SharedVM vm;
    private RecyclerView listaBugs;

    public Listado() {
        // Required empty public constructor
    }



    public static Listado newInstance() {
        Listado fragment = new Listado();
        Bundle args = new Bundle();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_listado, container, false);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        //Instanciamos las vistas
        listaBugs = (RecyclerView) view.findViewById(R.id.listaBugs);

        //Dado que el viewmodel es compartido entre todos los fragments,
        //el owner es la actividad principal
        vm = new ViewModelProvider(requireActivity()).get(SharedVM.class);

        //Instanciamos un nuevo adaptador y le pasamos la implementacion del onItemClickListener
        bugListAdapter adapter = new bugListAdapter(view.getContext(),
                R.layout.fila_listado,
                new ArrayList<>(vm.getBugsDeProgramador().getValue()));
        adapter.setListener(this::onItemClick);

        //Le asignamos el adaptador y un layout manager a la vista
        listaBugs.setAdapter(adapter);
        listaBugs.setLayoutManager(new LinearLayoutManager(view.getContext()));

        //Notificando al adaptador para reflejar los cambios de la lista de bugs en la vista
        vm.getBugsDeProgramador().observe(requireActivity(), item -> { adapter.notifyDataSetChanged();});

    }

    @Override
    public void onItemClick(Bug bug) {

        //Cada vez que se haga click en un item de la lista, se le pasa el bug que representa
        //al viewmodel. FUNCIONALIDAD NO REQUERIDA POR EL EJERCICIO, PERO CONTRIBUYE A COMPLETA
        //IMPLEMENTACION DEL RECYCLER VIEW
        vm.getBugSeleccionado().setValue(bug);
    }
}