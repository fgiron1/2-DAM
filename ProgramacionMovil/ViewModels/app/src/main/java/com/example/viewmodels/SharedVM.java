package com.example.viewmodels;

import android.app.Application;

import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;

import java.util.ArrayList;

public class SharedVM extends AndroidViewModel {


    private MutableLiveData<ArrayList<Equipo>> equiposNBA = new MutableLiveData<ArrayList<Equipo>>(new ArrayList<Equipo>());
    private MutableLiveData<Equipo> seleccionado = new MutableLiveData<Equipo>(new Equipo());

    public SharedVM(Application application){

        super(application);

        MutableLiveData<ArrayList<Equipo>> equipos = new MutableLiveData<ArrayList<Equipo>>(new ArrayList<Equipo>());


        this.equiposNBA = equipos;
    }


    public MutableLiveData<ArrayList<Equipo>> getEquiposNBA() {
        return equiposNBA;
    }
    public void setEquiposNBA(MutableLiveData<ArrayList<Equipo>> equiposNBA) {this.equiposNBA = equiposNBA;}

    public MutableLiveData<Equipo> getSeleccionado() {return this.seleccionado;}
    public void setSeleccionado(MutableLiveData<Equipo> seleccionado) {this.seleccionado = seleccionado;}


}

