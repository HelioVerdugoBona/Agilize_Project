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
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
            SetAll();
        }

        private void SetAll()
        {
            RedondearBoton(retunBTN);
            RedondearBoton(saveBTN);
            RedondearBoton(addMemberBTN);
        }

        private void RedondearBoton(System.Windows.Forms.Button btn)
        {
            var radio = 15;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(btn.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(btn.Width - radio, btn.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, btn.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        private void descriptionTxtBox_Enter(object sender, EventArgs e)
        {
            if (descriptionTxtBox.Text == "Add a description")
            {
                descriptionTxtBox.Text = "";
                descriptionTxtBox.ForeColor = SystemColors.WindowText; // Cambiar a color normal
            }
        }

        private void descriptionTxtBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTxtBox.Text))
            {
                descriptionTxtBox.Text = "Add a description";
                descriptionTxtBox.ForeColor = SystemColors.GrayText; // Cambiar a color gris
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
