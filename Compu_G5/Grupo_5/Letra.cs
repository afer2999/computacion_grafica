using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo_5
{
    class Letra : Vector
    {
        public double Radio;
        //constructor
        public Letra(double nX0, double nY0, double nRadio, Color nColor0, PictureBox nViewPort, Bitmap nGrafico)
            : base(nX0, nY0, nColor0, nViewPort, nGrafico)
        {
            X0 = nX0;
            Y0 = nY0;
            Radio = nRadio;
            Color0 = nColor0;
            ViewPort = nViewPort;
            Grafico = nGrafico;
        }

        //destructor
        ~Letra()
        { }
        //procesos
        
        public override void Encender()
        {


            Vector cir = new Vector(0, 0, Color0, ViewPort, Grafico);

            double t = 0;
            double dt = 0.001;
            do
            {
                // se suma el xo y el yo para q ue se pueda mover
                //tiene que poner para poder mover de lado a lado
                //en todas las circunferencias
                cir.X0 = Radio * Math.Cos(t) + X0;
                cir.Y0 = 1.5 * Radio * Math.Sin(t) + Y0;
                cir.Encender();
                Segmento le = new Segmento(X0 - Radio, Y0, X0 + Radio, Y0, Color0, ViewPort, Grafico);
                le.Encender();
                t += dt;
            } while (t <= (Math.PI * 2));
        }



        
        public  void letrat()
        {
            double t = -3.25, dt = 0.003;
            Vector seg = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            do
            {
                seg.X0 = X0 + (Radio) * Math.Cos(t);
                seg.Y0 = Y0 + (Radio) * Math.Sin(t);
                Segmento seg1 = new Segmento((X0 - Radio), Y0, (X0 - Radio), Y0 + (2 * Radio), Color0, ViewPort, Grafico);
                Segmento seg2 = new Segmento(X0, Y0 + Radio, X0 - (Radio * 1.5), Y0 + Radio, Color0, ViewPort, Grafico);
                seg.Encender();
                seg1.Encender();
                seg2.Encender();
                t = t + dt;
            } while (t <= -1* Math.PI/4 );
        }



        public void casa()
        {
            //double t = -3.25, dt = 0.003;
            Vector seg = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            

                Segmento seg1 = new Segmento(X0, Y0, X0, Y0, Color0, ViewPort, Grafico);

                Segmento seg2 = new Segmento(5+X0, Y0, X0, Y0, Color0, ViewPort, Grafico);

                Segmento seg3 = new Segmento(X0, Y0, X0+5, Y0, Color0, ViewPort, Grafico);

                Segmento seg4 = new Segmento(X0, Y0, X0, Y0+5, Color0, ViewPort, Grafico);

                seg1.Encender();
                seg2.Encender();
                seg3.Encender();
                seg4.Encender();
           
        }
        /// </summary>







        /*
        public void letrat()
        {
            double t, dt;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            t = Math.PI;
            dt = 0.001;
            do
            {
                v.X0 = X0 + (Radio * Math.Cos(t));
                v.Y0 = Y0 + (Radio * Math.Sin(t));
                v.Encender();
                t = t + dt;
            } while (t <= 2 * Math.PI);
        }*/

        public void letras()
        {
            double dt=0.001;
            double t = Math.PI/5;
            Vector seg = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            do
            {
                seg.X0 = X0 + (Radio * Math.Cos(t));
                seg.Y0 = Y0 + (Radio * Math.Sin(t));
                seg.Encender();
                t = t + dt;
         } while (t <= (1 * 6 ) - (Math.PI/3));
        }

        public void letras2()
        {
            double dt = 0.001;
            double t = Math.PI / 3;
            Vector seg = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            do
            {
                seg.X0 = X0 + (Radio * Math.Cos(t));
                seg.Y0 = Y0 + (Radio * Math.Sin(t));
                seg.Encender();
                t = t + dt;
              } while (t <= (1 * 6) - (Math.PI / 8));
            }
        public void letrad()
        {
            double dt = 0.001;
            double t = Math.PI / 8;
            Vector seg = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            do
            {
                seg.X0 = X0 + (Radio * Math.Cos(t));
                seg.Y0 = Y0 + (Radio * Math.Sin(t));
                seg.Encender();
                t = t + dt;
            } while (t <= (2 * 3.141516) - (Math.PI / 8));
        }

        }
}
