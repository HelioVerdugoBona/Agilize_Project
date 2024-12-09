using System;
using System.Drawing;
using System.Windows.Forms;

namespace Agilize
{
    public partial class MainHub : Form
    {

        Users user;
        String pathToProjectFiles;

        public MainHub(Users user, String pathToProjectFiles)
        {
            InitializeComponent();
            this.user = new Users();
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
            SetAll();
            
        }

        private void SetAll()
        {
            SetAllLbls();
            string fontPathInter = @"Fonts\Inter_Regular.ttf";
            string fontPathOutfit = @"Fonts\Outfit_Regular.ttf";

            Fonts fontLoader = new Fonts();
            Font InterRegular = fontLoader.LoadCustomFont(fontPathInter, 16);
            Font outfitRegular = fontLoader.LoadCustomFont(fontPathOutfit, 16);

            ProjectLBox.Font = InterRegular;
            projectsLBL.Font = outfitRegular;

            if (user.projectsList != null)
            {
                foreach (var project in user.projectsList)
                {
                    ProjectLBox.Items.Add(project);
                }
            }
            RedondearBoton(logOutBtn);
        }

        private void RedondearBoton(System.Windows.Forms.Button btn)
        {
            var radio = 8;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(btn.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(btn.Width - radio, btn.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, btn.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        private void SetAllLbls()
        {
            homeLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            newProjectLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            projectFoldersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            acountLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        
        }

        private void ProjectLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String projectName = (String)ProjectLBox.SelectedItem;

            if (projectName != null)
            {
                foreach (var existentProject in user.projectsList)
                {
                    if (projectName.Equals(existentProject))
                    {
                        ProjectWindow project = new ProjectWindow(user, pathToProjectFiles, existentProject, false);
                        project.Show();
                        this.Close();
                    }
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
