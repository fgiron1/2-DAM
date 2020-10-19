<?php

$usuario = new Person(date("Y") - $_GET["año"]);

echo "Tienes ".$usuario->getEdad()." años";