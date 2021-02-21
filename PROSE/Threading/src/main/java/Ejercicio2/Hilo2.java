package Ejercicio2;

public class Hilo2 implements Runnable{

    public static void main(String[] args) {

        Thread hilo1 = new Thread(new Hilo1());
        Thread hilo2 = new Thread(new Hilo2());

        hilo1.start();
        hilo2.start();


    }

    @Override
    public void run(){

        synchronized(Hilo1.getMonitor()){

            for(int i = 0; i < 50; i++){

                System.out.print("Adios\n");

                Hilo1.getMonitor().notify();

                try {
                    Hilo1.getMonitor().wait();
                } catch (InterruptedException e){
                    e.printStackTrace();
                }

            }
        }
    }
}
