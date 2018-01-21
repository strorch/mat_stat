using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace po_laba1
{
    public partial class RegrValid : Form
    {
        double[] X;
        double[] Y;
        public RegrValid(double[] X, double[] Y)
        {
            InitializeComponent();
            this.X = X;
            this.Y = Y;
        }

        #region radio click
        bool linear = false;
        bool parabolic = false;
        bool kvazilinear = false; 
        private void radioButton1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            linear = true;
            comboBox1.Items.Add("a");
            comboBox1.Items.Add("b");
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            parabolic = true;
            comboBox1.Items.Add("a");
            comboBox1.Items.Add("b");
            comboBox1.Items.Add("c");
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            kvazilinear = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не введено значення параметра!");
                return;
            }
            double parametr = 0;
            string RESULT = "Розв'язання:\n";
            if (linear == true)
            {
                parametr = Convert.ToDouble(textBox1.Text);
                int N = X.Length;
                double x_ser = korelation.ser_ar(X);
                double y_ser = korelation.ser_ar(Y);
                double sigX = Math.Sqrt(korelation.dispersion(X));
                double sigY = Math.Sqrt(korelation.dispersion(Y));
                double kor = korelation.koef_kor(X, Y);
                double b = kor * sigY / sigX;
                double a = y_ser - b * x_ser;
                double S_zal_kv = regression.SzalKvLinear(X, Y);
                double disp_a = Math.Sqrt(S_zal_kv * (1 / N + x_ser * x_ser / (sigX * sigX * (N - 1))));
                double disp_b = Math.Sqrt(S_zal_kv) / (sigX * Math.Sqrt(N - 1));
                if (comboBox1.Text == "a")
                {
                    double Tstat = (a - parametr) / disp_a;
                    if (Math.Abs(Tstat) < Quantil.StudentQuantil1(N - 2))
                        RESULT += "\nПараметр А значущий.\n  Статистика Т = " + Math.Round(Tstat, 4).ToString() + "\n";
                    else
                        RESULT += "\nПараметр А не значущий.\n  Статистика Т = " + Math.Round(Tstat, 4).ToString() + "\n";
                    linear = false;
                }
                else if (comboBox1.Text == "b")
                {
                    double Tstat = (b - parametr) / disp_b;
                    if (Math.Abs(Tstat) < Quantil.StudentQuantil1(N - 2))
                        RESULT += "\nПараметр B значущий.\n  Статистика Т = " + Math.Round(Tstat, 4).ToString() + "\n";
                    else
                        RESULT += "\nПараметр B не значущий.\n  Статистика Т = " + Math.Round(Tstat, 4).ToString() + "\n";
                    linear = false;
                }
                else
                {
                    MessageBox.Show("Неправильно вибрано параметри!");
                    linear = false;
                }
            }
            else if (parabolic == true)
            {
                parametr = Convert.ToDouble(textBox1.Text);
                if (comboBox1.Text == "a")
                {

                }
                else if (comboBox1.Text == "b")
                {

                }
                else if (comboBox1.Text == "c")
                {

                }
                else
                {
                    MessageBox.Show("Неправильно вибрано параметри!");
                }
            }
            else if (kvazilinear == true)
            { 
                parametr = Convert.ToDouble(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Неправильно вибрано параметри!");
                return;
            }
            label3.Text = RESULT;
        }
    }
}
