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
    public partial class NewProject : Form
    {

        Projects projects = new Projects();
        Users user;
        String pathToProjectFiles;
        public NewProject(Users user, String pathToProjectFiles)
        {
            InitializeComponent();
            this.user = new Users();
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
        }

        private void projectNameTxTBox_Enter(object sender, EventArgs e)
        {
            if (projectNameTxTBox.Text == "Project Name")
            {
                projectNameTxTBox.Text = "";
                projectNameTxTBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void projectNameTxTBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(projectNameTxTBox.Text))
            {
                projectNameTxTBox.Text = "Project Name";
                projectNameTxTBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                projects.projectName = projectNameTxTBox.Text;

            }
            
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            user.projectsList.Add(projects.projectName);
            ProjectWindow project = new ProjectWindow(user,pathToProjectFiles,projects);
            project.Show();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
