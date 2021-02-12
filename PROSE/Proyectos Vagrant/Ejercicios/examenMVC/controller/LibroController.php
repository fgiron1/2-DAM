<?php

require_once "Controller.php";
require_once "../handler/PersonajeHandlerModel.php";

class LibroController extends Controller
{
    public function manageGetVerb(Request $request)
    {

        $listaLibros = null;
        $listaLibrosConPersonajes = Array();

        $id = null;
        $response = null;
        $code = null;


        /*
         * Endpoints
         *
         * ../Libro/{id}      -> Devuelve libro por id
         * ../Libro/{string}  -> Filtra libros por su nombre
         */


        //We check for a string value on the

        if (isset($request->getUrlElements()[1]) && !is_string($request->getUrlElements()[1])) {

            $id = $request->getUrlElements()[1];


        //We check whether the book list is empty or not, and answer accordingly
        $listaLibros = LibroHandlerModel::getLibro($id);

        if ($listaLibros != null) {

            $code = '200';

            //Instantiating a new LibroPersonajeModel from a LibroModel and a PersonajesModel array

            foreach ($listaLibros as $libro) {

                //We retrieve the character list associated to $libro
                $listaPersonajes = PersonajeHandlerModel::getPersonajeByLibro($libro->getCodigo());

                //A new LibroPersonajeModel instance is created with the book data and its character list
                $libroPersonaje = new LibroPersonajeModel($libro, $listaPersonajes);

                //Adding the object to the list
                $listaLibrosConPersonajes[] = $libroPersonaje;

            }
        }


        //Is set and is string

        } elseif(isset($request->getUrlElements()[1]) && is_string($request->getUrlElements()[1])){

            $listaLibros = LibroHandlerModel::getLibrosByName($request->getUrlElements()[1]);

            //Codigo repetido

            foreach ($listaLibros as $libro) {

                //We retrieve the character list associated to $libro
                $listaPersonajes = PersonajeHandlerModel::getPersonajeByLibro($libro->getCodigo());

                //A new LibroPersonajeModel instance is created with the book data and its character list
                $libroPersonaje = new LibroPersonajeModel($libro, $listaPersonajes);

                //Adding the object to the list
                $listaLibrosConPersonajes[] = $libroPersonaje;

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