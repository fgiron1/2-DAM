<?php

include "../class/Person.php";

$año = $_GET["año"];

$usuario = new Person(date("Y") - $año);

var_dump($usuario);

echo "Tienes ".$usuario->getEdad()." años";