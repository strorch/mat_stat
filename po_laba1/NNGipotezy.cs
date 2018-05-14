using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleMatrix;
using Algebra;

namespace po_laba1
{
    public partial class NNGipotezy : Form
    {
        List<NNData> list;

        public NNGipotezy(List<NNData> list)
        {
            InitializeComponent();
            this.list = list;

            for (int r = 0; r < list.Count(); r++)
            {
                domainUpDown1.Items.Add(list[r].file_name);
                domainUpDown2.Items.Add(list[r].file_name);
            }
        }

        private NNData ReturnByName(string name)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].file_name == name)
                    return list[i];
            }
            return null;
        }

        private void button29_Click(object sender, EventArgs e)
        {/*
            if (domainUpDown1.Text == "" || domainUpDown2.Text == ""
                || comboBox1.Text == "" || domainUpDown1.Text == domainUpDown2.Text
                || ReturnByName(domainUpDown1.Text) == null
                || ReturnByName(domainUpDown2.Text) == null)
            {
                MessageBox.Show("No parameters!");
                return;
            }*/

            string RESULT = "";

            if (comboBox1.Text == "Багатовимірні середнi (рівні DC)")
            {
                NNData first = ReturnByName(domainUpDown1.Text);
                NNData second = ReturnByName(domainUpDown2.Text);

                if (first.Num != second.Num)
                {
                    MessageBox.Show("not equal");
                    return;
                }
                double Vstat = Help.VStatistic(first, second);
                if (Vstat <= Quantil.XIquantil(first.Num))
                {
                    RESULT += "+" + Vstat.ToString() + "\n";
                }
                else
                {
                    RESULT += "-" + Vstat.ToString() + "\n";
                }
                label30.Text = RESULT;
            }
            else if (comboBox1.Text == "k n-вимірних середніх (розбіжні DC)")
            {
                double Vstat = Help.VStatistic(list);
                if (Vstat <= Quantil.XIquantil(list[0].Num))
                {
                    RESULT += "+" + Vstat.ToString() + "\n";
                }
                else
                {
                    RESULT += "-" + Vstat.ToString() + "\n";
                }
                label30.Text = RESULT;
            }
            else if (comboBox1.Text == "збіг DC")
            {
                double Vstat = Help.V2Statistic(list);
                if (Vstat <= Quantil.XIquantil(list[0].Num))
                {
                    RESULT += "+" + Vstat.ToString() + "\n";
                }
                else
                {
                    RESULT += "-" + Vstat.ToString() + "\n";
                }
                label30.Text = RESULT;
            }
            else
            {
                MessageBox.Show("kek");
                return;
            }
        }
    }

    public static class Help
    {
        public static double VStatistic(NNData d1, NNData d2)
        {
            Matrix m0 = Matrix.Create.New(s0(d1, d2));
            Matrix m1 = Matrix.Create.New(s1(d1, d2));

            return -1d * (d1.Length + d2.Length - 2 - d1.Num / 2d) * Math.Log(m1.Determinant() / m0.Determinant());
        }

        private static double[,] s0(NNData d1, NNData d2)
        {
            double[,] ret = new double[d1.Num, d2.Num];
            for (int i = 0; i < ret.GetLength(0); i++)
            {
                for (int j = 0; j < ret.GetLength(1); j++)
                {
                    ret[i, j] = s0_ij(NNData.PartArr(d1.ARR, d1.Length, i), NNData.PartArr(d1.ARR, d1.Length, j), NNData.PartArr(d2.ARR, d2.Length, i), NNData.PartArr(d2.ARR, d2.Length, j));
                }
            }

            return ret;
        }

        private static double[,] s1(NNData d1, NNData d2)
        {
            double[,] ret = new double[d1.Num, d2.Num];

            for (int i = 0; i < ret.GetLength(0); i++)
            {
                for (int j = 0; j < ret.GetLength(1); j++)
                {
                    ret[i, j] = s1_ij(NNData.PartArr(d1.ARR, d1.Length, i), NNData.PartArr(d1.ARR, d1.Length, j), NNData.PartArr(d2.ARR, d2.Length, i), NNData.PartArr(d2.ARR, d2.Length, j));
                }
            }

            return ret;
        }

        private static double s0_ij(double[] xi, double[] xj, double[] yi, double[] yj)
        {
            double sumxij = 0, sumyij = 0;
            int n1 = xi.Length, n2 = yi.Length;

            for (int i = 0; i < n1; i++)
            {
                sumxij += xi[i] * xj[i];
            }
            for (int i = 0; i < n2; i++)
            {
                sumyij += yi[i] * yj[i];
            }

            return (sumxij + sumyij - (xi.Sum() + yi.Sum()) * (xj.Sum() + yj.Sum()) / (n1 + n2)) / (n1 + n2 - 2);
        }

        private static double s1_ij(double[] xi, double[] xj, double[] yi, double[] yj)
        {
            double sumxij = 0, sumyij = 0;
            int n1 = xi.Length, n2 = yi.Length;

            for (int i = 0; i < n1; i++)
            {
                sumxij += xi[i] * xj[i];
            }
            for (int i = 0; i < n2; i++)
            {
                sumyij += yi[i] * yj[i];
            }

            return (sumxij + sumyij - (xi.Sum() * xj.Sum()) / n1 - (yi.Sum() * yj.Sum()) / n2) / (n1 + n2 - 2);
        }

        public static double VStatistic(List<NNData> dt)
        {
            double res = 0;
            Vector xs = xgeneral(dt), tmpv;

            for (int i = 0; i < dt.Count(); i++)
            {
                tmpv = new Vector(dt[i].SerAr());
                tmpv = tmpv - xs;

                res += dt[i].Length / sd(dt[i]) * tmpv * tmpv;
            }

            return res;
        }

        private static Vector xgeneral(List<NNData> lst)
        {
            double sum1 = 0;
            Vector sum2 = Vector.Create.New(lst[0].Num);

            for (int i = 0; i < lst.Count(); i++)
            {
                double tmp = lst[i].Length / sd(lst[i]);
                sum1 += tmp;
                sum2 += tmp * new Vector(lst[i].SerAr());
            }

            return sum2 / sum1;
        }

        private static double sd(NNData d)
        {
            double[] m = d.SerAr();

            List<double> tmp = new List<double>();
            for (int i = 0; i < d.Num; i++)
                tmp.AddRange(NNData.PartArr(d.ARR, d.Length, i).Select(e => e - m[i]));

            Vector v = new Vector(tmp.ToArray());

            return v * v / (d.Length - 1d);
        }

        public static double V2Statistic(List<NNData> dt)
        {
            double res = 0;
            double s = S(dt);

            for (int i = 0; i < dt.Count(); i++)
            {
                res += ((dt[i].Length - 1d) / 2d) * Math.Log(Math.Abs(s) / Math.Abs(sd(dt[i])));
            }

            return res;
        }

        public static double S(List<NNData> dt)
        {
            int nt = dt.Sum(d => d.Length) - dt.Count();
            double sum = 0;

            for (int i = 0; i < dt.Count; i++)
            {
                sum += sd(dt[i]) * (dt[i].Length - 1d);
            }

            return sum / nt;
        }
    }
}
