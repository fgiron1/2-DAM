package com.example.crud.models.persistence;

import android.graphics.Bitmap;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.Ignore;
import androidx.room.PrimaryKey;
import androidx.room.TypeConverters;

import com.example.crud.converters.DateConverter;

import java.util.Date;

@Entity(tableName = "personas")

@TypeConverters(DateConverter.class)
public class Persona {

    @PrimaryKey(autoGenerate = true)
    @ColumnInfo(name = "idPersona")
    private int idPersona;

    @Ignore
    Bitmap image;

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

    @ColumnInfo(name = "department_id")
    private int DepartmentID;

    public Persona(){}

    public Persona(int idPersona, Bitmap image, String firstName, String lastName, Date birthdate, String phoneNumber, String email, int departmentID) {
        this.idPersona = idPersona;
        this.image = image;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
        PhoneNumber = phoneNumber;
        Email = email;
        DepartmentID = departmentID;
    }

    //region Getters y setters

    public int getIdPersona() {
        return idPersona;
    }

    public void setIdPersona(int idPersona) {
        this.idPersona = idPersona;
    }

    public Bitmap getImage() { return image; }

    public void setImage(Bitmap image) { this.image = image; }

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

    public int getDepartmentID() {
        return DepartmentID;
    }

    public void setDepartmentID(int departmentID) {
        DepartmentID = departmentID;
    }

    //endregion

}
