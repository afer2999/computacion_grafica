using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewCompu
{
    class Segmento : Vector
    {
        public double xf;
        public double yf;

        public Segmento() { }

        public Segmento(double x1, double y1, double x2, double y2, Color c)
        {
            this.x0 = x1;
            this.y0 = y1;
            this.xf = x2;
            this.yf = y2;
            this.color0 = c;
        }
        public override void Encender(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector v = new Vector();
            do
            {
                v.x0 = x0 + (xf - x0) * t;
                v.y0 = y0 + (yf - y0) * t;
                v.color0 = color0;
                /* v.c = Color.FromArgb(
                     (int)(255 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))),
                     (int)(255 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))),
                     (int)(8 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))));*/
                v.Encender(grafico);
                t += dt;
            } while (t <= 1);
        }

        public void apagar(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector v = new Vector();
            do
            {
                v.x0 = x0 + (xf - x0) * t;
                v.y0 = y0 + (yf - y0) * t;
                v.color0 = Color.White;
                /* v.c = Color.FromArgb(
                     (int)(255 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))),
                     (int)(255 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))),
                     (int)(8 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))));*/
                v.Encender(grafico);
                t += dt;
            } while (t <= 1);
        }

        public void Recta(double a, double b, double m)
        {
            Segmento s = new Segmento();
            double y1, y2;
            y1 = m * (-14 - a) + b;

            y2 = m * (14 - a) + b;
            s.x0 = -14;
            s.y0 = y1;
            s.xf = 14;
            s.yf = y2;
            s.color0 = color0;
        }
    }
}
