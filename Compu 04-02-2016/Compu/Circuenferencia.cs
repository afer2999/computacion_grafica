using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Circuenferencia : Vector
    {
        public double radio;

        public Circuenferencia() { }
        public Circuenferencia(double x, double y, double r, Color c)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.c = c;
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

                //vc.c = this.c;
                //INTERPOLACION DE COLORES 
                vc.c = Color.FromArgb(0,255,0);/*
                Convert.ToInt32((255 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (53 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((255 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (8 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((8 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (255 * (t - 0) / ((2 * Math.PI) - 0))));
                */
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        public void ApagarCircunferencia(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);

                //vc.c = this.c;
                //INTERPOLACION DE COLORES 
                vc.c = Color.White;

                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        public void EncenderI(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.c = this.c;
                /*Color.FromArgb(
                Convert.ToInt32((0 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (5 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((255 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (0 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((0 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (0 * (t - 0) / ((2 * Math.PI) - 0))));*/
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        //********************* Circunferencias entrecortada *********************//
        public void CEntrecortada(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            double c = 0;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.c = this.c;
                if (c % 25 == 0) {
                    vc.Encender(grafico);
                }
                t += dt;
                c += 1;
            } while (t <= 2 * Math.PI);
        }

        //********************* Circunferencias Llenada *********************//

        public void CLlenada(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                for (double i = 0; i < radio; i += 0.02)
                {
                    vc.x0 = x0 + i * Math.Cos(t);
                    vc.y0 = y0 + i * Math.Sin(t);
                    vc.c = this.c;
                    vc.Encender(grafico);
                }
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        //********************* LETRAS *********************//

        public void Letrateta(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t)*1.4;
                vc.c = this.c;
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);

            Segmento sa = new Segmento();
            sa.c = Color.Black;
            sa.x0 = this.x0;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = this.y0;
            sa.EncenderSegmento(grafico);
            sa.x0 = this.x0;
            sa.y0 = this.y0;
            sa.xf = this.x0 - this.radio;
            sa.yf = this.y0 ;
            sa.EncenderSegmento(grafico);
        }

        
        public void Letraa(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.c = this.c;
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);

            Segmento sa = new Segmento();
            sa.x0 = this.x0 + this.radio;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = sa.y0 + this.radio;
            sa.EncenderSegmento(grafico);
            sa.x0 = this.x0 + this.radio;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = sa.y0 - this.radio;
            sa.EncenderSegmento(grafico);
        }

        public void Letrab(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            vc.c = this.c;
            while (t <= 2 * Math.PI)
            {
                vc.x0 = this.x0 + this.radio * Math.Cos(t);
                vc.y0 = this.y0 + this.radio * Math.Sin(t);
                if ((t <= (110 * Math.PI / 180) && t >= 0) || (t <= (2 * Math.PI) && t >= (250 * Math.PI / 180)))
                {
                    vc.Encender(grafico);
                }
                t += dt;
            }

            Segmento p = new Segmento();
            p.x0 = this.x0 + this.radio * Math.Cos((250 * Math.PI) / 180);
            p.y0 = (this.y0 + this.radio * Math.Sin((250 * Math.PI) / 180)) - this.radio / 5;
            p.xf = this.x0 + this.radio * Math.Cos((250 * Math.PI) / 180);
            p.yf = (this.y0 + this.radio * Math.Sin((250 * Math.PI) / 180)) + this.radio * 3;
            p.EncenderSegmento(grafico);

        }

        public void Letrac(Bitmap grafico)
        {
            double t = ((45 * Math.PI) / 180);
            double dt = 0.001;
            Vector vc = new Vector();
            vc.c = this.c;
            while (t <= ((315 * Math.PI) / 180))
            {
                vc.x0 = this.x0 + this.radio * Math.Cos(t);
                vc.y0 = this.y0 + this.radio * Math.Sin(t);
                vc.Encender(grafico);
                t += dt;
            }
        }

        public void Letrad(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.c = this.c;
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);

            Segmento sa = new Segmento();
            sa.x0 = this.x0 + this.radio;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = sa.y0 + this.radio * 2;
            sa.EncenderSegmento(grafico);
            sa.x0 = this.x0 + this.radio;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = sa.y0 - this.radio;
            sa.EncenderSegmento(grafico);
        }

        public void Letrae(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            vc.c = this.c;
            while (t <= ((315 * Math.PI) / 180))
            {
                vc.x0 = this.x0 + this.radio * Math.Cos(t);
                vc.y0 = this.y0 + this.radio * Math.Sin(t);
                vc.Encender(grafico);
                t += dt;
            }

            Segmento sa = new Segmento();
            sa.x0 = this.x0;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = sa.y0;
            sa.EncenderSegmento(grafico);
            sa.x0 = this.x0;
            sa.y0 = this.y0;
            sa.xf = this.x0 - this.radio;
            sa.yf = sa.y0;
            sa.EncenderSegmento(grafico);
        }

        public void Letraf(Bitmap grafico)
        {
            double t = ((30 * Math.PI) / 180);
            double dt = 0.001;
            Vector vc = new Vector();
            vc.c = this.c;
            while (t <= ((180 * Math.PI) / 180))
            {
                vc.x0 = this.x0 + this.radio * Math.Cos(t);
                vc.y0 = this.y0 + this.radio * Math.Sin(t);
                vc.Encender(grafico);
                t += dt;
            }

            Segmento sa = new Segmento();
            sa.c = Color.Black;
            sa.x0 = this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180);
            sa.y0 = this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180);
            sa.xf = this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180);
            sa.yf = (this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180)) - this.radio;
            sa.EncenderSegmento(grafico);

            sa.x0 = (this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180));
            sa.y0 = (this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180)) - this.radio;
            sa.xf = (this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180)) + this.radio / 2;
            sa.yf = (this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180)) - this.radio;
            sa.EncenderSegmento(grafico);
            sa.x0 = (this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180));
            sa.y0 = (this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180)) - this.radio;
            sa.xf = (this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180)) - this.radio / 2;
            sa.yf = (this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180)) - this.radio;
            sa.EncenderSegmento(grafico);
            sa.x0 = this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180);
            sa.y0 = (this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180)) - this.radio;
            sa.xf = this.x0 + this.radio * Math.Cos((180 * Math.PI) / 180);
            sa.yf = (this.y0 + this.radio * Math.Sin((180 * Math.PI) / 180)) - this.radio * 3;
            sa.EncenderSegmento(grafico);
        }

        public void Letrag(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            vc.c = this.c;
            while (t <= (2 * Math.PI))
            {
                vc.x0 = this.x0 + this.radio * Math.Cos(t);
                vc.y0 = this.y0 + this.radio * Math.Sin(t);
                vc.Encender(grafico);
                t += dt;
            }

            Segmento sa = new Segmento();
            sa.x0 = this.x0 + this.radio * Math.Cos(2 * Math.PI);
            sa.y0 = this.y0 + this.radio * Math.Sin(2 * Math.PI);
            sa.xf = this.x0 + this.radio * Math.Cos(2 * Math.PI);
            sa.yf = (this.y0 + this.radio * Math.Sin(2 * Math.PI)) - this.radio * 2;
            sa.EncenderSegmento(grafico);

            t = ((250 * Math.PI) / 180);
            while (t <= (2 * Math.PI))
            {
                vc.x0 = (this.x0 + this.radio * Math.Cos(t));
                vc.y0 = (this.y0 + this.radio * Math.Sin(t)) - 2 * this.radio;
                vc.Encender(grafico);
                t += dt;
            }

        }

        public void Letrah(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            vc.c = this.c;
            while (t <= ((120 * Math.PI) / 180))
            {
                vc.x0 = this.x0 + this.radio * Math.Cos(t);
                vc.y0 = this.y0 + this.radio * Math.Sin(t);
                vc.Encender(grafico);
                t += dt;
            }

            Segmento sa = new Segmento();
            sa.c = Color.Black;
            sa.x0 = this.x0 + this.radio * Math.Cos((120 * Math.PI) / 180);
            sa.y0 = this.y0 + this.radio * Math.Sin((120 * Math.PI) / 180);
            sa.xf = this.x0 + this.radio * Math.Cos((120 * Math.PI) / 180);
            sa.yf = (this.y0 + this.radio * Math.Sin((120 * Math.PI) / 180)) + this.radio * 2;
            sa.EncenderSegmento(grafico);

            sa.x0 = this.x0 + this.radio * Math.Cos((120 * Math.PI) / 180);
            sa.y0 = this.y0 + this.radio * Math.Sin((120 * Math.PI) / 180);
            sa.xf = this.x0 + this.radio * Math.Cos((120 * Math.PI) / 180);
            sa.yf = (this.y0 + this.radio * Math.Sin((120 * Math.PI) / 180)) - this.radio - 1.2;
            sa.EncenderSegmento(grafico);

            sa.x0 = this.x0 + this.radio;
            sa.y0 = this.y0;
            sa.xf = this.x0 + this.radio;
            sa.yf = this.y0 - this.radio + 0.5;
            sa.EncenderSegmento(grafico);
        }

        public void EncenderCirculoLm(Bitmap Grafico)
        {
            double t = 0, dt = 0.001;
            this.radio = this.radio / 2;
            Vector v = new Vector();
            v.c = this.c;
            while (t <= Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(Grafico);
                t += dt;
            }

            Segmento sm = new Segmento();
            sm.c = this.c;
            sm.x0 = this.x0 + this.radio;
            sm.y0 = this.y0;
            sm.xf = this.x0 + this.radio;
            sm.yf = this.y0 - this.radio;
            sm.EncenderSegmento(Grafico);
            sm.x0 = this.x0 - this.radio;
            sm.y0 = this.y0 + this.radio;
            sm.xf = this.x0 - this.radio;
            sm.yf = this.y0 - this.radio;
            sm.EncenderSegmento(Grafico);

            this.x0 = this.x0 + this.radio * 2;

            t = 0;
            while (t <= Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(Grafico);
                t += dt;
            }

            sm.c = this.c;
            sm.x0 = this.x0 + this.radio;
            sm.y0 = this.y0;
            sm.xf = this.x0 + this.radio;
            sm.yf = this.y0 - this.radio;
            sm.EncenderSegmento(Grafico);
            sm.x0 = this.x0 - this.radio;
            sm.y0 = this.y0;
            sm.xf = this.x0 - this.radio;
            sm.yf = this.y0 - this.radio;
            sm.EncenderSegmento(Grafico);

        }

        public void Letrai(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            vc.c = this.c;
            while (t <= (2 * Math.PI))
            {
                vc.x0 = this.x0 + this.radio * Math.Cos(t);
                vc.y0 = this.y0 + this.radio * Math.Sin(t);
                vc.Encender(grafico);
                t += dt;
            }
            //t = 0;
            Segmento sa = new Segmento();
            sa.x0 = this.x0;
            sa.y0 = this.y0 - this.radio * 2;
            sa.xf = this.x0;
            sa.yf = this.y0 - this.radio * 10;
            sa.EncenderSegmento(grafico);


        }

        public void Letraq(Bitmap grafico)
        {
            double t = ((30 * Math.PI) / 180);
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.c = this.c;
                vc.Encender(grafico);
                t += dt;
            } while (t <= (330 * Math.PI) / 180);

            Segmento sa = new Segmento();
            sa.c = Color.Black;
            sa.x0 =x0 + this.radio * Math.Cos((30 * Math.PI) / 180);
            sa.y0 = y0+radio;
            sa.xf = x0 + this.radio * Math.Cos((30 * Math.PI) / 180);
            sa.yf = y0 - this.radio * 2;
            sa.EncenderSegmento(grafico);
            
        }

        
