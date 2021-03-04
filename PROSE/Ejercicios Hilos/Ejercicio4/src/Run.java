public class Run implements Runnable {

    private int[] array;
    private static int sumaTotal = 0;
    private static int hilosAcabados = 0;

    private static Object monitor;
    private int indiceMenor, indiceMayor;

    public Run(int[] array, int indiceMenor, int indiceMayor, Object monitor){
        this.array = array;
        this.indiceMayor = indiceMayor;
        this.indiceMenor = indiceMenor;
        this.monitor = monitor;
    }

    @Override
    public void run() {
        for(int i=indiceMenor; i<indiceMayor; i++){
            for(int j = 0; j <array.length; j++){
                if(array[i] == array[j] && i != j){
                    sumaTotal += array[i];
                }
            }
        }
       /* synchronized (monitor){
            hilosAcabados++;
            if(hilosAcabados == 2){
                monitor.notifyAll();
            }
        }*/
    }

    public static int getSumaTotal() {
        return sumaTotal;
    }

}
