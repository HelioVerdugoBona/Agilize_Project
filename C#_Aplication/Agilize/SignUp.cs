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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void SingUpLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();        
        }

        private void HaveAcount_Click(object sender, EventArgs e)
        {

        }
    }
}
