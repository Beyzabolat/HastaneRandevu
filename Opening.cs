﻿using System;
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
    public partial class Opening : Form
    {
        public Opening()
        {
            InitializeComponent();
        }

        private void btn_SecLogin_Click(object sender, EventArgs e)
        {
            SecLogin loginScreen = new SecLogin();
            loginScreen.Show();
            this.Hide();
        }

        private void btn_doktor_Click(object sender, EventArgs e)
        {
            DocLogin loginScreen = new DocLogin();
            loginScreen.Show();
            this.Hide();

        }
        private void btn_DocLogin_Click(object sender, EventArgs e)
        {
            DocLogin loginScreen = new DocLogin();
            loginScreen.Show();
            this.Hide();
        }
    }
}
