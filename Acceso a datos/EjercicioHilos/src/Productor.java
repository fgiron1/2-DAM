public class Productor implements Runnable{

    //Generar numeros primos a partir de 8000

    @Override
    public void run() {

        synchronized (Main.Monitor){
            if(Main.lista.size() == 10){

            }
            Main.lista.add(siguiente());
        }

        //Si la lista está llena, despierta al otro y te duermes

    }

    public Integer siguiente(){
        return 5;
    }

}
