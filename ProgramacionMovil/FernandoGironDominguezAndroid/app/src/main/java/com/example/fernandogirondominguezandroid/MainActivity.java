package com.example.fernandogirondominguezandroid;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.ViewModelProvider;

import android.os.Bundle;
import android.view.View;

import com.example.fernandogirondominguezandroid.fragments.InsertBug;
import com.example.fernandogirondominguezandroid.fragments.InsertProg;
import com.example.fernandogirondominguezandroid.fragments.Listado;
import com.example.fernandogirondominguezandroid.fragments.Opciones;
import com.example.fernandogirondominguezandroid.viewmodels.SharedVM;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    private SharedVM vm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Instanciamos el Viewmodel y poblamos la lista de personas
        vm = new ViewModelProvider(this).get(SharedVM.class);


        //Al iniciar la actividad, el fragment que se muestra es el de opciones
        //y el de la lista, cada uno en sus respectivos containers

        FragmentManager fm = getSupportFragmentManager();

        Opciones opcionesFragment = new Opciones();
        fm.beginTransaction()
                .replace(R.id.opcionesContainer, opcionesFragment)
                .addToBackStack("opciones")
                .setReorderingAllowed(true)
                .commit();

        Listado listadoFragment = new Listado();
        fm.beginTransaction()
                .replace(R.id.listadoContainer, listadoFragment)
                .addToBackStack("listado")
                .setReorderingAllowed(true)
                .commit();

    }

    @Override
    public void onClick(View v) {

        FragmentManager fm = getSupportFragmentManager();

        //Los fragmentos se pueden añadir manualmente (instanciandolos previamente) o pasando
        //tuClase.class por parámetros (de esta ultima forma no me funciona)

        switch(v.getId()){

            //Decidimos el fragment a invocar en función del botón clicado

            case R.id.btnBug:

                InsertBug bug = new InsertBug();

                fm.beginTransaction()
                        .replace(R.id.insertContainer, bug)
                        .addToBackStack("bug")
                        .setReorderingAllowed(true)
                        .commit();

                break;

            case R.id.btnProg:

                InsertProg prog = new InsertProg();

                fm.beginTransaction()
                        .replace(R.id.insertContainer, prog)
                        .addToBackStack("prog")
                        .setReorderingAllowed(true)
                        .commit();

                break;

        }

    }

}