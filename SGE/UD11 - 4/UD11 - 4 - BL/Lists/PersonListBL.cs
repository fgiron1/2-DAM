using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Lists;

namespace UD11___4___BL.Lists
{
    public class PersonListBL
    {
        public PersonListDAL PersonList { get; set; }

        public PersonListBL()
        {
            this.PersonList = new PersonListDAL();
        }
    }
}
