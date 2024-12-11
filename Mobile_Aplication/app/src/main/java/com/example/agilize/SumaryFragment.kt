package com.example.agilize

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.agilize.adapters.RecyclerViewUsersAdapter
import com.example.agilize.classes.Tasks

class SumaryFragment: Fragment()
{
    companion object {
    private const val ARG_TASK = "task"
    fun newInstance(task: Tasks): SumaryFragment {
        val fragment = SumaryFragment()
        val args = Bundle()
        args.putParcelable(ARG_TASK, task)
        fragment.arguments = args
        return fragment
    }
}

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View
    {
        val view = inflater.inflate(R.layout.fragment_sumary,container,false)

        val task = arguments?.getParcelable<Tasks>("task")
        if(task != null){
            view?.let { setAll(it, task) }
        }

        return view
    }

    private fun setAll(view: View, task: Tasks) {
        val txtStarted = view.findViewById<TextView>(R.id.TxtFinalDateCreation)
        val txtEnded = view.findViewById<TextView>(R.id.TxtFinalDateEnd)
        val txtState = view.findViewById<TextView>(R.id.TxtFinalCurrentState)
        val txtSprint = view.findViewById<TextView>(R.id.TxtFinalSprint)
        val txtTime = view.findViewById<TextView>(R.id.TxtFinalTime)
        val txtDescription = view.findViewById<TextView>(R.id.TxtFinalDesciprion)

        val rvMembers = view.findViewById<RecyclerView>(R.id.RVFinalMembers)


        txtStarted.text = task.DateCreation
        txtEnded.text = task.DeadLine
        txtState.text = setState(task.CurrentState)
        txtSprint.text = task.Sprint.toString()
        txtTime.text = task.EstimatedTime
        txtDescription.text = task.Description

        val adapter = RecyclerViewUsersAdapter(task.TaskMembers)
        rvMembers.adapter = adapter
        rvMembers.layoutManager = GridLayoutManager(view.context, 3)
    }

    private fun setState(currentState: Int): String {
        when(currentState){
            0 -> return getString(R.string.backlog)
            1 -> return getString(R.string.to_do)
            2 -> return getString(R.string.doing)
            3 -> return getString(R.string.pending_confirmation)
            4 -> return getString(R.string.done)
        }
        return "Error"
    }
}