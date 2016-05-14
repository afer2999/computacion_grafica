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
    class Hipociclo:Circunferencia
    {
        public Hipociclo() { }
        ~Hipociclo() { }
        public Hipociclo(double x, double y, double r, Color ca, Bitmap gra, PictureBox view,int tp) {
            x0 = x;
            y0 = y;
            radio = r;
            c = ca;
            grafico = gra;
            ViewPort = view;
            tipo = tp;
        }
        public override void Encender( )
        {
            Vector vc = new Vector(0, 0, c, grafico, ViewPort);
            switch (tipo)
            {
                    //hipociclo
                case 0:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Pow(Math.Sin(t), 3);
                            vc.y0 = y0 + radio * Math.Pow(Math.Cos(t), 3);
                            t = t + dt;
                            vc.c = this.c;
                            vc.Encender();
                        } while (t <= 2 * Math.PI);
                    }break;
            }
            
        }
    }
}
