package com.example.agilize

import android.content.Intent
import android.content.res.Configuration
import android.graphics.Color
import android.os.Build
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.example.agilize.classes.Users
import com.example.agilize.misc.FileManager
import org.bouncycastle.crypto.engines.BlowfishEngine
import org.bouncycastle.crypto.paddings.PaddedBufferedBlockCipher
import org.bouncycastle.crypto.params.KeyParameter
import java.util.Base64
import java.util.Locale

class AccountActivity: AppCompatActivity() {

    object UserStats{
        const val STATS = "STATS"
    }

    private lateinit var userNickname: EditText
    private lateinit var userName: EditText
    private lateinit var userSurname: EditText
    private lateinit var userEmail: EditText
    private lateinit var newPassword: EditText
    private lateinit var confirmPassword: EditText

    private lateinit var englishBtn: Button
    private lateinit var catalanBtn: Button
    private lateinit var spanishBtn: Button

    private lateinit var user: Users

    private var languageUpdated = false

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_account)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        obtainUserStats()
        setAllETxt()
        setAllBtn()

        englishBtn.setOnClickListener {
            changelanguaje("en")
        }
        catalanBtn.setOnClickListener {
            changelanguaje("cat")
        }
        spanishBtn.setOnClickListener {
            changelanguaje("es")
        }

        val returnBtn = findViewById<ImageButton>(R.id.returnBtn)
        returnBtn.setOnClickListener{
            val intent = Intent()
            setResult(RESULT_OK, intent)
            finish()
        }

        val saveBtn = findViewById<ImageButton>(R.id.saveBtn)
        saveBtn.setOnClickListener{
            saveDataUser()
        }
        val changePasswordBtn = findViewById<Button>(R.id.confirmChangePasswordBtn)
        changePasswordBtn.setOnClickListener {
            if(newPassword.text.isNotEmpty() && confirmPassword.text.isNotEmpty() ){
                if(newPassword.text.toString() == confirmPassword.text.toString()){
                    user.password = encryptPassword(confirmPassword.text.toString())
                }else{
                    Toast.makeText(this@AccountActivity, getString(R.string.password_correlation_error), Toast.LENGTH_LONG).show()
                }
            }else{
                Toast.makeText(this@AccountActivity, getString(R.string.password_correlation_null), Toast.LENGTH_LONG).show()
            }
        }
    }

    private fun obtainUserStats() {
        val intent = intent
        user = intent.getParcelableExtra(UserStats.STATS)!!
    }

    private fun saveDataUser() {
        if(userName.text.isNotEmpty()){
            user.name = userName.text.toString()
        }
        if(userSurname.text.isNotEmpty()){
            user.surname = userSurname.text.toString()
        }
        if(userEmail.text.isNotEmpty()){
            user.email = userEmail.text.toString()
        }

        if(!FileManager.comproveFile(this,"Users.json")){
            Toast.makeText(this@AccountActivity, getString(R.string.saving_user_error), Toast.LENGTH_LONG).show()
        }else{
            val arrayUsers = FileManager.getUsersStats(this,"Users.json")
            val index = arrayUsers.indexOfFirst { it.nickname == user.nickname }
            if (index != -1) {
                arrayUsers[index] = user
                FileManager.saveUsersStats(this,arrayUsers,"Users.json")
            }else{
                Toast.makeText(this@AccountActivity,  getString(R.string.saving_user_error), Toast.LENGTH_SHORT).show()
            }
        }
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

    private fun setAllETxt() {
        userNickname = findViewById(R.id.EtxtUserNicknameAccount)
        userName = findViewById(R.id.EtxtUserName)
        userSurname = findViewById(R.id.EtxtUserSurname)
        userEmail = findViewById(R.id.EtxtEmail)
        newPassword = findViewById(R.id.EtxtPassword)
        confirmPassword = findViewById(R.id.EtxtConfirmPassword)

        userNickname.hint = user.nickname
        if (user.name != null){userName.hint = user.name}
        if (user.surname != null){userSurname.hint = user.surname}
        userEmail.hint = user.email
    }

    private fun setAllBtn() {
        englishBtn = findViewById(R.id.englishBtn)
        catalanBtn = findViewById(R.id.catalanBtn)
        spanishBtn = findViewById(R.id.spanishBtn)
        setBackgroundColorBtn()
    }

    private fun setBackgroundColorBtn() {
        val sharedPreferences = getSharedPreferences("settings", MODE_PRIVATE)
        val selectedLanguage = sharedPreferences.getString("language", Locale.getDefault().language)
        when(selectedLanguage){
            "en"->{
                englishBtn.setBackgroundColor(Color.rgb(64, 116, 156))
                catalanBtn.setBackgroundColor(Color.rgb(26, 101, 158))
                spanishBtn.setBackgroundColor(Color.rgb(26, 101, 158))
            }
            "cat"->{
                englishBtn.setBackgroundColor(Color.rgb(26, 101, 158))
                catalanBtn.setBackgroundColor(Color.rgb(64, 116, 156))
                spanishBtn.setBackgroundColor(Color.rgb(26, 101, 158))
            }
            "es"->{
                englishBtn.setBackgroundColor(Color.rgb(26, 101, 158))
                catalanBtn.setBackgroundColor(Color.rgb(26, 101, 158))
                spanishBtn.setBackgroundColor(Color.rgb(64, 116, 156))
            }
        }
    }


    private fun changelanguaje(language: String) {
        val locale = Locale(language)
        Locale.setDefault(locale)
        val config = Configuration()
        config.locale = locale
        resources.updateConfiguration(config, resources.displayMetrics)
        saveLanguage(language)
        setBackgroundColorBtn()
        languageUpdated = true
        recreate()
    }

    private fun saveLanguage(language: String) {
        val sharedPreferences = getSharedPreferences("settings", MODE_PRIVATE)
        val editor = sharedPreferences.edit()
        editor.putString("selected_language", language)
        editor.apply()
    }
}