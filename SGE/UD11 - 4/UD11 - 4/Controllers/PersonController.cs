using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UD11___4.Models;
using UD11___4___BL.Handlers;
using UD11___4___BL.Lists;
using UD11___4___Entities;

namespace UD11___4.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            PersonDepartmentNameList list = new PersonDepartmentNameList();

            //Bringing the list of all Person records in the database and storing them 
            PersonListBL PersonListBL = new PersonListBL();

            DepartmentListBL DepartmentListBL = new DepartmentListBL();
            //Adding to the PersonDepartmentNameList a new PersonDepartmentName object in each iteration
            //Its constructor takes a Person, and a department name
                
            
            foreach(Person p in PersonListBL.getPersonList()) {
                    list.List.Add(new PersonDepartmentName(p, DepartmentListBL.getDepartmentById(p.DepartmentID).Name));
            }

            return View(list.List);
        }

        [HttpPost]
        public ActionResult Details(int id)
        {
            //Finding the person clicked
            PersonListBL PersonList = new PersonListBL();
            Person Person = PersonList.getPersonById(id);

            DepartmentListBL DepartmentList = new DepartmentListBL();

            return View(p);
        }


        //This controller will be called when a record es edited and the information change needs to be registered
        [HttpPost]
        public ActionResult Edit(/*El modelo que me falta*/ Person)
        {
            //Finding the person clicked
            PersonListBL PersonList = new PersonListBL();
            Person Person = PersonList.getPersonById(id);

            DepartmentListBL DepartmentList = new DepartmentListBL();

            //AHORA NECESITO UN MODELO QUE AUNE LOS DATOS DE LA PERSONA BUSCADA Y ADEMAS SE LE PONE UN LISTADO DE DEPARTAMENTOS


            return View(p);
        }

                        //This parameter is going to be provided by the ActionLink's third parameter in Edit's view
        public ActionResult Edit(int id)
        {
            //I NEED TO CHANGE MY ID NAME IN MY Person CLASS, SINCE VS AUTOMATICALLY BINDS THE REST WITH ONLY THE ID, BUT THE NAME
            //NEEDS TO BE id INSTEAD OF ID
            //Finding the person clicked
            PersonListBL PersonList = new PersonListBL();
            Person Person = PersonList.getPersonById(id);

            DepartmentListBL DepartmentList = new DepartmentListBL();

            //AHORA NECESITO UN MODELO QUE AUNE LOS DATOS DE LA PERSONA BUSCADA Y ADEMAS SE LE PONE UN LISTADO DE DEPARTAMENTOS


            return View(p);
        }

    }
}