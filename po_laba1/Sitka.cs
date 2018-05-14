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
    public partial class Sitka : Form
    {
        public Sitka(NNData data)
        {
            InitializeComponent();
            chart1.Series.Clear();
            data = TemperatureMap.Check(data);
            chart1.ChartAreas[0].AxisX.Maximum = data.Num - 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            double[] arr_max = data.arr_max;

            for (int i = 0; i < data.Length; i++)
            {
                chart1.Series.Add(i.ToString());
                chart1.Series[i.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[i.ToString()].Color = Color.Blue;
                for (int j = 0; j < data.Num; j++)
                    chart1.Series[i.ToString()].Points.AddXY(j, data.ARR[i, j] / arr_max[j]);
            }
        }
    }
}
