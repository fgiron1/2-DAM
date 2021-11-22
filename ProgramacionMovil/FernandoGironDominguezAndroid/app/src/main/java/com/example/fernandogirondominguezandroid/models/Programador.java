package com.example.fernandogirondominguezandroid.models;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "programadores")
public class Programador {

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "idProgramador")
    private int idProgramador;

    @ColumnInfo(name = "nombre")
    private String nombre;

    @ColumnInfo(name = "DNI")
    private String DNI;

    public Programador(String nombre, String DNI) {
        this.nombre = nombre;
        this.DNI = DNI;
    }

    public int getIdProgramador() {
        return idProgramador;
    }

    public void setIdProgramador(int idProgramador) {
        this.idProgramador = idProgramador;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDNI() {
        return DNI;
    }

    public void setDNI(String DNI) {
        this.DNI = DNI;
    }
}
