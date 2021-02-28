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
    public class PersonasController : ApiController
    {
        // GET: api/Personas
        public HttpResponseMessage Get()
        {
            List<Person> lista = null;
            HttpResponseMessage respuesta;

            try
            {
                PersonListBL handler = new PersonListBL();
                lista = handler.getPersonList();
            }
            catch(HttpResponseException e)
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

        // GET: api/Personas/5
        public HttpResponseMessage Get(int id)
        {
            Person oPersona = null;
            HttpResponseMessage respuesta;

            try
            {
                PersonListBL handler = new PersonListBL();
                oPersona = handler.getPersonById(id);
            }
            catch(Exception e)
            {
                //Conexión con las otras capas fallida
                //No se envía la información de la excepción e para evitar exponer al público detalles técnicos
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            finally
            {
                if (oPersona == null)
                {
                    //Según el estándar http, NO se debe incluir contenido
                    //en las respuestas http de no content
                    respuesta = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    respuesta = Request.CreateResponse(HttpStatusCode.OK, oPersona);
                }
            }

            return respuesta;
        }

        // POST: api/Personas
        public void Post([FromBody]Person personaNueva)
        {
            try
            {
                PersonHandlerBL handler = new PersonHandlerBL();
                handler.insertPerson(personaNueva);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }


        }

        // PUT: api/Personas/5
        public void Put([FromBody]Person personaActualizada)
        {
            try
            {
                PersonHandlerBL handler = new PersonHandlerBL();
                handler.updatePerson(personaActualizada);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
        }

        // DELETE: api/Personas/5
        public void Delete(int id)
        {
            try
            {
                PersonHandlerBL handler = new PersonHandlerBL();
                handler.deletePerson(id);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            

        }
    }
}
