package Ejercicio3;

import java.util.Random;
import java.util.Scanner;

public class Hilo1 implements Runnable{

    private static Object monitor = new Object();
    private static int aleatorio = -1;

    //Asignamos un numero distinto a aleatorio y a entrada
    //de Hilo2 para que en la primera iteración no coincidan
    //Además, ambos números están fuera del rango de números aleatorios posibles

    public static int getAleatorio() { return aleatorio; }
    public static void setAleatorio(int newValue){aleatorio = newValue;}

    public static Object getMonitor(){return monitor;}

    public static void main(String[] args){

        Thread hilo1 = new Thread(new Hilo1());
        Thread hilo2 = new Thread(new Hilo2());

        hilo1.start();
        hilo2.start();


    }

    @Override
    public void run(){

        synchronized(monitor) {

            //We store a newly generated arbitrary number and print it on screen
            setAleatorio(rand(1, 20));
            System.out.print(aleatorio);

            //We wake the other thread up and go to sleep
            monitor.notify();

            try {
                monitor.wait();
            } catch(InterruptedException e) {
                e.printStackTrace();
            }


        }

    }

    public int rand(int min, int max){

        Random r = new Random();
        return r.nextInt(max - min + 1) + min;
    }


}
