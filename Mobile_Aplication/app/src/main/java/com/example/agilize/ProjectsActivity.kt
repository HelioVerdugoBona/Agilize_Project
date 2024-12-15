package com.example.agilize

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.adapters.RecyclerViewProjectosAdapter
import com.example.agilize.classes.Projects
import com.example.agilize.classes.Users
import com.example.agilize.misc.FileManager
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

class ProjectsActivity: AppCompatActivity()
{
    object UserProjects{
        const val PROJECTS = "PROJECTS"
    }

    private var arrayTotalProjects = mutableListOf<Projects>()
    private var arrayUserProjects = mutableListOf<Projects>()
    private var showedProjects = mutableListOf<Projects>()
    private lateinit var user: Users
    private lateinit var rvProjects: RecyclerView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_mainhub)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        rvProjects = findViewById(R.id.recyclerViewProjects)

        obtainUser()
        obtainFileProjects()
        setUserProjects()
        // Configura el adaptador y el layout manager
        rvProjects.layoutManager = LinearLayoutManager(this)
        rvProjects.adapter = RecyclerViewProjectosAdapter(showedProjects){ projects ->
            val intent = Intent(this,ProjectWindow::class.java)
            intent.putExtra(ProjectWindow.ProjectStats.STATS,projects)
            startActivityForResult(intent,1)
        }

        val imgAccountBtn = findViewById<ImageButton>(R.id.imgAccountBtn)
        imgAccountBtn.setOnClickListener {
            imgAccountBtn.setBackgroundColor(Color.rgb(252, 132, 88))
            lifecycleScope.launch {
                delay(300)
                imgAccountBtn.setBackgroundColor(Color.rgb(255, 107, 53))
            }
            val intent = Intent(this, AccountActivity::class.java)
            intent.putExtra(AccountActivity.UserStats.STATS,user)
            startActivityForResult(intent,2)
        }

        val btnSearch = findViewById<Button>(R.id.BtnBuscar)
        val projectSearched = findViewById<EditText>(R.id.ProjectSearch)
        btnSearch.setOnClickListener{
            showedProjects.clear()
            if(projectSearched.text.toString().isEmpty()){
                showedProjects.addAll(arrayUserProjects)
            }else{
                arrayUserProjects.forEach{ projectName ->
                    val muck = projectSearched.text.toString()
                    if(projectName.projectName.contains(muck)){
                        showedProjects.add(projectName)
                    }
                }
            }
            rvProjects.adapter?.notifyDataSetChanged()
        }
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (requestCode == 1 && resultCode == RESULT_OK) {
            projectUpdater()
            rvProjects.adapter?.notifyDataSetChanged()
        }else if(requestCode == 2 && resultCode == RESULT_OK){
            recreate()
        }
    }

    private fun projectUpdater() {
        arrayTotalProjects.clear()
        obtainFileProjects()
        arrayUserProjects.clear()
        showedProjects.clear()
        setUserProjects()
    }

    private fun obtainUser() {
        val intent = intent
        user = intent.getParcelableExtra(UserProjects.PROJECTS)!!
    }

    private fun setUserProjects() {
        arrayTotalProjects.forEach{ project ->
            if(user.projectsList.contains(project.projectName)){
                arrayUserProjects.add(project)
            }
        }
        showedProjects.addAll(arrayUserProjects)
    }

    private fun obtainFileProjects() {

        if(!FileManager.comproveFile(this,"Projects.json"))
        {
            Toast.makeText(this@ProjectsActivity, getString(R.string.obtaining_projects_error), Toast.LENGTH_LONG).show()
        }else{
            arrayTotalProjects = FileManager.getProjectStats(this,"Projects.json")
        }
    }
}