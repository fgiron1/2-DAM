package com.example.crud.database.Departamento;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Update;

import com.example.crud.models.persistence.Departamento;

import java.util.List;

@Dao
public interface DepartamentoDAO {


    @Update
    void updateDepartamento(Departamento d);

    @Delete
    void deleteDepartamento(Departamento d);

    @Insert
    void insertDepartamento(Departamento d);

    @Insert
    void insertDepartamentoList(List<Departamento> departamentoList);

}
