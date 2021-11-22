package Ejercicio3;


import java.util.Random;

public class Hilo1 implements Runnable{

    private  static Object monitor;
    private static boolean run=true;
    private static int valor;

    @Override
    public void run() {

            while(run){
                valor=new Random().nextInt(10);
                System.out.println(valor);
                try{
                    Thread.sleep(1000);
                }catch (Exception e){

                }
            }




    }

    public static void setRun(boolean run) {
        Hilo1.run = run;
    }

    public static boolean isRun() {
        return run;
    }

    public static int getValor() {
        return valor;
    }
}