using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Person
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        private int _departmentID;
        public virtual int DepartmentID
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

        public Person()
        {
            this.id = 0;
            this.FirstName = "John";
            this.LastName = "Doe";
            this.Birthdate = new DateTime();
            this.Email = "johndoe@hotmail.com";
            this.PhoneNumber = "654000000";
            this.DepartmentID = 0;
        }

    }
}
