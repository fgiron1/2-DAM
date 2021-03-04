package Ejercicio1;

import java.util.Random;

public class Hilo1 implements Runnable {
    @Override
    public void run() {
        for(int i=0;i<5;i++){
            System.out.println(new Random().nextInt());
        }
    }
}
