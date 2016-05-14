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
    class cVector:cModelosMat
    {
        public double x0;
        public double y0;
        public Color c;
        public Bitmap grafico;
        public PictureBox ViewPort;

        public cVector() { }
        public cVector(double x0,double y0, Color co ,Bitmap grafico,PictureBox View) 
        {
            this.x0 = x0;
            this.y0 = y0;
            this.c= co ;
            this.grafico = grafico;
            this.ViewPort = View;
        
        }

        public void Encender(Bitmap grafico)
        {
            int sx, sy;
            Pantalla(this.x0, this.y0, out sx, out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy, this.c);
            }
        }
        public void EcenderV()
        {
            int sx, sy;
            Pantalla(this.x0,this.y0,out sx,out sy);
            if (sx > 0 && sx < 600 && sy > 0 && sy < 400)
            {
                grafico.SetPixel(sx, sy,c);
             //   ViewPort.Image = grafico;
                
            }
        }

        public virtual void Apagar(Color color)
        {
            c = color;
            EcenderV();
        }




         



    }
}
