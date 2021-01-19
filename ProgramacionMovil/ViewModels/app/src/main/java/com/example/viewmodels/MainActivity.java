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
import androidx.lifecycle.MutableLiveData;
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
        //Se le pasa el getValue() porque el adaptador ya se entera con el método onChanged()
        ArrayAdapter<Equipo> adaptador = new ArrayAdapter<Equipo>(getApplicationContext(), android.R.layout.simple_list_item_1, vm.getEquiposNBA().getValue());
                                                    //Notacion lambda para el onchanged
                                                    //Cualquier elemento que cambie de la lista, se lo decimos al adaptador para que visualmente se refleje el cambio
        //Observar solo detecta cuando se llaman a los metodos set o post de cada atributo
        //del MutableLiveData, y se ejecuta la lógica especificada
        vm.getEquiposNBA().observe(this, item -> { adaptador.notifyDataSetChanged();});

        botonEliminar.setOnClickListener(this);
        botonDesplegarForm.setOnClickListener(this);
        listaEquipos.setOnItemClickListener(this);


        Equipo e2 = new Equipo("Real Madrid", 2);
        Equipo e3 = new Equipo("Huesca F.C.", 3);
        Equipo e4 = new Equipo("Recre", 4);

        ArrayList<Equipo> equipos = new ArrayList<Equipo>();
        equipos.add(e2);
        equipos.add(e3);
        equipos.add(e4);
        vm.getEquiposNBA().setValue(equipos);

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

                    //Segun la documentacion, la manera de actualizar
                    //los atributos del VM es conseguir el mutable live data (getAtributo()),
                    //y despues invocar el método setValue()
                    ArrayList<Equipo> listaActualizada = vm.getEquiposNBA().getValue();
                    listaActualizada.remove(vm.getSeleccionado().getValue());
                    vm.getEquiposNBA().setValue(listaActualizada);

                break;

        }

    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

        //Pasamos una referencia del item de la lista clicado al atributo seleccionado del viewmodel

        vm.getSeleccionado().setValue((Equipo) parent.getItemAtPosition(position));
        //El observador y el método onChanged deberian de hacer el resto
        detailsFragment f = new detailsFragment();
        FragmentManager fm = getSupportFragmentManager();
        fm.beginTransaction()
                .replace(R.id.FragmentContainer, f)
                .addToBackStack("form")
                .commit();


    }
}