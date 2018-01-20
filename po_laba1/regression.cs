using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace po_laba1
{
    class regression
    {
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
