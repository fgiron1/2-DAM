using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UD11___4.Models
{
    public class PersonDepartmentNameList
    {
        public List<PersonDepartmentName> List { get; set; }

        public PersonDepartmentNameList()
        {
            this.List = new List<PersonDepartmentName>();
        }

    }
}