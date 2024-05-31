using System;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;

namespace HastaneRandevu
{
    public partial class PasswordReset : Form
    {
        public PasswordReset()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Lütfen geçerli bir email adresi giriniz.");
                return;
            }

            string password = LogicDoc.LLDoktorSifreAl(email);

            if (password != null)
            {
                
                try
                {
                    var mailAddress = new MailAddress(email);
                    MailMessage mesaj = new MailMessage();
                    mesaj.From = new MailAddress("saglikliyasamhastanesi@gmail.com");
                    mesaj.To.Add(mailAddress.Address); 
                    mesaj.Subject = "Şifre Sıfırlama Talebi";
    StringBuilder body = new StringBuilder();
                    body.AppendLine("Merhaba,");
                    body.AppendLine();
                    body.AppendLine("Şifre sıfırlama talebiniz üzerine bu e-postayı alıyorsunuz.");
                    body.AppendLine($"Yeni şifreniz: {password}");
                    body.AppendLine();
                    body.AppendLine("Sağlıklı Yaşam Hastanesi");

                    mesaj.Body = body.ToString();

                  
                    SmtpClient a = new SmtpClient();
                    a.Credentials = new System.Net.NetworkCredential("saglikliyasamhastanesi@gmail.com", "jjmt nkds bkcc qkkn");
                    a.Port = 587;
                    a.Host = "smtp.gmail.com";
                    a.EnableSsl = true;

                   
                    a.Send(mesaj);
                    MessageBox.Show("Şifreniz email adresinize gönderildi.");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Geçersiz e-posta adresi!");
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show("Mail gönderme hatası: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Girilen email adresi ile eşleşen bir kullanıcı bulunamadı.");
            }
        }

        private void btn_BackToLogin_Click(object sender, EventArgs e)
        {
            DocLogin loginForm = new DocLogin();
            loginForm.Show();
            this.Hide();
        }
    }
}
