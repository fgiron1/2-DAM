using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Handlers;

namespace UD11___4___BL.Handlers
{
    public class PersonHandlerBL
    {
        public PersonHandlerDAL PersonHandler { get; set; }

        public PersonHandlerBL()
        {
            PersonHandler = new PersonHandlerDAL();
        }
    }
}
