using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Xamarin_Entities.DTO
{
    public class PersonDepartmentName
    {
        /*
         * Cuando se hacen llamadas a la API, usamos este DTO para que nos sea todo más fácil.
         * Pero a la hora de persistir los datos, tenemos que emplear las entidades
         */

        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int DepartmentID { get; set; }
        public string departmentName { get; set; }

    }
}
