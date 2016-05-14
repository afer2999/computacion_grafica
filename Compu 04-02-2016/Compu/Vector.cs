using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    public class Vector:ModelosMat
    {
        public double x0;
        public double y0;
        public Color c;

        public Vector() { }

        public Vector(double x, double y, Color c) {
            this.x0 = x;
            this.y0 = y;
            this.c = c;
        }

        public void Encender(Bitmap grafico) {
            int sx, sy;
            Pantalla(this.x0, this.y0, out sx, out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, this.c);
            }
        }

        public void Apagar(Bitmap grafico)
        {
            int sx, sy;
            Pantalla(this.x0, this.y0, out sx, out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, Color.White);
            }
        }


      /*  public void Apagar(Bitmap grafico)
        {
            this.c = Color.White;
            Encender(grafico);
        }  */
    }
}
