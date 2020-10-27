<?php

include "../class/Person.php";

$tmp_filename = $_FILES["profilepic"]["tmp_name"];
var_dump($tmp_filename);
//Checking file upload. If unsuccessful, registration ends


$name = $_POST["name"];
$surname = $_POST["surname"];
$birthdate = $_POST["birthdate"];
$address = $_POST["address"];
$filename = $_FILES["profilepic"]["name"];
echo "Yes1!";
//File extension is missing
$client = new Person("/uploads/".$filename, $name, $surname, $birthdate, $address);
var_dump($client);

echo "Yes2!";


