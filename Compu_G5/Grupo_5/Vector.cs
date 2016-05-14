using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace Grupo_5
{
    class Vector : LibreriaMat
    //class Vector
    {
        public double X0, Y0;
        public Color Color0;
        public Bitmap Grafico;
        public PictureBox ViewPort;
        /* private double nX0;
         private double nY0;
         private Color nColor;
         private PictureBox nViewPort;*/
        //constructor
        public Vector(double nX0, double nY0, Color nColor0, PictureBox nViewPort, Bitmap nGrafico)
        {
            X0 = nX0;
            Y0 = nY0;
            Color0 = nColor0;
            ViewPort = nViewPort;
            Grafico = nGrafico;
        }
        //destructor 
        ~Vector()
        { }
        //procesos
        public virtual void Encender()
        {
            int SX0;
            int SY0;
            pantalla(X0, Y0, out SX0, out SY0);
            if (SX0 > 0 && SX0 < 600 && SY0 > 0 && SY0 < 400)
            // if (X0 > -12 && X0 < 12 && Y0 > -10 && Y0 < 10)
            {
                Grafico.SetPixel(SX0, SY0, Color0);
                ViewPort.Image = Grafico;
            }
        }
        public virtual void apagar(Color col)
        {
            Color0 = col;
            Encender();
        }
    }
}
