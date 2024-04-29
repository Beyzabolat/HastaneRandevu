using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace HastaneRandevu
{
    public partial class DocLogin : Form
    {
        public DocLogin()
        {
            InitializeComponent();
        }

        private void clearFieldsTxt_Click(object sender, EventArgs e)
        {
            txtUser.Clear();    // Username girilen textboxtaki metni silmeye yarayan kod
            txtPw.Clear();      // Şifre girilen textboxtaki metni silmeye yarayan kod
            txtUser.Focus();
        }

        private void exitTxt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Kullanıcı Adınız")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Gray; // Opsiyonel: Siyah renkte görünecek
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.Text = "Kullanıcı Adınız";
                txtUser.ForeColor = Color.Gray; // Opsiyonel: Gri renkte görünecek
            }
        }

        private void txtPw_Enter(object sender, EventArgs e)
        {
            if (txtPw.Text == "********")
            {
                txtPw.Text = "";
                txtPw.PasswordChar = '*'; // Şifre alanındaki karakterleri göster
            }
        }

        private void txtPw_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPw.Text))
            {
                txtPw.Text = "********";
                txtPw.PasswordChar = '\0'; // Şifre alanındaki karakterleri gizle
            }
        }

        private void mainmenuTxt_Click(object sender, EventArgs e)
        {
            Opening loginScreen = new Opening();
            loginScreen.Show();
            this.Hide();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            EntityDoc ent = new EntityDoc();
            ent.Docusername = txtUser.Text;
            ent.Docpassword = txtPw.Text;
            if (txtUser.Text == "Kullanıcı Adınız" || txtPw.Text == "********")
            {
                MessageBox.Show("Kullanıcı Adı ya da şifre boş bırakılamaz!!");
            }
            else
            {
                if (LogicDoc.LLDoktorGiris(ent) == 1)
                {
                    OleDbCommand a = LogicDoc.LLDoktorAdıCek(ent);
                    string ad = (string)a.ExecuteScalar();
                    OleDbCommand b = LogicDoc.LLDoktorSoyadıCek(ent);
                    string soyad = (string)b.ExecuteScalar();

                    DocAnaSayfa docAnaSayfa = new DocAnaSayfa();
                    docAnaSayfa.doktorad = ad;
                    docAnaSayfa.doktorsoyad = soyad;
                    docAnaSayfa.Show();
                    this.Hide();
                }
                else if (LogicDoc.LLDoktorGiris(ent) == 2)
                {
                    MessageBox.Show("Kullanıcı adı ya da şifreniz hatalıdır. Lütfen kullanıcı adınızı ya da şifrenizi kontrol ediniz!");
                }
            }
        }

        private void btn_ShowPw_Click(object sender, EventArgs e)
        {
            if (txtPw.PasswordChar == '*')
            {
                btn_HidePw.BringToFront();
                txtPw.PasswordChar = '\0';
            }
        }

        private void btn_HidePw_Click(object sender, EventArgs e)
        {
            if (txtPw.PasswordChar == '\0')
            {
                btn_ShowPw.BringToFront();
                txtPw.PasswordChar = '*';
            }
        }
        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
