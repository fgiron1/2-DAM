


/**
 * @description ssfdsfds
 * @author Leo
 */
import org.xml.sax.helpers.*;
import org.xml.sax.*;
public class GestionContenido extends DefaultHandler {

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
        System.out.println("\t[/ "+nombreC +"]");
    }

    //Tengo que almacenar lo que haya dentro de las etiquetas en el objeto "a" para despues mandarlo
    //a través del JDBC a la base de datos. Si la apuesta no es válida, se captura la excepción


    @Override
    public void characters (char[] ch, int inicio, int longitud) throws SAXException{
        String cad = new String(ch, inicio, longitud);


    }
}
