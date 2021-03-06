<?php


require_once("Controller.php");
require_once("../model/OfertaModelHandler.php");

class OfertaController extends Controller
{

    /*
         * Vamos a devolver un objeto RESPONSE (VISTA) en cada método, por lo que, a priori, necesitamos:
         *
         * header: A null normalmente
         * body: El recurso solicitado (o mensaje de resultado)
         * code: El código de respuesta (exitoso, error del cliente, error del servidor, etc...)
         * format: El formato de la respuesta (json normalmente), EXTRAIDO DEL FORMATO QUE ACEPTA EL REQUEST PASADO POR PARÁMETROS.
         *
         */

    function manageGetVerb(Request $request)
    {

        /*
         * Endpoints:
         *
         * ../ofertas       -> Devuelve una colección de todas las ofertas de trabajo
         * ../ofertas/{id}  -> Devuelve una oferta en concreto
         *
        */
        $header = null;
        $body = null;
        $code = null;
        $format = $request->getAccept();
        $id = null;

        //Assigning the HTTP response's body
        //Comprobamos si el recurso solicitado es una colección o es un recurso individual

        if(isset($request->getUrlElements()[1])){
            $id = $request->getUrlElements()[1];
            $body = OfertaModelHandler::getOfferById($id);
        } else {
            $body = OfertaModelHandler::getAllOffers(); //Esto deberia de estar ya en json?
        }

        //Assigning the HTTP response's code

        if($body != null){
            $code = "200";
        } else {

            if (OfertaModelHandler::isValid($id)) {
                $code = "404"; //Página no encontrada
            } else {
                $code = "400"; //Formato erróneo de la id
            }

        }

        //Creating the response object
        $response = new Response($code, null, $body, $format);
        $response->generate();

    }

    function manageDeleteVerb(Request $request){

        /*
         * Endpoints:
         *
         * ../ofertas/{id}/eliminar   Elimina una oferta de trabajo identificada por la id
         *
         */

        $header = null;
        $body = null;
        $code = null;
        $format = $request->getAccept();
        $id = null;

        $id = $request->getUrlElements()[1];

        //Assigning the HTTP response's body
        //Checking for a valid id
        if(OfertaModelHandler::isValid($id)) {
            if (OfertaModelHandler::deleteOffer($id)) {
                $body = "Deleted successfully";
                $code = "200";
            } else {
                //Internal server error
                $code = "500";
                $body = "Oops! There was a problem :(";
            }
        } else {
            $code = "400";
        }

        $response = new Response($code, $header, $body, $format);
        $response->generate();

    }

    function managePostVerb(Request $request)
    {
        /*
         * Endpoints:
         *
         * ../ofertas
         *
         */


        //Construimos la respuesta

        $header = null;
        $body = null;
        $code = null;
        $format = $request->getAccept();
        $jsonInvalido = false;
        $ofertaData = $request->getBodyParameters();

        //En el objeto Request pasado por parámetros, $body_parameters es un archivo JSON decodificado en una variable php
        //Es decir, ya tiene los datos que nos interesa.
        //Construimos un nuevo objeto OfertaModel en función de esos datos
        //SE ACCEDEN A TRAVES DE: $valor = $body_parameters->{"clave"};


        //Lista de claves necesarias que tiene que tener el json:

        $required = array("ofertante", "puesto", "descripcion", "requisitos", "fecha_publicacion", "contacto");

        //Comprobamos si alguno de los campos requeridos no contiene información o tiene un valor null-ish
        foreach($required as $campo){
            if(empty($ofertaData->{$campo})){
                $jsonInvalido = true;
                $code = 500;
            }
        }

        //Si todos los campos están llenos, persistimos la info a la bbdd
        if(!$jsonInvalido){
            //We don't need the id from the client, since it is autogenerated in the db
            //So we set it to a dummy value
            $ofertaToInsert = new OfertaModel(0, $ofertaData->{"ofertante"}, $ofertaData->{"puesto"}, $ofertaData->{"descripcion"}, $ofertaData->{"requisitos"}, $ofertaData->{"fecha_publicacion"}, $ofertaData->{"contacto"});

            if(OfertaModelHandler::insertOffer($ofertaToInsert)){
                $code = 200;
            } else {
                $code = 500;
                $body = "There was a problem persisting the information";
            }

        }

        //Enviamos la respuesta HTTP
        $response = new Response($code, $header, $body, $format);
        $response->generate();

    }

    function managePutVerb(Request $request)
    {
        //Construimos la respuesta

        $header = null;
        $body = null;
        $code = null;
        $format = $request->getAccept();
        $jsonInvalido = false;
        $ofertaData = $request->getBodyParameters();

        //Lista de claves necesarias que tiene que tener el json:

        $required = array("id", "ofertante", "puesto", "descripcion", "requisitos", "fecha_publicacion", "contacto");

        //Comprobamos si alguno de los campos requeridos no contiene información o tiene un valor null-ish
        foreach($required as $campo){
            if(empty($ofertaData->{$campo})){
                $jsonInvalido = true;
                $code = 500;
            }
        }

        //Si todos los campos están llenos, persistimos la info a la bbdd
        if(!$jsonInvalido){

            $ofertaToInsert = new OfertaModel($ofertaData->{"id"}, $ofertaData->{"ofertante"}, $ofertaData->{"puesto"}, $ofertaData->{"descripcion"}, $ofertaData->{"requisitos"}, $ofertaData->{"fecha_publicacion"}, $ofertaData->{"contacto"});

            if(OfertaModelHandler::updateOffer($ofertaToInsert->getId(), $ofertaToInsert)){
                $code = 200;
            } else {
                $code = 500;
                $body = "There was a problem persisting the information";
            }

        }

        //Enviamos la respuesta HTTP
        $response = new Response($code, $header, $body, $format);
        $response->generate();
    }
}