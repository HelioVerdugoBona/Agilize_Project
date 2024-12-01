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

namespace Agilize
{
    public partial class Acount : Form
    {
        Users user;
        String pathToProjectFiles;
        String newPswrd;
        public Acount(Users user, String pathToProjectFiles)
        {
            InitializeComponent();
            SetAllLbls();
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
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

        private void calendarLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Calendar calendar = new Calendar(user, pathToProjectFiles);
            calendar.Show();
            this.Close();
        }

        private void calendarIMG_Click(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar(user, pathToProjectFiles);
            calendar.Show();
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

        private void SettingLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings settings = new Settings(user, pathToProjectFiles);
            settings.Show();
            this.Close();
        }

        private void settingsIMG_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(user, pathToProjectFiles);
            settings.Show();
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
                user.name = nameTxtBox.Text;
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
                user.surname = surnamesTxtBox.Text;
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
                user.email = mailTxtBox.Text;
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
                newPswrd = PaswordTxtBox.Text;
            }
        }

        private void confirmPswrdTxtBox_Enter(object sender, EventArgs e)
        {
            if (confirmPswrdTxtBox.Text == "Password")
            {
                confirmPswrdTxtBox.Text = "";
                confirmPswrdTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void confirmPswrdTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(confirmPswrdTxtBox.Text))
            {
                confirmPswrdTxtBox.Text = "Password";
                confirmPswrdTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
            }
            else
            {
                String newPswrdConfirmation = confirmPswrdTxtBox.Text;

                if (newPswrd.Equals(newPswrdConfirmation))
                {
                    user.password = EncryptPassword(newPswrdConfirmation);
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    confirmPswrdTxtBox.Text = "Password";
                    PaswordTxtBox.Text = "Password";
                }

            }
        }


        public string EncryptPassword(string pswd)
        {
            var engine = new BlowfishEngine();
            var blockCipher = new PaddedBufferedBlockCipher(engine);
            var keyBytes = Encoding.UTF8.GetBytes("f83jsd74jdue0qnd");
            blockCipher.Init(true, new KeyParameter(keyBytes));

            var inputBytes = Encoding.UTF8.GetBytes(pswd);
            var outputBytes = new byte[blockCipher.GetOutputSize(inputBytes.Length)];

            var length = blockCipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            blockCipher.DoFinal(outputBytes, length);

            return Convert.ToBase64String(outputBytes);
        }

        private void deleteAcountBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro de querer borrar su cuenta? Esto será PERMANENTE","Borrar Cuenta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (ValidateUser())
                {
                    if (!File.Exists(pathToProjectFiles + "\\Users.json"))
                    {
                        File.Create(pathToProjectFiles + "\\Users.json").Close(); // Crea y cierra el archivo
                    }

                    // Leer usuarios existentes del archivo JSON
                    List<Users> usersList = new List<Users>();
                    string jsonContent = File.ReadAllText(pathToProjectFiles + "\\Users.json");
                    if (!string.IsNullOrWhiteSpace(jsonContent))
                    {
                        usersList = System.Text.Json.JsonSerializer.Deserialize<List<Users>>(jsonContent);
                    }
                    foreach (var user in usersList)
                    {
                        if (user.nickname.Equals(this.user.nickname))
                        {
                            usersList.Remove(user);
                            break;
                        }
                    }

                    string newJsonContent = System.Text.Json.JsonSerializer.Serialize(usersList, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(pathToProjectFiles + "\\Users.json", newJsonContent);

                    MessageBox.Show("Se ha eliminado su cuenta con éxito. \n ¡Hasta luego y gracias por el pescado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor introduce parametros validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (ValidateUser())
            {
                if (!File.Exists(pathToProjectFiles + "\\Users.json"))
                {
                    File.Create(pathToProjectFiles + "\\Users.json").Close(); // Crea y cierra el archivo
                }

                // Leer usuarios existentes del archivo JSON
                List<Users> usersList = new List<Users>();
                string jsonContent = File.ReadAllText(pathToProjectFiles + "\\Users.json");
                if (!string.IsNullOrWhiteSpace(jsonContent))
                {
                    usersList = System.Text.Json.JsonSerializer.Deserialize<List<Users>>(jsonContent);
                }
                foreach (var user in usersList)
                {
                    if (user.nickname.Equals(this.user.nickname))
                    {
                        usersList.Remove(user);
                        usersList.Add(this.user);
                        break;
                    }
                }
 
                string newJsonContent = System.Text.Json.JsonSerializer.Serialize(usersList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(pathToProjectFiles + "\\Users.json", newJsonContent);

                MessageBox.Show("Datos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor introduce parametros validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser()
        {
            return !string.IsNullOrWhiteSpace(user.name) &&
                   !string.IsNullOrWhiteSpace(user.surname) &&
                   !string.IsNullOrWhiteSpace(user.email) &&
                   !string.IsNullOrWhiteSpace(user.nickname) &&
                   !string.IsNullOrWhiteSpace(user.password);
        }
    }
}
