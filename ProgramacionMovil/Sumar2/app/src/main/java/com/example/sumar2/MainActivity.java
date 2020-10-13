package com.example.sumar2;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    Button boton_sumar;
    EditText n1, n2, resultado;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Assigning a java object to each UI view
         boton_sumar = (Button) findViewById(R.id.boton_sumar);
         n1 = (EditText) findViewById(R.id.num1);
         n2 = (EditText) findViewById(R.id.num2);
         resultado = (EditText) findViewById(R.id.resultado);


        //An EVENT LISTENER detects when an event is triggered.
        //The behavior that follows the firing of the event
        //is defined by the EVENT HANDLER.
        //Event listeners are INTERFACES that include their
        //respective event handlers. For the sake of simplicity,
        //it's preferred to implement the event handler as a
        //method defined in an anonymous inner class instance
        //, such as done below

        //EVENT REGISTRATION -> The process by which an event handler gets registered with
        //an Event Listener so that the handler is called when the Event Listener fires the event
        boton_sumar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //Adding a string casts Editable to String type.
                // TODO: Though, it'd be better to simply warn the user that non-numbers can't be added together
                Integer.parseInt(n1.getText() + "");    
            }
        });

    }
}