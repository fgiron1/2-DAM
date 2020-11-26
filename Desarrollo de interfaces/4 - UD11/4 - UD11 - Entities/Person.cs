using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4___UD11___Entities
{
    public class Person

    {
        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePic { get; set; }

        public Person(){}
        public Person(string firstName, string lastName, DateTime Birthdate, string PhoneNumber, string Email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthdate = Birthdate;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
        }
    }
}
