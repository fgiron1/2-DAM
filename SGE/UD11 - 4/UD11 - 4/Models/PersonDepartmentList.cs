using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using UD11___4___Entities;

namespace UD11___4.Models
{
    public class PersonDepartmentList : Person
    {
        [DisplayName("Department list")]
        public List<Department> departmentList{ get; set; }

        public PersonDepartmentList(Person Person, List<Department> departmentList)
        {

            this.id = Person.id;
            this.FirstName = Person.FirstName;
            this.LastName = Person.LastName;
            this.Birthdate = Person.Birthdate;
            this.Email = Person.Email;
            this.PhoneNumber = Person.PhoneNumber;
            this.departmentList = departmentList;
        }
    }
}