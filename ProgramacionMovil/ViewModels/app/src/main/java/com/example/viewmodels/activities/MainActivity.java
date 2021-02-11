package com.example.viewmodels.activities;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.ViewModelProvider;

import com.example.viewmodels.Equipo;
import com.example.viewmodels.R;
import com.example.viewmodels.SharedVM;
import com.example.viewmodels.fragments.detailsFragment;
import com.example.viewmodels.fragments.formFragment;

import java.util.ArrayList;

//Flujo Master/Details para cambiar persistencia de API a BBDD

//Añadir las librerias que puso el fran

//Patrón repository

public class MainActivity extends AppCompatActivity implements View.OnClickListener, AdapterView.OnItemClickListener {

    private SharedVM vm;
    ListView listaEquipos;
    Button botonEliminar, botonDesplegarForm;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Instanciando las vistas
        listaEquipos = (ListView) findViewById(R.id.listaEquipos);
        botonEliminar = (Button) findViewById(R.id.botonEliminado);
        botonDesplegarForm = (Button) findViewById(R.id.botonDesplegarForm);

        vm = new ViewModelProvider(this).get(SharedVM.class);

        ArrayAdapter<Equipo> adaptador = new ArrayAdapter<Equipo>(getApplicationContext(), android.R.layout.simple_list_item_1, vm.getEquiposNBA().getValue());

        //Observar solo detecta cuando se llaman a los metodos set o post de cada atributo
        //del MutableLiveData, y se ejecuta la lógica especificada

        //Notificando al adaptador para reflejar los cambios de vm.equiposNBA en la vista
        vm.getEquiposNBA().observe(this, item -> { adaptador.notifyDataSetChanged();});

        botonEliminar.setOnClickListener(this);
        botonDesplegarForm.setOnClickListener(this);
        listaEquipos.setOnItemClickListener(this);


        //The adapter's item list is contained in the VM
        //IMPORTANTE: Con Arrays, la lista de objetos que crea el adapter es INMUTABLE, porque la convierte en una AbstractList(List)
        //SOLUCION: Usar ArrayList

        //Al ejecutarlo, me da la dirección de memoria del objeto Equipo, porque NO ESPECIFICO UN ATRIBUTO DE EQUIPO PARA MOSTRAR



        listaEquipos.setAdapter(adaptador);


    }

    @Override
    public void onClick(View v) {

        FragmentManager fm = getSupportFragmentManager();

        //Los fragmentos se pueden añadir manualmente (instanciandolos previamente) o pasando
        //tuClase.class por parámetros (de esta ultima forma no me funciona)

        switch(v.getId()){

            case R.id.botonDesplegarForm:

                formFragment f = new formFragment();

                fm.beginTransaction()
                        .replace(R.id.FragmentContainer, f)
                        .addToBackStack("form")
                        .setReorderingAllowed(true)
                        .commit();

                break;

            case R.id.botonEliminado:

                    //En esta línea, por no haber hecho new(vm.getEquiposNBA().getValue())
                    //lo que tienes es una referencia a la lista del viewmodel
                    //Por eso, la última línea sobra.

                    //Lista auxiliar
                    ArrayList<Equipo> listaActualizada = vm.getEquiposNBA().getValue();
                    listaActualizada.remove(vm.getSeleccionado().getValue());

                    //Notificamos al observer
                    vm.getEquiposNBA().setValue(listaActualizada);

                break;

        }

    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

        //Pasamos una referencia del item de la lista clicado al atributo seleccionado del viewmodel

        vm.getSeleccionado().setValue((Equipo) parent.getItemAtPosition(position));
        //El observador detecta el cambio y notifica al adaptador

        detailsFragment f = new detailsFragment();
        FragmentManager fm = getSupportFragmentManager();
        fm.beginTransaction()
                .replace(R.id.FragmentContainer, f)
                .addToBackStack("form")
                .setReorderingAllowed(true)
                .commit();


    }
}