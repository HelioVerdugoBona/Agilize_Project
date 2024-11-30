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
    public partial class ManageMembers : Form
    {
        Users newUser = new Users();
        Users user;
        public ManageMembers(Users user, String pathToProjectFiles)
        {
            InitializeComponent();
            this.user = user;
        }

        private void createMemberBtn_Click(object sender, EventArgs e)
        {

        }

        private void addMemberBtn_Click(object sender, EventArgs e)
        {

        }

        private void deleteMemberbtn_Click(object sender, EventArgs e)
        {

        }

        private void mailTxtBox_Enter(object sender, EventArgs e)
        {
            if (mailTxtBox.Text == "Email")
            {
                mailTxtBox.Text = "";
                mailTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void mailTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mailTxtBox.Text))
            {
                mailTxtBox.Text = "Email";
                mailTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                newUser.email = mailTxtBox.Text;
            }
        }

        private void NicknameTxtBox_Enter(object sender, EventArgs e)
        {
            if (NicknameTxtBox.Text == "Nickname")
            {
                NicknameTxtBox.Text = "";
                NicknameTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void NicknameTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NicknameTxtBox.Text))
            {
                NicknameTxtBox.Text = "Nickname";
                NicknameTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                newUser.nickname = NicknameTxtBox.Text;
            }
        }

        private void PaswordTxtBox_Enter(object sender, EventArgs e)
        {
            if (PaswordTxtBox.Text == "Password")
            {
                PaswordTxtBox.Text = "";
                PaswordTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void PaswordTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PaswordTxtBox.Text))
            {
                PaswordTxtBox.Text = "Password";
                PaswordTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                newUser.password = PaswordTxtBox.Text;
            }
        }

        private void retunBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
