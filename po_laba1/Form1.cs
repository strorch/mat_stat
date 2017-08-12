﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace po_laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        List<double[]> list_mass = new List<double[]>();
        public double[] massiv;
        public string[] data_mas;
        public double step;
        public int but = 0;
        public int vyb = 0;
        public int kvantili = 0;
        public bool otkr_pub = false;
        public bool modelyuvannya = false;
        int numclass = 0;

        ////////////////
        public int numb_vybirok = 0;

        #region peretvorennya
        //logarifmization
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string message = "not data log!";
                string caption = "Помилка вхідних даних!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return;
            }

            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i] < 0)
                {
                    MessageBox.Show("Елемент №{0} менше 0", i.ToString());
                    return;
                }
            }

            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = Math.Round(Math.Log(massiv[i], Convert.ToDouble(textBox1.Text)), 4);
            }
        }

        //logarifmization e
        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i] < 0)
                {
                    MessageBox.Show("Елемент №{0} менше 0", i.ToString());
                    return;
                }
            }

            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = Math.Round(Math.Log(massiv[i]), 4);

            }
        }

        //logarifmization 10
        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i] < 0)
                {
                    MessageBox.Show("Елемент №{0} менше 0", i.ToString());
                    return;
                }
            }

            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = Math.Round(Math.Log10(massiv[i]), 4);
            }
        }

        //standartization
        private void button5_Click_1(object sender, EventArgs e)
        {
            double MED_but = MED(massiv);
            double MAD_but = MAD(massiv);

            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = (massiv[i] - MED_but) / MAD_but;
            }
        }

        //moving
        private void button6_Click_1(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                string message = "!";
                string caption = "Помилка вхідних даних!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return;
            }

            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = massiv[i] + Convert.ToDouble(textBox2.Text);
            }
        }

        //exponentiation
        private void button10_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
            {
                string message = "!";
                string caption = "Помилка вхідних даних!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return;
            }

            for (int i = 0; i < massiv.Length; i++)
                massiv[i] = Math.Pow(massiv[i], Convert.ToDouble(textBox4.Text));

        }

        //Підрахунок мінімуму
        public double max1(double[] A)
        {
            double m = A[0];
            int i = 0;
            for (; i < A.Length; i++)
                if (m < A[i])
                    m = A[i];
            return m;
        }

        //Підрахунок максимуму
        public double min1(double[] A)
        {
            double m = A[0];
            int i = 0;
            for (; i < A.Length; i++)
                if (m > A[i])
                    m = A[i];
            return m;
        }
        #endregion
        /*
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            modelyuvannya = false;
            otkr_pub = true;

            Stream myStream = null;
            OpenFileDialog openF = new OpenFileDialog();
            openF.InitialDirectory = Application.StartupPath.ToString();

            openF.Filter = "txt files (*.txt)|*.txt";
            openF.FilterIndex = 1;
            openF.RestoreDirectory = true;
            string data = "";
            if (openF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openF.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            try
                            {
                                data = File.ReadAllText(openF.FileName);
                                lst4click = true;
                            }
                            catch
                            {
                                MessageBox.Show("Error: file \"{0}\" is empty(", openF.FileName);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error: Could not read file");
                }
            }
            else return;

            data = data.Replace("\r", " ");
            data = data.Replace("\n", " ");
            data = data.Replace("\t", " ");
            data = data.Replace("  ", " ");
            data = data.Replace(".", ",");
            data_mas = Regex.Split(data, " ");
            massiv = new double[data_mas.Length];

            for (int i = 0; i < data_mas.Length; i++)
            {
                massiv[i] = Convert.ToDouble(data_mas[i]);
            }
            Array.Sort(massiv);

            list_mass.Add(massiv);
        }
        */
        //Відкриття файлу
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            modelyuvannya = false;
            otkr_pub = true;

            Stream myStream = null;
            OpenFileDialog openF = new OpenFileDialog();
            openF.InitialDirectory = Application.StartupPath.ToString();

            openF.Filter = "txt files (*.txt)|*.txt";
            openF.FilterIndex = 1;
            openF.RestoreDirectory = true;
            string data = "";
            if (openF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openF.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            try
                            {
                                data = File.ReadAllText(openF.FileName);
                            }
                            catch
                            {
                                MessageBox.Show("Error: file \"{0}\" is empty(", openF.FileName);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error: Could not read file");
                }
            }
            else return;

            data = data.Replace("\r", " ");
            data = data.Replace("\t", " ");
            data = data.Replace("\n", " ");
            data = data.Replace("  ", " ");
            data = data.Replace(".", ",");

            data_mas = Regex.Split(data, " ");


            massiv = new double[data_mas.Length];

            for (int i = 0; i < data_mas.Length; i++)
            {
                massiv[i] = Convert.ToDouble(data_mas[i]);
            }
            Array.Sort(massiv);

            list_mass.Add(massiv);
        }

        //Побудова даних
        public void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();

            if (massiv == null)
            {
                MessageBox.Show("Не вибрано ніяких початкових даних");
                return;
            }

            //////////////////////////////////////////////////////////////////////////

            but = 1;
            vyb = 1;
            kvantili = 1;

            //////////////////////////////////////////////////////////////////////

            int count_elem = 0;
            for (int i = 0; i < list_mass.Count(); i++)
            {
                    if (list_mass[i].Length > count_elem)
                    {
                        count_elem = list_mass[i].Length;
                    }
            }
            //removing
            while (dataGridView4.ColumnCount > 0)
            {
                dataGridView4.Columns.RemoveAt(0);
            }
            //

            for (int j = 0; j < count_elem; j++)
            {
                dataGridView4.Columns.Add("", "El_"+j.ToString());
            }
            //////////

            for (int i = 0; i < list_mass.Count(); i++)
            {
                dataGridView4.Rows.Add();
                for (int j = 0; j < list_mass[i].Length; j++)
                {
                    dataGridView4.Rows[i].Cells[j].Value = Math.Round(list_mass[i][j],4).ToString();
                }
            }

            ///////////////////////////////////////////////////////////////

            //Data grid filling 1
            dataGridView1.Rows.Add("Cереднє арифметичне", Math.Round(ser_ar(massiv) - Quantil.StudentQuantil(massiv.Length, massiv) * sigma_x_ser(massiv), 4), ser_ar(massiv), Math.Round(ser_ar(massiv) + Quantil.StudentQuantil(massiv.Length, massiv) * sigma_x_ser(massiv), 4), sigma_x_ser(massiv));
            dataGridView1.Rows.Add("Математичне сподівання", "", mat_spod(massiv), "", "");
            dataGridView1.Rows.Add("МЕД", "", MED(massiv), "", "");
            dataGridView1.Rows.Add("Усічене середнє", "", Math.Round(usichene_ser(massiv, 0.05), 4), "", "");
            dataGridView1.Rows.Add("Дисперсія", "", dispersion(massiv), "", "");
            dataGridView1.Rows.Add("Середнє квадратичне відхилення", Math.Round(ser_kvad_vidh(massiv) - Quantil.StudentQuantil(massiv.Length, massiv) * sigma_sigma(massiv), 4), ser_kvad_vidh(massiv), Math.Round(ser_kvad_vidh(massiv) + Quantil.StudentQuantil(massiv.Length, massiv) * sigma_sigma(massiv), 4), sigma_sigma(massiv));
            dataGridView1.Rows.Add("МАД", "", MAD(massiv), "", "");
            dataGridView1.Rows.Add("Медіана середніх Уолша", "", Math.Round(Yolsh(massiv), 4), "", "");
            dataGridView1.Rows.Add("Коефіцієнт асиметрії", Math.Round(koef_asym(massiv) - Quantil.StudentQuantil(massiv.Length, massiv) * sigma_koef_as(massiv), 4), koef_asym(massiv), Math.Round(koef_asym(massiv) + Quantil.StudentQuantil(massiv.Length, massiv) * sigma_koef_as(massiv), 4), sigma_koef_as(massiv));
            dataGridView1.Rows.Add("Коефіцієнт eксцесу", Math.Round(koef_aksc(massiv) - Quantil.StudentQuantil(massiv.Length, massiv) * sigma_koef_aksc(massiv), 4), koef_aksc(massiv), Math.Round(koef_aksc(massiv) + Quantil.StudentQuantil(massiv.Length, massiv) * sigma_koef_aksc(massiv), 4), sigma_koef_aksc(massiv));
            dataGridView1.Rows.Add("Контрeксцес", Math.Round(kontraksc(massiv) - Quantil.StudentQuantil(massiv.Length, massiv) * sigma_kontreks(massiv), 4), kontraksc(massiv), Math.Round(kontraksc(massiv) + Quantil.StudentQuantil(massiv.Length, massiv) * sigma_kontreks(massiv), 4), sigma_kontreks(massiv));
            if (MED(massiv) != 0)
                dataGridView1.Rows.Add("Непараметричний коефіцієнт варіації", "", Math.Round(MAD(massiv) / MED(massiv), 4), "", "");
            else
                MessageBox.Show("MED = 0 неможливо порахувати MED");
            dataGridView1.Rows.Add("Коефіцієнт варіації Пірсона", Math.Round(koef_var_pirs(massiv) - Quantil.StudentQuantil(massiv.Length, massiv) * sigma_koef_var_pirs(massiv), 4), koef_var_pirs(massiv), Math.Round(koef_var_pirs(massiv) + Quantil.StudentQuantil(massiv.Length, massiv) * sigma_koef_var_pirs(massiv), 4), sigma_koef_var_pirs(massiv));

            //Data grid filling 2
            if (massiv.Length <= 3000)
            {
                for (int i = 0; i < massiv.Length; i++)
                {
                    dataGridView2.Rows.Add("X_" + (i + 1), Math.Round(massiv[i], 4));

                }
            }

            ////////////////////

            if (massiv.Length < 100)
            {
                int kakaha = (int)Math.Truncate(Math.Sqrt(massiv.Length));
                if (kakaha % 2 == 0)
                    numclass = kakaha - 1;
                else
                    numclass = kakaha;
            }
            else
            {
                double kakaha = Math.Truncate(Math.Pow(massiv.Length, 1.0 / 3.0));
                if (kakaha % 2 == 0)
                    numclass = (int)kakaha - 1;
                else
                    numclass = (int)kakaha;
            }

            label4.Visible = true;
            label4.Text = "Cтандартна к - сть класів - " + Convert.ToString(numclass);

            //CHART_1

            chart1.Series.Add("lala");

            chart1.Series["lala"].BorderColor = Color.Black;
            chart1.Series["lala"].ChartType = SeriesChartType.Column;
            chart1.Series["lala"].CustomProperties = "PointWidth=1";


            if (textBox3.Text != "")
            {
                numclass = Convert.ToInt32(textBox3.Text);
            }

            step = (max1(massiv) - min1(massiv)) / numclass;
            double min = min1(massiv);

            chart1.ChartAreas[0].AxisX.Minimum = min1(massiv);
            chart1.ChartAreas[0].AxisX.Maximum = max1(massiv) + 2;

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "###,##0.000";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "###,##0.000";
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            chart1.ChartAreas[0].AxisX.Interval = step;
            for (int j = 0; j < numclass; j++)
            {
                double num1 = 0;
                for (int i = 0; i < massiv.Length; i++)
                {
                    if ((massiv[i] >= min) && (massiv[i] <= (min + step + 0.00005)))
                    {
                        num1++;
                    }
                }
                chart1.Series["lala"].Points.AddXY(Math.Round(min + step / 2, 4), (num1 / massiv.Length));
                min = min + step;
            }

            //CHART_2

            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].CursorX.Interval = 0.01D;
            //chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart2.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].CursorY.Interval = 0.01D;

            //chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            //chart2.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "###,##0.000";
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "###,##0.000";
            chart2.Series.Add("gaga");
            chart2.Series["gaga"].ChartType = SeriesChartType.StepLine;

            double minimum = min1(massiv);

            double num2 = 0;
            chart2.ChartAreas[0].AxisX.Minimum = min1(massiv);
            chart2.ChartAreas[0].AxisX.Maximum = max1(massiv) + 0.1;

            for (int i = 0; i < numclass; i++)
            {
                for (int j = 0; j < massiv.Length; j++)
                {
                    if ((massiv[j] > minimum - 0.000005) && (massiv[j] < (minimum + step + 0.000005)))
                    {
                        num2++;
                    }
                    else continue;
                }
                chart2.Series["gaga"].Points.AddXY(Math.Round(minimum, 4), (num2 / massiv.Length));
                minimum = minimum + step;
            }

            if (massiv.Length <= 3000)
            {
                chart2.Series.Add("points");
                chart2.Series["points"].ChartType = SeriesChartType.Point;

                for (int i = 0; i < massiv.Length; i++)
                {
                    double a = 0;
                    for (int j = 0; j < massiv.Length; j++)
                    {
                        if (massiv[j] <= massiv[i])
                        {
                            a++;
                        }
                    }

                    chart2.Series["points"].Points.AddXY(Math.Round(massiv[i], 4), a / massiv.Length);
                }
            }
        }

        //Видалення елементу
        public void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            List<double> lst = new List<double>(massiv);
            lst.RemoveAt(e.Row.Index);
            massiv = lst.ToArray();
        }

        #region Point marks funktions

        public double Yolsh(double[] mass)
        {
            double[] MAD = new double[mass.Length];
            for (int i = 0; i < mass.Length; i++)
                for (int j = i; j < mass.Length; j++)
                    MAD[i] = (mass[i] + mass[j]) / 2;
            Array.Sort(MAD);
            return MAD[(int)(MAD.Length / 2)];
        }

        public double sigma(double[] mass)
        {
            double gc = 0;
            for (int i = 0; i < mass.Length; i++)
                gc += mass[i] * mass[i];
            return Math.Round(Math.Pow(gc / massiv.Length - Math.Pow(ser_ar(mass), 2), 3 / 2), 4);
        }

        public double ser_ar(double[] mass)
        {
            double ser_ar = 0;
            double ga = 0;
            for (int i = 0; i < mass.Length; i++)
                ga += mass[i];

            ser_ar = Math.Round(ga / massiv.Length, 4);
            return ser_ar;
        }

        public double mat_spod(double[] mass)
        {
            return ser_ar(mass);
        }

        public double MED(double[] mass)
        {
            int ser_left_MED = mass.Length / 2;
            int ser_right_MED = mass.Length / 2 + 1;
            double med_res = 0;
            if (massiv.Length % 2 == 0)
            {
                med_res = mass[(ser_left_MED + ser_right_MED) / 2];
            }
            else
            {
                med_res = mass[mass.Length / 2 + 1];
            }
            return Math.Round(med_res, 4);
        }

        public double usichene_ser(double[] mass, double alfa)
        {
            if (alfa < 0 || alfa > 0.5)
            {
                MessageBox.Show("Nekorektne alfa");
            }
            double gb = 0;
            int k = (int)Math.Truncate(alfa * mass.Length);
            for (int i = k + 1; i < mass.Length - k; i++)
                gb += mass[i];

            return gb / (mass.Length - 2 * k);
        }

        public double dispersion(double[] mass)
        {

            double[] mass_disp = new double[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                mass_disp[i] = Math.Pow((mass[i] - ser_ar(mass)), 2);
            }
            double gb = 0;
            for (int i = 0; i < mass_disp.Length; i++)
                gb += mass_disp[i];
            return Math.Round(gb / (mass_disp.Length - 1), 4);
        }

        public double ser_kvad_vidh(double[] mass)
        {
            return Math.Round(Math.Sqrt(dispersion(mass)), 4);
        }

        public double MAD(double[] mass)
        {
            double[] mass_mad = new double[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                mass_mad[i] = mass[i] - Convert.ToInt32(MED(mass));
            }
            Array.Sort(mass);
            int ser_left_MAD = mass_mad.Length / 2;
            int ser_right_MAD = mass_mad.Length / 2 + 1;

            double mad_res = 0;
            if (mass_mad.Length % 2 == 0)
            {
                mad_res = 1.483 * (ser_left_MAD + ser_right_MAD) / 2;
            }
            else
            {
                mad_res = 1.483 * mass_mad[mass_mad.Length / 2 + 1];
            }

            return Math.Round(mad_res, 4);
        }

        public double koef_asym(double[] mass)
        {
            double[] mass_k_a = new double[mass.Length];

            for (int i = 0; i < mass.Length; i++)
            {
                mass_k_a[i] = Math.Pow(mass[i] - ser_ar(mass), 3);
            }
            double gd = 0;
            for (int i = 0; i < mass_k_a.Length; i++)
                gd += mass_k_a[i] * mass_k_a[i];
            double koef_as_zsun = gd / (mass_k_a.Length * Math.Pow(sigma(mass), 3));

            return Math.Round(koef_as_zsun * Math.Sqrt(mass_k_a.Length * (mass_k_a.Length - 1)) / (mass_k_a.Length - 2), 4);
        }

        public double koef_aksc(double[] mass)
        {
            int N = mass.Length;

            double[] mass_koef_aksc = new double[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                mass_koef_aksc[i] = Math.Pow(mass[i] - ser_ar(mass), 4);
            }

            double ge = 0;
            for (int i = 0; i < mass_koef_aksc.Length; i++)
                ge += mass_koef_aksc[i];

            double zsun_koef_ak = ge / (N * Math.Pow(sigma(mass), 4));

            return Math.Round((N * N - 1) * (zsun_koef_ak - 3 + 6 / (N + 1)) / ((N - 2) * (N - 3)), 4);
        }

        public double kontraksc(double[] mass)
        {
            return Math.Round(1 / Math.Sqrt(Math.Abs(koef_aksc(mass))), 4);
        }

        public double koef_var_pirs(double[] mass)
        {
            if (ser_ar(mass) != 0)
            {
                return Math.Round(Math.Sqrt(dispersion(mass)) / ser_ar(mass), 4);
            }
            else
            {
                string message = "Неможливо порахувати Коефіцієнт варіації Пірсона, так як Х середнє дорівнює 0!";
                string caption = "Помилка вхідних даних!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return 1;
            }
        }

        public double interkvart_rozm(double[] mass)
        {
            return 0;
        }

        #endregion

        #region Interval marks funktions

        public double sigma_x_ser(double[] mass)
        {
            return Math.Round(sigma(mass) / Math.Sqrt(mass.Length), 4);
        }

        public double sigma_sigma(double[] mass)
        {
            return Math.Round(sigma(mass) / Math.Sqrt(mass.Length * 2), 4);
        }

        public double sigma_koef_as(double[] mass)
        {
            double N = mass.Length;
            return Math.Round(Math.Sqrt(6 * (N - 2) / ((N + 1) * (N + 3))), 4);
        }

        public double sigma_koef_aksc(double[] mass)
        {
            double N = mass.Length;
            return Math.Round(Math.Sqrt(24 * N * (N - 2) * (N - 3) / (Math.Pow(N + 1, 2) * (N + 3) * (N + 5))), 4);
        }

        public double sigma_kontreks(double[] mass)
        {
            double N = mass.Length;
            return Math.Round(Math.Sqrt(Math.Abs(kontraksc(mass)) / (29 * N)) * Math.Pow(Math.Abs(Math.Pow(kontraksc(mass), 2) - 1), 3 / 4), 4);
        }

        public double sigma_koef_var_pirs(double[] mass)
        {
            return Math.Round(koef_var_pirs(mass) * Math.Sqrt((1 + 2 * Math.Pow(koef_var_pirs(mass), 2)) / (2 * mass.Length)), 4);
        }

        #endregion

        //Очищення данних
        private void button3_Click(object sender, EventArgs e)
        {
            massiv = null;
            list_mass.Clear();
            label4.Visible = false;
            but = 0;
            vyb = 0;
            chart1.Series.Clear();
            chart2.Series.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            label18.Text = "Резульати оцінок:\n";
        }

        //Початкові дані
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (otkr_pub == true)
            {
                massiv = new double[data_mas.Length];
                for (int i = 0; i < massiv.Length; i++)
                {
                    massiv[i] = Convert.ToDouble(data_mas[i]);
                }
            }
            else if (modelyuvannya == true)
            {
                massiv = new double[mass1.Length];
                for (int i = 0; i < mass1.Length; i++)
                {
                    massiv[i] = mass1[i];
                }
            }

        }

        //Збереження файлу
        int count = 0;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            count++;
            string[] massiv_str = new string[massiv.Length];
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv_str[i] = Convert.ToString(Math.Round(massiv[i], 4));
            }

            // Set a variable to the My Documents path.
            string mydocpath =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\Data(" + count.ToString() + ").txt"))
            {
                for (int i = 0; i < massiv_str.Length; i++)
                    outputFile.WriteLine(massiv_str[i]);
            }
        }

        //Вилучення аномальних даних
        private void button2_Click(object sender, EventArgs e)
        {
            int N = massiv.Length; // pre-count used in auto-remove of abnormals
            double[] S_allnum = new double[0]; // cleared array of values
            double AverageX = ser_ar(massiv); // Average X

            try
            {
                double
                    t = 1.55 + 0.8 * (Math.Sqrt(Math.Abs(koef_aksc(massiv))) * Math.Log10(N / 10)),
                    A = Math.Round(AverageX - t * ser_kvad_vidh(massiv)),
                    B = Math.Round(AverageX + t * ser_kvad_vidh(massiv));
                int k = 0;
                double[] Buf_allnum = new double[massiv.Length]; // temporary array

                for (int i = 0; i < massiv.Length; i++)
                {
                    if (massiv[i] < B && massiv[i] > A)
                    {
                        Buf_allnum[k] = massiv[i];
                        k++;
                    }
                }
                S_allnum = new double[k];
                for (int i = 0; i < k; i++)
                {
                    S_allnum[i] = Buf_allnum[i];
                }
                massiv = S_allnum;
                N = massiv.Length;
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }

        public bool expon_raspr = false;
        public bool norm_raspr = false;
        public bool raspr_veibulla = false;
        public double[] mass1;

        //Моделювання вибірки
        private void button13_Click(object sender, EventArgs e)
        {
            otkr_pub = false;
            modelyuvannya = true;

            if (textBox10.Text == "")
            {
                string message = "Не вибрано к-сть елементів вибірки!";
                string caption = "Помилка вхідних даних!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return;
            }
            /////////////////////////////////////////////////////////////////////////////
            if (expon_raspr == true)
            {
                if (textBox7.Text == "")
                {
                    string message = "Не введено параметри експоненціального розподілу!";
                    string caption = "Помилка вхідних даних!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        this.Close();
                    }
                    return;
                }
                double l = Convert.ToDouble(textBox7.Text);
                massiv = new double[Convert.ToInt32(textBox10.Text)];
                mass1 = new double[Convert.ToInt32(textBox10.Text)];
                for (int i = 0; i < massiv.Length; i++)
                {
                    massiv[i] = TestSimpleRNG.SimpleRNG.GetExponential(1 / l);
                    mass1[i] = TestSimpleRNG.SimpleRNG.GetExponential(1 / l);
                }
                list_mass.Add(massiv);
                expon_raspr = false;
            }
            else if (norm_raspr == true)
            {
                if (textBox5.Text == "" || textBox6.Text == "")
                {
                    string message = "Не введено параметри експоненціального розподілу!";
                    string caption = "Помилка вхідних даних!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        this.Close();
                    }
                    return;
                }
                double m = Convert.ToDouble(textBox5.Text);
                double O = Convert.ToDouble(textBox6.Text);
                massiv = new double[Convert.ToInt32(textBox10.Text)];
                mass1 = new double[Convert.ToInt32(textBox10.Text)];

                for (int i = 0; i < massiv.Length; i++)
                {
                    massiv[i] = TestSimpleRNG.SimpleRNG.GetNormal(m, O);
                    mass1[i] = TestSimpleRNG.SimpleRNG.GetNormal(m, O);
                }
                list_mass.Add(massiv);

                norm_raspr = false;
            }
            else if (raspr_veibulla == true)
            {
                if (textBox8.Text == "" || textBox9.Text == "")
                {
                    string message = "Не введено параметри експоненціального розподілу!";
                    string caption = "Помилка вхідних даних!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        this.Close();
                    }
                    return;
                }
                double alfa = Convert.ToDouble(textBox8.Text);
                double beta = Convert.ToDouble(textBox9.Text);

                massiv = new double[Convert.ToInt32(textBox10.Text)];
                mass1 = new double[Convert.ToInt32(textBox10.Text)];

                for (int i = 0; i < massiv.Length; i++)
                {
                    massiv[i] = TestSimpleRNG.SimpleRNG.GetWeibull(alfa, beta);
                    mass1[i] = TestSimpleRNG.SimpleRNG.GetWeibull(alfa, beta);
                }
                list_mass.Add(massiv);

                raspr_veibulla = false;
            }
            else
            {
                string message = "Натиснуто 'Моделювання', але не було вибрано вибірку!";
                string caption = "Помилка вхідних даних!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return;
            }
        }

        #region vydtvorennya rozp
        Hashtable arr1;
        //Відтворення нормального розподілу
        private void button7_Click(object sender, EventArgs e)
        {

            arr1 = new Hashtable(1000);

            double m = ser_ar(massiv);
            double sigma = ser_kvad_vidh(massiv);
            int N = massiv.Length;
            double a = 1.0 / (sigma * Math.Sqrt(2 * Math.PI));
            double inter = (max1(massiv) - min1(massiv)) / 1000;
            double sum = 0;

            double d_M = 0, d_sigma = 0;
            double disp_m = sigma * sigma / N;
            double disp_sigma = sigma * sigma / (2 * N);
            double D = 0;

            for (double i = Math.Round(min1(massiv), 3); i < max1(massiv); i = Math.Round(i + inter, 3))
            {
                arr1[i] = Math.Round(a * Math.Pow(Math.E, -1.0 * ((i - m) * (i - m) / (2 * sigma * sigma))), 5);
                sum += (double)arr1[i];
            }

            double q = 1000 / numclass;


            chart1.Series.Add("norm_rozp_gis");
            chart1.Series["norm_rozp_gis"].ChartType = SeriesChartType.Spline;
            Array.Sort(massiv);

            for (double i = Math.Round(min1(massiv), 3); i < max1(massiv); i = Math.Round(i + inter, 3))
            {
                arr1[i] = (double)arr1[i] * q / sum;
                chart1.Series["norm_rozp_gis"].Points.AddXY(i, arr1[i]);
            }

            double temp = 0;
            double end = 0;

            chart2.Series.Add("norm_rozp_nyzh");
            chart2.Series["norm_rozp_nyzh"].ChartType = SeriesChartType.Spline;
            chart2.Series.Add("norm_rozp");
            chart2.Series["norm_rozp"].ChartType = SeriesChartType.Spline;
            chart2.Series.Add("norm_rozp_verh");
            chart2.Series["norm_rozp_verh"].ChartType = SeriesChartType.Spline;


            for (double i = Math.Round(min1(massiv) + inter, 3); i < max1(massiv); i = Math.Round(i + inter, 3))
            {
                temp = Math.Round(i - inter, 3);
                arr1[i] = (double)arr1[temp] + (double)arr1[Math.Round(i, 3)];
                end = Math.Round(i, 3);
            }

            Hashtable nyzh = new Hashtable(1000);
            Hashtable verh = new Hashtable(1000);

            for (double i = Math.Round(min1(massiv), 3); i < max1(massiv); i = Math.Round(i + inter, 3))
            {
                arr1[i] = Math.Round((double)arr1[i] / (double)arr1[end], 3);
                chart2.Series["norm_rozp"].Points.AddXY(i, arr1[i]);

                d_M = (-1.0 / (sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp(-1 * (i - m) * (i - m) / (2 * sigma * sigma));
                d_sigma = (-1) * (i - m) / (sigma * sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp((-1) * (i - m) * (i - m) / (2 * sigma * sigma));
                D = d_M * d_M * disp_m + d_sigma * d_sigma * disp_sigma;

                nyzh[i] = (double)arr1[i] - Math.Sqrt(D) * Quantil.NormalQuantil();
                verh[i] = (double)arr1[i] + Math.Sqrt(D) * Quantil.NormalQuantil();

                chart2.Series["norm_rozp_nyzh"].Points.AddXY(i, nyzh[i]);
                chart2.Series["norm_rozp_verh"].Points.AddXY(i, verh[i]);
            }
        }
        
        //Відтворення експоненціального розподілу
        private void button8_Click(object sender, EventArgs e)
        {
            chart1.Series.Add("exp_rozp_gis");
            chart1.Series["exp_rozp_gis"].ChartType = SeriesChartType.Spline;

            chart2.Series.Add("exp_rozp_nyzh");
            chart2.Series["exp_rozp_nyzh"].ChartType = SeriesChartType.Spline;
            chart2.Series.Add("exp_rozp");
            chart2.Series["exp_rozp"].ChartType = SeriesChartType.Spline;
            chart2.Series.Add("exp_rozp_verh");
            chart2.Series["exp_rozp_verh"].ChartType = SeriesChartType.Spline;
            
            double lamb = 1 / ser_ar(massiv);

            int N = massiv.Length;
            double MinX = min1(massiv);
            double MaxX = max1(massiv);

            for (double i = 0; i < MaxX + 2 * step; i += 0.01 * (MaxX - MinX))
                chart1.Series["exp_rozp_gis"].Points.AddXY(i, lamb * Math.Exp(-lamb * i) * step);
            double D = 0;
            double D_lyam = Math.Pow(lamb, 2) / N;
            double nk = Quantil.NormalQuantil();
            for (int i = 0; i < N; i++)
            {
                D = nk * Math.Sqrt(Math.Pow(massiv[i], 2) * Math.Exp(-2 * lamb * massiv[i]) * D_lyam);
                chart2.Series["exp_rozp"].Points.AddXY(massiv[i], 1 - Math.Exp(-lamb * massiv[i]));
                chart2.Series["exp_rozp_verh"].Points.AddXY(massiv[i], 1 - Math.Exp(-lamb * massiv[i]) + D);
                chart2.Series["exp_rozp_nyzh"].Points.AddXY(massiv[i], 1 - Math.Exp(-lamb * massiv[i]) - D);
            }
        }

        //Відтворення розподілу Вейбулла
        private void button9_Click(object sender, EventArgs e)
        {
            chart1.Series.Add("veib_rozp_gis");
            chart1.Series["veib_rozp_gis"].ChartType = SeriesChartType.Spline;

            chart2.Series.Add("veib_rozp_nyzh");
            chart2.Series["veib_rozp_nyzh"].ChartType = SeriesChartType.Spline;
            chart2.Series.Add("veib_rozp");
            chart2.Series["veib_rozp"].ChartType = SeriesChartType.Spline;
            chart2.Series.Add("veib_rozp_verh");
            chart2.Series["veib_rozp_verh"].ChartType = SeriesChartType.Spline;

            //counting koeficients
            ///////////////////////////////////////////////////////////
            int N = massiv.Length;

            double a11 = N - 1;
            double a21 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                a21 += Math.Log(massiv[i]);
            }

            double a12 = a21;
            double a22 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                a22 += Math.Pow(Math.Log(massiv[i]),2);
            }

            double b1 = 0, b2 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                double a = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a++;
                    }
                }
                b1 += Math.Log(Math.Log(1 / (1 - a / N)));
            }

            for (int i = 0; i < N - 1; i++)
            {
                double a = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a++;
                    }
                }
                b2 += Math.Log(massiv[i])* Math.Log(Math.Log(1 / (1 - a / N)));
            }

            double beta_kr = (a11*b2 - a21*b1)/(a11*a22 - a12*a21);
            double A_kr = (b1 - a12 * beta_kr) / a11;
            double alfa_kr = Math.Exp((-1) * A_kr);

            double s2zag = 0;

            for(int i =0; i < N - 1; i++)
            {
                double a = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a++;
                    }
                }
                s2zag += Math.Pow(Math.Log(Math.Log(1.0 / (1 - a / N))) - A_kr - beta_kr * Math.Log(massiv[i]),2);
            }

            s2zag = s2zag / (N - 3);

            double disp_A_kr = a22 * s2zag / (a11 * a22 - a12 * a21);
            double disp_beta_kr = (a11 * s2zag) / (a11 * a22 - a12 * a21);
            
            double cov_Akr_betakr = (-1) * a21 * s2zag / (a11*a22 - a12 * a21);
            double disp_alfa_kr = Math.Exp((-2) * A_kr) * disp_A_kr;
            double cov_alfa_beta = (-1) * Math.Exp(A_kr) * cov_Akr_betakr;

            //
            double D_alfa = 0, D_beta = 0;
            double sum = 0;
            double[] array = new double[N];
            Hashtable arr = new Hashtable(1000);
            double inter = (max1(massiv) - min1(massiv)) / 1000;

            for(double i = Math.Round(min1(massiv), 3); i < max1(massiv); i = Math.Round(i + inter, 3))
            {
                if(i == 0)
                {
                    continue;
                }

                if (!Double.IsInfinity((double)(beta_kr / alfa_kr) * Math.Pow(i, beta_kr - 1) * Math.Exp((-1) * Math.Pow(i, beta_kr) / alfa_kr)))
                    arr[i] = (beta_kr / alfa_kr) * Math.Pow(i, beta_kr - 1) * Math.Exp((-1) * Math.Pow(i, beta_kr) / alfa_kr);
                sum += (double)arr[i];
            }

            double q = 1000 / numclass;
            for (double i = Math.Round(min1(massiv), 3); i < max1(massiv); i = Math.Round(i + inter, 3))
            {
                arr[i] = (double)arr[i] * q / sum;
                chart1.Series["veib_rozp_gis"].Points.AddXY(i, arr[i]);
            }
            arr = new Hashtable(1000);
            double D = 0;

            Hashtable verh = new Hashtable(1000);
            Hashtable nyzh = new Hashtable(1000);

            for (double i = Math.Round(min1(massiv), 3); i < max1(massiv); i = Math.Round(i + inter, 3))
            {
                if (i == 0) continue;
                if (!Double.IsInfinity(1 - Math.Exp(-Math.Pow(i, beta_kr) / alfa_kr)))
                    arr[i] = 1 - Math.Exp(-Math.Pow(i, beta_kr) / alfa_kr);

                chart2.Series["veib_rozp"].Points.AddXY(i, arr[i]);
                D_alfa = (-1) * Math.Pow(i, beta_kr) / (alfa_kr * alfa_kr) * Math.Exp((-1) * Math.Pow(i, beta_kr) / alfa_kr);
                D_beta = Math.Pow(i, beta_kr) / alfa_kr * Math.Log(i) * Math.Exp((-1) * Math.Pow(i, beta_kr) / alfa_kr);
                    
                D = Math.Pow(D_alfa, 2) * disp_alfa_kr + Math.Pow(D_beta, 2) * disp_beta_kr + 2 * D_alfa * D_beta * cov_alfa_beta;
                verh[i] = (double)arr[i] + Quantil.NormalQuantil() * Math.Sqrt(D);
                nyzh[i] = (double)arr[i] - Quantil.NormalQuantil() * Math.Sqrt(D);
                chart2.Series["veib_rozp_nyzh"].Points.AddXY(i, nyzh[i]);
                chart2.Series["veib_rozp_verh"].Points.AddXY(i, verh[i]);
            }
        }
        #endregion

        #region click obj
        //Моделювання нормального розподілу
        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            norm_raspr = true;
            //MessageBox.Show("loh");
        }

        //Моделювання Експоненціального розподілу
        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            expon_raspr = true;
            //MessageBox.Show("dibil");
        }

        //Моделювання розподілу вейбулла
        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            raspr_veibulla = true;
            //MessageBox.Show("kek");
        }
        #endregion

        //вихід з програми
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //критерій пірсена
        #region pirsen
        public int search(double a, double b)
        {
            int ret = 0;
            for (int i = 0; i < this.massiv.Length; i++)
                if (this.massiv[i] > (a - 0.00001) && this.massiv[i] < b + 0.00001)
                    ret++;
            return ret;
        }
        void pirs_norm()
        {
            double[] teor = new double[massiv.Length];
            double m = ser_ar(massiv);
            double sigma = ser_kvad_vidh(massiv);
            int N = massiv.Length;
            double a1 = 1.0 / (sigma * Math.Sqrt(2 * Math.PI));
            double sum1 = 0;


            for (int i = 0; i < massiv.Length; i++)
            {
                teor[i] = Math.Round(a1 * Math.Pow(Math.E, -1.0 * ((massiv[i] - m) * (massiv[i] - m) / (2 * sigma * sigma))), 5);
                sum1 += (double)teor[i];
            }

            int temp = 0;

            for (int i = 1; i < massiv.Length; i++)
            {
                temp = i - 1;
                teor[i] = (double)teor[temp] + (double)teor[i];
            }

            for (int i = 0; i < massiv.Length; i++)
            {
                teor[i] = teor[i] / teor[massiv.Length - 1];
            }

            double alpha = 0.0;
            if (N < 30) alpha = 0.3;
            if (N >= 30 && N <= 100) alpha = 0.1;
            if (N > 100) alpha = 0.05;
            double Xi2 = 0.0;

            double a = massiv.Min();
            double b = massiv.Max();
            double h = (b - a) / (double)numclass;
            b = a + h;
            double chs = 0.0;
            for (int i = 0; i < numclass - 1; i++)
            {
                chs = search(a, b);
                Xi2 += Math.Pow((chs - N * (double)(teor[i + 1] - teor[i])), 2) / (double)(N * (teor[i + 1] - teor[i]));
                a += h;
                b += h;
            }
            string s = "Альфа = " + alpha.ToString() + "\t v = " + (numclass - 1).ToString() + "\nЗначення статистики Хі^2 = " + Math.Round(Xi2, 4).ToString() + "\n" + "Якщо Хі^2 не перевищує табличне значення для альфа та v, то емпірична функція збігається з теоретичною";

            label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
        }
        void pirs_veib()
        {

            int N = massiv.Length;
            double a11 = N - 1;
            double a21 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                a21 += Math.Log(massiv[i]);
            }

            double a12 = a21;
            double a22 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                a22 += Math.Pow(Math.Log(massiv[i]), 2);
            }

            double b1 = 0, b2 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                double a1 = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a1++;
                    }
                }
                b1 += Math.Log(Math.Log(1 / (1 - a1 / N)));
            }

            for (int i = 0; i < N - 1; i++)
            {
                double a1 = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a1++;
                    }
                }
                b2 += Math.Log(massiv[i]) * Math.Log(Math.Log(1 / (1 - a1 / N)));
            }

            double beta_kr = (a11 * b2 - a21 * b1) / (a11 * a22 - a12 * a21);
            double A_kr = (b1 - a12 * beta_kr) / a11;
            double alfa_kr = Math.Exp((-1) * A_kr);
            double alpha = 0.0;
            if (N < 30) alpha = 0.3;
            if (N >= 30 && N <= 100) alpha = 0.1;
            if (N > 100) alpha = 0.05;
            double Xi2 = 0.0;

            double a = massiv.Min();
            double b = massiv.Max();
            double h = (b - a) / (double)numclass;
            b = a + h;
            double chs = 0.0;
            for (int i = 0; i < numclass - 1; i++)
            {
                chs = search(a, b);
                Xi2 += Math.Pow((chs - N * (double)(1 - Math.Exp(-Math.Pow(massiv[i + 1], beta_kr) / alfa_kr) - 1 + Math.Exp(-Math.Pow(massiv[i], beta_kr) / alfa_kr))), 2) / (double)(N * (1 - Math.Exp(-Math.Pow(massiv[i + 1], beta_kr) / alfa_kr) - 1 + Math.Exp(-Math.Pow(massiv[i], beta_kr) / alfa_kr)));
                a += h;
                b += h;
            }
            string s = "Альфа = " + alpha.ToString() + "\t v = " + (numclass - 1).ToString() + "\nЗначення статистики Хі^2 = " + Math.Round(Xi2, 4).ToString() + "\n" + "Якщо Хі^2 не перевищує табличне значення для альфа та v, то емпірична функція збігається з теоретичною";

            label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
        }
        void pirs_eksp()
        {
            Array.Sort(massiv);
            double lamb = 1 / ser_ar(massiv);
            string s;
            int N = massiv.Length;
            double alpha = 0.0;
            if (N < 30) alpha = 0.3;
            if (N >= 30 && N <= 100) alpha = 0.1;
            if (N > 100) alpha = 0.05;
            double Xi2 = 0.0;

            double a = massiv.Min();
            double b = massiv.Max();
            double h = (b - a) / (double)numclass;
            b = a + h;
            double chs = 0.0;
            for (int i = 0; i < numclass - 1; i++)
            {
                chs = search(a, b);
                Xi2 += Math.Pow((chs - N * (double)(1 - Math.Exp(-lamb * massiv[i + 1]) - 1 + Math.Exp(-lamb * massiv[i]))), 2) / (double)(N * (1 - Math.Exp(-lamb * massiv[i + 1]) - 1 + Math.Exp(-lamb * massiv[i])));
                a += h;
                b += h;
            }
             s = "Альфа = " + alpha.ToString() + "\t v = " + (numclass - 1).ToString() + "\nЗначення статистики Хі^2 = " + Math.Round(Xi2, 4).ToString() + "\n" + "Якщо Хі^2 не перевищує табличне значення для альфа та v, то емпірична функція збігається з теоретичною";

            label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            pirs_norm();
            pirs_eksp();
            pirs_veib();
        }
        #endregion

        //kryteryy kolmogorova
        #region kolmogorov

        void kolmog_exp()
        {
            Array.Sort(massiv);
            double lamb = 1 / ser_ar(massiv);
            string s;
            double alpha = 0.0, Dn_plus = 0.0, Dn_minus = 0.0;
            int N = massiv.Length;
            if (N < 30) alpha = 0.3;
            if (N >= 30 && N <= 100) alpha = 0.1;
            if (N > 100) alpha = 0.05;

            double frozp = 0;
            double fteor = 0;
            double fteor1 = 0;
            for (int i = 0; i < massiv.Length; i++)
            {
                double a = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a++;
                    }
                }
                double b = a;
                frozp = a / massiv.Length;
                if (frozp > 1)
                {
                    MessageBox.Show("помилка");
                    return;
                }


                fteor = 1 - Math.Exp(-lamb * massiv[i]);
                if (Dn_plus < Math.Abs(frozp - fteor))
                    Dn_plus = Math.Abs(frozp - fteor);
                if (i > 0)
                    if (Dn_minus < Math.Abs(frozp - fteor1))
                    {
                        fteor1 = 1 - Math.Exp(-lamb * massiv[i - 1]);
                        Dn_minus = Math.Abs(frozp - fteor1);
                    }
            }

            double ror = Math.Sqrt(N);

            double z = 0;

            if (Dn_minus > Dn_plus)
            {
                z = ror * Dn_minus;
            }
            else
            {
                z = ror * Dn_plus;
            }

            int k = 1;
            double sum0, sum = 0, f1, f2;
            do
            {
                sum0 = sum;
                f1 = k * k - 0.5 * (1 - Math.Pow(-1, k));
                f2 = 5 * k * k + 22 - 7.5 * (1 - Math.Pow(-1, k));
                sum += Math.Pow(-1, k) * Math.Exp(-2 * k * k * z * z) * (1 - (2 * k * k * z) / (3 * Math.Sqrt(N)) - (8 * Math.Pow(k * z, 4) + k * k * z * z * (f1 - 4 * (f1 + 3))) / (18 * N) + (k * k * z * (f2 * f2 / 5 - 4 * k * k * z * z * (f2 + 45) / 15 + 8 * Math.Pow(k * z, 4))) / (27 * Math.Pow(N, 3.0 / 2.0)));
                k++;
            } while (Math.Abs(sum - sum0) > 0.001);
            double Kz = 1 + 2 * sum;
            double Pz = 1 - Kz;
            s = "Для експоненціального розподілу статистика критерію Колмогорова z = " + z.ToString() + ".\nЙмовірність узгодження P(z) = " + Pz.ToString();
            if (Pz >= alpha)
                s = s + ".\nЗа уточненим критерієм Колмогорова емпірична функція збігається з теоретичною.";
            else
                s = s + ".\nЗа уточненим критерієм Колмогорова емпірична функція НЕ збігається з теоретичною.";

            label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
        }
        
        void kolmog_norm()
        {
            double[] teor = new double[massiv.Length];
            double m = ser_ar(massiv);
            double sigma = ser_kvad_vidh(massiv);
            int N = massiv.Length;
            double a = 1.0 / (sigma * Math.Sqrt(2 * Math.PI));
            double sum1 = 0;

            
            for (int i = 0; i < massiv.Length; i ++)
            {
                teor[i] = Math.Round(a * Math.Pow(Math.E, -1.0 * ((massiv[i] - m) * (massiv[i] - m) / (2 * sigma * sigma))), 5);
                sum1 += (double)teor[i];
            }

            //double q = massiv.Length / numclass;

            Array.Sort(massiv);
/*
            for (int i = 0; i < massiv.Length; i++)
            {
                teor[i] = (double)teor[i] * q / sum1;
            }
            */
            int temp = 0;
            
            for (int i = 1; i < massiv.Length; i++)
            {
                temp = i-1;
                teor[i] = (double)teor[temp] + (double)teor[i];
            }

            for (int i = 0; i < massiv.Length; i++)
            {
                teor[i] = teor[i] / teor[massiv.Length-1];
            }



            string s;
            double alpha = 0.0, Dn_plus = 0.0, Dn_minus = 0.0;
            if (N < 30) alpha = 0.3;
            if (N >= 30 && N <= 100) alpha = 0.1;
            if (N > 100) alpha = 0.05;
            for (int i = 0; i < N; i++)
            {
                double b = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        b++;
                    }
                }
                double test = b / massiv.Length; 
                if (Dn_plus < Math.Abs(b / massiv.Length - (double)teor[i]))
                    Dn_plus = Math.Abs(b / massiv.Length - (double)teor[i]);
                if (i > 0)
                    if (Dn_minus < Math.Abs(b / massiv.Length - (double)teor[i - 1]))
                        Dn_minus = Math.Abs(b / massiv.Length - (double)teor[i - 1]);
            }
            double z = Math.Sqrt(N) * Math.Max(Dn_minus, Dn_plus);
            int k = 1;
            double sum0, sum = 0, f1, f2;
            do
            {
                sum0 = sum;
                f1 = k * k - 0.5 * (1 - Math.Pow(-1, k));
                f2 = 5 * k * k + 22 - 7.5 * (1 - Math.Pow(-1, k));
                sum += Math.Pow(-1, k) * Math.Exp(-2 * k * k * z * z) * (1 - (2 * k * k * z) / (3 * Math.Sqrt(N)) - (8 * Math.Pow(k * z, 4) + k * k * z * z * (f1 - 4 * (f1 + 3))) / (18 * N) + (k * k * z * (f2 * f2 / 5 - 4 * k * k * z * z * (f2 + 45) / 15 + 8 * Math.Pow(k * z, 4))) / (27 * Math.Pow(N, 3.0 / 2.0)));
                k++;
            } while (Math.Abs(sum - sum0) > 0.001);
            double Kz = 1 + 2 * sum;
            double Pz = 1 - Kz;
            s = "Для експоненціального розподілу статистика критерію Колмогорова z = " + z.ToString() + ".\nЙмовірність узгодження P(z) = " + Pz.ToString();
            if (Pz >= alpha)
                s = s + ".\nЗа уточненим критерієм Колмогорова емпірична функція збігається з теоретичною.";
            else
                s = s + ".\nЗа уточненим критерієм Колмогорова емпірична функція НЕ збігається з теоретичною.";

            label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
        }
        void kolmog_veib()
        {
            int N = massiv.Length;
            double a11 = N - 1;
            double a21 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                a21 += Math.Log(massiv[i]);
            }

            double a12 = a21;
            double a22 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                a22 += Math.Pow(Math.Log(massiv[i]), 2);
            }

            double b1 = 0, b2 = 0;

            for (int i = 0; i < N - 1; i++)
            {
                double a = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a++;
                    }
                }
                b1 += Math.Log(Math.Log(1 / (1 - a / N)));
            }

            for (int i = 0; i < N - 1; i++)
            {
                double a = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a++;
                    }
                }
                b2 += Math.Log(massiv[i]) * Math.Log(Math.Log(1 / (1 - a / N)));
            }

            double beta_kr = (a11 * b2 - a21 * b1) / (a11 * a22 - a12 * a21);
            double A_kr = (b1 - a12 * beta_kr) / a11;
            double alfa_kr = Math.Exp((-1) * A_kr);
            string s;
            double alpha = 0.0, Dn_plus = 0.0, Dn_minus = 0.0;
            if (N < 30) alpha = 0.3;
            if (N >= 30 && N <= 100) alpha = 0.1;
            if (N > 100) alpha = 0.05;
            for (int i = 0; i < N; i++)
            {
                double a = 0;
                for (int j = 0; j < massiv.Length; j++)
                {
                    if (massiv[j] <= massiv[i])
                    {
                        a++;
                    }
                }
                //MessageBox.Show((a / massiv.Length).ToString() +" "+ (1 - Math.Exp(-Math.Pow(i, beta_kr) / alfa_kr)).ToString());
                if (Dn_plus < Math.Abs(a / massiv.Length - 1 + Math.Exp(-Math.Pow(massiv[i], beta_kr) / alfa_kr)))
                    Dn_plus = Math.Abs(a / massiv.Length - 1 + Math.Exp(-Math.Pow(massiv[i], beta_kr) / alfa_kr));
                if (i > 0)
                    if (Dn_minus < Math.Abs(a / massiv.Length - 1 + Math.Exp(-Math.Pow(massiv[i - 1], beta_kr) / alfa_kr)))
                        Dn_minus = Math.Abs(a / massiv.Length - 1 + Math.Exp(-Math.Pow(massiv[i - 1], beta_kr) / alfa_kr));
            }
            double z = 0;
            if (Dn_minus > Dn_plus)
            {
                z = Math.Sqrt(N) * Dn_minus;
            }
            else
            {
                z = Math.Sqrt(N) * Dn_plus;
            }
            int k = 1;
            double sum0, sum = 0, f1, f2;
            do
            {
                sum0 = sum;
                f1 = k * k - 0.5 * (1 - Math.Pow(-1, k));
                f2 = 5 * k * k + 22 - 7.5 * (1 - Math.Pow(-1, k));
                sum += Math.Pow(-1, k) * Math.Exp(-2 * k * k * z * z) * (1 - (2 * k * k * z) / (3 * Math.Sqrt(N)) - (8 * Math.Pow(k * z, 4) + k * k * z * z * (f1 - 4 * (f1 + 3))) / (18 * N) + (k * k * z * (f2 * f2 / 5 - 4 * k * k * z * z * (f2 + 45) / 15 + 8 * Math.Pow(k * z, 4))) / (27 * Math.Pow(N, 3.0 / 2.0)));
                k++;
            } while (Math.Abs(sum - sum0) > 0.001);
            double Kz = 1 + 2 * sum;
            double Pz = 1 - Kz;
            s = "Для розподілу Вейбулла статистика критерію Колмогорова z = " + z.ToString() + ".\nЙмовірність узгодження P(z) = " + Pz.ToString();
            if (Pz >= alpha)
                s = s + ".\nЗа уточненим критерієм Колмогорова емпірична функція збігається з теоретичною.";
            else
                s = s + ".\nЗа уточненим критерієм Колмогорова емпірична функція НЕ збігається з теоретичною.";

            label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            kolmog_exp();
            //kolmog_norm();
            kolmog_veib();
        }

        #endregion

        //побудування вибраної вибірки
        private void побудуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView4.CurrentCell.RowIndex;
            massiv = new double[list_mass[index].Length];
            for (int i = 0; i < list_mass[index].Length; i++)
            {
                massiv[i] = list_mass[index][i];
            }
        }

        //видалення вибірки
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView4.CurrentCell.RowIndex;

            list_mass.RemoveAt(index);
        }

        //очищення журналу
        private void button14_Click(object sender, EventArgs e)
        {
            label18.Text = "Резульати оцінок:\n";
        }

        //дві вибірки
        #region дві вибірки
        double[,] rang1(double[] mass1)
        {
            Array.Sort(mass1);
            ////////////

            double[] rung_sum_mass = new double[mass1.Length];

            for (int i = 0; i < mass1.Length; i++)
            {
                rung_sum_mass[i] = i + 1;
            }
            ///////////////


            for (int i = 0; i < mass1.Length; i++)
            {
                if (rung_sum_mass[i] == mass1.Length)
                {
                    rung_sum_mass[i] = i + 1;
                    break;
                }
                if (mass1[i] == mass1[i + 1])
                {
                    int num = 0;
                    for (int j = i; j < mass1.Length; j++)
                    {
                        if (j == mass1.Length)
                        {
                            num++;
                            break;
                        }
                        if (mass1[i] == mass1[j])
                            num++;
                    }

                    double sum_ar_el = 0;

                    for (int j = i; j <= i + num - 1; j++)
                    {
                        sum_ar_el += rung_sum_mass[j];
                    }
                    sum_ar_el = sum_ar_el / num;
                    for (int j = i; j <= i + num - 1; j++)
                    {
                        rung_sum_mass[j] = sum_ar_el;
                    }
                    i = i + num - 1;
                }
                else
                {
                    rung_sum_mass[i] = i + 1;
                }
            }

            double[,] big_mass = new double[mass1.Length, 1];
            for(int i = 0; i < mass1.Length; i++)
            {
                big_mass[i, 0] = mass1[i];
                big_mass[i, 1] = rung_sum_mass[i];
            }

            return big_mass;
        }
        
        private void button18_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(rang1(list_mass[0], list_mass[1]));
            if (textBox12.Text == "" && textBox13.Text == "")
            {
                string message = "Не вибрані вибірки для перевірки!";
                string caption = "Помилка вхідних даних!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return;
            }

            int N1 = list_mass[Convert.ToInt32(textBox12.Text) - 1].Length;
            int N2 = list_mass[Convert.ToInt32(textBox13.Text) - 1].Length;
            int N = N1 + N2;

            if (comboBox1.Text == "Вілкоксона")
            {
                double W = 0;

                double[] sum_mass = new double[list_mass[Convert.ToInt32(textBox12.Text) - 1].Length + list_mass[Convert.ToInt32(textBox13.Text) - 1].Length];
                for(int i = 0; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i++)
                {
                    sum_mass[i] = list_mass[Convert.ToInt32(textBox12.Text) - 1][i];
                }

                for (int i = list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length + list_mass[Convert.ToInt32(textBox13.Text) - 1].Length; i++)
                {
                    sum_mass[i] = list_mass[Convert.ToInt32(textBox13.Text) - 1][i] - list_mass[Convert.ToInt32(textBox12.Text) - 1].Length;
                }


                for (int i = 0; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i++)
                {
                    if (list_mass[Convert.ToInt32(textBox12.Text) - 1][i] == rang1(sum_mass)[i, 0])
                    {
                        W += rang1(sum_mass)[i, 1];
                    }
                    //W += rang1(list_mass[Convert.ToInt32(textBox12.Text) - 1])[i];
                }

                double E_W = N1 * (N + 1) / 2;
                double D_W = N1 * N2 * (N + 1) / 12;
                double w = (W - E_W) / Math.Sqrt(D_W);

                string s = "";
                if (w > Quantil.NormalQuantil())
                {
                    s = "\nТест за критерієм Вілкоксона не пройдено.\n";
                }
                else
                {
                    s = "\nТест за критерієм Вілкоксона пройдено.\n   w = " + w.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox1.Text == "Мана-Уїтні")
            {
                int z = 0;
                double u = 0;
                for (int j = 0; j < N2; j++)
                {
                    for (int i = 0; i < N1; i++)
                    {
                        if (list_mass[Convert.ToInt32(textBox12.Text) - 1][i] > list_mass[Convert.ToInt32(textBox13.Text) - 1][j])
                        {
                            z = 1;
                        }
                        else if (list_mass[Convert.ToInt32(textBox12.Text) - 1][i] <= list_mass[Convert.ToInt32(textBox13.Text) - 1][j])
                        {
                            z = 0;
                        }
                        u += z;
                    }
                }

                double E_W = N1 * N2 / 2;
                double D_W = N1 * N2 * (N + 1) / 12;
                double w = (u - E_W) / Math.Sqrt(D_W);

                string s = "";
                if (w > Quantil.NormalQuantil())
                {
                    s = "\nТест за критерієм Мана-Уїтні не пройдено.\n";
                }
                else
                {
                    s = "\nТест за критерієм Мана-Уїтні пройдено.\n    w = " + w.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox1.Text == "Різниці середніх рангів")
            {
                double[] sum_mass = new double[list_mass[Convert.ToInt32(textBox12.Text) - 1].Length + list_mass[Convert.ToInt32(textBox13.Text) - 1].Length];
                for (int i = 0; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i++)
                {
                    sum_mass[i] = list_mass[Convert.ToInt32(textBox12.Text) - 1][i];
                }

                for (int i = list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length + list_mass[Convert.ToInt32(textBox13.Text) - 1].Length; i++)
                {
                    sum_mass[i] = list_mass[Convert.ToInt32(textBox13.Text) - 1][i] - list_mass[Convert.ToInt32(textBox12.Text) - 1].Length;
                }

                double sum_r1 = 0;
                for (int i = 0; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i++)
                {
                    if (list_mass[Convert.ToInt32(textBox12.Text) - 1][i] == rang1(sum_mass)[i, 0])
                    {
                        sum_r1 += rang1(sum_mass)[i, 1];
                    }
                }
                sum_r1 = sum_r1 / N1;

                double sum_r2 = 0;
                for (int i = 0; i < list_mass[Convert.ToInt32(textBox13.Text) - 1].Length; i++)
                {
                    if (list_mass[Convert.ToInt32(textBox13.Text) - 1][i] == rang1(sum_mass)[i, 0])
                    {
                        sum_r2 += rang1(sum_mass)[i, 1];
                    }
                }
                sum_r2 = sum_r2 / N2;

                double nyu = Math.Abs((sum_r1 - sum_r2) / (N * Math.Sqrt((N + 1) / (12 * N1 * N2))));

                string s = "";
                if (nyu > Quantil.NormalQuantil())
                {
                    s = "\nТест за критерієм Мана-Уїтні не пройдено.\n";
                }
                else
                {
                    s = "\nТест за критерієм Мана-Уїтні пройдено.\n    y = " + nyu.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox1.Text == "Критерій знаків")
            {
                if(list_mass[Convert.ToInt32(textBox12.Text)].Length != list_mass[Convert.ToInt32(textBox13.Text)].Length)
                {
                    MessageBox.Show("Розмір вибірок не однаковий!");
                    return;
                }
                double[] zl = new double[N1];
                int[] U = new int[N1];
                int nan = N1;

                for(int i = 0; i < N1; i++)
                {
                    zl[i] = list_mass[Convert.ToInt32(textBox12.Text) - 1][i] - list_mass[Convert.ToInt32(textBox13.Text) - 1][i];
                    if (zl[i] > 0) U[i] = 1;
                    else U[i] = 0;
                }

                int zero = 0;
                for (int l = 0; l < zl.Length; l++)
                    if (zl[l] == 0)
                        zero++;
                nan = N1 - zero;

                int S = 0;

                for (int l = 0; l < U.Length; l++)
                {
                    S += U[l];
                }
                double S_Zirka = 0;

                if (nan > 15)
                    S_Zirka = (2 * S - 1 - nan) / Math.Sqrt(nan);

                string s = "";
                if (S_Zirka > Quantil.NormalQuantil())
                {
                    s = "\nТест за критерієм знаків не пройдено.\n";
                }
                else
                {
                    s = "\nТест за критерієм знаків пройдено.\n   S* = " + S_Zirka.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            #region Abbe
            else if (comboBox1.Text == "Критерій Аббе")
            {
                if(textBox12.Text != "" || textBox13.Text != "")
                {
                    double d = 0;
                    double[] array1 = list_mass[Convert.ToInt32(textBox12.Text) - 1];
                    double[] array2 = list_mass[Convert.ToInt32(textBox13.Text) - 1];
                    double[] array = new double[array1.Length];
                    int just_N = list_mass[Convert.ToInt32(textBox12.Text) - 1].Length;

                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = array1[i] - array2[i];
                    }

                    for (int i = 0; i < just_N - 1; i++)
                    {
                        d += Math.Pow((array[i + 1] - array[i]), 2);
                    }

                    d = (1.0 / (just_N - 1)) * d;
                    double S = dispersion(array);
                    double q = (d) / (2 * S);
                    double U = (q - 1) * Math.Sqrt((just_N * just_N - 1) / (just_N - 2));

                    string s = "";
                    if (U < Quantil.NormalQuantil())
                    {
                        s = "\nТест за критерієм Аббе дані величини незалежні.\n   U = " + U.ToString() + "\n";
                    }
                    else
                    {
                        s = "\nТест за критерієм Аббе дані величини незалежні.\n   U = " + U.ToString() + "\n";
                    }
                    label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
                }
                if(textBox12.Text == "")
                {
                    double d = 0;
                    double[] array = list_mass[Convert.ToInt32(textBox13.Text) - 1];
                    int just_N = list_mass[Convert.ToInt32(textBox12.Text) - 1].Length;
                    for (int i = 0; i < just_N - 1; i++)
                    {
                        d += Math.Pow((array[i + 1] - array[i]), 2);
                    }
                    d = (1.0 / (just_N - 1)) * d;
                    double S = dispersion(array);
                    double q = (d) / (2 * S);
                    double U = (q - 1) * Math.Sqrt((just_N * just_N - 1) / (just_N - 2));

                    string s = "";
                    if (U < Quantil.NormalQuantil())
                    {
                        s = "\nТест за критерієм Аббе дана величина незалежна.\n   U = " + U.ToString() + "\n";
                    }
                    else
                    {
                        s = "\nТест за критерієм Аббе дана величина незалежна.\n   U = " + U.ToString() + "\n";
                    }
                    label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
                }
                else if(textBox13.Text == "")
                {
                    double d = 0;
                    double[] array = list_mass[Convert.ToInt32(textBox12.Text) - 1];
                    int just_N = list_mass[Convert.ToInt32(textBox12.Text) - 1].Length;
                    for (int i = 0; i < just_N - 1; i++)
                    {
                        d += Math.Pow((array[i + 1] - array[i]), 2);
                    }
                    d = (1.0 / (just_N - 1)) * d;
                    double S = dispersion(array);
                    double q = (d) / (2 * S);
                    double U = (q - 1) * Math.Sqrt((just_N * just_N - 1) / (just_N - 2));

                    string s = "";
                    if (U < Quantil.NormalQuantil())
                    {
                        s = "\nТест за критерієм Аббе дана величина незалежна.\n   U = " + U.ToString() + "\n";
                    }
                    else
                    {
                        s = "\nТест за критерієм Аббе дана величина незалежна.\n   U = " + U.ToString() + "\n";
                    }
                    label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
                }
            }
            #endregion
            else if (comboBox1.Text == "Збіг середніх(залежні вибірки)")
            {
                if(Convert.ToInt32(textBox12.Text) != Convert.ToInt32(textBox13.Text))
                {
                    MessageBox.Show("Розмір вибірок не однаковий!");
                    return;
                }
                double[] z = new double[Convert.ToInt32(textBox12.Text) - 1];

                for(int i = 0; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i++)
                {
                    z[i] = list_mass[Convert.ToInt32(textBox12.Text) - 1][i] - list_mass[Convert.ToInt32(textBox13.Text) - 1].Length;
                }

                double z_ser = ser_ar(z);
                double z_disp = dispersion(z);

                double t = Math.Abs(z_ser * Math.Sqrt(z.Length) / Math.Sqrt(z_disp));

                string s = "";
                if (t > Quantil.StudentQuantil(z.Length, z))
                {
                    s = "\nЗначення статистики t потрапило до критичної області, отже результат перевірки на збіг середніх негативний.\n   Статистика t = " + t.ToString() + "\n";
                }
                else
                {
                    s = "\nРезультат перевірки на збіг середніх позитивний.\n    Статистика t = " + t.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox1.Text == "Збіг середніх(незалежні вибірки)")
            {
                if (Convert.ToInt32(textBox12.Text) == Convert.ToInt32(textBox13.Text))
                {
                    MessageBox.Show("Дані вибірки є залежними!");
                    return;
                }

                double z_ser = ser_ar(list_mass[Convert.ToInt32(textBox12.Text) - 1]) - ser_ar(list_mass[Convert.ToInt32(textBox13.Text) - 1]);

                double Sx = dispersion(list_mass[Convert.ToInt32(textBox12.Text) - 1]);
                double Sy = dispersion(list_mass[Convert.ToInt32(textBox13.Text) - 1]);

                double Sz = Sx / list_mass[Convert.ToInt32(textBox12.Text) - 1].Length + Sy / list_mass[Convert.ToInt32(textBox13.Text) - 1].Length;
                double t = z_ser / Math.Sqrt(Sz);

                string s = "";

                double[] new_mas = new double[list_mass[Convert.ToInt32(textBox12.Text) - 1].Length + list_mass[Convert.ToInt32(textBox13.Text) - 1].Length];
                for(int i = 0; i < list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i++)
                {
                    new_mas[i] = list_mass[Convert.ToInt32(textBox12.Text) - 1][i];
                }
                for (int i = list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i < list_mass[Convert.ToInt32(textBox13.Text) - 1].Length + list_mass[Convert.ToInt32(textBox12.Text) - 1].Length; i++)
                {
                    new_mas[i] = list_mass[Convert.ToInt32(textBox13.Text) - 1][i - list_mass[Convert.ToInt32(textBox12.Text) - 1].Length];
                }

                if (t > Quantil.StudentQuantil(N - 2, new_mas))
                {
                    s = "\nЗначення статистики t потрапило до критичної області, отже результат перевірки на збіг середніх негативний.\n   Статистика t = " + t.ToString() + "\n";
                }
                else
                {
                    s = "\nРезультат перевірки на збіг середніх позитивний.\n    Статистика t = " + t.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox1.Text == "Збіг дисперсій")
            {
                double disp_x = dispersion(list_mass[Convert.ToInt32(textBox12.Text) - 1]);
                double disp_y = dispersion(list_mass[Convert.ToInt32(textBox13.Text) - 1]);
                double f = 0;

                if(disp_x >= disp_y)
                {
                    f = disp_x / disp_y;
                }
                else
                {
                    f = disp_y / disp_x;
                }

                string s = "";
                if (f > Quantil.QuantilFishera(list_mass[Convert.ToInt32(textBox12.Text)].Length - 2, list_mass[Convert.ToInt32(textBox13.Text)].Length - 2))
                {
                    s = "\nЗначення статистики f потрапило до критичної області, отже результат перевірки на збіг дисперсій негативний.\n   Статистика f = " + f.ToString() + "\n";
                }
                else
                {
                    s = "\nРезультат перевірки на збіг дисперсій позитивний.\n    Статистика f = " + f.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox1.Text == "Смирнова-Колмогорова")
            {/*
                int N_ = Math.Min(list_mass[Convert.ToInt32(textBox12.Text) - 1].Length, list_mass[Convert.ToInt32(textBox13.Text) - 1].Length);

                double z = Math.Abs(Rozpodil_F(index1, Array_number_variation[0][0]) - Rozpodil_F(index2, Array_number_variation[0][0]));
                for (int i = 1; i < M; i++)
                {
                    if (z > Math.Abs((Rozpodil_F(index1, Array_number_variation[0][i])) - (Rozpodil_F(index2, Array_number_variation[0][i])))) ;
                    z = Math.Abs((Rozpodil_F(index1, Array_number_variation[0][i])) - (Rozpodil_F(index2, Array_number_variation[0][i])));  // supremum від чогось just assk another person
                }
                double L = 1 - Math.Exp(-2 * z * z) * (1 - (2 * z) / (3 * Math.Sqrt(just_N)) * (1 - (2 * z * z) / 3) + (4 * z / (9 * Math.Sqrt(Math.Pow(just_N, 3)))) * (1.0 / 5 - (19 * z * z) / 15 + (2 * z * z * z * z) / 3));
                */
                /*for (int i = 0; i < massiv.Length; i++)
                {
                    double a = 0;
                    for (int j = 0; j < massiv.Length; j++)
                    {
                        if (massiv[j] <= massiv[i])
                        {
                            a++;
                        }
                    }

                    chart2.Series["points"].Points.AddXY(Math.Round(massiv[i], 4), a / massiv.Length);
                }*/
            }
            else
            {
                MessageBox.Show("Невірно вибрано критерій!");
                return;
            }
        }


        #endregion

        //більше вибірок
        private void button19_Click(object sender, EventArgs e)
        {
            if (list_mass.Count() <= 2)
            {
                string message = "Занадто мало вибірок!";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
                return;
            }

            if (comboBox2.Text == "Бартлетта")
            {
                double[] x_ser = new double[list_mass.Count()];
                double[] disp = new double[list_mass.Count()];

                for(int i = 0; i < list_mass.Count(); i++)
                {
                    for(int j = 0; j < list_mass[i].Length; j++)
                    {
                        x_ser[i] += list_mass[i][j];
                    }
                    x_ser[i] = x_ser[i] / list_mass.Count(); 
                }

                for (int i = 0; i < list_mass.Count(); i++)
                {
                    for (int j = 0; j < list_mass[i].Length; j++)
                    {
                        disp[i] += Math.Pow((list_mass[i][j] - x_ser[i]), 2);
                    }

                    disp[i] = (1.0 / (list_mass[i].Length - 1.0)) * disp[i];
                }

                double top = 0;
                double bot = 0;
                double S_stat = 0;
                double B = 0;
                double C = 0;
                double X_stat = 0;
                for (int i = 0; i < list_mass.Count(); i++)
                {
                    top += (list_mass[i].Length - 1) * disp[i];
                    bot += (list_mass[i].Length - 1);
                }
                S_stat = top / bot;

                for (int i = 0; i < list_mass.Count(); i++)
                {
                    B += (list_mass[i].Length - 1) * Math.Log(disp[i] / S_stat);
                }
                B = B * -1;

                double temp1 = 0;
                double temp2 = 0;
                for (int i = 0; i < list_mass.Count(); i++)
                {
                    temp1 += 1.0 / (list_mass[i].Length - 1);
                    temp2 += (list_mass[i].Length - 1);
                }

                C = 1 + 1.0 / (3 * (list_mass.Count() - 1)) * (temp1 - 1.0 / temp2);
                X_stat = B / C;

                double nu = list_mass.Count() - 1;
                double hik = (nu) * Math.Pow(1 - 2.0 / (9 * nu) + Quantil.NormalQuantil() * Math.Sqrt(2.0 / (9.0 * nu)), 3);

                string s = "";
                if (X_stat > hik)
                {
                    s = "\nТест за критерієм Бартлетта не пройдено.\n";
                }
                else
                {
                    s = "\nТест за критерієм Бартлетта пройдено.\n   X-статистичне = " + X_stat.ToString() + "\n"+ "Квантиль Хі = " + hik.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox2.Text == "Однофакторний дисперсійний аналіз")
            {
                double Stat_S = 0;
                double[] x_average = new double[list_mass.Count()];
                double[] disp = new double[list_mass.Count()];
                double Total_x_average = 0;
                for (int i = 0; i < list_mass.Count(); i++)
                {
                    for (int j = 0; j < list_mass[i].Length; j++)
                        x_average[i] += list_mass[i][j];

                    x_average[i] = (1.0 / list_mass[i].Length) * x_average[i];
                }

                for (int i = 0; i < list_mass.Count(); i++)
                    Total_x_average += list_mass[i].Length * x_average[i];

                int Total_count = 0;
                for (int i = 0; i < list_mass.Count(); i++)
                {
                    Total_count += list_mass[i].Length;
                }

                Total_x_average = (1.0 / Total_count) * Total_x_average;

                for (int i = 0; i < list_mass.Count(); i++)
                {
                    Stat_S += list_mass[i].Length * Math.Pow((x_average[i] - Total_x_average), 2);
                }
                Stat_S = 1.0 / (list_mass.Count() - 1) * Stat_S;

                double Stat_S_2 = 0;

                for (int i = 0; i < list_mass.Count(); i++)
                {
                    Stat_S_2 += (list_mass[i].Length - 1) * dispersion(list_mass[i]);
                }
                Stat_S_2 = 1.0 / (Total_count - list_mass.Count()) * Stat_S_2;

                double F = Stat_S / Stat_S_2;
                double kv = Quantil.QuantilFishera(list_mass.Count() - 1, Total_count - list_mass.Count());

                string s = "";
                if (kv < F)
                {
                    s = "\nОднофакторний дисперсійний аналіз не пройдено.\n";
                }
                else
                {
                    s = "\nОднофакторний дисперсійний аналіз пройдено.\n   Статистика F = " + F.ToString() + "\n" + "Квантиль F = " + kv.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox2.Text == "Кохрена")
            {
                double[][] koh = new double[list_mass.Count()][];
                for (int i = 0; i < koh.Length; i++)
                    koh[i] = (double[])list_mass[i].Clone();

                double aver;
                for (int i = 0; i < koh.Length; i++)
                {
                    aver = ser_ar(koh[i]);
                    for (int j = 0; j < koh[i].Length; j++)
                    {
                        if (koh[i][j] > aver) koh[i][j] = 1;
                        else koh[i][j] = 0;
                    }
                }
                int k = koh.Length;
                double Q;
                double[] U = new double[koh[0].Length];
                double[] T = new double[k];
                for (int i = 0; i < koh[0].Length; i++)
                {
                    U[i] = 0;
                    for (int j = 0; j < koh.Length; j++)
                        U[i] += koh[j][i];
                }

                for (int i = 0; i < koh.Length; i++)
                    for (int j = 0; j < koh[i].Length; j++)
                        T[i] += koh[i][j];

                double Total_T = 0;
                for (int i = 0; i < k; i++)
                    Total_T += T[i];

                Total_T = (1.0 / (k)) * Total_T;
                double sumT = 0;
                double sumu = 0;
                double sumu2 = 0;
                for (int i = 0; i < T.Length; i++)
                {
                    sumT += Math.Pow((T[i] - Total_T), 2);
                }
                Array.Sort(U);
                for (int i = 0; i < U.Length; i++)
                {
                    sumu += U[i];
                    sumu2 += Math.Pow(U[i], 2);
                }
                Q = (k * (k - 1) * sumT) / (k * sumu - sumu2);
                double kv = Quantil.NormalQuantil();
                double nu = k - 1;
                double hik = (nu) * Math.Pow(1 - 2.0 / (9 * nu) + kv * Math.Sqrt(2.0 / (9.0 * nu)), 3);

                string s = "";
                if (hik < Q)
                {
                    s = "\nОднофакторний дисперсійний аналіз не пройдено.\n";
                }
                else
                {
                    s = "\nОднофакторний дисперсійний аналіз пройдено.\n   Статистика Q = " + Q.ToString() + "\n" + "Квантиль Xi = " + hik.ToString() + "\n";
                }
                label18.Text += "\n-----------------------------------\n" + s + "\n-----------------------------------\n";
            }
            else if (comboBox2.Text == "Н-критерій")
            {/*
                int size = 0;
                for(int i = 0; i < list_mass.Count(); i++)
                {
                    size += list_mass[i].Length;
                }

                double[] sum_mass = new double[size];
                string s = "";
                for(int i = 0; i < list_mass.Count(); i++)
                {
                    for(int j = 0; j < list_mass[i].Length; j = j + list_mass[i].Length)
                    {
                        sum_mass[j] = list_mass[i][j] - list_mass[i].Length;
                        s += sum_mass[j].ToString() + " ";
                    }
                }
                MessageBox.Show(s);*/
            }
            else
            {
                MessageBox.Show("Невірно вибрано критерій!");
                return;
            }
        }
    }

    public class Quantil
    {
        static public double QuantilFishera(int N1, int N2)
        {
            double res;
            double norm_kv = Quantil.NormalQuantil();
            double sig = (1.0 / N1) + (1.0 / N2);
            double delta = (1.0 / N1) - (1.0 / N2);
            res = norm_kv * Math.Sqrt(sig / 2.0);
            res -= (1.0 / 6) * delta * (Math.Pow(norm_kv, 2) + 2);
            res += Math.Sqrt(sig / 2.0) * ((sig / 24) * (Math.Pow(norm_kv, 2) + 3 * norm_kv) + (1.0 / 72) * (delta * delta / sig) * (Math.Pow(norm_kv, 3) + 11 * norm_kv));
            res -= (delta * sig / 120) * (Math.Pow(norm_kv, 4) + 9 * Math.Pow(norm_kv, 2) + 8);
            res += Math.Pow(delta, 3) / (sig * 3240) * (3 * Math.Pow(norm_kv, 4) + 7 * Math.Pow(norm_kv, 2) - 16);
            res += Math.Sqrt(sig / 2.0) * ((Math.Pow(sig, 2) / 1920) * (Math.Pow(norm_kv, 5) + 20 * Math.Pow(norm_kv, 3) + 15 * norm_kv) + (Math.Pow(delta, 4) / 2880) * (Math.Pow(norm_kv, 5) + 44 * Math.Pow(norm_kv, 3) + 183 * norm_kv) + (Math.Pow(delta, 4) / (155520 * sig * sig)) * (9 * Math.Pow(norm_kv, 5) - 284 * Math.Pow(norm_kv, 3) - 1513 * norm_kv));
            res = Math.Exp(2 * res);
            return res;
        }

        static public double NormalQuantil()
        {
            double p = 0.025;
            double t = Math.Sqrt(Math.Log(1 / Math.Pow(p, 2)));
            double Ealpha = 4.5 * Math.Pow(10, -4);
            double c0 = 2.515517;
            double c1 = 0.802853;
            double c2 = 0.010328;
            double d1 = 1.432788;
            double d2 = 0.1892659;
            double d3 = 0.001308;
            double u = t - ((c0 + c1 * t + c2 * Math.Pow(t, 2)) / (1 + d1 * t + d2 * Math.Pow(t, 2) + d3 * Math.Pow(t, 3))) + Ealpha;
            return u;
        }

        static public double StudentQuantil(double sum, double[] A)
        {
            double g1 = (Math.Pow(NormalQuantil(), 3) + NormalQuantil()) / 4;
            double g2 = (5 * Math.Pow(NormalQuantil(), 5) + 16 * Math.Pow(NormalQuantil(), 3) + 3 * NormalQuantil()) / 96;
            double g3 = (3 * Math.Pow(NormalQuantil(), 7) + 19 * Math.Pow(NormalQuantil(), 5) + 17 * Math.Pow(NormalQuantil(), 3) + 15 * NormalQuantil()) / 384;
            double g4 = (79 * Math.Pow(NormalQuantil(), 9) + 779 * Math.Pow(NormalQuantil(), 7) + 1482 * Math.Pow(NormalQuantil(), 5) + 1920 * Math.Pow(NormalQuantil(), 3) + 945 * NormalQuantil()) / 92160;
            double SQ = NormalQuantil() + (g1 / start_moment(1, A) + (g2 / start_moment(2, A)) + (g3 / start_moment(3, A)) + (g4 / start_moment(4, A)));
            return SQ;
        }

        static double start_moment(int k, double[] mass)
        {
            double nyu = 0;

            for (int i = 0; i < mass.Length; i++)
            {
                nyu += Math.Pow(mass[i], k);
            }
            return nyu / mass.Length;
        }

        double central_moment(int k, double[] mass)
        {
            double myu = 0;

            for (int i = 0; i < mass.Length; i++)
            {
                myu += Math.Pow(mass[i] - start_moment(1, mass), k);
            }

            return myu / mass.Length;
        }
    }
}