package com.example.agilize.classes

import android.os.Parcel
import android.os.Parcelable


class Projects(var projectOwner:String, var projectName: String, var arrayProjectUsers: MutableList<Users>,
               var  arrayTasks: MutableList<Tasks>): Parcelable {

    constructor(parcel: Parcel) : this(
        parcel.readString().toString(),
        parcel.readString().toString(),
        mutableListOf<Users>().apply {
            parcel.readTypedList(this, Users.CREATOR)
        },
        mutableListOf<Tasks>().apply {
        parcel.readTypedList(this, Tasks.CREATOR)
        }
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeString(projectOwner)
        parcel.writeString(projectName)
        parcel.writeTypedList(arrayProjectUsers)
        parcel.writeTypedList(arrayTasks)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Projects> {
        override fun createFromParcel(parcel: Parcel): Projects {
            return Projects(parcel)
        }

        override fun newArray(size: Int): Array<Projects?> {
            return arrayOfNulls(size)
        }
    }
}