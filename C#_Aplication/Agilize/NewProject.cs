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

        Projects projects;
        Users user;
        String pathToProjectFiles;
        public NewProject(Users user, String pathToProjectFiles)
        {
            InitializeComponent();
            projects = new Projects();
            this.user = new Users();
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
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
            if (!string.IsNullOrWhiteSpace(projects.projectName))
            {
                if (user.projectsList == null)
                {
                    BindingList<String> firstProject = new BindingList<String>();
                    firstProject.Add(projects.projectName);
                    user.projectsList = firstProject;
                }
                else
                {
                    user.projectsList.Add(projects.projectName);
                }
                ProjectWindow project = new ProjectWindow(user, pathToProjectFiles, projects.projectName, true);
                project.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Introduce un Nombre valido", "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
