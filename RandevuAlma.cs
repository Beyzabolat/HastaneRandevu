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
                EntityHst ent = new EntityHst();                               
                ent.Hstname = txt_HastaAdi.Text;                              
                ent.Hstsurname = txt_HastaSoyadi.Text;                        
                ent.Hsttckn = txt_TCKN.Text;                                    
                ent.Hstphone = txt_Telefon.Text;                              
                ent.Hstbolum = comboBox_Bolum.Text;                            
                ent.Docname = comboBox_Doktoradi.Text;
                ent.Tarih = dateTimePicker1.Value;
                ent.Saat = comboBox_Saat.Text + ":" + comboBox_Dakika.Text;
                ent.Rapor = " ";
                LogicHst.LLHstEkle(ent);

                MessageBox.Show("Randevu başarıyla kaydedilmiştir.");
               
            }
        }
        private void ClearFields()
        {
            txt_HastaAdi.Clear();
            txt_HastaSoyadi.Clear();
            txt_TCKN.Clear();
            txt_Telefon.Clear();
            comboBox_Bolum.SelectedIndex = -1;
            comboBox_Doktoradi.Items.Clear();
            comboBox_Saat.SelectedIndex = 0;
            comboBox_Dakika.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
        }
        private void RandevuAlma_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 23; i++)
            {
                comboBox_Saat.Items.Add(i.ToString("00"));
            }

            for (int i = 0; i <= 59; i++)
            {
                comboBox_Dakika.Items.Add(i.ToString("00"));
            }

            comboBox_Saat.SelectedIndex = 0;
            comboBox_Dakika.SelectedIndex = 0;

            List<string> bolumListesi = new List<string>();
            bolumListesi.Add("Kardiyoloji");
            bolumListesi.Add("Ortopedi");
            bolumListesi.Add("Dahiliye");
            bolumListesi.Add("Genel Cerrahi");
            bolumListesi.Add("Psikiyatri");
            bolumListesi.Add("Kulak-Burun-Boğaz");
            bolumListesi.Add("Kadın Hastalıkları");
            bolumListesi.Add("Kadın Doğum");
            bolumListesi.Add("Üroloji");
            bolumListesi.Add("Dahiliye");
            bolumListesi.Add("Çocuk Hastalıkları");
            bolumListesi.Add("Aile Hekimi");

            comboBox_Bolum.DataSource = bolumListesi;

            // MinDate ayarını yapalım
            dateTimePicker1.MinDate = DateTime.Today; // Bugünkü tarihi minimum tarih olarak ayarla

            OleDbDataReader dr = LogicHst.LLFilter(comboBox_Bolum.Text);
            while (dr.Read())
            {
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }
            dr.Close();
        }

        private void comboBox_Bolum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Doktoradi.Items.Clear();
            OleDbDataReader dr = LogicHst.LLFilter(comboBox_Bolum.Text);             
            while (dr.Read())                                                      
            {                                                                      
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }
            dr.Close();
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
                MessageBox.Show("Hafta sonları seçilemez!");               
                dateTimePicker1.Value = DateTime.Now.AddDays(2);         
            }
        }

        private void comboBox_Bolum_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            comboBox_Doktoradi.Items.Clear();

            
            string selectedBolum = comboBox_Bolum.SelectedItem.ToString();

          
            OleDbDataReader dr = LogicHst.LLFilter(selectedBolum);

          
            while (dr.Read())
            {
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }

            dr.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
