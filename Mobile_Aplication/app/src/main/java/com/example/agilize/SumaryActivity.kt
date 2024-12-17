package com.example.agilize

import android.os.Bundle
import android.view.View
import android.widget.ImageButton
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.adapters.EndedTasksAdapterval
import com.example.agilize.classes.Tasks


class SumaryActivity: AppCompatActivity()
{
    object TasksStats{
        const val STATS = "STATS"
    }

    private var arrayTasks = mutableListOf<Tasks>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sumary)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        obtainStats()
        if(arrayTasks.isNotEmpty()){
            setTasks()
        }else{
            val txtEndedTasks = findViewById<TextView>(R.id.TxtEndedTasks)
            txtEndedTasks.text = "There is no ended Tasks"
        }

        val returnBtn = findViewById<ImageButton>(R.id.returnBtn)

        returnBtn.setOnClickListener {
            finish()
        }

    }

    private fun setTasks() {
        val rvEndedTasks = findViewById<RecyclerView>(R.id.RVEndedTasks)
        val adapter = EndedTasksAdapterval(arrayTasks){ task ->
            val sumaryAc = SumaryFragment.newInstance(task)
            supportFragmentManager.beginTransaction()
                .replace(R.id.Resumen,sumaryAc)
                .commit()
        }

        rvEndedTasks.adapter = adapter
        rvEndedTasks.layoutManager =  LinearLayoutManager(this)
    }

    private fun obtainStats() {
        val intent = intent
        arrayTasks = intent.getParcelableArrayListExtra(TasksStats.STATS)!!
    }
}