using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Vector3D:Vector
    {
        public double z0;

        public Vector3D(){}

        public Vector3D(double x, double y, double z, Color c)
        {
            this.x0=x;
            this.y0=y;
            this.z0=z;
            this.c=c;
        }

        public void Encender3D(Bitmap grafico)
        {
            double ax, ay;
            int sx, sy;
            ModelosMat.Axionometria(x0,y0,z0, out ax, out ay);
            ModelosMat.Pantalla(ax, ay, out sx, out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, this.c);
            }
            
        }

        public void Apagar3D(Bitmap grafico)
        {
            double ax, ay;
            int sx, sy;
            ModelosMat.Axionometria(x0, y0, z0, out ax, out ay);
            ModelosMat.Pantalla(ax, ay, out sx, out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, Color.White);
            }

        }
    }
}
