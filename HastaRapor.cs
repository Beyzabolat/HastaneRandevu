using EntityLayer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevu
{
    public partial class HastaRapor : Form
    {
        public HastaRapor()
        {
            InitializeComponent();
        }
        public string doktorad;
        public string doktorsoyad;

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            EntityHst ent = new EntityHst();
            ent.Hstid = Convert.ToInt32(textBox1.Text);
            ent.Rapor = txt_Rapor.Text;                                   
            LogicHst.LLHstGuncelle2(ent);                                  

            EntityDoc doc = new EntityDoc();                               
            doc.Docname = doktorad;                                        
            doc.Docsurname = doktorsoyad;                                   
            List<EntityHst> PerList = LogicHst.LLDoktoraGoreHstList(doc);   
            dataGridView1.DataSource = PerList;
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            EntityDoc doc = new EntityDoc();                                  
            doc.Docname = doktorad;                                            
            doc.Docsurname = doktorsoyad;                                     
                                                                              
            List<EntityHst> PerList = LogicHst.LLDoktoraGoreHstList(doc);
            dataGridView1.DataSource = PerList;
        }

        private void listeleme(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            txt_Adi.Text = selectedRow.Cells[1].Value.ToString(); 
            txt_Soyadi.Text = selectedRow.Cells[2].Value.ToString(); 
            txt_TC.Text = selectedRow.Cells[3].Value.ToString(); 
            
            lbl_ReceteNo.Text = GenerateRandomPrescriptionNumber(); 
            string randevuTarihi = selectedRow.Cells[7].Value.ToString();
            Tarih.Text = randevuTarihi; 
            txt_Rapor.Text = selectedRow.Cells[9].Value.ToString(); 
            
            Tarih.Text = randevuTarihi; 
        }

        private string GenerateRandomPrescriptionNumber()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            EntityHst ent = new EntityHst();
            ent.Hstid = Convert.ToInt32(textBox1.Text);
            LogicHst.LLHstSil(ent.Hstid);

            List<EntityHst> PerList = LogicHst.LLHstList();
            dataGridView1.DataSource = PerList;
        }

        private void btn_Mail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Mail.Text) || string.IsNullOrWhiteSpace(txt_Rapor.Text))
            {
                MessageBox.Show("Boş Alan Bırakmayınız !!!");
            }
            else
            {
                try
                {
                    var mailAddress = new MailAddress(txt_Mail.Text);
                    MailMessage mesaj = new MailMessage();
                    mesaj.From = new MailAddress("saglikliyasamhastanesi@gmail.com");
                    mesaj.To.Add(mailAddress.Address); 
                    mesaj.Subject = "# Sağlıklı Yaşam Hastanesi Doktor Raporu #";

                   
                    StringBuilder body = new StringBuilder();
                    body.AppendLine($"Sn. {txt_Adi.Text},");
                    body.AppendLine($"{Tarih.Text} tarihinde Sağlıklı Yaşam Hastanesi'nde yazılan reçete numaranız {lbl_ReceteNo.Text} ve doktor görüşü ekte bulunmaktadır.");
                    body.AppendLine("Geçmiş olsun.");
                    body.AppendLine($"Doktor Görüşü: {txt_Rapor.Text}");
                    mesaj.Body = body.ToString();

                   
                    SmtpClient a = new SmtpClient();
                    a.Credentials = new System.Net.NetworkCredential("saglikliyasamhastanesi@gmail.com", "jjmt nkds bkcc qkkn");
                    a.Port = 587;
                    a.Host = "smtp.gmail.com";
                    a.EnableSsl = true;

                   
                    a.Send(mesaj);
                    MessageBox.Show("Mail Gönderilmiştir");
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
        }

        private void txtMainMenu_Click(object sender, EventArgs e)
        {
            DocAnaSayfa dok = new DocAnaSayfa();
            dok.doktorad = doktorad;
            dok.doktorsoyad = doktorsoyad;
            dok.Show();
            this.Close();
        }

        private void HastaRapor_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(listeleme);
        }

        private void btn_Pdf_Click(object sender, EventArgs e)
        {
            
            try
            {
                string pdfFilePath = "C:\\Users\\admin\\Desktop\\HastaRaporu.pdf";

                
                Document pdfDoc = new Document();
                PdfWriter.GetInstance(pdfDoc, new FileStream(pdfFilePath, FileMode.Create));

                pdfDoc.Open();

                
                pdfDoc.Add(new Paragraph($"Doktor Adı: {doktorad} {doktorsoyad}"));
                pdfDoc.Add(new Paragraph($"Hasta ID: {textBox1.Text}"));
                pdfDoc.Add(new Paragraph("Görüşme Raporu:"));
                pdfDoc.Add(new Paragraph(txt_Rapor.Text));

                pdfDoc.Close();

                MessageBox.Show("PDF oluşturuldu: " + pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturma hatası: " + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
