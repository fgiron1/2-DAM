using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Handlers;
using UD11___4___Entities;

namespace UD11___4___DAL.Lists
{
    public class PersonListDAL
    {
        public List<Person> PersonList { get; set; }

        public PersonListDAL()
        {
            PersonHandlerDAL PersonHandler = new PersonHandlerDAL();
            this.PersonList = PersonHandler.getPersonList();
        }

    }
}
