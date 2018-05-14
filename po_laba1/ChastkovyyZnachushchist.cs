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
    public partial class ChastkovyyZnachushchist : Form
    {
        private static double statistic(double koef, int Num, int kkst)
        {
            return koef * Math.Sqrt(Num - kkst - 2) / Math.Sqrt(1 - koef * koef);
        }

        public ChastkovyyZnachushchist(NNData data)
        {
            InitializeComponent();

            for (int i = 0; i < data.Num; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Rows.Add();
            }
            for (int i = 0; i < data.Num; i++)
            {
                for (int j = 0; j < data.Num; j++)
                {
                    if (data.Znachushchist[i, j] != "")
                    {
                        double stat = statistic(Convert.ToDouble(data.Znachushchist[i, j]), data.Length, data.kor_num);
                        if (Math.Abs(stat) <= Quantil.StudentQuantil1(data.Length - data.kor_num - 2))
                            dataGridView1.Rows[i].Cells[j].Value = stat.ToString("N5") + ", True";
                        else
                            dataGridView1.Rows[i].Cells[j].Value = stat.ToString("N5") + ", False";
                    }
                }
            }
        }
    }
}
