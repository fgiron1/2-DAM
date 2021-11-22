import com.microsoft.sqlserver.jdbc.SQLServerException;
import practica.Incidencia;
import practica.Incidencias;
import practica.ObjectFactory;
import java.sql.*;
import java.text.DateFormat;
import java.text.SimpleDateFormat;

public class Conexion {

	private String sourceURL = "jdbc:sqlserver://localhost:1433";
	private String usuario = "prueba1234";
	private String password = "prueba1234";
	private Incidencias incidencias;

	private ObjectFactory factory = new ObjectFactory();

	private Connection conexionBaseDatos;

	public Conexion(){

		this.incidencias = factory.createIncidencias();

		try{
			conexionBaseDatos = (DriverManager.getConnection(sourceURL, usuario, password));
			conexionBaseDatos.setAutoCommit(true);
		}catch(SQLException e){
			e.printStackTrace();
		}

	}

	public Incidencias getIncidencias() {
		return incidencias;
	}

	public void setIncidencias(Incidencias incidencias) { this.incidencias = incidencias; }

	public ObjectFactory getFactory() {
		return factory;
	}

	public void setFactory(ObjectFactory factory) {
		this.factory = factory;
	}

	//Nombre procedimiento en SQL: GrabarApuestaGanadoresPartidos

	public void insertarApuesta(Apuesta apuesta) throws SQLServerException {

		//int IDUsuario, int Partido, float Cantidad, LocalDate fecha, String resultado
		//Además, se le tiene que poner la variable del output o da error

		String sql = "EXECUTE GrabarApuestaGanadoresPartidos ?, ?, ?, ?, ?, ?";

		try{

			//Instanciamos un objeto de tipo java.sql.Date, que toma por parámetros
			//milisegundos desde el epoch, obtenidos con el método de la clase java.util.Date
			//de getTime()

			Date fechaSql = new Date(apuesta.getFecha().getTime());

			CallableStatement statement = conexionBaseDatos.prepareCall(sql);

			statement.setInt(1, apuesta.getUsuario());
			statement.setInt(2, apuesta.getPartido());
			statement.setFloat(3, apuesta.getCantidad());
			statement.setDate(4, fechaSql);
			statement.setString(5, apuesta.getResultado());
			statement.registerOutParameter(6, Types.INTEGER);

			statement.executeUpdate();

			//Asignamos el resultado del procedimiento al objeto apuesta
			apuesta.setOutput(statement.getInt(6));

			statement.close();


		} catch(SQLException e){
			grabarIncidencia(apuesta, e.getMessage());
		}

	}

	public void insertarApuestaOverUnder(Apuesta apuesta) throws SQLServerException{

		String sql = "EXECUTE GrabarApuestaOverUnder ?, ?, ?, ?, ?, ?, ?";

		try{

			//Instanciamos un objeto de tipo java.sql.Date, que toma por parámetros
			//milisegundos desde el epoch, obtenidos con el método de la clase java.util.Date
			//de getTime()

			Date fechaSql = new Date(apuesta.getFecha().getTime());

			CallableStatement statement = conexionBaseDatos.prepareCall(sql);

			statement.setInt(1, apuesta.getUsuario());
			statement.setInt(2, apuesta.getPartido());
			statement.setFloat(3, apuesta.getCantidad());
			statement.setDate(4, fechaSql);
			statement.setString(5, apuesta.getOverunder());
			statement.setFloat(6, apuesta.getDiferencia());
			statement.registerOutParameter(7, Types.INTEGER);

			statement.executeUpdate();

			//Asignamos el resultado del procedimiento al objeto apuesta
			apuesta.setOutput(statement.getInt(7));

			statement.close();



		} catch(SQLException e){
			grabarIncidencia(apuesta, e.getMessage());
		}

	}

	public void insertarApuestaDiferencia(Apuesta apuesta) throws SQLServerException{

		String sql = "EXECUTE GrabarApuestaHandicap ?, ?, ?, ?, ?, ?";

		try{

			//Instanciamos un objeto de tipo java.sql.Date, que toma por parámetros
			//milisegundos desde el epoch, obtenidos con el método de la clase java.util.Date
			//de getTime()

			Date fechaSql = new Date(apuesta.getFecha().getTime());

			CallableStatement statement = conexionBaseDatos.prepareCall(sql);

			statement.setInt(1, apuesta.getUsuario());
			statement.setInt(2, apuesta.getPartido());
			statement.setFloat(3, apuesta.getCantidad());
			statement.setDate(4, fechaSql);
			statement.setInt(5, apuesta.getHandicap());
			statement.registerOutParameter(6, Types.INTEGER);

			statement.executeUpdate();

			//Asignamos el resultado del procedimiento al objeto apuesta
			apuesta.setOutput(statement.getInt(6));

			statement.close();


		} catch(SQLException e){
			grabarIncidencia(apuesta, e.getMessage());
		}

	}

	public void grabarIncidencia(Apuesta apuesta, String mensajeError){

		//usuario -> usuario
		//fecha -> fecha
		//evento -> partido
		//importe -> cantidad
		//motivoRechazo -> mensajeError

		//Creamos una nueva incidencia y la añadimos a la lista de incidencias
		incidencias.getIncidencia().add(factory.createIncidencia());

		//Cogemos la referencia del último elemento insertado
		Incidencia inc = incidencias.getIncidencia().get(incidencias.getIncidencia().size() - 1);

		//Asignamos los valores a la incidencia
		inc.setUsuario(String.valueOf(apuesta.getUsuario()));
		DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
		inc.setFecha(dateFormat.format(apuesta.getFecha()));
		inc.setEvento(String.valueOf(apuesta.getPartido()));
		inc.setImporte(String.valueOf(apuesta.getCantidad()));
		inc.setMotivoRechazo(mensajeError);


	}

}

