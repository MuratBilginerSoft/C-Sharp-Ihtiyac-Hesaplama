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
    public class Controllers
    {
        #region Form Aç

        public void FormAç(Form Form1, Form Form2)
        {
            Form1.Hide();
            Form2.ShowDialog();
            Form1.Show();
        }

        #endregion


    }
}
