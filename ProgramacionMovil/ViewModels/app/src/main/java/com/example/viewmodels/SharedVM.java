package com.example.viewmodels;

import android.content.Context;

import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;
import androidx.room.Room;

import java.util.ArrayList;
import java.util.List;

public class SharedVM extends AndroidViewModel {


    private MutableLiveData<ArrayList<Equipo>> equiposNBA = new MutableLiveData<ArrayList<Equipo>>(new ArrayList<Equipo>());
    private MutableLiveData<Equipo> seleccionado = new MutableLiveData<Equipo>(new Equipo());

    public SharedVM(){

        LiveData<ArrayList<Equipo>> equipos = new LiveData<ArrayList<Equipo>>(new ArrayList<Equipo>);

        //Instanciamos la base de datos

        DB db = Room.databaseBuilder(
                getApplication().getApplicationContext(),
                DB.class,
                "EquiposNBA")
                .build();

        equipos = db.daoEquipo().getAllEquiposLive();

        this.equiposNBA = equipos;
    }


    public MutableLiveData<ArrayList<Equipo>> getEquiposNBA() {
        return equiposNBA;
    }
    public void setEquiposNBA(MutableLiveData<ArrayList<Equipo>> equiposNBA) {this.equiposNBA = equiposNBA;}

    public MutableLiveData<Equipo> getSeleccionado() {return this.seleccionado;}
    public void setSeleccionado(MutableLiveData<Equipo> seleccionado) {this.seleccionado = seleccionado;}


}

