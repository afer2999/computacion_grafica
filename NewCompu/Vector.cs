using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewCompu
{
    class Vector:RepositorioMM
    {
        public double x0;
        public double y0;
        public Color color0;

        ~Vector()
        { }

       
        public Vector() { }

        public Vector(double x, double y, Color c)
        {
            this.x0 = x;
            this.y0 = y;
            this.color0 = c;
        }

        public void Encender(Bitmap grafico)
        {
            int px, py;
            Pantalla(this.x0, this.y0, out px, out py);
            if (px > 0 && px < 560 && py > 0 && py < 440)
            {
                grafico.SetPixel(px, py, this.color0);
            
            }
        }

        public virtual void Apagar(Bitmap grafico)
        {
           
                 color0 = Color.White;
                Encender(grafico);
            
        }
    }
}
