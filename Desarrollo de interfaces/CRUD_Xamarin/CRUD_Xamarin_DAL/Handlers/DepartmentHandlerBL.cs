using CRUD_Xamarin_DAL.Connection;
using CRUD_Xamarin_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Xamarin_DAL.Handlers
{
    public class DepartmentHandlerBL
    {
        public static async Task<Department> getDepartmentById(int id)
        {

            Department retrievedDepartment = new Department();
            HttpResponseMessage response;
            string respuestaJSON;

            Uri uri = new Uri($"{BaseURI.API}Departments/{id}");

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
                    retrievedDepartment = JsonConvert.DeserializeObject<Department>(respuestaJSON);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return retrievedDepartment;
        }

        public static async Task<List<Department>> getDepartmentList()
        {

            List<Department> departmentList = new List<Department>();
            HttpResponseMessage status;
            string respuestaJSON;

            Uri uri = new Uri($"{BaseURI.API}Departments");

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
                    departmentList = JsonConvert.DeserializeObject<List<Department>>(respuestaJSON);
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return departmentList;

        }
    }
}
