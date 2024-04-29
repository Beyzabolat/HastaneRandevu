namespace HastaneRandevu
{
    partial class DocLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocLogin));
            this.loginTxt = new System.Windows.Forms.Label();
            this.mainmenuTxt = new System.Windows.Forms.Label();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.exitTxt = new System.Windows.Forms.Label();
            this.clearFieldsTxt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_ShowPw = new System.Windows.Forms.Button();
            this.usernamePic = new System.Windows.Forms.PictureBox();
            this.passwordPic = new System.Windows.Forms.PictureBox();
            this.loginPic = new System.Windows.Forms.PictureBox();
            this.btn_HidePw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).BeginInit();
            this.SuspendLayout();
            // 
            // loginTxt
            // 
            this.loginTxt.AutoSize = true;
            this.loginTxt.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loginTxt.Location = new System.Drawing.Point(78, 232);
            this.loginTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginTxt.Name = "loginTxt";
            this.loginTxt.Size = new System.Drawing.Size(251, 52);
            this.loginTxt.TabIndex = 16;
            this.loginTxt.Text = "Doktor Giriş";
            this.loginTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainmenuTxt
            // 
            this.mainmenuTxt.AutoSize = true;
            this.mainmenuTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainmenuTxt.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.mainmenuTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainmenuTxt.Location = new System.Drawing.Point(33, 521);
            this.mainmenuTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainmenuTxt.Name = "mainmenuTxt";
            this.mainmenuTxt.Size = new System.Drawing.Size(113, 27);
            this.mainmenuTxt.TabIndex = 32;
            this.mainmenuTxt.Text = "Ana Sayfa";
            this.mainmenuTxt.Click += new System.EventHandler(this.mainmenuTxt_Click);
            // 
            // txtPw
            // 
            this.txtPw.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPw.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPw.Location = new System.Drawing.Point(87, 367);
            this.txtPw.Margin = new System.Windows.Forms.Padding(4);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new System.Drawing.Size(299, 22);
            this.txtPw.TabIndex = 30;
            this.txtPw.TextChanged += new System.EventHandler(this.txtPw_TextChanged);
            this.txtPw.Enter += new System.EventHandler(this.txtPw_Enter);
            this.txtPw.Leave += new System.EventHandler(this.txtPw_Leave);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUser.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUser.Location = new System.Drawing.Point(87, 297);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(299, 22);
            this.txtUser.TabIndex = 29;
            this.txtUser.Text = "Kullanıcı Adınız";
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // exitTxt
            // 
            this.exitTxt.AutoSize = true;
            this.exitTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitTxt.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.exitTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exitTxt.Location = new System.Drawing.Point(325, 521);
            this.exitTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.exitTxt.Name = "exitTxt";
            this.exitTxt.Size = new System.Drawing.Size(58, 27);
            this.exitTxt.TabIndex = 33;
            this.exitTxt.Text = "Çıkış";
            this.exitTxt.Click += new System.EventHandler(this.exitTxt_Click);
            // 
            // clearFieldsTxt
            // 
            this.clearFieldsTxt.AutoSize = true;
            this.clearFieldsTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearFieldsTxt.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clearFieldsTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clearFieldsTxt.Location = new System.Drawing.Point(208, 409);
            this.clearFieldsTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clearFieldsTxt.Name = "clearFieldsTxt";
            this.clearFieldsTxt.Size = new System.Drawing.Size(175, 27);
            this.clearFieldsTxt.TabIndex = 31;
            this.clearFieldsTxt.Text = "Alanları Temizle";
            this.clearFieldsTxt.Click += new System.EventHandler(this.clearFieldsTxt_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Location = new System.Drawing.Point(39, 404);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 1);
            this.panel2.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Location = new System.Drawing.Point(39, 334);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 1);
            this.panel1.TabIndex = 34;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Login.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_Login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Login.Location = new System.Drawing.Point(35, 444);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(347, 43);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "Giriş Yap";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "eye.png");
            // 
            // btn_ShowPw
            // 
            this.btn_ShowPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ShowPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_ShowPw.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_ShowPw.ImageKey = "eye.png";
            this.btn_ShowPw.ImageList = this.ımageList1;
            this.btn_ShowPw.Location = new System.Drawing.Point(313, 342);
            this.btn_ShowPw.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ShowPw.Name = "btn_ShowPw";
            this.btn_ShowPw.Size = new System.Drawing.Size(69, 59);
            this.btn_ShowPw.TabIndex = 38;
            this.btn_ShowPw.Text = "button1";
            this.btn_ShowPw.UseVisualStyleBackColor = true;
            this.btn_ShowPw.Click += new System.EventHandler(this.btn_ShowPw_Click);
            // 
            // usernamePic
            // 
            this.usernamePic.Image = global::HastaneRandevu.Properties.Resources._3;
            this.usernamePic.Location = new System.Drawing.Point(39, 290);
            this.usernamePic.Margin = new System.Windows.Forms.Padding(4);
            this.usernamePic.Name = "usernamePic";
            this.usernamePic.Size = new System.Drawing.Size(40, 37);
            this.usernamePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.usernamePic.TabIndex = 37;
            this.usernamePic.TabStop = false;
            // 
            // passwordPic
            // 
            this.passwordPic.Image = global::HastaneRandevu.Properties.Resources._4;
            this.passwordPic.Location = new System.Drawing.Point(39, 360);
            this.passwordPic.Margin = new System.Windows.Forms.Padding(4);
            this.passwordPic.Name = "passwordPic";
            this.passwordPic.Size = new System.Drawing.Size(40, 37);
            this.passwordPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.passwordPic.TabIndex = 35;
            this.passwordPic.TabStop = false;
            // 
            // loginPic
            // 
            this.loginPic.Image = global::HastaneRandevu.Properties.Resources.Adsız_tasarım__6_;
            this.loginPic.Location = new System.Drawing.Point(110, 61);
            this.loginPic.Margin = new System.Windows.Forms.Padding(4);
            this.loginPic.Name = "loginPic";
            this.loginPic.Size = new System.Drawing.Size(171, 158);
            this.loginPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginPic.TabIndex = 15;
            this.loginPic.TabStop = false;
            // 
            // btn_HidePw
            // 
            this.btn_HidePw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_HidePw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_HidePw.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_HidePw.ImageKey = "eye.png";
            this.btn_HidePw.ImageList = this.ımageList1;
            this.btn_HidePw.Location = new System.Drawing.Point(314, 342);
            this.btn_HidePw.Margin = new System.Windows.Forms.Padding(4);
            this.btn_HidePw.Name = "btn_HidePw";
            this.btn_HidePw.Size = new System.Drawing.Size(69, 59);
            this.btn_HidePw.TabIndex = 39;
            this.btn_HidePw.UseVisualStyleBackColor = true;
            this.btn_HidePw.Click += new System.EventHandler(this.btn_HidePw_Click);
            // 
            // DocLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(416, 575);
            this.Controls.Add(this.btn_HidePw);
            this.Controls.Add(this.btn_ShowPw);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.mainmenuTxt);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.exitTxt);
            this.Controls.Add(this.clearFieldsTxt);
            this.Controls.Add(this.usernamePic);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.passwordPic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loginTxt);
            this.Controls.Add(this.loginPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DocLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doktor Girişi";
            ((System.ComponentModel.ISupportInitialize)(this.usernamePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loginPic;
        private System.Windows.Forms.Label loginTxt;
        private System.Windows.Forms.Label mainmenuTxt;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label exitTxt;
        private System.Windows.Forms.Label clearFieldsTxt;
        private System.Windows.Forms.PictureBox usernamePic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox passwordPic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button btn_ShowPw;
        private System.Windows.Forms.Button btn_HidePw;
    }
}