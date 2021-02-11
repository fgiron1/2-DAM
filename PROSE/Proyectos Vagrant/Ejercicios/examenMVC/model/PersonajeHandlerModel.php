<?php

require_once "ConsPersonajeModel.php";
require_once "ConsLibrosModel.php";

class PersonajeHandlerModel
{
    //This function returns the characters of a book using its id
    public static function getPersonajeByLibro($LibroId){
        $personajesList = null;

        //We open a connection to the database
        $db = DatabaseModel::getInstance();
        $db_connection = $db->getConnection();

        //Validating book ID
        $valid = self::isValid($LibroId);

        //Checks input for non-null and numeric values

        if ($valid === true) {

            //We prepare this query

            //SELECT ID, Nombre, Edad FROM
            //Libros AS L INNER JOIN Personajes AS P
            //ON L.IDPersonaje = P.ID AND
            //   L.IDPersonaje IS NOT NULL

            $query = "SELECT " . ConsPersonajeModel::COD . ","
                . ConsPersonajeModel::NOMBRE . ","
                . ConsPersonajeModel::EDAD . " FROM " . ConsPersonajeModel::TABLE_NAME
                . " INNER JOIN IN " . ConsLibrosModel::TABLE_NAME . "." . ConsPersonajeModel::COD . " = " . ConsPersonajeModel::COD . " AND "
                . ConsLibrosModel::TABLE_NAME . "." . ConsPersonajeModel::COD . " IS NOT NULL"
                . " WHERE " . ConsLibrosModel::TABLE_NAME . "." . ConsLibrosModel::COD . " = ?";
        }

        //Preparing the query, binding $LibroID and executing it
        $prep_query = $db_connection->prepare($query);
        $prep_query->bind_param('s', $Libroid);
        $prep_query->execute();

        $listaLibros = array();

        //We use $id, $nombre and $edad to store the
        $prep_query->bind_result($cod, $num, $pag);
        while ($prep_query->fetch()) {
            $tit = utf8_encode($tit);
            $libro = new LibroModel($cod, $tit, $pag);
            $listaLibros[] = $libro;
        }

        return $listaLibros;

    }
//            $result = $prep_query->get_result();
//            for ($i = 0; $row = $result->fetch_object(LibroModel::class); $i++) {
//
//                $listaLibros[$i] = $row;
//            }
  //      }

    //returns true if $id is a valid id for a book
    //In this case, it will be valid if it only contains
    //numeric characters, even if this $id does not exist in
    // the table of books
    public static function isValid($id)
    {
        $res = false;

        if (ctype_digit($id) && $id != null) {
            $res = true;
        }
        return $res;
    }

    public static function getAllPersonajes(){

    }

}