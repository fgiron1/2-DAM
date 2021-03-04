package com.example.crud.models.persistence;

import androidx.room.Embedded;
import androidx.room.Entity;
import androidx.room.TypeConverters;

import com.example.crud.converters.DateConverter;

@Entity
@TypeConverters(DateConverter.class)
public class PersonaWithDepartmento {

    @Embedded
    Persona p;

    @Embedded
    Departamento d;

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

    /* @PrimaryKey(autoGenerate = true)
    private int idPersona;

    @ColumnInfo(name = "first_name")
    private String FirstName;

    @ColumnInfo(name = "last_name")
    private String LastName;

    @ColumnInfo(name = "birthdate")
    private Date Birthdate;

    @ColumnInfo(name = "phone_number")
    private String PhoneNumber;

    @ColumnInfo(name = "email")
    private String Email;

    @Embedded public Departamento departamento;

    public int getIdPersona() {
        return idPersona;
    }

    public void setIdPersona(int idPersona) {
        this.idPersona = idPersona;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        FirstName = firstName;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String lastName) {
        LastName = lastName;
    }

    public Date getBirthdate() {
        return Birthdate;
    }

    public void setBirthdate(Date birthdate) {
        Birthdate = birthdate;
    }

    public String getPhoneNumber() {
        return PhoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        PhoneNumber = phoneNumber;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public Departamento getDepartamento() {
        return departamento;
    }

    public void setDepartamento(Departamento departamento) {
        this.departamento = departamento;
    }
    */

}
