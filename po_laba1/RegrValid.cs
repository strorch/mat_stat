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
            comboBox1.Items.Add("Регресія");
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            kvazilinear = true;
            comboBox1.Items.Add("a");
            comboBox1.Items.Add("b");
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
                int N = X.Length;
                double serX = korelation.ser_ar(X);
                double serY = korelation.ser_ar(Y);
                double sigmaX = Math.Sqrt(korelation.dispersion(X));
                double sigmaY = Math.Sqrt(korelation.dispersion(Y));
                double koefkor = korelation.koef_kor(X, Y);
                double SOME = 0;
                for (int i = 0; i < N; i++)
                    SOME += Math.Pow(regression.fi2(X, i), 2);
                SOME = SOME / N;
                double S_zal_kv = Math.Sqrt(regression.SzalKvParabolic(X, Y));
                var Params = regression.Params(X, Y);
                double BigPart1 = 0, BigPart2 = 0;
                double part2 = 0;
                double part3 = 0;
                double part4 = 0;
                for (int i = 0; i < N; i++)
                {
                    part2 += Math.Pow(X[i], 2);
                    part3 += Math.Pow(X[i], 3);
                    part4 += Math.Pow(X[i], 4);
                }
                double SomeKek = 0;
                for (int i = 0; i < N; i++)
                    SomeKek += (X[i] * X[i] - part2) * (Y[i] - serY);
                SomeKek = SomeKek / N;
                BigPart1 = (part4 - part2 * part2) * koefkor * sigmaX * sigmaY - (part3 - part2 * serX) * SomeKek;
                BigPart2 = sigmaX * sigmaX * (part4 - part2 * part2) - Math.Pow(part3 - part2 * serX, 2);
                double B = BigPart1 / BigPart2;
                BigPart1 = sigmaX * sigmaX * SomeKek - (part3 - part2 * serX) * koefkor * sigmaX * sigmaY;
                BigPart2 = sigmaX * sigmaX * (part4 - part2 * part2) - Math.Pow(part3 - part2 * serX, 2);
                double C = BigPart1 / BigPart2;
                double A = serY - B * serX - C * part2;
                if (comboBox1.Text == "a")
                {
                    double stat = (Params.Item1 - parametr) * Math.Sqrt(N) / S_zal_kv;
                    if (Math.Abs(stat) <= Quantil.StudentQuantil1(N - 3))
                    {
                        RESULT += "\nПараметр А значущий.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    else
                    {
                        RESULT += "\nПараметр А не значущий.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    parabolic = false;
                }
                else if (comboBox1.Text == "b")
                {
                    double stat = (Params.Item2 - parametr) * sigmaX * Math.Sqrt(N) / S_zal_kv;
                    if (Math.Abs(stat) <= Quantil.StudentQuantil1(N - 3))
                    {
                        RESULT += "\nПараметр B значущий.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    else
                    {
                        RESULT += "\nПараметр B не значущий.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    parabolic = false;
                }
                else if (comboBox1.Text == "c")
                {
                    double stat = (Params.Item3 - parametr) * Math.Sqrt(N * SOME) / S_zal_kv;
                    if (Math.Abs(stat) <= Quantil.StudentQuantil1(N - 3))
                    {
                        RESULT += "\nПараметр C значущий.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    else
                    {
                        RESULT += "\nПараметр C не значущий.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    parabolic = false;
                }
                else if (comboBox1.Text == "Регресія")
                {
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Не введено значення!");
                        return;
                    }
                    int x = Convert.ToInt32(textBox2.Text) - 1;
                    double inter_disp = (S_zal_kv / Math.Sqrt(N)) * Math.Sqrt(1 + Math.Pow(regression.fi1(X, x) / sigmaX, 2) + Math.Pow(regression.fi2(X, x), 2) / SOME);
                    double stat = ((A + B * X[x] + C * X[x] * X[x]) - Y[x]) / inter_disp;
                    if (Math.Abs(stat) >= Quantil.StudentQuantil1(N - 3))
                    {
                        RESULT += "\nРегресія в точці Х = " + X[x].ToString() + " значущa.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    else
                    {
                        RESULT += "\nРегресія в точці Х = " + X[x].ToString() + " не значущa.\n  Статистика Т = " + Math.Round(stat, 4).ToString() + "\n";
                    }
                    parabolic = false;
                }
                else
                {
                    MessageBox.Show("Неправильно вибрано параметри!");
                    parabolic = false;
                }
            }
            else if (kvazilinear == true)
            { 
                parametr = Convert.ToDouble(textBox1.Text);
                int N = X.Length;
                double[] NewX = new double[N];
                double[] NewY = new double[N];
                Array.Copy(X, NewX, N);
                Array.Copy(Y, NewY, N);
                for (int i = 0; i < N; i++)
                {
                    if (NewX[i] <= 0 || NewY[i] <= 0)
                    {
                        MessageBox.Show("Неможливо порахувати логарифм!");
                        return;
                    }
                    NewX[i] = 1 / NewX[i];
                    NewY[i] = Math.Log(NewY[i]);
                }
                double x_ser = korelation.ser_ar(NewX);
                double y_ser = korelation.ser_ar(NewY);
                double sigX = Math.Sqrt(korelation.dispersion(NewX));
                double sigY = Math.Sqrt(korelation.dispersion(NewY));
                double kor = korelation.koef_kor(NewX, NewY);
                double b = kor * sigY / sigX;
                double a = y_ser - b * x_ser;
                double S_zal_kv = regression.SzalKvLinear(NewX, NewY);
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
            else
            {
                MessageBox.Show("Неправильно вибрано параметри!");
                return;
            }
            label3.Text = RESULT;
        }
    }
}
