using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Segmento3D:Vector3D
    {
        public double xf, yf, zf;

        public Segmento3D() { }

        public Segmento3D(double x, double y, double z, double x1, double y1, double z1, Color c ) {
            this.x0 = x;
            this.y0 = y;
            this.z0 = z;
            this.xf = x1;
            this.yf = y1;
            this.zf = z1;
            this.c = c;
        }

        public void EncSegmento3D(Bitmap grafico) {
            double t = 0, dt = 0.001;
            Vector3D v1 = new Vector3D();
            while (t <= 1)
            {
                v1.x0 = x0 + (xf - x0) * t;
                v1.y0 = y0 + (yf - y0) * t;
                v1.z0 = z0 + (zf - z0) * t;
                v1.Encender3D(grafico);
                v1.c = this.c;
                t += dt;
            }

        }
    }
}
