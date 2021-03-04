
import utils.Sequence;
import utils.ProducerConsumerUtils;

import java.util.Arrays;

public class Ejercicio5 {
    public static
    void main(String[] args) {
        final Sequence primeSequence = new Sequence<>(Ejercicio5::enesimoPrimo);

        final Runnable solucionProblema = ProducerConsumerUtils.produceConsume(
                Arrays.asList(primeSequence::next),

                Arrays.asList(System.out::println),

                10

        );


        solucionProblema.run();

    }


    /** Devuelve el enésimo número primo contando como el primero el 2 */
    public static int enesimoPrimo(int n) {
        int primosEncontrados = 0;
        int candidatoAPrimo = 2;

        while(primosEncontrados < n) {
            if (esPrimo(candidatoAPrimo))
            {
                primosEncontrados++;

            }


            candidatoAPrimo++;

        }


        return candidatoAPrimo - 1;
    }


    /** Indica si un número es primo*/
    public static boolean esPrimo(int num) {
        if(num == 2) {
            return true;
        }


        if (num % 2 == 0) {
            return false;
        }


        for (int i = 3; i <= Math.sqrt(num); i+= 2) {
            if (num % i == 0) {
                return false;
            }

        }

        return true;
    }

}