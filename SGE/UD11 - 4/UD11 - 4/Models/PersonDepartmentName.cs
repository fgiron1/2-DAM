using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using UD11___4___Entities;

namespace UD11___4.Models
{
    public class PersonDepartmentName : Person
    {
        [DisplayName("Department name")]
        public string departmentName { get; set; }
    
    }
}