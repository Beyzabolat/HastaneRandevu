namespace HastaneRandevu
{
    partial class Opening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opening));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DocLogin = new System.Windows.Forms.Button();
            this.btn_SecLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.label1.Location = new System.Drawing.Point(13, 321);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 47);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sağlıklı Yolculuk Hastanesi";
            // 
            // btn_DocLogin
            // 
            this.btn_DocLogin.BackColor = System.Drawing.Color.Transparent;
            this.btn_DocLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DocLogin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btn_DocLogin.ForeColor = System.Drawing.Color.Teal;
            this.btn_DocLogin.Location = new System.Drawing.Point(52, 70);
            this.btn_DocLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DocLogin.Name = "btn_DocLogin";
            this.btn_DocLogin.Size = new System.Drawing.Size(240, 55);
            this.btn_DocLogin.TabIndex = 22;
            this.btn_DocLogin.Text = "Doktor Girişi";
            this.btn_DocLogin.UseVisualStyleBackColor = false;
            this.btn_DocLogin.Click += new System.EventHandler(this.btn_DocLogin_Click);
            // 
            // btn_SecLogin
            // 
            this.btn_SecLogin.BackColor = System.Drawing.Color.Transparent;
            this.btn_SecLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SecLogin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.btn_SecLogin.ForeColor = System.Drawing.Color.Teal;
            this.btn_SecLogin.Location = new System.Drawing.Point(52, 165);
            this.btn_SecLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SecLogin.Name = "btn_SecLogin";
            this.btn_SecLogin.Size = new System.Drawing.Size(240, 55);
            this.btn_SecLogin.TabIndex = 23;
            this.btn_SecLogin.Text = "Sekreter Girişi";
            this.btn_SecLogin.UseVisualStyleBackColor = false;
            this.btn_SecLogin.Click += new System.EventHandler(this.btn_SecLogin_Click);
            // 
            // Opening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::HastaneRandevu.Properties.Resources.docBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(778, 396);
            this.Controls.Add(this.btn_SecLogin);
            this.Controls.Add(this.btn_DocLogin);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Opening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DocLogin;
        private System.Windows.Forms.Button btn_SecLogin;
    }
}