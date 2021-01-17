package com.example.viewmodels;

import androidx.lifecycle.*;

import java.util.List;

public class MyViewModel extends ViewModel {

    //LiveData ya trae get y set. Si creo otros no me va a notificar
    //No necesito metodos para añadir ni eliminar porque ya los trae list

    private MutableLiveData<List<Equipo>> equiposNBA;
    private MutableLiveData<Equipo> seleccionado;

    public void seleccionar(Equipo e){
        this.seleccionado.setValue(e);
    }

}

