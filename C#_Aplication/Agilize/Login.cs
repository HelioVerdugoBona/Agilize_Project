using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agilize
{
    public partial class Login : Form
    {
        Users user;
        String pathToProjectFiles;
        String encryptingKey = "f83jsd74jdue0qnd";// Letras aleatoreas completamente

        public Login(String pathToProjectFiles) 
        {
            InitializeComponent();
            user  = new Users();
            SetAll();
            this.pathToProjectFiles = pathToProjectFiles;
        }

        private void SetAll()
        {
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
            
            if (ValidateUser())
            {
                user.password = EncryptPassword(user.password);
                if (File.Exists(pathToProjectFiles + "\\Users.json"))
                {
                    if (IsUser())
                    {
                        MainHub mainHub = new MainHub(user, pathToProjectFiles);
                        mainHub.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrectos", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ha habido un error con los archivos de la aplicación",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }
            else
            {
                MessageBox.Show("Porfavor introduce valores validos", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean IsUser()
        {
            // Leer usuarios existentes del archivo JSON (si es necesario)
            List<Users> usersList = new List<Users>();
            string jsonContent = File.ReadAllText(pathToProjectFiles + "\\Users.json");
            if (!string.IsNullOrWhiteSpace(jsonContent))
            {
                usersList = System.Text.Json.JsonSerializer.Deserialize<List<Users>>(jsonContent);
            }

            foreach (var appUser in usersList)
            {
                if (appUser.nickname.Equals(user.nickname) && appUser.password.Equals(user.password))
                {
                    user = appUser;
                    return true;
                }
            }
            return false;
        }

        private void SingUpLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp(pathToProjectFiles + "\\Users.json");
            signUp.ShowDialog();
        }

        private void usernameTxTBox_Enter(object sender, EventArgs e)
        {
            if (usernameTxTBox.Text == "Nickname")
            {
                usernameTxTBox.Text = "";
                usernameTxTBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void usernameTxTBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTxTBox.Text))
            {
                usernameTxTBox.Text = "Nickname";
                usernameTxTBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                user.nickname = usernameTxTBox.Text;
            }

        }

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
            if (string.IsNullOrWhiteSpace(paswordTxTBox.Text))
            {
                paswordTxTBox.Text = "Password";
                paswordTxTBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                user.password = paswordTxTBox.Text;
            }
        }

        private void LblPaswordForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("JA JA JA, vaya prinago",
                       "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidateUser()
        {
            return !string.IsNullOrWhiteSpace(user.nickname) &&
                   !string.IsNullOrWhiteSpace(user.password);
        }

        public string EncryptPassword(string pswd)
        {
            var engine = new BlowfishEngine();
            var blockCipher = new PaddedBufferedBlockCipher(engine);
            var keyBytes = Encoding.UTF8.GetBytes(encryptingKey);
            blockCipher.Init(true, new KeyParameter(keyBytes));

            var inputBytes = Encoding.UTF8.GetBytes(pswd);
            var outputBytes = new byte[blockCipher.GetOutputSize(inputBytes.Length)];

            var length = blockCipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            blockCipher.DoFinal(outputBytes, length);

            return Convert.ToBase64String(outputBytes);
        }
    }
}
