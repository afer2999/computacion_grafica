using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewCompu
{
    class Circunferencia:Vector
    {
        public double radio;

        public Circunferencia() { }
        public Circunferencia(double x, double y, double r, Color c)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.color0 = c;
        }

        public void EncCircunferencia(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.color0 = color0;
                vc.Encender(grafico);
                t += dt;              

            } while (t <= 2 * Math.PI);
           /* Segmento s = new Segmento();
            s.x0 = x0 - radio;
            s.y0 = y0;
            s.xf = x0 + radio;
            s.yf = y0;
            s.color0 = Color.Black;
            s.Encender(grafico);*/

        }

        public void Apagar(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.color0 = Color.White;
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        



        // NÚMEROS 

        public void EncenderUno(Bitmap grafico)
        {
          
            Segmento s1 = new Segmento();
            s1.x0 = this.x0;
            s1.y0 = this.y0;
            s1.xf = this.x0 - this.radio;
            s1.yf = this.y0 - this.radio;
            s1.color0 = color0;
            s1.Encender(grafico);

            Segmento s = new Segmento();
            s.x0 = this.x0;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = color0;
            s.Encender(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 + this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = color0;
            s.Encender(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 - this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = color0;
            s.Encender(grafico);
        }
        public void EncenderUnoCirculo(Bitmap grafico)
        {

            double t = 0;
            double dt = 0.01;
            Vector v = new Vector();
            while (t <= 2 * Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(grafico);
                t += dt;
            }

            this.x0 = this.x0;
            this.y0 = this.y0;
            Segmento s1 = new Segmento();
            s1.x0 = this.x0;
            s1.y0 = this.y0;
            s1.xf = this.x0 - this.radio;
            s1.yf = this.y0 - this.radio;
            s1.color0 = color0;
            s1.Encender(grafico);

            Segmento s = new Segmento();
            s.x0 = this.x0;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = color0;
            s.Encender(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 + this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = color0;
            s.Encender(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 - this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = color0;
            s.Encender(grafico);
        }

        public void EncenderDos(Bitmap Grafico)
        {
            double t = (20 * Math.PI / 180), dt = 0.001;
            Vector v = new Vector();
            v.color0 = this.color0;

            while (t <= (Math.PI))
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(Grafico);
                t += dt;
            }

            Segmento sm = new Segmento();
            sm.color0 = this.color0;
            sm.x0 = this.x0 + this.radio * Math.Cos(20 * Math.PI / 180);
            sm.y0 = this.y0 + this.radio * Math.Sin(20 * Math.PI / 180);
            sm.xf = this.x0 + this.radio * Math.Cos(Math.PI);
            sm.yf = this.y0 + this.radio * Math.Sin(Math.PI) - radio;
            sm.Encender(Grafico);
            sm.x0 = this.x0 + this.radio * Math.Cos(Math.PI);
            sm.y0 = this.y0 + this.radio * Math.Sin(Math.PI) - radio;
            sm.xf = this.x0 + this.radio * Math.Cos(2 * Math.PI);
            sm.yf = this.y0 + this.radio * Math.Sin(2 * Math.PI) - radio;
            sm.Encender(Grafico);
        }

        public void EncenderTres(Bitmap Grafico)
        {
            
            Vector oV = new Vector();
            double t, dt;
            t = 1.5 * Math.PI;
            dt = 0.001;
            oV.color0 = color0;
            do
            {
                oV.x0 = x0 + radio * Math.Cos(t);
                oV.y0 = y0 + radio * Math.Sin(t);
                oV.Encender(Grafico);
                t = t + dt;

            } while (t <= 2.75 * Math.PI);
            t = 1.25 * Math.PI;
            y0 = y0 - 2 * radio;
            do
            {
                oV.x0 = x0 + radio * Math.Cos(t);
                oV.y0 = y0 + radio * Math.Sin(t);
                oV.Encender(Grafico);
                t = t + dt;
            } while (t <= 2.5 * Math.PI);
        }

        public void EncenderCuatro(Bitmap grafico)
        {

            /*Segmento s1 = new Segmento();
            s1.x0 = this.x0;
            s1.y0 = this.y0;
            s1.xf = this.x0 - this.radio;
            s1.yf = this.y0 - this.radio;
            s1.color0 = this.color0;
            s1.Encender(grafico);

            Segmento s = new Segmento();
            s.x0 = this.x0;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = this.color0;
            s.Encender(grafico);

            s.x0 = this.x0 - this.radio;
            s.y0 = this.y0 - this.radio;
            s.xf = this.x0;
            s.yf = this.y0 - this.radio;
            s.color0 = this.color0;
            s.Encender(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 + this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = this.color0;
            s.Encender(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 - this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.color0 = this.color0;
            s.Encender(grafico);*/
            Segmento seg = new Segmento(x0 - radio, y0, x0 + radio*0.02, y0, color0);
            seg.Encender(grafico);
            Segmento seg1 = new Segmento(x0, y0 - radio, x0, y0 + radio, color0);
            seg1.Encender(grafico);
            Segmento seg2 = new Segmento(x0 - radio, y0, x0, y0 + radio, color0); 
                                                                                                   
            seg2.Encender(grafico);
        }

        public void EncenderCinco(Bitmap Grafico)
        {

            double t = 0, dt = 0.001;
            Vector v = new Vector();
            v.color0 = this.color0;
            while (t <= 2 * Math.PI)
            {
                v.x0 = (this.x0 + this.radio * Math.Cos(t));
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                if ((t <= (90 * Math.PI / 180) && t >= 0) || (t <= (2 * Math.PI) && t >= (270 * Math.PI / 180)))
                {
                    v.Encender(Grafico);
                }
                t += dt;
            }

            Segmento seg = new Segmento();
            seg.color0 = this.color0;
            seg.x0 = this.x0;
            seg.y0 = this.y0 + this.radio;
            seg.xf = this.x0;
            seg.yf = this.y0 + 2 * this.radio;
            seg.Encender(Grafico);

            Segmento seg1 = new Segmento();
            seg1.color0 = this.color0;
            seg1.x0 = this.x0;
            seg1.y0 = this.y0 + this.radio * 2;
            seg1.xf = this.x0 + this.radio;
            seg1.yf = this.y0 + this.radio * 2;
            seg1.Encender(Grafico);
        }

        public void EncenderSies(Bitmap grafico)
        {
            double t = (100 * Math.PI / 180);
            double dt = 0.01;
            Vector v = new Vector();
            while (t <= (180 * Math.PI / 180))
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.color0 = this.color0;
                v.Encender(grafico);
                t += dt;
            }

            Segmento s = new Segmento();
            s.x0 = this.x0 + this.radio * Math.Cos(180 * Math.PI / 180);
            s.y0 = this.y0 + this.radio * Math.Sin(180 * Math.PI / 180);
            s.xf = this.x0 + this.radio * Math.Cos(180 * Math.PI / 180);
            s.yf = this.y0 + this.radio * Math.Sin(180 * Math.PI / 180) - 2 * this.radio;
            s.color0 = this.color0;
            s.Encender(grafico);

            t = 0;
            this.y0 = this.y0 - 2 * this.radio;
            while (t <= 2 * Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.color0 = this.color0;
                v.Encender(grafico);
                t += dt;
            }
        }

        public void EncenderSiete(Bitmap grafico)
        {

           

            Segmento s = new Segmento();
            s.x0 = this.x0 - this.radio;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0;
            s.color0 = this.color0;
            s.Encender(grafico);

            Segmento s1 = new Segmento();
            s1.x0 = this.x0;
            s1.y0 = this.y0;
            s1.xf = this.x0 - this.radio;
            s1.yf = this.y0 - this.radio;
            s1.color0 = this.color0;
            s1.Encender(grafico);

          
        }

        public void EncenderOcho(Bitmap grafico)
        {
            Vector objV = new Vector();
            double t, dt;
            t = 0;
            dt = 0.001;
            objV.color0 = color0;
            do
            {
                objV.x0 = x0 + radio * Math.Cos(t);
                objV.y0 = y0 + radio * Math.Sin(t);

                objV.Encender(grafico);
                t = t + dt;
            } while (t <= 2 * Math.PI);
        }
        public void EncendeNueve(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.01;
            Vector v = new Vector();
            while (t <= 2 * Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.color0 = this.color0;
                v.Encender(grafico);
                t += dt;
            }

            Segmento s = new Segmento();
            s.x0 = this.x0 + this.radio;
            s.y0 = this.y0;
            s.xf = this.x0 + this.radio;
            s.yf = this.y0 - 2 * this.radio;
            s.color0 = this.color0;
            s.Encender(grafico);

            t = (250 * Math.PI / 180);
            this.y0 = this.y0 - 2 * this.radio;

            while (t <= 2 * Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.color0 = this.color0;
                v.Encender(grafico);
                t += dt;
            }

        }







        public void lZ(Bitmap grafico)
        {



            Segmento s = new Segmento();
            s.x0 = this.x0 - this.radio;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0;
            s.color0 = this.color0;
            s.Encender(grafico);

            Segmento s1 = new Segmento();
            s1.x0 = this.x0;
            s1.y0 = this.y0;
            s1.xf = this.x0 - this.radio;
            s1.yf = this.y0 - this.radio;
            s1.color0 = this.color0;
            s1.Encender(grafico);

            Segmento s2 = new Segmento();
            s2.x0 = this.x0 - this.radio;
            s2.y0 = this.y0 - this.radio;
            s2.xf = this.x0;
            s2.yf = this.y0 - this.radio;
            s2.color0 = this.color0;
            s2.Encender(grafico);
        }



        //LETRAS..........




        public void Ld(Bitmap grafico)
        {
            double t = ((45 * Math.PI) / 180);
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.color0 = this.color0;
                vc.Encender(grafico);
                t += dt;
            } while (t < ((315 * Math.PI) / 180));

            Segmento sa = new Segmento();
            sa.x0 = this.x0 + this.radio;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = sa.y0 + this.radio * 2;
            sa.color0 = Color.Black;
            sa.Encender(grafico);
            sa.x0 = this.x0 + this.radio;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = sa.y0 - this.radio;
            sa.color0 = Color.Black;
            sa.Encender(grafico);
        }

        public void Lm(Bitmap Grafico)
        {
            double t = 0, dt = 0.001;
            this.radio = this.radio / 2;
            Vector v = new Vector();
            v.color0 = this.color0;
            while (t <= Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(Grafico);
                t += dt;
            }

            Segmento sm = new Segmento();
            sm.color0 = this.color0;
            sm.x0 = this.x0 + this.radio;
            sm.y0 = this.y0;
            sm.xf = this.x0 + this.radio;
            sm.yf = this.y0 - this.radio;
            sm.Encender(Grafico);
            sm.x0 = this.x0 - this.radio;
            sm.y0 = this.y0 + this.radio;
            sm.xf = this.x0 - this.radio;
            sm.yf = this.y0 - this.radio;
            sm.Encender(Grafico);

            this.x0 = this.x0 + this.radio * 2;

            t = 0;
            while (t <= Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(Grafico);
                t += dt;
            }

            sm.color0 = this.color0;
            sm.x0 = this.x0 + this.radio;
            sm.y0 = this.y0;
            sm.xf = this.x0 + this.radio;
            sm.yf = this.y0 - this.radio;
            sm.Encender(Grafico);
            sm.x0 = this.x0 - this.radio;
            sm.y0 = this.y0;
            sm.xf = this.x0 - this.radio;
            sm.yf = this.y0 - this.radio;
            sm.Encender(Grafico);

        }
        public void Ln(Bitmap Grafico)
        {
            double t = 0, dt = 0.001;
            this.radio = this.radio / 2;
            Vector v = new Vector();
            v.color0 = this.color0;
            while (t <= Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(Grafico);
                t += dt;
            }

            Segmento sm = new Segmento();
            sm.color0 = this.color0;
            sm.x0 = this.x0 + this.radio;
            sm.y0 = this.y0;
            sm.xf = this.x0 + this.radio;
            sm.yf = this.y0 - this.radio;
            sm.Encender(Grafico);
            sm.x0 = this.x0 - this.radio;
            sm.y0 = this.y0 + this.radio;
            sm.xf = this.x0 - this.radio;
            sm.yf = this.y0 - this.radio;
            sm.Encender(Grafico);



        }
    }
}
