using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Handlers;
using UD11___4___Entities;

namespace UD11___4___BL.Handlers
{
    public class PersonHandlerBL
    {
        private PersonHandlerDAL handler;

        public PersonHandlerBL()
        {
            handler = new PersonHandlerDAL();
        }

        public void updatePerson(Person newPerson)
        {
            handler.updatePerson(newPerson);
        }
        public void deletePerson(int id)
        {
            handler.deletePerson(id);
        }
        public void insertPerson(Person newPerson)
        {
            handler.insertPerson(newPerson);
        }

    }
}
