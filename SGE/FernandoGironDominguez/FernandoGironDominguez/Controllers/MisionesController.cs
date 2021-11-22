using FernandoGironDominguez___BL.Handlers;
using FernandoGironDominguez___BL.Lists;
using FernandoGironDominguez___Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FernandoGironDominguez.Controllers
{
    public class MisionesController : ApiController
    {
        // GET: api/Misiones
        public HttpResponseMessage Get()
        {
            List<Mision> lista = null;
            HttpResponseMessage respuesta;

            try
            {
                MisionListBL handler = new MisionListBL();
                lista = handler.getMisionList();
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

        // PUT: api/Misiones/5
        public void Put(int id, [FromBody]Mision mision)
        {
            try
            {
                MisionHandlerBL handler = new MisionHandlerBL();
                handler.updatePerson(mision);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

        }

        // GET: api/Misiones/5
        public HttpResponseMessage Get(int id)
        {
            Mision mision = null;
            HttpResponseMessage respuesta;

            try
            {
                MisionListBL handler = new MisionListBL();
                mision = handler.getMisionById(id);
            }
            catch (Exception e)
            {
                //Conexión con las otras capas fallida
                //No se envía la información de la excepción e para evitar exponer al público detalles técnicos
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }
            finally
            {
                if (mision == null)
                {
                    //Según el estándar http, NO se debe incluir contenido
                    //en las respuestas http de no content
                    respuesta = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    respuesta = Request.CreateResponse(HttpStatusCode.OK, mision);
                }
            }

            return respuesta;
        }

    }
}
