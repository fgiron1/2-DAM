package com.example.viewmodels;

import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.ArrayList;

public class SharedVM extends ViewModel {


    private MutableLiveData<ArrayList<Equipo>> equiposNBA = new MutableLiveData<ArrayList<Equipo>>(new ArrayList<Equipo>());
    private MutableLiveData<Equipo> seleccionado = new MutableLiveData<Equipo>(new Equipo());

    /*añadirEquipo*/
    /*eliminarEquipo*/

    public SharedVM(){

        Equipo e2 = new Equipo("Real Madrid", 2);
        Equipo e3 = new Equipo("Huesca F.C.", 3);
        Equipo e4 = new Equipo("Recre", 4);

        ArrayList<Equipo> equipos = new ArrayList<Equipo>();
        equipos.add(e2);
        equipos.add(e3);
        equipos.add(e4);

        this.equiposNBA.setValue(equipos);
    }


    public MutableLiveData<ArrayList<Equipo>> getEquiposNBA() {
        return equiposNBA;
    }
    public void setEquiposNBA(MutableLiveData<ArrayList<Equipo>> equiposNBA) {this.equiposNBA = equiposNBA;}

    public MutableLiveData<Equipo> getSeleccionado() {return this.seleccionado;}
    public void setSeleccionado(MutableLiveData<Equipo> seleccionado) {this.seleccionado = seleccionado;}


}

