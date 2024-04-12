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
    public partial class SecAnaSayfa : Form
    {
        public SecAnaSayfa()
        {
            InitializeComponent();
        }

        private void txt_MainMenu_Click(object sender, EventArgs e)
        {
            Opening loginScreen = new Opening();
            loginScreen.Show();
            this.Close();
        }

        private void btn_HstIslem_Click(object sender, EventArgs e)
        {
            RandevuUpdate hstislem = new RandevuUpdate();
            hstislem.Show();
            this.Close();
        }

        private void btn_RndEkle_Click(object sender, EventArgs e)
        {
            RandevuAlma rndal = new RandevuAlma();
            rndal.Show();
            this.Close();
        }

        private void btn_DocIslem_Click(object sender, EventArgs e)
        {
            DoktorIslemleri docislem = new DoktorIslemleri();
            docislem.Show();
            this.Close();
        }

        private void btn_SecIslem_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreter = new SekreterIslemleri();
            sekreter.Show();
            this.Close();
        }
    }
}
