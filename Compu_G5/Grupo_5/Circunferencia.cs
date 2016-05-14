using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo_5
{
    class Circunferencia : Vector
    {

        //public static PictureBox Viewport;
        public static Graphics SGrafico;

       

        public double Radio;
        public Circunferencia(double nX0, double nY0, double nRadio, Color nColor0, PictureBox nViewPort, Bitmap nGrafico)
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
        ~Circunferencia()
        { }
        //procesos
        public override void Encender()
        {
            //permite crear la circunferencia 
            double t, dt;
            
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            t = 0;
             dt=0.001;
            //dt = 0.001;
            do
            {
                v.X0 = X0 + (Radio * Math.Cos(t));
                v.Y0 = Y0 + (Radio * Math.Sin(t));
               
                
                v.Encender();
                t = t + dt;
            } while (t <= 2 * Math.PI);
        }
          /// <summary>
          /// / for (int i = 0; i < 400; i++)
            
                //for (int j = 0; j < 200; j++)  //pintar  todo el cuador de rojo
                //{
                //    Grafico.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                //}

                //for (int j = 200; j < 400; j++)  // pintar la mitad rojo y la mitad amarillo
                //{
                //    Grafico.SetPixel(i, j, Color.FromArgb(255, 255, 0));

        public void EncenderInterpolacion()
        {
            //permite crear la circunferencia 
            double t, dt;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            t = 0;
            dt = 0.001;
            do
            {
                v.X0 = X0 + (Radio * Math.Cos(t));
                v.Y0 = Y0 + (Radio * Math.Sin(t));
                v.Color0 = Color.FromArgb((int)((10 * (t - (2 * Math.PI)) / (-(2 * Math.PI)))), (int)(255 * (t) / ((2 * Math.PI))), (int)((255 * (t - (2 * Math.PI)) / (-(2 * Math.PI))) + ((255 * (t)) / (2 * Math.PI))));
                v.Encender();
                t = t + dt;
            } while (t <= 2 * Math.PI);
        }
        public void encenderSeis()
        {
            double t = Math.PI / 2, dt = 0.001;
            Vector objVec = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                objVec.X0 = X0 + Radio * Math.Cos(t);
                objVec.Y0 = Y0 + Radio * Math.Sin(t) * 2;
                objVec.Encender();
                t += dt;
            } while (t <= Math.PI);
        }
        public void encenderSeis2()
        {
            double t = 0, dt = 0.001;
            Vector objVec = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                objVec.X0 = X0 + Radio * Math.Cos(t);
                objVec.Y0 = Y0 + Radio * Math.Sin(t);
                objVec.Encender();
                t += dt;
            } while (t <= 2 * Math.PI);
        }
  
        
        /*public void encenderSeis()
        {
            double t = Math.PI / 2, dt = 0.001;
            Vector objVec = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                objVec.X0 = X0 + Radio * Math.Cos(t);
                objVec.Y0 = Y0 + Radio * Math.Sin(t) * 2;
                objVec.Encender();
                t += dt;
            } while (t <= Math.PI);
        }

            public void encenderSeis2()
            {
                double t = 0, dt = 0.001;
                Vector objVec = new Vector(0, 0, Color0, ViewPort, Grafico);
                do
                {
                    objVec.X0 = X0 + Radio * Math.Cos(t);
                    objVec.Y0 = Y0 + Radio* Math.Sin(t);
                    objVec.Encender();
                    t += dt;
                } while (t <= 2 * Math.PI);
            }*/

            public void encenderDos()
            {
                double t = 0, dt = 0.001;
                Vector objVec = new Vector(0, 0, Color0, ViewPort, Grafico); 
                do
                {
                    objVec.X0 = X0 + Radio * Math.Cos(t);
                    objVec.Y0 = Y0 + Radio * Math.Sin(t);
                    objVec.Encender();
                    t += dt;
                } while (t <= Math.PI);
            }

            public void encenderDos1()
            {
                Segmento obj1 = new Segmento(X0 + Radio, Y0, X0 - Radio, X0 - X0, Color0, ViewPort, Grafico);
                obj1.Encender();
                Segmento obj2 = new Segmento(X0 - Radio, X0 - X0, X0 + Radio, X0 - X0, Color0, ViewPort, Grafico);
                obj2.Encender();
            }
            public void encenderAnillo()
            {
                double t = 0, dt = 0.001;
                Vector objVec = new Vector(0, 0, Color0, ViewPort, Grafico);
                do
                {
                    objVec.X0 = X0 + Radio * Math.Cos(t);
                    objVec.Y0 = Y0 + Radio * Math.Sin(t);
                    objVec.Encender();


                    objVec.X0 = X0 + Radio * Math.Cos(t) + 0.05;
                    objVec.Y0 = Y0 + Radio * Math.Sin(t) + 0.05;
                    objVec.Encender();

                    objVec.X0 = X0 + Radio * Math.Cos(t) + 0.1;
                    objVec.Y0 = Y0 + Radio * Math.Sin(t) + 0.1;
                    objVec.Encender();

                    t += dt;
                } while (t <= 2 * Math.PI);
            }

            public void EncenderTrianguloCirculo()
            {
                //permite crear la circunferencia 
                double t, dt;
                Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
                t = 0;
                dt = 0.1;
                do
                {
                    v.X0 = X0 + (Radio * Math.Cos(t));
                    v.Y0 = Y0 + (Radio * Math.Sin(t));
                    v.Encender();
                    t = t + dt;
                } while (t <= 360);

                Segmento segmento;
                double x0, xf, y0, yf;

                x0 = X0 + (Radio * Math.Cos(Math.PI/2));
                y0 = Y0 + (Radio * Math.Sin(Math.PI / 2));

                xf = X0 + (Radio * Math.Cos(11*Math.PI / 6));
                yf = Y0 + (Radio * Math.Sin(11*Math.PI / 6));


                segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
                segmento.Encender();

                x0 = X0 + (Radio * Math.Cos(Math.PI / 2));
                y0 = Y0 + (Radio * Math.Sin(Math.PI / 2));

                xf = X0 + (Radio * Math.Cos(7 * Math.PI / 6));
                yf = Y0 + (Radio * Math.Sin(7 * Math.PI / 6));


                segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
                segmento.Encender();


                x0 = X0 + (Radio * Math.Cos(7*Math.PI / 6));
                y0 = Y0 + (Radio * Math.Sin(7*Math.PI / 6));

                xf = X0 + (Radio * Math.Cos(11 * Math.PI / 6));
                yf = Y0 + (Radio * Math.Sin(11 * Math.PI / 6));


                segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
                segmento.Encender();

            }
    
    public void EncenderCuadradoCirculo()
            {
                //permite crear la circunferencia 
                double t, dt;
                Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
                t = 0;
                dt = 0.1;
                do
                {
                    v.X0 = X0 + (Radio * Math.Cos(t));
                    v.Y0 = Y0 + (Radio * Math.Sin(t));
                    v.Encender();
                    t = t + dt;
                } while (t <= 360);

                Segmento segmento;
                double x0, xf, y0, yf;

                x0 = X0 + (Radio * Math.Cos(Math.PI / 4));
                y0 = Y0 + (Radio * Math.Sin(Math.PI / 4));

                xf = X0 + (Radio * Math.Cos(3*Math.PI / 4));
                yf = Y0 + (Radio * Math.Sin(3*Math.PI / 4));


                segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
                segmento.Encender();

                x0 = X0 + (Radio * Math.Cos(Math.PI / 4));
                y0 = Y0 + (Radio * Math.Sin(Math.PI / 4));

                xf = X0 + (Radio * Math.Cos(7 * Math.PI / 4));
                yf = Y0 + (Radio * Math.Sin(7 * Math.PI / 4));


                segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
                segmento.Encender();


                x0 = X0 + (Radio * Math.Cos(3 * Math.PI / 4));
                y0 = Y0 + (Radio * Math.Sin(3 * Math.PI / 4));

                xf = X0 + (Radio * Math.Cos(5 * Math.PI / 4));
                yf = Y0 + (Radio * Math.Sin(5 * Math.PI / 4));


                segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
                segmento.Encender();


                x0 = X0 + (Radio * Math.Cos(5 * Math.PI / 4));
                y0 = Y0 + (Radio * Math.Sin(5 * Math.PI / 4));

                xf = X0 + (Radio * Math.Cos(7 * Math.PI / 4));
                yf = Y0 + (Radio * Math.Sin(7 * Math.PI / 4));


                segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
                segmento.Encender();

            }
    public void EncenderPentagonoCirculo()
    {
        //permite crear la circunferencia 
        double t, dt;
        Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
        t = 0;
        dt = 0.1;
        do
        {
            v.X0 = X0 + (Radio * Math.Cos(t));
            v.Y0 = Y0 + (Radio * Math.Sin(t));
            v.Encender();
            t = t + dt;
        } while (t <= 360);

        Segmento segmento;
        double x0, xf, y0, yf;

        x0 = X0 + (Radio * Math.Cos(Math.PI / 2));
        y0 = Y0 + (Radio * Math.Sin(Math.PI / 2));

        xf = X0 + (Radio * Math.Cos( Math.PI / 6));
        yf = Y0 + (Radio * Math.Sin( Math.PI / 6));


        segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
        segmento.Encender();
        
        x0 = X0 + (Radio * Math.Cos(Math.PI / 2));
        y0 = Y0 + (Radio * Math.Sin(Math.PI / 2));

        xf = X0 + (Radio * Math.Cos(5 * Math.PI / 6));
        yf = Y0 + (Radio * Math.Sin(5 * Math.PI / 6));


        segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
        segmento.Encender();

        x0 = X0 + (Radio * Math.Cos(Math.PI / 6));
        y0 = Y0 + (Radio * Math.Sin(Math.PI / 6));

        xf = X0 + (Radio * Math.Cos(5 * Math.PI / 3));
        yf = Y0 + (Radio * Math.Sin(5 * Math.PI / 3));


        segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
        segmento.Encender();


        x0 = X0 + (Radio * Math.Cos(5 * Math.PI / 6));
        y0 = Y0 + (Radio * Math.Sin(5 * Math.PI / 6));

        xf = X0 + (Radio * Math.Cos(4 * Math.PI / 3));
        yf = Y0 + (Radio * Math.Sin(4 * Math.PI / 3));


        segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
        segmento.Encender();


        x0 = X0 + (Radio * Math.Cos(4 * Math.PI / 3));
        y0 = Y0 + (Radio * Math.Sin(4 * Math.PI / 3));

        xf = X0 + (Radio * Math.Cos(5 * Math.PI / 3));
        yf = Y0 + (Radio * Math.Sin(5 * Math.PI / 3));


        segmento = new Segmento(x0, y0, xf, yf, Color0, ViewPort, Grafico);
        segmento.Encender();

    }
    public void Apagar(Color c)
    {
        double t = 0, dt = 0.003;
        Vector seg = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
        do
        {

            seg.X0 = X0 + (Radio) * Math.Cos(t);
            seg.Y0 = Y0 + (Radio) * Math.Sin(t);
            seg.apagar(c);
            t = t + dt;
        } while (t <= 2 * 3.141516);

    }

    }
}
