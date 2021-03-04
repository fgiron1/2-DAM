using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Handlers;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___BL.Handlers
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
