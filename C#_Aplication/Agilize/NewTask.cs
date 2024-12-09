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
            RedondearBoton(acceptBtn);
            RedondearBoton(cancelBtn);
        }
        private void RedondearBoton(System.Windows.Forms.Button btn)
        {
            var radio = 15;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(btn.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(btn.Width - radio, btn.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, btn.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        private void projectNameTxTBox_TextChanged(object sender, EventArgs e)
        {
            newTaskName = projectNameTxTBox.Text;
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newTaskName))
            {
                Task task = new Task(projectWindow, tasksList, user, newTaskName, state, projectsUsers);
                this.Hide();
                task.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Introduce un Nombre valido","Name Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
