public class Main {
    public static Object obj = new Object();

    public static void main (String[] args){
        Thread hilo1 = new Thread(new Hola());
        Thread hilo2 = new Thread(new Adios());

        hilo1.start();
        hilo2.start();
    }
}
