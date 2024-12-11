package com.example.agilize.classes

import android.os.Parcel
import android.os.Parcelable


class Tasks(var TaskName: String, var Description: String, var DateCreation: String, var DeadLine: String,
            var CurrentState: Int, var Sprint: Int, var EstimatedTime: String, var TaskMembers: MutableList<Users>):
    Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readInt(),
        parcel.readInt(),
        parcel.readString().toString(),
        mutableListOf<Users>().apply {
            parcel.readTypedList(this, Users.CREATOR)
        }
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeString(TaskName)
        parcel.writeString(Description)
        parcel.writeString(DateCreation)
        parcel.writeString(DeadLine)
        parcel.writeInt(CurrentState)
        parcel.writeInt(Sprint)
        parcel.writeString(EstimatedTime)
        parcel.writeTypedList(TaskMembers)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Tasks> {
        override fun createFromParcel(parcel: Parcel): Tasks {
            return Tasks(parcel)
        }

        override fun newArray(size: Int): Array<Tasks?> {
            return arrayOfNulls(size)
        }
    }
}