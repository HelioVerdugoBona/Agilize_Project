
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Agilize
{
    public partial class SignUp : Form
    {
        Users newUser = new Users();
        String pathToProjectFiles;
        
        String encryptingKey = "f83jsd74jdue0qnd";// Letras aleatoreas completamente

        public SignUp(String pathToProjectFiles)
        {
            InitializeComponent();
            SetAll();
            this.pathToProjectFiles = pathToProjectFiles;
        }

        private void SetAll()
        {
            LoginLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;

        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            newUser.password = EncryptPassword(newUser.password);

            if (ValidateNewUser())
            {
                if (!File.Exists(pathToProjectFiles))
                {
                    File.Create(pathToProjectFiles).Close(); // Crea y cierra el archivo
                }

                // Leer usuarios existentes del archivo JSON
                List<Users> usersList = new List<Users>();
                string jsonContent = File.ReadAllText(pathToProjectFiles);
                if (!string.IsNullOrWhiteSpace(jsonContent))
                {
                    usersList = System.Text.Json.JsonSerializer.Deserialize<List<Users>>(jsonContent);
                }

                // Agregar el nuevo usuario a la lista
                usersList.Add(newUser);

                string newJsonContent = System.Text.Json.JsonSerializer.Serialize(usersList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(pathToProjectFiles, newJsonContent);

                MessageBox.Show("Usuario registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor introduce parametros validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void nameTxtBox_Enter(object sender, EventArgs e)
        {
            if (nameTxtBox.Text == "Name")
            {
                nameTxtBox.Text = "";
                nameTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void nameTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTxtBox.Text))
            {
                nameTxtBox.Text = "Name";
                nameTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                newUser.name = nameTxtBox.Text;
            }
        }

        private void surnamesTxtBox_Enter(object sender, EventArgs e)
        {
            if (surnamesTxtBox.Text == "Surnames")
            {
                surnamesTxtBox.Text = "";
                surnamesTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void surnamesTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(surnamesTxtBox.Text))
            {
                surnamesTxtBox.Text = "Surnames";
                surnamesTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                newUser.surname = surnamesTxtBox.Text;
            }
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

        private bool ValidateNewUser()
        {
            return !string.IsNullOrWhiteSpace(newUser.name) &&
                   !string.IsNullOrWhiteSpace(newUser.surname) &&
                   !string.IsNullOrWhiteSpace(newUser.email) &&
                   !string.IsNullOrWhiteSpace(newUser.nickname) &&
                   !string.IsNullOrWhiteSpace(newUser.password);
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
