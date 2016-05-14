using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo_5
{
    class Poligonos:Circunferencia
    {
       private int nLados;
        //double YF,XF;

        public int NLados {get { return nLados; } set { nLados = value; }}

        public Poligonos(double nX0, double nY0, double nRadio,int nLado, Color nColor0, PictureBox nViewPort, Bitmap nGrafico)
            : base(nX0, nY0, nRadio, nColor0, nViewPort, nGrafico)
        {
            X0 = nX0;
            Y0 = nY0;
            Radio = nRadio;
            nLados = nLado;
            Color0 = nColor0;
            ViewPort = nViewPort;
            Grafico=nGrafico;
            SGrafico = ViewPort.CreateGraphics();
        }

   
              

        public override void Encender()   //encender poligono
        {
           // cVector vec = new cVector(0, 0, cl, bit, ventanaP);
            Segmento seg = new Segmento(0, 0, 0, 0, Color0, ViewPort, Grafico);

            double alfa,beta;            
            alfa = (2 * Math.PI) / nLados;
            beta = Math.PI/2;
            do
            {
                seg.X0 = X0 + Radio * Math.Cos(beta);
                seg.Y0 = Y0 + Radio * Math.Sin(beta);
                seg.XF = X0 + Radio * Math.Cos(beta + alfa);
                seg.YF = Y0 + Radio * Math.Sin(beta + alfa);
                seg.Encender();
                beta = beta + alfa;
            }while(beta<=(2.5 * Math.PI));
        }



        public void encenderTipo2()
        {
            Segmento seg = new Segmento(0, 0, 0, 0, Color0, ViewPort, Grafico);
            double Beta = (Math.PI) / 2;
            for (int i = 0; i <= nLados; i++)
            {
                seg.X0 = X0 + (Radio * Math.Cos(Beta));
                seg.Y0 = Y0 + (Radio * Math.Sin(Beta));
                seg.XF = X0 + (Radio * Math.Cos(Beta + Alfa));
                seg.YF = Y0 + (Radio * Math.Sin(Beta + Alfa));
                seg.Encender();
                seg.XF = X0;
                seg.YF = Y0;
                seg.Encender();
                Beta = Beta + Alfa;
            }
        }


        public double Alfa { get; set; }
    }
}
