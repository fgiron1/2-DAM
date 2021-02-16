import java.sql.*;
import java.sql.Connection;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;

public class Conexion {

	private String sourceURL = "jdbc:sqlserver://localhost";
	private String usuario = "prueba3";
	private String password = "123";

	private static Connection conexionBaseDatos;

	public Conexion(){

		try{
			conexionBaseDatos = (DriverManager.getConnection(sourceURL, usuario, password));
		}catch(SQLException e){
			e.printStackTrace();
		}

	}
	//Nombre procedimiento en SQL: GrabarApuestaGanadoresPartidos

	public static void insertarApuesta(Apuesta apuesta){

		//int IDUsuario, int Partido, float Cantidad, LocalDate fecha, String resultado

		String sql = "EXECUTE GrabarApuestaGanadoresPartidos ?, ?, ?, ?, ?";

		try{

			//Instanciamos un objeto de tipo java.sql.Date, que toma por parámetros
			//milisegundos desde el epoch, obtenidos con el método de la clase java.util.Date
			//de getTime()

			java.sql.Date fechaSql = new java.sql.Date(apuesta.getFecha().getTime());

			CallableStatement statement = conexionBaseDatos.prepareCall(sql);

			statement.setInt(1, apuesta.getUsuario());
			statement.setInt(2, apuesta.getPartido());
			statement.setFloat(3, apuesta.getCantidad());
			statement.setDate(4, fechaSql);
			statement.setString(5, apuesta.getResultado());

			//No hemos usado el resultado de salida

			statement.executeUpdate();


		} catch(SQLException e){
			e.printStackTrace();
		}

	}

	public static void insertarApuestaOverUnder(Apuesta apuesta){

		String sql = "EXECUTE GrabarApuestaOverUnder ?, ?, ?, ?, ?, ?";

		try{

			//Instanciamos un objeto de tipo java.sql.Date, que toma por parámetros
			//milisegundos desde el epoch, obtenidos con el método de la clase java.util.Date
			//de getTime()

			java.sql.Date fechaSql = new java.sql.Date(apuesta.getFecha().getTime());

			CallableStatement statement = conexionBaseDatos.prepareCall(sql);

			statement.setInt(1, apuesta.getUsuario());
			statement.setInt(2, apuesta.getPartido());
			statement.setFloat(3, apuesta.getCantidad());
			statement.setDate(4, fechaSql);
			statement.setString(5, apuesta.getOverunder());
			statement.setFloat(6, apuesta.getDiferencia());


			statement.executeUpdate();


		} catch(SQLException e){
			e.printStackTrace();
		}

	}

	public static void insertarApuestaDiferencia(Apuesta apuesta){

		String sql = "EXECUTE GrabarApuestasHandicap ?, ?, ?, ?, ?";

		try{

			//Instanciamos un objeto de tipo java.sql.Date, que toma por parámetros
			//milisegundos desde el epoch, obtenidos con el método de la clase java.util.Date
			//de getTime()

			java.sql.Date fechaSql = new java.sql.Date(apuesta.getFecha().getTime());

			CallableStatement statement = conexionBaseDatos.prepareCall(sql);

			statement.setInt(1, apuesta.getUsuario());
			statement.setInt(2, apuesta.getPartido());
			statement.setFloat(3, apuesta.getCantidad());
			statement.setDate(4, fechaSql);
			statement.setInt(5, apuesta.getHandicap());

			//No hemos usado el resultado de salida

			statement.executeUpdate();


		} catch(SQLException e){
			e.printStackTrace();
		}

	}

}

