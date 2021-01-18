package com.example.listas;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    public RecyclerView NBA;
    public MyAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ArrayList dataset = new ArrayList();

        dataset.add("Marco");
        dataset.add("Polo");
        dataset.add("Pedro");
        dataset.add("Paco");
        dataset.add("Pablo");
        dataset.add("Perro");

        adapter = new MyAdapter(dataset);
        NBA = (RecyclerView) findViewById(R.id.NBA);
        NBA.setAdapter(adapter);

    }
}