package com.example.viewmodels;

import android.content.Intent;
import android.widget.ArrayAdapter;

import androidx.lifecycle.*;

import java.util.ArrayList;
import java.util.List;

public class SharedVM extends ViewModel {


    private MutableLiveData<ArrayList<Equipo>> equiposNBA = new MutableLiveData<ArrayList<Equipo>>(new ArrayList<Equipo>());
    private MutableLiveData<Equipo> seleccionado = new MutableLiveData<Equipo>(new Equipo());

    public void seleccionar(Equipo e){
        this.seleccionado.setValue(e);

    }

    //Devolviendo wrappers

    public MutableLiveData<ArrayList<Equipo>> getEquiposNBA() {
        return equiposNBA;
    }

    public void setEquiposNBA(MutableLiveData<ArrayList<Equipo>> equiposNBA) {

        this.equiposNBA = equiposNBA;
    }

    public MutableLiveData<Equipo> getSeleccionado() {
        return this.seleccionado;
    }

    public void setSeleccionado(MutableLiveData<Equipo> seleccionado) {

        this.seleccionado = seleccionado;
    }

    //Devolviendo valores

    public ArrayList<Equipo> getValueEquiposNBA() {
        if(this.equiposNBA.getValue() == null){
            this.equiposNBA.setValue(new ArrayList<Equipo>());
        }
        return this.equiposNBA.getValue();
    }

    public void setValueEquiposNBA(ArrayList<Equipo> valueEquiposNBA) {
        this.equiposNBA = new MutableLiveData<ArrayList<Equipo>>(valueEquiposNBA);
    }

    public Equipo getValueSeleccionado() {
        return this.seleccionado.getValue();
    }

    public void setValueSeleccionado(Equipo valueSeleccionado) {
        this.seleccionado = new MutableLiveData<Equipo>(valueSeleccionado);
    }


    //Devolviendo valores


}

