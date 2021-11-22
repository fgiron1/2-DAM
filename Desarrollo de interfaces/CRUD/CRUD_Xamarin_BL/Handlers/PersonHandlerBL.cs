﻿using CRUD_Xamarin_DAL.Handlers;
using CRUD_Xamarin_Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Xamarin_BL.Handlers
{
    public class PersonHandlerBL
    {
        public static async Task<List<Person>> getPersonListBL() { return await PersonHandler.getPersonList(); }
        public static async Task<Person> getPersonByIdBL(int id) { return await PersonHandler.getPersonById(id); }
        public static async Task<HttpStatusCode> updatePersonBL(Person updatePerson) { return await PersonHandler.updatePerson(updatePerson); }
        public static async Task<HttpStatusCode> insertPersonBL(Person newPerson) { return await PersonHandler.insertPerson(newPerson); }
        public static async Task<HttpStatusCode> deletePerson(int id) { return await PersonHandler.deletePerson(id); }
    }
}