using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;

namespace HastaneRandevu
{
    public partial class SecLogin : Form
    {
        public SecLogin()
        {
            InitializeComponent();
        }

        private void clearFieldsTxt_Click(object sender, EventArgs e)
        {
            txtUser2.Clear();
            txtPw2.Clear();
            txtUser2.Focus();
        }
        private void txtUserEnter2(object sender, EventArgs e)
        {
            if (txtUser2.Text.Equals(@"Kullanıcı Adınız"))
            {
                txtUser2.Text = "";
            }
        }

        private void txtUserLeave2(object sender, EventArgs e)
        {
            if (txtUser2.Text.Equals(@""))
            {
                txtUser2.Text = "Kullanıcı Adınız";
            }
        }

        private void txtPwLeave2(object sender, EventArgs e)
        {
            if (txtPw2.Text.Equals(@""))
            {
                txtPw2.Text = "********";
            }
        }

        private void txtPwEnter2(object sender, EventArgs e)
        {
            if (txtPw2.Text.Equals(@"********"))
            {
                txtPw2.Text = "";
                txtPw2.PasswordChar = '*'; // Şifre alanındaki karakterleri göster
            }
        }


        private void mainmenuTxt_Click(object sender, EventArgs e)
        {
            Opening loginScreen = new Opening();
            loginScreen.Show();
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            EntitySec ent = new EntitySec();
            ent.Secusername = txtUser2.Text;
            ent.Secpassword = txtPw2.Text;
            if (txtUser2.Text == "Kullanıcı Adınız" || txtPw2.Text == "********")
            {
                MessageBox.Show("Kullanıcı Adı ya da şifre boş bırakılamaz!!");
            }
            else
            {
                if (LogicSec.LLSecGiris(ent) == 1)
                {
                    SecAnaSayfa secAnaSayfa = new SecAnaSayfa();
                    secAnaSayfa.Show();
                    this.Close();
                }
                else if (LogicSec.LLSecGiris(ent) == 2)
                {
                    MessageBox.Show("Kullanıcı adı ya da şifreniz hatalıdır. Lütfen kullanıcı adınızı ya da şifrenizi kontrol ediniz!");
                }
            }

        }

        private void txtUser2_Enter(object sender, EventArgs e)
        {
            if (txtUser2.Text == "Kullanıcı Adınız")
            {
                txtUser2.Text = "";
                txtUser2.ForeColor = Color.Gray; // Opsiyonel: Siyah renkte görünecek
            }
        }

        private void txtUser2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser2.Text))
            {
                txtUser2.Text = "Kullanıcı Adınız";
                txtUser2.ForeColor = Color.Gray; // Opsiyonel: Gri renkte görünecek
            }
        }

        private void txtPw2_Enter(object sender, EventArgs e)
        {
            if (txtPw2.Text == "********")
            {
                txtPw2.Text = "";
                txtPw2.ForeColor = Color.Gray; // Opsiyonel: Siyah renkte görünecek
                txtPw2.PasswordChar = '*'; // Şifre alanındaki karakterleri göster
            }
        }

        private void txtPw2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPw2.Text))
            {
                txtPw2.Text = "********";
                txtPw2.ForeColor = Color.Gray; // Opsiyonel: Gri renkte görünecek
                txtPw2.PasswordChar = '\0'; // Şifre alanındaki karakterleri gizle
            }
        }

        private void exitTxt_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Opening loginScreen = new Opening();
            loginScreen.Show();
            this.Hide();
        }
    }
}
