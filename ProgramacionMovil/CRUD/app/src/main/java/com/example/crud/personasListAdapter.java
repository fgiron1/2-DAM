package com.example.crud;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.crud.models.persistence.Persona;

import java.util.ArrayList;

//Parametrizado con el ViewHolder que nosotros hemos definido dentro

public class personasListAdapter extends RecyclerView.Adapter<personasListAdapter.RecyclerHolder>{

    private ArrayList<Persona> datosLista = new ArrayList<>();
    private LayoutInflater inflater;
    private onItemClickListener listener;
    private int layoutFilaId;

    public interface onItemClickListener  {
        //En el main activity, se debe implementar esta interfaz
        //para pasarle el objeto Persona al VM en un campo de
        //persona seleccionadas
        void onItemClick(Persona p);
    }


    //region Custom ViewHolder

    public class RecyclerHolder extends RecyclerView.ViewHolder{

        private final ImageView imagen;
        private final TextView nombreApellidos;

        public RecyclerHolder(@NonNull View itemView){
            super(itemView);
            this.imagen = (ImageView) itemView.findViewById(R.id.imagenTxtView);
            this.nombreApellidos = (TextView) itemView.findViewById(R.id.nombreTxtView);
            itemView.setOnClickListener(v -> {
                //Le pasamos la persona seleccionada representada por este viewholder
                listener.onItemClick(datosLista.get(getAdapterPosition()));
            });

        }

        public ImageView getImagen() { return imagen; }
        public TextView getNombreApellidos() { return nombreApellidos; }
    }

    //endregion

    //region Getters y setters

    public ArrayList<Persona> getDatosLista() { return datosLista; }
    public void setDatosLista(ArrayList<Persona> datosLista) {
        this.datosLista = datosLista;
        notifyDataSetChanged();
    }

    public onItemClickListener getListener() {
        return listener;
    }

    public void setListener(onItemClickListener listener) {
        this.listener = listener;
    }

    //endregion
    
    //region Constructores
    public personasListAdapter(Context c, int layoutFilaId, ArrayList<Persona> datosLista){
        inflater = LayoutInflater.from(c);
        this.layoutFilaId = layoutFilaId;
        this.datosLista = datosLista;
    }
    //endregion
    
    //region RecyclerView methods

    @NonNull
    @Override
    //Se encarga de inflar (crear) las vistas. Es llamado por el layout manager
    public RecyclerHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        //Creamos una nueva vista (un nuevo objeto en la lista)
        //usando el layout para la fila especificado en layoutFilaId
        View view = inflater.inflate(layoutFilaId, parent, false);

        return new RecyclerHolder(view);
    }

    //Se asocian los datos a la vista. Es llamado por el layout manager
    @Override
    public void onBindViewHolder(@NonNull RecyclerHolder holder, int position) {

        String texto = datosLista.get(position).getFirstName() + " " +
                datosLista.get(position).getLastName();

        holder.getNombreApellidos().setText(texto);
        holder.getImagen().setImageBitmap(datosLista.get(position).getImage());
    }

    @Override
    public int getItemCount() {
        return datosLista.size();
    }

    //endregion

}
