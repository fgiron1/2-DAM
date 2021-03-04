import java.util.Random;

public class Gestora {

    public static int sumarElementosRepetidos(int[] array){
        int sumaTotal = 0;
        for(int i = 0; i < array.length; i++){
            for(int j = 0; j < array.length; j++){
                if(array[i] == array[j] && i != j){
                    sumaTotal += array[i];
                }
            }
        }
        return sumaTotal;
    }

    public static int[] generarArray(int longitud){
        int[] array = new int[longitud];
        Random random = new Random();
        for(int i = 0; i < array.length; i++){
            array[i] = random.nextInt(9)+1;
            if(i!=0){
                System.out.print(", "+array[i]);
            }else{
                System.out.print(array[i]);
            }
        }
        return array;
    }
}
