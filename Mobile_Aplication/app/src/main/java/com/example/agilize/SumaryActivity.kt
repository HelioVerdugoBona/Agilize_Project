package com.example.agilize

import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.ScrollView
import androidx.appcompat.app.AppCompatActivity
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
        obtainStats()
        setSumary()
    }

    private fun obtainStats() {
        val intent = intent
        arrayTasks = intent.getParcelableExtra(TasksStats.STATS)!!
    }

    private fun setSumary() {
        val sumaryBtn = findViewById<Button>(R.id.ObtainsSumaryBtn)
        val sumaryView = findViewById<ScrollView>(R.id.Sumary)

        sumaryBtn.visibility = View.VISIBLE
        sumaryView.visibility = View.VISIBLE
        sumaryBtn.setOnClickListener {
            val sumaryAc = SumaryFragment.newInstance(arrayTasks[0])
            supportFragmentManager.beginTransaction().replace(R.id.Resumen,sumaryAc).commit()
        }

    }
}