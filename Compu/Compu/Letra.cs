using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compu
{
    class Letra : Vector
    {
        public double Radio;
        double dt = 0.0001;
        //constructor
        public Letra(double nX0, double nY0, double nRadio, Color nColor0, Bitmap nGrafico, PictureBox nViewPort)
            : base(nX0, nY0, nColor0, nGrafico, nViewPort)
        {
            x0 = nX0;
            y0 = nY0;
            Radio = nRadio;
            c = nColor0;
            ViewPort = nViewPort;
            grafico = nGrafico;
        }

        //destructor
        ~Letra()
        { }
        //procesos
        
        public override void Encender()
        {
            Vector vec = new Vector(0, 0, c, grafico, ViewPort);
            double t = 0;
            double posicionX = x0 + Radio;
            Segmento segmento = new Segmento(posicionX, y0, posicionX - 2 * Radio, y0, c, grafico, ViewPort,0);
            segmento.Encender();
            do
            {
                vec.x0 = Radio * Math.Cos(t) + x0;
                vec.y0 = 1.2 *( Radio * Math.Sin(t)) + y0;
                vec.Encender();
                t += dt;
            } while (t <= (Math.PI * 2));
        }
        public  void letrat()
        {
            double t = Math.PI;
            Vector vec = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            do
            {
                vec.x0 = x0 + (Radio) * Math.Cos(t);
                vec.y0 = y0 + (Radio) * Math.Sin(t);
                vec.Encender();
                t = t + dt;
            } while (t <= 2* Math.PI );

            double posicionX = x0 + (Radio * Math.Cos(Math.PI)); //toma el valor para x 135 grados
            double posicionY = y0 + (Radio * Math.Sin(Math.PI));
            double posicionXF = x0 + (Radio * Math.Cos(Math.PI)); // toma el valor para x 225 grados
            double posicionYF = y0 + 2 * Radio + (Radio * Math.Sin(Math.PI)); //toma la posicion para x y la duplica el radio y baja 
            Segmento segmentoVertical = new Segmento(posicionX, posicionY, posicionXF, posicionYF, c, grafico, ViewPort,0);
            segmentoVertical.Encender();

            posicionX = x0 - 2 * Radio; //Desde 2R<--0 
            posicionY = y0 + Radio + (Radio * Math.Sin(Math.PI));
            posicionXF = x0; //Punto 0
            posicionYF = y0 + Radio + (Radio * Math.Sin(Math.PI));
            Segmento segmentoHorizontal = new Segmento(posicionX, posicionY, posicionXF, posicionYF, c,grafico,ViewPort,0);
            segmentoHorizontal.Encender();

        }

        public void casa()
        {
            //double t = -3.25, dt = 0.003;
            Vector seg = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento seg1 = new Segmento(x0, y0, x0, y0, c, grafico, ViewPort, 0);
            Segmento seg2 = new Segmento(5 + x0, y0, x0, y0, c, grafico, ViewPort, 0);
            Segmento seg3 = new Segmento(x0, y0, x0 + 5, y0, c, grafico, ViewPort, 0);
            Segmento seg4 = new Segmento(x0, y0, x0, y0 + 5, c, grafico, ViewPort, 0);
                seg1.Encender();
                seg2.Encender();
                seg3.Encender();
                seg4.Encender();
           
        }
        /// </summary>

        public void letras()
        {
            double dt=0.001;
            double t = Math.PI/5;
            Vector seg = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            do
            {
                seg.x0 = x0 + (Radio * Math.Cos(t));
                seg.y0 = y0 + (Radio * Math.Sin(t));
                seg.Encender();
                t = t + dt;
         } while (t <= (1 * 6 ) - (Math.PI/3));
        }

        public void letras2()
        {
            double dt = 0.001;
            double t = Math.PI / 3;
            Vector seg = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            do
            {
                seg.x0 = x0 + (Radio * Math.Cos(t));
                seg.y0 = y0 + (Radio * Math.Sin(t));
                seg.Encender();
                t = t + dt;
              } while (t <= (1 * 6) - (Math.PI / 8));
            }
        public void letrad1()
        {

            double t = Math.PI / 4;
            double dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento segmento = new Segmento((x0 + (Radio * Math.Cos(7 * Math.PI / 4))), (y0 + (Radio * Math.Sin(3 * Math.PI / 2))), (x0 + (Radio * Math.Cos(7 * Math.PI / 4))), ((y0 + (Radio * Math.Sin(3 * Math.PI / 2))) + 4 * Radio), c, grafico, ViewPort, 0);
            segmento.Encender();
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= (7 * Math.PI / 4));
         }
        public void letrad()
        {

            double t = Math.PI / 4;
            double dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento segmento = new Segmento((x0 + Radio * Math.Cos(Math.PI / 4)), (y0 - Radio), (x0 + Radio * Math.Cos(Math.PI / 4)), (y0 + (Radio * 2)), c, grafico, ViewPort,0);
            segmento.Encender();
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= (7 * Math.PI / 4));
        }
        public void letrab()
        {

            double t =0;
            double dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento segmento = new Segmento((x0 + Radio * Math.Cos(3 * Math.PI / 4)), (y0 - Radio), (x0 + Radio * Math.Cos(3 * Math.PI / 4)), (y0 + (Radio * 2)), c, grafico, ViewPort, 0);
            segmento.Encender();
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= 3*(Math.PI / 4));
            t = 5*Math.PI/4;
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= 2*Math.PI);
        }
        public void letraB()
        {

            double t = 0;
            double dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento segmento = new Segmento((x0 + Radio * Math.Cos((2 * (Math.PI / 3)) - 0.3)), (y0 - Radio), (x0 + Radio * Math.Cos((2 * (Math.PI / 3)) - 0.3)), (y0 + (Radio * 3)), c, grafico, ViewPort, 0);
            segmento.Encender();
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= (2 * (Math.PI / 3))-0.3);
            t = (4 * Math.PI / 3)+0.3;
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = y0 + (Radio * Math.Sin(t));
                vector.Encender();
                t = t + dt;
            } while (t <= 2 * Math.PI);
            t = 0;
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0+2*Radio) + (Radio * Math.Sin(t));
                vector.Encender();
                t = t + dt;
            } while (t <= (2 * (Math.PI / 3))-0.3);
            t = 4 * Math.PI / 3+0.3;
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0+2*Radio) + (Radio * Math.Sin(t));
                vector.Encender();
                t = t + dt;
            } while (t <= 2 * Math.PI);
        }
        public void letraminuscula_c()
        {
            double t = (Math.PI) / 4;
            double dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);
            double posicionX = x0 + (Radio * Math.Cos(t));
            double posicionY = y0 + Radio;
            //cSegmento segmento = new cSegmento(posicionX, posicionY, posicionX, posicionY - 2 * Radio, color0, bit, lienzo);
            //segmento.Encender();
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= (3 * (Math.PI) / 2) + (Math.PI) / 4);
        }
        public void letraD()
        {

            double t = 0;
            double dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento segmento = new Segmento((x0 + Radio * Math.Cos(Math.PI / 2)), (y0 - Radio), (x0 + Radio * Math.Cos(Math.PI / 2)), (y0 + (Radio)), c, grafico, ViewPort,0);
            segmento.Encender();
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= (Math.PI / 2));
            t = 3 * Math.PI / 2;
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= 2 * Math.PI);
        }
        public void letraminuscula_e()
        {
            double t = 0;
            double dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);
            double posicionX = x0 + Radio;
            double posicionY = y0;
            double posicionYF = x0 + Radio * (Math.PI);
            Segmento segmento = new Segmento(posicionX, posicionY, posicionX - (Radio * 2), posicionY, c, grafico, ViewPort, 0);
            segmento.Encender();
            do
            {
                vector.x0 = x0 + (Radio * Math.Cos(t));
                vector.y0 = (y0 + (Radio * Math.Sin(t)));
                vector.Encender();
                t = t + dt;
            } while (t <= (3 * (Math.PI) / 2) + (Math.PI) / 4);
        }
        public void letraE()
        {


            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento segmento = new Segmento((x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0 + Radio), (x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0 - Radio), c, grafico, ViewPort, 0);
            segmento.Encender();
            Segmento segmento1 = new Segmento((x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0 + Radio), (x0 + Radio * Math.Cos(Math.PI / 3)), (y0 + Radio), c, grafico, ViewPort, 0);
            segmento1.Encender();
            Segmento segmento2 = new Segmento((x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0 - Radio), (x0 + Radio * Math.Cos(Math.PI / 3)), (y0 - Radio), c, grafico, ViewPort, 0);
            segmento2.Encender();
            //double xm
            Segmento segmento3 = new Segmento((x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0), (x0 + Radio * Math.Cos(Math.PI / 3)), (y0), c, grafico, ViewPort, 0);
            segmento3.Encender();
        }
        public void letraf()
        {

            double t = Math.PI/3, dt = 0.001;
            Vector v = new Vector(0, 0, c, grafico, ViewPort);
            do
            {
                v.x0 = x0 + Radio * Math.Cos(t);
                v.y0 = y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;

            }while(t<=5*Math.PI/6);

            Segmento segmento = new Segmento((x0 + Radio * Math.Cos(5 * Math.PI / 6)), (y0 + Radio * Math.Sin(5 * Math.PI / 6)), (x0 + Radio * Math.Cos(5 * Math.PI / 6)), (y0 - Radio * 2), c, grafico, ViewPort, 0);
            segmento.Encender();
            Segmento segmento3 = new Segmento((x0 + Radio * Math.Cos(5 * Math.PI / 6)), (y0 - Radio / 2), (x0 + Radio * Math.Cos(Math.PI / 3)), (y0 - Radio / 2), c, grafico, ViewPort, 0);
            segmento3.Encender();
        }
        public void letraF()
        {


            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            Segmento segmento = new Segmento((x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0 + Radio), (x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0 - Radio), c, grafico, ViewPort, 0);
            segmento.Encender();
            Segmento segmento1 = new Segmento((x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0 + Radio), (x0 + Radio * Math.Cos(Math.PI / 3)), (y0 + Radio), c, grafico, ViewPort, 0);
            segmento1.Encender();
           
            //double xm
            Segmento segmento3 = new Segmento((x0 + Radio * Math.Cos(2 * Math.PI / 3)), (y0), (x0 + Radio * Math.Cos(Math.PI / 3)), (y0), c, grafico, ViewPort, 0);
            segmento3.Encender();
        }
        public void letrag()
        {

            double t = Math.PI/6, dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            do
            {
                vector.x0 = x0 + Radio * Math.Cos(t);
                vector.y0 = y0 + Radio * Math.Sin(t);
                vector.Encender();
                t = t + dt;

            }while(t<=11*Math.PI/6);
            Segmento s = new Segmento(x0 + Radio * Math.Cos(Math.PI / 6), y0 + Radio * 0.8, x0 + Radio * Math.Cos(Math.PI / 6), y0 - Radio * 1.5, c, grafico, ViewPort, 0);
            s.Encender();
            t = 7*Math.PI/6;
            do
            {
                vector.x0 = x0 + Radio * Math.Cos(t);
                vector.y0 = y0-Radio + (Radio) * Math.Sin(t);
                vector.Encender();
                t = t + dt;

            }while(t<=330*Math.PI/180);
           
           
        }
        public void letra9()
        {

            double t = Math.PI / 6, dt = 0.001;
            Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
            do
            {
                vector.x0 = x0 + Radio * Math.Cos(t);
                vector.y0 = y0 + Radio * Math.Sin(t);
                vector.Encender();
                t = t + dt;

            } while (t <= 11 * Math.PI / 6);
            Segmento s = new Segmento(x0 + Radio * Math.Cos(Math.PI / 6), y0 + Radio * Math.Sin(Math.PI / 6), x0 + Radio * Math.Cos(Math.PI / 6), y0 - Radio * 1.5, c, grafico, ViewPort, 0);
            s.Encender();
            t = 7 * Math.PI / 6;
            do
            {
                vector.x0 = x0 + Radio * Math.Cos(t);
                vector.y0 = y0 - Radio + (Radio) * Math.Sin(t);
                vector.Encender();
                t = t + dt;

            } while (t <= 330 * Math.PI / 180);


        }
        /*public void letraG()
        {

            double t = Math.PI / 4, dt = 0.001;
            Vector vector = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            do
            {
                vector.X0 = X0 + Radio * Math.Cos(t);
                vector.Y0 = Y0 + Radio * Math.Sin(t);
                vector.Encender();
                t = t + dt;

            } while (t <= 7 * Math.PI / 4);
            Segmento s = new Segmento(X0 + Radio * Math.Cos(Math.PI / 4), Y0, X0 + Radio * Math.Cos(Math.PI / 4), Y0 - Radio * Math.Sin(Math.PI / 4), Color0, ViewPort, Grafico);
            s.Encender();
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(Math.PI / 4), Y0 , X0 + Radio * 0.2, Y0 , Color0, ViewPort, Grafico);
            s1.Encender();
        }
        public void letraH()
        {


            Segmento s = new Segmento(X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 + Radio * Math.Sin(50 * Math.PI / 180), X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 - Radio * Math.Sin(50 * Math.PI / 180), Color0, ViewPort, Grafico);
            s.Encender();
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(130 * Math.PI / 180), Y0 + Radio * Math.Sin(130 * Math.PI / 180), X0 + Radio * Math.Cos(130 * Math.PI / 180), Y0 - Radio * Math.Sin(130 * Math.PI / 180), Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(130 * Math.PI / 180), Y0, X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0, Color0, ViewPort, Grafico);
            s2.Encender();
        }
        public void letrah()
        {
            double t = 40*Math.PI/180, dt = 0.001;
            Vector v = new Vector(0,0,Color0,ViewPort,Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            }while(t<=(140*Math.PI/180));
            
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio*2.5, X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 - Radio , Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio * Math.Sin(40 * Math.PI / 180), X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
        }
        public void letrai()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio/3 * Math.Cos(t);
                v.Y0 = Y0 + Radio/3 * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= (360 * Math.PI / 180));

            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 -Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 - Radio*6, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio * Math.Sin(40 * Math.PI / 180), X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            //s2.Encender();
        }
        public void letraI()
        {
           

            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio , X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 + Radio , X0 + Radio * Math.Cos(130 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(310 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(230 * Math.PI / 180), Y0 - Radio , Color0, ViewPort, Grafico);
            s3.Encender();
        }
        public void letraj()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio / 3 * Math.Cos(t) + Radio * Math.Cos(50 * Math.PI / 180);
                v.Y0 = Y0 + Radio/3 * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= (360 * Math.PI / 180));

            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 - Radio * 4 + Radio * 0.2, Color0, ViewPort, Grafico);
            s1.Encender();
            t = 200*Math.PI/180;
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 - Radio*3 + (Radio) * Math.Sin(t);
                v.Encender();
                t = t + dt;

            } while (t <= 310 * Math.PI / 180);
            
        }
        public void letraJ()
        {
            double t = 220 * Math.PI / 180, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);

            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 - Radio * 4 + Radio * 0.2, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(0 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
           
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 - Radio * 3 + (Radio) * Math.Sin(t);
                v.Encender();
                t = t + dt;

            } while (t <= 310 * Math.PI / 180);
            
        }
        public void letrak()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 - Radio , Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0, X0 + Radio/2 * Math.Cos(60 * Math.PI / 180), Y0+Radio*Math.Sin(40 * Math.PI / 180), Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0, X0 + Radio * Math.Cos(300 * Math.PI / 180), Y0 - Radio , Color0, ViewPort, Grafico);
            s3.Encender();

         
        }
        public void letraK()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0, X0 + Radio * Math.Cos(80 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0, X0 + Radio * Math.Cos(280 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s3.Encender();


        }
        public void letraL()
        {
            Vector vector = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            Segmento segmento = new Segmento((X0 + Radio * Math.Cos(2 * Math.PI / 3)), (Y0 + Radio), (X0 + Radio * Math.Cos(2 * Math.PI / 3)), (Y0 - Radio), Color0, ViewPort, Grafico);
            segmento.Encender();
            Segmento segmento2 = new Segmento((X0 + Radio * Math.Cos(2 * Math.PI / 3)), (Y0 - Radio), (X0 + Radio * Math.Cos(Math.PI / 3)), (Y0 - Radio), Color0, ViewPort, Grafico);
            segmento2.Encender();  
        }
        public void letral()
        {
            Vector vector = new Vector(0, 0, Color0, ViewPort, Grafico);//aki quede los parametros
            Segmento segmento = new Segmento((X0 + Radio * Math.Cos(2 * Math.PI / 3)), (Y0 + Radio), (X0 + Radio * Math.Cos(2 * Math.PI / 3)), (Y0 - Radio), Color0, ViewPort, Grafico);
            segmento.Encender();
        }
        public void letran()
        {
            double t = 40 * Math.PI / 180, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= (140 * Math.PI / 180));

            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio * Math.Sin(40 * Math.PI / 180), X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
        }
        public void letraN()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(320 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(320 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(320 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s3.Encender();
        }
        public void letraO()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0,0,Color0,ViewPort,Grafico);
            do
            {
                v.X0 = X0 + (Radio*0.8)*Math.Cos(t);
                v.Y0 = Y0 + Radio* Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
        }
        public void letrap()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 110 * Math.PI / 180);
            t = 250*Math.PI/180;
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
            Segmento s = new Segmento(X0+Radio*Math.Cos(110*Math.PI/180),Y0+Radio,X0+Radio*Math.Cos(110*Math.PI/180),Y0-Radio*2,Color0,ViewPort,Grafico);
            s.Encender();
        }
        public void letraq()
        {
            double t = 40*Math.PI/180, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 320 * Math.PI / 180);
            Segmento s = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(40 * Math.PI / 180),Y0-Radio*2,Color0,ViewPort,Grafico);
            s.Encender();
        }
        public void letraQ()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + (Radio * 0.8) * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
            Segmento s = new Segmento(X0-Radio*0.8*Math.Cos(90*Math.PI/180),Y0-Radio/2,X0+Radio*0.8*Math.Cos(0*Math.PI/180),Y0-Radio,Color0,ViewPort,Grafico);
            s.Encender();
        }
        public void letrar()
        {
            double t = 90*Math.PI/180, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 140 * Math.PI / 180);
            Segmento s = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 - Radio*0.5, Color0, ViewPort, Grafico);
            s.Encender();
        }
        public void letraR()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 110 * Math.PI / 180);
            t = 250*Math.PI/180;
            do
            {
                v.X0 = X0 + Radio  * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
            Segmento s = new Segmento(X0 + Radio* Math.Cos(110 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(110 * Math.PI / 180), Y0 - Radio*3, Color0, ViewPort, Grafico);
            s.Encender();
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(110 * Math.PI / 180), Y0 - Radio*0.9, X0 + Radio * Math.Cos(360 * Math.PI / 180), Y0 - Radio * 3, Color0, ViewPort, Grafico);
            s1.Encender();
        }
        public void letraT()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(130 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            s2.Encender();
        }
        public void letraV()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(30 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(270 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(150 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(270 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
        }
        public void letraW()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(300 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(240 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(240 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            s3.Encender();
            Segmento s4 = new Segmento(X0 + Radio * Math.Cos(300 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            s4.Encender();
        }
        public void letraX()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(220 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(320 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(240 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            //s3.Encender();
            Segmento s4 = new Segmento(X0 + Radio * Math.Cos(300 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
           // s4.Encender();
        }
        public void letray()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(220 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0+Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(240 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            //s3.Encender();
            Segmento s4 = new Segmento(X0 + Radio * Math.Cos(300 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            //s4.Encender();
        }
        public void letraY()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s3.Encender();
            Segmento s4 = new Segmento(X0 + Radio * Math.Cos(300 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            //s4.Encender();
        }
        public void letraZ()
        {
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(140 * Math.PI / 180), Y0+Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 + Radio, X0 + Radio * Math.Cos(220 * Math.PI / 180), Y0-Radio, Color0, ViewPort, Grafico);
            s2.Encender();
            Segmento s3 = new Segmento(X0 + Radio * Math.Cos(40 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(220 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s3.Encender();
            Segmento s4 = new Segmento(X0 + Radio * Math.Cos(300 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio, Color0, ViewPort, Grafico);
            //s4.Encender();
        }
        public void numero0()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0,0,Color0,ViewPort,Grafico);
            do
            {
                v.X0 = X0 + Radio*0.6 * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            }while(t<=360*Math.PI/180);
        }
        public void numero1()
        {
            Segmento s = new Segmento(X0+Radio*Math.Cos(120*Math.PI/180),Y0+Radio*Math.Sin(120*Math.PI/180),X0+Radio*Math.Cos(90*Math.PI/180),Y0+Radio,Color0,ViewPort,Grafico);
            s.Encender();
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 + Radio,X0 + Radio * Math.Cos(90 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(120 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(60 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
        }
        public void numero2()
        {
            double t = 20*Math.PI/180; dt = 0.001;
            Vector v = new Vector(0,0,Color0,ViewPort,Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            }while(t<=160*Math.PI/180);
            Segmento s = new Segmento(X0 + Radio * Math.Cos(20 * Math.PI / 180), Y0+Radio*Math.Sin(20*Math.PI/180) , X0 + Radio * Math.Cos(180 * Math.PI / 180), Y0-Radio, Color0, ViewPort, Grafico);
            s.Encender();
            Segmento s2 = new Segmento(X0 + Radio * Math.Cos(20 * Math.PI / 180), Y0 - Radio, X0 + Radio * Math.Cos(160 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s2.Encender();
        }
        public void numero3()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio* Math.Cos(t);
                v.Y0 = Y0+ Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 100 * Math.PI / 180);
            t = 240 * Math.PI / 180;
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
            t = 0;
            do
            {
                v.X0 = X0 + Radio* Math.Cos(t);
                v.Y0 = Y0+Radio*2 +Radio* Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 120 * Math.PI / 180);
            t = 260 * Math.PI / 180;
            do
            {
                v.X0 = X0 + Radio* Math.Cos(t);
                v.Y0 = Y0+Radio*2 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
          
        }
        public void numero4()
        {
            Segmento s = new Segmento(X0+Radio*Math.Cos(90*Math.PI/180),Y0+Radio,X0+Radio*Math.Cos(180*Math.PI/180),Y0,Color0,ViewPort,Grafico);
            s.Encender();
            Segmento s1 = new Segmento(X0+Radio*Math.Cos(180*Math.PI/180),Y0,X0+Radio*0.3,Y0,Color0,ViewPort,Grafico);
            s1.Encender();
            Segmento s2 = new Segmento(X0+Radio*Math.Cos(90*Math.PI/180),Y0+Radio,X0+Radio*Math.Cos(90*Math.PI/180),Y0-Radio*0.7,Color0,ViewPort,Grafico);
            s2.Encender();
        }
        public void numero5()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 110 * Math.PI / 180);
            t = 250 * Math.PI / 180;
            do
            {
                v.X0 = X0 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
            Segmento s = new Segmento(X0 + Radio * Math.Cos(110 * Math.PI / 180), Y0 + Radio*2, X0 + Radio * Math.Cos(360 * Math.PI / 180), Y0+Radio*2, Color0, ViewPort, Grafico);
            s.Encender();
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(110 * Math.PI / 180), Y0 + Radio*2, X0 + Radio * Math.Cos(110 * Math.PI / 180), Y0+ Radio* Math.Sin(110 * Math.PI / 180), Color0, ViewPort, Grafico);
            s1.Encender();
         
        }
        public void numero6()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio*0.8 * Math.Cos(t);
                v.Y0 = Y0 + Radio*0.8 * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
            t = 70 * Math.PI / 180;
            do
            {
                v.X0 = X0+Radio*0.2 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio*2 * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 180 * Math.PI / 180);
        }
        public void numero7()
        {
            Segmento s = new Segmento(X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 + Radio * Math.Sin(50 * Math.PI / 180), X0 + Radio * Math.Cos(130 * Math.PI / 180), Y0 + Radio * Math.Sin(130 * Math.PI / 180), Color0, ViewPort, Grafico);
            s.Encender();
            Segmento s1 = new Segmento(X0 + Radio * Math.Cos(50 * Math.PI / 180), Y0 + Radio * Math.Sin(50 * Math.PI / 180), X0 + Radio * Math.Cos(230 * Math.PI / 180), Y0 - Radio, Color0, ViewPort, Grafico);
            s1.Encender();
        }
        public void numero9()
        {
            double t = 0, dt = 0.001;
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            do
            {
                v.X0 = X0 + Radio * 0.8 * Math.Cos(t);
                v.Y0 = Y0 + Radio * 0.8 * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
            t = 250 * Math.PI / 180;
            do
            {
                v.X0 = X0 - Radio * 0.2 + Radio * Math.Cos(t);
                v.Y0 = Y0 + Radio * 2 * Math.Sin(t);
                v.Encender();
                t = t + dt;
            } while (t <= 360 * Math.PI / 180);
        }*/
    }
}
