using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_5
{
    class cFractalMandelbrot
    {

       public int FractalManderbrot(double x0, double y0)
        {
            double Xn, Yn, Xnn, Ynn, d=0;
            int i = 0;
            int colorM = 0;
            Xn = x0;
            Yn = y0;
            for (i = 0; i <= 100;i++ )
            {
                    //fractal de manderbrot
                    Xnn = (Xn * Xn) - (Yn * Yn) + x0;
                    Ynn = 2 * Xn * Yn + y0;
                    d = Math.Sqrt(Math.Pow((Xnn - x0), 2) + Math.Pow((Ynn - y0), 2));
                    if (d > 2) // No converge
                    {
                        colorM = i;
                        i = 100;
                    }
                    else //Si convergen
                    {
                        Xn = Xnn;
                        Yn = Ynn;
                    }
            }
            if (d < 2)
            {
                colorM = 0;
                i = 100;
            }
            return colorM;
        }
    }
}
