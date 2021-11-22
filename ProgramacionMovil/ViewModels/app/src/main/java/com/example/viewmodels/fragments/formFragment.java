package com.example.viewmodels.fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import com.example.viewmodels.Equipo;
import com.example.viewmodels.R;
import com.example.viewmodels.SharedVM;

import java.util.ArrayList;

public class formFragment extends Fragment implements View.OnClickListener {

    private SharedVM vm;
    public AutoCompleteTextView nombreEquipoForm;
    public EditText numeroTitulosForm;
    public Button botonAnadirformFragment;


    public formFragment() {}

    public static formFragment newInstance() {
        formFragment fragment = new formFragment();
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
        return inflater.inflate(R.layout.fragment_form, container, false);


    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        nombreEquipoForm = (AutoCompleteTextView) view.findViewById(R.id.nombreEquipoForm);
        numeroTitulosForm = (EditText) view.findViewById(R.id.numeroTitulosForm);
        botonAnadirformFragment = (Button) getView().findViewById(R.id.botonAñadirformFragment);

        //Instanciamos el viewmodel cuyo propietario es la actividad principal
        //Es decir, es un viewmodel compartido.
        vm = new ViewModelProvider(requireActivity()).get(SharedVM.class);

        botonAnadirformFragment.setOnClickListener(this);

    }

    @Override
    public void onClick(View v) {
        switch(v.getId()){
            case R.id.botonAñadirformFragment:

                //FIXME INPUT DEL NUMERO TITULOS NO VALIDADO; INTRODUCIR UN STRING LO ROMPE
                Equipo nuevoEquipo = new Equipo(nombreEquipoForm.getText().toString(), Integer.parseInt(numeroTitulosForm.getText().toString()));

                //Lista auxiliar
                ArrayList<Equipo> listaActualizada = vm.getEquiposNBA().getValue();
                listaActualizada.add(nuevoEquipo);

                //El observador detecta el cambio y notifica al adaptador de la lista
                vm.getEquiposNBA().setValue(listaActualizada);



                break;
        }
    }
}