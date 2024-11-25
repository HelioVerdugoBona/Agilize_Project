using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agilize
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetAll();
        }

        private void SetAll()
        {
            SetTextUserName(usernameTxTBox);
            SetTextPassword(paswordTxTBox);
            SetAllLbls();
            RedondearBoton(LoginBtn);
        }

        private void SetAllLbls()
        {
            LblPaswordForgot.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            singUpLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
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

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            MainHub mainHub = new MainHub();
            mainHub.Show();
        }

        private void SingUpLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        private void LblPaswordForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void usernameTxTBox_Enter(object sender, EventArgs e)
        {
            if (usernameTxTBox.Text == "Username or Email")
            {
                usernameTxTBox.Text = "";
                usernameTxTBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void usernameTxTBox_Leave(object sender, EventArgs e)
        {
            SetTextUserName(usernameTxTBox);
        }

        private void SetTextUserName(System.Windows.Forms.TextBox txtBox)
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.Text = "Username or Email";
                txtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
        }

        //---------------------------------------------------------

        private void paswordTxTBox_Enter(object sender, EventArgs e)
        {
            if (paswordTxTBox.Text == "Password")
            {
                paswordTxTBox.Text = "";
                paswordTxTBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void paswordTxTBox_Leave(object sender, EventArgs e)
        {
            SetTextPassword(paswordTxTBox); 
        }

        private void SetTextPassword(System.Windows.Forms.TextBox txtBox)
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.Text = "Password";
                txtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
        }
    }
}
