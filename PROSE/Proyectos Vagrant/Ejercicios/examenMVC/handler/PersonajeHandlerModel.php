<?php

require_once "../constants/ConsPersonajeModel.php";
require_once "../constants/ConsLibrosModel.php";

class PersonajeHandlerModel
{
    //This function returns the characters of a book using its id
    public static function getPersonajeByLibro($LibroId){

        $personajesList = Array();

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

            $prep_query = $db_connection->prepare($query);

            //Binding the parameter $LibroId to the query
            $prep_query->bind_param('s', $Libroid);

            //We use $id, $nombre and $edad to store the retrieved data from each row.
            $prep_query->bind_result($id, $nombre, $edad);

            try{
                $prep_query->execute();

                //Podriamos hacer esto más fácil con fetch_object, que te lo transforma ya a un objeto

                while ($prep_query->fetch()) {

                    //A new PersonajeModel is instantiated and added to the list
                    //using previously binded variables

                    $personaje = new PersonajeModel($id, $nombre, $edad);

                    $personajesList[] = $personaje;
                }

            }catch(Exception $e){
                print("Something went wrong with the database connection, sending empty array");
            }

        }

        $db_connection->close();

        return $personajesList;

    }

    //returns true if $id is a valid id for a book
    //In this case, it will be valid if it only contains
    //numeric characters and is non-null, even if this $id does not exist in
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