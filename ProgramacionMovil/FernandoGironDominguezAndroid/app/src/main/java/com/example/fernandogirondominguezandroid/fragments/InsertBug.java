package com.example.fernandogirondominguezandroid.fragments;

import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import com.example.fernandogirondominguezandroid.R;
import com.example.fernandogirondominguezandroid.database.database;
import com.example.fernandogirondominguezandroid.models.Bug;

public class InsertBug extends Fragment implements View.OnClickListener {

    private EditText campoPrioridad;
    private EditText campoIdProgramador;
    private Button botonInsertar;

    public InsertBug() {
        // Required empty public constructor
    }

    public static InsertBug newInstance() {
        InsertBug fragment = new InsertBug();
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
        return inflater.inflate(R.layout.fragment_insert_bug, container, false);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        //Instanciamos las vistas
        campoPrioridad = (EditText) view.findViewById(R.id.editTextPrioridad);
        campoIdProgramador = (EditText) view.findViewById(R.id.editTextIdProgramador);
        botonInsertar = (Button) view.findViewById(R.id.btnInsertarBug);

        //Asignamos el listener para el boton
        botonInsertar.setOnClickListener(this::onClick);

    }

    @Override
    public void onClick(View v) {

        String prioridad = campoPrioridad.getText().toString();
        int idProgramador = Integer.parseInt(campoIdProgramador.getText().toString());

        //Comprobamos que el valor escrito en el campo prioridad sea exclusivamente las palabras
        //alta o baja, independientemente de si están o no en mayúsculas
        if(prioridad.compareToIgnoreCase("alta") == 0 || prioridad.compareToIgnoreCase("baja") == 0){

            //Insertamos el bug en la base de datos
            Bug bug = new Bug(prioridad, idProgramador);
            database.getDatabase(getContext()).bugDAO().insertBug(bug);

        }

        //Volvemos a poner los campos vacíos
        campoPrioridad.setText("");
        campoIdProgramador.setText("");


    }
}