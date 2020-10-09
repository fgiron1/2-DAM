<?php
echo "Tu edad es".$_POST['edad'];

$edad = $_POST['edad'];

if($edad>=18){
    echo "Eres mayor de edad";
} else {
    echo "Eres menor de edad";
}