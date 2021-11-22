package Ejercicio2;

public class Hilo1 implements Runnable{

    private static Object monitor=new Object();

    @Override
    public  void run() {
        synchronized(monitor){
        for (int i=0;i<50;i++){

                System.out.println("Hola");
                monitor.notify();
                try{
                    monitor.wait();
                }catch(Exception e){

                }
            }

        }
    }

    public static Object getMonitor() {
        return monitor;
    }

}
