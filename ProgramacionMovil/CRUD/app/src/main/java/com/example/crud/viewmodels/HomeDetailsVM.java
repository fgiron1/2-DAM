package com.example.crud.viewmodels;

import android.content.Context;

import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import com.example.crud.database.database;
import com.example.crud.models.persistence.Persona;

import java.util.ArrayList;

public class HomeDetailsVM extends ViewModel {

    private MutableLiveData<ArrayList<Persona>> listaPersonas = new MutableLiveData<>();
    private MutableLiveData<Persona> personaSeleccionada = new MutableLiveData<>();

    public HomeDetailsVM(){

    }


    //region Getters y setters

    public MutableLiveData<ArrayList<Persona>> getListaPersonas() {
        return listaPersonas;
    }

    public void setListaPersonas(MutableLiveData<ArrayList<Persona>> listaPersonas) {
        this.listaPersonas = listaPersonas;
    }

    public MutableLiveData<Persona> getPersonaSeleccionada() {

        if(personaSeleccionada == null){
            personaSeleccionada = new MutableLiveData<>();
        }

        return personaSeleccionada;
    }
    public void setPersonaSeleccionada(MutableLiveData<Persona> personaSeleccionada) {
        this.personaSeleccionada = personaSeleccionada;

    }

    //endregion

    //region Metodos

    //IMPORTANTE: Manejar contextos en viewmodels va en contra de su filosofía
    //Sin embargo, solo es empleado en instanciar la base de datos
    public void poblarLista(Context c){

        //Poblamos la lista llamando a la base de datos
        listaPersonas.setValue(
                new ArrayList<Persona>(database.getDatabase(c).personaDAO().getAllPersons())
        );
    }

    //endregion


}
