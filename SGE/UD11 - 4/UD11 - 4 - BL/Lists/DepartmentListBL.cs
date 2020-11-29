using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Lists;

namespace UD11___4___BL.Lists
{
    public class DepartmentListBL
    {
        public DepartmentListDAL DepartmentList { get; set; }
        public DepartmentListBL()
        {
            this.DepartmentList = new DepartmentListDAL();
        }
    }
}
