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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            MainHub mainHub = new MainHub();
            mainHub.Show();
            //this.Close();
        }

        private void SingUpLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            //this.Close();
        }

        private void LblPaswordForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
