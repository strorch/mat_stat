using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace po_laba1
{
    class regression
    {
        #region Validating statistic
        private static int num_in_class(double[] X, double min, double step)
        {
            int num = 0;
            for (int i = 0; i < X.Length; i++)
            {
                if (X[i] >= min && X[i] < min + step)
                    num++;
            }
            return num;
        }
        public static double[]   SerArr(double[][] arr)
        {
            double[] new_arr = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                new_arr[i] = korelation.ser_ar(arr[i]);
            return new_arr;
        }
        public static double[][] VidnArr(double[] X, double[] Y)
        {
            int numclass = korelation.num_class(X);
            double[][] new_arr = new double[numclass][];
            double minX = X.Min();
            double maxX = X.Max();
            double step = (maxX - minX) / numclass;
            for (int i = 0; i < numclass; i++)
            {
                new_arr[i] = new double[regression.num_in_class(X, minX, step)];
                int k = 0;
                for (int j = 0; j < X.Length; j++)
                {
                    if (X[j] >= minX && X[j] < minX + step)
                    {
                        new_arr[i][k] = Y[j];
                        k++;
                    }
                }
                minX = minX + step;
            }
            return (new_arr);
        }
        public static int[] ArrNumbers(double[] X, double[] Y)
        {
            int numclass = korelation.num_class(X);
            int[] num = new int[numclass];
            double minX = X.Min();
            double maxX = X.Max();
            double step = (maxX - minX) / numclass;
            for (int i = 0; i < numclass; i++)
            {
                num[i] = regression.num_in_class(X, minX, step);
                minX = minX + step;
            }
            return num;
        }
        static double C(double[] X, double[] Y)
        {
            int N = X.Length;
            int numclass = korelation.num_class(X);
            int[] arrnum = ArrNumbers(X, Y);
            double sum = 0;
            for (int i = 0; i < numclass; i++)
            {
                sum += 1 / (double)arrnum[i];
            }
            return 1 + (sum - 1 / N) / (3 * (numclass - 1));
        }
        static double DispKvXY(double[] Yarr, double serY, double num)
        {
            double sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum += Math.Pow(Yarr[i] - serY, 2);
            }
            sum = sum / num;
            return sum;
        }
        static double DispKv(double[] X, double[] Y)
        {
            int N = X.Length;
            int[] numbs = ArrNumbers(X, Y);
            double sum = 0;
            int numclass = korelation.num_class(X);
            double[][] ARR = VidnArr(X, Y);
            double[] SER_Arr = SerArr(ARR);
            for (int i = 0; i < numclass; i++)
            {
                sum += (numbs[i] - 1) * DispKvXY(ARR[i], SER_Arr[i], numbs[i]);
            }
            sum = sum / (N - numclass);
            return sum;
        }
        public static double  RegresStat(double[] X, double[] Y)
        {
            double[][] MAIN_Arr = VidnArr(X, Y);
            double[] SER_Arr = SerArr(MAIN_Arr);
            int numclass = korelation.num_class(X);
            double C = regression.C(X, Y);
            double sum = 0;
            int[] ARR_N = ArrNumbers(X, Y);
            double DispKv = regression.DispKv(X, Y);
            for (int i = 0; i < numclass; i++)
            {
                double DispKvXY = regression.DispKvXY(MAIN_Arr[i], SER_Arr[i], ARR_N[i]);
                sum += ARR_N[i] * Math.Log(DispKvXY / DispKv);
            }
            return sum / (-C);
        }
        #endregion

        public static double  SzalKvLinear(double[] X, double[] Y)
        {
            int N = X.Length;
            double x_ser = korelation.ser_ar(X);
            double y_ser = korelation.ser_ar(Y);
            double sigX = Math.Sqrt(korelation.dispersion(X));
            double sigY = Math.Sqrt(korelation.dispersion(Y));
            double kor = korelation.koef_kor(X, Y);
            double b = kor * sigY / sigX;
            double a = y_ser - b * x_ser;
            double S_zal_kv = 0;
            for (int i = 0; i < N; i++)
            {
                S_zal_kv += Math.Pow(Y[i] - a - b * X[i], 2);
            }
            S_zal_kv = S_zal_kv / (N - 2);
            return S_zal_kv;
        }

        public static double SzalKvParabolic(double[] X, double[] Y)
        {
            int N = X.Length;
            double serX = korelation.ser_ar(X);
            double serY = korelation.ser_ar(Y);
            double sigX = Math.Sqrt(korelation.dispersion(Y));
            double sigY = Math.Sqrt(korelation.dispersion(Y));
            double kor = korelation.koef_kor(X, Y);
            double A1 = serY;
            double part11 = 0;
            double part21 = 0;
            for (int i = 0; i < N; i++)
            {
                part11 += (X[i] - serX) * serY;
                part21 += Math.Pow(X[i] - serX, 2);
            }
            double B1 = part11 / part21;
            part11 = 0;
            part21 = 0;
            for (int i = 0; i < N; i++)
            {
                part11 += regression.fi2(X, i) * Y[i];
                part21 += Math.Pow(regression.fi2(X, i), 2);
            }
            double C1 = part11 / part21;
            double S_zal_kv = 0;
            for (int i = 0; i < N; i++)
                S_zal_kv += Math.Pow(Y[i] - A1 - B1 * regression.fi1(X, i) - C1 * regression.fi2(X, i), 2);
            return S_zal_kv / (N - 3);
        }
        public static Tuple<double, double, double> Params(double[] X, double[] Y)
        {
            int N = X.Length;
            double serX = korelation.ser_ar(X);
            double serY = korelation.ser_ar(Y);
            double sigX = Math.Sqrt(korelation.dispersion(Y));
            double sigY = Math.Sqrt(korelation.dispersion(Y));
            double kor = korelation.koef_kor(X, Y);
            double A1 = serY;
            double part11 = 0;
            double part21 = 0;
            for (int i = 0; i < N; i++)
            {
                part11 += (X[i] - serX) * serY;
                part21 += Math.Pow(X[i] - serX, 2);
            }
            double B1 = part11 / part21;
            part11 = 0;
            part21 = 0;
            for (int i = 0; i < N; i++)
            {
                part11 += regression.fi2(X, i) * Y[i];
                part21 += Math.Pow(regression.fi2(X, i), 2);
            }
            double C1 = part11 / part21;
            return Tuple.Create(A1, B1, C1);
        }

        public static double fi1(double[] X, int i)
        {
            return X[i] - korelation.ser_ar(X);
        }
        public static double fi1(double[] X, double el)
        {
            return el - korelation.ser_ar(X);
        }
        public static double fi2(double[] X, int i)
        {
            int N = X.Length;
            double part1 = 0;
            double part2 = 0;
            double x_ser = korelation.ser_ar(X);
            for (int j = 0; j < N; j++)
            {
                part1 += Math.Pow(X[i], 2);
                part2 += Math.Pow(X[i], 3);
            }
            double some = (part2 - x_ser * part1) * (X[i] - x_ser) / (part1 - N * x_ser * x_ser);
            return X[i] * X[i] - some;
        }
        public static double fi2(double[] X, double el)
        {
            int N = X.Length;
            double part1 = 0;
            double part2 = 0;
            double x_ser = korelation.ser_ar(X);
            for (int j = 0; j < N; j++)
            {
                part1 += Math.Pow(el, 2);
                part2 += Math.Pow(el, 3);
            }
            double some = (part2 - x_ser * part1) * (el - x_ser) / (part1 - N * x_ser * x_ser);
            return Math.Pow(el, 2) - some;
        }
    }
}
