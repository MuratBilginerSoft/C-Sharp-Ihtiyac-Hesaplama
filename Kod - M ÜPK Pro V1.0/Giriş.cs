using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kod___M_ÜPK_Pro_V1._0
{
    public partial class Giriş : Form
    {
        #region Tanımlamalar

        Controllers BL = new Controllers();

        #endregion

        public Giriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            İhtiyaç_Hesapla İHForm = new İhtiyaç_Hesapla();
            BL.FormAç(this, İHForm);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
