<?php


/*Clase abstracta diseñada para acceder a una base de datos MySQL*/
class DAO
{

    //Datos para conectarse a la BD MySQL del Servidor
    const SCHEMA="`Ejemplo_Persona`";
    const SERVER_MYSQL = "localhost:3306";
    const USER_MYSQL = "root";
    const PASSWORD_MYSQL = "mitesoro";

    /*Atributos*/
    public $conexion;

    //Crea un nuevo schema en la base de datos
    public function createSchema(){
        $sql = "CREATE SCHEMA ".$this::SCHEMA.";";
        $this->query($sql);

    }


    //Método utilizado para abrir una conexion con la BD
    public function openConnection()
    {
        $this->conexion=new mysqli(self::SERVER_MYSQL, self::USER_MYSQL, self::PASSWORD_MYSQL);
        if ( $this->conexion->connect_error) {
            echo " <br> Failed to connect to MySQL: " .  $this->conexion->connect_error . "<br>";
        }
        return  $this->conexion;
    }

    //Método utilizado para ejecutar una sentencia SQL, sin preparar, y sin resultados a obtener
    public function query($sql)
    {
        //Abrimos la conexión con la BD
        $this->openConnection();

        //Ejecutamos la sentencia SQL
        $sucess =  $this->conexion->query($sql);

        //Comprobamos si ha habido algún error
        if ($sucess === FALSE) {
            echo "<br> Error executing: " . $sql . "<br>";
        }

        //Cerramos la conexion
        $this->closeConnection();
    }

    //Método utilizado para ejecutar una sentencia SQL, sin preparar, con resultados a obtener.
    //Por ello no se cierra la conexión, y se devuelve el resultado de la ejecución de la sentencia
    public function query_with_result($sql)
    {
        //Abrimos la conexión con la BD
        $this->openConnection();

        //Ejecutamos la sentencia SQL
        $sucess =  $this->conexion->query($sql);

        //Comprobamos si ha habido algún error
        if ($sucess === FALSE) {
            echo "<br> Error executing: " . $sql . "<br>";
        }

        return $sucess;
    }

    //Método utilizado para cerrar la conexión
    public function closeConnection(){

        /* Consignar y consolidar la transacción */
        if (! $this->conexion->commit()) {
            print("Error with transaction\n");
        }
        //Cerramos la conexion
        $this->conexion->close();
    }
}