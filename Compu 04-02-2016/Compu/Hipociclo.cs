using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Hipociclo:Circuenferencia
    {
        public Hipociclo() { }

        public Hipociclo(double x, double y, double r, Color c) {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.c = c;
        }

        public void EncenderHipociclo(Bitmap grafico) {
            double t = 0;
            double dt = 0.001;
            Vector vh = new Vector();
            do
            {
                vh.x0 = x0+ (Math.Pow(Math.Sin(t),3))*radio;
                vh.y0 = y0 + (Math.Pow(Math.Cos(t), 3)) * radio;
                vh.c = this.c;
                vh.Encender(grafico);
                t += dt;
                
            } while (t<=2*Math.PI);
        }

        public void Encender(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vh = new Vector();
            do
            {
                vh.x0 = x0 + (Math.Pow(Math.Sin(t), 3)) * radio;
                vh.y0 = y0 + (Math.Pow(Math.Cos(t), 3)) * radio;
                vh.c = this.c;
                vh.Encender(grafico);
                t += dt;

            } while (t <= 2 * Math.PI);
        }
    }
}
