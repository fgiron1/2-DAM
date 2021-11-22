using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Lists;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___BL.Lists
{
    public class MisionListBL {
        public List<Mision> getMisionList()
        {
            MisionListDAL list = new MisionListDAL();
            return list.getMisionList();
        }

        
        public Mision getMisionById(int id)
        {
            MisionListDAL list = new MisionListDAL();
            return list.getMision(id);
        }
    }
}
