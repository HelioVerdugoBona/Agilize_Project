package com.example.agilize.misc

import android.content.Context
import android.os.Environment
import com.example.agilize.classes.Projects
import com.example.agilize.classes.Users
import com.google.firebase.crashlytics.buildtools.reloc.com.google.common.reflect.TypeToken
import com.google.gson.Gson
import java.io.File
import java.io.FileReader
import java.io.FileWriter

class FileManager
{
    companion object {

        fun comproveFile(context: Context,filename: String): Boolean
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = File(jsonFilePath)
            return jsonFile.exists() && jsonFile.length() != 0L
        }

        //==========================================Users==========================================//

        fun getUsersStats(context: Context,filename: String): MutableList<Users>
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = FileReader(jsonFilePath)
            val listUsersType = object : TypeToken<MutableList<Users>>() {}.type
            val arrayUsersData: MutableList<Users> = Gson().fromJson(jsonFile,listUsersType)
            return arrayUsersData
        }

        fun saveUsersStats(context: Context, arrayUsersData: List<Users>, filename: String)
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = FileWriter(jsonFilePath)
            val gson = Gson()
            val jsonElement = gson.toJson(arrayUsersData)
            jsonFile.write(jsonElement)
            jsonFile.close()
        }

        //==========================================Projects==========================================//

        fun getProjectStats(context: Context,filename: String): MutableList<Projects>
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = FileReader(jsonFilePath)
            val listProjectsType = object : TypeToken<MutableList<Projects>>() {}.type
            val arrayProjectData: MutableList<Projects> = Gson().fromJson(jsonFile,listProjectsType)
            return arrayProjectData
        }

        fun saveProjectStats(context: Context, arrayProjectData: List<Projects>, filename: String)
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = FileWriter(jsonFilePath)
            val gson = Gson()
            val jsonElement = gson.toJson(arrayProjectData)
            jsonFile.write(jsonElement)
            jsonFile.close()
        }
    }
}