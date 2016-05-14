using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Grupo_5
{
    class Segmento:Vector
    {


        
        

        public double XF, YF;
        //constructor
        public Segmento(double nX0, double nY0, double nXF, double nYF, Color nColor0, PictureBox nViewPort, Bitmap nGrafico)
            : base(nX0, nY0, nColor0, nViewPort, nGrafico)
        {
            X0 = nX0;
            Y0 = nY0;
            XF = nXF;
            YF = nYF;
            Color0 = nColor0;
            ViewPort = nViewPort;
            Grafico = nGrafico;
        }


        


        //destructor
        ~Segmento()
        { }
        //procesos
        public override void Encender()
        {



            //d mide la distancia de los punto señanalados
            //formula normal d= rais cuadrada de ((X0-Xf)+(Yo-Yf)2)
            double t = 0;
            double d = Math.Abs(X0 - XF) + Math.Abs(Y0 - YF);
            double dt = 1 / (100 * (d + 1));
            Vector vec = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {

                vec.X0 = X0 * (1 - t) + XF * t;
                vec.Y0 = Y0 * (1 - t) + YF * t;
                        

                vec.Encender();
                t += dt;
            } while (t <= 1);
}
        public void Encender1()
        {



            //d mide la distancia de los punto señanalados
            //formula normal d= rais cuadrada de ((X0-Xf)+(Yo-Yf)2)
            double t = 0;
            double d = Math.Abs(X0 - XF) + Math.Abs(Y0 - YF);
            double dt = 1 / (5*(d + 1));
            Vector vec = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {

                vec.X0 = X0 * (1 - t) + XF * t;
                vec.Y0 = Y0 * (1 - t) + YF * t;


                vec.Encender();
                t += dt;
            } while (t <= 1);
        }

        public void EncenderInter()
        {



            //d mide la distancia de los punto señanalados
            //formula normal d= rais cuadrada de ((X0-Xf)+(Yo-Yf)2)
            double t = 0;
            double d = Math.Abs(X0 - XF) + Math.Abs(Y0 - YF);
            double dt = 1 / (100 * (d + 1));
            Vector vec = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                vec.X0 = X0 * (1 - t) + XF * t;
                vec.Y0 = Y0 * (1 - t) + YF * t;
                vec.Color0 = Color.FromArgb((int)((10 * (t - (1)) / (-(1)))), (int)(255 * (t) / ((1))), (int)((255 * (t - (1)) / (-(1))) + ((255 * (t)) / (1))));
                vec.Encender();
                t += dt;
            } while (t <= 1);
        }
        public void apagar(Color col)
        {
            Color0 = col;
            Encender();
        }

    }
}
