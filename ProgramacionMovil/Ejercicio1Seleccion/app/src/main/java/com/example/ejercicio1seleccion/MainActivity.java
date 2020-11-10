package com.example.ejercicio1seleccion;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    private RecyclerView teamList;
    private RecyclerView.LayoutManager layoutManager;
    private CustomAdapter adapter;
    private TextView item0, item1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        teamList = (RecyclerView) findViewById(R.id);
        item0 = (TextView) findViewById(R.id.item0);
        item1 = (TextView) findViewById(R.id.item1);

        //A layout manager is instantiated and binded to the RecyclerViews
        layoutManager = new LinearLayoutManager(this);
        teamList.setLayoutManager(layoutManager);

        //A custom adapter is instantiated and is set as an adapter for the RecyclerView
        adapter = new CustomAdapter();
        teamList.setAdapter(adapter);



    }
}