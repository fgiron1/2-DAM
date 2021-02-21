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
    }
}
