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
        double a, b, c;
        double DispA, DispB, DispC;
        public RegrValid(double a, double b, double c, double DispA, double DispB, double DispC)
        {
            InitializeComponent();
            this.a = a;
            this.b = b;
            this.c = c;
            this.DispA = DispA;
            this.DispB = DispB;
            this.DispC = DispC;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Не введено значення параметра!");
                return;
            }
            double parametr = 0;
            if (comboBox1.Text == "a")
                parametr = this.a;
            else if (comboBox1.Text == "b")
                parametr = this.b;
            else if (comboBox1.Text == "c")
                parametr = this.c;
            else
            {
                MessageBox.Show("Неправильно вибрано параметри!");
                return;
            }
        }
    }
}
