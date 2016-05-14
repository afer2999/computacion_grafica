using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Grupo_5
{
    class LibreriaMat
    {
        //Estos valores siempre deben ser Reales pueden cojer un valor diferente valores reales
        double X1 = -15;
        double Y1 = -10;
        double X2 = 15;
        double Y2 = 10;
        //Estos valores siempre deben ser Enteros por se r de la pantalla
        int SX1 = 0;
        int SY1 = 0;
        int SX2 = 600;
        int SY2 = 400;

        //Metodo que nos permite representar los vectores implementando las formulas de los vectores
        //out int SX nos permite dar a conocer el valor que va ha salir
        //if nos permite controlar que el grafico no salga de las dimensiones dadas

        //public LibreriaMat(double x1z, double y1z, double x2z, double y2z)
        //{
        //    this.X1 = x1z;
        //    this.Y1 = y1z;
        //    this.X2 = x2z;
        //    this.Y2 = y2z;
        //}
        public void pantalla(double X, double Y, out int SX, out int SY)
        {
            int xs, ys;
            SX = 0;
            SY = 0;
            xs = (int)Math.Truncate(((SX1 - SX2) / (X1 - X2)) * (X - X1)) + SX1;
            ys = (int)Math.Truncate(((SY1 - SY2) / (Y2 - Y1)) * (Y - Y1)) + SY2;
            if (xs < 600 && ys < 400)
            {
                SX = xs; SY = ys;
            }
        }
        public void Carta(int SX, int SY, out double X, out double Y)
        {
            X = (((SX - SX1) * (X1 - X2)) / (SX1 - SX2)) + X1;
            Y = (((SY - SY1) * (Y2 - Y1)) / (SY1 - SY2)) + Y2;
        }




        public static double Lagrange(double x, double[] vx, double[] vy, int n)
        {
            double P;
            double s = 0;

            for (int i = 0; i < n; i++)
            {
                P = 1;

                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        P = P * ((x - vx[j]) / (vx[i] - vx[j]));
                    }
                }
                s = s + (vy[i] * P);
            }
            return s;
        }

        public void fac(int num, out int facto)
        {
            facto = 1;
            if (num == 0)
                facto = 1;
            else
            {
                for (int i = 1; i < num + 1; i++)
                {
                    facto = facto * i;
                }
            }
        }
        public void bezier(double t, out double xt, out double yt, int contador, double[] VecX, double[] VecY)
        {
            int nfac, ifac, nifac;
            int aco;
            aco = contador - 1;
            fac(aco, out nfac);
            int i;
            xt = 0; yt = 0;
            for (i = 0; i <= aco; i++)
            {
                fac(i, out ifac);
                fac((aco - i), out nifac);
                xt = (VecX[i] * (nfac / (ifac * nifac)) * (Math.Pow(t, i)) * (Math.Pow((1 - t), (aco - i)))) + xt;
                yt = (VecY[i] * (nfac / (ifac * nifac)) * (Math.Pow(t, i)) * (Math.Pow((1 - t), (aco - i)))) + yt;
            }
        }
        public void Rotar1(double x, double y, double teta, out double rx, out double ry)
        {
            rx = (x * Math.Cos(teta)) - (y * Math.Sin(teta));
            ry = (x * Math.Sin(teta)) + (y * Math.Cos(teta));
            //teta = teta + 0.01;

        }

        public void Rotar2(double x, double y, double teta, double dx, double dy, out double rx, out double ry)
        {
            rx = ((x - dx) * Math.Cos(teta)) - ((y - dy) * Math.Sin(teta)) + dx;
            ry = ((x - dx) * Math.Sin(teta)) + ((y - dy) * Math.Cos(teta)) + dy;

        }


        public Vector pRotar(double x, double y, double teta, Color Color0, PictureBox ViewPort, Bitmap Grafico)
        {
            double rx = (x * Math.Cos(teta)) - (y * Math.Sin(teta));
            double ry = (x * Math.Sin(teta)) + (y * Math.Cos(teta));
            Vector obj = new Vector(rx, ry, Color0, ViewPort, Grafico);
            return obj;
        }

        public Vector pRotar2(double x, double y, double teta, double dx, double dy, Color Color0, PictureBox ViewPort, Bitmap Grafico)
        {
            double rx = ((x - dx) * Math.Cos(teta)) - ((y - dy) * Math.Sin(teta)) + dx;
            double ry = ((x - dx) * Math.Sin(teta)) + ((y - dy) * Math.Cos(teta)) + dy;
            Vector obj = new Vector(rx, ry, Color0, ViewPort, Grafico);
            return obj;
        }
    }
}
