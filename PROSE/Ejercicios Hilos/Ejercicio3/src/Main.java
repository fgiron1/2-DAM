
public class Main {

    public static void main (String[] args){
        Thread hilo1 = new Thread(new Run1());
        Thread hilo2 = new Thread(new Run2());

        hilo1.start();
        hilo2.start();
    }
}
