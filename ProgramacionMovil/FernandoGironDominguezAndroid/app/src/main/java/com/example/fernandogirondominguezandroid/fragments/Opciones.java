package com.example.fernandogirondominguezandroid.fragments;

import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.example.fernandogirondominguezandroid.R;
import com.example.fernandogirondominguezandroid.viewmodels.SharedVM;

import java.util.ArrayList;


public class Opciones extends Fragment {

    private SharedVM vm;
    private Button insertarBug;
    private Button insertarProg;


    public Opciones() {
        // Required empty public constructor
    }

    public static Opciones newInstance() {
        Opciones fragment = new Opciones();
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
        return inflater.inflate(R.layout.fragment_opciones, container, false);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        //Dado que el viewmodel es compartido entre todos los fragments,
        //el owner es la actividad principal
        vm = new ViewModelProvider(requireActivity()).get(SharedVM.class);


        insertarBug = (Button) view.findViewById(R.id.btnBug);
        insertarProg = (Button) view.findViewById(R.id.btnProg);



    }



}