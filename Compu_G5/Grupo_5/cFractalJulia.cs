using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo_5
{
    class cFractalJulia
    {

       public int FractalJulia(double x0, double y0)
        {
            double Xn, Yn, Xnn, Ynn, d=0;
            int i = 0;
            int colorM = 0;
            Xn = x0;
            Yn = y0;
            for (i = 0; i <= 100;i++ )
            {
                    //fractal de manderbrot
                    Xnn = (Xn * Xn) - (Yn * Yn) - 1;
                    Ynn = 2 * Xn * Yn + 0.23;
                    d = Math.Sqrt(Math.Pow((Xnn), 2) + Math.Pow((Ynn), 2));
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
