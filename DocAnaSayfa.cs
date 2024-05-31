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
namespace HastaneRandevu
{
    public partial class DocAnaSayfa : Form
    {
        public DocAnaSayfa()
        {
            InitializeComponent();
        }
        public string doktorad;
        public string doktorsoyad;

        private void btn_HstIslem_Click(object sender, EventArgs e)
        {
            HastaRapor hastaislem = new HastaRapor();   
            hastaislem.Show();                         

            hastaislem.doktorad = this.doktorad;       
            hastaislem.doktorsoyad = this.doktorsoyad;  
            this.Close();
        }

        private void txt_MainMenu_Click(object sender, EventArgs e)
        {
            Opening loginScreen = new Opening();       
            loginScreen.Show();                       
            this.Close();
        }

        private void btn_Grafik1_Click(object sender, EventArgs e)
        {
            Grafik1 grafik1 = new Grafik1();           
            grafik1.Show();                            
            this.Close();
        }

        private void DocAnaSayfa_Load(object sender, EventArgs e)
        {
            label2.Text = doktorad + " " + doktorsoyad;     

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
