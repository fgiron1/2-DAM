using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Handlers;
using Entities;

namespace BL.Handlers
{
    public class DepartmentHandlerBL
    {
        //Property only used by member methods
        private DepartmentHandlerDAL handler;

        public DepartmentHandlerBL()
        {
            handler = new DepartmentHandlerDAL();
        }

        public void updateDepartment(Department newDepartment)
        {
            handler.updateDepartment(newDepartment);
        }
        public void deleteDepartment(int id)
        {
            handler.deleteDepartment(id);
        }
        public void insertDepartment(Department newDepartment)
        {
            handler.insertDepartment(newDepartment);
        }
    }
}
