using CRUD_Xamarin_DAL.Connection;
using CRUD_Xamarin_Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace CRUD_Xamarin_DAL.Handlers
{
    public class PersonHandler
    {
        public static async Task<List<Person>> getPersonList()
        {

            List<Person> personList = new List<Person>();
            HttpResponseMessage status;
            string respuestaJSON;

            Uri uri = new Uri($"{BaseURI.API}Personas");

            HttpClient client = new HttpClient();

            try
            {
                //Comprobamos si la petición se ha procesado correctamente
                status = await client.GetAsync(uri);

                if (status.IsSuccessStatusCode)
                {
                    respuestaJSON = await client.GetStringAsync(uri);
                    client.Dispose();

                    //Convertimos el JSON recibido a un objeto de tipo List<Person>
                    personList = JsonConvert.DeserializeObject<List<Person>>(respuestaJSON);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return personList;

        }
        public static async Task<Person> getPersonById(int id) {

            Person retrievedPerson = new Person();
            HttpResponseMessage response;
            string respuestaJSON;

            Uri uri = new Uri($"{BaseURI.API}Personas/{id}");

            HttpClient client = new HttpClient();

            try
            {
                //Comprobamos si la petición se ha procesado correctamente
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    respuestaJSON = await client.GetStringAsync(uri);
                    client.Dispose();

                    //Convertimos el JSON recibido a un objeto de tipo List<Person>
                    retrievedPerson = JsonConvert.DeserializeObject<Person>(respuestaJSON);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return retrievedPerson;
        }
        public static async Task<HttpStatusCode> updatePerson(Person updatePerson)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            HttpContent content;
            string personJSON;
            Uri uri = new Uri($"{BaseURI.API}Personas/{updatePerson.id}");

            HttpClient client = new HttpClient();

            try
            {
                personJSON = JsonConvert.SerializeObject(updatePerson);
                content = new StringContent(personJSON, System.Text.Encoding.UTF8, "application/json");

                response = await client.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response.StatusCode;
        }
        public static async Task<HttpStatusCode> insertPerson(Person newPerson)

        {
            HttpResponseMessage response = new HttpResponseMessage();
            HttpContent content;
            string personJSON;
            Uri uri = new Uri($"{BaseURI.API}Personas");

            HttpClient client = new HttpClient();

            try
            {
                personJSON = JsonConvert.SerializeObject(newPerson);
                content = new StringContent(personJSON, System.Text.Encoding.UTF8, "application/json");

                response = await client.PostAsync(uri, content);
            }
            catch (Exception e)
            {
                throw e;
            }

            return response.StatusCode;


        }
        public static async Task<HttpStatusCode> deletePerson(int id) {

            HttpResponseMessage response = new HttpResponseMessage();

            Uri uri = new Uri($"{BaseURI.API}Personas/{id}");

            HttpClient client = new HttpClient();

            try
            {
                response = await client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response.StatusCode;

        }


    }
}

   
