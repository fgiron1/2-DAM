package com.example.fernandogirondominguezandroid.database;

import android.content.Context;

import androidx.annotation.NonNull;
import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;
import androidx.sqlite.db.SupportSQLiteDatabase;

import com.example.fernandogirondominguezandroid.models.Bug;
import com.example.fernandogirondominguezandroid.models.Programador;

import java.util.concurrent.Executors;

@Database(entities = {Programador.class,
        Bug.class},
        exportSchema = false,
        version = 6)
public abstract class database extends RoomDatabase {

    private static database INSTANCE;

    //DAOs usados por clases externas
    public abstract BugDAO bugDAO();
    public abstract ProgramadorDAO programadorDAO();

    public static database getDatabase(final Context context){

        //region Room callback class implementation

        //Instanciamos como CLASE ANÓNIMA un nuevo objeto RoomDatabase.Callback
        //que implementan los métodos onCreate y onOpen

        RoomDatabase.Callback rdc = new RoomDatabase.Callback() {

            public void onCreate(@NonNull SupportSQLiteDatabase db) {



                //Hecho en otro hilo para evitar recursividad
                Executors.newSingleThreadExecutor().execute(() -> {

                    //FIXME Poblar base de datos
                    INSTANCE.programadorDAO();


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
