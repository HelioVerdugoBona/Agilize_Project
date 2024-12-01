using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Agilize
{
    public partial class Task : Form
    {
        BindingList<Tasks> tasksList;
        ProjectWindow projectWindow;
        BindingList<Users> projectMembers;
        Users user;
        Tasks task;
        Tasks oldTask;
        Boolean isnewTask;
        public Task(ProjectWindow projectWindow, BindingList<Tasks> tasksList,Tasks task, Users user, BindingList<Users> projectMembers)
        {
            InitializeComponent();
            this.task = new Tasks();
            oldTask = new Tasks();
            this.projectMembers = new BindingList<Users>();
            this.projectMembers = projectMembers;
            isnewTask = false;
            this.tasksList = tasksList;
            this.projectWindow = projectWindow;
            this.task = task;
            this.user = user;
            SetAll(false);
        }

        public Task(ProjectWindow projectWindow, BindingList<Tasks> tasksList, Users user,String taskName,TaskState state, BindingList<Users> projectMembers)
        {
            InitializeComponent();
            task = new Tasks();
            this.tasksList = tasksList;
            this.projectWindow = projectWindow;
            this.projectMembers = new BindingList<Users>();
            this.projectMembers = projectMembers;
            this.user = user;
            isnewTask = true;
            task.CurrentState = state;
            task.TaskName = taskName;
            SetAll(true);
        }

       private void SetAll(Boolean firstTime)
        {
            RedondearBoton(retunBTN);
            RedondearBoton(addMemberBTN);
            RedondearBoton(deleteMemberBtn);
            if (firstTime)
            {
                SetAllLblsFirstTime();
            }
            else
            {
                SetAllLbls();
            }
            SetAllLBox();
        }

        private void SetAllLBox()
        {
            if (projectMembers != null)
            {
                if (task.TaskMembers != null)
                {
                    foreach (var userProject in this.projectMembers)
                    {
                        if (userProject != null && !task.TaskMembers.Contains(userProject))
                        {
                            MembersListBox.Items.Add(userProject);
                        }
                    }
                }
                else
                {
                    foreach (var userProject in this.projectMembers)
                    {
                        if (userProject != null)
                        {
                            MembersListBox.Items.Add(userProject);
                        }
                    }
                }
            }
            if (task.TaskMembers != null)
            {
                foreach(var userTask in this.task.TaskMembers)
                {
                    if (userTask != null)
                    {
                        ListedMembersListBox.Items.Add(userTask);
                    }
                }
            }
           
        }

        private void SetAllLblsFirstTime()
        {
            TaskLBL.Text = task.TaskName;

            currentSateCBox.SelectedIndexChanged -= currentSateCBox_SelectedIndexChanged;

            currentSateCBox.DataSource = Enum.GetValues(typeof(TaskState));
            currentSateCBox.SelectedItem = task.CurrentState;

            currentSateCBox.SelectedIndexChanged += currentSateCBox_SelectedIndexChanged;

            ListedMembersListBox.Items.Clear();
            MembersListBox.Items.Clear();
        }

        private void SetAllLbls()
        {
            TaskLBL.Text = task.TaskName;

            currentSateCBox.SelectedIndexChanged -= currentSateCBox_SelectedIndexChanged;

            currentSateCBox.DataSource = Enum.GetValues(typeof(TaskState));
            descriptionTxtBox.Text = task.Description;

            currentSateCBox.SelectedIndexChanged += currentSateCBox_SelectedIndexChanged;
            dateCreationTPicker.Text = task.DateCreation.ToString();
            deadLineTPicker.Text = task.DeadLine.ToString();
            sprintNumUpDown.Text = task.Sprint.ToString();
            currentSateCBox.SelectedItem = task.CurrentState;
            estimatedTimeTxtBox.Text = task.EstimatedTime;
            ListedMembersListBox.Items.Clear();
            MembersListBox.Items.Clear();
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

        private void ValidateTask()
        {
            if (task.Description == null)
            {
                task.Description = " ";
            }
            if (task.DateCreation == null)
            {
                task.DateCreation = dateCreationTPicker.Value.ToString();
            }
            if (task.DeadLine == null)
            {
                task.DeadLine = deadLineTPicker.Value.ToString();
            }
            if (task.EstimatedTime == null)
            {
                task.EstimatedTime = "0h";
            }
            if (task.TaskMembers == null)
            {
                task.TaskMembers.Add(this.user);
            }
        }

        private void descriptionTxtBox_TextChanged(object sender, EventArgs e)
        {
            task.Description = descriptionTxtBox.Text;
        }

        private void dateCreationTPicker_ValueChanged(object sender, EventArgs e)
        {
            task.DateCreation = deadLineTPicker.Value.ToString();
        }

        private void deadLineTPicker_ValueChanged(object sender, EventArgs e)
        {
            task.DeadLine = deadLineTPicker.Value.ToString();
        }

        private void currentSateCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            task.CurrentState = (TaskState)currentSateCBox.SelectedItem;
        }

        private void sprintNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            task.Sprint = (int) sprintNumUpDown.Value;
        }

        private void estimatedTimeTxtBox_TextChanged(object sender, EventArgs e)
        {
            task.EstimatedTime = estimatedTimeTxtBox.Text;
        }

        private void deleteMemberBtn_Click(object sender, EventArgs e)
        {
            if (ListedMembersListBox.SelectedItem == null)
            {
                MessageBox.Show("No hay ningun miembro seleccionado","Delete Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Users deletedUser = (Users)ListedMembersListBox.SelectedItem;
                if (deletedUser != null)
                {
                    MembersListBox.Items.Add(deletedUser);
                    ListedMembersListBox.Items.Remove(deletedUser);
                    task.TaskMembers.Remove(deletedUser);
                }
            }
        }

        private void addMemberBTN_Click(object sender, EventArgs e)
        {
            if (MembersListBox.SelectedItem == null)
            {
                MessageBox.Show("No hay ningun miembro seleccionado", "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Users addedUsers = (Users)MembersListBox.SelectedItem;
                if (addedUsers != null)
                {
                    ListedMembersListBox.Items.Add(addedUsers);
                    MembersListBox.Items.Remove(addedUsers);

                    if (task.TaskMembers == null)
                    {
                        task.TaskMembers = new BindingList<Users> { addedUsers };
                    }
                    else
                    {
                        task.TaskMembers.Add(addedUsers);
                    }
                }
            }
        }

        private void retunBTN_Click(object sender, EventArgs e)
        {
            ValidateTask();
            if (tasksList == null)
            {
                tasksList = new BindingList<Tasks> { task };
            }
            else
            {
                if (isnewTask)
                {
                    tasksList.Add(task);
                }
            }
            projectWindow.updateTasks(tasksList);
            this.Close();
         }

        private void descriptionTxtBox_Enter(object sender, EventArgs e)
        {
            if (descriptionTxtBox.Text == "Add a description")
            {
                descriptionTxtBox.Text = "";
                descriptionTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void descriptionTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTxtBox.Text))
            {
                descriptionTxtBox.Text = "Add a description";
                descriptionTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
        }
    }
}
