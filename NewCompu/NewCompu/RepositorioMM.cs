using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NewCompu
{
    class RepositorioMM
    {
        public static int pxmax = 560;
        public static int pymax = 440;
        public static int pxmin = 0;
        public static int pymin = 0;
        public static double xmax = 14;
        public static double xmin = -7;
        public static double ymax = 11;
        public static double ymin = -6;

        Bitmap grafico;

        public static void Pantalla(double x, double y, out int px, out int py)
        {
            px = (int)Math.Truncate((pxmax - pxmin) / (xmax - xmin) * (x - xmax) + pxmax);
            py = (int)Math.Truncate((pymin - pymax) / (ymax - ymin) * (y - ymax) + pymin);
        }

        public static void Carta(int px, int py, out double x, out double y)
        {
            x = ((px - pxmax) * ((xmax - xmin) / (pxmax - pxmin))) + xmax;
            y = ((py - pymax) * ((ymax - ymin) / (pymin - pymax))) + ymin;
        }

    }
}
