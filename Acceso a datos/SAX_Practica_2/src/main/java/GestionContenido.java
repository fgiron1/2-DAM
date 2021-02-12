


/**
 * @description ssfdsfds
 * @author Leo
 */
import org.xml.sax.helpers.*;
import org.xml.sax.*;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;

public class GestionContenido extends DefaultHandler {

    //El objeto "a" nos permite persistir la información para comunicarla entre los métodos
    //endElement y characters. Se reusa con la información de la apuesta que el parser
    //está leyendo en cada momento

    Apuesta a = new Apuesta();

    //Estos flags nos ayudan a comunicarnos con el metodo characters
    //Avisando de la etiqueta que se está leyendo actualmente

    boolean flagUsuario;
    boolean flagPartido;
    boolean flagCantidad;
    boolean flagFecha;
    boolean flagResultado;
    boolean flagOverunder;
    boolean flagDiferencia;
    boolean flagHandicap;

    public GestionContenido() {
        super();
    }
    @Override
    public void startDocument(){
        
    }
    @Override
    public void endDocument(){
        System.out.println("Fin del documento XML");
    }
    @Override
    public void startElement(String uri, String nombre, String nombreC, Attributes att){

        //Específicas del tipo de apuesta
        switch (nombreC) {
            case "usuario" -> flagUsuario = true;
            case "partido" -> flagPartido = true;
            case "cantidad" -> flagCantidad = true;
            case "fecha" -> flagFecha = true;
            case "resultado" -> flagResultado = true;
            case "overunder" -> flagOverunder = true;
            case "diferencia" -> flagDiferencia = true;
            case "handicap" -> flagHandicap = true;
        }

    }
    @Override
    public void endElement(String uri, String nombre, String nombreC){

        //Aquí la sentencia SQL que usa el objeto
        //Aqui empleamos un objeto que se encargue de conectar con la base de datos
        //y ejecutar las sentencias

        if(nombreC == "apuesta"){



        }



    }



    @Override
    public void characters (char[] ch, int inicio, int longitud) throws SAXException{
        String cad = new String(ch, inicio, longitud);

        //Con la informacion parseada, le asignamos valores a un objeto Apuesta en listadoApuestas

        //El formato de fecha aceptado es yyyy/MM/dd

        if(flagUsuario){a.setUsuario(Integer.parseInt(cad));}
        if(flagPartido){a.setPartido(Integer.parseInt(cad));}
        if(flagCantidad){a.setCantidad(Float.parseFloat(cad));}

        //Usamos un SimpleDateFormat para transformar un String en un Date

        SimpleDateFormat formateo = new SimpleDateFormat("yyyy/MM/dd");

        if(flagFecha){
            try {
                a.setFecha( formateo.parse(cad));
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }

        if(flagResultado){a.setResultado(cad);}

        if(flagOverunder){a.setOverunder(Boolean.parseBoolean(cad));}
        if(flagDiferencia){a.setDiferencia(Float.parseFloat(cad));}
        if(flagHandicap){a.setHandicap(Integer.parseInt(cad));}

    }
}
