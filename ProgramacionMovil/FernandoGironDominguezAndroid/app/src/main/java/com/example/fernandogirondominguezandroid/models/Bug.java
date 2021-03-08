package com.example.fernandogirondominguezandroid.models;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "bugs")
public class Bug {

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "idBug")
    private int idBug;

    @ColumnInfo(name = "prioridad")
    private String prioridad;

    @ColumnInfo(name = "idProgramador")
    private int idProgramador;

    public Bug(String prioridad, int idProgramador) {
        this.prioridad = prioridad;
        this.idProgramador = idProgramador;
    }

    public int getIdBug() {
        return idBug;
    }

    public void setIdBug(int idBug) {
        this.idBug = idBug;
    }

    public String getPrioridad() {
        return prioridad;
    }

    public void setPrioridad(String prioridad) {
        this.prioridad = prioridad;
    }

    public int getIdProgramador() {
        return idProgramador;
    }

    public void setIdProgramador(int idProgramador) {
        this.idProgramador = idProgramador;
    }
}
