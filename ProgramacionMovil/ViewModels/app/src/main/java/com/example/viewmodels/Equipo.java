package com.example.viemodels.models;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "Equipos")
public class Equipo{

<<<<<<< HEAD
    @PrimaryKey
=======
    @PrimaryKey(autoGenerate = true)
>>>>>>> master
    private int id;

    @ColumnInfo(name = "nombre")
    private String nombre;

<<<<<<< HEAD
    @ColumnInfo(name = "numero_titulos")
=======
    @ColumnInfo(name ="numero_titulos")
>>>>>>> master
    private int numeroTitulos;

    public Equipo(){
        this.nombre = new String();
        this.numeroTitulos = 0;
    }

    public Equipo(String nombre, int numeroTitulos){
        this.nombre = nombre;
        this.numeroTitulos = numeroTitulos;
    }
    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getNumeroTitulos() {
        return numeroTitulos;
    }

    public void setNumeroTitulos(int numeroTitulos) {
        this.numeroTitulos = numeroTitulos;
    }

    @Override
    public String toString(){
        String resultado = "Nombre: "+this.nombre+"\nNumero titulos: "+numeroTitulos;
        return resultado;
    }

}
