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
        public MainHub()
        {
            InitializeComponent();
            SetAllLbls();
        }

        private void SetAllLbls()
        {
            homeLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            newProjectLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            calendarLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            projectFoldersLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            acountLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            SettingLBL.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }


        private void Menu_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void acountIMG_Click(object sender, EventArgs e)
        {

        }

        private void newProjectLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Project project = new Project();
            project.Show();
            this.Close();
        }

        private void newProjectIMG_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            project.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
