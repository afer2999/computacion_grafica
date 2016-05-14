using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo_5
{
    class CurvaV : Circunferencia
    {
        public int Tipo;
        //constructor
        public CurvaV(double nX0, double nY0, double nRadio, int nTipo, Color nColor0, PictureBox nViewPort, Bitmap nGrafico)
            : base(nX0, nY0, nRadio, nColor0, nViewPort, nGrafico)
        {
            X0 = nX0;
            Y0 = nY0;
            Radio = nRadio;
            Tipo = nTipo;
            Color0 = nColor0;
            ViewPort = nViewPort;
            Grafico = nGrafico;
        }
        //destructor
        ~CurvaV()
        { }
        //procesos
        public override void Encender()
        {
            double t, dt;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            Vector c = new Vector(0, 0, Color0, ViewPort, Grafico);
            LibreriaMat obj = new LibreriaMat();
            switch (Tipo)
            {
                case 0://lazo
                    t = 0; dt = 0.001;
                    do
                    {
                        v.X0 = X0 + (Radio * Math.Sin(2 * t));
                        v.Y0 = Y0 + (Radio * Math.Cos(3 * t));
                        v.Encender();
                        t = t + dt;
                    } while (t <= (2 * Math.PI));
                    break;
                case 1://hipociclo
                    t = 0; dt = 0.001;
                    do
                    {
                        v.X0 = X0 + (Radio * Math.Pow(Math.Sin(t), 3));
                        v.Y0 = Y0 + (Radio * Math.Pow(Math.Cos(t), 3));
                        v.Encender();
                        t = t + dt;
                    } while (t <= (2 * Math.PI));
                    break;
                case 2://margarita
                    t = 0; dt = 0.001;
                    do
                    {
                        v.X0 = X0 + (Radio * (Math.Cos(4 * t) / 2) * Math.Cos(t));
                        v.Y0 = Y0 + (Radio * ((Math.Cos(4 * t)) * (Math.Sin(t))) / 2);
                        v.Encender();
                        t = t + dt;
                    } while (t <= (2 * Math.PI));
                    break;
                case 3://espiral
                    t = 0; dt = 0.001;
                    do
                    {
                        v.X0 = X0 + (Radio * (t / 10) * Math.Cos(t));
                        v.Y0 = Y0 + (Radio * (t / 10) * Math.Sin(t));
                        v.Encender();
                        t = t + dt;
                    }
                    while (t <= (6 * Math.PI));
                    break;
            }
        }
      }
}
