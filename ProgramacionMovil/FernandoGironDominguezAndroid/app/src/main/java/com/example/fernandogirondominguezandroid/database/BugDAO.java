package com.example.fernandogirondominguezandroid.database;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Transaction;
import androidx.room.Update;

import com.example.fernandogirondominguezandroid.models.Bug;

import java.util.ArrayList;
import java.util.List;


@Dao
public interface BugDAO {

    @Update
    void updateBug(Bug bug);

    @Delete
    void deleteBug(Bug bug);

    @Insert
    void insertBug(Bug bug);

    @Insert
    void insertBugList(List<Bug> bugList);

    @Transaction
    @Query("SELECT * FROM bugs WHERE idBug = :id")
    Bug getBugById(int id);

    @Transaction
    @Query("SELECT * FROM bugs")
    List<Bug> getAllBugs();

    @Transaction
    @Query("SELECT idBug, prioridad, idProgramador FROM bugs WHERE idProgramador = :id")
    List<Bug> getBugByProgrammerId(int id);

}