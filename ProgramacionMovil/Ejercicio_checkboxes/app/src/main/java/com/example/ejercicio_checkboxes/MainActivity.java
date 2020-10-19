package com.example.ejercicio_checkboxes;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.RadioGroup;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity implements CompoundButton.OnCheckedChangeListener {

    CheckBox cb1, cb2, cb3, cb4;
    TextView texto;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        cb1 = (CheckBox) findViewById(R.id.cb1);
        cb2 = (CheckBox) findViewById(R.id.cb2);
        cb3 = (CheckBox) findViewById(R.id.cb3);
        cb4 = (CheckBox) findViewById(R.id.cb4);
        texto = (TextView) findViewById(R.id.texto);

        cb1.setOnCheckedChangeListener(this);
        cb2.setOnCheckedChangeListener(this);
        cb3.setOnCheckedChangeListener(this);
        cb4.setOnCheckedChangeListener(this);


    }


    //I think I can't do it without a listener (The app has to constantly check the state of the checkboxes)
    @Override
    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {

        switch(buttonView.getId()){

            case R.id.cb1:

                if(isChecked){
                    texto.setTypeface(null, Typeface.BOLD);
                } else {
                    texto.setTypeface(null, Typeface.NORMAL);
                }

                break;

            case R.id.cb2:

                if(isChecked){
                    texto.setTextSize(22);
                } else {
                    texto.setTextSize(15);
                }
                break;

            case R.id.cb3:

                if(isChecked){
                    texto.setTextSize(5);
                } else {
                    texto.setTextSize(15);
                }

                break;

            case R.id.cb4:

                if(isChecked){
                    texto.setTextColor(Color.RED);
                } else {
                    texto.setTextColor(Color.BLACK);
                }

                break;

        }

    }
}