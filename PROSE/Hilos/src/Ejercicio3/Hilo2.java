package Ejercicio3;

import java.util.Random;
import java.util.Scanner;

public class Hilo2 implements Runnable{

    @Override
    public void run() {
        Scanner sc=new Scanner(System.in);
        int valorIntroducido=sc.nextInt();
        if(valorIntroducido== Hilo1.getValor()){
            Hilo1.setRun(false);
        }

    }
}