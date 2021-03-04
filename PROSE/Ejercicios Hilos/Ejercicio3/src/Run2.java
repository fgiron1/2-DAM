import java.util.Scanner;

public class Run2 implements Runnable {

    private static int numeroIntroducido;
    private boolean exito = false;

    @Override
    public void run() {
        Scanner sc = new Scanner(System.in);
        do{
          numeroIntroducido = sc.nextInt();
          if(Run1.isExito()){
              exito = true;
              System.out.println("El hilo de escribir se ha parado");
          }
        } while(!exito);
    }

    public static int getNumeroIntroducido() {
        return numeroIntroducido;
    }
}
