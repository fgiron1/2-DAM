import java.util.Date;

public class Apuesta {

    int usuario;

    int partido;
    float cantidad;
    Date fecha;
    //Puede ser 1, X o 2
    String resultado;
    //boolean no nos permite diferenciar que el campo este vacío
    //porque tanto false como true tienen significados. Usamos String
    String overunder;
    float diferencia;
    int handicap;
    int output;


    public int getOutput() { return output; }

    public void setOutput(int output) { this.output = output; }

    public int getUsuario() {
        return usuario;
    }

    public void setUsuario(int usuario) {
        this.usuario = usuario;
    }

    public int getPartido() {
        return partido;
    }

    public void setPartido(int partido) {
        this.partido = partido;
    }

    public float getCantidad() {
        return cantidad;
    }

    public void setCantidad(float cantidad) {
        this.cantidad = cantidad;
    }

    public Date getFecha() {
        return fecha;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    public String getResultado() {
        return resultado;
    }

    public void setResultado(String resultado) {
        this.resultado = resultado;
    }

    public String getOverunder() {
        return overunder;
    }

    public void setOverunder(String overunder) {
        this.overunder = overunder;
    }

    public float getDiferencia() {
        return diferencia;
    }

    public void setDiferencia(float diferencia) {
        this.diferencia = diferencia;
    }

    public int getHandicap() {
        return handicap;
    }

    public void setHandicap(int handicap) {
        this.handicap = handicap;
    }
}
