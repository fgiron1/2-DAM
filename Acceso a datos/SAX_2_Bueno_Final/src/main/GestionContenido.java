package main;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import java.text.ParseException;
import java.text.SimpleDateFormat;

import static java.util.Objects.isNull;

public class GestionContenido extends DefaultHandler {

    //El objeto "a" nos permite persistir la información para comunicarla entre los métodos
    //endElement y characters. Se reusa con la información de la apuesta que el parser
    //está leyendo en cada momento

    Apuesta a = new Apuesta();
    Conexion conexion = new Conexion();

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

        //Identificamos el tipo de apuesta
        //Si resultado tiene valor, no puede tenerlo ni handicap ni overunder

        if(nombreC.equals("apuesta")){


            if(!isNull(a.getResultado())){
                //Apuesta resultado
                conexion.insertarApuesta(a);
            } else if(!isNull(a.getOverunder())){
                //Apuesta overunder
                conexion.insertarApuestaOverUnder(a);
            } else{
                //Apuesta diferencia
                conexion.insertarApuestaDiferencia(a);
            }

        }



    }



    @Override
    public void characters (char[] ch, int inicio, int longitud) throws SAXException{

        String cad = new String(ch, inicio, longitud);

        //Con la informacion parseada, le asignamos valores a un objeto Apuesta en listadoApuestas
        //El formato de fecha aceptado es yyyy/MM/dd

        //Después de realizar la asignación, volvemos a asignar false a cada flag
        //para próximas iteraciones de este método

        if(flagUsuario){a.setUsuario(Integer.parseInt(cad)); flagUsuario = false;}
        if(flagPartido){a.setPartido(Integer.parseInt(cad)); flagPartido = false;}
        if(flagCantidad){a.setCantidad(Float.parseFloat(cad)); flagCantidad = false;}

        //Usamos un SimpleDateFormat para transformar un String en un Date

        SimpleDateFormat formateo = new SimpleDateFormat("yyyy-MM-dd");

        if(flagFecha){
            try {
                a.setFecha(formateo.parse(cad));
            } catch (ParseException e) {
                e.printStackTrace();
            } finally{
                flagFecha = false;
            }
        }

        if(flagResultado){a.setResultado(cad); flagResultado = false;}
        if(flagOverunder){a.setOverunder(cad); flagOverunder = false;}
        if(flagDiferencia){a.setDiferencia(Float.parseFloat(cad)); flagDiferencia = false;}
        if(flagHandicap){a.setHandicap(Integer.parseInt(cad)); flagHandicap = false;}

    }
}
