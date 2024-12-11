package com.example.agilize

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.ImageButton
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.adapters.RecyclerViewUsersAdapter
import com.example.agilize.classes.Tasks
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class TaskActivity:AppCompatActivity() {

    object TasksStats{
        const val STATS = "STATS"
    }

    private lateinit var task: Tasks
    private lateinit var sprint: EditText
    private lateinit var estimatedTime: EditText

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_task)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        obtainStats()

        val returnBtn = findViewById<ImageButton>(R.id.returnBtn)
        returnBtn.setOnClickListener{
            returnBtn.setBackgroundColor(Color.rgb(252, 132, 88))
            lifecycleScope.launch {
                delay(300)
                returnBtn.setBackgroundColor(Color.rgb(255, 107, 53))
            }

            val intent = Intent()
            intent.putExtra("task_result", task)
            setResult(RESULT_OK, intent)
            finish()
        }

        val saveBtn = findViewById<ImageButton>(R.id.saveBtn)
        saveBtn.setOnClickListener{
            saveBtn.setBackgroundColor(Color.rgb(252, 132, 88))
            lifecycleScope.launch {
                delay(300)
                saveBtn.setBackgroundColor(Color.rgb(255, 107, 53))
            }

            saveAllData()
        }

    }

    private fun obtainStats() {
        val intent = intent
        task = intent.getParcelableExtra(TasksStats.STATS)!!
        setAll()
    }

    private fun setAll() {
        val creationDate = findViewById<EditText>(R.id.EtxtDateCreation)
        val deadLine = findViewById<EditText>(R.id.EtxtDeadLine)
        val currentState = findViewById<EditText>(R.id.EtxtCurrentState)
        sprint = findViewById(R.id.EtxtSprint)
        estimatedTime = findViewById(R.id.EtxtEstimatedTime)
        val description = findViewById<TextView>(R.id.TxtDescription)
        val taskName = findViewById<TextView>(R.id.TxtTaskName)

        creationDate.hint = task.DateCreation
        deadLine.hint = task.DeadLine
        sprint.hint = task.Sprint.toString()
        estimatedTime.hint = task.EstimatedTime + "h"
        description.text = task.Description
        taskName.text = task.TaskName
        setCurrentState(currentState)
        setUsers()
    }

    private fun setCurrentState(currentState: EditText) {
        when(task.CurrentState){
            0 -> currentState.hint = getString(R.string.backlog)
            1 -> currentState.hint = getString(R.string.to_do)
            2 -> currentState.hint = getString(R.string.doing)
            3 -> currentState.hint = getString(R.string.pending_confirmation)
            4 -> currentState.hint = getString(R.string.done)
        }
    }


    private fun setUsers() {
        val rvTaskMembers = findViewById<RecyclerView>(R.id.RVTaskMembers)
        val adapter = RecyclerViewUsersAdapter(task.TaskMembers)
        rvTaskMembers.adapter = adapter
        rvTaskMembers.layoutManager = GridLayoutManager(this, 3)
    }

    private fun saveAllData() {
        if(sprint.text.toString().toIntOrNull() != null){
            task.Sprint = sprint.text.toString().toInt()
        }else{
            Toast.makeText(this@TaskActivity, getString(R.string.sprint_saving_error), Toast.LENGTH_LONG).show()
        }
        if(estimatedTime.text.isNotEmpty()){
            task.EstimatedTime = estimatedTime.text.toString()
        }
    }
}