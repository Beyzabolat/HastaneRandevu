using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevu
{
    public partial class SekreterIslemleri : Form
    {
        public SekreterIslemleri()
        {
            InitializeComponent();
        }

        private void btn_List_Click(object sender, EventArgs e)
        {
            List<EntitySec> PerList = LogicSec.LLSecList();
            dataGridView1.DataSource = PerList;
        }

        private void txtMainMenu_Click(object sender, EventArgs e)
        {
            SecAnaSayfa secAnaSayfa = new SecAnaSayfa();
            secAnaSayfa.Show();
            this.Hide();
        }
        private void listeleme(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];           
            textBox1.Text = selectedRow.Cells[0].Value.ToString();             
            txt_SekreterAdi.Text = selectedRow.Cells[1].Value.ToString();       
            txt_SekreterSoyadi.Text = selectedRow.Cells[2].Value.ToString();   
            txt_Telefon.Text = selectedRow.Cells[3].Value.ToString();
            txt_Username.Text = selectedRow.Cells[4].Value.ToString();
            txt_Password.Text = selectedRow.Cells[5].Value.ToString();
        }
        private void SekreterEkle_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;                     
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            EntitySec ent = new EntitySec();
            ent.Secname = txt_SekreterAdi.Text;
            ent.Secsurname = txt_SekreterSoyadi.Text;
            ent.Secphone = txt_Telefon.Text;
            ent.Secusername = txt_Username.Text;
            ent.Secpassword = txt_Password.Text;
            LogicSec.LLSecEkle(ent);

            List<EntitySec> PerList = LogicSec.LLSecList();
            dataGridView1.DataSource = PerList;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_SekreterAdi.Text == "" || txt_SekreterSoyadi.Text == "" || txt_Telefon.Text == "" +
               "" || txt_Username.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Hiçbir Alan Boş Bırakılamaz", "!!!");     
            }                                                               
            else                                                           
            {                                                               
                EntitySec ent = new EntitySec();                           
                ent.Secid = Convert.ToInt32(textBox1.Text);                 
                ent.Secname = txt_SekreterAdi.Text;                        
                ent.Secsurname = txt_SekreterSoyadi.Text;                   
                ent.Secphone = txt_Telefon.Text;                        
                ent.Secusername = txt_Username.Text;                       
                ent.Secpassword = txt_Password.Text;                        
                LogicSec.LLSecGuncelle(ent);                                
                                                                           
                List<EntitySec> PerList = LogicSec.LLSecList();           
                dataGridView1.DataSource = PerList;                         
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            EntitySec ent = new EntitySec();
            ent.Secid = Convert.ToInt32(textBox1.Text);
            LogicSec.LLSecSil(ent.Secid);

            List<EntitySec> PerList = LogicSec.LLSecList();
            dataGridView1.DataSource = PerList;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SekreterIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(listeleme);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            textBox1.Text = "";
            txt_SekreterAdi.Text = "";
            txt_SekreterSoyadi.Text = "";
           
            txt_Telefon.Text = "";
            txt_Username.Text = "";
            txt_Password.Text = "";
        }
    }
}
