package utils;

import java.util.*;
import java.util.concurrent.Semaphore;
import java.util.stream.Stream;

public class ProducerConsumerUtils {
    /** Interfaz que implementarán los productores */
    public interface IProduce<T> {
        T produce();
    }

    /** Interfaz que implementarán los consumidores */
    public interface IConsume<T> {
        void consume(T product);
    }

    /** Interfaz que implementarán las condiciones de continuación */
    public interface ICondition {
        boolean holds();
    }

    /**
     * Devuelve una acción que produce y consume valores
     *
     * @param producers Conjunto de instancias capaces de producir valores
     * @param productionCondition Condición que se tiene que cumplir para seguir produciendo valores
     * @param consumption Conjunto de instancias capaces de consumir valores
     * @param consumerCondition Condición que se tiene que cumplir para seguir consumiendo valores
     * @param maxItems Máximo de objetos que pueden estar producidos a la espera de consumirse simultáneamente
     * @param <T> Tipo del valor que se produce
     */
    public static <T> Runnable produceConsume(
            List<IProduce<T>> producers,
            ICondition productionCondition,
            List<IConsume<T>> consumption,
            ICondition consumerCondition,
            int maxItems) {
        // Creamos el buffer
        final Queue<T> buffer = new LinkedList<>();

        // Creamos un semáforo que controlará cuándo se puede producir
        final Semaphore produceSemaphore = new Semaphore(maxItems, true);

        // Creamos otro que controlará cuándo se puede consumir
        final Semaphore consumeSemaphore = new Semaphore(0, true);

        // Por cada productor, creamos un hilo de producción
        Stream<Runnable> produce = producers.stream()
                .map(producer -> () -> {
                    while (productionCondition.holds()) {
                        // Producimos el valor
                        T item = producer.produce();

                        // Esperamos a que se pueda producir
                        try {
                            produceSemaphore.acquire();
                        } catch (InterruptedException ignored) {}

                        // Añadimos el valor al buffer
                        synchronized (buffer) {
                            buffer.add(item);
                        }

                        // Dejamos que el valor sea consumido
                        consumeSemaphore.release();
                    }
                });

        // Por cada consumidor, creamos un hilo de producción
        Stream<Runnable> consume = consumption.stream()
                .map(consumer -> () -> {
                    // Paramos de consumir si no quedan objetos que consumir y no se van a producir más
                    while (consumerCondition.holds() && !(buffer.isEmpty() && !productionCondition.holds())) {
                        T product;

                        // Esperamos a que se pueda consumir
                        try {
                            consumeSemaphore.acquire();
                        } catch (InterruptedException ignored) {}

                        // Sacamos el valor del buffer
                        synchronized (buffer) {
                            product =  buffer.remove();
                        }

                        // Dejamos que se produzca un nuevo valor
                        produceSemaphore.release();

                        // Consumimos al valor
                        consumer.consume(product);
                    }
                });

        // Ejecutamos todos los hilos de manera paralela
        Stream<Runnable> runnables = Stream.concat(produce, consume);
        return paralelizar(runnables.toArray(Runnable[]::new));
    }

    /** Sobrecarga de produceConsume que nunca para de producir */
    public static <T> Runnable produceConsume(
            List<IProduce<T>> producers,
            List<IConsume<T>> consumption,
            ICondition consumerCondition,
            int maxItems) {
        return produceConsume(producers, () -> true, consumption, consumerCondition, maxItems);
    }

    /** Sobrecarga de produceConsume que nunca para de consumir ni de producir */
    public static <T> Runnable produceConsume(
            List<IProduce<T>> producers,
            List<IConsume<T>> consumption,
            int maxItems) {
        return produceConsume(producers, () -> true, consumption, () -> true, maxItems);
    }

    /** Devuelve una acción que realiza un conjunto de acciones de manera paralela */
    public static Runnable paralelizar(Runnable ...accionesParalelas) {
        return () -> {
            // Creamos los hilos
            final Thread[] hilosParciales = Arrays.stream(accionesParalelas).map(Thread::new).toArray(Thread[]::new);

            // Los iniciamos
            for (Thread hilo : hilosParciales) {
                hilo.start();
            }

            // Esperamos a que terminen todos
            for (Thread hilo : hilosParciales) {
                try {
                    hilo.join();
                } catch (InterruptedException ignored) {}
            }
        };
    }
}