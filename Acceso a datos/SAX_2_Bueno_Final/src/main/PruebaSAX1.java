package main;

/**
 *
 * @author Leo
 */

import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class PruebaSAX1 {
    
    XMLReader procesadorXML;
    GestionContenido gestor;
    InputSource archivoXML;
    
    public PruebaSAX1 (String nombreArchivo){
        try {
            SAXParserFactory parserFactory = SAXParserFactory.newInstance();
            SAXParser parser = parserFactory.newSAXParser();
            procesadorXML = parser.getXMLReader();
        } catch (SAXException ex) {
            Logger.getLogger(PruebaSAX1.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ParserConfigurationException ex) {
            Logger.getLogger(PruebaSAX1.class.getName()).log(Level.SEVERE, null, ex);
        }
        gestor = new GestionContenido();
        procesadorXML.setContentHandler(gestor);
        archivoXML = new InputSource(nombreArchivo);
    }
    void leerArchivo(){
        try {
            procesadorXML.parse(archivoXML);
        } catch (IOException ex) {
            Logger.getLogger(PruebaSAX1.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SAXException ex) {
            Logger.getLogger(PruebaSAX1.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
// Fin PruebaSAX1
