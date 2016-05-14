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
    class Lazo:Circunferencia
    {
        
        public Lazo() { }
        public Lazo(double x, double y, double r, Color ca, Bitmap gra, PictureBox view, int tp)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.c = ca;
            this.grafico = gra;
            this.ViewPort = view;
            tipo = tp;
        }
        public override void Encender( )
        {
            Vector vc = new Vector(0,0,c,grafico,ViewPort);
            switch (tipo)
            {
                    //Lazo
                case 0:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Sin(2 * t);
                            vc.y0 = y0 + radio * Math.Cos(3 * t);
                            t = t + dt;

                            vc.Encender();
                        } while (t <= 2 * Math.PI);
                    }break;
            }
           
        }
    }
}
