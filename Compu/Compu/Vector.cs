using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Compu
{
    class Vector : ModelosMat
    {
        public double x0;
        public double y0;
        public Color c;
        public Bitmap grafico;
        public PictureBox ViewPort;

        public Vector() { }

        public Vector(double x, double y, Color ca, Bitmap gra, PictureBox view)
        {
            x0 = x;
            y0 = y;
            c = ca;
            grafico = gra;
            ViewPort = view;
        }
        ~Vector()
        { }
        public virtual void  Encender()
        {
            int sx, sy;
            Pantalla(x0, y0, out sx, out sy);

            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, c);
                ViewPort.Image = grafico;
            }
        }
        public virtual void Apagar(Color color)
        {
            c = color;
            Encender();
        }

    }
}
