﻿using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agilize
{
    public partial class ProjectFolders : Form
    {
        DirectoryInfo actualDirectory;
        List<FichDir> subDirectories = new List<FichDir>();
        List<FichDir> files = new List<FichDir>();
        String pathToProjectFiles;
        String newfolderPathTxtBox;
        Users user;

        public ProjectFolders(Users user,String pathToProjectFiles)
        {
            InitializeComponent();
            SetAllLbls();
            getAll(user, pathToProjectFiles);
            RedondearBoton(saveBTN);
        }

        private void getAll(Users user, String pathToProjectFiles)
        {
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
            if (pathToProjectFiles != null)
            {
                folderPathTxtBox.Text = pathToProjectFiles;
            }

        }

        private void SetAllLbls()
        {
            homeLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            newProjectLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            projectFoldersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            acountLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = pathToProjectFiles;
            DialogResult result = folder.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderPathTxtBox.Text = folder.SelectedPath;
                pathToProjectFiles = folder.SelectedPath;
                newfolderPathTxtBox = folder.SelectedPath;
                actualDirectory = new DirectoryInfo(folderPathTxtBox.Text);

                ObtainSubdirectories();
                Obtainfiles();
            }
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
        private void ObtainSubdirectories()
        {
            subDirectories.Clear();
            foreach (DirectoryInfo subDir in actualDirectory.GetDirectories())
            {
                FichDir fichDir = new FichDir();
                fichDir.Name = subDir.Name;
                fichDir.Fullname = subDir.FullName;
                subDirectories.Add(fichDir);

                directorysListBox.DataSource = null;
                directorysListBox.DataSource = subDirectories;
                directorysListBox.DisplayMember = "Name";
            }
        }

        private void Obtainfiles()
        {
            files.Clear();

            foreach (FileInfo file in actualDirectory.GetFiles())
            {
                FichDir fichDir = new FichDir();
                fichDir.Name = file.Name;
                fichDir.Fullname = file.FullName;
                files.Add(fichDir);

                fileListBox.DataSource = null;
                fileListBox.DataSource = files;
                fileListBox.DisplayMember = "Name";
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

        private void saveBTN_Click(object sender, EventArgs e)
        {
            pathToProjectFiles = newfolderPathTxtBox;
        }

        private void calendarIMG_Click(object sender, EventArgs e)
        {

        }

        private void calendarLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
