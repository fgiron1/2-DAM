using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UD11___4.Models
{
    public class PersonDepartmentNameList
    {
        public List<PersonDepartmentName> PersonDepartmentName { get; set; }

        public PersonDepartmentNameList()
        {
            this.PersonDepartmentName = new List<PersonDepartmentName>();
        }

    }
}