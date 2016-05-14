using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewCompu
{
    class Circunferencia:Vector
    {
        public double radio;

        public Circunferencia() { }
        public Circunferencia(double x, double y, double r, Color c)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.color0 = c;
        }

        public void EncCircunferencia(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.color0 = Color.Black;
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        public void ApagarCircunferencia(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector();
            do
            {
                vc.x0 = x0 + radio * Math.Cos(t);
                vc.y0 = y0 + radio * Math.Sin(t);
                vc.color0 = Color.White;
                vc.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }
    }
}
