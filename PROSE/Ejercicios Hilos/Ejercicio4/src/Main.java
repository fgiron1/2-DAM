import java.util.Random;
import java.util.Scanner;

public class Main {
    public static void main (String[] args) throws InterruptedException {

        Object monitor = new Object();

        //CREAMOS EL CONTENIDO DEL ARRAY
        System.out.print("El array es ");
        int[] array = new int[9000];

        Random r = new Random();
        for(int i = 0; i < 9000; i++){
            if(i >= 4500){
                array[i] = 9000 - i;
            } else {
                array[i] = i;
            }

        }


        //UTILIZAMOS EL MÉTODO SECUENCIAL
        long inicio = System.currentTimeMillis();
        int sumaTotal = Gestora.sumarElementosRepetidos(array);
        long fin = System.currentTimeMillis();
        long tiempoTotal = fin - inicio;
        System.out.println("\nLa suma total es: "+sumaTotal+" y ha tardado "+tiempoTotal+" milisegundos");

        //CREAMOS LOS HILOS
        Thread hilo1 = new Thread(new Run(array, 0, array.length/2, monitor));
        Thread hilo2 = new Thread(new Run(array, array.length/2, array.length, monitor));
        inicio = System.currentTimeMillis();
        hilo1.start();
        hilo2.start();

        hilo1.join();
        hilo2.join();

        //El hilo principal espera a que se muera el primer hilo
        //y seguidamente, el segundo; ya se garantiza la suma total a la hora
        //de llamar a getSumaTotal()

        /*synchronized (monitor){
            try {
                monitor.wait();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }*/

        //Los dos hilos creados comienzan su ejecución y el hilo principal se duerme
        //Acaba el primer hilo, y seguidamente acaba el segundo. Al acabar el segundo,
        //como sabemos cuando se han acabado ambas operaciones, sencillamente despertamos el hilo principal
        //y ya podemos llamar a Run.getSumaTotal(); con la seguridad de que es la suma total.
        //El synchronized en los run es para poder despertar al hilo principal desde los run con notifyAll()


        fin = System.currentTimeMillis();
        tiempoTotal = fin - inicio;
        int suma = Run.getSumaTotal();
        System.out.println("La suma total por hilos es de: "+suma+" y ha tardado "+tiempoTotal+" milisegundos");
    }


}
