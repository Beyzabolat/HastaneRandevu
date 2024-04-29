using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using EntityLayer;
using LogicLayer;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;


namespace HastaneRandevu
{
    public partial class RandevuUpdate : Form
    {
        public RandevuUpdate()
        {
            InitializeComponent();
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            List<EntityHst> PerList = LogicHst.LLHstList();
            dataGridView1.DataSource = PerList;
        }

        private void txtMainMenu_Click(object sender, EventArgs e)
        {
            SecAnaSayfa secAnaSayfa = new SecAnaSayfa();
            secAnaSayfa.Show();
            this.Hide();
        }
        private void HastaEkle_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
        string saat;
        string dakika;
        private void listeleme(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();                      //Bu kod bloğu, dataGridView üzerinde
            txt_HastaAdi.Text = selectedRow.Cells[1].Value.ToString();                  //tıklanan hastanın tüm bilgilerini
            txt_HastaSoyadi.Text = selectedRow.Cells[2].Value.ToString();               //gerekli textBox, comboBox ve
            txt_TCKN.Text = selectedRow.Cells[3].Value.ToString();                      //dateTimePicker üzerine çekilmesini sağlar
            txt_Telefon.Text = selectedRow.Cells[4].Value.ToString();
            comboBox_Bolum.Text = selectedRow.Cells[5].Value.ToString();
            comboBox_Doktoradi.Text = selectedRow.Cells[6].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells[7].Value);
            saat = selectedRow.Cells[8].Value.ToString();
            saat = saat.Substring(0, 2);
            comboBox_Saat.Text = saat;
            dakika = selectedRow.Cells[8].Value.ToString();
            dakika = dakika.Substring(3);
            comboBox_Dakika.Text = dakika;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private void btn_Update_Click(object sender, EventArgs e)
        {

            if (txt_HastaAdi.Text == "" || txt_HastaSoyadi.Text == "" || txt_TCKN.Text == "" || txt_Telefon.Text == "" +
                "" || comboBox_Bolum.Text == "" || comboBox_Doktoradi.Text == "" || comboBox_Saat.Text == "" || comboBox_Dakika.Text == "")
            {
                MessageBox.Show("Hiçbir Alan Boş Bırakılamaz", "!!!");
            }
            else
            {
                EntityHst ent = new EntityHst();
                ent.Hstid = Convert.ToInt32(textBox1.Text);
                ent.Hstname = txt_HastaAdi.Text;
                ent.Hstsurname = txt_HastaSoyadi.Text;
                ent.Hsttckn = txt_TCKN.Text;
                ent.Hstphone = txt_Telefon.Text;
                ent.Hstbolum = comboBox_Bolum.Text;
                ent.Docname = comboBox_Doktoradi.Text;
                ent.Tarih = dateTimePicker1.Value;
                ent.Saat = comboBox_Saat.Text + ":" + comboBox_Dakika.Text;
                LogicHst.LLHstGuncelle(ent);

                List<EntityHst> PerList = LogicHst.LLHstList();
                dataGridView1.DataSource = PerList;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            EntityHst ent = new EntityHst();
            ent.Hstid = Convert.ToInt32(textBox1.Text);
            LogicHst.LLHstSil(ent.Hstid);

            List<EntityHst> PerList = LogicHst.LLHstList();
            dataGridView1.DataSource = PerList;
        }

        private void comboBox_Doktoradi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_TCKN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

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

        private void RandevuUpdate_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(listeleme);

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
    }
}
