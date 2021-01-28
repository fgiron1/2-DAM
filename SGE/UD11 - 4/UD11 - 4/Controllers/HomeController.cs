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
    public class HomeController : Controller
    {
        // GET: Person
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonDepartmentName Person)
        {
            PersonHandlerBL handler = new PersonHandlerBL();

            Person newPerson = new Person();

            newPerson.id = Person.id;
            newPerson.FirstName = Person.FirstName;
            newPerson.LastName = Person.LastName;
            newPerson.Birthdate = Person.Birthdate;
            newPerson.PhoneNumber = Person.PhoneNumber;
            newPerson.DepartmentID = Person.DepartmentID;

            handler.insertPerson(newPerson);

            return View("Done");
        }

        public ActionResult Details(int id)
        {
            //Finding the person clicked
            PersonListBL PersonList = new PersonListBL();
            Person Person = PersonList.getPersonById(id);

            DepartmentListBL DepartmentList = new DepartmentListBL();
            Department department = DepartmentList.getDepartmentById(Person.DepartmentID);

            PersonDepartmentName finalResult = new PersonDepartmentName(Person, department.Name);

            return View(finalResult);
        }


        //This action will be called when a record is edited and the information change needs to be registered in the DB
        [HttpPost]
        public ActionResult Edit(PersonDepartmentName Person)
        {
            PersonHandlerBL handler = new PersonHandlerBL();

            //TODO: ONLY THE DEPARTMENT NAME SHOULD APPEAR IN THE VIEW. THERE SHOULD BE SOME LOGIC HERE BY WHICH
            //THE CHOSEN DEPARTMENT NAME IS  TRANSLATED INTO ITS CORRESPONDING ID AS DepartmentListDAL's getDepartmentById
            //METHOD DOES WITH THE DEPARTMENT ID

            //The Person's id won't change, so we can use the updated Person's id for convenience
            handler.updatePerson(Person);

            return View("Done");
        }

                        //This parameter is going to be provided by the ActionLink's third parameter in Edit's view
        public ActionResult Edit(int id)
        {
            //This commented code is the code that should be used with model PersonDepartmentList, which is, in the first place
            //how this is supposed to be designed

                /* //Finding the person clicked
                 PersonListBL PersonList = new PersonListBL();
                 Person Person = PersonList.getPersonById(id);

                 //Retrieving a list of departments
                 DepartmentListBL DepartmentList = new DepartmentListBL();
                 List<Department> list = DepartmentList.getDepartmentList();

                 //Building our model with the clicked Person's data and the department list
                 PersonDepartmentList finalResult = new PersonDepartmentList(Person, list);*/

            //CODE USED WITH PersonDepartmentName MODEL
            //Finding the person clicked
            PersonListBL PersonList = new PersonListBL();
            Person Person = PersonList.getPersonById(id);

            DepartmentListBL list = new DepartmentListBL();
            //Building our model with the clicked Person's data. Person's field DepartmentID is translated into its corresponding department name
            PersonDepartmentName finalResult = new PersonDepartmentName(Person, list.getDepartmentById(Person.DepartmentID).Name);

            return View(finalResult);
        }

        public ActionResult Delete(int id)
        {
            //CODE USED WITH PersonDepartmentName MODEL
            //Finding the person clicked
            PersonListBL PersonList = new PersonListBL();
            Person Person = PersonList.getPersonById(id);

            DepartmentListBL list = new DepartmentListBL();
            //Building our model with the clicked Person's data. Person's field DepartmentID is translated into its corresponding department name
            PersonDepartmentName finalResult = new PersonDepartmentName(Person, list.getDepartmentById(Person.DepartmentID).Name);

            return View(finalResult);
        }

        [HttpPost]
        public ActionResult Delete(PersonDepartmentName Person)
        {

            PersonHandlerBL handler = new PersonHandlerBL();
            handler.deletePerson(Person.id);
         
            return View("Done");
        }

        public ActionResult Done()
        {
            return View();
        }

    }
}