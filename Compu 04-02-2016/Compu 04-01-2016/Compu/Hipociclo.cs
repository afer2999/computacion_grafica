using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Compu
{
    class Hipociclo:Circuenferencia
    {
        public Hipociclo() { }
        public Hipociclo(double x, double y, double r, Color c,Bitmap gra, PictureBox view,int tp) {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.c = c;
            grafico = gra;
            ViewPort = view;
            tipo = tp;
        }

        public override void Encender()
        {
            double t = 0;
            double dt = 0.001;
            Vector vh = new Vector(0, 0, c, grafico, ViewPort);
            do
            {
                vh.x0 = x0 + (Math.Pow(Math.Sin(t), 3)) * radio;
                vh.y0 = y0 + (Math.Pow(Math.Cos(t), 3)) * radio;
                vh.c = this.c;
                vh.Encender();
                t += dt;

            } while (t <= 2 * Math.PI);
        }
    }
}
