using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_CRUD_Entities
{
    public class Person
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int DepartmentID { get; set; }

        public Person() { }

        public Person(int id, string firstName, string lastName, string phoneNumber, string email, DateTime birthdate, int departmentID)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Birthdate = birthdate;
            DepartmentID = departmentID;
        }

    }
}
