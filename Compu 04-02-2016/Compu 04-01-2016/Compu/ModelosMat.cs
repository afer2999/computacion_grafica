using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compu
{
    public class ModelosMat
    {
        public static double x1 = -15;
        public static double y1 = -10;
        public static double x2 = 15;
        public static double y2 = 10;
        //public static double x1 = -3;
        //public static double y1 = -2;
        //public static double x2 = 3;
        //public static double y2 = 2;
        public static int sx1 = 0;
        public static int sy1 = 0;
        public static int sx2 = 600;
        public static int sy2 = 400;
        public static double p;

        public static void Pantalla(double x, double y, out int sx, out int sy) {
            sx = (int)Math.Truncate((sx2 - sx1) / (x2 - x1) * (x - x2) + sx2);
            sy = (int)Math.Truncate((sy1 - sy2) / (y2 - y1) * (y - y2) + sy1);
        }

        public static void RealXY(int sx, int sy, out double x, out double y) {
            x = ((sx - sx2) * ((x2 - x1) / (sx2 - sx1))) + x2;
            y = ((sy - sy1) *((y2 - y1) / (sy1 - sy2))) + y2;
        }

        public static double RealX(double sx)
        {
            double x;
            x = ((sx - sx1) / ((sx1 - sx2) / (x1 - x2))) + x1;
            return x;

        }

        public static double RealY(double sy)
        {
            double y;
            y = ((sy - sy2) / ((sy1 - sy2) / (y2 - y1))) + y1;
            return y;
        }

        public static double Lagrange(double x, double[] vx, double[] vy, int n)
        {
            double s = 0;

            for (int i = 0; i < n; i++)
            {
                p = 1;

                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        p = p * (x - vx[j]) / (vx[i] - vx[j]);
                    }
                }
                s = s + vy[i] * p;
            }
            return s;
        }

        public static void Bezier(double[] vx, double[] vy, int cont, double t, out double xt, out double yt)
        {
            int nfac, ifac, nifac;
            int aco;
            aco = cont - 1;
            fac(aco, out nfac);
            int i;
            xt = 0; yt = 0;
            for (i = 0; i <= aco; i++)
            {
                fac(i, out ifac);
                fac((aco - i), out nifac);
                xt = (vx[i] * (nfac / (ifac * nifac)) * (Math.Pow(t, i)) * (Math.Pow((1 - t), (aco - i)))) + xt;
                yt = (vy[i] * (nfac / (ifac * nifac)) * (Math.Pow(t, i)) * (Math.Pow((1 - t), (aco - i)))) + yt;
            }
        }
        public static void fac(int x, out int y)
        {
            int f = 1;
            if (x > 1)
            {
                for (int i = 1; i <= x; i++)
                {
                    f = f * i;
                }
            }
            y = f;
        }
        public static void Rotar(double x, double y, double xc, double yc, double teta, out  double ry, out double rx)
        {
            rx = (x - xc) * Math.Cos(teta) - (y - yc) * Math.Sin(teta) + xc;
            ry = (x - xc) * Math.Sin(teta) + (y - yc) * Math.Cos(teta) + yc;
        }
        public static void Rotar1(double x, double y, double xc, double yc, double teta, out  double rx, out double ry)
        {
            ry = (x - xc) * Math.Cos(teta) - (y - yc) * Math.Sin(teta) + xc;
            rx = (x - xc) * Math.Sin(teta) + (y - yc) * Math.Cos(teta) + yc;
        }

        public static void Spline(double[] vx, double[] vy, int n, out double a, out double b, out double c)
        {
            a = 0;
            b = 0;
            c = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    a = 0;
                    b = (vy[i] - vy[i + 1]) / (vx[i] - vx[i + 1]);
                    c = vy[i] - vx[i] * b;
                }
                else
                {
                    b = ((Math.Pow(vx[i + 2], 2) * vx[i+1]) - (Math.Pow(vx[i+1], 2) * vx[i + 2])) / ((Math.Pow(vx[i + 2], 2) * vy[i+1]) - (Math.Pow(vx[i + 1], 2) * vy[i + 2]));
                    a = (vy[i + 1] - vx[i+1] * b + vx[i + 2]* b - vy[i+2])/(Math.Pow(vx[i + 1], 2)-(Math.Pow(vx[i + 2], 2)));
                    c = Math.Pow(vx[i + 1], 2) * a + vx[i + 1] * b - vy[i + 1];
                }
            }
        }
    }
}
