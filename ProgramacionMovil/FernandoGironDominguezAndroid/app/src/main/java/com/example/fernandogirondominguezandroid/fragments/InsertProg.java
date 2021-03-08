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
import com.example.fernandogirondominguezandroid.models.Programador;

public class InsertProg extends Fragment implements View.OnClickListener{

    private EditText campoNombre;
    private EditText campoDNI;
    private Button botonInsertar;

    public InsertProg() {
        // Required empty public constructor
    }


    public static InsertProg newInstance() {
        InsertProg fragment = new InsertProg();
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
        return inflater.inflate(R.layout.fragment_insert_prog, container, false);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        //Instanciamos las vistas
        campoNombre = (EditText) view.findViewById(R.id.editTextNombre);
        campoDNI = (EditText) view.findViewById(R.id.editTextDNI);
        botonInsertar = (Button) view.findViewById(R.id.btnInsertarProg);

        //Asignamos el listener para el boton
        botonInsertar.setOnClickListener(this::onClick);

    }

    @Override
    public void onClick(View v) {

        String nombre = campoNombre.getText().toString();
        String dni = campoDNI.getText().toString();

        //Comprobamos que el DNI tenga 9 caracteres (la letra incluida) y que el nombre
        //no sea más largo de 90 caracteres
        if(dni.length() == 9 && nombre.length() < 90){

            //Insertamos el bug en la base de datos
            String dniMayus = dni.toUpperCase();
            Programador prog = new Programador(nombre, dniMayus);
            database.getDatabase(getContext()).programadorDAO().insertProgramador(prog);

        }

        //Volvemos a poner los campos vacíos
        campoNombre.setText("");
        campoDNI.setText("");

    }
}