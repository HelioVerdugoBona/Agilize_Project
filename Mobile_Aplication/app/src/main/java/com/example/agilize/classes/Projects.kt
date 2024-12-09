package com.example.agilize.classes

import java.io.Serializable

class Projects(var projectOwner:String, var projectName: String, var arrayProjectUsers: MutableList<Users>,
               var  arrayTasks: MutableList<Tasks>): Serializable