using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Handlers;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___BL.Handlers
{
    public class MisionHandlerBL
    {
        private MisionHandlerDAL handler;

        public MisionHandlerBL()
        {
            handler = new MisionHandlerDAL();
        }

        public void updatePerson(Mision newMision)
        {
            handler.updateMision(newMision);
        }

    }
}
