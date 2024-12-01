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
    public partial class ManageMembers : Form
    {
        Users newUser = new Users();
        BindingList<Users> listNewUsers = new BindingList<Users>();
        Users user;
        Projects projects;
        String pathToProjectFiles;

        public ManageMembers(Users user, String pathToProjectFiles,Projects projects)
        {
            InitializeComponent();
            this.projects = new Projects();
            this.projects = projects;
            this.user = user;
            this.pathToProjectFiles = pathToProjectFiles;
            setListsBoxs();

        }

        private void setListsBoxs()
        {

            if (!File.Exists(pathToProjectFiles + "\\Users.json"))
            {
                File.Create(pathToProjectFiles + "\\Users.json").Close(); // Crea y cierra el archivo
            }
            else
            {
                List<Users> usersList = new List<Users>();
                string jsonContent = File.ReadAllText(pathToProjectFiles + "\\Users.json");
                if (!string.IsNullOrWhiteSpace(jsonContent))
                {
                    usersList = System.Text.Json.JsonSerializer.Deserialize<List<Users>>(jsonContent);
                }
                if (projects.arrayProjectUsers != null)
                {
                    foreach (Users user in usersList)
                    {
                        if (user.nickname.Equals(this.user.nickname) && projects.arrayProjectUsers.Contains(user))
                        {
                            membersofAgilize.Items.Add(user);
                        }
                    }

                    foreach (var projectMember in projects.arrayProjectUsers)
                    {
                        projectMembers.Items.Add(projectMember);
                    }
                }
                else
                {
                    foreach (Users user in usersList)
                    {
                        if (!user.nickname.Equals(this.user.nickname))
                        {
                            membersofAgilize.Items.Add(user);
                        }
                    }
                }
            } 
        }

        private void createMemberBtn_Click(object sender, EventArgs e)
        {
            if (ValidateNewUser())
            {
                Users userToAdd = new Users
                {
                    nickname = newUser.nickname,
                    email = newUser.email,
                    password = EncryptPassword(newUser.password)
                };

                projectMembers.Items.Add(userToAdd);

                if (projects.arrayProjectUsers != null)
                {
                    projects.arrayProjectUsers.Add(userToAdd);
                }
                else
                {
                    projects.arrayProjectUsers = new BindingList<Users> { userToAdd };
                }

                newUser.email = null;
                newUser.nickname = null;
                newUser.password = null;

                mailTxtBox.Text = "Email";
                NicknameTxtBox.Text = "Nickname";
                PaswordTxtBox.Text = "Password";
            }
            else
            {
                MessageBox.Show("Error, los parametros no son correctos para un usuario", "Creating Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
           
        }

        private void addMemberBtn_Click(object sender, EventArgs e)
        {
            Users addedUsers = (Users)membersofAgilize.SelectedItem;
            if (addedUsers != null)
            {
                projectMembers.Items.Add(addedUsers);
                projects.arrayProjectUsers.Add(addedUsers);

                membersofAgilize.Items.Remove(addedUsers);
            }
            else
            {
                MessageBox.Show("Error, no se ha selecciconado miembro a añadir", "Selecting Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void deleteMemberbtn_Click(object sender, EventArgs e)
        {
            Users deletedUser = (Users)projectMembers.SelectedItem;
            if (deletedUser != null)
            {
                membersofAgilize.Items.Add(deletedUser);
                projectMembers.Items.Remove(deletedUser);
                projects.arrayProjectUsers.Remove(deletedUser);
            }
            else
            {
                MessageBox.Show("Error, no se ha selecciconado miembro a eliminar", "Selecting Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        private void retunBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateNewUser()
        {
            return !string.IsNullOrWhiteSpace(newUser.email) &&
                   !string.IsNullOrWhiteSpace(newUser.nickname) &&
                   !string.IsNullOrWhiteSpace(newUser.password);
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
    }
}
