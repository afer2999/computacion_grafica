using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Fractal:Circuenferencia
    {
        public Fractal() { }

        public double gama, beta;
        public Fractal(double x, double y, double r, Color c, double gama, double beta)
        {
            this.gama = gama;
            this.beta = beta;
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.c = c;


        }
        public void ArbolF(Bitmap grafico)
        {
            double r1 = radio, g1 = gama, x = x0, y = y0;
            Segmento ar = new Segmento();
            
            //ar.c = Color.FromArgb(247, 191, 190);

            if (radio > 0.1)
            {
                ar.x0 = x0;
                ar.y0 = y0;
                ar.xf = x0 + radio * Math.Cos(gama);
                ar.yf = y0 + radio * Math.Sin(gama);
                ar.c = this.c;               
                ar.EncSegmentoInterpolado(grafico);

                x0 = ar.xf;
                y0 = ar.yf;
                gama = gama - beta;
                radio = radio / 2;
                ArbolF(grafico);

                ar.x0 = x;
                ar.y0 = y;
                ar.xf = x + r1 * Math.Cos(g1);
                ar.yf = y + r1 * Math.Sin(g1);
                ar.c = this.c;
                ar.EncSegmentoInterpolado(grafico);

                x0 = ar.xf;
                y0 = ar.yf;
                gama = g1 + beta;
                radio = r1 / 2;
                ArbolF(grafico);

                x0 = ar.xf;
                y0 = ar.yf;
                gama = g1;
                radio = r1 / 1.7;
                ArbolF(grafico);
            }
        }

        public void Mandelbrot(double x, double y, out int colorM) {
            double xn1, yn1, xn, yn, d;
            int i = 0;
            xn = x;
            yn = y;
            do
            {
                i += 1;
                xn1 = (xn * xn) - (yn * yn) + x;
                yn1 = 2 * xn * yn + y;
                d = Math.Sqrt((Math.Pow((xn1 - x), 2)) + (Math.Pow((yn1 - y), 2)));
                xn = xn1;
                yn = yn1;
            } while ((d<2)&&(i<=100));

            if (d < 2) // CONVERGE XQ NUNCA SALIO DEL CIRCULO
            {
                colorM = 0;
            }
            else       // RETORNA LA POSICION I EN DONDE SALIO DEL CIRCULO Y LO PITA DE ACUERDO A LA POSICION --- DIVERGE 
            {
                colorM = (i % 14)+1;
            }
        }

        public void Julia(double x, double y, out int colorM) {
            double xn1, yn1, xn, yn, d;
            int i = 0;
            xn = x;
            yn = y;
            do
            {
                i += 1;
                xn1 = (xn * xn) - (yn * yn) -1;
                yn1 = 2 * xn * yn + 0.25;
                d = Math.Sqrt((Math.Pow((xn1), 2)) + (Math.Pow((yn1), 2)));
                xn = xn1;
                yn = yn1;
            } while ((d<2)&&(i<=100));

            if (d < 2) // CONVERGE XQ NUNCA SALIO DEL CIRCULO
            {
                colorM = 0;
            }
            else       // RETORNA LA POSICION I EN DONDE SALIO DEL CIRCULO Y LO PITA DE ACUERDO A LA POSICION --- DIVERGE 
            {
                colorM = (i % 14)+1;
            }
        }

        public void Dibujar_Sierpinski(double Ax, double Ay, double Bx, double By, double Cx, double Cy, int N, Bitmap grafico)
        {
            Segmento sg = new Segmento(0, 0, 0, 0, c);
            double ABx, BCx, CAx, ABy, BCy, CAy;
            if (N == 0)
            {
                // Triángulo Mínimo   
                sg.x0 = Ax;
                sg.y0 = Ay;
                sg.xf = Bx;
                sg.yf = By;
                sg.EncenderSegmento(grafico);
                sg.x0 = Bx;
                sg.y0 = By;
                sg.xf = Cx;
                sg.yf = Cy;
                sg.EncenderSegmento(grafico);
                sg.x0 = Ax;
                sg.y0 = Ay;
                sg.xf = Cx;
                sg.yf = Cy;
                sg.EncenderSegmento(grafico);

            }
            else
            {
                // Dividir en 3 triángulos
                ABx = Mitad(Ax, Bx);
                BCx = Mitad(Bx, Cx);
                CAx = Mitad(Cx, Ax);
                ABy = Mitad(Ay, By);
                BCy = Mitad(By, Cy);
                CAy = Mitad(Cy, Ay);
                Dibujar_Sierpinski(Ax, Ay, ABx, ABy, CAx, CAy, N - 1,grafico);
                Dibujar_Sierpinski(ABx, ABy, Bx, By, BCx, BCy, N - 1,grafico);
                Dibujar_Sierpinski(CAx, CAy, BCx, BCy, Cx, Cy, N - 1,grafico);
            }
        }
        public double Mitad(double P1, double P2)
        {
            double resultado;
            resultado = (P1 + P2) / 2;
            return resultado;
        }

        public void Cantor(Segmento s, Bitmap grafico)
        {

            if (s.yf <= -10)
                return;

            s.yf -= 1.5;
            double d = (s.xf - s.x0) / 3;

            Segmento s1 = new Segmento(s.x0, s.yf, s.x0 + d, s.yf, Color.Green);
            s1.EncenderSegmento(grafico);
            Segmento s2 = new Segmento(s.xf - d, s.yf, s.xf, s.yf, Color.Blue);
            s2.EncenderSegmento(grafico);
            Cantor(s1,grafico);
            Cantor(s2,grafico);
        }
       
    }
}
