package Ejercicio3;

public class Ejercicio3Main {
    public static void main(String[] args) {

        Hilo1 contador=new Hilo1();
        Hilo2 input= new Hilo2();
        Thread t1=new Thread(contador);
        Thread t2=new Thread(input);
        t1.start();
        t2.start();

    }
}