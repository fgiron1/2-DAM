package com.example.listas;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class MyAdapter extends RecyclerView.Adapter {

    //IMPORTANTE: NO ESTA PARAMETRIZADO PORQUE AQUI HABRÁ IMÁGENES (array de bytes?) Y STRINGS
    //FIXME He metido un holder por defecto por necesidad del default del switch en onCreateViewHolder
    public ArrayList dataset = new ArrayList();

    //Definiendo un holder por defecto
    public static class DefaultHolder extends RecyclerView.ViewHolder{
        private View view;

        public DefaultHolder(View view){
            super(view);
        }
    }

    //Definiendo un holder para vistas TextView
    public static class TextHolder extends RecyclerView.ViewHolder{
        private TextView text;

        public TextHolder(TextView view){
            super(view);
        }

        public TextView getView(){return this.text;}
        public void setView(TextView text){this.text = text;}

    }

    //Definiendo un holder para vistas ImageView
    public static class ImageHolder extends RecyclerView.ViewHolder{
        private ImageView image;

        public ImageHolder(ImageView view){
            super(view);
        }

        public ImageView getView(){return this.image;}
        public void setView(ImageView image){this.image = image;}
    }

    public MyAdapter(ArrayList dataset){
        this.dataset = dataset;
    }

    @NonNull
    @Override
    //En este método se instancia la vista, se infla y se usa para instanciar el viewholder, que se devuelve
    //Método usado por el layout manager para crear las vistas. AUN NO TIENEN NINGUN DATO BINDEADO.
    //El viewType pasado por parámetros nos dice qué tipo de vista hay que crear, de entre las dos posibles
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        switch(viewType){
            case 0:
                //En la MainActivity, se puede usar el método estático getLayoutInflater() en lugar de
                // LayoutInflater.from(root); ya tiene asociado el viewgroup. Quedaría así:
                //TextView view = (TextView) getLayoutInflater().inflate(...);
                TextView textView = (TextView) LayoutInflater.from(parent.getContext())
                                .inflate(R.layout.activity_main, parent, false);
                TextHolder textHolder = new TextHolder(textView);
                return textHolder;
            case 2:
                ImageView imageView = (ImageView) LayoutInflater.from(parent.getContext())
                                .inflate(R.layout.activity_main, parent, false);
                ImageHolder imageHolder = new ImageHolder(imageView);
                return imageHolder;

            default:
                //Holder por defecto contiene una vista "vacia", pero no nula
                return new DefaultHolder(new View(parent.getContext()));
        }

    }

    //Este metodo lo usa el layout manager para bindear el dato cuya posición es pasada por parametros en nuestro dataset
    // a la viewholder pasada por parametros
    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        switch(holder.getItemViewType()){
            //ViewType 0: TextView
            //ViewType 2: ImageView
            case 0:
                TextHolder textHolder = (TextHolder) holder;
                textHolder.getView().setText( (String) dataset.get(position));
        }
    }

    @Override
    //position significa la posición en el RecyclerView de un ítem.
    public int getItemViewType(int position) {
        // Just as an example, return 0 or 2 depending on position
        return position % 2 * 2;
    }

    @Override
    public int getItemCount() {
        return dataset.size();
    }

    public int getViewTypeCount(){
        return 2;
    }

}
