using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Lists;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___BL.Lists
{
    public class PersonListBL {
        public List<Person> getPersonList()
        {
            PersonListDAL list = new PersonListDAL();
            return list.getPersonList();
        }

        public Person getPersonById(int id)
        {
            PersonListDAL list = new PersonListDAL();
            return list.getPerson(id);
        }
    }
}