// NÚMEROS 

        public void EncenderUno(Bitmap grafico)
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
            s1.c = Color.Violet;
            s1.EncenderSegmento(grafico);

            Segmento s = new Segmento();
            s.x0 = this.x0;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0 - 2 * Math.PI;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 + this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 - this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);
         }

        public void EncenderDos(Bitmap Grafico)
        {
            double t = (20 * Math.PI / 180), dt = 0.001;
            Vector v = new Vector();
            v.c = this.c;

            while (t <= (Math.PI))
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(Grafico);
                t += dt;
            }

            Segmento sm = new Segmento();
            sm.c = this.c;
            sm.x0 = this.x0 + this.radio * Math.Cos(20 * Math.PI / 180);
            sm.y0 = this.y0 + this.radio * Math.Sin(20 * Math.PI / 180);
            sm.xf = this.x0 + this.radio * Math.Cos(Math.PI);
            sm.yf = this.y0 + this.radio * Math.Sin(Math.PI) - radio;
            sm.EncenderSegmento(Grafico);
            sm.x0 = this.x0 + this.radio * Math.Cos(Math.PI);
            sm.y0 = this.y0 + this.radio * Math.Sin(Math.PI) - radio;
            sm.xf = this.x0 + this.radio * Math.Cos(2 * Math.PI);
            sm.yf = this.y0 + this.radio * Math.Sin(2 * Math.PI) - radio;
            sm.EncenderSegmento(Grafico);
        }

        public void EncenderTres(Bitmap Grafico)
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector();
            v.c = this.c;
            while (t <= 2 * Math.PI)
            {
                v.x0 = (this.x0 + this.radio * Math.Cos(t));
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                if ((t <= (110 * Math.PI / 180) && t >= 0) || (t <= (2 * Math.PI) && t >= (250 * Math.PI / 180)))
                {
                    v.Encender(Grafico);
                }
                t += dt;
                v.x0 = (this.x0 + this.radio * Math.Cos(t));
                v.y0 = this.y0 + this.radio + this.radio + this.radio * Math.Sin(t);
                if ((t <= (90 * Math.PI / 180) && t >= 0) || (t <= (2 * Math.PI) && t >= (250 * Math.PI / 180)))
                {
                    v.Encender(Grafico);
                }
                //t += dt;
            }
        }

        public void EncenderCuatro(Bitmap grafico)
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
            s1.c = Color.Violet;
            s1.EncenderSegmento(grafico);

            Segmento s = new Segmento();
            s.x0 = this.x0;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0 - 2 * Math.PI;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);

            s.x0 = this.x0 - this.radio;
            s.y0 = this.y0 - this.radio;
            s.xf = this.x0;
            s.yf = this.y0 - this.radio;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 + this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);

            s.x0 = this.x0;
            s.y0 = this.y0 - 2 * Math.PI;
            s.xf = this.x0 - this.radio / 4;
            s.yf = this.y0 - 2 * Math.PI;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);
        }

        public void EncenderCinco(Bitmap Grafico)
        {

            double t = 0, dt = 0.001;
            Vector v = new Vector();
            v.c = this.c;
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
            seg.c = this.c;
            seg.x0 = this.x0;
            seg.y0 = this.y0 + this.radio;
            seg.xf = this.x0;
            seg.yf = this.y0 + 2 * this.radio;
            seg.EncenderSegmento(Grafico);

            Segmento seg1 = new Segmento();
            seg1.c = this.c;
            seg1.x0 = this.x0;
            seg1.y0 = this.y0 + this.radio * 2;
            seg1.xf = this.x0 + this.radio;
            seg1.yf = this.y0 + this.radio * 2;
            seg1.EncenderSegmento(Grafico);
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
                v.c = this.c;
                v.Encender(grafico);
                t += dt;
            }

             Segmento s = new Segmento();
             s.x0 = this.x0 + this.radio * Math.Cos(180 * Math.PI / 180);
             s.y0 = this.y0 + this.radio * Math.Sin(180 * Math.PI / 180);
             s.xf = this.x0 + this.radio * Math.Cos(180 * Math.PI / 180);
             s.yf = this.y0 + this.radio * Math.Sin(180 * Math.PI / 180) - 2 * this.radio;
             s.c = Color.Violet;
             s.EncenderSegmento(grafico);
            
             t = 0;
            this.y0 = this.y0 - 2 * this.radio;
            while (t <= 2 * Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.c = this.c;
                v.Encender(grafico);
                t += dt;
            }
        }

        public void EncenderSiete(Bitmap grafico)
        {

            double t = Math.PI / 2;
            double dt = 0.01;
            Vector v = new Vector();
            while (t <= Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.Encender(grafico);
                t += dt;
            }

            Segmento s = new Segmento();
            s.x0 = this.x0 - this.radio;
            s.y0 = this.y0;
            s.xf = this.x0;
            s.yf = this.y0;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);

            Segmento s1 = new Segmento();
            s1.x0 = this.x0;
            s1.y0 = this.y0;
            s1.xf = this.x0 - this.radio;
            s1.yf = this.y0 - this.radio;
            s1.c = Color.Violet;
            s1.EncenderSegmento(grafico);
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
                v.c = this.c;
                v.Encender(grafico);
                t += dt;
            }

            Segmento s = new Segmento();
            s.x0 = this.x0 + this.radio;
            s.y0 = this.y0;
            s.xf = this.x0 + this.radio;
            s.yf = this.y0 - 2 * this.radio;
            s.c = Color.Violet;
            s.EncenderSegmento(grafico);

            t = (250 * Math.PI / 180);
            this.y0 = this.y0 - 2 * this.radio;

            while (t <= 2 * Math.PI)
            {
                v.x0 = this.x0 + this.radio * Math.Cos(t);
                v.y0 = this.y0 + this.radio * Math.Sin(t);
                v.c = this.c;
                v.Encender(grafico);
                t += dt;
            }

        }

    }
}
