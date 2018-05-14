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
    public partial class TemperatureMap : Form
    {
        public static NNData Check(NNData data)
        {
            double[] min_arr = new double[data.Num];
            for (int i = 0; i < data.Num; i++)
            {
                double[] arr = NNData.PartArr(data.ARR, data.Length, i);
                min_arr[i] = arr.Min();
            }
            double abs_min = min_arr.Min();
            if (abs_min >= 0)
                return data;
            abs_min = Math.Abs(abs_min);
            double[,] new_arr = new double[data.Length, data.Num];
            for (int i = 0; i < data.Num; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    new_arr[j, i] = data.ARR[ j, i] + abs_min + 1;
                }
            }
            return new NNData(Tuple.Create(new_arr, data.Num, data.Length, data.file_name));
        }

        public TemperatureMap(NNData data1)
        {
            this.AutoScroll = true;
            InitializeComponent();
            pictureBox1.Height = 32 * data1.Length;
            pictureBox1.Width = 64 * data1.Num;
            NNData data = Check(data1);
            

            Bitmap OutputImage = new Bitmap(64 * data.Num, 32 * data.Length, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Bitmap Temp = new Bitmap(64, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics G = Graphics.FromImage(OutputImage);
            Graphics TempG = Graphics.FromImage(Temp);
            Pen BlackPen = new Pen(Color.Black, 0.3f);
            int TempRead = 0;
            for (int i = 0, j; i < data.Num; i++)
            {
                double[] arr = NNData.PartArr(data.ARR, data.Length, i);
                for (j = 0; j < data.Length; j++)
                {
                    TempRead = (255 * data.ARR[j, i] / arr.Max()> 255) ? 255 : (int)(Math.Round(255 * data.ARR[j, i] / arr.Max()));
                    TempG.Clear(Color.FromArgb(155, 0, TempRead, TempRead));
                    TempG.DrawRectangle(BlackPen, 0, 0, Temp.Width, Temp.Height);
                    G.DrawImage(Temp, i * 64, j * 32);
                }
            }
            pictureBox1.Image = OutputImage;
        }
    }
}
