import java.util.Random;

public class MyThread implements Runnable{

    @Override
    public void run() {
        Random rnd = new Random();
        int numero;
        for(int i = 0; i < 10; i++){
            numero = rnd.nextInt(5)+1;
            System.out.println(numero);
        }
    }
}
