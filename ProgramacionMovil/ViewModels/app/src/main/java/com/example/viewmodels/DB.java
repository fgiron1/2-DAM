package com.example.viewmodels;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;

@Database(entities = {Equipo.class}, version = 1)
public abstract class DB extends RoomDatabase {

    public abstract DAOEquipo daoEquipo();
    private static DB INSTANCE;

    //En un método estático, la sintaxis para declarar un método synchronized
    //es la que sale  (y si es un método normal, se le pasa this por parámetros),
    //pero en realidad es lo mismo que:
    //public synchronized void metodo() {}

    public static DB getDatabase(final Context context){
        //Si la BBDD está creada, con esta previa comprobación
        //nos ahorramos esperar al synchronized
        if(INSTANCE == null){
            // Cada vez que un thread intenta acceder a un bloque sincronizado
            // le pregunta a ese objeto si no hay algún otro thread que ya tenga
            // el lock para ese objeto. Es decir, si otro thread lo está usando
            synchronized (DB.class){
                if(INSTANCE == null){
                    INSTANCE = Room.databaseBuilder(context.getApplicationContext(),
                            DB.class, "EquiposNBA.db")
                            .build();
                }
            }
        }
    }


}