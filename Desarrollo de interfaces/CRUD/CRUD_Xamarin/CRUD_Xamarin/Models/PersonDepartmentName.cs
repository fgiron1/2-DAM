using CRUD_Xamarin_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Xamarin.Models
{
    public class PersonDepartmentName
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int DepartmentID { get; set; }
        public string departmentName { get; set; }

        public PersonDepartmentName() { }
        public PersonDepartmentName(Person p, string dptName)
        {
            id = p.id;
            FirstName = p.FirstName;
            LastName = p.LastName;
            PhoneNumber = p.PhoneNumber;
            Email = p.Email;
            Birthdate = p.Birthdate;
            DepartmentID = p.DepartmentID;
            departmentName = dptName;
        }

    }
}
