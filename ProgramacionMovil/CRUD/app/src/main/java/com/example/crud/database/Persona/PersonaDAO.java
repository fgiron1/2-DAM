package com.example.crud.database.Persona;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Transaction;
import androidx.room.Update;

import com.example.crud.models.persistence.Persona;
import com.example.crud.models.persistence.PersonaWithDepartmento;

import java.util.List;

@Dao
public interface PersonaDAO {

    @Update
    void updatePersona(Persona p);

    @Delete
    void deletePersona(Persona p);

    @Insert
    void insertPersona(Persona p);

    @Insert
    void insertPersonaList(List<Persona> personaList);

    @Transaction
    @Query("SELECT * FROM personas WHERE idPersona = :id")
    Persona getPersonById(int id);

    @Transaction
    @Query("SELECT * FROM personas")
    List<Persona> getAllPersons();

    @Transaction
    @Query("SELECT personas.*, departamentos.* FROM personas INNER JOIN departamentos ON personas.department_id = departamentos.id")
    List<PersonaWithDepartmento> getPersonWithDepartmentList();

   /* static class PersonaWithDepartamento {
        @Embedded
        public Persona p;

        @Embedded
        public Departamento d;

        public Persona getP() {
            return p;
        }

        public void setP(Persona p) {
            this.p = p;
        }

        public Departamento getD() {
            return d;
        }

        public void setD(Departamento d) {
            this.d = d;
        }
    }
*/
}
