using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Lazo:Circuenferencia
    {
        public double alfa;

        public Lazo() { }

        public Lazo(double x, double y, double r,double alfa1, Color c) {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.alfa=alfa1;
            this.c = c;
        }

        public void EncenderLazo(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vl = new Vector();
            do
            {
                vl.x0 = x0 + Math.Sin(2 * t) * radio;
                vl.y0 = y0 + Math.Cos(3 * t) * radio;
                vl.c = this.c;
                vl.Encender(grafico);
                t += dt;
            } while (t<=2*Math.PI);
        }

        public void EncenderLazoRotar(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vl = new Vector();
            Vector w = new Vector();
            do
            {
                vl.x0 = x0 + Math.Sin(2 * t) * radio;
                vl.y0 = y0 + Math.Cos(3 * t) * radio;
                vl.c = this.c;
                ModelosMat.Rotar(vl.x0, vl.y0, x0, y0, alfa, out w.x0,out w.y0);
                w.c = this.c;
                w.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        public void ApagarLazoRotar(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vl = new Vector();
            Vector w = new Vector();
            do
            {
                vl.x0 = x0 + Math.Sin(2 * t) * radio;
                vl.y0 = y0 + Math.Cos(3 * t) * radio;
                vl.c = Color.White;
                ModelosMat.Rotar(vl.x0, vl.y0, x0, y0, alfa, out w.x0, out w.y0);
                w.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
        }

        public void ApagarLazo(Bitmap grafico)
        {
            double t = 0;
            double dt = 0.001;
            Vector vl = new Vector();
            do
            {
                vl.x0 = x0 + Math.Sin(2 * t) * radio;
                vl.y0 = y0 + Math.Cos(3 * t) * radio;
                vl.c = Color.White;
                vl.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);
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
                vl.c = this.c;
                vl.Encender(grafico);
                t += dt;
            } while (t <= 2 * Math.PI);


        }

    }
}
