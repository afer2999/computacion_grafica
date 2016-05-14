using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FabianYunda
{
    class cPoligono:cCircunferencia
    {

        public int nlados;

        public cPoligono() { }

        public cPoligono(double x, double y, double r, int n, Color c)
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

            cSegmento s = new cSegmento(0,0,0,0,this.c,grafico,ViewPort,0);
            s.c = this.c;
            for (int i = 0; i < nlados; i++)
            {
                s.x0 = x0 + radio * Math.Sin(beta);
                s.y0 = y0 + radio * Math.Cos(beta);
                s.xf = x0 + radio * Math.Sin(alfa + beta);
                s.yf = y0 + radio * Math.Cos(alfa + beta);
                s.EcenderS();
                beta = beta + alfa;
            }
        }

        public void PAraña(Bitmap grafico)
        {
            cSegmento sp = new cSegmento(0,0,0,0,this.c,grafico,ViewPort,0);
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
                sp.EcenderS();
                
                sp.x0 = x0;
                sp.y0 = y0;
                sp.xf = this.x0 + this.radio * (Math.Sin(beta));
                sp.yf = this.y0 + this.radio * (Math.Cos(beta));
                beta = beta + alfa;
                sp.c = this.c;
                 sp.EcenderS();
            }
        }
    }
}
