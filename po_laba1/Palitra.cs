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
    public partial class Palitra : Form
    {
        Color[] colors;
        public Palitra(Color[] colors, Tuple<double, double> znach)
        {
            InitializeComponent();
            double par = Math.Round(znach.Item1, 4);
            double step = Math.Round(znach.Item2, 4);
            this.colors = colors;
            label1.Text = par.ToString() + " - " + (par + step).ToString();
            panel1.BackColor = colors[0];
            par = par + step;
            label2.Text = par.ToString() + " - " + (par + step).ToString();
            panel2.BackColor = colors[1];
            par = par + step;
            label3.Text = par.ToString() + " - " + (par + step).ToString();
            panel3.BackColor = colors[2];    
            par = par + step;                
            label4.Text = par.ToString() + " - " + (par + step).ToString();
            panel4.BackColor = colors[3];    
            par = par + step;                
            label5.Text = par.ToString() + " - " + (par + step).ToString();
            panel5.BackColor = colors[4];    
            par = par + step;                
            label6.Text = par.ToString() + " - " + (par + step).ToString();
            panel6.BackColor = colors[5];    
            par = par + step;                
            label7.Text = par.ToString() + " - " + (par + step).ToString();
            panel7.BackColor = colors[6];
        }
    }
}
