<?php

require_once "Controller.php";


class LibroController extends Controller
{
    public function manageGetVerb(Request $request)
    {

        $listaLibros = null;
        $id = null;
        $response = null;
        $code = null;

        //if the URI refers to a libro entity, instead of the libro collection
        if (isset($request->getUrlElements()[2])) {
            $id = $request->getUrlElements()[2];
        }


        $listaLibros = LibroHandlerModel::getLibro($id);

        if ($listaLibros != null) {
            $code = '200';

        } else {

            //We could send 404 in any case, but if we want more precission,
            //we can send 400 if the syntax of the entity was incorrect...
            if (LibroHandlerModel::isValid($id)) {
                $code = '404';
            } else {
                $code = '400';
            }

        }

        $response = new Response($code, null, $listaLibros, $request->getAccept());
        $response->generate();

    }

    public function manageDeleteVerb(Request $request)
    {


        $header = null;
        $body = null;
        $code = null;
        $format = $request->getAccept();
        $queryString = $request->getQueryString();

        //If a query string is set, we look for the key "num_paginas_max"
        if(isset($queryString)){

            //The query string is then parsed into an array and the word by which to filter
            //is extracted from the parsed query string.

            $parsed_queryString = Array();

            parse_str($queryString, $parsed_queryString);

            $filter = $parsed_queryString["num_paginas_max"];

            try {
                LibroHandlerModel::deleteBooksBy($filter);
            } catch(Exception $e) {
                print("Something went wrong :(");
            }

        }



        $response = new Response($code, $header, $body, $format);
        $response->generate();
    }

}