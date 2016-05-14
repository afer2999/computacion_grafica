using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Curva3D:Vector3D
    {
        public double a, b, gama;
        public int eje;

        public Curva3D() { }

        public Curva3D(double x, double y, double z, double radio, double altura, double ga, int ej, Color c) {
            this.x0 = x;
            this.y0 = y;
            this.z0 = z;
            this.a = radio;
            this.b = altura;
            this.gama = ga;
            this.eje = ej;
            this.c = c;
        }

         public void EncenderCurva3D(Bitmap grafico)
         {   
           double t, dt;
             t = 0;
             dt = 0.002;
             a = 4;
             b = 0.33;
             Vector3D V3D = new Vector3D();
             Vector3D W3D = new Vector3D();
             V3D.c = Color.Blue;
             W3D.c = Color.Red;

             do
             {
                 V3D.x0 =  (a * Math.Cos(t));
                 V3D.y0 =  (a * Math.Sin(t));
                 V3D.z0 =  (b * t);
                 ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                 //V3D.Encender3D(grafico);
                 W3D.Encender3D(grafico);
                 t = t + dt;
             } while (t <= 6 * Math.PI);
         }
        
        public void EncenderChuro(Bitmap grafico)
         {
            double t = 0, dt = 0.002;
                             a = 4;
                            b = 0.33;
                            Vector3D V3D = new Vector3D();
                            Vector3D W3D = new Vector3D();

                            int con = 0;
                                do
                                 {
                                    a = (0* ((t - 18.8) / (0 - 18.8))) + (4 * ((t - 0) / (18.8 - 0)));
                                    V3D.x0 =  (a * Math.Cos(t));
                                    V3D.y0 =  (a * Math.Sin(t));
                                    V3D.z0 =  (b * t);
                                    Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                    //V3D.Encender3D(grafico);

                                   W3D.c = Color.FromArgb(Convert.ToInt32((255 * ((t - (6 * Math.PI)) / (0 - (6 * Math.PI)))) + (255 * ((t - 0) / ((6 * Math.PI) - 0)))),
                                        Convert.ToInt32((255 * ((t - (6 * Math.PI)) / (0 - (6 * Math.PI)))) + (0 * ((t - 0) / ((6 * Math.PI) - 0)))),
                                        Convert.ToInt32((0 * ((t - (6 * Math.PI)) / (0 - (6 * Math.PI)))) + (0 * ((t - 0) / ((6 * Math.PI) - 0))))); 
                                    if (con % 25 == 0)
                                         {
                                             W3D.Encender3D(grafico);

                                        }
                                 t = t + dt;
                                 con++;
                                 } while (t <= 6 * Math.PI);

         }
         public void ApagarCurva3D(Bitmap grafico)
         {

             double t, dt;
             t = 0;
             dt = 0.002;
             a = 4;
             b = 0.33;
             Vector3D V3D = new Vector3D();
             Vector3D W3D = new Vector3D();
             V3D.c = Color.White;
             W3D.c = Color.White;

             do
             {
                 V3D.x0 = (a * Math.Cos(t));
                 V3D.y0 = (a * Math.Sin(t));
                 V3D.z0 = (b * t);
                 ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                 //V3D.Encender3D(grafico);
                 W3D.Encender3D(grafico);
                 t = t + dt;
             } while (t <= 6 * Math.PI);

             
         }

        public void ApagarChuro(Bitmap grafico)
         {
            double t = 0,dt = 0.002;
                     a = 4;
                     b = 0.33;
            Vector3D V3D = new Vector3D();
             Vector3D W3D = new Vector3D();
             
                     int con = 0;
                     do
                     {
                         a = (0 * ((t - 18.8) / (0 - 18.8))) + (4 * ((t - 0) / (18.8 - 0)));
                         V3D.x0 = (a * Math.Cos(t));
                         V3D.y0 = (a * Math.Sin(t));
                         V3D.z0 = (b * t);
                         Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                         //V3D.Encender3D(grafico);

                         W3D.c = Color.White;
                         if (con % 25 == 0)
                         {
                             W3D.Encender3D(grafico);

                         }
                         t = t + dt;
                         con++;
                     } while (t <= 6 * Math.PI);


         }
    }
}
