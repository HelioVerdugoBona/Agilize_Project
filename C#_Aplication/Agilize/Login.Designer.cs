﻿namespace Agilize
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginBox = new System.Windows.Forms.GroupBox();
            this.LblPaswordForgot = new System.Windows.Forms.LinkLabel();
            this.SingUpLbl = new System.Windows.Forms.LinkLabel();
            this.DonAcount = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            this.LoginBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(208)))));
            this.LoginBox.Controls.Add(this.pictureBox2);
            this.LoginBox.Controls.Add(this.LblPaswordForgot);
            this.LoginBox.Controls.Add(this.SingUpLbl);
            this.LoginBox.Controls.Add(this.DonAcount);
            this.LoginBox.Controls.Add(this.textBox2);
            this.LoginBox.Controls.Add(this.textBox1);
            this.LoginBox.Controls.Add(this.LoginBtn);
            this.LoginBox.Location = new System.Drawing.Point(621, 0);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(643, 765);
            this.LoginBox.TabIndex = 1;
            this.LoginBox.TabStop = false;
            // 
            // LblPaswordForgot
            // 
            this.LblPaswordForgot.AutoSize = true;
            this.LblPaswordForgot.LinkColor = System.Drawing.Color.Black;
            this.LblPaswordForgot.Location = new System.Drawing.Point(545, 433);
            this.LblPaswordForgot.Name = "LblPaswordForgot";
            this.LblPaswordForgot.Size = new System.Drawing.Size(87, 13);
            this.LblPaswordForgot.TabIndex = 6;
            this.LblPaswordForgot.TabStop = true;
            this.LblPaswordForgot.Text = "Forgot Pasword?";
            this.LblPaswordForgot.VisitedLinkColor = System.Drawing.Color.Blue;
            this.LblPaswordForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblPaswordForgot_LinkClicked);
            // 
            // SingUpLbl
            // 
            this.SingUpLbl.AutoSize = true;
            this.SingUpLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingUpLbl.LinkColor = System.Drawing.Color.Black;
            this.SingUpLbl.Location = new System.Drawing.Point(385, 676);
            this.SingUpLbl.Name = "SingUpLbl";
            this.SingUpLbl.Size = new System.Drawing.Size(138, 37);
            this.SingUpLbl.TabIndex = 4;
            this.SingUpLbl.TabStop = true;
            this.SingUpLbl.Text = "Sign Up";
            this.SingUpLbl.VisitedLinkColor = System.Drawing.Color.Blue;
            this.SingUpLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SingUpLbl_LinkClicked);
            // 
            // DonAcount
            // 
            this.DonAcount.AutoSize = true;
            this.DonAcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DonAcount.Location = new System.Drawing.Point(102, 676);
            this.DonAcount.Name = "DonAcount";
            this.DonAcount.Size = new System.Drawing.Size(292, 37);
            this.DonAcount.TabIndex = 3;
            this.DonAcount.Text = "Don\'t have acount?";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(21, 369);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(611, 51);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Password";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(21, 274);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(611, 51);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Username or Email";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(101)))), ((int)(((byte)(158)))));
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoginBtn.Location = new System.Drawing.Point(231, 561);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(192, 58);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Agilize.Properties.Resources.Icon;
            this.pictureBox2.Location = new System.Drawing.Point(270, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 103);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Agilize.Properties.Resources.TeamWork_1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(626, 765);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Login";
            this.Text = "Login";
            this.LoginBox.ResumeLayout(false);
            this.LoginBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox LoginBox;
        private System.Windows.Forms.LinkLabel SingUpLbl;
        private System.Windows.Forms.Label DonAcount;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.LinkLabel LblPaswordForgot;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
