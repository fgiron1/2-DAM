package com.example.viewmodels;

import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;


public class detailsFragment extends Fragment {

    private SharedVM vm;

    public detailsFragment() {
        // Required empty public constructor
    }

    public static detailsFragment newInstance() {
        detailsFragment fragment = new detailsFragment();
        Bundle args = new Bundle();

        fragment.setArguments(args);
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
        return inflater.inflate(R.layout.fragment_details, container, false);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        vm = new ViewModelProvider(requireActivity()).get(SharedVM.class);

        //Si quisiera usar el findviewbyid en el onCreate(), me daria null
        //Porque las vistas no estan infladas todavia

        EditText numeroTitulos = (EditText) getView().findViewById(R.id.numeroTitulos);
        TextView nombre = (TextView) getView().findViewById(R.id.nombre);

        numeroTitulos.setText(Integer.toString(vm.getSeleccionado().getValue().getNumeroTitulos()));
        nombre.setText(vm.getSeleccionado().getValue().getNombre());

    }

}