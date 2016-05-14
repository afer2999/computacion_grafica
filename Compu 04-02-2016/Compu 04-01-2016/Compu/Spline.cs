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
    class Spline: Vector
    {
        public int num;
        double a;
        double[] vx;
        double[] vy;


        public Spline(double[] vx, double[] vy, int n, Color c, PictureBox viewport, Graphics gra)
        {
            
        }

        public void CurvaSpline() {
            for (int i = 0; i < num; i++)
            {
                if (i==0)
                {
                    a = 0;

                }
            }


        }
    }
}
