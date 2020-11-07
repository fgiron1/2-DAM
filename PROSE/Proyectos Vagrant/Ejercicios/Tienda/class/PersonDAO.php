<?php

require_once "DAO.php";
require_once  "Person.php";

class PersonDAO extends DAO
{
    const SCHEMA="`Ejemplo_Persona`";
    const NAME_TABLE="`Person`";

    //CREATE TABLE Person
    public function createTable(){
        $sql = "CREATE TABLE ".self::SCHEMA.".".self::NAME_TABLE." (".
            "`idPerson` INT AUTO_INCREMENT NOT NULL,".
            "`name` VARCHAR(45) NOT NULL,".
            "`surname` VARCHAR(45) NOT NULL,".
            "`picture` VARCHAR(30000) NULL,".
            "`birthdate` VARCHAR(45) NULL,".
            "`password` VARCHAR(100) NOT NULL)".
            "PRIMARY KEY (`idPerson`));";
        parent::query($sql);

    }


    //Obtener todos las personas con una determinada edad
    //(Ejemplo para ver el uso de prepare)
    public function getPersonsByAge($age){

        //Obtenemos los registros con la edad $age, usando prepare
        $this->openConnection();
        $stmt=$this->conexion->prepare(
            "SELECT * FROM ".self::SCHEMA.".".self::NAME_TABLE.
            " WHERE age= ?");
        $stmt->bind_param('i', $age);
        $stmt->execute();
        $result = $stmt->get_result();
        //Obtenemos una array de objetos personas a partir de los registros
        $persons=$this->getArrayPersonsFromResultSet($result);

        //Cerramos la conexión
        $this->closeConnection();
        //Devolvemos la array con las personas
        return $persons;
    }

    //Inserta un objeto de la clase persona en la BD
    public function insertPerson($person){

        $sql="INSERT INTO ".self::SCHEMA.".".self::NAME_TABLE.
            " (`name`, `surname`, `picture`, `birthdate`) VALUES ('".$person->getName()."', '".$person->getSurname()."', '".$person->getPicture()."','".$person->getBirthdate()."')";
        parent::query($sql);
    }

    private function getArrayPersonsFromResultSet($result){
        //Creamos una array de objetos Person
        $persons=array();
        //por cada registro de la BD vamos a crear un objeto Person y guardarlo en la array
        for($i=0;$i<$result->num_rows;$i++) {
            //Obtenemos el registro
            $row = $result->fetch_assoc();
            //Creamos el objeto persona y seteamos los valores
            $person = new Person();
            $person->setBirthdate($row["birthdate"]);
            $person->setName($row["name"]);
            $person->setPicture($row["picture"]);
            $person->setSurname($row["surname"]);
            //Guardamos el objeto persona en la array
            $persons[$i] = $person;
        }
        return $persons;
    }





}