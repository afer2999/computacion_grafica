using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace NewCompu
{
    class Lazo:Circunferencia
    {
        public double alfa;
        
        

        public Lazo() { }

        public Lazo(double x, double y, double r, Color c)
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
            Vector vl = new Vector();
            do
            {
                vl.x0 = x0 + Math.Sin(2 * t) * radio;
                vl.y0 = y0 + Math.Cos(3 * t) * radio;
                vl.color0 = this.color0;
                vl.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        public void Apagar(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vl = new Vector();
            do
            {
                vl.x0 = x0 + Math.Sin(2 * t) * radio;
                vl.y0 = y0 + Math.Cos(3 * t) * radio;
                vl.color0 = Color.White; ;
                vl.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

    }
}
