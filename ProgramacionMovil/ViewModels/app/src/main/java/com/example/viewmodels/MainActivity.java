package com.example.viewmodels;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import java.util.ArrayList;


//Idea de la app: Arriba la lista, justo debajo un boton para borrar equipos, debajo y otro para añadirlo a su lado
//Si se hace clic en un equipo, abajo se muestra un fragment rollo master/details.
//Si se hace clic en el boton añadir, se muestra el formulario para rellenar aquello


//NECESIDAD DEL VIEWMODEL
//Que los datos persistan a pesar de cambios en la configuración (que pueden
//influir en el ciclo de vida de una actividad, y por lo tanto, pueden hacer que se destruya):

//Cambios provocados por cosas que uno hace muy frecuentemente con el movil
//Como cambiar la orientación de la pantalla, que el teclado salga, etc...
//Se almacenan


//Para decir aqui en el main que se haga una cosa u otra en funcion de la resolucion y tal.
//LO unico que tenemos que hacer es un findviewbyid de un elemento que no tengan los dos layouts
//Si dicho elemento es null, significa que estaría la aplicación corriendo en la otra resolución
//que usa el otro layout.


//Tengo que observar la propiedad equipoSeleccionado, y cuando cambie de null a algo o de algo a otra cosa
//Es cuando lanzo una nueva instancia del fragment details y coge el equipo seleccionado del vm

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

        //Los fragments pueden crear otro adaptador, que si lo hacen desde la misma fuente de datos, que está en el VM, no pasa nada.
        //La cosa es que no son owners de los observers puestos
        ArrayAdapter<Equipo> adaptador = new ArrayAdapter<Equipo>(getApplicationContext(), android.R.layout.simple_list_item_1, vm.getValueEquiposNBA());
                                                    //Notacion lambda para el onchanged
                                                    //Cualquier elemento que cambie de la lista, se lo decimos al adaptador para que visualmente se refleje el cambio
        //Observar solo detecta cuando se llaman a los metodos set o post de cada atributo
        //del MutableLiveData, y se ejecuta la lógica especificada
        vm.getEquiposNBA().observe(this, item -> {
            adaptador.notifyDataSetChanged();

        });

        botonEliminar.setOnClickListener(this);
        botonDesplegarForm.setOnClickListener(this);
        listaEquipos.setOnItemClickListener(this);


        Equipo e2 = new Equipo("Real Madrid", 2);
        Equipo e3 = new Equipo("Huesca F.C.", 3);
        Equipo e4 = new Equipo("Recre", 4);

        //ESTO DEBERIA HACER QUE LA LISTA FUERA NO VACIA
        ArrayList<Equipo> equipos = new ArrayList<Equipo>();
        equipos.add(e2);
        equipos.add(e3);
        equipos.add(e4);
        vm.setValueEquiposNBA(equipos);

        //The adapter's item list is contained in the VM
        //IMPORTANTE: Con Arrays, la lista de objetos que crea el adapter es INMUTABLE, porque la convierte en una AbstractList(List)
        //SOLUCION: Usar ArrayList

        //Al ejecutarlo, me da la dirección de memoria del objeto Equipo, porque NO ESPECIFICO UN ATRIBUTO DE EQUIPO PARA MOSTRAR



        listaEquipos.setAdapter(adaptador);
        //vm.getSeleccionado().observe(this, seleccionObserver);


    }

    @Override
    public void onClick(View v) {

        FragmentManager fm = getSupportFragmentManager();

        //Los fragmentos se pueden añadir manualmente (instanciandolos previamente) o pasando
        //tuClase.class por parámetros (de esta ultima forma no me funciona, no sé por qué)

        switch(v.getId()){

            case R.id.botonDesplegarForm:

                formFragment f = new formFragment();

                fm.beginTransaction()
                        .replace(R.id.FragmentContainer, f)
                        .addToBackStack("form")
                        .commit();

                break;

            case R.id.botonEliminado:


                    ArrayList<Equipo> listaActualizada = vm.getValueEquiposNBA();
                    //TODO PREGUNTAR DUDA: POR QUE NO SE ELIMINA CON EL REMOVE?
                    //TODO PUEDE QUE SEA PORQUE SE LE PASA UNA REFERENCIA DISTINTA
                    //TODO Mejor lo hago pasando el indice tambien
                    listaActualizada.remove(vm.getValueSeleccionado());
                    vm.setValueEquiposNBA(listaActualizada);

                break;

        }

    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

        //Esto tendrá que cambiarse por los campos de equipo
        //Pasamos una referencia del item de la lista clicado al atributo seleccionado del viewmodel
        vm.setValueSeleccionado((Equipo) parent.getItemAtPosition(position));
        //El observador y el método onChanged deberian de hacer el resto
        detailsFragment f = new detailsFragment();
        FragmentManager fm = getSupportFragmentManager();
        fm.beginTransaction()
                .replace(R.id.FragmentContainer, f)
                .addToBackStack("form")
                .commit();


    }
}