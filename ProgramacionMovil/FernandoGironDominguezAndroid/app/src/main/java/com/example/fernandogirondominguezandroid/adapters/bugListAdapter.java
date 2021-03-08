package com.example.fernandogirondominguezandroid.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.fernandogirondominguezandroid.R;
import com.example.fernandogirondominguezandroid.models.Bug;

import java.util.ArrayList;

public class bugListAdapter extends RecyclerView.Adapter<bugListAdapter.RecyclerHolder> {

    private ArrayList<Bug> datosLista = new ArrayList<>();
    private LayoutInflater inflater;
    private onItemClickListener listener;
    private int layoutFilaId;

    public interface onItemClickListener  {
        //En el main activity, se debe implementar esta interfaz
        //para pasarle el objeto Persona al VM en un campo de
        //persona seleccionadas
        void onItemClick(Bug bug);
    }


    //region Custom ViewHolder

    public class RecyclerHolder extends RecyclerView.ViewHolder{

        private final TextView info;

        public RecyclerHolder(@NonNull View itemView){
            super(itemView);

            this.info = (TextView) itemView.findViewById(R.id.infoTxtView);
            itemView.setOnClickListener(v -> {
                //Le pasamos la persona seleccionada representada por este viewholder
                listener.onItemClick(datosLista.get(getAdapterPosition()));
            });

        }

        public TextView getInfo() { return info; }
    }

    //endregion

    //region Getters y setters

    public ArrayList<Bug> getDatosLista() { return datosLista; }
    public void setDatosLista(ArrayList<Bug> datosLista) {
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
    public bugListAdapter(Context c, int layoutFilaId, ArrayList<Bug> datosLista){
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

        String texto = datosLista.get(position).getIdBug() + " " +
                datosLista.get(position).getPrioridad();

        holder.getInfo().setText(texto);

    }

    @Override
    public int getItemCount() {
        return datosLista.size();
    }

    //endregion

}
