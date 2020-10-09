<?php


class Person
{
    private $edad;

    /*
     *@return int
     */
    public function getEdad(){return $this->$edad;}

    /*
     * @return void
     */
    public function setEdad($edad){$this->$edad = $edad;}
}