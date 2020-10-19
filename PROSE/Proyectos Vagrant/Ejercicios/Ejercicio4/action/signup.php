<?php


$tmp_filename = $_FILES["profilepic"]["tmp_name"];

//Checking file upload. If unsuccessful, registration ends
if(move_uploaded_file($tmp_filename, "/uploads")){

$name = $_POST["name"];
$surname = $_POST["surname"];
$birthdate = $_POST["birthdate"];
$address = $_POST["address"];
$filename = $_FILES["profilepic"]["name"];

//File extension is missing
$client = new Person("/uploads/".$filename, $name, $surname, $birthdate, $address);


} else {
    echo "Invalid file. Please try signing up again";
}



