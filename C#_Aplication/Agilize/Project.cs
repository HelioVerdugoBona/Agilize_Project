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
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
            SetAllLbls();
        }


        private void SetAllLbls()
        {
            homeLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            manageMembersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            calendarLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            projectFoldersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            acountLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            SettingLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void newProjectIMG_Click(object sender, EventArgs e)
        {

        }

        private void homeLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainHub mainHub = new MainHub();
            mainHub.Show();
            this.Close();
        }

        private void homeIMG_Click(object sender, EventArgs e)
        {
            MainHub mainHub = new MainHub();
            mainHub.Show();
            this.Close();
        }

        private void backLogLBL_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.ShowDialog();
        }

        private void toDoLBL_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.ShowDialog();
        }

        private void doingLBL_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.ShowDialog();
        }

        private void pendingConfirmationLBL_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.ShowDialog();
        }

        private void doneLBL_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.ShowDialog();
        }
    }
}
