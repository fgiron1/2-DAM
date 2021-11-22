package Ejercicio2;

public class Hilo2 implements Runnable{
    @Override
    public void run() {
        synchronized ( Hilo1.getMonitor()){
        for (int i=0;i<50;i++){

                System.out.println("Adios");
                Hilo1.getMonitor().notify();

                try {
                    Hilo1.getMonitor().wait();
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }

        }
    }
}
