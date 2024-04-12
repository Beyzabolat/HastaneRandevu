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

    }
}
