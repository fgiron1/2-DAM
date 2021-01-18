package com.example.viewmodels;

import java.io.Serializable;

public class Equipo{

    private String nombre;
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
