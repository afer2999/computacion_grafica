using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Compu
{
    class Superficie:Vector3D
    {
        public int tipo;
        public double gama;
        public int eje;
        public double radio1,radio;
        public double[,] vx = new double[1000,1000];
        public double[,] vy = new double[1000,1000];
        public int cx,nx;
        public int cy,ny;
        public double ax, ay;
        public int tipom;
        
        public Superficie() { }

        public Superficie(double x, double y, double z, double gam, int ej, int tip, Color c, int tipom) 
        {
            this.x0 = x;
            this.y0 = y;
            this.z0 = z;
            this.c = c;
            this.tipo = tip;
            this.eje = eje;
            this.gama = gama;
            this.tipom = tipom;

        }

        public void EncSuperficie(Bitmap grafico) 
        {
            double x, dx, y, dy, z, dz;
            Vector3D V3D = new Vector3D();
            Vector3D W3D = new Vector3D();


            x = 0; 
            dx = 0.5;
            

            switch (tipo)
            {  // ************************************************cilindro normal ***************************************
                case 0:
                {
                    x = 0;
                    dx = Math.PI/10;
                    cx = 0;
                   
                    do
                    {
                        y = -3;
                        dy = Math.PI/10;
                        cy = 0;

                    
                        do
                        {
                            V3D.x0 = this.x0 + 4 * Math.Cos(x);
                            V3D.y0 = this.y0 + 4 * Math.Sin(x);
                            V3D.z0 = this.z0 + y;
                            V3D.c = this.c;
                       
                          
                           // V3D.Encender3D(grafico);
                            
                            ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0,gama,eje, out W3D.x0, out W3D.y0, out W3D.z0);
                            ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);

                            vx[cx, cy] = ax;
                            vy[cx, cy] = ay;
                           //W3D.c=Color.Blue;
                           //W3D.Encender3D(grafico);
                            y += dy;
                            cy = cy + 1;
                        } while (y<=3);
                        x += dx;
                        cx = cx + 1;
                    } while (x<=2 *Math.PI);
                    nx = cx-2;
                    ny = cy-2;
                  
                    //if (tipom == 0 )
                   // {
                    for (cx = 0; cx <= nx; cx++)
                    {
                        for (cy = 0; cy <=ny; cy++)
                        {

                            ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                vx[cx , cy + 1], vy[cx, cy+1], 
                                vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                vx[cx+1, cy], vy[cx + 1, cy ], grafico, 0);
                         
                            
                        }
                        
                    }
                 //  // }
                 //   if (tipom == 1)
                 //   {
                 //       for (cx = 0; cx <= nx; cx++)
                 //       {
                 //           for (cy = 0; cy <= ny; cy++)
                 //           {

                 //               ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                 //                   vx[cx, cy + 1], vy[cx, cy + 1],
                 //                   vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                 //                   vx[cx + 1, cy], vy[cx + 1, cy], grafico, 1);


                 //           }

                 //       }
                 //   }
                    
                   
                 //   if (tipom == 2)
                 //   {

                 //       for (cx = 0; cx <= nx; cx++)
                 //   {
                 //       for (cy = 0; cy <=ny; cy++)
                 //       {

                 //           ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                 //               vx[cx , cy + 1], vy[cx, cy+1], 
                 //               vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                 //               vx[cx+1, cy], vy[cx + 1, cy ], grafico, 2);
                       
                            
                 //       }|
                        
                 //   }
                 //}    |
                }
                 break;
                            //*******************************circunferencia completa******************************
                case 1:
                 {
                     x = 0;
                     dx = Math.PI/10;
                     cx=0;
                     do
                     {
                         y = 0;
                         dy = Math.PI/10;
                         cy=0;
                         do
                         {
                             V3D.x0 = this.x0 + 5 * Math.Sin(x) * Math.Cos(y);
                             V3D.y0 = this.y0 + 5 * Math.Sin(x) * Math.Sin(y);
                             V3D.z0 = this.z0 + 5 * Math.Cos(x); 
                             /*V3D.c = this.c;
                             V3D.Encender3D(grafico);*/
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             ModelosMat.Axionometria(W3D.x0,W3D.y0,W3D.z0,out ax,out ay);

                             vx[cx, cy]= ax;
                             vy[cx,cy]=ay;
                             y += dy;
                             cy = cy + 1;
                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= Math.PI);
                     nx = cx - 2;
                     ny = cy - 2;
                     for ( cx = 0; cx <=nx; cx++)
                     {
                         for ( cy = 0; cy <=ny; cy++)
                         {
                             ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                 vx[cx, cy + 1], vy[cx, cy + 1],
                                 vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                 vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);

                         }
                     }
                 }
                 break;
                     //**********************************************toroide******************************************************
                case 2:
                     {
                         x = 0;
                     dx = Math.PI/10;
                     cx = 0;
                     do
                     {
                         y = 0;
                         dy =Math.PI/10;
                         cy = 0;
                         do
                         {
                             V3D.x0 = this.x0 + (radio + (radio1) * Math.Cos(x)) * Math.Cos(y);
                             V3D.y0 = this.y0 + (radio + (radio1) * Math.Cos(x)) * Math.Sin(y);
                             V3D.z0 = this.z0 + radio1 * Math.Sin(x) * 0.5;
                             /*V3D.c = Color.Blue;
                             V3D.Encender3D(grafico);*/
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                         ModelosMat.Axionometria(W3D.x0,W3D.y0, W3D.z0,out ax ,out ay);
                             //W3D.c = Color.Blue;
                             //W3D.Encender3D(grafico);
                             vx[cx,cy]=ax;
                             vy[cx,cy]=ay;
                             y += dy;
                             cy = cy + 1;
                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;

                     } while (x <= 2*Math.PI);

                     nx = cx - 2;
                     ny = cy - 2;
                     for (cx = 0; cx<= nx; cx++)
                     {
                         for ( cy = 0; cy <=ny; cy++)
                         {
                              ModelosMat.Cuadrilatero(vx[cx,cy],vy[cx,cy],
                                                       vx[cx,cy+1],vy[cx,cy+1],
                                                       vx[cx+1,cy+1],vy[cx+1,cy+1],
                                                       vx[cx+1,cy],vy[cx+1,cy],grafico,0);
                                


                         }
                     }
                 }
                 break;
                //**************************************************Copa*******************************************************
                case 3:
                 {
                     double rad = 4;
                     //_______________________parte de la copa___________________________
                     x = Math.PI / 2;
                     dx = Math.PI / 10;
                     cx = 0;
                     do
                     {
                         y = 0;
                         dy = Math.PI / 10;
                         cy = 0;
                         do
                         {

                             V3D.x0 = this.x0 + rad * Math.Sin(x) * Math.Cos(y);
                             V3D.y0 = this.y0 + rad * Math.Sin(x) * Math.Sin(y);
                             V3D.z0 = this.z0 + (rad * 1.7) * Math.Cos(x);
                             //V3D.c = Color.Blue;
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                             vx[cx, cy] = ax;
                             vy[cx, cy] = ay;
                             //W3D.Encender3D(grafico);
                             //W3D.c = Color.Blue;
                             //W3D.Apagar3D(grafico);
                             y += dy;
                             cy = cy + 1;

                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= Math.PI);

                     nx = cx - 2;
                     ny = cy - 2;
                     for (cx = 0; cx <= nx; cx++)
                     {
                         for (cy = 0; cy <= ny; cy++)
                         {
                             ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                                     vx[cx, cy + 1], vy[cx, cy + 1],
                                                     vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                                     vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                         }
                     }
                     //________________________ parte de del medio de la copa______________________________
                     x = 0;
                     dx = Math.PI/10;
                     cx = 0;
                     do
                     {
                         y = -rad/1.5;
                         dy = Math.PI/10;
                         cy=0;
                         do
                         {
                             V3D.x0 = this.x0 + rad/5 * Math.Cos(x);
                             V3D.y0 = this.y0 + rad/5 * Math.Sin(x);
                             V3D.z0 = (this.z0 + y)-(rad+2*rad/1.5);
                             V3D.c = this.c;
                             //V3D.Encender3D(grafico);
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                             vx[cx,cy]=ax;
                             vy[cx,cy]=ay;
                             //W3D.c = Color.Blue;
                             //W3D.Encender3D(grafico);
                             y += dy;
                             cy = cy + 1;
                         } while (y <= rad/1.5);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= 2 * Math.PI);
                     nx = cx - 2;
                     ny = cy - 2;
                     for ( cx = 0; cx <= nx; cx++)
                     {
                         for ( cy = 0; cy <= ny; cy++)
                         {
                             Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                            vx[cx, cy + 1], vy[cx, cy + 1],
                                            vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                            vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                         }
                     }
                    // ________________________________________parte de la base de la copa_______________________________
                     x = Math.PI / 2;
                     dx =Math.PI/10;
                     cx = 0;
                     do
                     {
                         y = 0;
                         dy = Math.PI/10;
                         cy = 0;
                         do
                         {

                             V3D.x0 = this.x0 + rad/1.5 * Math.Sin(x) * Math.Cos(y);
                             V3D.y0 = this.y0 + rad/1.5 * Math.Sin(x) * Math.Sin(y);
                             V3D.z0 = this.z0 - (rad +( 3 * rad / 1.5));
                             //V3D.c = Color.Blue;
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                             vx[cx,cy]=ax;
                             vy[cx,cy]=ay;
                             //W3D.c = Color.Blue;
                             //W3D.Encender3D(grafico);
                             //W3D.Apagar3D(grafico);
                             y += dy;
                             cy = cy + 1;
                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= Math.PI);
                     nx = cx - 1;
                     ny = cy - 1;

                     for (cx = 0; cx <=nx; cx++)
                     {
                         for (cy = 0; cy < ny; cy++)
                         {
                             Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                          vx[cx, cy + 1], vy[cx, cy + 1],
                                          vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                          vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                             
                         }
                     }
               }
                 break;
                   //***************************************** sombrero*******************
                case 4:
                    {

                        radio = 3;
                        // _________________________parte de la corona del sombrero________________________________
                        cx = 0;
                        x = Math.PI / 2;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            do
                            {
                                V3D.x0 = this.x0 + radio/1.5 * Math.Sin(x) * Math.Cos(y);
                                V3D.y0 = this.y0 + radio/1.5 * Math.Sin(x) * Math.Sin(y);
                                V3D.z0 = this.z0 - (2.1 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx;
                            cx += 1;
                        } while (x <= Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j], vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1], vx[i, j + 1], vy[i, j + 1], grafico, 0);
                            }
                        } 
                        // ______________________________________la perte  del medio del sombrero___________________________________

                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = -radio / 1.5;
                            dy = Math.PI / 10;
                            do
                            {
                                V3D.x0 = this.x0 + (radio/1.5) * Math.Cos(x);
                                V3D.y0 = this.y0 + (radio/1.5) * Math.Sin(x);
                                V3D.z0 = this.z0 + y - (1.7 * radio + (radio / 1.5));
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy; cy += 1;
                            } while (y <= radio);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 0);
                            }
                        }

                        // ______________________________la base del sobrero con toride________________________
                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            double radio1 = radio + 3;
                            do
                            {
                                V3D.x0 = this.x0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Cos(y);
                                V3D.y0 = this.y0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Sin(y);
                                V3D.z0 = this.z0 - (4.5 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 0);
                            }
                       
                        }

                    }
              break;
             
                    // ********************************************************carretil ******************************************
                        case 5:
                    {
                        radio = 3;
                        
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = -radio / 1.5;
                            dy = Math.PI / 10;
                            do
                            {
                               V3D.z0 = this.x0 + (radio/1.5) * Math.Cos(x);
                                V3D.y0 = this.y0 + (radio)/1.5 * Math.Sin(x);
                                V3D.x0 = this.z0 + y - (1.7 * radio + (radio / 1.5));
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy; cy += 1;
                            } while (y <= radio);
                            x += dx; cx += 1;
                        } while (x <= 2* Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 0);
                            }
                        }
                        //________________________________________ las  puntas del carretil_____________________________________________
                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            double radio1 = radio + 3;
                            do
                            {
                                V3D.z0 = this.x0 + ((radio) + (radio1 /6) * Math.Cos(x)) * Math.Cos(y);
                                V3D.y0 = this.y0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Sin(y);
                                V3D.x0 = this.z0 - (4.5 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 0);
                            }
                       
                        }
                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            double radio1 = radio + 3;
                            do
                            {
                                V3D.z0 = this.x0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Cos(y);
                                V3D.y0 = this.y0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Sin(y);
                                V3D.x0 = this.z0 - (2 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 0);
                            }

                        }

                }
             break;
                    /////////////////////comienzo del puente
             case 6:
                {
                        radio = 3;
                        
                        x = Math.PI/6;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = -radio / 1.5;
                            dy = Math.PI / 10;
                            do
                            {
                                int a = 4;

                                V3D.z0 = this.y0 + (radio) / 1.5 * Math.Sin(x)*3;
                                V3D.y0 = this.x0 + (radio / 1.5) * Math.Cos(x)*3;
                                V3D.x0 = this.z0 + y - (1.7 * radio + (radio / 1.5));
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy; cy += 1;
                            } while (y <= radio);
                            x += dx; cx += 1;
                        } while (x <= (5*Math.PI/6) );
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 0);
                            }
                        }

                        x = 0;
                        dx = Math.PI / 10;
                        cx = 0;
                        do
                        {
                            double rad = 4;
                            y = -rad / 1.5;
                            dy = Math.PI / 10;
                            cy = 0;
                            do
                            {
                                V3D.x0 = this.x0 + rad / 4 * Math.Cos(x);
                                V3D.y0 = this.y0 + rad / 4 * Math.Sin(x);
                                V3D.z0 = this.z0 +y ;
                                V3D.c = this.c;
                                //V3D.Encender3D(grafico);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                //W3D.c = Color.Blue;
                                //W3D.Encender3D(grafico);
                                y += dy;
                                cy = cy + 1;
                            } while (y <= rad / 1.5);
                            x += dx;
                            cx = cx + 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx - 2;
                        ny = cy - 2;
                        for (cx = 0; cx <= nx; cx++)
                        {
                            for (cy = 0; cy <= ny; cy++)
                            {
                                Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                               vx[cx, cy + 1], vy[cx, cy + 1],
                                               vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                               vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                            }
                        }

                        x = 0;
                        dx = Math.PI / 10;
                        cx = 0;
                        do
                        {
                            double rad = 4;
                            y = -rad / 1.5;
                            dy = Math.PI / 10;
                            cy = 0;
                            do
                            {
                                V3D.x0 = this.x0 + rad / 4 * Math.Cos(x);
                                V3D.y0 = this.y0 + rad / 4 * Math.Sin(x);
                                V3D.z0 = this.z0 + y - (rad/2*rad/2);
                                V3D.c = this.c;
                                //V3D.Encender3D(grafico);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                //W3D.c = Color.Blue;
                                //W3D.Encender3D(grafico);
                                y += dy;
                                cy = cy + 1;
                            } while (y <= rad / 1.5);
                            x += dx;
                            cx = cx + 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx - 2;
                        ny = cy - 2;
                        for (cx = 0; cx <= nx; cx++)
                        {
                            for (cy = 0; cy <= ny; cy++)
                            {
                                Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                               vx[cx, cy + 1], vy[cx, cy + 1],
                                               vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                               vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                            }
                        }

                   }
                  break;
                  case 7:
                  {
                            double rad = 2;
                            //_______________________paragua  arriba___________________________
                            x = Math.PI / 2;
                            dx = Math.PI / 10;
                            cx = 0;
                            do
                            {
                                y = 0;
                                dy = Math.PI / 10;
                                cy = 0;
                                do
                                {

                                    V3D.x0 = this.x0 + rad * Math.Sin(x) * Math.Cos(y)*2;
                                    V3D.y0 = this.y0 + rad * Math.Sin(x) * Math.Sin(y)*2;
                                    V3D.z0 = this.z0 - (rad * 1.7) * Math.Cos(x);
                                    //V3D.c = Color.Blue;
                                    ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                    ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                    vx[cx, cy] = ax;
                                    vy[cx, cy] = ay;
                                    //W3D.Encender3D(grafico);
                                    //W3D.c = Color.Blue;
                                    //W3D.Apagar3D(grafico);
                                    y += dy;
                                    cy = cy + 1;

                                } while (y <= 2 * Math.PI);
                                x += dx;
                                cx = cx + 1;
                            } while (x <= Math.PI);

                            nx = cx - 2;
                            ny = cy - 2;
                            for (cx = 0; cx <= nx; cx++)
                            {
                                for (cy = 0; cy <= ny; cy++)
                                {
                                    ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                                            vx[cx, cy + 1], vy[cx, cy + 1],
                                                            vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                                            vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                                }
                            }
                            ////________________________ la cola del paraguas______________________________
                            x = 0;
                            dx = Math.PI / 10;
                            cx = 0;
                            do
                            {
                                y = -rad / 1.5;
                                dy = Math.PI / 10;
                                cy = 0;
                                do
                                {
                                    V3D.x0 = this.x0 + rad / 9 * Math.Cos(x);
                                    V3D.y0 = this.y0 + rad / 9 * Math.Sin(x);
                                    V3D.z0 = (this.z0 + y) -(rad*2);
                                    V3D.c = this.c;
                                    //V3D.Encender3D(grafico);
                                    ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                    Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                    vx[cx, cy] = ax;
                                    vy[cx, cy] = ay;
                                    //W3D.c = Color.Blue;
                                    //W3D.Encender3D(grafico);
                                    y += dy;
                                    cy = cy + 1;
                                } while (y <= 4*rad );
                                x += dx;
                                cx = cx + 1;
                            } while (x <= 2 * Math.PI);
                            nx = cx - 2;
                            ny = cy - 2;
                            for (cx = 0; cx <= nx; cx++)
                            {
                                for (cy = 0; cy <= ny; cy++)
                                {
                                    Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                                   vx[cx, cy + 1], vy[cx, cy + 1],
                                                   vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                                   vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                                }
                            }
                            // ______________________________la base del sobrero con toride________________________
                            // ______________________________gancho del paraguas________________________
                            cx = 0;

                            x = 0;
                            dx = Math.PI / 10;
                            do
                            {
                                cy = 0;
                                y = Math.PI;
                                radio=1;
                                dy = Math.PI / 10;
                                double radio1 = radio + 1;
                                do
                                {
                                    V3D.y0 = this.x0 + ((radio) + (radio1 / 8) * Math.Cos(x)) * Math.Cos(y);
                                    V3D.z0 = -2*this.y0 + ((radio) + (radio1 / 8) * Math.Cos(x)) * Math.Sin(y);
                                    V3D.x0 = -2*this.z0 -(radio1/8*Math.Sin(x));
                                    ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                    ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                    vx[cx, cy] = ax;
                                    vy[cx, cy] = ay;
                                    y += dy;
                                    cy += 1;
                                } while (y <= 2 * Math.PI);
                                x += dx; cx += 1;
                            } while (x <= 2 * Math.PI);
                            nx = cx;
                            ny = cy;
                            for (int i = 0; i < nx - 1; i++)
                            {
                                for (int j = 0; j < ny - 1; j++)
                                {
                                    Cuadrilatero(vx[i, j], vy[i, j],
                                        vx[i + 1, j], vy[i + 1, j],
                                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                                        vx[i, j + 1], vy[i, j + 1], grafico, 0);
                                }

                            }


                        }
              break;

                  case 8:
                      {
              int tp = 2; 
              double w1 = 1.5, d, v = 9.3, z1; 
              cx = 0; 
              x = -12; 
              dx = Math.PI / 10; 
              do { 
                  cy = 0; 
                  y = -10; 
                  dy = Math.PI/10; 
                  do { 
                      d = Math.Sqrt((x * x) + (y * y)); 
                      double k = w1 * (d - tp * v); 
                      z1 = Math.Sin(k) + 1; 
                      V3D.x0 = x; 
                      V3D.y0 = y; 
                      V3D.z0 = z1; 
                      ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0,gama,eje, out W3D.x0, out W3D.y0, out W3D.z0); 
                      ModelosMat.Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay); 
                      V3D.c=this.c; 
                      vx[cx, cy] = ax; 
                      vy[cx, cy] = ay; 
                      V3D.Encender3D(grafico); 
                      y += dy; 
                      cy += 1; 
                  } while (y<=10); 
                  x += dx; cx += 1; 
              } while (x<=12); 
              nx = cx;
                            ny = cy;
                            for (int i = 0; i < nx - 1; i++)
                            {
                                for (int j = 0; j < ny - 1; j++)
                                {
                                    Cuadrilatero(vx[i, j], vy[i, j],
                                        vx[i + 1, j], vy[i + 1, j],
                                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                                        vx[i, j + 1], vy[i, j + 1], grafico, 0);
                                }

                            }


                        }
              break;

                  //*************Cuerno***************
                  case 9:
              {
                  radio = 10;
                  x = 0;
                  dx = Math.PI / 10;
                  cx = 0;
                  do
                  {
                      y = 0;
                      dy = Math.PI / 10;
                      cy = 0;
                      do
                      {
                          radio = (0 * ((y - 8) / (0 - 8))) + (4 * ((y - 0) / (8 - 0)));
                          V3D.x0 = this.x0 + (10 + (radio / 3) * Math.Cos(x)) * Math.Cos(y);
                          V3D.y0 = this.y0 + (10 + (radio / 3) * Math.Cos(x)) * Math.Sin(y);
                          V3D.z0 = this.z0 + (radio / 3) * Math.Sin(x)+radio *1.5;
                          /*V3D.c = Color.Blue;
                          V3D.Encender3D(grafico);*/
                          ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                          ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                          //W3D.c = Color.Blue;
                          //W3D.Encender3D(grafico);
                          vx[cx, cy] = ax;
                          vy[cx, cy] = ay;
                          y += dy;
                          cy = cy + 1;
                      } while (y <= 3 * Math.PI);
                      x += dx;
                      cx = cx + 1;

                  } while (x <= 3 * Math.PI);

                  nx = cx - 2;
                  ny = cy - 2;
                  for (cx = 0; cx <= nx; cx++)
                  {
                      for (cy = 0; cy <= ny; cy++)
                      {
                          ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                                   vx[cx, cy + 1], vy[cx, cy + 1],
                                                   vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                                   vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);



                      }
                  }
              }
              break;


                  case 10:
              { 
                    int tp = 1; 
              double w = 1.5, w2=2, d, d1, v = 9.3, z1=0,z2; 
              
              cx = 0;
              x = -12;
              dx = Math.PI / 10;
              do
              {
                  cy = 0;
                  y = -10;
                  dy = Math.PI / 10;
                  do
                  {
                      d = Math.Sqrt(Math.Pow((x + 4), 2) + (y * y));
                      double k = w * (d - tp * v);
                      z1 = Math.Sin(k) + 1;

                      d1 = Math.Sqrt(Math.Pow((x - 4), 2) + (y * y));
                      double k1 = w2 * (d1 - tp * v);
                      z2 = Math.Sin(k1) + 1;
                      z = Convert.ToInt32((z1 + z2));
                      
                      V3D.x0 = x;
                      V3D.y0 = y;
                      V3D.z0 = z;
                      
                      Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                      Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                      
                      V3D.c = this.c;
                      vx[cx, cy] = ax;
                      vy[cx, cy] = ay;
                      V3D.Encender3D(grafico);
                      y += dy;
                      cy += 1;
                  } while (y <= 10);
                  x += dx; 
                  cx += 1;
              } while (x <= 12);
              nx = cx;
              ny = cy;
              for (int i = 0; i < nx - 1; i++)
              {
                  for (int j = 0; j < ny - 1; j++)
                  {
                      Cuadrilatero(vx[i, j], vy[i, j],
                          vx[i + 1, j], vy[i + 1, j],
                          vx[i + 1, j + 1], vy[i + 1, j + 1],
                          vx[i, j + 1], vy[i, j + 1], grafico, 0);
                  }

              }
              
              x = 0;
              dx = Math.PI / 10;
              cx = 0;

              do
              {
                  y = 0;
                  dy = Math.PI / 10;
                  cy = 0;
                  do
                  {
                      V3D.x0 = this.x0 + (radio + (radio1) * Math.Cos(x)) * Math.Cos(y);
                      V3D.y0 = this.y0 + (radio + (radio1) * Math.Cos(x)) * Math.Sin(y);
                      V3D.z0 = this.z0 + radio1 * Math.Sin(x) * 0.5;

                      Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                      Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                      vx[cx, cy] = ax;
                      vy[cx, cy] = ay;
                      y += dy;
                      cy = cy + 1;
                  } while (y <= 2 * Math.PI);
                  x += dx;
                  cx = cx + 1;
              } while (x <= 2 * Math.PI);
              nx = cx - 2;
              ny = cy - 2;

              for (cx = 0; cx <= nx; cx++)
              {
                  for (cy = 0; cy <= ny; cy++)
                  {
                      Cuadrilatero(vx[cx, cy], vy[cx, cy],
                       vx[cx, cy + 1], vy[cx, cy + 1],
                       vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                       vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                  }

              }


              }
              break;


                  case 11:
              {
                  int tp = 1;
                  double w = 1.5, w2 = 2, d, d1, v = 9.3, z1 = 0, z2;

                  cx = 0;
                  x = -12;
                  dx = Math.PI / 10;
                  do
                  {
                      cy = 0;
                      y = -10;
                      dy = Math.PI / 10;
                      do
                      {
                          d = Math.Sqrt(Math.Pow((x + 4), 2) + (y * y));
                          double k = w * (d - tp * v);
                          z1 = Math.Sin(k) + 1;

                          d1 = Math.Sqrt(Math.Pow((x - 4), 2) + (y * y));
                          double k1 = w2 * (d1 - tp * v);
                          z2 = Math.Sin(k1) + 1;
                          z = Convert.ToInt32((z1 + z2));

                          V3D.x0 = x;
                          V3D.y0 = y;
                          V3D.z0 = z;

                          Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                          Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);

                          V3D.c = this.c;
                          vx[cx, cy] = ax;
                          vy[cx, cy] = ay;
                          V3D.Encender3D(grafico);
                          y += dy;
                          cy += 1;
                      } while (y <= 10);
                      x += dx;
                      cx += 1;
                  } while (x <= 12);
                  nx = cx;
                  ny = cy;
                  for (int i = 0; i < nx - 1; i++)
                  {
                      for (int j = 0; j < ny - 1; j++)
                      {
                          Cuadrilatero(vx[i, j], vy[i, j],
                              vx[i + 1, j], vy[i + 1, j],
                              vx[i + 1, j + 1], vy[i + 1, j + 1],
                              vx[i, j + 1], vy[i, j + 1], grafico, 0);
                      }

                  }

                  //x = 0;
                  //dx = Math.PI / 10;
                  //cx = 0;

                  //do
                  //{
                  //    y = 0;
                  //    dy = Math.PI / 10;
                  //    cy = 0;
                  //    do
                  //    {
                  //        V3D.x0 = this.x0 + (radio + (radio1) * Math.Cos(x)) * Math.Cos(y);
                  //        V3D.y0 = this.y0 + (radio + (radio1) * Math.Cos(x)) * Math.Sin(y);
                  //        V3D.z0 = this.z0 + radio1 * Math.Sin(x) * 0.5;

                  //        Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                  //        Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                  //        vx[cx, cy] = ax;
                  //        vy[cx, cy] = ay;
                  //        y += dy;
                  //        cy = cy + 1;
                  //    } while (y <= 2 * Math.PI);
                  //    x += dx;
                  //    cx = cx + 1;
                  //} while (x <= 2 * Math.PI);
                  //nx = cx - 2;
                  //ny = cy - 2;

                  //for (cx = 0; cx <= nx; cx++)
                  //{
                  //    for (cy = 0; cy <= ny; cy++)
                  //    {
                  //        Cuadrilatero(vx[cx, cy], vy[cx, cy],
                  //         vx[cx, cy + 1], vy[cx, cy + 1],
                  //         vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                  //         vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                  //    }

                  //}


              }
              break;




            }
        }
        
            
        public void ApagarSuperficie(Bitmap grafico)// *****++++++++++++++++++++++++++++ pro apagar+++++++++++++++++++++++******************************
        {
            double x, dx, y, dy, z, dz;
            Vector3D V3D = new Vector3D();
            Vector3D W3D = new Vector3D();


            x = 0;
            dx = 0.5;

            switch (tipo)
            {  // ************************************************cilindro normal ***************************************
                case 0:
                {
                    x = 0;
                    dx = Math.PI/10;
                    cx = 0;
                   
                    do
                    {
                        y = -3;
                        dy = Math.PI/10;
                        cy = 0;

                    
                        do
                        {
                            V3D.x0 = this.x0 + 4 * Math.Cos(x);
                            V3D.y0 = this.y0 + 4 * Math.Sin(x);
                            V3D.z0 = this.z0 + y;
                            V3D.c = this.c;
                       
                          
                           // V3D.Encender3D(grafico);
                            
                            ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0,gama,eje, out W3D.x0, out W3D.y0, out W3D.z0);
                            ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);

                            vx[cx, cy] = ax;
                            vy[cx, cy] = ay;
                           //W3D.c=Color.Blue;
                           //W3D.Encender3D(grafico);
                            y += dy;
                            cy = cy + 1;
                        } while (y<=3);
                        x += dx;
                        cx = cx + 1;
                    } while (x<=2 *Math.PI);
                    nx = cx-2;
                    ny = cy-2;
                  
                    //if (tipom == 0 )
                   // {
                    for (cx = 0; cx <= nx; cx++)
                    {
                        for (cy = 0; cy <=ny; cy++)
                        {

                            ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                vx[cx , cy + 1], vy[cx, cy+1], 
                                vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                vx[cx+1, cy], vy[cx + 1, cy ], grafico, 3);
                         
                            
                        }
                        
                    }
                 //  // }
                 //   if (tipom == 1)
                 //   {
                 //       for (cx = 0; cx <= nx; cx++)
                 //       {
                 //           for (cy = 0; cy <= ny; cy++)
                 //           {

                 //               ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                 //                   vx[cx, cy + 1], vy[cx, cy + 1],
                 //                   vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                 //                   vx[cx + 1, cy], vy[cx + 1, cy], grafico, 1);


                 //           }

                 //       }
                 //   }
                    
                   
                 //   if (tipom == 2)
                 //   {

                 //       for (cx = 0; cx <= nx; cx++)
                 //   {
                 //       for (cy = 0; cy <=ny; cy++)
                 //       {

                 //           ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                 //               vx[cx , cy + 1], vy[cx, cy+1], 
                 //               vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                 //               vx[cx+1, cy], vy[cx + 1, cy ], grafico, 2);
                       
                            
                 //       }|
                        
                 //   }
                 //}    |
                }
                 break;
                            //*******************************circunferencia completa******************************
                case 1:
                 {
                     x = 0;
                     dx = Math.PI/10;
                     cx=0;
                     do
                     {
                         y = 0;
                         dy = Math.PI/10;
                         cy=0;
                         do
                         {
                             V3D.x0 = this.x0 + 5 * Math.Sin(x) * Math.Cos(y);
                             V3D.y0 = this.y0 + 5 * Math.Sin(x) * Math.Sin(y);
                             V3D.z0 = this.z0 + 5 * Math.Cos(x); 
                             /*V3D.c = this.c;
                             V3D.Encender3D(grafico);*/
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             ModelosMat.Axionometria(W3D.x0,W3D.y0,W3D.z0,out ax,out ay);

                             vx[cx, cy]= ax;
                             vy[cx,cy]=ay;
                             y += dy;
                             cy = cy + 1;
                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= Math.PI);
                     nx = cx - 2;
                     ny = cy - 2;
                     for ( cx = 0; cx <=nx; cx++)
                     {
                         for ( cy = 0; cy <=ny; cy++)
                         {
                             ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                 vx[cx, cy + 1], vy[cx, cy + 1],
                                 vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                 vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);

                         }
                     }
                 }
                 break;
                     //**********************************************toroide******************************************************
                case 2:
                     {
                         x = 0;
                     dx = Math.PI/10;
                     cx = 0;
                     do
                     {
                         y = 0;
                         dy =Math.PI/10;
                         cy = 0;
                         do
                         {
                             V3D.x0 = this.x0 + (radio + (radio1) * Math.Cos(x)) * Math.Cos(y);
                             V3D.y0 = this.y0 + (radio + (radio1) * Math.Cos(x)) * Math.Sin(y);
                             V3D.z0 = this.z0 + radio1 * Math.Sin(x) * 0.5;
                             /*V3D.c = Color.Blue;
                             V3D.Encender3D(grafico);*/
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                         ModelosMat.Axionometria(W3D.x0,W3D.y0, W3D.z0,out ax ,out ay);
                             //W3D.c = Color.Blue;
                             //W3D.Encender3D(grafico);
                             vx[cx,cy]=ax;
                             vy[cx,cy]=ay;
                             y += dy;
                             cy = cy + 1;
                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;

                     } while (x <= 2*Math.PI);

                     nx = cx - 2;
                     ny = cy - 2;
                     for (cx = 0; cx<= nx; cx++)
                     {
                         for ( cy = 0; cy <=ny; cy++)
                         {
                              ModelosMat.Cuadrilatero(vx[cx,cy],vy[cx,cy],
                                                       vx[cx,cy+1],vy[cx,cy+1],
                                                       vx[cx+1,cy+1],vy[cx+1,cy+1],
                                                       vx[cx+1,cy],vy[cx+1,cy],grafico,3);
                                


                         }
                     }
                 }
                 break;
                //**************************************************Copa*******************************************************
                case 3:
                 {
                     double rad = 4;
                     //_______________________parte de la copa___________________________
                     x = Math.PI / 2;
                     dx = Math.PI / 10;
                     cx = 0;
                     do
                     {
                         y = 0;
                         dy = Math.PI / 10;
                         cy = 0;
                         do
                         {

                             V3D.x0 = this.x0 + rad * Math.Sin(x) * Math.Cos(y);
                             V3D.y0 = this.y0 + rad * Math.Sin(x) * Math.Sin(y);
                             V3D.z0 = this.z0 + (rad * 1.7) * Math.Cos(x);
                             //V3D.c = Color.Blue;
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                             vx[cx, cy] = ax;
                             vy[cx, cy] = ay;
                             //W3D.Encender3D(grafico);
                             //W3D.c = Color.Blue;
                             //W3D.Apagar3D(grafico);
                             y += dy;
                             cy = cy + 1;

                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= Math.PI);

                     nx = cx - 2;
                     ny = cy - 2;
                     for (cx = 0; cx <= nx; cx++)
                     {
                         for (cy = 0; cy <= ny; cy++)
                         {
                             ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                                     vx[cx, cy + 1], vy[cx, cy + 1],
                                                     vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                                     vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                         }
                     }
                     //________________________ parte de del medio de la copa______________________________
                     x = 0;
                     dx = Math.PI/10;
                     cx = 0;
                     do
                     {
                         y = -rad/1.5;
                         dy = Math.PI/10;
                         cy=0;
                         do
                         {
                             V3D.x0 = this.x0 + rad/5 * Math.Cos(x);
                             V3D.y0 = this.y0 + rad/5 * Math.Sin(x);
                             V3D.z0 = (this.z0 + y)-(rad+2*rad/1.5);
                             V3D.c = this.c;
                             //V3D.Encender3D(grafico);
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                             vx[cx,cy]=ax;
                             vy[cx,cy]=ay;
                             //W3D.c = Color.Blue;
                             //W3D.Encender3D(grafico);
                             y += dy;
                             cy = cy + 1;
                         } while (y <= rad/1.5);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= 2 * Math.PI);
                     nx = cx - 2;
                     ny = cy - 2;
                     for ( cx = 0; cx <= nx; cx++)
                     {
                         for ( cy = 0; cy <= ny; cy++)
                         {
                             Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                            vx[cx, cy + 1], vy[cx, cy + 1],
                                            vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                            vx[cx + 1, cy], vy[cx + 1, cy], grafico,3);
                         }
                     }
                    // ________________________________________parte de la base de la copa_______________________________
                     x = Math.PI / 2;
                     dx =Math.PI/10;
                     cx = 0;
                     do
                     {
                         y = 0;
                         dy = Math.PI/10;
                         cy = 0;
                         do
                         {

                             V3D.x0 = this.x0 + rad/1.5 * Math.Sin(x) * Math.Cos(y);
                             V3D.y0 = this.y0 + rad/1.5 * Math.Sin(x) * Math.Sin(y);
                             V3D.z0 = this.z0 - (rad +( 3 * rad / 1.5));
                             //V3D.c = Color.Blue;
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                             Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                             vx[cx,cy]=ax;
                             vy[cx,cy]=ay;
                             //W3D.c = Color.Blue;
                             //W3D.Encender3D(grafico);
                             //W3D.Apagar3D(grafico);
                             y += dy;
                             cy = cy + 1;
                         } while (y <= 2 * Math.PI);
                         x += dx;
                         cx = cx + 1;
                     } while (x <= Math.PI);
                     nx = cx - 1;
                     ny = cy - 1;

                     for (cx = 0; cx <=nx; cx++)
                     {
                         for (cy = 0; cy < ny; cy++)
                         {
                             Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                          vx[cx, cy + 1], vy[cx, cy + 1],
                                          vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                          vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                             
                         }
                     }
               }
                 break;
                   //***************************************** sombrero*******************
                case 4:
                    {

                        radio = 3;
                        // _________________________parte de la corona del sombrero________________________________
                        cx = 0;
                        x = Math.PI / 2;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            do
                            {
                                V3D.x0 = this.x0 + radio/1.5 * Math.Sin(x) * Math.Cos(y);
                                V3D.y0 = this.y0 + radio/1.5 * Math.Sin(x) * Math.Sin(y);
                                V3D.z0 = this.z0 - (2.1 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx;
                            cx += 1;
                        } while (x <= Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j], vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1], vx[i, j + 1], vy[i, j + 1], grafico, 3);
                            }
                        } 
                        // ______________________________________la perte  del medio del sombrero___________________________________

                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = -radio / 1.5;
                            dy = Math.PI / 10;
                            do
                            {
                                V3D.x0 = this.x0 + (radio/1.5) * Math.Cos(x);
                                V3D.y0 = this.y0 + (radio/1.5) * Math.Sin(x);
                                V3D.z0 = this.z0 + y - (1.7 * radio + (radio / 1.5));
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy; cy += 1;
                            } while (y <= radio);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 3);
                            }
                        }

                        // ______________________________la base del sobrero con toride________________________
                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            double radio1 = radio + 3;
                            do
                            {
                                V3D.x0 = this.x0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Cos(y);
                                V3D.y0 = this.y0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Sin(y);
                                V3D.z0 = this.z0 - (4.5 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 3);
                            }
                       
                        }

                    }
              break;
             
                    // ********************************************************carretil ******************************************
                        case 5:
                    {
                        radio = 3;
                        
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = -radio / 1.5;
                            dy = Math.PI / 10;
                            do
                            {
                               V3D.z0 = this.x0 + (radio/1.5) * Math.Cos(x);
                                V3D.y0 = this.y0 + (radio)/1.5 * Math.Sin(x);
                                V3D.x0 = this.z0 + y - (1.7 * radio + (radio / 1.5));
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy; cy += 1;
                            } while (y <= radio);
                            x += dx; cx += 1;
                        } while (x <= 2* Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 3);
                            }
                        }
                        //________________________________________ las  puntas del carretil_____________________________________________
                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            double radio1 = radio + 3;
                            do
                            {
                                V3D.z0 = this.x0 + ((radio) + (radio1 /6) * Math.Cos(x)) * Math.Cos(y);
                                V3D.y0 = this.y0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Sin(y);
                                V3D.x0 = this.z0 - (4.5 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 3);
                            }
                       
                        }
                        cx = 0;
                        x = 0;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = 0;
                            dy = Math.PI / 10;
                            double radio1 = radio + 3;
                            do
                            {
                                V3D.z0 = this.x0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Cos(y);
                                V3D.y0 = this.y0 + ((radio) + (radio1 / 6) * Math.Cos(x)) * Math.Sin(y);
                                V3D.x0 = this.z0 - (2 * radio / 1.5);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy;
                                cy += 1;
                            } while (y <= 2 * Math.PI);
                            x += dx; cx += 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 3);
                            }

                        }

                }
             break;

             case 6:
                {
                        radio = 3;
                        
                        x = Math.PI/6;
                        dx = Math.PI / 10;
                        do
                        {
                            cy = 0;
                            y = -radio / 1.5;
                            dy = Math.PI / 10;
                            do
                            {
                                int a = 4;

                                V3D.z0 = this.y0 + (radio) / 1.5 * Math.Sin(x)*3;
                                V3D.y0 = this.x0 + (radio / 1.5) * Math.Cos(x)*3;
                                V3D.x0 = this.z0 + y - (1.7 * radio + (radio / 1.5));
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                W3D.c = this.c;
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                y += dy; cy += 1;
                            } while (y <= radio);
                            x += dx; cx += 1;
                        } while (x <= (5*Math.PI/6) );
                        nx = cx;
                        ny = cy;
                        for (int i = 0; i < nx - 1; i++)
                        {
                            for (int j = 0; j < ny - 1; j++)
                            {
                                Cuadrilatero(vx[i, j], vy[i, j],
                                    vx[i + 1, j], vy[i + 1, j],
                                    vx[i + 1, j + 1], vy[i + 1, j + 1],
                                    vx[i, j + 1], vy[i, j + 1], grafico, 3);
                            }
                        }

                        x = 0;
                        dx = Math.PI / 10;
                        cx = 0;
                        do
                        {
                            double rad = 4;
                            y = -rad / 1.5;
                            dy = Math.PI / 10;
                            cy = 0;
                            do
                            {
                                V3D.x0 = this.x0 + rad / 4 * Math.Cos(x);
                                V3D.y0 = this.y0 + rad / 4 * Math.Sin(x);
                                V3D.z0 = this.z0 +y ;
                                V3D.c = this.c;
                                //V3D.Encender3D(grafico);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                //W3D.c = Color.Blue;
                                //W3D.Encender3D(grafico);
                                y += dy;
                                cy = cy + 1;
                            } while (y <= rad / 1.5);
                            x += dx;
                            cx = cx + 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx - 2;
                        ny = cy - 2;
                        for (cx = 0; cx <= nx; cx++)
                        {
                            for (cy = 0; cy <= ny; cy++)
                            {
                                Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                               vx[cx, cy + 1], vy[cx, cy + 1],
                                               vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                               vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                            }
                        }

                        x = 0;
                        dx = Math.PI / 10;
                        cx = 0;
                        do
                        {
                            double rad = 4;
                            y = -rad / 1.5;
                            dy = Math.PI / 10;
                            cy = 0;
                            do
                            {
                                V3D.x0 = this.x0 + rad / 4 * Math.Cos(x);
                                V3D.y0 = this.y0 + rad / 4 * Math.Sin(x);
                                V3D.z0 = this.z0 + y - (rad/2*rad/2);
                                V3D.c = this.c;
                                //V3D.Encender3D(grafico);
                                ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                vx[cx, cy] = ax;
                                vy[cx, cy] = ay;
                                //W3D.c = Color.Blue;
                                //W3D.Encender3D(grafico);
                                y += dy;
                                cy = cy + 1;
                            } while (y <= rad / 1.5);
                            x += dx;
                            cx = cx + 1;
                        } while (x <= 2 * Math.PI);
                        nx = cx - 2;
                        ny = cy - 2;
                        for (cx = 0; cx <= nx; cx++)
                        {
                            for (cy = 0; cy <= ny; cy++)
                            {
                                Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                               vx[cx, cy + 1], vy[cx, cy + 1],
                                               vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                               vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                            }
                        }

                   }
                  break;
                  case 7:
                  {
                            double rad = 2;
                            //_______________________paragua  arriba___________________________
                            x = Math.PI / 2;
                            dx = Math.PI / 10;
                            cx = 0;
                            do
                            {
                                y = 0;
                                dy = Math.PI / 10;
                                cy = 0;
                                do
                                {

                                    V3D.x0 = this.x0 + rad * Math.Sin(x) * Math.Cos(y)*2;
                                    V3D.y0 = this.y0 + rad * Math.Sin(x) * Math.Sin(y)*2;
                                    V3D.z0 = this.z0 - (rad * 1.7) * Math.Cos(x);
                                    //V3D.c = Color.Blue;
                                    ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                    ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                    vx[cx, cy] = ax;
                                    vy[cx, cy] = ay;
                                    //W3D.Encender3D(grafico);
                                    //W3D.c = Color.Blue;
                                    //W3D.Apagar3D(grafico);
                                    y += dy;
                                    cy = cy + 1;

                                } while (y <= 2 * Math.PI);
                                x += dx;
                                cx = cx + 1;
                            } while (x <= Math.PI);

                            nx = cx - 2;
                            ny = cy - 2;
                            for (cx = 0; cx <= nx; cx++)
                            {
                                for (cy = 0; cy <= ny; cy++)
                                {
                                    ModelosMat.Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                                            vx[cx, cy + 1], vy[cx, cy + 1],
                                                            vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                                            vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                                }
                            }
                            ////________________________ la cola del paraguas______________________________
                            x = 0;
                            dx = Math.PI / 10;
                            cx = 0;
                            do
                            {
                                y = -rad / 1.5;
                                dy = Math.PI / 10;
                                cy = 0;
                                do
                                {
                                    V3D.x0 = this.x0 + rad / 9 * Math.Cos(x);
                                    V3D.y0 = this.y0 + rad / 9 * Math.Sin(x);
                                    V3D.z0 = (this.z0 + y) -(rad*2);
                                    V3D.c = this.c;
                                    //V3D.Encender3D(grafico);
                                    ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                    Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                                    vx[cx, cy] = ax;
                                    vy[cx, cy] = ay;
                                    //W3D.c = Color.Blue;
                                    //W3D.Encender3D(grafico);
                                    y += dy;
                                    cy = cy + 1;
                                } while (y <= 4*rad );
                                x += dx;
                                cx = cx + 1;
                            } while (x <= 2 * Math.PI);
                            nx = cx - 2;
                            ny = cy - 2;
                            for (cx = 0; cx <= nx; cx++)
                            {
                                for (cy = 0; cy <= ny; cy++)
                                {
                                    Cuadrilatero(vx[cx, cy], vy[cx, cy],
                                                   vx[cx, cy + 1], vy[cx, cy + 1],
                                                   vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                                                   vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                                }
                            }
                            // ______________________________la base del sobrero con toride________________________
                            cx = 0;

                            x = 0;
                            dx = Math.PI / 10;
                            do
                            {
                                cy = 0;
                                y = Math.PI;
                                radio = 1;
                                dy = Math.PI / 10;
                                double radio1 = radio + 1;
                                do
                                {
                                    V3D.y0 = this.x0 + ((radio) + (radio1 / 8) * Math.Cos(x)) * Math.Cos(y);
                                    V3D.z0 = -2 * this.y0 + ((radio) + (radio1 / 8) * Math.Cos(x)) * Math.Sin(y);
                                    V3D.x0 = -2 * this.z0 - (radio1 / 8 * Math.Sin(x));
                                    ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                                    ModelosMat.Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay); W3D.c = this.c;
                                    vx[cx, cy] = ax;
                                    vy[cx, cy] = ay;
                                    y += dy;
                                    cy += 1;
                                } while (y <= 2 * Math.PI);
                                x += dx; cx += 1;
                            } while (x <= 2 * Math.PI);
                            nx = cx;
                            ny = cy;
                            for (int i = 0; i < nx - 1; i++)
                            {
                                for (int j = 0; j < ny - 1; j++)
                                {
                                    Cuadrilatero(vx[i, j], vy[i, j],
                                        vx[i + 1, j], vy[i + 1, j],
                                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                                        vx[i, j + 1], vy[i, j + 1], grafico, 3);
                                }

                            }



                        }
              break;

                  case 8:
              {
                  int tp = 2;
                  double w1 = 1.5, d, v = 9.3, z1;
                  cx = 0;
                  x = -12;
                  dx = Math.PI / 10;
                  do
                  {
                      cy = 0;
                      y = -10;
                      dy = Math.PI / 10;
                      do
                      {
                          d = Math.Sqrt((x * x) + (y * y));
                          double k = w1 * (d - tp * v);
                          z1 = Math.Sin(k) + 1;
                          V3D.x0 = x;
                          V3D.y0 = y;
                          V3D.z0 = z1;
                          ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0,gama,eje, out W3D.x0, out W3D.y0, out W3D.z0); 
                          ModelosMat.Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                          V3D.c = this.c;
                          vx[cx, cy] = ax;
                          vy[cx, cy] = ay;
                          V3D.Encender3D(grafico);
                          y += dy;
                          cy += 1;
                      } while (y <= 10);
                      x += dx; cx += 1;
                  } while (x <= 12);
                  nx = cx;
                  ny = cy;
                  for (int i = 0; i < nx - 1; i++)
                  {
                      for (int j = 0; j < ny - 1; j++)
                      {
                          Cuadrilatero(vx[i, j], vy[i, j],
                              vx[i + 1, j], vy[i + 1, j],
                              vx[i + 1, j + 1], vy[i + 1, j + 1],
                              vx[i, j + 1], vy[i, j + 1], grafico, 3);
                      }

                  }


              }
              break;

                  //*************Cuerno***************
                  case 9:
       {
           radio = 10;
                         x = 0;
                     dx = Math.PI/10;
                     cx = 0;
                     do
                     {
                         y = 0;
                         dy =Math.PI/10;
                         cy = 0;
                         do
                         {
                             radio = (0 * ((y - 8) / (0 - 8))) + (4 * ((y - 0) / (8 - 0)));
                             V3D.x0 = this.x0 + (10 + (radio/3) * Math.Cos(x)) * Math.Cos(y);
                             V3D.y0 = this.y0 + (10 + (radio/3) * Math.Cos(x)) * Math.Sin(y);
                             V3D.z0 = this.z0 + (radio/3) * Math.Sin(x) + radio *1.5;
                             /*V3D.c = Color.Blue;
                             V3D.Encender3D(grafico);*/
                             ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                         ModelosMat.Axionometria(W3D.x0,W3D.y0, W3D.z0,out ax ,out ay);
                             //W3D.c = Color.Blue;
                             //W3D.Encender3D(grafico);
                             vx[cx,cy]=ax;
                             vy[cx,cy]=ay;
                             y += dy;
                             cy = cy + 1;
                         } while (y <= 3 * Math.PI);
                         x += dx;
                         cx = cx + 1;

                     } while (x <= 3 * Math.PI);

                     nx = cx - 1;
                     ny = cy - 1;
                     for (cx = 0; cx<= nx; cx++)
                     {
                         for ( cy = 0; cy <=ny; cy++)
                         {
                              ModelosMat.Cuadrilatero(vx[cx,cy],vy[cx,cy],
                                                       vx[cx,cy+1],vy[cx,cy+1],
                                                       vx[cx+1,cy+1],vy[cx+1,cy+1],
                                                       vx[cx+1,cy],vy[cx+1,cy],grafico,3);
                                


                         }
                     }
                 }
                            break;


                  case 10:
              {
                  int tp = 1;
                  double w = 1.5, w2 = 2, d, d1, v = 9.3, z1 = 0,  z2;

                  cx = 0;
                  x = -12;
                  dx = Math.PI / 10;
                  do
                  {
                      cy = 0;
                      y = -10;
                      dy = Math.PI / 10;
                      do
                      {
                          d = Math.Sqrt(Math.Pow((x + 4), 2) + (y * y));
                          double k = w * (d - tp * v);
                          z1 = Math.Sin(k) + 1;

                          d1 = Math.Sqrt(Math.Pow((x - 4), 2) + (y * y));
                          double k1 = w2 * (d1 - tp * v);
                          z2 = Math.Sin(k1) + 1;
                          z = Convert.ToInt32((z1 + z2));

                          V3D.x0 = x;
                          V3D.y0 = y;
                          V3D.z0 = z;

                          Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                          Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);

                          V3D.c = this.c;
                          vx[cx, cy] = ax;
                          vy[cx, cy] = ay;
                          V3D.Encender3D(grafico);
                          y += dy;
                          cy += 1;
                      } while (y <= 10);
                      x += dx;
                      cx += 1;
                  } while (x <= 12);
                  nx = cx;
                  ny = cy;
                  for (int i = 0; i < nx - 1; i++)
                  {
                      for (int j = 0; j < ny - 1; j++)
                      {
                          Cuadrilatero(vx[i, j], vy[i, j],
                              vx[i + 1, j], vy[i + 1, j],
                              vx[i + 1, j + 1], vy[i + 1, j + 1],
                              vx[i, j + 1], vy[i, j + 1], grafico, 3);
                      }

                  }

                  x = 0;
                  dx = Math.PI / 10;
                  cx = 0;

                  do
                  {
                      y = 0;
                      dy = Math.PI / 10;
                      cy = 0;
                      do
                      {
                          V3D.x0 = this.x0 + (radio + (radio1) * Math.Cos(x)) * Math.Cos(y);
                          V3D.y0 = this.y0 + (radio + (radio1) * Math.Cos(x)) * Math.Sin(y);
                          V3D.z0 = this.z0 + radio1 * Math.Sin(x) * 0.5;

                          Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                          Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                          vx[cx, cy] = ax;
                          vy[cx, cy] = ay;
                          y += dy;
                          cy = cy + 1;
                      } while (y <= 2 * Math.PI);
                      x += dx;
                      cx = cx + 1;
                  } while (x <= 2 * Math.PI);
                  nx = cx - 2;
                  ny = cy - 2;

                  for (cx = 0; cx <= nx; cx++)
                  {
                      for (cy = 0; cy <= ny; cy++)
                      {
                          Cuadrilatero(vx[cx, cy], vy[cx, cy],
                           vx[cx, cy + 1], vy[cx, cy + 1],
                           vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                           vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                      }

                  }


              }
              break;


                  case 11:
              {
                  int tp = 2;
                  double w1 = 1.5, d, v = 9.3, z1;
                  cx = 0;
                  x = -12;
                  dx = Math.PI / 10;
                  do
                  {
                      cy = 0;
                      y = -10;
                      dy = Math.PI / 10;
                      do
                      {
                          d = Math.Sqrt((x * x) + (y * y));
                          double k = w1 * (d - tp * v);
                          z1 = Math.Sin(k) + 1;
                          V3D.x0 = x;
                          V3D.y0 = y;
                          V3D.z0 = z1;
                          ModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                          ModelosMat.Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                          V3D.c = this.c;
                          vx[cx, cy] = ax;
                          vy[cx, cy] = ay;
                          V3D.Encender3D(grafico);
                          y += dy;
                          cy += 1;
                      } while (y <= 10);
                      x += dx; cx += 1;
                  } while (x <= 12);
                  nx = cx;
                  ny = cy;
                  for (int i = 0; i < nx - 1; i++)
                  {
                      for (int j = 0; j < ny - 1; j++)
                      {
                          Cuadrilatero(vx[i, j], vy[i, j],
                              vx[i + 1, j], vy[i + 1, j],
                              vx[i + 1, j + 1], vy[i + 1, j + 1],
                              vx[i, j + 1], vy[i, j + 1], grafico, 3);
                      }

                  }

              }
              break;


            }
}

        public void EncencerSuperOnda(Bitmap grafico, double tp)
        {


            double x, y, z, dx, dy, dz, z1 = 0, v = 9.3, d, d1;
            double z2;
            double w = 1.5, w2 = 2;
            Vector3D V3D = new Vector3D();
            Vector3D W3D = new Vector3D();



            cx = 0;
            x = -12;
            dx = Math.PI / 10;
            do
            {
                cy = 0;
                y = -10;
                dy = Math.PI / 10;
                do
                {
                    d = Math.Sqrt(Math.Pow((x + 4), 2) + (y * y));
                    double k = w * (d - tp * v);
                    z1 = Math.Sin(k) + 1;

                    d1 = Math.Sqrt(Math.Pow((x - 4), 2) + (y * y));
                    double k1 = w2 * (d1 - tp * v);
                    z2 = Math.Sin(k1) + 1;
                    z = Convert.ToInt32((z1 + z2));



                    V3D.x0 = x;
                    V3D.y0 = y;
                    V3D.z0 = z;
                    Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                    Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                    V3D.c = this.c;
                    vx[cx, cy] = ax;
                    vy[cx, cy] = ay;
                    V3D.Encender3D(grafico);
                    y += dy;
                    cy += 1;
                } while (y <= 10);
                x += dx; cx += 1;
            } while (x <= 12);
            nx = cx;
            ny = cy;
            for (int i = 0; i < nx - 1; i++)
            {
                for (int j = 0; j < ny - 1; j++)
                {
                    Cuadrilatero(vx[i, j], vy[i, j],
                        vx[i + 1, j], vy[i + 1, j],
                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                        vx[i, j + 1], vy[i, j + 1], grafico, 0);
                }

            }



        }
        public void EncenderSuperOnda(Bitmap grafico, double tp)
        {


            double x, y, z, dx, dy, dz, z1 = 0, v = 9.3, d, d1;
            double z2;
            double w = 1.5, w2 = 2;
            Vector3D V3D = new Vector3D();
            Vector3D W3D = new Vector3D();



            cx = 0;
            x = -12;
            dx = Math.PI / 10;
            do
            {
                cy = 0;
                y = -10;
                dy = Math.PI / 10;
                do
                {
                    d = Math.Sqrt(Math.Pow((x + 4), 2) + (y * y));
                    double k = w * (d - tp * v);
                    z1 = Math.Sin(k) + 1;

                    d1 = Math.Sqrt(Math.Pow((x - 4), 2) + (y * y));
                    double k1 = w2 * (d1 - tp * v);
                    z2 = Math.Sin(k1) + 1;
                    z = Convert.ToInt32((z1 + z2));



                    V3D.x0 = x;
                    V3D.y0 = y;
                    V3D.z0 = z;
                    Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                    Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                    V3D.c = this.c;
                    vx[cx, cy] = ax;
                    vy[cx, cy] = ay;
                    V3D.Encender3D(grafico);
                    y += dy;
                    cy += 1;
                } while (y <= 10);
                x += dx; cx += 1;
            } while (x <= 12);
            nx = cx;
            ny = cy;
            for (int i = 0; i < nx - 1; i++)
            {
                for (int j = 0; j < ny - 1; j++)
                {
                    Cuadrilatero(vx[i, j], vy[i, j],
                        vx[i + 1, j], vy[i + 1, j],
                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                        vx[i, j + 1], vy[i, j + 1], grafico, 0);
                }

            }

            x = 0;
            dx = Math.PI / 10;
            cx = 0;

            do
            {
                y = 0;
                dy = Math.PI / 10;
                cy = 0;
                do
                {
                    V3D.x0 = this.x0 + (radio + (radio1) * Math.Cos(x)) * Math.Cos(y);
                    V3D.y0 = this.y0 + (radio + (radio1) * Math.Cos(x)) * Math.Sin(y);
                    V3D.z0 = this.z0 + radio1 * Math.Sin(x) * 0.5;

                    // cModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                    Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                    vx[cx, cy] = ax;
                    vy[cx, cy] = ay;
                    y += dy;
                    cy = cy + 1;
                } while (y <= 2 * Math.PI);
                x += dx;
                cx = cx + 1;
            } while (x <= 2 * Math.PI);
            nx = cx - 2;
            ny = cy - 2;

            for (cx = 0; cx <= nx; cx++)
            {
                for (cy = 0; cy <= ny; cy++)
                {
                    Cuadrilatero(vx[cx, cy], vy[cx, cy],
                     vx[cx, cy + 1], vy[cx, cy + 1],
                     vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                     vx[cx + 1, cy], vy[cx + 1, cy], grafico, 0);
                }

            }
        }

        public void ApagarSuperOnda(Bitmap grafico, double tp)
        {


            double x, y, z, dx, dy, dz, z1 = 0, v = 9.3, d, d1;
            double z2;
            double w = 1.5, w2 = 2;
            Vector3D V3D = new Vector3D();
            Vector3D W3D = new Vector3D();



            cx = 0;
            x = -12;
            dx = Math.PI / 10;
            do
            {
                cy = 0;
                y = -10;
                dy = Math.PI / 10;
                do
                {
                    d = Math.Sqrt(Math.Pow((x + 4), 2) + (y * y));
                    double k = w * (d - tp * v);
                    z1 = Math.Sin(k) + 1;

                    d1 = Math.Sqrt(Math.Pow((x - 4), 2) + (y * y));
                    double k1 = w2 * (d1 - tp * v);
                    z2 = Math.Sin(k1) + 1;
                    z = Convert.ToInt32((z1 + z2));



                    V3D.x0 = x;
                    V3D.y0 = y;
                    V3D.z0 = z;
                    Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                    Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                    V3D.c = this.c;
                    vx[cx, cy] = ax;
                    vy[cx, cy] = ay;
                    V3D.Encender3D(grafico);
                    y += dy;
                    cy += 1;
                } while (y <= 10);
                x += dx; cx += 1;
            } while (x <= 12);
            nx = cx;
            ny = cy;
            for (int i = 0; i < nx - 1; i++)
            {
                for (int j = 0; j < ny - 1; j++)
                {
                    Cuadrilatero(vx[i, j], vy[i, j],
                        vx[i + 1, j], vy[i + 1, j],
                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                        vx[i, j + 1], vy[i, j + 1], grafico, 3);
                }

            }
            x = 0;
            dx = Math.PI / 10;
            cx = 0;

            do
            {
                y = 0;
                dy = Math.PI / 10;
                cy = 0;
                do
                {
                    V3D.x0 = this.x0 + (radio + (radio1) * Math.Cos(x)) * Math.Cos(y);
                    V3D.y0 = this.y0 + (radio + (radio1) * Math.Cos(x)) * Math.Sin(y);
                    V3D.z0 = this.z0 + radio1 * Math.Sin(x) * 0.5;

                    // cModelosMat.Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                    Axionometria(W3D.x0, W3D.y0, W3D.z0, out ax, out ay);
                    vx[cx, cy] = ax;
                    vy[cx, cy] = ay;
                    y += dy;
                    cy = cy + 1;
                } while (y <= 2 * Math.PI);
                x += dx;
                cx = cx + 1;
            } while (x <= 2 * Math.PI);
            nx = cx - 2;
            ny = cy - 2;

            for (cx = 0; cx <= nx; cx++)
            {
                for (cy = 0; cy <= ny; cy++)
                {
                    Cuadrilatero(vx[cx, cy], vy[cx, cy],
                     vx[cx, cy + 1], vy[cx, cy + 1],
                     vx[cx + 1, cy + 1], vy[cx + 1, cy + 1],
                     vx[cx + 1, cy], vy[cx + 1, cy], grafico, 3);
                }

            }


        }
        public void EncenderSuperOndaJugiens(Bitmap grafico, double tp)
        {


            double x, y, z, dx, dy, dz, z1 = 0, v = 9.3, d, d1;
            double z2;
            double w = 1.5, w2 = 2;
            Vector3D V3D = new Vector3D();
            Vector3D W3D = new Vector3D();



            cx = 0;
            x = -12;
            dx = Math.PI / 10;
            do
            {
                cy = 0;
                y = -10;
                dy = Math.PI / 10;
                do
                {
                    z2 = 0;
                    for (int m = 0; m < 10; m++)
                    {


                        d = Math.Sqrt(Math.Pow((x - 10 + m), 2) + Math.Pow((y - 2), 2));
                        double k = w * (d - tp * v);
                        z1 = z1+Math.Sin(k) ;
                        //z2 = (z2 + z1) % 15;
                    }

                    V3D.x0 = x;
                    V3D.y0 = y;
                    V3D.z0 =Math.Sin( z1);
                    Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                    Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                    V3D.c = this.c;
                    vx[cx, cy] = ax;
                    vy[cx, cy] = ay;
                    V3D.Encender3D(grafico);
                    y += dy;
                    cy += 1;
                } while (y <= 10);
                x += dx; cx += 1;
            } while (x <= 12);
            nx = cx;
            ny = cy;
            for (int i = 0; i < nx - 1; i++)
            {
                for (int j = 0; j < ny - 1; j++)
                {
                    Cuadrilatero(vx[i, j], vy[i, j],
                        vx[i + 1, j], vy[i + 1, j],
                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                        vx[i, j + 1], vy[i, j + 1], grafico, 0);
                }

            }
        }
        public void ApagarSuperOndaJugiens(Bitmap grafico, double tp)
        {


            double x, y, z, dx, dy, dz, z1 = 0, v = 9.3, d, d1;
            double z2;
            double w = 1.5, w2 = 2;
            Vector3D V3D = new Vector3D();
            Vector3D W3D = new Vector3D();



            cx = 0;
            x = -12;
            dx = Math.PI / 10;
            do
            {
                cy = 0;
                y = -10;
                dy = Math.PI / 10;
                do
                {
                    z2 = 0;
                    for (int m = 0; m < 10; m++)
                    {


                        d = Math.Sqrt(Math.Pow((x - 10 + m), 2) + Math.Pow((y - 2), 2));
                        double k = w * (d - tp * v);
                        z1 = z1 + Math.Sin(k);
                        //z2 = (z2 + z1) % 15;
                    }

                    V3D.x0 = x;
                    V3D.y0 = y;
                    V3D.z0 = Math.Sin(z1);
                    Rotar(V3D.x0, V3D.y0, V3D.z0, gama, eje, out W3D.x0, out W3D.y0, out W3D.z0);
                    Axionometria(V3D.x0, V3D.y0, V3D.z0, out ax, out ay);
                    V3D.c = this.c;
                    vx[cx, cy] = ax;
                    vy[cx, cy] = ay;
                    V3D.Encender3D(grafico);
                    y += dy;
                    cy += 1;
                } while (y <= 10);
                x += dx; cx += 1;
            } while (x <= 12);
            nx = cx;
            ny = cy;
            for (int i = 0; i < nx - 1; i++)
            {
                for (int j = 0; j < ny - 1; j++)
                {
                    Cuadrilatero(vx[i, j], vy[i, j],
                        vx[i + 1, j], vy[i + 1, j],
                        vx[i + 1, j + 1], vy[i + 1, j + 1],
                        vx[i, j + 1], vy[i, j + 1], grafico, 3);
                }

            }
        }
        

        





}
}