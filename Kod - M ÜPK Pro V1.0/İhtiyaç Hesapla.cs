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
    public partial class İhtiyaç_Hesapla : Form
    {
        #region Tanımlamalar

        int[] A = new int[13];

        int[] B = new int[13];

        #endregion

        #region Değişkenler

        int a1, a2;

        double Sonuc1, Sonuc2, Sonuc3, Sonuc4, Sonuc5, Sonuc6;

        double Xi, Yi, XiYi, Xi2;

        double X1, X2;

        double SXY, SX2, Zet=0;

        int ÖH, Hafta, AH;

        int N1;

        #endregion

        #region Ana Form İşlemleri

        public İhtiyaç_Hesapla()
        {
            InitializeComponent();
        }

        #endregion

        #region Yöntem Seçme

        private void RadioBasit_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioBasit.Checked==true)
            {
                GroupBoxBasit.Enabled = true;
                GroupLineer.Enabled = false;
                GroubAğırlıklı.Enabled = false;
            }
        }

        private void RadioLineer_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioLineer.Checked==true)
            {
                GroupBoxBasit.Enabled = false;
                GroupLineer.Enabled = true;
                GroubAğırlıklı.Enabled = false;
            }
        }

        private void RadioAğırlıklı_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioAğırlıklı.Checked==true)
            {
                GroupBoxBasit.Enabled = false;
                GroupLineer.Enabled = false;
                GroubAğırlıklı.Enabled = true;
            }
        }

        #endregion

        #region RadioButon İşlemleri

        private void RadioÖHDDA_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioÖHDDA.Checked==true)
            {
                NUD1.Enabled = true;
                NUD2.Enabled = true;
            }
        }

        private void RadioÖHDDM_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioÖHDDM.Checked==true)
            {
                NUD1.Enabled = false;
                NUD2.Enabled = true;
            }
        }

        #endregion

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            a1 = 12;
            a2 = 12;

            foreach (Control nesne in PanelVeri1.Controls)
            {
                A[a1] = int.Parse(nesne.Text);
                a1--;
            }

            foreach (Control nesne in PanelVeri2.Controls)
            {
                B[a2] = int.Parse(nesne.Text);
                a2--;
            }

            LblDurum.Text = "Veriler Aktarıldı...";
            PanelDurum.BackColor = Color.Red;
            PicVeriAktar.BackColor = Color.White;
            GroupSeçim.Enabled = true;
            LblDurum.Left = (PanelDurum.ClientSize.Width - LblDurum.Size.Width) / 2;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            #region Basit Ortalama Yöntemi

            if (RadioBasit.Checked==true)
            {
                Sonuc1 = 0; Sonuc2 = 0;

                Hafta = Convert.ToInt32(NUD2.Value);

                if (RadioÖHDDA.Checked==true)
                {
                    ÖH = Convert.ToInt32(NUD1.Value);

                    for (int i1 = 0; i1 < Hafta; i1++)
                    {
                        Sonuc1 += A[i1];
                        Sonuc2 += B[i1];
                    }

                    TextA1.Text = (Sonuc1 / ((ÖH+Hafta) - 1)).ToString("F") + " Adet".ToString();
                    TextB1.Text = (Sonuc2 / ((ÖH+Hafta) - 1)).ToString("F") + " Adet".ToString();
                }

                else
                {
                    for (int i1 = 1; i1 < Hafta; i1++)
                    {
                        Sonuc1 += A[i1];
                        Sonuc2 += B[i1];
                    }

                    TextA1.Text = (Sonuc1 / (Hafta - 1)).ToString("F") + " Adet".ToString();
                    TextB1.Text = (Sonuc2 / (Hafta - 1)).ToString("F") + " Adet".ToString();
                }

                LblDurum.Text = "Basit Ortalama Yöntemi İle Sonuç Hesaplandı";
                PanelDurum.BackColor = Color.Blue;
            }

            #endregion

            #region Ağırlıklı Değişken Ortalama Değer Yöntemi

            else if (RadioAğırlıklı.Checked==true)
            {
                Sonuc3 = 0; Sonuc4 = 0;

                AH=Convert.ToInt32(NUD3.Value);
                Hafta = Convert.ToInt32(NUD4.Value);

                for (int i2 = Hafta-1; i2 >= Hafta-AH; i2--)
                {
                    Sonuc3 += A[i2];
                    Sonuc4 += B[i2];
                }

                TextA2.Text = (Sonuc3 / AH).ToString("F") + " Adet";
                TextB2.Text = (Sonuc4 / AH).ToString("F") + " Adet";

                LblDurum.Text = "Ağırlıklı Değişken Ortalama Değer Yöntemi İle Sonuç Hesaplandı";
                PanelDurum.BackColor = Color.SlateBlue;
            }

            #endregion

            #region Lineer Regresyon Yöntemi İle Hesaplama

            else
            {
                Hafta = Convert.ToInt32(NUD5.Value);
                Sonuc5 = 0;
                Sonuc6 = 0;

                Yi = 0;
                Xi = 0;
                XiYi = 0;
                Xi2 = 0;
                N1 = Hafta - 1;

                if (ComboÜrün.Text == "A Ürünü")
                {
                    if (ComboTrend.Text=="Trend Yok")
                    {
                        for (int i = 1; i < Hafta; i++)
                        {
                            Sonuc5 += A[i];
                        }

                        Sonuc6 = Sonuc5 / N1;

                        TextA3.Text = Sonuc6 + " Adet";
                    }

                    else if (ComboTrend.Text == "Trend Var")
                    {
                        for (int i = 1; i < Hafta; i++)
                        {
                            Yi += A[i];
                            Xi += i;
                            XiYi += (i * A[i]);
                            Xi2 += i * i;
                        }

                        
                        X2 = Xi * Yi;

                        SXY = XiYi - (X2/N1);
                        SX2 = Xi2 - (Math.Pow(Xi, 2)/N1);

                        Zet = SXY / SX2;

                        Sonuc5 = (Yi - Zet * Xi)/N1;
                        Sonuc6 = (Zet * Hafta) + Sonuc5;

                        TextA3.Text = Sonuc6 + " Adet";

                    }
                }


                else if (ComboÜrün.Text == "B Ürünü")
                {
                     if (ComboTrend.Text=="Trend Yok")
                    {
                        for (int i = 1; i < Hafta; i++)
                        {
                            Sonuc5 += B[i];
                        }

                        Sonuc6 = Sonuc5 / N1;

                        TextB3.Text = Sonuc6 + " Adet";
                    }

                    else if (ComboTrend.Text == "Trend Var")
                    {
                        for (int i = 1; i < Hafta; i++)
                        {
                            Yi += B[i];
                            Xi += i;
                            XiYi += (i * B[i]);
                            Xi2 += i * i;
                        }

                        
                        X2 = Xi * Yi;

                        SXY = XiYi - (X2/N1);
                        SX2 = Xi2 - (Math.Pow(Xi, 2)/N1);

                        Zet = SXY / SX2;

                        Sonuc5 = (Yi - Zet * Xi)/N1;
                        Sonuc6 = (Zet * Hafta) + Sonuc5;

                        TextB3.Text = Sonuc6 + " Adet";

                    }
                }

                LblDurum.Text = "Lineer Regresyon Yöntemi İle Sonuç Hesaplandı";
                PanelDurum.BackColor = Color.SlateGray;
            }
            
            #endregion

            LblDurum.Left = (PanelDurum.ClientSize.Width - LblDurum.Size.Width) / 2;
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
