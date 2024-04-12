using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevu
{
    public partial class Grafik1 : Form
    {
        public Grafik1()
        {
            InitializeComponent();
        }

        private void Grafik1_Load(object sender, EventArgs e)
        {
            string[] bolumler = { "Dahiliye", "Kulak-Burun-Boğaz", "Psikiyatri", "Üroloji", "Genel Cerrahi", "Kardiyoloji" };
            int lenght = bolumler.Length;

            for (int a = 0; a < lenght; a++)
            {
                OleDbCommand b = LogicLayer.LogicDoc.LLBolumHastaSayisiCek(bolumler[a]);
                Int32 sayi = (Int32)b.ExecuteScalar();
                chart1.Series[bolumler[a]].Points.AddXY(a + 1, sayi);
            }
        }
    }
}
