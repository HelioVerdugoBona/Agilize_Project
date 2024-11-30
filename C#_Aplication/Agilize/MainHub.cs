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
    public partial class MainHub : Form
    {
       
        Users user;
        String pathToProjectFiles;
        public MainHub(Users user, String pathToProjectFiles)
        {
            this.user = new Users();
            InitializeComponent();
            this.user = user;
            SetAllLbls();
            this.pathToProjectFiles = pathToProjectFiles;
        }

        public MainHub(Users user)
        {
            InitializeComponent();
            SetAllLbls();
            this.user = user;
        }

        private void SetAllLbls()
        {
            homeLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            newProjectLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            calendarLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            projectFoldersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            acountLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            SettingLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            foreach(var project in user.projectsList)
            {
                ProjectLBox.Items.Add(project);
            }
            
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

        private void newProjectLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewProject newProject = new NewProject(user, pathToProjectFiles);
            newProject.Show();
            this.Close();
        }

        private void newProjectIMG_Click(object sender, EventArgs e)
        {
            NewProject newProject = new NewProject(user, pathToProjectFiles);
            newProject.Show();
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProjectLBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
