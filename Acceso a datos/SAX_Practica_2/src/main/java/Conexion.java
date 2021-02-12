import java.sql.*;
import java.sql.Connection;

public class Conexion {

	String sourceURL = "jdbc:sqlserver://localhost";
	String usuario = "prueba";
	String password = "123";
	
 
	Connection conexionBaseDatos = (DriverManager.getConnection(sourceURL, usuario, password));

}

public static void insertarApuesta(int IDUsuario, int Partido, float Cantidad, SimpleDateFormat fecha, String resultado){


}

public static void insertarApuestaOverUnder(int IDUsuario, int Partido, float Cantidad, SimpleDateFormat fecha, boolean overunder, float diferencia){


}

public static void insertarApuestaDiferencia(int IDUsuario, int Partido, float Cantidad, SimpleDateFormat fecha, int handicap){


}