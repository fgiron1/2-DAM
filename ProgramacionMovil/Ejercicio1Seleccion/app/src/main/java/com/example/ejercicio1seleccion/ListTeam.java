package com.example.ejercicio1seleccion;

import android.widget.ImageView;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

//ESTA DEFINICION DE CLASE PODRIA SER REALIZADA COMO CLASE ANONIMA
// EN LA DEFINICION DEL ADAPTER EN EL CASO DE SER MUY SIMPLE
public class TeamHolder extends RecyclerView.ViewHolder {

    //Creo que si solo va a tener vistas de un unico tipo, se pone y ya.
    //MIRATE https://stackoverflow.com/questions/26245139/how-to-create-recyclerview-with-multiple-view-type
    private TextView name;
    private ImageView picture;

    public TeamHolder(TextView name, TextView foundingYear){
        super(name);
        super(foundingYear);
        this.name = name;
        this.foundingYear = foundingYear;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getFoundingYear() {
        return foundingYear;
    }

    public void setFoundingYear(String foundingYear) {
        this.foundingYear = foundingYear;
    }

}
