using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Compu
{
    public class ModelosMat
    {
        public static double x1 = -15;
        public static double y1 = -10;
        public static double x2 = 15;
        public static double y2 = 10;
        public static int sx1 = 0;
        public static int sy1 = 0;
        public static int sx2 = 600;
        public static int sy2 = 400;
        public static double p;
        Bitmap grafico;

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

       public static double Lagrange1(double x, Vector[] vx, int n)
        {
            double s = 0;

            for (int i = 0; i < n; i++)
            {
                p = 1;

                for (int j = 0; j < n; j++)
                {
                    if (vx[i].x0 != vx[j].x0)
                    {
                        p = p * (x - vx[j].x0) / (vx[i].x0 - vx[j].x0);
                    }
                }
                s = s + vx[i].y0 * p;
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

       public static Vector Bezier1(Vector[] vy, int cont, double t)
        {
            Vector bezier = new Vector();
            int aco;
            aco = cont - 1;
            double xt = 0, yt = 0;
            for (int i = 0; i <= aco; i++)
            {

                xt = (vy[i].x0 * (factorial(aco) / (factorial(i) * (factorial(aco - i)))) * (Math.Pow(t, i)) * (Math.Pow((1 - t), (aco - i)))) + xt;
                yt = (vy[i].y0 * (factorial(aco) / (factorial(i) * (factorial(aco - i)))) * (Math.Pow(t, i)) * (Math.Pow((1 - t), (aco - i)))) + yt;
            }
            bezier.x0 = xt;
            bezier.y0 = yt;
            return bezier;
        }

        public static double factorial(double real)
        {
            double resp = 1;
            for (double i = 1; i <= real; i++)
            {
                resp = resp * i;
            }
            return resp;
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

        public static void Rotar(double x, double y, double xc, double yc,double teta, out double rx, out double ry){
            rx = ((x - xc) * Math.Cos(teta)) - ((y - yc) * Math.Sin(teta)) + xc;
            ry = ((x - xc) * Math.Sin(teta)) + ((y - yc) * Math.Cos(teta)) + yc;
            
        }

        public static void RotarAnimacion(double x, double y, double xc, double yc, double teta, out double ry, out double rx)
        {
            rx = ((x - xc) * Math.Cos(teta)) - ((y - yc) * Math.Sin(teta)) + xc;
            ry = ((x - xc) * Math.Sin(teta)) + ((y - yc) * Math.Cos(teta)) + yc;

        }

        public static void Axionometria(double x, double y, double z, out double ax, out double ay)
        {
            double po = 0.5;
            double alfa = (Math.PI / 4);
            ax = y - po * x * Math.Cos(alfa);
            ay = z - po * x * Math.Sin(alfa);
        }

        public static void Rotar(double x, double y, double z, double gama, int eje, out double rx, out double ry, out double rz) 
        {
            rx = 0;
            ry = 0;
            rz = 0;

         
            if (eje==1)
	        {
		        rx = x;
                ry = y * Math.Cos(gama) - z * Math.Sin(gama);
                rz = y * Math.Sin(gama) + z * Math.Cos(gama);
	        }

            if (eje==2)
	        {
		        rx = x * Math.Cos(gama) + z * Math.Sin(gama);
                ry = y;
                rz = -x * Math.Sin(gama) + z * Math.Cos(gama);
	        }

            if (eje==3)
	        {
		        rx = x * Math.Cos(gama) - y * Math.Sin(gama);
                ry = x * Math.Sin(gama) + y * Math.Cos(gama);
                rz = z;
	        }
        }



        public  static void Cuadrilatero(double Px, double Py, double Qx, double Qy, double Rx, double Ry, double Tx, double Ty, Bitmap b, int tipo)
        {
            int SPx, SPy, SQx, SQy, SRx, SRy, STx, STy;
            Graphics g = Graphics.FromImage(b);
            Pen pn;

            Pantalla(Px, Py, out SPx, out SPy);
            Pantalla(Qx, Qy, out SQx, out SQy);
            Pantalla(Rx, Ry, out SRx, out SRy);
            Pantalla(Tx, Ty, out STx, out STy);

            Point p1 = new Point(SPx, SPy);
            Point p2 = new Point(SQx, SQy);
            Point p3 = new Point(SRx, SRy);
            Point p4 = new Point(STx, STy);
            Point[] p = { p1, p2, p3, p4 };
            SolidBrush sb;

            if (tipo == 0)
            {

                pn = new Pen(Color.White);
                g.DrawPolygon(pn, p);

            }

            if (tipo == 1)
            {
                pn = new Pen(Color.White);
                sb = new SolidBrush(Color.Blue);
                g.FillPolygon(sb, p);
                g.DrawPolygon(pn, p);
            }

            if (tipo == 2)
            {
                pn = new Pen(Color.Green);
                sb = new SolidBrush(Color.LightGray);
                g.FillPolygon(sb, p);
                g.DrawPolygon(pn, p);
            }


            if (tipo == 3)
            {

                pn = new Pen(Color.Black);
                g.DrawPolygon(pn, p);

            }
        }
    
    }
}
