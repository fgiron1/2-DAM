<?php


//No se como coño se pone la ruta, no me coge ninguna, ni relativa ni absoluta
//Ni desde el directorio del vagrant ni desde el local
include_once "/vagrant/Ejercicios/Tienda/class/Person.php";
include_once "";
include_once "";



$var = getcwd();
echo $var;

//Checking if the data has been sent
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

$Person = new Person();
$PersonDAO = new PersonDAO();
echo "hi";
$Person->setName($_POST["inputName"]);
$Person->setSurname($_POST["inputSurname"]);
$Person->setBirthdate($_POST["inputBirthdate"]);
$Person->setPassword(password_hash($_POST["inputPassword"],PASSWORD_DEFAULT));
echo "Hey";
$PersonDAO->openConnection();
$PersonDAO->insertPerson($Person);
$PersonDAO->closeConnection();