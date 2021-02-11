package com.example.viemodels.models;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import java.io.Serializable;

@Entity(tableName = "Equipos")
public class Equipo{

    @PrimaryKey
    private int id;

    @ColumnInfo(name = "nombre")
    private String nombre;

    @ColumnInfo(name = "numero_titulos")
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
