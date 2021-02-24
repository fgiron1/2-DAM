import java.util.LinkedList;

public class Main {

    public static LinkedList<Integer> lista = new LinkedList<Integer>();
    public static Object Monitor = new Object();

    public static void main(String[] args){

        Thread t1 = new Thread(new Consumidor());
        Thread t2 = new Thread(new Productor());

    }
}
