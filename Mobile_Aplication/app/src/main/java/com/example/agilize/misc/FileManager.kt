package com.example.agilize.misc

import android.content.Context
import android.os.Build
import androidx.annotation.RequiresApi
import com.example.agilize.classes.Projects
import com.example.agilize.classes.Users
import com.google.firebase.crashlytics.buildtools.reloc.com.google.common.reflect.TypeToken
import com.google.gson.Gson
import java.io.File
import java.io.FileWriter
import java.util.Base64
import javax.crypto.Cipher
import javax.crypto.SecretKey
import javax.crypto.spec.IvParameterSpec
import javax.crypto.spec.SecretKeySpec

class FileManager
{
    companion object {
        private const val secretKey = "YqNkZ2lK8mvAqOq5F5j8ZMBktcBGVKTvMkYpHl1IkHc="
        private const val iv = "7JZ+YmFic2x+5Te3mF7Fcg=="


        fun comproveFile(context: Context,filename: String): Boolean
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = File(jsonFilePath)
            return jsonFile.exists() && jsonFile.length() != 0L
        }

        //==========================================Users==========================================//

        @RequiresApi(Build.VERSION_CODES.O)
        fun getUsersStats(context: Context, filename: String): MutableList<Users> {

            // Ruta del archivo JSON encriptado
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = File(jsonFilePath)

            return if (comproveFile(context,filename)) {
                // Leer el contenido encriptado del archivo
                val encryptedContent = jsonFile.readText()

                // Desencriptar el contenido
                val decryptedJson = decryptAES(encryptedContent)

                // Convertir el JSON desencriptado a lista de Users
                val listUsersType = object : TypeToken<MutableList<Users>>() {}.type
                Gson().fromJson(decryptedJson, listUsersType)
            } else {
                mutableListOf() // Si el archivo no existe, devolver una lista vacía
            }
        }

        @RequiresApi(Build.VERSION_CODES.O)
        fun saveUsersStats(context: Context, arrayUsersData: List<Users>, filename: String)
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = FileWriter(jsonFilePath)
            val gson = Gson()
            val jsonElement = gson.toJson(arrayUsersData)
            val encryptedJson = encryptAES(jsonElement)
            jsonFile.write(encryptedJson)
            jsonFile.close()
        }



        //==========================================Projects==========================================//

        @RequiresApi(Build.VERSION_CODES.O)
        fun getProjectStats(context: Context, filename: String): MutableList<Projects>
        {
            // Ruta del archivo JSON encriptado
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = File(jsonFilePath)

            return if (comproveFile(context,filename)) {
                // Leer el contenido encriptado del archivo
                val encryptedContent = jsonFile.readText()

                // Desencriptar el contenido
                val decryptedJson = decryptAES(encryptedContent)

                // Convertir el JSON desencriptado a lista de Users
                val listProjectsType = object : TypeToken<MutableList<Projects>>() {}.type
                Gson().fromJson(decryptedJson, listProjectsType)
            } else {
                mutableListOf() // Si el archivo no existe, devolver una lista vacía
            }
        }

        @RequiresApi(Build.VERSION_CODES.O)
        fun saveProjectStats(context: Context, arrayProjectData: List<Projects>, filename: String)
        {
            val jsonFilePath = context.filesDir.toString() + "/$filename"
            val jsonFile = FileWriter(jsonFilePath)
            val gson = Gson()
            val jsonElement = gson.toJson(arrayProjectData)
            val encryptedJson = encryptAES(jsonElement)
            jsonFile.write(encryptedJson)
            jsonFile.close()
        }


        @RequiresApi(Build.VERSION_CODES.O)
        fun encryptAES(plainText: String): String {
            return try {
                // Decodificar la clave y el IV desde Base64
                val decodedKey = Base64.getDecoder().decode(secretKey)
                val secretKeySpec: SecretKey = SecretKeySpec(decodedKey, "AES")
                val ivSpec = IvParameterSpec(Base64.getDecoder().decode(iv))

                // Configurar el cifrado AES en modo CBC
                val cipher = Cipher.getInstance("AES/CBC/PKCS5Padding")
                cipher.init(Cipher.ENCRYPT_MODE, secretKeySpec, ivSpec)

                // Encriptar el texto y codificarlo a Base64
                val encryptedBytes = cipher.doFinal(plainText.toByteArray(Charsets.UTF_8))
                Base64.getEncoder().encodeToString(encryptedBytes)
            } catch (e: Exception) {
                e.printStackTrace()
                throw RuntimeException("Error al encriptar el texto: ${e.message}")
            }
        }

        @RequiresApi(Build.VERSION_CODES.O)
        fun decryptAES(encryptedText: String): String {
            try {
                // Decodificar la clave y el IV desde Base64
                val decodedKey = Base64.getDecoder().decode(secretKey)
                val secretKey: SecretKey = SecretKeySpec(decodedKey, 0, decodedKey.size, "AES")
                val iv = IvParameterSpec(Base64.getDecoder().decode(iv))

                // Configurar el cifrado AES en modo CBC
                val cipher = Cipher.getInstance("AES/CBC/PKCS5Padding")
                cipher.init(Cipher.DECRYPT_MODE, secretKey, iv)

                // Decodificar y desencriptar el texto
                val encryptedBytes = Base64.getDecoder().decode(encryptedText)
                val decryptedBytes = cipher.doFinal(encryptedBytes)

                // Convertir a String y devolver
                return String(decryptedBytes, Charsets.UTF_8)
            } catch (e: Exception) {
                e.printStackTrace()
                throw RuntimeException("Error al desencriptar el texto")
            }
        }
    }
}