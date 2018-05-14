using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleMatrix;
using Algebra;

namespace po_laba1
{
    public class NNData
    {
        public double[,] ARR;
        public int Num;
        public int Length;
        public string file_name;
        public double[] arr_max;
        public double mnozh_koef_kor;
        public double[,] KorelationMatrix;
        public string[,] Znachushchist;
        public int kor_num = 0;

        public NNData(Tuple<double[,], int, int, string> data)
        {
            this.ARR = data.Item1;
            this.Num = data.Item2;
            this.Length = data.Item3;
            this.file_name = FileNoDir(data.Item4);
            this.arr_max = arr_max1(ARR, Length, Num);
            this.mnozh_koef_kor = mnozh_koef();
        }

        private static double mnozh_koef()
        {
            return 0;
        }

        private static double[] arr_max1(double[,] ARR, int Length, int Num)
        {
            double[] arr = new double[Num];

            for (int i = 0; i < Num; i++)
            {
                arr[i] = PartArr(ARR, Length, i).Max();
            }
            return arr;
        }

        public static string FileNoDir(string name)
        {
            string[] sep = { @"\" };
            string[] New = name.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            return New[New.Length - 1];
        }

        public static double[] PartArr(double[,] ARR, int Length, int index)
        {
            double[] new_ar = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                new_ar[i] = ARR[i, index];
            }
            return new_ar;
        }
        public static double[] PartArr1(double[,] ARR, int Num, int index)
        {
            double[] new_ar = new double[Num];
            for (int i = 0; i < Num; i++)
            {
                new_ar[i] = ARR[index, i];
            }
            return new_ar;
        }

        public double[] SerAr()
        {
            double[] ArrSer = new double[this.Num];
            for (int i = 0; i < this.Num; i++)
            {
                ArrSer[i] = korelation.ser_ar(PartArr(ARR, Length, i));
            }
            return ArrSer;
        }

        public double[] KoefKor()
        {
            List<double> kor_lst = new List<double>();
            for (int i = 0; i < this.Num; i++)
            {
                for (int j = 0; j < this.Num; j++)
                {
                    double koef = korelation.koef_kor(PartArr(ARR, Length, i), PartArr(ARR, Length, j));
                    kor_lst.Add(koef);
                }
            }
            return kor_lst.ToArray();
        }

        public double[] Sigmas()
        {
            double[] ArrSer = new double[this.Num];
            for (int i = 0; i < this.Num; i++)
            {
                ArrSer[i] = Math.Sqrt(korelation.dispersion(PartArr(ARR, Length, i)));
            }
            return ArrSer;
        }

        public static double ChastkovyyKorelation(double[,] KorelationArr, int i, int j, int d)
        {
            return (KorelationArr[i,j] - KorelationArr[i,d] * KorelationArr[j, d]) /
                Math.Sqrt((1- KorelationArr[i, d] * KorelationArr[i, d]) * (1 - KorelationArr[j, d] * KorelationArr[j, d]));
        }

        private static double[,] part_matrix(double[,] data, int index)
        {
            int N = data.GetLength(0);
            List<double> rows;
            List<List<double>> lst = new List<List<double>>();
            double[,] to_return = new double[N - 1, N - 1];
            for (int i = 0; i < N; i++)
            {
                rows = new List<double>();
                for (int j = 0; j < N; j++)
                {
                    if (i != index && j != index)
                        rows.Add(data[i, j]);
                }
                if (rows.Count() != 0)
                    lst.Add(rows);
            }
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    to_return[i, j] = lst[i][j];
                }
            }
            return to_return;
        }

        public static double MnozhynnKorelation(NNData data, int index)
        {
            double[,] new_matrix = part_matrix(data.KorelationMatrix, index);
            Matrix main_matrix = Matrix.Create.New(data.KorelationMatrix);
            Matrix little_matrix = Matrix.Create.New(new_matrix);
            return Math.Sqrt(1 - main_matrix.Determinant() / little_matrix.Determinant());
        }
    }
}
