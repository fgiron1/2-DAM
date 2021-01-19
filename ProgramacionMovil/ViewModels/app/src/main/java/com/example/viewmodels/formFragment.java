package com.example.viewmodels;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import java.util.ArrayList;
import java.util.Observable;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link formFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class formFragment extends Fragment implements View.OnClickListener {

    private SharedVM vm;
    public AutoCompleteTextView nombreEquipoForm;
    public EditText numeroTitulosForm;
    public Button botonAnadirformFragment;


    public formFragment() {
        // Required empty public constructor
    }

    // TODO: Rename and change types and number of parameters
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

        nombreEquipoForm = (AutoCompleteTextView) getView().findViewById(R.id.nombreEquipoForm);
        numeroTitulosForm = (EditText) getView().findViewById(R.id.numeroTitulosForm);
        botonAnadirformFragment = (Button) getView().findViewById(R.id.botonAñadirformFragment);

        vm = new ViewModelProvider(requireActivity()).get(SharedVM.class);

        botonAnadirformFragment.setOnClickListener(this);

    }

    @Override
    public void onClick(View v) {
        switch(v.getId()){
            case R.id.botonAñadirformFragment:

                Equipo nuevoEquipo = new Equipo(nombreEquipoForm.getText().toString(), Integer.parseInt(numeroTitulosForm.getText().toString()));

                //Podria hacer un metodo para añadir, editar y eliminar, porque con el wrpaper de MutableLiveData
                //tengo que crearlos de nuevo. En su lugar, instancio una nueva lista con
                //el item que quiero añadir, y se la paso

                ArrayList<Equipo> listaActualizada = vm.getEquiposNBA().getValue();
                listaActualizada.add(nuevoEquipo);

                vm.getEquiposNBA().setValue(listaActualizada);

                //Ahora llama al observador de equiposNBA para que el adapter le pasa la lista a
                //la vista

                break;
        }
    }
}