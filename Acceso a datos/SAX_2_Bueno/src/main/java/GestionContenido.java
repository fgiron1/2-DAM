import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;
import practica.Incidencias;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBElement;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import java.io.File;
import java.sql.SQLException;
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

        JAXBElement<Incidencias> incidencias = conexion.getFactory().createIncidencias(conexion.getIncidencias());

        File file = new File("./incidencias.xml"); //Ruta relativa
        JAXBContext jaxbContext = null;
        try {
            jaxbContext = JAXBContext.newInstance(Incidencias.class);
            Marshaller jaxbMarshaller = jaxbContext.createMarshaller();
            jaxbMarshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
            jaxbMarshaller.marshal(incidencias, file);
        } catch (JAXBException e) {
            e.printStackTrace();
        }

        System.out.println("Fin del documento XML");
    }
    @Override
    public void startElement(String uri, String nombre, String nombreC, Attributes att){

        //Específicas del tipo de apuesta
        switch (nombreC) {
            case "usuario": flagUsuario = true; break;
            case "partido": flagPartido = true; break;
            case "cantidad": flagCantidad = true; break;
            case "fecha": flagFecha = true; break;
            case "resultado": flagResultado = true; break;
            case "overunder": flagOverunder = true; break;
            case "diferencia": flagDiferencia = true; break;
            case "handicap": flagHandicap = true; break;
        }

    }
    @Override
    public void endElement(String uri, String nombre, String nombreC){

        //Intentamos grabar la apuesta en la etiqueta de cierre de cada
        //elemento "apuesta", en el XML

        //Identificamos el tipo de apuesta
        //Si "resultado" tiene valor, no puede tenerlo ni "handicap" ni "overunder"
        //porque solo puede ser un tipo de apuesta a la vez

        if(nombreC.equals("apuesta")){

            try {
                if (!isNull(a.getResultado())) {

                    //Apuesta resultado
                    conexion.insertarApuesta(a);

                } else if (!isNull(a.getOverunder())) {

                    //Apuesta overunder
                    conexion.insertarApuestaOverUnder(a);

                } else {

                    //Apuesta diferencia
                    conexion.insertarApuestaDiferencia(a);

                }

            } catch(SQLException e) {
                e.printStackTrace();
            }

            //Reseteamos el objeto para no tener información
            //de apuestas anteriores
            a = new Apuesta();

        }



    }
    @Override
    public void characters (char[] ch, int inicio, int longitud) throws SAXException{

        String cad = new String(ch, inicio, longitud);

        //Con la informacion parseada, le asignamos valores a un objeto Apuesta en listadoApuestas
        //El formato de fecha aceptado es yyyy-MM-dd

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
