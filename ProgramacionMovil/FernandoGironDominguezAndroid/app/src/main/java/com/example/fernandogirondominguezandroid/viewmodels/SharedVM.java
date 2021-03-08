package com.example.fernandogirondominguezandroid.viewmodels;

import android.app.Application;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;

import com.example.fernandogirondominguezandroid.database.database;
import com.example.fernandogirondominguezandroid.models.Bug;
import com.example.fernandogirondominguezandroid.models.Programador;

import java.util.ArrayList;
import java.util.List;

public class SharedVM extends AndroidViewModel {

    //FIXME Al ejecutar, error por ser null
    private MutableLiveData<List<Bug>> bugsDeProgramador = new MutableLiveData<>();

    //FIXME Al ejecutar, error por ser null
    //El programador seleccionado en el spinner
    private MutableLiveData<Programador> programadorSeleccionado = new MutableLiveData<>();

    //El bug seleccionado en la lista de bugs asociados al programador seleccionado en el spinner
    private MutableLiveData<Bug> bugSeleccionado = new MutableLiveData<>();

    public SharedVM(@NonNull Application application) {
        super(application);
    }

    //region Getters y setters



    public MutableLiveData<Bug> getBugSeleccionado() {
        return bugSeleccionado;
    }

    public void setBugSeleccionado(MutableLiveData<Bug> bugSeleccionado) {
        this.bugSeleccionado = bugSeleccionado;
    }

    public MutableLiveData<List<Bug>> getBugsDeProgramador() {
        return bugsDeProgramador;
    }

    public void setBugsDeProgramador(MutableLiveData<List<Bug>> bugsDeProgramador) {
        this.bugsDeProgramador = bugsDeProgramador;
    }

    public MutableLiveData<Programador> getProgramadorSeleccionado() {
        return programadorSeleccionado;
    }

    public void setProgramadorSeleccionado(MutableLiveData<Programador> programadorSeleccionado) {
        this.programadorSeleccionado = programadorSeleccionado;
    }

    //endregion

    public void poblarBugsDeProgramador(@NonNull Application application){

        //Si se ha seleccionado a un programador, nos traemos los bugs asociados

        //FIXME ROOM DEVUELVE LiveData<List<Bug>>. YO MANEJO MutableLiveData<ArrayList<Bug>>
        //FIXME LA CONVERSIÓN DE LiveData<> a MutableLiveData<> la hago.
        //FIXME Pero la conversión de MutableLiveData<List<Bug>> a MutableLiveData<ArrayList<Bug>> NO CONSIGO HACERLA
        //FIXME PARA QUE NO HAYAN ERRORES DE COMPILACIÓN, HE DECIDIDO DEVOLVER EN EL DAO
        //FIXME UNA LISTA, EN LUGAR DE UN LiveData<List>
        MutableLiveData<List<Bug>> lista;

        lista = (MutableLiveData<List<Bug>>) database.getDatabase(application.getApplicationContext())
                .bugDAO()
                .getBugByProgrammerId(programadorSeleccionado.getValue().getIdProgramador());


        if(programadorSeleccionado != null){
           bugsDeProgramador = lista;
        }
    }


}
