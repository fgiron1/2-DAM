package com.example.fernandogirondominguezandroid.database;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Transaction;
import androidx.room.Update;

import com.example.fernandogirondominguezandroid.models.Bug;
import com.example.fernandogirondominguezandroid.models.Programador;

import java.util.List;

@Dao
public interface ProgramadorDAO {

    @Update
    void updateProgramador(Programador prog);

    @Delete
    void deleteProgramador(Programador prog);

    @Insert
    void insertProgramador(Programador prog);

    @Insert
    void insertProgramadorList(List<Programador> programadorList);

    @Transaction
    @Query("SELECT * FROM programadores WHERE idProgramador = :id")
    Programador getProgramadorById(int id);

    @Transaction
    @Query("SELECT * FROM bugs")
    List<Programador> getAllProgramadores();


}
