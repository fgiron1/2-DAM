package com.example.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.Query;
import androidx.room.Update;

import java.util.ArrayList;

@Dao
public interface DAOEquipo {

    @Query("SELECT nombre, numero_titulos FROM Equipos WHERE id = :id")
    public Equipo getEquipoById(int id);

    //LiveData para mostrar una lista con datos que se actualizan
    //con los cambios en la bbdd en tiempo real
    @Query("SELECT * FROM Equipos")
    public LiveData<ArrayList<Equipo>> getAllEquiposLive();

    @Insert(onConflict = OnConflictStrategy.ABORT)
    public void insertEquipo(Equipo e);

    @Delete
    public void deleteEquipo(Equipo e);

    @Update
    public void updateEquipo(Equipo e);
}
