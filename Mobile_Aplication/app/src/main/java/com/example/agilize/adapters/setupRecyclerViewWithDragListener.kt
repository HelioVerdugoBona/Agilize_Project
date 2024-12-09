package com.example.agilize.adapters

import android.graphics.Color
import android.view.DragEvent
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.classes.Tasks

fun setupRecyclerViewWithDragListener(
    recyclerView: RecyclerView,
    adapter: RecyclerViewTasksAdapter
) {
    recyclerView.setOnDragListener { _, event ->
        when (event.action) {
            DragEvent.ACTION_DRAG_STARTED -> true
            DragEvent.ACTION_DRAG_ENTERED -> {
                recyclerView.setBackgroundColor(Color.WHITE) // Visual feedback
                true
            }
            DragEvent.ACTION_DRAG_EXITED -> {
                recyclerView.setBackgroundColor(Color.rgb(208, 208, 179))
                true
            }
            DragEvent.ACTION_DROP -> {
                recyclerView.setBackgroundColor(Color.rgb(208, 208, 179))

                // Recuperar los datos del evento
                val dragData = event.localState as? Pair<Tasks, RecyclerViewTasksAdapter>
                val task = dragData?.first
                val sourceAdapter = dragData?.second

                if (task != null && sourceAdapter != null) {
                    // Eliminar el ítem del RecyclerView origen
                    val positionInSource = sourceAdapter.taskList.indexOf(task)
                    if (positionInSource != -1) {
                        sourceAdapter.removeItem(positionInSource)
                    }
                    task.CurrentState = adapter.getState()
                    // Agregar el ítem al RecyclerView destino
                    val positionInTarget = adapter.itemCount
                    adapter.addItem(task, positionInTarget)
                }
                true
            }
            else -> false
        }
    }
}