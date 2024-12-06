package com.example.agilize.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.R
import com.example.agilize.classes.Users

class RecyclerViewUsersAdapter(private val usersList: List<Users>) : RecyclerView.Adapter<RecyclerViewUsersAdapter.UsersViewHolder>() {

    // ViewHolder interno que representa cada elemento del RecyclerView
    class UsersViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val nicknameTextView: TextView = itemView.findViewById(R.id.TxtUserNickname)
    }

    // Inflar el layout del item
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UsersViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_user, parent, false)
        return UsersViewHolder(view)
    }

    // Vincular datos con el ViewHolder
    override fun onBindViewHolder(holder: UsersViewHolder, position: Int) {
        val user = usersList[position]
        holder.nicknameTextView.text = user.nickname
    }

    // Tamaño de la lista
    override fun getItemCount(): Int {
        return usersList.size
    }
}