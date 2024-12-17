package com.example.agilize.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.R
import com.example.agilize.classes.Tasks

class EndedTasksAdapterval(private val taskList: MutableList<Tasks>,
                           private val onItemClickListener: (Tasks) -> Unit
                            ) : RecyclerView.Adapter<EndedTasksAdapterval.EndedTaskViewHolder>(){

    inner class EndedTaskViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        private val taskName: TextView = view.findViewById(R.id.taskName)
        private val sprint: TextView = view.findViewById(R.id.sprint)

        fun bind(task: Tasks) {
            taskName.text = task.TaskName
            sprint.text = "Sprint: ${task.Sprint}"

            itemView.setOnClickListener{
                onItemClickListener(task)
            }
        }
    }

    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): EndedTasksAdapterval.EndedTaskViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_task_ended, parent, false)
        return EndedTaskViewHolder(view)
    }

    override fun getItemCount(): Int = taskList.size

    override fun onBindViewHolder(holder: EndedTasksAdapterval.EndedTaskViewHolder, position: Int) {
        holder.bind(taskList[position])
    }
}
