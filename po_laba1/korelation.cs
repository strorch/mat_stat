using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace po_laba1
{
    class korelation
    {
        static public double koef_kor(double[] first, double[] second)
        {
            int N = first.Length;
            double var = 0;

            for (int i = 0; i < N; i++)
                var += first[i] * second[i];
            var = var / N;
            return (N) * (var - ser_ar(first) * ser_ar(second)) / ((N - 1) * Math.Sqrt(dispersion(first)) * Math.Sqrt(dispersion(second)));
        }

        static public double ser_ar(double[] mass)
        {
            double ser_ar = 0;
            double ga = 0;
            for (int i = 0; i < mass.Length; i++)
                ga += mass[i];

            ser_ar = Math.Round(ga / mass.Length, 4);
            return ser_ar;
        }

        static public double dispersion(double[] mass)
        {
            double[] mass_disp = new double[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                mass_disp[i] = Math.Pow((mass[i] - korelation.ser_ar(mass)), 2);
            }
            double gb = 0;
            for (int i = 0; i < mass_disp.Length; i++)
                gb += mass_disp[i];
            return Math.Round(gb / (mass_disp.Length - 1), 4);
        }
        static public double korel_vidn(double[] arr1)
        {
            int numclass = korelation.num_class(arr1);
            double min = korelation.min1(arr1);
            double disp = korelation.dispersion(arr1);
            double step = (korelation.max1(arr1) - korelation.min1(arr1)) / korelation.num_class(arr1);
            double sum = 0;

            for (int i = 0; i < numclass; i++)
            {
                sum += korelation.num_y(arr1, min, min + step) * Math.Pow(ser_ar(arr1) - ser_y(arr1, min, min + step), 2);
                min = min + step;
            }
            return sum / (disp * (arr1.Length - 1));
        }

        static double ser_y(double[] arr, double min, double max)
        {
            double sum = 0;
            int num = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= min && arr[i] <= max)
                {
                    sum += arr[i];
                    num++;
                }
            }
            return sum / num;
        }

        static int num_y(double[] arr, double min, double max)
        {
            int num = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= min && arr[i] <= max)
                    num++;
            }
            return (num);
        }

        static public void Sort(double[] X, double[] Y, int length)
        {
            double temp1 = 0;
            double temp2 = 0;
            bool exit = false;

            while (!exit)
            {
                exit = true;
                for (int i = 0; i < (length - 1); i++)
                {
                    if (X[i] > X[i + 1])
                    {
                        temp1 = X[i];
                        X[i] = X[i + 1];
                        X[i + 1] = temp1;

                        temp2 = Y[i];
                        Y[i] = Y[i + 1];
                        Y[i + 1] = temp2;
                        exit = false;
                    }
                }
            }
        }
        static public int num_class(double[] arr)
        {
            int numclass = 0;
            if (arr.Length < 100)
            {
                int kakaha = (int)Math.Truncate(Math.Sqrt(arr.Length));
                if (kakaha % 2 == 0)
                    numclass = kakaha - 1;
                else
                    numclass = kakaha;
            }
            else
            {
                double kakaha = Math.Truncate(Math.Pow(arr.Length, 1.0 / 3.0));
                if (kakaha % 2 == 0)
                    numclass = (int)kakaha - 1;
                else
                    numclass = (int)kakaha;
            }
            return numclass;
        }

        static public double max1(double[] A)
        {
            double m = A[0];
            int i = 0;
            for (; i < A.Length; i++)
                if (m < A[i])
                    m = A[i];
            return m;
        }

        static public double min1(double[] A)
        {
            double m = A[0];
            int i = 0;
            for (; i < A.Length; i++)
                if (m > A[i])
                    m = A[i];
            return m;
        }
    }
}
