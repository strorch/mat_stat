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
    public partial class MultiCharting : Form
    {
        NNData data;

        public MultiCharting(NNData data)
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            this.data = data;
            tableLayoutPanel1.ColumnCount = data.Num;
            tableLayoutPanel1.RowCount = data.Num;
            for (int i = 0; i < data.Num; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / data.Num));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / data.Num));
            }

            Chart[,] CHARTS = new Chart[data.Num, data.Num];
            int num = 0 ;
            for (int g = 0; g < data.Num; g++)
                for (int k = 0; k < data.Num; k++)
                {
                    double[] part_arr = NNData.PartArr(data.ARR, data.Length, k);
                    double min = part_arr.Min();
                    int numclass = korelation.num_class(part_arr);
                    double step = (part_arr.Max() - min) / numclass;

                    Chart chart1 = new Chart();
                    ChartArea chartArea1 = new ChartArea();
                    chartArea1.Name = "ChartArea1";
                    chart1.ChartAreas.Add(chartArea1);
                    ((System.ComponentModel.ISupportInitialize)(chart1)).BeginInit();
                    chart1.BorderlineColor = System.Drawing.Color.Black;
                    chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                    chart1.Size = new System.Drawing.Size(250, 200);
                    chart1.Series.Add(num.ToString());
                    chart1.Series[num.ToString()].ChartArea = "ChartArea1";
                    chart1.Series[num.ToString()].BorderWidth = 1;
                    chart1.Series[num.ToString()].CustomProperties = "PointWidth=1";
                    chart1.Series[num.ToString()].BorderColor = Color.Black;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0.000}";
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.000}";

                    if (g == k)
                    {
                        chart1.ChartAreas[0].AxisX.Minimum = min;
                        chart1.ChartAreas[0].AxisX.Maximum = part_arr.Max();
                        chart1.Series[num.ToString()].ChartType = SeriesChartType.Column;
                        for (int j = 0; j < numclass; j++)
                        {
                            double num1 = 0;
                            for (int i = 0; i < part_arr.Length; i++)
                            {
                                if ((part_arr[i] >= min) && (part_arr[i] <= (min + step + 0.00005)))
                                {
                                    num1++;
                                }
                            }
                            chart1.Series[num.ToString()].Points.AddXY(Math.Round(min + step / 2, 4), (num1 / part_arr.Length));
                            min = min + step;
                        }
                        CHARTS[k, g] = chart1;
                    }
                    else
                    {
                        chart1.Series[num.ToString()].ChartType = SeriesChartType.Point;
                        double[] X = NNData.PartArr(data.ARR, data.Length, g);
                        double[] Y = NNData.PartArr(data.ARR, data.Length, k);
                        for (int i = 0; i < X.Length; i++)
                        {
                            chart1.Series[num.ToString()].Points.AddXY(X[i], Y[i]);
                        }
                        CHARTS[k, g] = chart1;
                    }
                    num++;
                }


                for (int i = 0; i < data.Num; i++)
                    for (int j = 0; j < data.Num; j++)
                    {
                        tableLayoutPanel1.Controls.Add(CHARTS[i, j], i, j);
                    }
        }
    }
}
