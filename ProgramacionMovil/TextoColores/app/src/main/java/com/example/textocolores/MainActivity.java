package com.example.textocolores;

import androidx.annotation.ColorInt;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    Button botonRojo;
    Button botonAzul;
    Button botonVerde;
    EditText cajaTextoColor;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        botonRojo = (Button) findViewById(R.id.botonRojo);
        botonAzul = (Button) findViewById(R.id.botonAzul);
        botonVerde = (Button) findViewById(R.id.botonVerde);
        cajaTextoColor = (EditText) findViewById(R.id.cajaTextoColor);

        botonRojo.setOnClickListener(this);
    }

    @Override
    public void onClick(View v){

        switch(v.getId()){

            case R.id.botonAzul:
                cajaTextoColor.setTextColor(getResources().getColor(R.color.rojo));
                break;

            case R.id.botonVerde:
                cajaTextoColor.setTextColor(getResources().getColor(R.color.verde));
                break;

            case R.id.botonRojo:
                cajaTextoColor.setTextColor(getResources().getColor(R.color.azul));
                break;


        }

    }

}