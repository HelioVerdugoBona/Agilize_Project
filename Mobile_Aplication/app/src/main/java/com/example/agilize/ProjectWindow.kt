package com.example.agilize

import android.annotation.SuppressLint
import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.view.View
import android.widget.ImageButton
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.adapters.RecyclerViewTasksAdapter
import com.example.agilize.adapters.setupRecyclerViewWithDragListener
import com.example.agilize.classes.Projects
import com.example.agilize.classes.Tasks
import com.example.agilize.misc.FileManager
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class ProjectWindow: AppCompatActivity()
{
    object ProjectStats{
        const val STATS = "STATS"
    }

    private lateinit var rvBackLog: RecyclerView
    private lateinit var rvToDo: RecyclerView
    private lateinit var rvDoing: RecyclerView
    private lateinit var rvToValidate: RecyclerView
    private lateinit var rvDone: RecyclerView

    private var arrayBackLog = mutableListOf<Tasks>()
    private var arrayToDo = mutableListOf<Tasks>()
    private var arrayDoing = mutableListOf<Tasks>()
    private var arrayToValidate = mutableListOf<Tasks>()
    private var arrayDone = mutableListOf<Tasks>()

    private lateinit var project: Projects
    private var update = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_project)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        getRVView()
        obtainStats()
        setAll()

        val returnBtn = findViewById<ImageButton>(R.id.returnBtn)
        returnBtn.setOnClickListener{
            returnBtn.setBackgroundColor(Color.rgb(252, 132, 88))
            lifecycleScope.launch {
                delay(300)
                returnBtn.setBackgroundColor(Color.rgb(255, 107, 53))
            }
            val intent = Intent()
            if(update){ setResult(RESULT_OK, intent) }
            else{ setResult(RESULT_CANCELED, intent) }
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

    private fun saveAllData() {
        if(!FileManager.comproveFile(this,"Projects.json")){
            Toast.makeText(this@ProjectWindow, getString(R.string.saving_projects_error), Toast.LENGTH_LONG).show()
        }else{
            val arrayProjects = FileManager.getProjectStats(this,"Projects.json")
            val index = arrayProjects.indexOfFirst { it.projectName == project.projectName }
            if (index != -1) {
                arrayProjects[index] = project
                FileManager.saveProjectStats(this,arrayProjects,"Projects.json")
                update = true
            }else{
                Toast.makeText(this@ProjectWindow, getString(R.string.saving_projects_error), Toast.LENGTH_SHORT).show()
            }
        }
    }

    private fun getRVView() {
        rvBackLog = findViewById(R.id.RVBackLog)
        rvToDo = findViewById(R.id.RVToDo)
        rvDoing = findViewById(R.id.RVDoing)
        rvToValidate = findViewById(R.id.RVToValidate)
        rvDone = findViewById(R.id.RVDone)
    }

    private fun obtainStats() {
        val intent = intent
        project = intent.getSerializableExtra(ProjectStats.STATS) as Projects
    }

    private fun setAll() {
        val projectName = findViewById<TextView>(R.id.TxtProjectName)
        projectName.text = project.projectName
        project.arrayTasks.forEach{ task ->
            when(task.CurrentState)
            {
            0 ->arrayBackLog.add(task)
            1 ->arrayToDo.add(task)
            2 ->arrayDoing.add(task)
            3 ->arrayToValidate.add(task)
            4 ->arrayDone.add(task)
            }
        }

        val rvBackLogAdapter = setRVAdapter(arrayBackLog,0)
        rvBackLog = setAllRV(rvBackLogAdapter,rvBackLog)

        val rvToDoAdapter = setRVAdapter(arrayToDo,1)
        rvToDo = setAllRV(rvToDoAdapter,rvToDo)

        val rvDoingAdapter = setRVAdapter(arrayDoing,2)
        rvDoing = setAllRV(rvDoingAdapter,rvDoing)

        val rvToValidateAdapter = setRVAdapter(arrayToValidate,3)
        rvToValidate = setAllRV(rvToValidateAdapter,rvToValidate)

        val rvDoneAdapter = setRVAdapter(arrayDone,4)
        rvDone = setAllRV(rvDoneAdapter,rvDone)
    }

    private fun setAllRV(rvAdapter: RecyclerViewTasksAdapter, rv: RecyclerView): RecyclerView {
        setupRecyclerViewWithDragListener(rv,rvAdapter)
        rv.adapter = rvAdapter
        rv.layoutManager = LinearLayoutManager(this,LinearLayoutManager.HORIZONTAL,false)
        return rv
    }

    private fun setRVAdapter(arrayTask : MutableList<Tasks>, state: Int): RecyclerViewTasksAdapter {
        val rvAdaper = RecyclerViewTasksAdapter(
            arrayTask,
            state,
            onSummaryClick = { task ->
                val intent = Intent(this,TaskActivity::class.java)
                intent.putExtra(TaskActivity.TasksStats.STATS,task)
                startActivityForResult(intent,1)
            }
        )
        return rvAdaper
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (requestCode == 1 && resultCode == RESULT_OK) {
            val task = data?.getSerializableExtra("task_result") as? Tasks
            if (task != null) {
                when(task.CurrentState){
                    0 ->arrayBackLog = taskUpdater(arrayBackLog,task)
                    1 ->arrayToDo = taskUpdater(arrayToDo,task)
                    2 ->arrayDoing = taskUpdater(arrayDoing,task)
                    3 ->arrayToValidate = taskUpdater(arrayToValidate,task)
                    4 ->arrayDone = taskUpdater(arrayDone,task)
                }
            }
        }
    }

    private fun taskUpdater(arraytask: MutableList<Tasks>, task: Tasks): MutableList<Tasks> {
        val index = arraytask.indexOfFirst { it.TaskName == task.TaskName }
        if (index != -1) {
            arraytask[index] = task
            updateRecyclerview(task)
        }else{
            Toast.makeText(this@ProjectWindow, getString(R.string.updating_task_error), Toast.LENGTH_SHORT).show()
        }
        return arraytask
    }

    @SuppressLint("NotifyDataSetChanged")
    private fun updateRecyclerview(task: Tasks) {
        when(task.CurrentState){
            0 -> rvBackLog.adapter?.notifyDataSetChanged()
            1 -> rvToDo.adapter?.notifyDataSetChanged()
            2 -> rvDoing.adapter?.notifyDataSetChanged()
            3 -> rvToValidate.adapter?.notifyDataSetChanged()
            4 -> rvDone.adapter?.notifyDataSetChanged()
        }
    }
}