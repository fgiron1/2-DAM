


/**
 *
 * @author Leo
 */
import org.xml.sax.helpers.*;
import org.xml.sax.*;
public class GestionContenido extends DefaultHandler {

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

        switch(nombreC){
            case "usuario":
                break;
            case "partido":
                break;
            case "cantidad":
                break;
            case "fecha":
                break;
            case "resultado":
                break;

                //Específicas del tipo de apuesta
            case "overunder":
                break;
            case "diferencia":
                break;
            case "handicap":
                break;
        }

    }
    @Override
    public void endElement(String uri, String nombre, String nombreC){
        System.out.println("\t[/ "+nombreC +"]");
    }
    @Override
    public void characters (char[] ch, int inicio, int longitud) throws SAXException{
        String cad = new String(ch, inicio, longitud);
        cad = cad.replaceAll("[\t\n]",""); // Quitamos tabuladores y saltos de linea
        System.out.println("\t\t" + cad);
    }
}
// FIN GestionContenido
