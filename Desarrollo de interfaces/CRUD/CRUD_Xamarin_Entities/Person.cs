using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Xamarin_Entities
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

        //Constructor con la id para la actualización de la API (Encuentra la persona a actualizar usando la id del objeto)
        public Person(int ID, string firstName, string lastName, string phoneNumber, string email, DateTime birthdate, int departmentID)
        {
            id = ID;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Birthdate = birthdate;
            DepartmentID = departmentID;
        }

        public Person(string firstName, string lastName, string phoneNumber, string email, DateTime birthdate, int departmentID)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Birthdate = birthdate;
            DepartmentID = departmentID;
        }

    }
}
