package Ejercicio3;

import java.util.Scanner;

public class Hilo2 implements Runnable {

    //We set an initial value for the first iteration
    //different from aleatorio
    private static int entrada = 0;

    @Override
    public void run(){

        //Este hilo pide el input del usuario durante 1 segundo

        synchronized(Hilo1.getMonitor()){


            while(entrada != Hilo1.getAleatorio()){

                //System.in is blocking
                Scanner input = new Scanner(System.in);
                entrada = input.nextInt();

                try {
                    //Si el otro hilo tardase más de 1 segundo, le interrumpiría a este?
                    Hilo1.getMonitor().wait(1000);
                } catch(InterruptedException e) {
                    e.printStackTrace();
                }
            }
            //We end the program
            System.exit(0);


        }


    }

}
