using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agilize
{
    public partial class NewTask : Form
    {
        BindingList<Tasks> tasksList;
        BindingList<Users> projectsUsers;
        ProjectWindow projectWindow;
        Users user;
        String newTaskName;
        TaskState state;
        public NewTask(ProjectWindow projectWindow, BindingList<Tasks> tasksList, Users user, TaskState state, BindingList<Users> projectsUsers)
        {
            InitializeComponent();
            this.tasksList = new BindingList<Tasks>();
            this.projectsUsers = new BindingList<Users>();
            this.tasksList = tasksList;
            this.projectWindow = projectWindow;
            this.user = user;
            this.state = state;
            this.projectsUsers = projectsUsers;
        }

        private void projectNameTxTBox_TextChanged(object sender, EventArgs e)
        {
            newTaskName = projectNameTxTBox.Text;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            Task task = new Task(projectWindow, tasksList, user, newTaskName, state, projectsUsers);
            task.Show();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
