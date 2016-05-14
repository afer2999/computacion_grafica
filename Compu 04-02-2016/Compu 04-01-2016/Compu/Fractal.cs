using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compu
{
    class Fractal: Circuenferencia
    {
        public double alfa1;
        public double gama, beta;
        public Fractal( double x, double y, double r,double g, double b, Color color, Bitmap gra, PictureBox view)
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
        public void ArbolF()
        { 
            double x=x0,y=y0,g1=gama,r1=radio;
            Segmento s = new Segmento(0, 0, 0,0, c, grafico, ViewPort, 0);
            if (radio > 0.1)
            {
                s.x0 = x0;
                s.y0 = y0;
                s.xf = x0 + radio * Math.Cos(gama);
                s.yf = y0 + radio * Math.Sin(gama);
                s.Encender();
                x0 = s.xf;
                y0 = s.yf;
                gama = gama - beta;
                radio = radio / 2;
                ArbolF();
                x0 = s.xf;
                y0 = s.yf;
                gama = g1 + beta;
                radio = r1 / 2;
                ArbolF();
                x0 = s.xf;
                y0 = s.yf;
                gama = g1;
                radio = r1 / 1.7;
                ArbolF();
            }
        }
        public void Mandelbrot(double x, double y, out int colorM)
        {
            double xn1, yn1, xn=x, yn=y, d;
            int i=0;
            do
            {
                i = i + 1;
                xn1 =xn*xn - yn*yn + x;
                yn1 = 2 * xn * yn + y;
                d = Math.Sqrt(Math.Pow((xn1-x),2)+Math.Pow((yn1-y),2));
                xn = xn1;
                yn = yn1;
            } while ((d<2) && (i<=100));
            if (d < 2)//converge
            {
                colorM = 0;
            }
            else {//diverge
                colorM = (i % 14)+1;
            }
        }
        public void Julia(double x, double y, out int colorM)
        {
            double xn1, yn1, xn = x, yn = y, d;
            int i = 0;
            do
            {
                i = i + 1;
                xn1 = xn * xn - yn * yn -1;
                yn1 = 2 * xn * yn + 0.25;
                d = Math.Sqrt(Math.Pow((xn1), 2) + Math.Pow((yn1), 2));
                xn = xn1;
                yn = yn1;
            } while ((d < 2) && (i <= 100));
            if (d < 2)//converge
            {
                colorM = 0;
            }
            else
            {//diverge
                colorM = (i % 14) + 1;
            }
        }
        public void Flor()
        {
            double t = 0, dt = 0.003;
            Vector Margarita = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros creamos
            do
            {
                Margarita.x0 = x0 + (0.7 * Math.Cos(4 * t) * Math.Cos(t)) * radio;
                Margarita.y0 = y0 + (0.7 * Math.Cos(4 * t) * Math.Sin(t)) * radio;
                Margarita.Encender();
                t = t + dt;
            } while (t <= 2 * Math.PI);
            
        }
        public void Nubes()
        {
            double t = 0, dt = 0.003;
            Vector Lemiscata = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros creamos
            do
            {
                for (double i = 0; i < radio; i += 0.002)
                {
                    Lemiscata.x0 = x0 + ((8 * Math.Cos(t) - Math.Cos(8 * t)) / 4) * i * 3;
                    Lemiscata.y0 = y0 + ((8 * Math.Sin(t) - Math.Sin(8 * t)) / 4) * i;
                    Lemiscata.Encender();
                }
                    t = t + dt;
            } while (t <= 2 * Math.PI);
        }
        public void luna()
        {

            double radio = alfa1;
            Circuenferencia circunferencia = new Circuenferencia(0,0,0,c,grafico,ViewPort,0);
            while (radio >= 2)
            {
                circunferencia.x0 = x0;
                circunferencia.y0 = y0;
                circunferencia.radio = radio;
                //circunferencia.COLOR = Color.FromArgb((int)((300 - (75 * radio)) / -2), (int)((300 - (75 * radio)) / -2), (int)((300 - (75 * radio)) / -2));
                circunferencia.c = Color.FromArgb((int)(440 - (110 * radio)), (int)(440 - (110 * radio)), (int)(440 - (110 * radio)));
                circunferencia.Encender();
                radio -= 0.05;
            }
            while (radio >= 0 && radio < 2)
            {
                circunferencia.x0 = x0;
                circunferencia.y0 = y0;
                circunferencia.radio = radio;
                circunferencia.c = Color.FromArgb((int)((235 * radio / 2) + ((250 * (radio - 2)) / -2)),
                    (int)((235 * radio / 2) + ((250 * (radio - 2)) / -2)),
                    (int)((235 * radio / 2) + ((250 * (radio - 2)) / -2)));
                circunferencia.Encender();
                radio -= 0.05;

            }
        }
      public void  Dibujar_Sierpinski( double Ax,double Ay,double Bx, double By, double Cx, double Cy, int N )
      {
          Segmento sg= new Segmento(0,0,0,0,c,grafico,ViewPort,0);
          double ABx,BCx,CAx,ABy,BCy,CAy;
          if (N==0)
	        {
		            // Triángulo Mínimo   
                        sg.x0=Ax;
                        sg.y0=Ay;
                        sg.xf=Bx;
                        sg.yf=By;
                        sg.Encender();
                        sg.x0=Bx;
                        sg.y0=By;
                        sg.xf=Cx;
                        sg.yf=Cy;
                        sg.Encender();
                        sg.x0=Ax;
                        sg.y0=Ay;
                        sg.xf=Cx;
                        sg.yf=Cy;
                        sg.Encender();
              
	        }
          else{
              // Dividir en 3 triángulos
                ABx=Mitad( Ax, Bx );
                BCx =Mitad( Bx, Cx );
                CAx=Mitad( Cx, Ax );
                ABy = Mitad(Ay, By);
                BCy = Mitad(By, Cy);
                CAy = Mitad(Cy, Ay);
                Dibujar_Sierpinski( Ax,Ay, ABx,ABy, CAx,CAy, N-1 );
                Dibujar_Sierpinski(ABx, ABy, Bx,By, BCx,BCy, N - 1);
                Dibujar_Sierpinski( CAx,CAy, BCx,BCy, Cx,Cy, N-1 );
          }
      }
       public double Mitad( double P1, double P2 )
       {
           double resultado;
           resultado=(P1 + P2) / 2;
           return resultado;
       }
      /* public void Dibujar_Cantor(double Lx0, double Ly0, double Lxf, double Lyf)
       {
           double a,b;
           Segmento cant = new Segmento(0, 0, 0, Lyf, c, grafico, ViewPort, 0);
           if (cant.yf <= 0)
               return;
               a = Lx0 / 3;
               b = (2 * Lx0) / 3;
               cant.x0 = Lx0;
               cant.y0 = Ly0;
               cant.xf = Lx0 / 3;
               cant.yf = Ly0;
               cant.Encender();
               cant.x0 = (2 * Lx0) / 3;
               cant.y0 = Ly0;
               cant.xf = Lxf;
               cant.yf = Ly0;
               cant.Encender();
               Dibujar_Cantor(Lx0, Ly0 - 1, a, Lyf - 1);
               Dibujar_Cantor(b, Ly0 - 1, Lxf, Lyf - 1);
            
       }*/
       //public void Cantor(Segmento s)
       //{

       //    if (s.yf <= -10)
       //        return;

       //    s.yf -= 1.5;
       //    double d = (s.xf - s.x0) / 3;

       //    Segmento s1 = new Segmento(s.x0, s.yf, s.x0 + d, s.yf, Color.Green, grafico, ViewPort, 0); s1.Encender();
       //    Segmento s2 = new Segmento(s.xf - d, s.yf, s.xf, s.yf, Color.Blue, grafico, ViewPort, 0); s2.Encender();
       //    ViewPort.Refresh();
       //    Cantor(s1);
       //    Cantor(s2);

       //}
    }
}
