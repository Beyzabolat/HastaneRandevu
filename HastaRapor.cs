using EntityLayer;
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
            ent.Rapor = txt_Rapor.Text;                                     //Hasta raporunun
            LogicHst.LLHstGuncelle2(ent);                                   //eklenmesini sağlayan kod bloğu

            EntityDoc doc = new EntityDoc();                                //raporu kaydettikten sonra
            doc.Docname = doktorad;                                         //datagridView üzerine
            doc.Docsurname = doktorsoyad;                                   //aynı hastaların listelenmesini
            List<EntityHst> PerList = LogicHst.LLDoktoraGoreHstList(doc);   //sağlayan kod bloğu
            dataGridView1.DataSource = PerList;
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            EntityDoc doc = new EntityDoc();                                    //sadece o doktora 
            doc.Docname = doktorad;                                             //randevusu olan  
            doc.Docsurname = doktorsoyad;                                       //hastaların listelenmesini 
                                                                                //sağlayan kodlar
            List<EntityHst> PerList = LogicHst.LLDoktoraGoreHstList(doc);
            dataGridView1.DataSource = PerList;
        }
        private void listeleme(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;                                         //dataGridView üzerinde
            DataGridViewRow selectedRow = dataGridView1.Rows[index];        //listelenen hastaların
            txt_Rapor.Text = selectedRow.Cells[9].Value.ToString();         //isimlerine tıklandığında raporunun
            textBox1.Text = selectedRow.Cells[0].Value.ToString();          //textBox'a yansıtılmasını sağlayan fonksiyon
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
                    var mailAddress = new MailAddress(txt_Mail.Text); // E-posta adresini kontrol et
                    MailMessage mesaj = new MailMessage();
                    mesaj.From = new MailAddress("beybolat62@gmail.com");
                    mesaj.To.Add(mailAddress.Address); // Geçerli ise, e-posta adresini kullan
                    mesaj.Subject = "# Sağlıklı Yaşam Hastanesi Doktor Raporu #";
                    mesaj.Body = txt_Rapor.Text;

                    // SmtpClient yapılandırması
                    SmtpClient a = new SmtpClient();
                    a.Credentials = new System.Net.NetworkCredential("beybolat62@gmail.com", "035805BeyzA.");
                    a.Port = 587;
                    a.Host = "smtp.gmail.com";
                    a.EnableSsl = true;

                    // E-postayı gönderme
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
            // PDF oluşturma işlemleri
            try
            {
                // PDF dosyasının adı ve konumu
                string pdfFilePath = "C:\\Users\\admin\\Desktop\\FileName.pdf";

                // PDF belgesi oluştur
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(pdfDoc, new FileStream(pdfFilePath, FileMode.Create));

                pdfDoc.Open();

                // PDF'e eklemek istediğiniz metni ekleyin
                pdfDoc.Add(new iTextSharp.text.Paragraph("PDF Oluşturma Örnegi"));

                pdfDoc.Close();

                MessageBox.Show("PDF oluşturuldu: " + pdfFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturma hatası: " + ex.Message);
            }
        }

    }
}
