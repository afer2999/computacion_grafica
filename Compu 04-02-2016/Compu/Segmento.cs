using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
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
            this.c = c;
        }
        public void EncenderSegmento(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector v = new Vector();
            do
            {
                v.x0 = x0 + (xf - x0) * t;
                v.y0 = y0 + (yf - y0) * t;
                v.c = this.c;
                /* v.c = Color.FromArgb(
                     (int)(255 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))),
                     (int)(255 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))),
                     (int)(8 * ((t - 1) / (0 - 1)) + 53 * ((t - 0) / (1 - 0))));*/
                v.Encender(grafico);
                t += dt;
            } while (t <= 1);
        }

        public void EncSegmentoInterpolado(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector v = new Vector();
            do
            {
                v.x0 = x0 + (xf - x0) * t;
                v.y0 = y0 + (yf - y0) * t;
                v.c = Color.FromArgb(
                     (int)(0 * ((t - 1) / (0 - 1)) + 247 * ((t - 0) / (1 - 0))),
                     (int)(255 * ((t - 1) / (0 - 1)) + 191 * ((t - 0) / (1 - 0))),
                     (int)(0 * ((t - 1) / (0 - 1)) + 190 * ((t - 0) / (1 - 0))));
                v.Encender(grafico);
                t += dt;
            } while (t <= 1);
        }

        //********************* Segmento entrecortada *********************//

        public void SEntrecortado(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            double c = 0;
            Vector v = new Vector();
            do
            {
                v.x0 = x0 + (xf - x0) * t;
                v.y0 = y0 + (yf - y0) * t;
                v.c = this.c;
                if (c % 25 == 0) {
                    v.Encender(grafico);
                }
                t += dt;
                c += 1;
            } while (t <= 1);
        }

        public void Encender(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector v = new Vector();
            do
            {
                v.x0 = x0 + (xf - x0) * t;
                v.y0 = y0 + (yf - y0) * t;
                v.c = this.c;
                v.Encender(grafico);
                t += dt;
            } while (t <= 1);
        }

        public void segmento2(double xc, double yc, double mc, out double y1, out double y2)
        {
            y1 = mc * (-15 - xc) + yc;
            y2 = mc * (15 - xc) + yc;
        }

        //********************* LETRAS *********************//

        public void Letrak(Bitmap grafico)
        {

            Segmento s = new Segmento();
            s.x0 = x0;
            s.y0 = y0;
            s.xf = xf;
            s.yf = yf;
            s.c = Color.Black;
            s.EncenderSegmento(grafico);

            s.x0 = x0;
            s.y0 = y0;
            s.xf = x0 + x0 + x0;
            s.yf = y0;

            s.x0 = x0 + x0 * 2;
            s.y0 = y0;
            s.xf = xf + xf + xf;
            s.yf = yf;

            s.x0 = x0;
            s.y0 = (y0 + yf) / 2;
            s.xf = x0 + x0 + x0;
            s.yf = y0;
            s.c = Color.Black;
            s.EncenderSegmento(grafico);

            s.x0 = x0;
            s.y0 = (y0 + yf) / 2;
            s.xf = xf + xf + xf;
            s.yf = yf;
            s.c = Color.Black;
            s.EncenderSegmento(grafico);




        }

    }
}
