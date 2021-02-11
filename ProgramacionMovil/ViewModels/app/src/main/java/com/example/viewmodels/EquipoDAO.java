package com.example.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.Query;
import androidx.room.Update;

import java.util.List;

@Dao
public interface EquipoDAO {

    @Query("SELECT * FROM Equipos")
    List<Equipo> getAllEquipos();

    //Devolvemos una lista observable
    @Query("SELECT nombre, numero_titulos FROM Equipos")
    LiveData<List<Equipo>> getLiveEquiposSync();

    @Query("SELECT * FROM Equipos WHERE id = (:id)")
    Equipo getEquipoById(int id);

    @Update
    void updateEquipo(Equipo updateEquipo);

    @Delete
    void deleteEquipo(Equipo toBeDeleted);

    @Insert(onConflict = OnConflictStrategy.IGNORE)
    void insertEquipo(Equipo newEquipo);


}
