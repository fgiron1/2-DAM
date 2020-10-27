<?php

//Checking if the data has been sent
var_dump($_POST);

if(!isset($_POST["inputName"],
          $_POST["inputSurname"],
          $_POST["inputBirthdate"],
          $_POST["inputPassword"],
          $_POST["inputRepeatPassword"]) &&
          $_SERVER["REQUEST_METHOD"] != "POST"){
    exit("Please complete the registration form");
}

//Checking whether the fields are empty or not
if(empty($_POST["inputName"]) ||
    empty($_POST["inputSurname"]) ||
    empty($_POST["inputBirthdate"]) ||
    empty($_POST["inputPassword"]) ||
    empty($_POST["inputRepeatPassword"])){
    exit("Please fill out all the fields");
}

if($_POST["inputPassword"] !== $_POST["inputRepeatPassword"]){
    exit("Passwords don't match");
}

//TODO CREAR OBJETO USUARIO
//TODO HACERLO CON SESIONES

echo ("Heyyy you did it");