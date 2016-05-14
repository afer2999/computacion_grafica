using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Poligono : Circuenferencia
    {
        public int nlados;

        public Poligono() { }

        public Poligono(double x, double y, double r, int n, Color c)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.nlados = n;
            this.c = c;
        }

        public void EncPoligono(Bitmap grafico)
        {

            double alfa = (2 * Math.PI) / nlados;
            double beta = 0;

            Segmento s = new Segmento();
            s.c = this.c;
            for (int i = 0; i < nlados; i++)
            {
                s.x0 = x0 + radio * Math.Sin(beta);
                s.y0 = y0 + radio * Math.Cos(beta);
                s.xf = x0 + radio * Math.Sin(alfa + beta);
                s.yf = y0 + radio * Math.Cos(alfa + beta);
                s.EncenderSegmento(grafico);
                beta = beta + alfa;
            }
        }

        public void PAraña(Bitmap grafico)
        {
            Segmento sp = new Segmento();
            double alfa, beta;
            alfa = (2 * Math.PI) / nlados;
            beta = 0;
            for (int i = 0; i < nlados; i++)
            {
                sp.x0 = this.x0 + this.radio * (Math.Sin(beta));
                sp.y0 = this.y0 + this.radio * (Math.Cos(beta));
                sp.xf = this.x0 + this.radio * (Math.Sin(beta + alfa));
                sp.yf = this.y0 + this.radio * (Math.Cos(beta + alfa));
                sp.c = this.c;
                sp.EncenderSegmento(grafico);
                
                sp.x0 = x0;
                sp.y0 = y0;
                sp.xf = this.x0 + this.radio * (Math.Sin(beta));
                sp.yf = this.y0 + this.radio * (Math.Cos(beta));
                beta = beta + alfa;
                sp.c = this.c;
                sp.EncenderSegmento(grafico);
            }
        }
    }
}
