package com.example.crud.database;

import android.content.Context;

import androidx.annotation.NonNull;
import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;
import androidx.sqlite.db.SupportSQLiteDatabase;

import com.example.crud.database.Departamento.DepartamentoDAO;
import com.example.crud.database.Persona.PersonaDAO;
import com.example.crud.models.persistence.Departamento;
import com.example.crud.models.persistence.Persona;

import java.util.Date;
import java.util.concurrent.Executors;

@Database(entities = {Persona.class,
                      Departamento.class},
                      exportSchema = false,
                      version = 6)
public abstract class database extends RoomDatabase {

    private static database INSTANCE;
    //public static String baseUrl = "https://api-crud-sge.azurewebsites.net/api/";

    //DAOs usados por clases externas
    public abstract PersonaDAO personaDAO();
    public abstract DepartamentoDAO departamentoDAO();

    //DAOs empleados internamente por getDatabase(), para los métodos onCreate y onOpen
    //Necesitan ser estáticos como getDatabase()
    //FIXME Quiza no funcionen porque al no ser abstract, room no los puede implementar?
    //private static PersonaDAO internalPersonaDAO();
    //private static DepartamentoDAO internalDepartamentoDAO();

     public static database getDatabase(final Context context){

         //region Room callback class implementation

         //Instanciamos como CLASE ANÓNIMA un nuevo objeto RoomDatabase.Callback
         //que implementan los métodos onCreate y onOpen/

        RoomDatabase.Callback rdc = new RoomDatabase.Callback() {

            public void onCreate(@NonNull SupportSQLiteDatabase db) {

                //region Poblar base de datos con Retrofit WIP (CODIGO COMENTADO)
                /*


                //Las tablas están recién creadas y, por lo tanto, vacías. Se pueblan llamando a la API
                //Llamo a la API para solicitar una lista de personas y otra de departamentos para insertarlas en la bbdd

                Gson gson = new GsonBuilder()
                        .setLenient()
                        .create();

                //Construimos la instancia de retrofit con la configuración indicada
                Retrofit retrofit = new Retrofit.Builder()
                        .baseUrl(baseUrl)
                        .addConverterFactory(GsonConverterFactory.create(gson))
                        .build();

                //Retrofit implementa los métodos de la interfaz EmployeesAPI
                EmployeesAPI api = retrofit.create(EmployeesAPI.class);

                //IMPORTANTE: Por la naturaleza de retrofit, no se devuelve nada, sino que se asigna
                //un callback para manejar los resultados de la petición a la API. La decisión de implementar
                //aquí los métodos onResponse y onFailure, en lugar de en una clase a parte, es porque
                //puedo emplear los DAO de la clase directamente para la inserción (y además no voy
                // a reusarlo en otras partes del código)


                //region Retrofit getAllPersonas() callback implementation

                api.getAllPersonas().enqueue(new retrofit2.Callback<List<Persona>>(){

                    @Override
                    public void onResponse(@NonNull Call<List<Persona>> call, @NonNull Response<List<Persona>> response){
                        //Comprobamos el código de estado de la respuesta HTTP
                        if(response.isSuccessful()) {
                            //Insertamos la lista de forma asíncrona
                            Executors.newSingleThreadScheduledExecutor().execute(() ->
                                    internalPersonaDAO.insertPersonaList(response.body()));
                        } else {
                            System.out.print(response.errorBody());
                        }
                    }

                    @Override
                    public void onFailure(Call<List<Persona>> call, Throwable t) {
                        t.printStackTrace();
                    }

                });

                //endregion

                //region Retrofit getAllDepartments() callback implementation
                api.getAllDepartments().enqueue(new retrofit2.Callback<List<Departamento>>(){

                    @Override
                    public void onResponse(Call<List<Departamento>> call, Response<List<Departamento>> response) {

                        //Comprobamos el código de estado de la respuesta HTTP
                        if(response.isSuccessful()) {
                            //Insertamos la lista de forma asíncrona
                            Executors.newSingleThreadScheduledExecutor().execute(() ->
                                    internalDepartamentoDAO.insertDepartamentoList(response.body()));
                        } else {
                            System.out.print(response.errorBody());
                        }
                    }

                    @Override
                    public void onFailure(Call<List<Departamento>> call, Throwable t) {
                        t.printStackTrace();
                    }
                });

                //endregion

                */
                //endregion

                //String populatePersonas = "INSERT INTO personas VALUES(5, 'Pedro', 'Sanchez', datetime('now','localtime'), '654000000', 'pedrosanchez@gov.es', 1)";

               // try{
               //     db.execSQL(populatePersonas);
               // } catch (SQLException e){
               //     e.printStackTrace();
               // }

               Persona p = new Persona(5, null, "Pedro", "Sanchez", new Date(), "654000000", "pedrosanchez@gov.es", 1);
               Persona p2 = new Persona(9, null, "LOco", "Keko", new Date(), "654000000", "pedrosanchez@gov.es", 1);
               Departamento d1 = new Departamento(1, "Marketing");

                //Hecho en otro hilo para evitar recursividad
                Executors.newSingleThreadExecutor().execute(() -> {

                    INSTANCE.personaDAO().insertPersona(p);
                    INSTANCE.personaDAO().insertPersona(p2);
                    INSTANCE.departamentoDAO().insertDepartamento(d1);

                    //FIXME PROBAR A INSERTAR INNERJOIN CON PERSONAWITHDEPARTAMENTO

                });





            }

            public void onOpen(@NonNull SupportSQLiteDatabase db) {

            }
        };

        //endregion

        if (INSTANCE == null){
            synchronized(database.class){
                if(INSTANCE == null){
                    INSTANCE = Room.databaseBuilder(context.getApplicationContext(),
                            database.class, "empleados.db")
                            .addCallback(rdc)
                            .allowMainThreadQueries()
                            .build();
                }

            }

        }
        return INSTANCE;
    }

}
