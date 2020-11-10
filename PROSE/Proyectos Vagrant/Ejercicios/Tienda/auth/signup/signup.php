<?php


include_once("./class/PersonDAO.php");
include_once("./class/DAO.php");
include_once("./class/Person.php");


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

$Person->setName($_POST["inputName"]);
$Person->setSurname($_POST["inputSurname"]);
$Person->setBirthdate($_POST["inputBirthdate"]);
$Person->setPassword(password_hash($_POST["inputPassword"],PASSWORD_DEFAULT));

var_dump($Person);
$PersonDAO->openConnection();
$PersonDAO->insertPerson($Person);
$PersonDAO->closeConnection();