import java.util.Random;

public class Run1 implements Runnable{

    private static boolean exito = false;

    @Override
    public void run() {
        Random rnd = new Random();
        int numero;

        do{
            numero = rnd.nextInt(10)+1;
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                System.out.println("ERROR");
            }
            if(Run2.getNumeroIntroducido() == numero){
                exito = true;
                System.out.println("¡ENHORABUENA!");
            } else{
                System.out.println("El numero es: "+numero);
            }

        }while(!exito);
    }

    public static boolean isExito() {
        return exito;
    }
}
