package com.example.agilize

class Tasks(var TaskName: String, var Description: String, var DateCreation: String, var DeadLine: String,
            var CurrentState: String, var Sprint: Int, var EstimatedTime: String, TaskMembers: MutableList<Users>)