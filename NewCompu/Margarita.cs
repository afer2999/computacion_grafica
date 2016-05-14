using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewCompu
{
    class Margarita:Circunferencia
    {
        public double alfa;
        public Margarita() { }

        public Margarita(double x, double y, double r, Color c)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.color0 = c;
            
        }
        public void Encender(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vh = new Vector();
            Vector w = new Vector();
            do
            {
                vh.x0 = x0 + (Math.Cos(4 * t) * Math.Cos(t))*radio;
                vh.y0 = y0 + (Math.Cos(4*t)* Math.Sin(t))*radio;
                w.Rotar2(vh.x0, vh.y0, alfa,x0, y0 , out w.x0, out w.y0);

                w.Encender(grafico);
                w.color0=this.color0;
                vh.color0 = this.color0;
                vh.Encender(grafico);
                t += dt;


            } while (t <= 2 * Math.PI);
        }
    }
}
