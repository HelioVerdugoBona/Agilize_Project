using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agilize
{
    public partial class ProjectWindow : Form
    {
        Users user;
        String pathToProjectFiles;
        Projects projects;

        public ProjectWindow(Users user,String pathToProjectFiles)
        {
            InitializeComponent();
            SetAllLbls();
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
        }

        public ProjectWindow(Users user, String pathToProjectFiles, Projects project)
        {
            InitializeComponent();
            SetAll(user, pathToProjectFiles, project);
            IsNewProject();
        }

        private void SetAll(Users user, String pathToProjectFiles, Projects project)
        {
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
            this.projects = project;
            pruebaTasks();
            SetAllLbls();
            SetAllLBoxs();
        }

        private void pruebaTasks()
        {
            BindingList<Users> lista = new BindingList<Users>();
            lista.Add(user);
            Tasks tasks = new Tasks("First Task", "No hay descripcion", "30/11/2024 00:00:00", "30/11/2024 00:00:00", TaskState.ToDo, 3, "4h", lista);
            BindingList<Tasks> taska = new BindingList<Tasks>();
            taska.Add(tasks);
            projects.arrayTasks = taska;
        }

        private void SetAllLBoxs()
        {
            BackLogLBox.Items.Clear();
            ToDoLBox.Items.Clear();
            DoingLBox.Items.Clear();
            PendingConfirmationLBox.Items.Clear();
            DoneLBox.Items.Clear();
            if (projects.arrayTasks != null)
            {
                foreach (var task in projects.arrayTasks)
                {
                    switch (task.CurrentState)
                    {
                        case TaskState.BackLog:
                            BackLogLBox.Items.Add(task);
                            break;
                        case TaskState.ToDo:
                            ToDoLBox.Items.Add(task);
                            break;
                        case TaskState.Doing:
                            DoingLBox.Items.Add(task);
                            break;
                        case TaskState.Pending_Confirmation:
                            PendingConfirmationLBox.Items.Add(task);
                            break;
                        case TaskState.Done:
                            DoneLBox.Items.Add(task);
                            break;
                    }
                }
            }
        }

        private void IsNewProject()
        {
            ChangeJSONProperties();
            string appFolder = Path.Combine(pathToProjectFiles, projects.projectName);
            Directory.CreateDirectory(appFolder);
        }

        private void ChangeJSONProperties()
        {
            List<Users> usersList = new List<Users>();
            string jsonContent = File.ReadAllText(pathToProjectFiles + "\\Users.json");
            if (!string.IsNullOrWhiteSpace(jsonContent))
            {
                usersList = System.Text.Json.JsonSerializer.Deserialize<List<Users>>(jsonContent);
            }

            foreach (Users user in usersList)
            {
                if (this.user.nickname.Equals(user.nickname))
                {
                    user.projectsList = this.user.projectsList;
                }
            }

            string newJsonContent = System.Text.Json.JsonSerializer.Serialize(usersList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(pathToProjectFiles + "\\Users.json", newJsonContent);
        }

        private void SetAllLbls()
        {
            homeLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            manageMembersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            calendarLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            projectFoldersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            acountLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            SettingLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;

            projectNameLBL.Text = projects.projectName;
        }

        private void homeLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainHub mainHub = new MainHub(user, pathToProjectFiles);
            mainHub.Show();
            this.Close();
        }

        private void homeIMG_Click(object sender, EventArgs e)
        {
            MainHub mainHub = new MainHub(user, pathToProjectFiles);
            mainHub.Show();
            this.Close();
        }

        private void manageMembersLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManageMembers manageMembers = new ManageMembers(user, pathToProjectFiles);
            manageMembers.ShowDialog();
        }

        private void manageMembersIMG_Click(object sender, EventArgs e)
        {
            ManageMembers manageMembers = new ManageMembers(user, pathToProjectFiles);
            manageMembers.ShowDialog();
        }

        private void calendarLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Calendar calendar = new Calendar(user, pathToProjectFiles);
            calendar.Show();
            this.Close();
        }

        private void calendarIMG_Click(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar(user, pathToProjectFiles);
            calendar.Show();
            this.Close();
        }

        private void projectFoldersLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProjectFolders projectFolders = new ProjectFolders(user, pathToProjectFiles);
            projectFolders.Show();
            this.Close();
        }

        private void projectFoldersIMG_Click(object sender, EventArgs e)
        {
            ProjectFolders projectFolders = new ProjectFolders(user, pathToProjectFiles);
            projectFolders.Show();
            this.Close();
        }

        private void acountLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Acount acount = new Acount(user, pathToProjectFiles);
            acount.Show();
            this.Close();
        }

        private void acountIMG_Click(object sender, EventArgs e)
        {
            Acount acount = new Acount(user, pathToProjectFiles);
            acount.Show();
            this.Close();
        }

        private void SettingLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings settings = new Settings(user, pathToProjectFiles);
            settings.Show();
            this.Close();
        }

        private void settingsIMG_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(user, pathToProjectFiles);
            settings.Show();
            this.Close();
        }

        private void backLogLBL_Click(object sender, EventArgs e)
        {
            NewTask newtask = new NewTask(this, projects.arrayTasks, user, TaskState.BackLog);
            newtask.ShowDialog();
        }

        private void toDoLBL_Click(object sender, EventArgs e)
        {
            NewTask newtask = new NewTask(this, projects.arrayTasks, user, TaskState.ToDo);
            newtask.ShowDialog();
        }

        private void doingLBL_Click(object sender, EventArgs e)
        {
            NewTask newtask = new NewTask(this, projects.arrayTasks, user, TaskState.Doing);
            newtask.ShowDialog();
        }

        private void pendingConfirmationLBL_Click(object sender, EventArgs e)
        {
            NewTask newtask = new NewTask(this, projects.arrayTasks, user, TaskState.Pending_Confirmation);
            newtask.ShowDialog();
        }

        private void doneLBL_Click(object sender, EventArgs e)
        {
            NewTask newtask = new NewTask(this, projects.arrayTasks, user, TaskState.Done);
            newtask.ShowDialog();
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {

        }

        public void updateTasks(BindingList<Tasks> actualTasks)
        {
            projects.arrayTasks = actualTasks;
            SetAllLBoxs();
        }

        private void BackLogLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTask(BackLogLBox);
        }

        private void ToDoLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTask(ToDoLBox);
        }

        private void DoingLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTask(DoingLBox);
        }

        private void PendingConfirmationLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTask(PendingConfirmationLBox);
        }

        private void DoneLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTask(DoneLBox);
        }

        private void SelectTask(ListBox selectedListBox)
        {
            Tasks selectedTask = (Tasks)selectedListBox.SelectedItem;
            if (selectedTask != null)
            {
                Task task = new Task(this, projects.arrayTasks, selectedTask, user);
                task.ShowDialog();
            }
        }
    }
}
