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
using DataAccessLayer;
using LogicLayer;

namespace HastaneRandevu
{
    public partial class DoktorIslemleri : Form
    {
        public DoktorIslemleri()
        {
            InitializeComponent();
        }

        private void DoktorIslemleri_Load(object sender, EventArgs e)
        {
            List<string> bolumListesi = new List<string>();
            bolumListesi.Add("Kardiyoloji");
            bolumListesi.Add("Ortopedi");
            bolumListesi.Add("Dahiliye");
            comboBox_Bolum.DataSource = bolumListesi;
            dataGridView1.CellClick += new DataGridViewCellEventHandler(listeleme);
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            List<EntityDoc> docList = LogicDoc.LLDocList();
            dataGridView1.DataSource = docList;
        }
        private void comboBox_Bolum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void listeleme(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                txt_DoktorAdi.Text = selectedRow.Cells[1].Value.ToString();
                txt_DoktorSoyadi.Text = selectedRow.Cells[2].Value.ToString();
                comboBox_Bolum.Text = selectedRow.Cells[3].Value.ToString();
                txt_Telefon.Text = selectedRow.Cells[4].Value.ToString();
                txt_Username.Text = selectedRow.Cells[5].Value.ToString();
                txt_Password.Text = selectedRow.Cells[6].Value.ToString();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            EntityDoc ent = new EntityDoc();
            ent.Docname = txt_DoktorAdi.Text;
            ent.Docsurname = txt_DoktorSoyadi.Text;
            ent.Docbranch = comboBox_Bolum.Text;
            ent.Docphone = txt_Telefon.Text;
            ent.Docusername = txt_Username.Text;
            ent.Docpassword = txt_Password.Text;
            LogicDoc.LLDocEkle(ent);

            List<EntityDoc> docList = LogicDoc.LLDocList();
            dataGridView1.DataSource = docList;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_DoktorAdi.Text == "" || txt_DoktorSoyadi.Text == "" || txt_Telefon.Text == "" +
             "" || comboBox_Bolum.Text == "" || txt_Username.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Hiçbir Alan Boş Bırakılamaz", "!!!");
            }
            else
            {
                if (int.TryParse(textBox1.Text, out int docId))
                {
                    EntityDoc ent = new EntityDoc();
                    ent.Docid = docId;
                    ent.Docname = txt_DoktorAdi.Text;
                    ent.Docsurname = txt_DoktorSoyadi.Text;
                    ent.Docbranch = comboBox_Bolum.Text;
                    ent.Docphone = txt_Telefon.Text;
                    ent.Docusername = txt_Username.Text;
                    ent.Docpassword = txt_Password.Text;
                    LogicDoc.LLDocGuncelle(ent);

                    List<EntityDoc> docList = LogicDoc.LLDocList();
                    dataGridView1.DataSource = docList;
                }
                else
                {
                    MessageBox.Show("Geçersiz doktor ID değeri. Lütfen geçerli bir ID girin.", "Hata");
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int docId))
            {
                LogicDoc.LLDocSil(docId);

                List<EntityDoc> docList = LogicDoc.LLDocList();
                dataGridView1.DataSource = docList;
            }
            else
            {
                MessageBox.Show("Geçersiz doktor ID değeri. Lütfen geçerli bir ID girin.", "Hata");
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
    }
}
