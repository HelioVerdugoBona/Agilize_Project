package com.example.agilize.classes

import java.io.Serializable

class Tasks(var TaskName: String, var Description: String, var DateCreation: String, var DeadLine: String,
            var CurrentState: Int, var Sprint: Int, var EstimatedTime: String, var TaskMembers: MutableList<Users>):
    Serializable