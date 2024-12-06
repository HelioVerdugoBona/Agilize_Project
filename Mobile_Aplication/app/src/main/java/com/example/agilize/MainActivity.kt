package com.example.agilize

import android.content.Intent
import android.content.res.Configuration
import android.os.Build
import android.os.Bundle
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.Spinner
import android.widget.TextView
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.example.agilize.classes.Users
import com.example.agilize.misc.FileManager
import org.bouncycastle.crypto.engines.BlowfishEngine
import org.bouncycastle.crypto.paddings.PaddedBufferedBlockCipher
import org.bouncycastle.crypto.params.KeyParameter
import java.util.Locale
import java.util.Base64

class MainActivity : AppCompatActivity() {

    private lateinit var userNck: EditText
    private lateinit var userPsw: EditText
    private lateinit var pswFrgt: TextView
    private lateinit var loginBtn: Button

    private var arrayUsers = mutableListOf<Users>()
    private lateinit var user: Users

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)
        setAll()
        configureSpinner()
        obtainFileUsers()
        val loginBtn =  findViewById<Button>(R.id.loginBtn)

        loginBtn.setOnClickListener {
            if(validateUser()){
                val intent = Intent(this, ProjectsActivity::class.java)
                intent.putExtra(ProjectsActivity.UserProjects.PROJECTS,user)
                startActivity(intent)
            }else{
                Toast.makeText(this@MainActivity, getString(R.string.login_error), Toast.LENGTH_SHORT).show()
            }

        }

    }

    private fun setAll() {
        userNck = findViewById(R.id.UserNickname)
        userPsw = findViewById(R.id.UserPassword)
        pswFrgt = findViewById(R.id.passwordForgoted)
        loginBtn = findViewById(R.id.loginBtn)
    }

    @RequiresApi(Build.VERSION_CODES.O)
    private fun validateUser(): Boolean {
        var userName = userNck.text.toString()
        var userPassword = userPsw.text.toString()
        userPassword = encryptPassword(userPassword)
        arrayUsers.forEach { user ->
            if(user.nickname == userName && user.password == userPassword){
                this.user = user
                return true
            }
        }
        return false
    }

    @RequiresApi(Build.VERSION_CODES.O)
    private fun encryptPassword(pswd: String): String {

        val engine = BlowfishEngine()
        val blockCipher = PaddedBufferedBlockCipher(engine)

        val keyBytes = "f83jsd74jdue0qnd".toByteArray(Charsets.UTF_8)
        blockCipher.init(true, KeyParameter(keyBytes))

        val inputBytes = pswd.toByteArray(Charsets.UTF_8)
        val outputBytes = ByteArray(blockCipher.getOutputSize(inputBytes.size))

        var length = blockCipher.processBytes(inputBytes, 0, inputBytes.size, outputBytes, 0)
        length += blockCipher.doFinal(outputBytes, length)

        return Base64.getEncoder().encodeToString(outputBytes.copyOf(length))
    }


    private fun obtainFileUsers() {
        if(!FileManager.comproveFile(this,"Users.json"))
        {
            Toast.makeText(this@MainActivity, getString(R.string.obtaining_user_error), Toast.LENGTH_LONG).show()
        }else{
            arrayUsers = FileManager.getUsersStats(this,"Users.json")
        }
    }

    private fun configureSpinner() {
        val spinner: Spinner = findViewById(R.id.spinner)

        // Configurar adaptador
        val items = resources.getStringArray(R.array.languajes_array)
        val adapter = ArrayAdapter(this, android.R.layout.simple_spinner_item, items)
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
        spinner.adapter = adapter

        // Configurar selección inicial
        spinner.setSelection(0)

        // Asigna el adaptador al Spinner

        var isOtherSelection = true
        // Agrega un listener para manejar la selección de elementos
        spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {
                if (isOtherSelection) {
                    isOtherSelection = false // Ignora el primer evento
                    return
                }
                val selectedItem = parent?.getItemAtPosition(position).toString()
                Toast.makeText(this@MainActivity, "Seleccionaste: $selectedItem", Toast.LENGTH_SHORT).show()
             when (selectedItem)
                {
                    "Castellano" -> changelanguaje("es")
                    "Catala" -> changelanguaje("cat")
                    "English" -> changelanguaje("en")
                  }
            }
            override fun onNothingSelected(p0: AdapterView<*>?) {
                // Acción opcional cuando no hay selección
            }
        }
    }

    private fun changelanguaje(language: String) {
        val locale = Locale(language)
        Locale.setDefault(locale)
        val config = Configuration()
        config.locale = locale
        resources.updateConfiguration(config, resources.displayMetrics)
        updateUI()
        saveLanguage(language)
    }

    private fun updateUI() {
        userNck.hint = getString(R.string.nickname)
        userPsw.hint = getString(R.string.pasword)
        pswFrgt.text = getString(R.string.forgotpassword)
        loginBtn.text = getString(R.string.loginBtn)
    }

    private fun saveLanguage(language: String) {
        val sharedPreferences = getSharedPreferences("settings", MODE_PRIVATE)
        val editor = sharedPreferences.edit()
        editor.putString("selected_language", language)
        editor.apply()
    }
}