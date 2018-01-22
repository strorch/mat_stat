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
    public partial class Transformation : Form
    {
        public double[] X, Y;
        public Transformation(double[] X, double[] Y)
        {
            InitializeComponent();
            this.X = X;
            this.Y = Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = X.Length;
            if (comboBox1.Text == "Логарифм за основою 'e'")
            {
                for (int i = 0; i < N; i++)
                {
                    if (X[i] <= 0 || Y[i] <= 0)
                    {
                        MessageBox.Show("Дані неможливо прологарифмувати!");
                        return;
                    }
                    X[i] = Math.Log(X[i]);
                    Y[i] = Math.Log(Y[i]);
                }
            }
            else if (comboBox1.Text == "Логарифм за основою '10'")
            {
                for (int i = 0; i < N; i++)
                {
                    if (X[i] <= 0 || Y[i] <= 0)
                    {
                        MessageBox.Show("Дані неможливо прологарифмувати!");
                        return;
                    }
                    X[i] = Math.Log10(X[i]);
                    Y[i] = Math.Log10(Y[i]);
                }
            }
            else if (comboBox1.Text == "Зсув")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Не введено значення!");
                    return;
                }
                double zsuv = Convert.ToDouble(textBox1.Text);
                for (int i = 0; i < N; i++)
                {
                    X[i] += zsuv;
                    Y[i] += zsuv;
                }
            }
            else if (comboBox1.Text == "Піднесення до степеня")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Не введено значення!");
                    return;
                }
                double zsuv = Convert.ToDouble(textBox1.Text);
                for (int i = 0; i < N; i++)
                {
                    X[i] += Math.Pow(X[i], zsuv);
                    Y[i] += Math.Pow(Y[i], zsuv);
                }
            }
            else
            {
                MessageBox.Show("Неправильно вибрано операцію!");
                return;
            }
        }
    }
}
