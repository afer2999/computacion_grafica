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
    class cCircunferencia:cVector
    {
      
       public  int tipo;
       public double radio;
       public double alfa;
          public double t1cos;
          public double t1sen;

        public cCircunferencia() { }
        public cCircunferencia(double x0, double y0, double r, Color c, Bitmap grafico, PictureBox View, int tipo) 
        {
            this.x0 = x0;
            this.y0 = y0;
          

            this.c = c;
            this.radio=r;
            this.grafico = grafico;
            this.ViewPort = View;
            this.tipo = tipo;
        
        }
        public void EcenderC()
        {
            double t = 0, dt = 0.001;
            cVector cc = new cVector(0, 0, c, grafico, ViewPort);
           
              switch (tipo)
            {
                    //encender circulo  normal
                case 0:{
            do
            { 
                cc.x0=x0+ radio*Math.Cos(t);
                cc.y0=y0+ radio*Math.Sin(t);
                   cc.c = this.c;
                cc.EcenderV();
                t = t + dt;



            } while (t <= 2 * Math.PI);

        }break;
                      //interpolado colores
    case 1:{
            do
            { 
                cc.x0=x0+ radio*Math.Cos(t);
                cc.y0=y0+ radio*Math.Sin(t);
                   cc.c = Color.FromArgb(
                     (int)(0 * ((t - 6.28) / (0 - 6.28)) + 255 * ((t - 0) / (6.28 - 0))),
                     (int)(0 * ((t - 6.28) / (0 - 6.28)) + 0 * ((t - 0) / (6.28 - 0))),
                     (int)(255 * ((t - 6.28) / (0 - 6.28)) + 255 * ((t - 0) / (6.28 - 0))));
                cc.EcenderV();
                t = t + dt;

                 
                
            } while (t <= 2 * Math.PI);

        }break;


              //circulo entrecortada
         case 2:
             {
            double ccc = 0;
            do
            {
                cc.x0 = x0 + radio * Math.Cos(t);
                cc.y0 = y0 + radio * Math.Sin(t);
                cc.c = this.c;
                if (ccc%35==0)
                {
                    cc.EcenderV();
                }
                t = t + dt;
                ccc = ccc + 1;


            } while (t <= 2 * Math.PI);

        } break;

         case 3:
             {
              
                 do
                 {
                     for (double i = radio-0.2; i < radio; i+=0.01)
                     {
                         cc.x0 = x0 + i * Math.Cos(t);
                         cc.y0 = y0 + i * Math.Sin(t);
                          cc.c = this.c;
                          cc.EcenderV();
                      
                     }
                     t = t + dt;
                 } while (t <= 2 * Math.PI);

             } break;
         case 4:
             {
                 t = 0;
                 dt = 0.001;
                 cVector vl = new cVector(0, 0, c, grafico, ViewPort);
                 cVector W = new cVector(0, 0, c, grafico, ViewPort);
                 do
                 {
                     vl.x0 = x0 + Math.Sin(t1sen * t) * radio;
                     vl.y0 = y0 + Math.Cos(t1cos * t) * radio;
                     Rotar2D(vl.x0, vl.y0, x0, y0, alfa, out W.x0, out W.y0);
                     W.c = this.c;
                     W.EcenderV();
                     t += dt;
                 } while (t <= 2 * Math.PI);
             } break;
                




            }


        }

        public void ApagarC()
        {

            double t = 0, dt = 0.001;
            cVector cc = new cVector(0, 0, c, grafico, ViewPort);
           
              switch (tipo)
            {
                    //encender circulo  normal
                 case 0:{
                         do
                         { 
                          cc.x0=x0+ radio*Math.Cos(t);
                          cc.y0=y0+ radio*Math.Sin(t);
                          cc.c = Color.White;
                           cc.EcenderV();
                         t = t + dt;



                         } while (t <= 2 * Math.PI);

                       }break;
                      //interpolado colores
                 case 1:{
                            do
                             { 
                            cc.x0=x0+ radio*Math.Cos(t);
                            cc.y0=y0+ radio*Math.Sin(t);
                                cc.c = Color.White;
                             cc.EcenderV();
                             t = t + dt;
                             } while (t <= 2 * Math.PI);
                         }break;


                               //circulo entrecortada
                case 2:
                     {
                    double ccc = 0;
                    do
                     {
                      cc.x0 = x0 + radio * Math.Cos(t);
                     cc.y0 = y0 + radio * Math.Sin(t);
                        cc.c = Color.White;
                     if (ccc%35==0)
                     {
                         cc.EcenderV();
                       }
                      t = t + dt;
                        ccc = ccc + 1;


                      } while (t <= 2 * Math.PI);

                     } break;

                case 3:
                  {
              
                 do
                 {
                     for (double i = 0; i < radio; i+=0.02)
                     {
                         cc.x0 = x0 + i * Math.Cos(t);
                         cc.y0 = y0 + i * Math.Sin(t);
                          cc.c = Color.White;
                          cc.EcenderV();
                      
                     }
                     t = t + dt;
                 } while (t <= 2 * Math.PI);

             } break;
         case 4:
             {
                 t = 0;
                 dt = 0.001;
                 cVector vl = new cVector(0, 0, c, grafico, ViewPort);
                 cVector W = new cVector(0, 0, c, grafico, ViewPort);
                 do
                 {
                     vl.x0 = x0 + Math.Sin(t1sen * t) * radio;
                     vl.y0 = y0 + Math.Cos(t1cos * t) * radio;
                     Rotar2D(vl.x0, vl.y0, x0, y0, alfa, out W.x0, out W.y0);
                     W.c = Color.White;
                     W.EcenderV();
                     t += dt;
                 } while (t <= 2 * Math.PI);
             } break;





            }
        }   


    }
}
