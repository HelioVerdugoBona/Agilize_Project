namespace Agilize
{
    partial class SignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginBox = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Pswrd = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LoginLbl = new System.Windows.Forms.LinkLabel();
            this.HaveAcount = new System.Windows.Forms.Label();
            this.Nickname = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            this.LoginBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(208)))));
            this.LoginBox.Controls.Add(this.textBox5);
            this.LoginBox.Controls.Add(this.textBox4);
            this.LoginBox.Controls.Add(this.Pswrd);
            this.LoginBox.Controls.Add(this.pictureBox2);
            this.LoginBox.Controls.Add(this.LoginLbl);
            this.LoginBox.Controls.Add(this.HaveAcount);
            this.LoginBox.Controls.Add(this.Nickname);
            this.LoginBox.Controls.Add(this.textBox1);
            this.LoginBox.Controls.Add(this.LoginBtn);
            this.LoginBox.Location = new System.Drawing.Point(621, 0);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(643, 765);
            this.LoginBox.TabIndex = 2;
            this.LoginBox.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(311, 204);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(320, 51);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "Surnames";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(20, 204);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(242, 51);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "Name";
            // 
            // Pswrd
            // 
            this.Pswrd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.Pswrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pswrd.Location = new System.Drawing.Point(20, 442);
            this.Pswrd.Name = "Pswrd";
            this.Pswrd.Size = new System.Drawing.Size(611, 51);
            this.Pswrd.TabIndex = 8;
            this.Pswrd.Text = "Password";
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
            // LoginLbl
            // 
            this.LoginLbl.AutoSize = true;
            this.LoginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLbl.LinkColor = System.Drawing.Color.Black;
            this.LoginLbl.Location = new System.Drawing.Point(443, 683);
            this.LoginLbl.Name = "LoginLbl";
            this.LoginLbl.Size = new System.Drawing.Size(101, 37);
            this.LoginLbl.TabIndex = 4;
            this.LoginLbl.TabStop = true;
            this.LoginLbl.Text = "Login";
            this.LoginLbl.VisitedLinkColor = System.Drawing.Color.Blue;
            this.LoginLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SingUpLbl_LinkClicked);
            // 
            // HaveAcount
            // 
            this.HaveAcount.AutoSize = true;
            this.HaveAcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HaveAcount.Location = new System.Drawing.Point(83, 683);
            this.HaveAcount.Name = "HaveAcount";
            this.HaveAcount.Size = new System.Drawing.Size(379, 37);
            this.HaveAcount.TabIndex = 3;
            this.HaveAcount.Text = "Already have an acount? ";
            this.HaveAcount.Click += new System.EventHandler(this.HaveAcount_Click);
            // 
            // Nickname
            // 
            this.Nickname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.Nickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nickname.Location = new System.Drawing.Point(20, 353);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(611, 51);
            this.Nickname.TabIndex = 2;
            this.Nickname.Text = "Nickname";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(20, 270);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(611, 51);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Email";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(101)))), ((int)(((byte)(158)))));
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LoginBtn.Location = new System.Drawing.Point(243, 567);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(192, 58);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Sign Up";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Agilize.Properties.Resources.TeamWork2_1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(626, 765);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginBox);
            this.Name = "SignUp";
            this.Text = "SignUp";
            this.LoginBox.ResumeLayout(false);
            this.LoginBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LoginBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel LoginLbl;
        private System.Windows.Forms.Label HaveAcount;
        private System.Windows.Forms.TextBox Nickname;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Pswrd;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
    }
}