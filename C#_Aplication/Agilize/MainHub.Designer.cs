namespace Agilize
{
    partial class MainHub
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
            this.Menu = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LblMenu = new System.Windows.Forms.Label();
            this.LblAcount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(197)))), ((int)(((byte)(159)))));
            this.Menu.Controls.Add(this.button1);
            this.Menu.Controls.Add(this.LblAcount);
            this.Menu.Controls.Add(this.LblMenu);
            this.Menu.Controls.Add(this.pictureBox2);
            this.Menu.Location = new System.Drawing.Point(-1, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(312, 763);
            this.Menu.TabIndex = 0;
            this.Menu.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Agilize.Properties.Resources.Icon;
            this.pictureBox2.Location = new System.Drawing.Point(100, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 103);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // LblMenu
            // 
            this.LblMenu.AutoSize = true;
            this.LblMenu.Location = new System.Drawing.Point(13, 201);
            this.LblMenu.Name = "LblMenu";
            this.LblMenu.Size = new System.Drawing.Size(34, 13);
            this.LblMenu.TabIndex = 9;
            this.LblMenu.Text = "Menu";
            // 
            // LblAcount
            // 
            this.LblAcount.AutoSize = true;
            this.LblAcount.Location = new System.Drawing.Point(13, 432);
            this.LblAcount.Name = "LblAcount";
            this.LblAcount.Size = new System.Drawing.Size(41, 13);
            this.LblAcount.TabIndex = 10;
            this.LblAcount.Text = "Acount";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(101)))), ((int)(((byte)(158)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(16, 703);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // MainHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.Menu);
            this.Name = "MainHub";
            this.Text = "MainHub";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Menu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LblAcount;
        private System.Windows.Forms.Label LblMenu;
        private System.Windows.Forms.Button button1;
    }
}