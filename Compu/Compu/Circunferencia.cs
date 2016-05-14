using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Compu
{
     class Circunferencia:Vector
    {
        public double radio;
        public int tipo;
        
        public Circunferencia() { }
         ~Circunferencia() { }
        public Circunferencia(double x, double y, double r, Color ca, Bitmap gra, PictureBox view, int tp)
        {
            x0 = x;
            y0 = y;
            radio = r;
            c = ca;
            grafico = gra;
            ViewPort = view;
            tipo = tp;
        }
        public override void Encender()
        {
            Vector vc = new Vector(0,0,c,grafico,ViewPort);
            switch(tipo)
            {
                    //circunferencia
                case 0:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.Encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);
                    }break;
                ////////interpolado
                case 1:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.c = Color.FromArgb(255,(int)((255*t)/(2*Math.PI)),0);
                            t = t + dt;
                            vc.Encender();
                        }while(t<=2*Math.PI);
                    }break;
                ////////dos colores
                case 2:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            if (t <= Math.PI)
                            {
                                vc.c = Color.Red;
                            }
                            else
                            {
                                vc.c = Color.Yellow;
                            }
                            t = t + dt;
                            vc.Encender();
                        } while (t <= 2 * Math.PI);
                    }break;
                ////////interpolado en dos tramos
                case 3:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            if (t <= Math.PI)
                            {
                                vc.c = Color.FromArgb(255,(int)((255*t)/(Math.PI)),0);
                            }
                            else
                            {
                                vc.c = Color.FromArgb((255 * 2) - 255, (int)((255 * t) / (2 * Math.PI)), 0);
                            }
                            t = t + dt;
                            vc.Encender();
                        }while(t<=2*Math.PI);
                    }break;
                ////////Cono
                case 4:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            t = t + dt;
                            vc.Encender();
                        } while (t <= Math.PI);
                    } break;
                    ////////letra d
                case 5:
                    {
                        double t = 40*Math.PI/180, dt =0.001 ;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            t = t + dt;
                            vc.Encender();
                        } while (t <= 320*Math.PI/180);
                        Segmento sg = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 - radio, x0+radio * Math.Cos(40 * Math.PI / 180), y0 + radio * 2, c, grafico, ViewPort, 0);
                        sg.Encender();
                    } break;
                    ///letra teta
                case 6:
                     {
                        double t = 0, dt =0.001 ;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + 1.2*radio * Math.Sin(t);
                            t = t + dt;
                            vc.Encender();
                        } while (t <= 360*Math.PI/180);
                        Segmento sg = new Segmento(x0 + radio, y0, x0 - radio, y0, c, grafico, ViewPort, 0);
                        sg.Encender();
                    } break;
        }
            
        }
    }
}
