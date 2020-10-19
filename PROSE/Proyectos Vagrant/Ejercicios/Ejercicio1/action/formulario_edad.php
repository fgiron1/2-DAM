<?php

$cliente = new Person($_POST['edad']);

echo "Tu edad es ".$cliente->getEdad();

if($cliente->getEdad()>=18){
    echo "Eres mayor de edad";
} else {
    echo "Eres menor de edad";
}