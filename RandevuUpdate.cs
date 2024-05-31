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
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            txt_HastaAdi.Text = selectedRow.Cells[1].Value.ToString();
            txt_HastaSoyadi.Text = selectedRow.Cells[2].Value.ToString();
            txt_TCKN.Text = selectedRow.Cells[3].Value.ToString();
            txt_Telefon.Text = selectedRow.Cells[4].Value.ToString();
            comboBox_Bolum.Text = selectedRow.Cells[5].Value.ToString();
            comboBox_Doktoradi.Text = selectedRow.Cells[6].Value.ToString();

            DateTime tarihValue;
            if (DateTime.TryParse(selectedRow.Cells[7].Value.ToString(), out tarihValue))
            {
                if (tarihValue < dateTimePicker1.MinDate)
                {
                    dateTimePicker1.Value = dateTimePicker1.MinDate;
                }
                else if (tarihValue > dateTimePicker1.MaxDate)
                {
                    dateTimePicker1.Value = dateTimePicker1.MaxDate;
                }
                else
                {
                    dateTimePicker1.Value = tarihValue;
                }
            }
            else
            {
                dateTimePicker1.Value = dateTimePicker1.MinDate;
            }

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
           
            comboBox_Doktoradi.Items.Clear();

           
            string selectedBolum = comboBox_Bolum.SelectedItem.ToString();

           
            OleDbDataReader dr = LogicHst.LLFilter(selectedBolum);

            while (dr.Read())
            {
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }

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

            // MinDate ve MaxDate ayarlarını yapalım
            dateTimePicker1.MinDate = DateTime.Today; // Bugünkü tarihi minimum tarih olarak ayarla
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(10); // Örnek: Şu andan itibaren 10 yıl sonrası

            List<string> bolumListesi = new List<string>
    {
        "Kardiyoloji", "Ortopedi", "Dahiliye", "Genel Cerrahi", "Psikiyatri",
        "Kulak-Burun-Boğaz", "Kadın Hastalıkları", "Kadın Doğum", "Üroloji",
        "Çocuk Hastalıkları", "Aile Hekimi"
    };
            comboBox_Bolum.DataSource = bolumListesi;

            OleDbDataReader dr = LogicHst.LLFilter(comboBox_Bolum.Text);
            while (dr.Read())
            {
                comboBox_Doktoradi.Items.Add(dr["DocAD"] + " " + dr["DocSOYAD"]);
            }
            dr.Close();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            textBox1.Text = "";
            txt_HastaAdi.Text = "";
            txt_HastaSoyadi.Text = "";
            txt_TCKN.Text = "";
            txt_Telefon.Text = "";
            comboBox_Bolum.SelectedIndex = -1;
            comboBox_Doktoradi.SelectedIndex = -1;
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            comboBox_Saat.SelectedIndex = 0;
            comboBox_Dakika.SelectedIndex = 0;
        }
    }
}
