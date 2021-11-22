package Ejercicio2;

public class Ejercicio2Main {
    public static void main(String[] args) {
        Hilo1 hola=new Hilo1();
        Hilo2 adios=new Hilo2();
        Thread t1=new Thread(hola);
        Thread t2=new Thread(adios);
        t1.start();
        t2.start();
    }
}
