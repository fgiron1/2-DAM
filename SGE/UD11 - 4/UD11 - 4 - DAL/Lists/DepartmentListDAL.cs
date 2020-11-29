using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Handlers;
using UD11___4___Entities;

namespace UD11___4___DAL.Lists
{
    public class DepartmentListDAL
    {
        public List<Department> DepartmentList { get; set; }

        public DepartmentListDAL()
        {
            DepartmentHandlerDAL DepartmentHandler = new DepartmentHandlerDAL();
            this.DepartmentList = DepartmentHandler.getDepartmentList();
        }
    }
}
