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
    
     
       class cCurva3D:cVector3D
    {
        public double a, b, gama;
        public int eje;
        double radio;
        public int tipo;
        public cCurva3D() { }

        public cCurva3D(double x, double y, double z, double radio, double altura, double ga, int ej, Color c,int tip) {
            this.x0 = x;
            this.y0 = y;
            this.z0 = z;
            this.a = radio;
            this.b = altura;
            this.gama = ga;
            this.tipo = tip;
            this.eje = ej;
            this.c = c;
        }

         public void EncenderCurva3D(Bitmap grafico)
         {
             double t, dt;
             cVector3D V3D = new cVector3D();
             cVector3D W3D = new cVector3D();
             
             switch(tipo)
             {
                    case 0:
                         t = 0;
                         dt = 0.002;
                             do
                                 {
                                   V3D.x0 = (a * Math.Cos(t));
                                   V3D.y0 = (a * Math.Sin(t));
                                   V3D.z0 = (b * t);
                                   V3D.Encender3D(grafico);
                                   V3D.c =this.c;
                                   t = t + dt;
                                 } while (t <= 6 * Math.PI);
                   break;
                   case 1:
                     
                          t = 0;
                         dt = 0.002;
                         do
                              {
                                   V3D.x0 =  (a * Math.Cos(t));
                                   V3D.y0 =  (a * Math.Sin(t));
                                   V3D.z0 =  (b * t);
                                   cModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                   W3D.c=this.c;
                                //V3D.Encender3D(grafico);
                                   W3D.Encender3D(grafico);
                                   t = t + dt;
                               } while (t <= 6 * Math.PI);
                 break;
                 case 2:
                             t = 0;
                             dt = 0.002;
                             a = 4;
                            b = 0.33;
                            int con = 0;
                                do
                                 {
                                    a = (0* ((t - 18.8) / (0 - 18.8))) + (4 * ((t - 0) / (18.8 - 0)));
                                    V3D.x0 =  (a * Math.Cos(t));
                                    V3D.y0 =  (a * Math.Sin(t));
                                    V3D.z0 =  (b * t);
                                    cModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
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
                                break;
                 
             
             
             }
             
         }


         public void ApagarCurva3D(Bitmap grafico)
         {
             double t, dt;
             cVector3D V3D = new cVector3D();
             cVector3D W3D = new cVector3D();

             switch (tipo)
             {
                 case 0:
                     t = 0;
                     dt = 0.002;
                     do
                     {
                         V3D.x0 = (a * Math.Cos(t));
                         V3D.y0 = (a * Math.Sin(t));
                         V3D.z0 = (b * t);
                         V3D.Encender3D(grafico);
                         V3D.c =Color.White;
                         t = t + dt;
                     } while (t <= 6 * Math.PI);
                     break;
                 case 1:

                     t = 0;
                     dt = 0.002;
                     do
                     {
                         V3D.x0 = (a * Math.Cos(t));
                         V3D.y0 = (a * Math.Sin(t));
                         V3D.z0 = (b * t);
                         cModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                         W3D.c = Color.White;
                         //V3D.Encender3D(grafico);
                         W3D.Encender3D(grafico);
                         t = t + dt;
                     } while (t <= 6 * Math.PI);
                     break;
                 case 2:
                     t = 0;
                     dt = 0.002;
                     a = 4;
                     b = 0.33;
                     int con = 0;
                     do
                     {
                         a = (0 * ((t - 18.8) / (0 - 18.8))) + (4 * ((t - 0) / (18.8 - 0)));
                         V3D.x0 = (a * Math.Cos(t));
                         V3D.y0 = (a * Math.Sin(t));
                         V3D.z0 = (b * t);
                         cModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                         //V3D.Encender3D(grafico);

                         W3D.c = Color.White;
                         if (con % 25 == 0)
                         {
                             W3D.Encender3D(grafico);

                         }
                         t = t + dt;
                         con++;
                     } while (t <= 6 * Math.PI);
                     break;



             }

         }
             
    }
    
}
