<?php


class LibroPersonajeModel
{
    private $titulo;
    private $codigo;
    private $numpag;
    private $listaPersonajes;

    public function __construct(LibroModel $libro, $listaPersonajes){

        $this->codigo = $libro->getCodigo();
        $this->titulo = $libro->getTitulo();
        $this->numpag = $libro->getNumpag();
        $this->listaPersonajes = $listaPersonajes;

    }

}