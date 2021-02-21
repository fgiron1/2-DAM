package Ejercicio2;

public class Hilo1 implements Runnable{

    private static Object monitor = new Object();

    public static Object getMonitor(){return monitor;}

    @Override
    public void run(){

        synchronized(monitor) {
            for(int i = 0; i < 50; i++){

                System.out.print("Hola\n");
                monitor.notify();

                try {
                    monitor.wait();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }

            }

        }

    }


}
