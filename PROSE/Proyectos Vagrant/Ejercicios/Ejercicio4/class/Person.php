<?php


class Person
{
    //I've decided on storing the path to the image in this variable, but the image may change its path
    private $profilepic;
    private $name;
    private $surname;
    private $birthdate; //Need to check for a proper date format
    private $address;

    public function __construct($profilepic, $name, $surname, $birthdate, $address){

        $this->profilepic = $profilepic;
        $this->name = $name;
        $this->surname = $surname;
        $this->birthdate = $birthdate;
        $this->address = $address;
    }

    public function getProfilePic(){return $this->profilepic;}
    public function getName(){return $this->name;}
    public function getSurname(){return $this->surname;}
    public function getBirthdate(){return $this->birthdate;}
    public function getAddress(){return $this->address;}

    public function setProfilePic($profilepic){$this->profilepic = $profilepic;}
    public function setName($name){$this->name = $name;}
    public function setSurname($surname){$this->surname = $surname;}
    public function setBirthdate($birthdate){$this->birthdate = $birthdate;}
    public function setAddress($address){$this->address = $address;}

}