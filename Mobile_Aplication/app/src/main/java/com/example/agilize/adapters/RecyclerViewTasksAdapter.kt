package com.example.agilize.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.R
import com.example.agilize.classes.Tasks

class RecyclerViewTasksAdapter(
    val taskList: MutableList<Tasks>,
    rvSetState: Int,
    private val onSummaryClick: (Tasks) -> Unit
) : RecyclerView.Adapter<RecyclerViewTasksAdapter.TaskViewHolder>() {

    private val rvState = rvSetState

    inner class TaskViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        private val taskName: TextView = view.findViewById(R.id.taskName)
        private val sprint: TextView = view.findViewById(R.id.sprint)
        private val description: TextView = view.findViewById(R.id.description)
        private val summaryButton: TextView = view.findViewById(R.id.Sumary)


        fun bind(task: Tasks) {
            taskName.text = task.TaskName
            sprint.text = "Sprint: ${task.Sprint}"
            description.text = task.Description

            summaryButton.setOnClickListener {
                onSummaryClick(task)
            }

            itemView.setOnLongClickListener {
                val shadowBuilder = View.DragShadowBuilder(itemView)

                // Pasar el objeto Task y el adaptador de origen en localState
                itemView.startDragAndDrop(
                    null, // No necesitas ClipData
                    shadowBuilder,
                    Pair(task, this@RecyclerViewTasksAdapter), // Pasar Task y el adaptador como Pair
                    0
                )
                true
            }

        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TaskViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.item_task, parent, false)
        return TaskViewHolder(view)
    }

    override fun onBindViewHolder(holder: TaskViewHolder, position: Int) {
        holder.bind(taskList[position])

    }

    override fun getItemCount(): Int = taskList.size

    // Métodos para mover elementos
    fun removeItem(position: Int): Tasks {
        return taskList.removeAt(position).also {
            notifyItemRemoved(position)
        }
    }

    fun addItem(task: Tasks, position: Int = taskList.size) {
        taskList.add(position, task)
        notifyItemInserted(position)
    }

    fun getState(): Int{
        return rvState
    }
}
