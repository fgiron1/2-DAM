using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjerciciosUD7.Models
{
    public class clsPersona
    {
        #region Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //Phone number with extension
        [DataType(DataType.PhoneNumber)]
        public string ExtPhoneNumber { get; set; }
        #endregion

        #region Constructors
        public clsPersona(string Name, string Surname, DateTime Birthdate, string Email, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Birthdate = Birthdate;
            this.Email = Email;
            this.ExtPhoneNumber = PhoneNumber;
        }
        #endregion

    }
}