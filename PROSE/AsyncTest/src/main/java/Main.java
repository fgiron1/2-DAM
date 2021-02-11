import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;
import static java.util.concurrent.CompletableFuture.supplyAsync;

public class Main {

    public static void main(String[] args){

        //Creo que si se hace con thenAccept(). ES decir, como esta hecho justo aqui abajo
        //https://stackoverflow.com/questions/51895840/asynchronous-non-blocking-task-with-completablefutures

        Test pagina = new Test();

        //Creamos un nuevo CompletableFuture y le pasamos la funcion getPersonData para que sea
        //ejecutada de forma asíncrona.
        //Devuelve un CompletableFuture (Promesas en JS)

        //Diferencia entre supplyAsyn y RunAsync: Su interfaz
        //runAsync toma un runnable y devuelve un CompletableFuture<Void>, es decir, nada.
        //runAsync -> No hay que devolver nada
        //supplyAsync() toma un supplier y devuelve el valor que este genera en un CompletableFuture
        //supplyAsync -> Queremos devolver algo en forma de CompletableFuture
        //E
        CompletableFuture<ArrayList<Person>> futureList = supplyAsync(pagina::getPersonData);

        //CALCULOS LARGOS

        //El thenAccept corre en el mismo hilo que el futureList.thenAccept(), no en el hilo creado
        //por el supplyAsync()
        futureList.thenAccept(pagina::pintarTabla);



        //Se le añade un callBack para cuando acabe (la función lambda).
        //El parámetro listaPersonasFutura de la función lambda está lleno porque getPersonData ya ha acabado de traer la lista
        //getPersonata puede lanzar una excepcion en su ejecucion y se delega la responsabilidad de manejarla a la funcion callback
        futureList.whenComplete((listaPersonasFutura, e) -> {
            if (e != null) {
                System.out.println("exception occurs");
                System.err.println(e);
            } else {
                pagina.pintarTabla(listaPersonasFutura);
            }

        });






        /*
        Esto explica el thenApply y el thenAccept, pero no son necesarios para hacer lo de la tabla

        //Se usa el anterior CompletableFuture para pintar la tabla,
        //devolviendo a su vez un CompletableFuture<Void> tras su ejecución.

        //Dado que getPersonData se ejecuta de forma asíncrona, pintarTabla también
        //Y espera a que

        //.thenAccept() toma un Consumer como parametro.
        // Es decir, una función que vaya a usar los resultados de getPersonData
        // y que no le vaya a aplicar otra función encima (ESA ES LA DIFERENCIA CON thenApply())
        CompletableFuture<Void> future = futureList
                .thenAccept(pagina::pintarTabla);

        //CODIGO QUE SE TIENE QUE EJECUTAR A LA VEZ QUE LOS ANTERIORES
        //pagina.cargarOtrasCosas();

        //thenApply(funcion) aplica la función "funcion" al resultado del cálculo de getPersonData

        //Devuelve una CompletionStage
        futureList.thenApply(() -> pagina.getPersonData());

*/

    }
}
