package com.example.agilize.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.R
import com.example.agilize.classes.Projects

class RecyclerViewProjectosAdapter( private val proyectosList: List<Projects>,
                                    private val onItemClickListener: (Projects) -> Unit
) : RecyclerView.Adapter<RecyclerViewProjectosAdapter.ProyectosViewHolder>() {

    // ViewHolder interno para manejar las vistas del elemento
    class ProyectosViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val projectImage: ImageView = itemView.findViewById(R.id.projectImage)
        val projectName: TextView = itemView.findViewById(R.id.projectName)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ProyectosViewHolder {
        // Infla el layout del elemento
        val itemView = LayoutInflater.from(parent.context)
            .inflate(R.layout.project_item, parent, false)
        return ProyectosViewHolder(itemView)
    }

    override fun onBindViewHolder(holder: ProyectosViewHolder, position: Int) {
        // Enlaza los datos del proyecto con las vistas
        val projects = proyectosList[position]
        holder.projectImage.setImageResource(R.drawable.default_img)
        holder.projectName.text = projects.projectName

        holder.itemView.setOnClickListener {
            onItemClickListener(projects) // Llama al callback con el proyecto clickeado
        }
    }

    override fun getItemCount(): Int = proyectosList.size
}
