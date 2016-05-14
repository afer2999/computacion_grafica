using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace FabianYunda
{
    class cVector3D:cVector
    {
     
        public double z0;
        private int p1;
        private int p2;
        private Color color;

        public cVector3D(){}

        public cVector3D(double x, double y, double z, Color c)
        {
            this.x0=x;
            this.y0=y;
            this.z0=z;
            this.c=c;
        }

        public cVector3D(int p1, int p2, Color color)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.color = color;
        }

        public void Encender3D(Bitmap grafico)
        {
            double ax, ay;
            int sx, sy;
            cModelosMat.Axionometria(x0,y0,z0, out ax, out ay);
            cModelosMat.Pantalla(ax, ay, out sx, out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, this.c);
            }
            
        }

        public void Apagar3D(Bitmap grafico)
        {
            double ax, ay;
            int sx, sy;
            cModelosMat.Axionometria(x0, y0, z0, out ax, out ay);
            cModelosMat.Pantalla(ax, ay, out sx, out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, Color.White);
            }

        }
    
}
}