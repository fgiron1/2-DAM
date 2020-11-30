﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD11___4___DAL.Handlers;
using UD11___4___Entities;

namespace UD11___4___BL.Handlers
{
    public class DepartmentHandlerBL
    {
        //Property only used by member methods
        private DepartmentHandlerDAL handler;

        public DepartmentHandlerBL()
        {
            handler = new DepartmentHandlerDAL();
        }

        public void updateDepartment(int id, Department newDepartment)
        {
            handler.updateDepartment(id, newDepartment);
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