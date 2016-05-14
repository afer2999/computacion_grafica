using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compu
{
    class ModelosMat
    {
        public double x1 = -15;
        public double y1 = -10;

        public double x2 = 15;
        public double y2 = 10;

        int sx1 = 0;
        int sy1 = 0;
        int sx2 = 600;
        int sy2 = 400;

        public ModelosMat(double x1i, double x2i, double y1i, double y2i) {
            x1 = x1i;
            x2 = x2i;
            y1 = y1i;
            y2 = y2i;
        }
         //Constructor sin Parametros

        public ModelosMat()
        { }

        //Destructor 

         ~ModelosMat() { }

        public void Pantalla(double x, double y, out int sx, out int sy)
        {
            sx = (int)Math.Truncate((sx2 - sx1) / (x2 - x1) * (x - x2) + sx2);
            sy = (int)Math.Truncate((sy1 - sy2) / (y2 - y1) * (y - y2) + sy1);
        }

        public void RealXY(int sx, int sy, out double x, out double y)
        {
            x = ((sx - sx2) * ((x2 - x1) / (sx2 - sx1))) + x2;
            y = ((sy - sy1) * ((y2 - y1) / (sy1 - sy2))) + y2;
        }
    }
}
