package com.example.crud;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.crud.database.database;
import com.example.crud.models.persistence.Persona;
import com.example.crud.models.persistence.PersonaWithDepartmento;
import com.example.crud.viewmodels.HomeDetailsVM;

import java.util.List;

public class HomeActivity extends AppCompatActivity implements personasListAdapter.onItemClickListener {

    RecyclerView listaPersonas;
    HomeDetailsVM vm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        /////////////////////////////////////////TEST//////////////////////////////////////////////////
        //LiveData<PersonaWithDepartmento> lista = database.getDatabase(getApplicationContext()).personaWithDepartamentoDAO().getPersonWithDepartmentList();
        List<Persona> lista = database.getDatabase(getApplicationContext()).personaDAO().getAllPersons();
        Persona persona = database.getDatabase(getApplicationContext()).personaDAO().getPersonById(325);

        List<PersonaWithDepartmento> listadoTraido = database.getDatabase(getApplicationContext()).personaDAO().getPersonWithDepartmentList();
        System.out.println(listadoTraido.toString());

        /////////////////////////////////////////TEST//////////////////////////////////////////////////

        //Instanciamos las vistas
        listaPersonas = (RecyclerView) findViewById(R.id.listaPersonas);

        //Instanciamos el Viewmodel y poblamos la lista de personas
        vm = new ViewModelProvider(this).get(HomeDetailsVM.class);
        vm.poblarLista(getApplicationContext());

        //Instanciamos un nuevo adaptador y le pasamos la implementacion del onItemClickListener
        personasListAdapter adapter = new personasListAdapter(getApplicationContext(), R.layout.fila_movil, vm.getListaPersonas().getValue());
        adapter.setListener(this::onItemClick);

        //Le asignamos el adaptador y el layout manager al RecyclerView
        listaPersonas.setAdapter(adapter);
        listaPersonas.setLayoutManager(new LinearLayoutManager(this));

        //Notificando al adaptador para reflejar los cambios de la lista de personas en la vista
        vm.getListaPersonas().observe(this, item -> { adapter.notifyDataSetChanged();});


    }

    @Override
    public void onItemClick(Persona p) {

        //Cada vez que se haga click en un item de la lista, se le pasa la persona que representa
        //al viewmodel
        vm.getPersonaSeleccionada().setValue(p);
    }
}