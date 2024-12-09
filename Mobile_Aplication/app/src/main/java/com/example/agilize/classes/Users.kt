package com.example.agilize.classes

import java.io.Serializable

class Users(
    var name: String, var surname: String, var password: String, var email: String,
    val nickname: String, var projectsList: MutableList<String>): Serializable