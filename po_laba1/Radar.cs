using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace po_laba1
{
    public partial class Radar : Form
    {
        private NNData data;
        private int    num = 0;
        private Chart[,] chart;

        public Radar(NNData data)
        {
            InitializeComponent();
            data = TemperatureMap.Check(data);
            this.data = data;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            this.WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 200f / data.Num));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 200f / data.Num));
            }
            
            chart = new Chart[5, 5];

            for (int i = 0; i < 5 ; i++)
                for (int j = 0; j < 5; j++)
                {
                    Chart chart1 = new Chart();
                    ChartArea chartArea1 = new ChartArea();
                    chartArea1.Name = "ChartArea1";
                    chart1.ChartAreas.Add(chartArea1);
                    ((System.ComponentModel.ISupportInitialize)(chart1)).BeginInit();
                    chart1.BorderlineColor = System.Drawing.Color.Black;
                    chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                    chart1.Size = new System.Drawing.Size(400, 400);
                    chart[i, j] = chart1;
                    tableLayoutPanel1.Controls.Add(chart[i, j], i, j);
                    chart1.ChartAreas[0].AxisY.Maximum = 1;
                }

            charts_filling(ref chart, data,ref  num);
        }

        private void charts_filling(ref Chart[,] charts, NNData data, ref int pointer)
        {
            double[] arr_max = data.arr_max;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (pointer == data.Length)
                    {
                        return;
                    }
                    chart[i, j].Series.Add(pointer.ToString());
                    chart[i, j].Series[pointer.ToString()].ChartArea = "ChartArea1";
                    chart[i, j].Series[pointer.ToString()].BorderWidth = 1;
                    chart[i, j].Series[pointer.ToString()].ChartType = SeriesChartType.Radar;
                    chart[i, j].ChartAreas[0].AxisX.Title = (pointer + 1).ToString();

                    for (int k = 0; k < data.Num; k++)
                    {
                        chart[i, j].Series[pointer.ToString()].Points.AddXY(k, data.ARR[pointer, k] / arr_max[k]);
                    }
                    pointer++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (num <= 25)
                return;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    chart[i, j].Series.Clear();
                }

            if (num == data.Length && num % 25 != 0)
                num -= 25 + (data.Length % 100) % 25;
            else
                num -= 50;
            charts_filling(ref chart, data, ref num);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (num >= data.Length)
                return;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    chart[i, j].Series.Clear();
                }
            
            charts_filling(ref chart, data, ref num);
        }
    }
}
