using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FernandoGironDominguez___BL.Handlers;
using FernandoGironDominguez___BL.Lists;
using FernandoGironDominguez___Entities;

namespace FernandoGironDominguez___API.Controllers
{
    public class DepartmentsController : ApiController
    {
        // GET: api/Departments
        public HttpResponseMessage Get()
        {
            List<Department> lista = null;
            HttpResponseMessage respuesta;

            try
            {
                DepartmentListBL handler = new DepartmentListBL();
                lista = handler.getDepartmentList();
            }
            catch (HttpResponseException e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            finally
            {
                if (lista == null)
                {
                    //Según el estándar http, NO se debe incluir contenido
                    //en las respuestas http de no content
                    respuesta = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    respuesta = Request.CreateResponse(HttpStatusCode.OK, lista);
                }
            }

            return respuesta;
        }

        // GET: api/Departments/5
        public HttpResponseMessage Get(int id)
        {
            Department oDepartment = null;
            HttpResponseMessage respuesta;

            try
            {
                DepartmentListBL handler = new DepartmentListBL();
                oDepartment = handler.getDepartmentById(id);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                //No se envía la información de la excepción e para evitar exponer al público detalles técnicos
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            finally
            {
                if (oDepartment == null)
                {
                    //Según el estándar http, NO se debe incluir contenido
                    //en las respuestas http de no content
                    respuesta = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    respuesta = Request.CreateResponse(HttpStatusCode.OK, oDepartment);
                }
            }

            return respuesta;
        }

        // POST: api/Departments
        public void Post([FromBody]Department nuevoDepartamento)
        {
            try
            {
                DepartmentHandlerBL handler = new DepartmentHandlerBL();
                handler.insertDepartment(nuevoDepartamento);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }

        // PUT: api/Departments/5
        public void Put(int id, [FromBody]Department nuevoDepartamento)
        {
            try
            {
                DepartmentHandlerBL handler = new DepartmentHandlerBL();
                handler.updateDepartment(nuevoDepartamento);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }

        // DELETE: api/Departments/5
        public void Delete(int id)
        {
            try
            {
                DepartmentHandlerBL handler = new DepartmentHandlerBL();
                handler.deleteDepartment(id);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
