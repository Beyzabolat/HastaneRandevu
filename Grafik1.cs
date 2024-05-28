using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

            // Chart kontrolünü formunuza eklediğinizi varsayıyoruz
            // Eğer henüz eklemediyseniz, Visual Studio Toolbox'tan sürükleyip bırakabilirsiniz
            chart1.Series.Clear();  // Önceki serileri temizler

            Series series = new Series
            {
                Name = "Hasta Sayısı",
                Color = Color.Blue,
                ChartType = SeriesChartType.Column
            };

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            for (int a = 0; a < lenght; a++)
            {
                OleDbCommand b = LogicLayer.LogicDoc.LLBolumHastaSayisiCek(bolumler[a]);
                Int32 sayi = (Int32)b.ExecuteScalar();
                series.Points.AddXY(bolumler[a], sayi);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
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
    }
}
