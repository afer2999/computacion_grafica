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
    class cFractal:cCircunferencia
    {
       public double alfa1;
        public double alfa2;
        public double gama, beta;
        public cFractal(double x, double y, double r, double g, double b, Color color, Bitmap gra, PictureBox view)
        {
            gama = g;
            beta = b;
            x0 = x;
            y0 = y;
            radio = r;
            c = color;
            grafico = gra;
            ViewPort = view;
        }
        public void ArbolFractal()
        {
            double  g1 = gama, r1 = radio;
            cSegmento s = new cSegmento(0, 0, 0, 0, c, grafico, ViewPort, 1);
            if (radio > 0.1)
            {
                s.x0 = x0;
                s.y0 = y0;
                s.xf = x0 + radio * Math.Cos(gama);
                s.yf = y0 + radio * Math.Sin(gama);
                s.EcenderS();
                
                
                x0 = s.xf;
                y0 = s.yf;
                gama = gama - beta;
                radio = radio / 2;
                ArbolFractal();

                x0 = s.xf;
                y0 = s.yf;
                gama = g1 + beta;
                radio = r1 / 2;
                ArbolFractal();


                x0 = s.xf;
                y0 = s.yf;
                gama = g1;
                radio = r1 / 1.7;
                ArbolFractal();
            }
        }

        public void Mandelbrot(double x, double y, out int colorM)
        {
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
            } while ((d < 2) && (i <= 100));

            if (d < 2) // CONVERGE XQ NUNCA SALIO DEL CIRCULO
            {
                colorM = 0;
            }
            else       // RETORNA LA POSICION I EN DONDE SALIO DEL CIRCULO Y LO PITA DE ACUERDO A LA POSICION --- DIVERGE 
            {
                colorM = (i % 14) + 1;
            }
        }

        public void Julia(double x, double y, out int colorM)
        {
            double xn1, yn1, xn, yn, d;
            int i = 0;
            xn = x;
            yn = y;
            do
            {
                i += 1;
                xn1 = (xn * xn) - (yn * yn) - 1;
                yn1 = 2 * xn * yn + 0.25;
                d = Math.Sqrt((Math.Pow((xn1), 2)) + (Math.Pow((yn1), 2)));
                xn = xn1;
                yn = yn1;
            } while ((d < 2) && (i <= 100));

            if (d < 2) // CONVERGE XQ NUNCA SALIO DEL CIRCULO
            {
                colorM = 0;
            }
            else       // RETORNA LA POSICION I EN DONDE SALIO DEL CIRCULO Y LO PITA DE ACUERDO A LA POSICION --- DIVERGE 
            {
                colorM = (i % 14) + 1;
            }
        }

        public void Dibujar_Sierpinski(double Ax, double Ay, double Bx, double By, double Cx, double Cy, int N, Bitmap grafico)
        {
            cSegmento sg = new cSegmento(0, 0, 0, 0, this.c,grafico,ViewPort,0);
            double ABx, BCx, CAx, ABy, BCy, CAy;
            if (N == 0)
            {
                // Triángulo Mínimo   
                sg.x0 = Ax;
                sg.y0 = Ay;
                sg.xf = Bx;
                sg.yf = By;
                sg.EcenderS();
                sg.x0 = Bx;
                sg.y0 = By;
                sg.xf = Cx;
                sg.yf = Cy;
                sg.EcenderS();
                sg.x0 = Ax;
                sg.y0 = Ay;
                sg.xf = Cx;
                sg.yf = Cy;
                sg.EcenderS();

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
                Dibujar_Sierpinski(Ax, Ay, ABx, ABy, CAx, CAy, N - 1, grafico);
                Dibujar_Sierpinski(ABx, ABy, Bx, By, BCx, BCy, N - 1, grafico);
                Dibujar_Sierpinski(CAx, CAy, BCx, BCy, Cx, Cy, N - 1, grafico);
            }
        }
        public double Mitad(double P1, double P2)
        {
            double resultado;
            resultado = (P1 + P2) / 2;
            return resultado;
        }

        public void Cantor(cSegmento s, Bitmap grafico)
        {

            if (s.yf <= -10)
                return;

            s.yf -= 1.5;
            double d = (s.xf - s.x0) / 3;

            cSegmento s1 = new cSegmento(s.x0, s.yf, s.x0 + d, s.yf, this.c,grafico,ViewPort,0);
            s1.EcenderS();
            cSegmento s2 = new cSegmento(s.xf - d, s.yf, s.xf, s.yf, this.c, grafico, ViewPort, 0);
            s1.EcenderS();
            Cantor(s1, grafico);
            Cantor(s2, grafico);
        }

    }




}
