using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FernandoGironDominguez___DAL.Lists;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___BL.Lists
{
    public class DepartmentListBL
    {
        public List<Department> getDepartmentList()
        {
            DepartmentListDAL list = new DepartmentListDAL();
            //Additional BL logic would go here?
            return list.getDepartmentList();
        }

        public Department getDepartmentById(int id)
        {
            DepartmentListDAL list = new DepartmentListDAL();
            //Additional BL logic would go here?
            return list.getDepartment(id);
        }

    }
}
