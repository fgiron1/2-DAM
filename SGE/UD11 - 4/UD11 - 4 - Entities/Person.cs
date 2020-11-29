using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD11___4___Entities
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        private int _departmentID;
        public int DepartmentID
        {
            get
            {
                return _departmentID;
            }

            set
            {
                _departmentID = value;
            }
        }
    }
}
