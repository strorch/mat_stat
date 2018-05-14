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
    public partial class Modelation : Form
    {
        double[] X;
        double[] Y;
        public Modelation(double[] X, double[] Y)
        {
            InitializeComponent();
            this.X = X;
            this.Y = Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Xmin = 0;
            double Xmax = 0;
            int N = 0;
            double A = 0;
            double B = 0;
            double sigm = 0;
            double C = 0;
            string nameF = "";
            try
            {
                Xmin = Convert.ToDouble(textBox1.Text);
                Xmax = Convert.ToDouble(textBox2.Text);
                N = Convert.ToInt32(textBox3.Text);
                A = Convert.ToDouble(textBox4.Text);
                B = Convert.ToDouble(textBox5.Text);
                sigm = Convert.ToDouble(textBox7.Text);
                nameF = textBox8.Text;
            }
            catch
            {
                MessageBox.Show("Не введено дані!");
                return;
            }
            if (comboBox1.Text == "Лінійна")
            {
                TwoDimModel.ModelLinear(Xmin, Xmax, N, A, B, sigm, nameF);
            }
            else if (comboBox1.Text == "Параболічна")
            {
                if (textBox6.Text == "")
                {
                    MessageBox.Show("Не введено дані!");
                    return;
                }
                C = Convert.ToDouble(textBox6.Text);
                TwoDimModel.ModelParabolic(Xmin, Xmax, N, A, B, C, sigm, nameF);
            }
            else if (comboBox1.Text == "Квазілінійна")
            {
                TwoDimModel.ModelKvaziLinear(Xmin, Xmax, N, A, B, sigm, nameF);
            }
            else
            {
                MessageBox.Show("Неправильно вибрано параметри!");
                return;
            }
        }
    }
}
