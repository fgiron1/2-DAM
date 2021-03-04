public class Main {
    public static void main (String[] args){
        Thread hilo = new Thread(new MyThread());
        hilo.start();
    }
}
