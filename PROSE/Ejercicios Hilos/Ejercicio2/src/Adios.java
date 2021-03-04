public class Adios implements Runnable{
    @Override
    public void run() {
        for(int i = 1; i <= 50; i++){
            synchronized (Main.obj){
                System.out.println("Adios "+i);
                Main.obj.notifyAll();
                try{
                    Main.obj.wait();
                }catch(Exception e){
                    System.out.println("Error");
                }
            }
        }
    }
}
