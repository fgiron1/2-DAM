<?php

require_once "Controller.php";
require_once "../handler/PersonajeHandlerModel.php";

class LibroController extends Controller
{
    public function manageGetVerb(Request $request)
    {

        $listaLibros = Array();
        $listaLibrosConPersonajes = Array();

        $id = null;
        $response = null;
        $code = null;


        /*
         * Endpoints
         *
         * ../Libro/{id}      -> Devuelve libro por id
         * ../Libro/          -> Devuelve una colección de Libros (Puede incluir en la request una query string con una clave "filter", para filtar los libros por el nombre)
         */



        if (isset($request->getUrlElements()[2])) {

            $id = $request->getUrlElements()[2];


            //We check whether the book list is empty or not, and answer accordingly
            $libro = LibroHandlerModel::getLibro($id);

            if ($libro != null) {

                //Instantiating a new LibroPersonajeModel from a LibroModel and a PersonajeModel array

                //We retrieve the character list associated to $libro
                $listaPersonajes = PersonajeHandlerModel::getPersonajeByLibro($libro->getCodigo());

                if(!empty($listaPersonajes)){

                    //A new LibroPersonajeModel instance is created with the book data and its character list
                    $libroPersonaje = new LibroPersonajeModel($libro, $listaPersonajes);

                    //Adding the object to the list
                    $listaLibrosConPersonajes[] = $libroPersonaje;

                    $code = '200';
                } else {

                    //Resource locked
                    $code = 423;

                }

            }


        //ID is not set -> endpoint is ../Libros and we have to return a book collection

        } elseif(!isset($request->getUrlElements()[2])) {

            $queryString = $request->getQueryString();

            //We check for a set query string -> User asks for a book collection filtered by the value of key "filter" in query string
            if(isset($queryString)){

                //The query string is then parsed into an array and the word by which to filter
                //is extracted from the parsed query string.

                $parsed_queryString = Array();

                parse_str($queryString, $parsed_queryString);

                $filter = $parsed_queryString["filter"];

                $listaLibros = LibroHandlerModel::getLibrosByName($filter);

                //Adding a character array and building a LibroPersonajeModel

                foreach ($listaLibros as $libro){

                    $personajesArray = PersonajeHandlerModel::getPersonajeByLibro($libro->codigo);

                    //If there are no characters associated with the book, that resource is locked
                    //and should not be displayed

                    if(!is_null($personajesArray) && !empty($personajesArray)) {
                        $libroPersonaje = new LibroPersonajeModel($libro, $personajesArray);
                        $listaLibrosConPersonajes[] = $libroPersonaje;
                    }
                }


            } else {
                //devuelve la colección de libros sin filtrar
                $listaLibros = LibroHandlerModel::getAllLibros();

                foreach ($listaLibros as $libro){

                    $personajesArray = PersonajeHandlerModel::getPersonajeByLibro($libro->codigo);

                    //If there are no characters associated with the book, that resource is locked
                    //and should not be displayed

                    if(!is_null($personajesArray) && !empty($personajesArray)) {
                        $libroPersonaje = new LibroPersonajeModel($libro, $personajesArray);
                        $listaLibrosConPersonajes[] = $libroPersonaje;
                    }
                }


            }

        } else {

            if (LibroHandlerModel::isValid($id)) {
                $code = '404';
            } else {
                $code = '400';
            }

        }

        $response = new Response($code, null, $listaLibrosConPersonajes, $request->getAccept());
        $response->generate();

    }

}