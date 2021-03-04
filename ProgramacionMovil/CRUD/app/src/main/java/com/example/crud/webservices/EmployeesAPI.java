package com.example.crud.webservices;

import com.example.crud.models.persistence.Departamento;
import com.example.crud.models.persistence.Persona;
import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;

public interface EmployeesAPI {

    @GET("Personas")
    Call<List<Persona>> getAllPersonas();

    @GET("Personas/{id}")
    Call<Persona> getPersonaById(int id);

    @GET("Departaments")
    Call<List<Departamento>> getAllDepartments();

    @GET("Departments/{id}")
    Call<Departamento> getDepartmentById(int id);

}
