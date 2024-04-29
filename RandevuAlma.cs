using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using EntityLayer;
using LogicLayer;
using DataAccessLayer;
using System.Data.SqlClient;

namespace HastaneRandevu
{
    public partial class RandevuAlma : Form
    {
        public RandevuAlma()
        {
            InitializeComponent();
        }

        private void btn_DocLogin_Click(object sender, EventArgs e)
        {
            if (txt_HastaAdi.Text == "" || txt_HastaSoyadi.Text == "" || txt_TCKN.Text == "" || txt_Telefon.Text == "" +
                "" || comboBox_Bolum.Text == "" || comboBox_Doktoradi.Text == "" || comboBox_Saat.Text == "" || comboBox_Dakika.Text == "")
            {
                MessageBox.Show("Hiçbir alan boş bırakılamaz!!!");
            }
            else
            {
                EntityHst ent = new EntityHst();                                //Bu kod parçası, kullanıcının belirli alanları doldurmasını kontrol eder                                   
                ent.Hstname = txt_HastaAdi.Text;                                //Eğer kullanıcı herhangi bir alanı boş bırakırsa, uyarı mesajı görüntülenir.
                ent.Hstsurname = txt_HastaSoyadi.Text;                          //Eğer tüm alanlar doldurulmuşsa, kullanıcının girdiği bilgiler
                ent.Hsttckn = txt_TCKN.Text;                                    //"EntitiesHst" adlı sınıfın nesnesine atılır ve "LogicHst.LLHstEkle" metodu çağrılır.
                ent.Hstphone = txt_Telefon.Text;                                //Bu metod, kullanıcının girdiği bilgileri veritabanına ekler.
                ent.Hstbolum = comboBox_Bolum.Text;                             //Son olarak, kullanıcıya "Randevu başarıyla kaydedilmiştir" mesajı gösterilir.
                ent.Docname = comboBox_Doktoradi.Text;
                ent.Tarih = dateTimePicker1.Value;
                ent.Saat = comboBox_Saat.Text + ":" + comboBox_Dakika.Text;
                ent.Rapor = " ";
                LogicHst.LLHstEkle(ent);

                MessageBox.Show("Randevu başarıyla kaydedilmiştir.");
            }
        }

        private void RandevuAlma_Load(object sender, EventArgs e)
        {
            // Saatleri ComboBox'a ekleyelim
            for (int i = 0; i <= 23; i++)
            {
                comboBox_Saat.Items.Add(i.ToString("00")); // Saatleri iki haneli olarak ekleyelim (örneğin: "01", "02", ..., "23")
            }

            // Dakikaları ComboBox'a ekleyelim
            for (int i = 0; i <= 59; i++)
            {
                comboBox_Dakika.Items.Add(i.ToString("00")); // Dakikaları iki haneli olarak ekleyelim (örneğin: "00", "01", ..., "59")
            }

            // İsteğe bağlı olarak, başlangıçta varsayılan saat ve dakikayı seçebilirsiniz
            comboBox_Saat.SelectedIndex = 0;
            comboBox_Dakika.SelectedIndex = 0;
            // Örnek bir bölüm listesi oluşturalım
            List<string> bolumListesi = new List<string>();
            bolumListesi.Add("Kardiyoloji");
            bolumListesi.Add("Ortopedi");
            bolumListesi.Add("Dahiliye");
            // ComboBox'ın veri kaynağını bu listeye bağlayalım
            comboBox_Bolum.DataSource = bolumListesi;
            // DataGridView'deki CellClick veya CellContentClick olaylarına listeleme metodunu atayalım

            dateTimePicker1.MinDate = DateTime.Now;
            OleDbDataReader dr = LogicHst.LLFilter(comboBox_Bolum.Text);              //bu kod parçası, seçilen bölüme göre
            while (dr.Read())                                                       //doktorların doktoradi comboBox'unda listelenmesini
            {                                                                       //sağlar.
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }
            dr.Close();

        }
        private void comboBox_Bolum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Doktoradi.Items.Clear();
            OleDbDataReader dr = LogicHst.LLFilter(comboBox_Bolum.Text);              //bu kod parçası, seçilen bölüme göre
            while (dr.Read())                                                       //doktorların doktoradi comboBox'unda listelenmesini
            {                                                                       //sağlar.
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }
            dr.Close();
        }

        private void txt_TCKN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;                                                        //bu kod parçası kimlik numarası ve telefon numarası
            }                                                                            //alanlarına harf girilmemesini ve en fazla
                                                                                         //11 karakter girilmesini sağlar.
            int maxLength = 11;
            if (txt_TCKN.Text.Length >= maxLength && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txt_Telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            int maxLength = 11;
            if (txt_Telefon.Text.Length >= maxLength && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtMainMenu_Click(object sender, EventArgs e)
        {
            SecAnaSayfa secAnaSayfa = new SecAnaSayfa();
            secAnaSayfa.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Hafta sonları seçilemez!");                //dateTimePicker üzerinde hafta sonunun
                dateTimePicker1.Value = DateTime.Now.AddDays(2);            //seçilmemesini sağlar
            }
        }

        private void comboBox_Bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Önce ComboBox'ı temizleyelim
            comboBox_Doktoradi.Items.Clear();

            // Seçilen bölüm adını alalım
            string selectedBolum = comboBox_Bolum.SelectedItem.ToString();

            // LogicLayer'daki LLFilter metodu kullanarak seçilen bölüme uygun doktorları getirelim
            OleDbDataReader dr = LogicHst.LLFilter(selectedBolum);

            // Doktorları ComboBox'a ekleyelim
            while (dr.Read())
            {
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }

            // DataReader'ı kapatmayı unutmayalım
            dr.Close();
        }

    }
}
