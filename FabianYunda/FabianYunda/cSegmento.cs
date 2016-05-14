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
    class cSegmento:cVector
    {
        public double xf, yf;
       public  int tipo;

        public cSegmento() { }
        public cSegmento(double x0, double y0, double xf, double yf, Color c, Bitmap grafico, PictureBox View, int tipo) 
        {
            this.x0 = x0;
            this.y0 = y0;
            this.xf = xf;
            this.yf = yf;

            this.c = c;
            this.grafico = grafico;
            this.ViewPort = View;
            this.tipo = tipo;
        
        }
        public void EcenderS()
        {
            double t = 0, dt = 0.001;
            cVector s = new cVector(0, 0, c, grafico, ViewPort);
            switch (tipo)
            {
                    //encender segmento normal
                case 0:{

              
            do
            {
                s.x0 = x0 + (xf - x0) * t;
                s.y0 = y0 + (yf - y0) * t;
                s.c = this.c;
                s.EcenderV();
                t = t + dt;
            } while (t  <=1);
           }
             break;
                    //segmento interpolado con coles
                case 1:
             {


                 do
                 {
                     s.x0 = x0 + (xf - x0) * t;
                     s.y0 = y0 + (yf - y0) * t;
                     s.c = Color.FromArgb(
                     (int)(0 * ((t - 1) / (0 - 1)) + 255 * ((t - 0) / (1 - 0))),
                     (int)(0 * ((t - 1) / (0 - 1)) + 0 * ((t - 0) / (1 - 0))),
                     (int)(255 * ((t - 1) / (0 - 1)) + 255 * ((t - 0) / (1 - 0))));
                     s.EcenderV();
                     t = t + dt;
                 } while (t <= 1);
             }
             break;
                    //segmento entrecortado
                case 2:
             {

                 double cc = 0;
                 do
                 {
                     s.x0 = x0 + (xf - x0) * t;
                     s.y0 = y0 + (yf - y0) * t;
                     s.c = this.c;
                     if (cc%25==0)
                     {
                         s.EcenderV();
                     }

                     t = t + dt;
                     cc = cc + 1;
                 } while (t <= 1);
             }
             break;

                case 3:
             {


                 int a = 1;
                 do
                 {
                     for (double i = 0; i <=0.3; i=i+0.01)
                     {
                         s.x0 = x0  + (xf - x0) * t;
                         s.y0 = y0 + i + (yf - y0) * t;
                         s.c = this.c;
                         s.EcenderV();
                         
                     }
                    
                     t = t + dt;
                          

                     
                    
                 } while (t <= 1);
             }
             break;
        
        
            
            }
        }

        public void segmento2(double xc, double yc, double mc, out double y1, out double y2)
        {
            y1 = mc * (-15 - xc) + yc;
            y2 = mc * (15 - xc) + yc;
        }
        public void ApagarS()
        {
            double t = 0, dt = 0.01;
            cVector s = new cVector(0, 0, c, grafico, ViewPort);

            do
            {
                s.x0 = x0 + (xf - x0) * t;
                s.y0 = y0 + (yf - y0) * t;
                s.c = this.c;

                s.EcenderV();
                t = t + dt;
            } while (t <= 1);

        }





    }
}
