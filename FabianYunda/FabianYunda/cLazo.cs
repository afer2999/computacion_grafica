using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace FabianYunda
{
    class cLazo : cCircunferencia
    {
        public double alfa;
        public cLazo() { }


        public cLazo(double x, double y, double r, Color ca, Bitmap gra, PictureBox view, double alf, int tp)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.c = ca;
            this.grafico = gra;
            this.ViewPort = view;
            tipo = tp;
            this.alfa = alf;
        }
        public  void EncenderLazo()
        {
            cVector vc = new cVector(0, 0, c, grafico, ViewPort);
            switch (tipo)
            {
                //Encender Lazo
                case 0:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Sin(2 * t);
                            vc.y0 = y0 + radio * Math.Cos(3 * t);
                            t = t + dt;
                            vc.EcenderV();
                        } while (t <= 2 * Math.PI);
                    } break;
                //Rotar Lazo
                case 1:
                    {
                        double t = 0;
                        double dt = 0.001;
                        cVector vl = new cVector(0, 0, c, grafico, ViewPort);
                        cVector W = new cVector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            vl.x0 = x0 + Math.Sin(2 * t) * radio;
                            vl.y0 = y0 + Math.Cos(3 * t) * radio;
                            Rotar2D(vl.x0, vl.y0, x0, y0, alfa, out W.x0, out W.y0);
                            W.EcenderV();
                            t += dt;
                        } while (t <= 2 * Math.PI);
                    } break;
                case 3:
                    {
                        double t = 0;
                        double dt = 0.001;
                        cVector vl = new cVector(0, 0, c, grafico, ViewPort);
                        cVector W = new cVector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            vl.x0 = x0 + Math.Sin(t1sen * t) * radio;
                            vl.y0 = y0 + Math.Cos(t1cos * t) * radio;
                            Rotar2D(vl.x0, vl.y0, x0, y0, alfa, out W.x0, out W.y0);
                            W.c = this.c;
                            W.EcenderV();
                            t += dt;
                        } while (t <= 2 * Math.PI);
                    } break;
            }
        }
        public  void ApagarLazo()
        {
            cVector vc = new cVector(0, 0, Color.White, grafico, ViewPort);
            switch (tipo)
            {
                //Encender Lazo
                case 0:
                    {
                        double t = 0, dt = 0.001;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Sin(2 * t);
                            vc.y0 = y0 + radio * Math.Cos(3 * t);
                            t = t + dt;
                            vc.EcenderV();
                        } while (t <= 2 * Math.PI);
                    } break;
                //Rotar Lazo
                case 1:
                    {
                        double t = 0;
                        double dt = 0.001;
                        cVector vl = new cVector(0, 0, Color.White, grafico, ViewPort);
                        cVector W = new cVector(0, 0, Color.White, grafico, ViewPort);
                        do
                        {
                            vl.x0 = x0 + Math.Sin(2 * t) * radio;
                            vl.y0 = y0 + Math.Cos(3 * t) * radio;
                            Rotar2D(vl.x0, vl.y0, x0, y0, alfa, out W.x0, out W.y0);
                            W.EcenderV();
                            t += dt;
                        } while (t <= 2 * Math.PI);
                    } break;
            }
        }
    }
}
