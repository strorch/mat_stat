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
    public partial class TwoRergessions : Form
    {
        Form1 _f;

        public TwoRergessions(Form1 f)
        {
            InitializeComponent();
            this._f = f;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string RESULT = "Результат:\n";
            int num1 = 0;
            int num2 = 0;
            try
            {
                num1 = Convert.ToInt32(textBox1.Text);
                num2 = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Не введено дані!");
                return;
            }
            var First = _f.ReturnTuple(num1 - 1);
            var Second = _f.ReturnTuple(num2 - 1);
            int N1 = First.Item2, N2 = Second.Item2;
            double[] X1 = new double[N1];
            double[] Y1 = new double[N1];
            double[] X2 = new double[N2];
            double[] Y2 = new double[N2];
            for (int i = 0; i < N1; i++)
            {   
                X1[i] = First.Item1[i, 0];
                Y1[i] = First.Item1[i, 1];
            }
            for (int i = 0; i < N2; i++)
            {
                X2[i] = Second.Item1[i, 0];
                Y2[i] = Second.Item1[i, 1];
            }
            double s_zal1 = regression.SzalKvLinear(X1, Y1);
            double s_zal2 = regression.SzalKvLinear(X2, Y2);
            double F;
            double S2 = ((N1 - 2) * s_zal1 + (N2 - 2) * s_zal2) / (N1 + N2 - 4);

            if (s_zal1 >= s_zal2)
                F = s_zal1 / s_zal2;
            else
                F = s_zal2 / s_zal1;
            if (F <= Quantil.QuantilFishera(N1 - 2, N2 - 2))
            {
                RESULT += "\n1)Результат перевірка на збіг залишкових дисперсій позитивний.\n  Статистика F = " + Math.Round(F, 4).ToString() +
                    "\n  Зведена оцінка дисперсії залишків S2 = " + Math.Round(S2, 4).ToString() + "\n";
            }
            else
                RESULT += "\n1)Результат перевірка на збіг залишкових дисперсій негативний.\n  Статистика F = " + Math.Round(F, 4).ToString() + "\n";

            double T = T_stat(X1, Y1, X2, Y2, S2);
            if (Math.Abs(T) <= Quantil.StudentQuantil(X1))
            {
                double B_stat = this.B_stat(X1, Y1, X2, Y2);
                RESULT += "\n2)Результат перевірка на збіг коефіцієнта В позитивний.\n  Статистика Т = " + Math.Round(T, 4).ToString()
                    + "\n  Статистика B = " + B_stat.ToString() + "\n";
                double at_stat = (B_stat - Bnull_stat(X1, Y1, X2, Y2)) / Snull_stat(X1, Y1, X2, Y2, S2);
                if (Math.Abs(at_stat) <= Quantil.StudentQuantil(X1))
                    RESULT += "\n3)Результат перевірка на збіг коефіцієнта A позитивний, \nотже обидві регресійні прямі є ідентичними.\n  Статистика T = "
                        + Math.Round(at_stat, 4).ToString() + "\n";
                else
                    RESULT += "\n3)Результат перевірка на збіг коефіцієнта A негативний.\n  Статистика T = "
                        + Math.Round(at_stat, 4).ToString() + "\n";
            }
            else
                RESULT += "\n2)Результат перевірка на збіг коефіцієнта В негативний.\n  Статистика Т = " + Math.Round(T, 4).ToString() + "\n";
            label3.Text = RESULT;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string RESULT = "Результат:\n";
            int num1 = 0;
            int num2 = 0;
            try
            {
                num1 = Convert.ToInt32(textBox1.Text);
                num2 = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Не введено дані!");
                return;
            }
            var First = _f.ReturnTuple(num1 - 1);
            var Second = _f.ReturnTuple(num2 - 1);
            int N1 = First.Item2, N2 = Second.Item2;
            double[] X1 = new double[N1];
            double[] Y1 = new double[N1];
            double[] X2 = new double[N2];
            double[] Y2 = new double[N2];
            for (int i = 0; i < N1; i++)
            {
                X1[i] = First.Item1[i, 0];
                Y1[i] = First.Item1[i, 1];
            }
            for (int i = 0; i < N2; i++)
            {
                X2[i] = Second.Item1[i, 0];
                Y2[i] = Second.Item1[i, 1];
            }

            double t_stat = this.Bt_stat(X1, Y1, X2, Y2);
            if (Math.Abs(t_stat) <= Quantil.StudentQuantil1(this.StepinViln(X1, Y1, X2, Y2)))
                RESULT += "\n1)За наближеними формулами результат перевірки на збіг коефіцієнта В позитивний.\n  Статистика Т = " + Math.Round(t_stat, 4).ToString() + "\n";
            else
                RESULT += "\n1)За наближеними формулами результат перевірки на збіг коефіцієнта В негативний.\n  Статистика Т = " + Math.Round(t_stat, 4).ToString() + "\n";
            double u_stat = this.Ustatistic(X1, Y1, X2, Y2);
            if (Math.Abs(u_stat) <= Quantil.NormalQuantil())
                RESULT += "\n2)За наближеними формулами результат перевірки на збіг коефіцієнта A позитивний.\n  Статистика U = " + Math.Round(u_stat, 4).ToString() + "\n";
            else
                RESULT += "\n2)За наближеними формулами результат перевірки на збіг коефіцієнта A негативний.\n  Статистика U = " + Math.Round(u_stat, 4).ToString() + "\n";
            label3.Text = RESULT;
        }

        private double Ustatistic(double[] X1, double[] Y1, double[] X2, double[] Y2)
        {
            int N1 = X1.Length;
            int N2 = X2.Length;
            double sigX1 = korelation.dispersion(X1);
            double sigX2 = korelation.dispersion(X2);
            double B1 = this.B(X1, Y1);
            double B2 = this.B(X2, Y2);
            double serX1 = korelation.ser_ar(X1);
            double serX2 = korelation.ser_ar(X2);
            double serY1 = korelation.ser_ar(Y1);
            double serY2 = korelation.ser_ar(Y2);
            double s_zal1 = regression.SzalKvLinear(X1, Y1);
            double s_zal2 = regression.SzalKvLinear(X2, Y2);
            double S2 = ((N1 - 2) * s_zal1 + (N2 - 2) * s_zal2) / (N1 + N2 - 4);
            double B0 = (serY1 - serY2) / (serX1 - serX2);
            double B_stat = (B1 * N1 * sigX1 / s_zal1 + B2 * N2 * sigX2 / s_zal2) / (N1 * sigX1 / s_zal1 + N2 * sigX2 / s_zal2);
            double part1 = (N2 * s_zal1 + N1 * s_zal2) / (N1 * N2 * Math.Pow(serX1 - serX2, 2));
            double part2 = s_zal1 * s_zal2 / (N1 * sigX1 * s_zal2 + N2 * sigX2 * s_zal1);
            double S10 = part1 + part2;
            return (B_stat - B0) / S10;
        }

        private double StepinViln(double[] X1, double[] Y1, double[] X2, double[] Y2)
        {
            int N1 = X1.Length;
            int N2 = X2.Length;
            double sigX1 = korelation.dispersion(X1);
            double sigX2 = korelation.dispersion(X2);
            double B1 = this.B(X1, Y1);
            double B2 = this.B(X2, Y2);
            double s_zal1 = regression.SzalKvLinear(X1, Y1);
            double s_zal2 = regression.SzalKvLinear(X2, Y2);
            double S2 = ((N1 - 2) * s_zal1 + (N2 - 2) * s_zal2) / (N1 + N2 - 4);
            double C0 = (s_zal1 / (N1 * sigX1)) / (s_zal1 / (N1 * sigX1) + s_zal2 / (N2 * sigX2));
            return Math.Truncate(Math.Pow(C0 * C0 / (N1 - 2) + Math.Pow(1 - C0, 2) / (N2 - 2), -1));
        }

        private double Bt_stat(double[] X1, double[] Y1, double[] X2, double[] Y2)
        {
            int N1 = X1.Length;
            int N2 = X2.Length;
            double sigX1 = korelation.dispersion(X1);
            double sigX2 = korelation.dispersion(X2);
            double B1 = this.B(X1, Y1);
            double B2 = this.B(X2, Y2);
            double s_zal1 = regression.SzalKvLinear(X1, Y1);
            double s_zal2 = regression.SzalKvLinear(X2, Y2);
            double S2 = ((N1 - 2) * s_zal1 + (N2 - 2) * s_zal2) / (N1 + N2 - 4);
            double part = Math.Sqrt(S2 * (s_zal1 / (N1 * sigX1) + s_zal2 / (N2 * sigX2)));
            return (B1 - B2) / part;
        }

        private double Bnull_stat(double[] X1, double[] Y1, double[] X2, double[] Y2)
        {
            double serX1 = korelation.ser_ar(X1);
            double serX2 = korelation.ser_ar(X2);
            double serY1 = korelation.ser_ar(Y1);
            double serY2 = korelation.ser_ar(Y2);
            return (serY1 - serY2) / (serX1 - serX2);
        }

        private double Snull_stat(double[] X1, double[] Y1, double[] X2, double[] Y2, double S2)
        {
            int N1 = X1.Length;
            int N2 = X2.Length;
            double sigX1 = korelation.dispersion(X1);
            double sigX2 = korelation.dispersion(X2);
            double serX1 = korelation.ser_ar(X1);
            double serX2 = korelation.ser_ar(X2);
            double part1 = 1 / ((N1 - 1) * sigX1 + (N2 - 1) * sigX2);
            double part2 = (1 / N1 + 1 / N2) / Math.Pow(serX1 - serX2, 2);
            return S2 * (part1 + part2);
        }

        private double B_stat(double[] X1, double[] Y1, double[] X2, double[] Y2)
        {
            int N1 = X1.Length;
            int N2 = X2.Length;
            double sigX1 = korelation.dispersion(X1);
            double sigX2 = korelation.dispersion(X2);
            double B1 = this.B(X1, Y1);
            double B2 = this.B(X2, Y2);
            double part1 = (N1 - 1) * sigX1 * B1 + (N2 - 1) * sigX2 * B2;
            double part2 = (N1 - 1) * sigX1 + (N2 - 1) * sigX2;
            return part1 / part2;
        }

        private double T_stat(double[] X1, double[] Y1, double[] X2, double[] Y2, double S2)
        {
            int N1 = X1.Length;
            int N2 = X2.Length;
            double B1 = this.B(X1, Y1);
            double B2 = this.B(X2, Y2);
            double sigX1 = korelation.dispersion(X1);
            double sigX2 = korelation.dispersion(X2);
            return (B1 - B2) / Math.Sqrt(S2 * (1 / ((N1 - 1) * sigX1) + 1 / ((N2 - 1) * sigX2)));
        }

        private double B(double[] X, double[] Y)
        {
            double kor = korelation.koef_kor(X, Y);
            double sigX = Math.Sqrt(korelation.dispersion(X));
            double sigY = Math.Sqrt(korelation.dispersion(Y));
            return kor * sigY / sigX;
        }
    }
}
