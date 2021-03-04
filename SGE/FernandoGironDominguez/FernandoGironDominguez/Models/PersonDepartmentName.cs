﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using FernandoGironDominguez___BL.Lists;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___API.Models
{
    public class PersonDepartmentName : Person
    {
        [DisplayName("Department name")]
        public string departmentName { get; set; }

        //"Casting" classes from entities to UI MVC models
        public PersonDepartmentName()
        {

        }

        public PersonDepartmentName(Person Person, String departmentName)
        {
            this.id = Person.id;
            this.FirstName = Person.FirstName;
            this.LastName = Person.LastName;
            this.Birthdate = Person.Birthdate;
            this.Email = Person.Email;
            this.PhoneNumber = Person.PhoneNumber;
            this.DepartmentID = Person.DepartmentID;
            this.departmentName = departmentName;
        }   
    }
}