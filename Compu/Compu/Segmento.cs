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
    class Segmento:Vector
    {
        public double xf, yf;
        public int tipo;
        public Segmento() { }
        public Segmento(double x, double y, double x2, double y2, Color ca, Bitmap gra, PictureBox view, int tp)
        {
            this.x0 = x;
            this.y0 = y;
            this.c = ca;
            this.yf = y2;
            this.xf = x2;
            this.grafico = gra;
            this.ViewPort = view;
            tipo = tp;
        }
        public override void Encender( )
        {
            Vector vs = new Vector(0, 0, c, grafico, ViewPort);
            switch(tipo)
            {
                    //segmento
                case 0:
                    {  double t = 0, dt = 0.001;
                        do
                        {
                            vs.x0 = x0 + (xf - x0) * t;
                            vs.y0 = y0 + (yf - y0) * t;
                            vs.Encender();
                            t = t + dt;
                        } while (t <= 1);
                    }break;
                    //segmento interpolado
                case 1:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vs.x0 = x0 + (xf - x0) * t;
                            vs.y0 = y0 + (yf - y0) * t;
                            vs.c = Color.FromArgb(255,(int)(255*t),0);
                            vs.Encender();
                            t = t + dt;
                        } while (t <= 1);
                    }break;
                case 2:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vs.x0 = x0 + (xf - x0) * t;
                            vs.y0 = y0 + (yf - y0) * t;
                            if (t <= 0.5)
                            {
                                vs.c = Color.Red;
                            }
                            else
                            {
                                vs.c = Color.Yellow;
                            }
                            t = t + dt;
                            vs.Encender();
                        }while(t<=1);
                    }break;
                case 3:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vs.x0 = x0 + (xf - x0) * t;
                            vs.y0 = y0 + (yf - y0) * t;
                            if (t <= 0.5)
                            {
                                vs.c = Color.FromArgb(255,(int)((255*t)/0.5),0);
                            }
                            else
                            {
                                vs.c = Color.FromArgb((int)((255/0.5)-255),(int)(((-255*t)/0.5)+255/0.5),0);
                            }
                            t = t + dt;
                            vs.Encender();
                            
                        } while (t <= 1);
                    }break;
                   
            }
            
        }
    }
}
