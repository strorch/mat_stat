using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace po_laba1
{
    class Quantil
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

        static public double NormalQuantil1(double p)
        {
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

        static public double QuantilFishera1(double alpha, double v1, double v2)
        {
            double s = 1 / v1 + 1 / v2;
            double d = 1 / v1 - 1 / v2;
            double u = NormalQuantil1(alpha);
            double z = u * Math.Sqrt(s / 2) - 1 / 6.0 * d * (u * u + 2) + Math.Sqrt(s / 2) * (s / 24.0 * (u * u + 3 * u) + 1 / 72.0 * d * d / s * (u * u * u + 11 * u));
            z -= s * d / 120.0 * (Math.Pow(u, 4) + 9 * u * u + 8);
            z += d * d * d / 3240 / s * (3 * Math.Pow(u, 4) + 7 * u * u - 16) + Math.Sqrt(s / 2) * (s * s / 1920.0 * (Math.Pow(u, 5) + 20 * u * u * u + 15 * u));
            z += Math.Pow(d, 4) / 2880.0 * (Math.Pow(u, 5) + 44 * u * u * u + 183 * u) + Math.Pow(d, 4) / (155520.0 * s * s) * (9 * Math.Pow(u, 5) - 284 * u * u * u - 1513 * u);
            return Math.Exp(2 * z);
        }

        static public double StudentQuantil(double[] A)
        {
            double g1 = (Math.Pow(NormalQuantil(), 3) + NormalQuantil()) / 4;
            double g2 = (5 * Math.Pow(NormalQuantil(), 5) + 16 * Math.Pow(NormalQuantil(), 3) + 3 * NormalQuantil()) / 96;
            double g3 = (3 * Math.Pow(NormalQuantil(), 7) + 19 * Math.Pow(NormalQuantil(), 5) + 17 * Math.Pow(NormalQuantil(), 3) + 15 * NormalQuantil()) / 384;
            double g4 = (79 * Math.Pow(NormalQuantil(), 9) + 779 * Math.Pow(NormalQuantil(), 7) + 1482 * Math.Pow(NormalQuantil(), 5) + 1920 * Math.Pow(NormalQuantil(), 3) + 945 * NormalQuantil()) / 92160;
            double SQ = NormalQuantil() + (g1 / start_moment(1, A) + (g2 / start_moment(2, A)) + (g3 / start_moment(3, A)) + (g4 / start_moment(4, A)));
            return SQ;
        }

        static public double StudentQuantil1(double stepeni)
        {
            double g1 = (Math.Pow(NormalQuantil(), 3) + NormalQuantil()) / 4;
            double g2 = (5 * Math.Pow(NormalQuantil(), 5) + 16 * Math.Pow(NormalQuantil(), 3) + 3 * NormalQuantil()) / 96;
            double g3 = (3 * Math.Pow(NormalQuantil(), 7) + 19 * Math.Pow(NormalQuantil(), 5) + 17 * Math.Pow(NormalQuantil(), 3) + 15 * NormalQuantil()) / 384;
            double g4 = (79 * Math.Pow(NormalQuantil(), 9) + 779 * Math.Pow(NormalQuantil(), 7) + 1482 * Math.Pow(NormalQuantil(), 5) + 1920 * Math.Pow(NormalQuantil(), 3) + 945 * NormalQuantil()) / 92160;
            double SQ = NormalQuantil() + g1 / stepeni + g2 / Math.Pow(stepeni, 2) + g3 / Math.Pow(stepeni, 3) + (g4 / Math.Pow(stepeni, 4));
            return SQ;
        }

        static public double XIquantil(double stepin)
        {
            double first = (1 - 2 / (9 * stepin) + NormalQuantil() * Math.Sqrt(2 / (9 * stepin)));
            double second = stepin * Math.Pow(first, 3);
            return second;
        }

        static public double start_moment(int k, double[] mass)
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
