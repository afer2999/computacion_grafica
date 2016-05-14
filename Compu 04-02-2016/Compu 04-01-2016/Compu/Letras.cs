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
    class Letras: Circuenferencia
    {
        public Letras() { }
        public Letras(double x, double y, double r, Color c, Bitmap gra, PictureBox view, int tp)
        {
            this.x0 = x;
            this.y0 = y;
            this.radio = r;
            this.c = c;
            tipo = tp;
            grafico = gra;
            ViewPort = view;
        }
        public override void Encender()
        {
            double t = 0;
            double dt = 0.001;
            Vector vc = new Vector(0, 0, c, grafico, ViewPort);
            Segmento sg = new Segmento(0, 0, 0, 0, c, grafico, ViewPort, 0);
            switch (tipo)
            {
                //teta
                case 0:
                    {
                        sg.x0 = x0 - radio;
                        sg.y0 = y0;
                        sg.xf = x0 + radio;
                        sg.yf = y0;
                        sg.c = c;
                        sg.Encender();
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + 1.4 * radio * Math.Sin(t);
                            vc.c = c;
                            vc.Encender();
                            t += dt;
                        } while (t <= 2 * Math.PI);

                    } break;
                //A
                case 1:
                    {
                        Segmento SegmentoT = new Segmento(0, 0, 0, 0, c, grafico, ViewPort,0);
                        this.radio = this.radio + (this.radio);


                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos((50 * Math.PI) / 180);
                        SegmentoT.y0 = y0;
                        SegmentoT.xf = this.x0 - this.radio * Math.Cos((50 * Math.PI) / 180);
                        SegmentoT.yf = y0;
                        SegmentoT.Encender();


                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos(Math.PI / 2);
                        SegmentoT.y0 = this.y0 + this.radio * Math.Sin(Math.PI / 2);
                        SegmentoT.xf = this.x0 + this.radio * Math.Cos((210 * Math.PI) / 180);
                        SegmentoT.yf = this.y0 + this.radio * Math.Sin((210 * Math.PI) / 180);
                        SegmentoT.Encender();

                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos((330 * Math.PI) / 180);
                        SegmentoT.y0 = this.y0 + this.radio * Math.Sin((330 * Math.PI) / 180);
                        SegmentoT.xf = this.x0 + this.radio * Math.Cos(Math.PI / 2);
                        SegmentoT.yf = this.y0 + this.radio * Math.Sin(Math.PI / 2);
                        SegmentoT.Encender();

                    } break;
                //a
                case 2:
                    {
                        t = (45 * Math.PI) / 180; dt = 0.001;
                        //v.c = this.c;
                        while (t <= (315 * Math.PI) / 180)
                        {
                            vc.x0 = this.x0 + this.radio * Math.Cos(t);
                            vc.y0 = this.y0 + this.radio * Math.Sin(t);
                            vc.Encender();
                            t += dt;
                        }
                        sg.x0 = this.x0 + this.radio * Math.Cos((45 * Math.PI) / 180);
                        sg.y0 = this.y0 + this.radio;
                        sg.xf = this.x0 + this.radio * Math.Cos((45 * Math.PI) / 180);
                        sg.yf = this.y0 - this.radio;
                        //p.c = this.c;
                        sg.Encender();

                    } break;
                //B
                case 3:
                    {
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos((2 * (Math.PI / 3)) - 0.3)), (y0 - radio), (x0 + radio * Math.Cos((2 * (Math.PI / 3)) - 0.3)), (y0 + (radio * 3)), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t) * 1.5);
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (2 * (Math.PI / 3)) - 0.35);
                        t = (4 * Math.PI / 3) + 0.4;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t) * 1.5);
                            vector.y0 = y0 + (radio * Math.Sin(t));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);
                        t = 0;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + 2 * radio) + (radio * Math.Sin(t));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (2 * (Math.PI / 3)) - 0.3);
                        t = 4 * Math.PI / 3 + 0.3;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + 2 * radio) + (radio * Math.Sin(t));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);
                        /*Segmento segmento = new Segmento((x0 + radio * Math.Cos((2 * (Math.PI / 3)) - 0.3)), (y0 - radio), (x0 + radio * Math.Cos((2 * (Math.PI / 3)) - 0.3)), (y0 + (radio * 3)), c, grafico, ViewPort,0);
                        segmento.Encender();
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t)*1.5);
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (2 * (Math.PI / 3)) - 0.3);
                        t = (4 * Math.PI / 3) + 0.3;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t) * 1.5);
                            vector.y0 = y0 + (radio * Math.Sin(t));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);
                        t = 0;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + 2 * radio) + (radio * Math.Sin(t));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (2 * (Math.PI / 3)) - 0.3);
                        t = 4 * Math.PI / 3 + 0.3;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + 2 * radio) + (radio * Math.Sin(t));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);*/

                    } break;
                //b
                case 4:
                    {
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos(3 * Math.PI / 4)), (y0 - radio), (x0 + radio * Math.Cos(3 * Math.PI / 4)), (y0 + (radio * 2)), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= 3 * (Math.PI / 4));
                        t = 5 * Math.PI / 4;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);

                    } break;
                //D
                case 5:
                    {
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos((120 * Math.PI) / 180)), (y0 - radio * Math.Sin((120 * Math.PI) / 180)), (x0 + radio * Math.Cos((120 * Math.PI) / 180)), (y0 + radio * Math.Sin((120 * Math.PI) / 180)), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (120*Math.PI)/180);
                        t = (240 * Math.PI) / 180;
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);

                    } break;
                //d
                case 6:
                    {
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos(Math.PI / 4)), (y0 - radio), (x0 + radio * Math.Cos(Math.PI / 4)), (y0 + (radio * 2)), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        t = Math.PI / 4;
                        segmento.Encender();
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (7 * Math.PI / 4));

                        } break;
                //E
                case 7:
                    {
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 + radio), (x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 - radio), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        Segmento segmento1 = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 + radio), (x0 + radio * Math.Cos(Math.PI / 3)), (y0 + radio), c, grafico, ViewPort, 0);
                        segmento1.Encender();
                        Segmento segmento2 = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 - radio), (x0 + radio * Math.Cos(Math.PI / 3)), (y0 - radio), c, grafico, ViewPort, 0);
                        segmento2.Encender();
                        //double xm
                        Segmento segmento3 = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0), (x0 + radio * Math.Cos(Math.PI / 3)), (y0), c, grafico, ViewPort, 0);
                        segmento3.Encender();

                    } break;
                //e
                case 8:
                    {
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
                        double posicionX = x0 + radio;
                        double posicionY = y0;
                        double posicionYF = x0 + radio * (Math.PI);
                        Segmento segmento = new Segmento(posicionX, posicionY, posicionX - (radio * 2), posicionY, c, grafico, ViewPort, 0);
                        segmento.Encender();
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (3 * (Math.PI) / 2) + (Math.PI) / 4);

                    } break;
                //F
                case 9:
                    {
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 + radio), (x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 - radio), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        Segmento segmento1 = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 + radio), (x0 + radio * Math.Cos(Math.PI / 3)), (y0 + radio), c, grafico, ViewPort, 0);
                        segmento1.Encender();
                        
                        Segmento segmento3 = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0), (x0 + radio * Math.Cos(Math.PI / 3)), (y0), c, grafico, ViewPort, 0);
                        segmento3.Encender();

                    } break;
                //f
                case 10:
                    {
                       t = Math.PI / 3;
                       Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            v.x0 = x0 + radio * Math.Cos(t);
                            v.y0 = y0 + radio * Math.Sin(t);
                            v.Encender();
                            t = t + dt;

                        } while (t <= 5 * Math.PI / 6);

                        Segmento segmento = new Segmento((x0 + radio * Math.Cos(5 * Math.PI / 6)), (y0 + radio * Math.Sin(5 * Math.PI / 6)), (x0 + radio * Math.Cos(5 * Math.PI / 6)), (y0 - radio * 2), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        Segmento segmento3 = new Segmento((x0 + radio * Math.Cos(5 * Math.PI / 6)), (y0 - radio / 2), (x0 + radio * Math.Cos(Math.PI / 3)), (y0 - radio / 2), c, grafico, ViewPort, 0);
                        segmento3.Encender();

                    } break;
                    ///G
                case 11:
                    {
                        t = Math.PI / 4;
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
                        do
                        {
                            vector.x0 = x0 + radio * Math.Cos(t);
                            vector.y0 = y0 + radio * Math.Sin(t);
                            vector.Encender();
                            t = t + dt;

                        } while (t <= 7 * Math.PI / 4);
                        Segmento s = new Segmento(x0 + radio * Math.Cos(Math.PI / 4), y0, x0 + radio * Math.Cos(Math.PI / 4), y0 - radio * Math.Sin(Math.PI / 4), c, grafico, ViewPort, 0);
                        s.Encender();
                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(Math.PI / 4), y0, x0 + radio * 0.2, y0, c, grafico, ViewPort, 0);
                        s1.Encender();

                    } break;
                ///g
                case 12:
                    {
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);
                        t = Math.PI / 6;
                        do
                        {
                            vector.x0 = x0 + radio * Math.Cos(t);
                            vector.y0 = y0 + radio * Math.Sin(t);
                            vector.Encender();
                            t = t + dt;

                        } while (t <= 11 * Math.PI / 6);
                        Segmento s = new Segmento(x0 + radio * Math.Cos(Math.PI / 6), y0 + radio * 0.8, x0 + radio * Math.Cos(Math.PI / 6), y0 - radio * 1.5, c, grafico, ViewPort, 0);
                        s.Encender();
                        t = 7 * Math.PI / 6;
                        do
                        {
                            vector.x0 = x0 + radio * Math.Cos(t);
                            vector.y0 = y0 - radio + (radio) * Math.Sin(t);
                            vector.Encender();
                            t = t + dt;

                        } while (t <= 330 * Math.PI / 180);

                    } break;
                ///H
                case 13:
                    {
                        Segmento s = new Segmento(x0 + radio * Math.Cos(50 * Math.PI / 180), y0 + radio * Math.Sin(50 * Math.PI / 180), x0 + radio * Math.Cos(50 * Math.PI / 180), y0 - radio * Math.Sin(50 * Math.PI / 180), c, grafico, ViewPort,0);
                        s.Encender();
                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(130 * Math.PI / 180), y0 + radio * Math.Sin(130 * Math.PI / 180), x0 + radio * Math.Cos(130 * Math.PI / 180), y0 - radio * Math.Sin(130 * Math.PI / 180), c, grafico, ViewPort,0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(130 * Math.PI / 180), y0, x0 + radio * Math.Cos(50 * Math.PI / 180), y0, c, grafico, ViewPort, 0);
                        s2.Encender();

                    } break;
                ///h
                case 14:
                    {
                        t = 40 * Math.PI / 180;
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            v.x0 = x0 + radio * Math.Cos(t);
                            v.y0 = y0 + radio * Math.Sin(t);
                            v.Encender();
                            t = t + dt;
                        } while (t <= (140 * Math.PI / 180));

                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio * 2.5, x0 + radio * Math.Cos(140 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio * Math.Sin(40 * Math.PI / 180), x0 + radio * Math.Cos(40 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s2.Encender();

                    } break;
                ///I
                case 15:
                    {
                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(50 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(130 * Math.PI / 180), y0 + radio, c, grafico, ViewPort, 0);
                        s2.Encender();
                        Segmento s3 = new Segmento(x0 + radio * Math.Cos(310 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(230 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s3.Encender();

                    } break;
                ///i
                case 16:
                    {
                        t = 0;
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            v.x0 = x0 + radio / 3 * Math.Cos(t);
                            v.y0 = y0 + radio / 3 * Math.Sin(t);
                            v.Encender();
                            t = t + dt;
                        } while (t <= (360 * Math.PI / 180));

                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(90 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 - radio * 6, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio * Math.Sin(40 * Math.PI / 180), x0 + radio * Math.Cos(40 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        //s2.Encender();

                    } break;
                    ////J
                case 17:
                    {
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        t = 220 * Math.PI / 180;

                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(50 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(50 * Math.PI / 180), y0 - radio * 4 + radio * 0.2, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(0 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s2.Encender();

                        do
                        {
                            v.x0 = x0 + radio * Math.Cos(t);
                            v.y0 = y0 - radio * 3 + (radio) * Math.Sin(t);
                            v.Encender();
                            t = t + dt;

                        } while (t <= 310 * Math.PI / 180);

                    } break;
                ////j
                case 18:
                    {
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        t = 0;
                        do
                        {
                            v.x0 = x0 + radio / 3 * Math.Cos(t) + radio * Math.Cos(50 * Math.PI / 180);
                            v.y0 = y0 + radio / 3 * Math.Sin(t);
                            v.Encender();
                            t = t + dt;
                        } while (t <= (360 * Math.PI / 180));

                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(50 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(50 * Math.PI / 180), y0 - radio * 4 + radio * 0.2, c, grafico, ViewPort, 0);
                        s1.Encender();
                        t = 200 * Math.PI / 180;
                        do
                        {
                            v.x0 = x0 + radio * Math.Cos(t);
                            v.y0 = y0 - radio * 3 + (radio) * Math.Sin(t);
                            v.Encender();
                            t = t + dt;

                        } while (t <= 310 * Math.PI / 180);

                    } break;
                ////K
                case 19:
                    {
                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(140 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0, x0 + radio * Math.Cos(80 * Math.PI / 180), y0 + radio, c, grafico, ViewPort, 0);
                        s2.Encender();
                        Segmento s3 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0, x0 + radio * Math.Cos(280 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s3.Encender();
                    } break;
                ////k
                case 20:
                    {
                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(140 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0, x0 + radio / 2 * Math.Cos(60 * Math.PI / 180), y0 + radio * Math.Sin(40 * Math.PI / 180), c, grafico, ViewPort, 0);
                        s2.Encender();
                        Segmento s3 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0, x0 + radio * Math.Cos(300 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s3.Encender();
                    } break;
                ////L
                case 21:
                    {
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 + radio), (x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 - radio), c, grafico, ViewPort, 0);
                        segmento.Encender();
                        Segmento segmento2 = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 - radio), (x0 + radio * Math.Cos(Math.PI / 3)), (y0 - radio), c, grafico, ViewPort, 0);
                        segmento2.Encender();  
                    } break;
                ////l
                case 22:
                    {
                        Segmento segmento = new Segmento((x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 + radio), (x0 + radio * Math.Cos(2 * Math.PI / 3)), (y0 - radio), c, grafico, ViewPort, 0);
                        segmento.Encender();
                    } break;
                    ////M
                case 23:
                    {
                        Segmento SegmentoT = new Segmento(0, 0, 0, 0, c, grafico, ViewPort, 0);
                        this.radio = this.radio + (this.radio);
                        this.radio = this.radio / 2;

                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos(150 * Math.PI / 180);
                        SegmentoT.y0 = this.y0 + this.radio * Math.Sin(150 * Math.PI / 180);
                        SegmentoT.xf = this.x0 + this.radio * Math.Cos((270 * Math.PI) / 180);
                        SegmentoT.yf = this.y0 + this.radio * Math.Sin((270 * Math.PI) / 180);
                        SegmentoT.Encender();

                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos(270 * Math.PI / 180);
                        SegmentoT.y0 = this.y0 + this.radio * Math.Sin(270 * Math.PI / 180);
                        SegmentoT.xf = this.x0 + this.radio * Math.Cos((30 * Math.PI) / 180);
                        SegmentoT.yf = this.y0 + this.radio * Math.Sin((30 * Math.PI) / 180);
                        SegmentoT.Encender();

                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos((150 * Math.PI) / 180);
                        SegmentoT.y0 = this.y0 + this.radio * Math.Sin((150 * Math.PI) / 180);
                        SegmentoT.xf = this.x0 + this.radio * Math.Cos((150 * Math.PI) / 180);
                        SegmentoT.yf = this.y0 - this.radio * 2;
                        SegmentoT.Encender();

                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos((30 * Math.PI) / 180);
                        SegmentoT.y0 = this.y0 + this.radio * Math.Sin((30 * Math.PI) / 180);
                        SegmentoT.xf = this.x0 + this.radio * Math.Cos((30 * Math.PI) / 180);
                        SegmentoT.yf = this.y0 - this.radio * 2;
                        SegmentoT.Encender();
                    } break;
                ////m
                case 24:
                    {
                        t = 0;
                        this.radio = this.radio / 2;
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);

                        while (t <= Math.PI)
                        {
                            v.x0 = this.x0 + this.radio * Math.Cos(t);
                            v.y0 = this.y0 + this.radio * Math.Sin(t);
                            v.Encender();
                            t += dt;
                        }
                        Segmento sm = new Segmento(0, 0, 0, 0, c, grafico, ViewPort,0);

                        sm.x0 = this.x0 + this.radio;
                        sm.y0 = this.y0;
                        sm.xf = this.x0 + this.radio;
                        sm.yf = this.y0 - this.radio;
                        sm.Encender();
                        sm.x0 = this.x0 - this.radio;
                        sm.y0 = this.y0 + this.radio;
                        sm.xf = this.x0 - this.radio;
                        sm.yf = this.y0 - this.radio;
                        sm.Encender();
                        this.x0 = this.x0 + this.radio * 2;
                        t = 0;
                        while (t <= Math.PI)
                        {
                            v.x0 = this.x0 + this.radio * Math.Cos(t);
                            v.y0 = this.y0 + this.radio * Math.Sin(t);
                            v.Encender();
                            t += dt;
                        }


                        sm.x0 = this.x0 + this.radio;
                        sm.y0 = this.y0;
                        sm.xf = this.x0 + this.radio;
                        sm.yf = this.y0 - this.radio;
                        sm.Encender();
                        sm.x0 = this.x0 - this.radio;
                        sm.y0 = this.y0;
                        sm.xf = this.x0 - this.radio;
                        sm.yf = this.y0 - this.radio;
                        sm.Encender();
                    } break;
                ////N
                case 25:
                    {
                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(140 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(320 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s2.Encender();
                        Segmento s3 = new Segmento(x0 + radio * Math.Cos(320 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(320 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s3.Encender();
                    } break;
                ////n
                case 26:
                    {
                        t = 40 * Math.PI / 180;
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            v.x0 = x0 + radio * Math.Cos(t);
                            v.y0 = y0 + radio * Math.Sin(t);
                            v.Encender();
                            t = t + dt;
                        } while (t <= (140 * Math.PI / 180));

                        Segmento s1 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(140 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s1.Encender();
                        Segmento s2 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio * Math.Sin(40 * Math.PI / 180), x0 + radio * Math.Cos(40 * Math.PI / 180), y0 - radio, c, grafico, ViewPort, 0);
                        s2.Encender();
                    } break;
                ////O
                case 27:
                    {
                        t = 0;
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            v.x0 = x0 + (radio * 0.8) * Math.Cos(t);
                            v.y0 = y0 + radio * Math.Sin(t);
                            v.Encender();
                            t = t + dt;
                        } while (t <= 360 * Math.PI / 180);
                    } break;
                ////C
                case 28:
                    {
                        t = (Math.PI) / 4;
                        Vector vector = new Vector(0, 0, c, grafico, ViewPort);
                        double posicionX = x0 + (radio * Math.Cos(t));
                        double posicionY = y0 + radio;
                        //cSegmento segmento = new cSegmento(posicionX, posicionY, posicionX, posicionY - 2 * Radio, color0, bit, lienzo);
                        //segmento.Encender();
                        do
                        {
                            vector.x0 = x0 + (radio * Math.Cos(t));
                            vector.y0 = (y0 + (radio * Math.Sin(t)));
                            vector.Encender();
                            t = t + dt;
                        } while (t <= (3 * (Math.PI) / 2) + (Math.PI) / 4);
                    } break;
                //p
                case 32:
                    {
                        t = 0;
                        sg.x0 = x0 + radio * Math.Cos((120 * Math.PI) / 180);
                        sg.y0 = y0 - 2 * radio;
                        sg.xf = x0 + radio * Math.Cos((120 * Math.PI) / 180);
                        sg.yf = y0 + radio;
                        sg.c = c;
                        sg.Encender();
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.c = c;
                            vc.Encender();
                            t += dt;
                        } while (t <= (120*Math.PI)/180);
                        t = (240 * Math.PI) / 180;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.c = c;
                            vc.Encender();
                            t += dt;
                        } while (t <= (360 * Math.PI) / 180);
                    } break;
                //q
                case 34:
                    {
                        t = Math.PI / 4;
                        sg.x0 = x0 + radio * Math.Cos(Math.PI / 4);
                        sg.y0 = y0 - 2 * radio;
                        sg.xf = x0 + radio * Math.Cos(Math.PI / 4);
                        sg.yf = y0 + radio;
                        sg.c = c;
                        sg.Encender();
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.c = c;
                            vc.Encender();
                            t += dt;
                        } while (t <= ((2 * Math.PI) - (Math.PI / 4)));
                    } break;
                //letra t
                case 40:
                    {
                        t = (200 * Math.PI) / 180;
                        sg.x0 = x0 + radio * Math.Cos((200 * Math.PI) / 180);
                        sg.y0 = y0 + radio * Math.Sin((200 * Math.PI) / 180);
                        sg.xf = x0 + radio * Math.Cos((200 * Math.PI) / 180);
                        sg.yf = y0 + 2 * radio;
                        sg.c = c;
                        sg.Encender();
                        sg.x0 = x0;
                        sg.y0 = y0 + radio;
                        sg.xf = x0 - radio - radio / 2;
                        sg.yf = y0 + radio;
                        sg.c = c;
                        sg.Encender();
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.c = c;
                            vc.Encender();
                            t += dt;
                        } while (t <= (330 * Math.PI) / 180);
                    } break;
            }
        }
        //Letras
        /*
         public void letraQ()
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
        do
        {
            v.x0 = x0 + (radio * 0.8) * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
        Segmento s = new Segmento(x0-radio*0.8*Math.Cos(90*Math.PI/180),y0-radio/2,x0+radio*0.8*Math.Cos(0*Math.PI/180),y0-radio,c,ViewPort,grafico);
        s.Encender();
    }
    public void letrar()
    {
        double t = 90*Math.PI/180, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
        do
        {
            v.x0 = x0 + radio * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 140 * Math.PI / 180);
        Segmento s = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(140 * Math.PI / 180), y0 - radio*0.5, c, ViewPort, grafico);
        s.Encender();
    }
    public void letraR()
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
        do
        {
            v.x0 = x0 + radio * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 110 * Math.PI / 180);
        t = 250*Math.PI/180;
        do
        {
            v.x0 = x0 + radio  * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
        Segmento s = new Segmento(x0 + radio* Math.Cos(110 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(110 * Math.PI / 180), y0 - radio*3, c, ViewPort, grafico);
        s.Encender();
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(110 * Math.PI / 180), y0 - radio*0.9, x0 + radio * Math.Cos(360 * Math.PI / 180), y0 - radio * 3, c, ViewPort, grafico);
        s1.Encender();
    }
    public void letraT()
    {
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(50 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(130 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        s2.Encender();
    }
    public void letraV()
    {
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(30 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(270 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(150 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(270 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s2.Encender();
    }
    public void letraW()
    {
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(300 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(240 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s2.Encender();
        Segmento s3 = new Segmento(x0 + radio * Math.Cos(240 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        s3.Encender();
        Segmento s4 = new Segmento(x0 + radio * Math.Cos(300 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        s4.Encender();
    }
    public void letraX()
    {
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(220 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(320 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s2.Encender();
        Segmento s3 = new Segmento(x0 + radio * Math.Cos(240 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        //s3.Encender();
        Segmento s4 = new Segmento(x0 + radio * Math.Cos(300 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
       // s4.Encender();
    }
    public void letray()
    {
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(220 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0+radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0, c, ViewPort, grafico);
        s2.Encender();
        Segmento s3 = new Segmento(x0 + radio * Math.Cos(240 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        //s3.Encender();
        Segmento s4 = new Segmento(x0 + radio * Math.Cos(300 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        //s4.Encender();
    }
    public void letraY()
    {
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(140 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0, c, ViewPort, grafico);
        s2.Encender();
        Segmento s3 = new Segmento(x0 + radio * Math.Cos(90 * Math.PI / 180), y0, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s3.Encender();
        Segmento s4 = new Segmento(x0 + radio * Math.Cos(300 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        //s4.Encender();
    }
    public void letraZ()
    {
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(140 * Math.PI / 180), y0+radio, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 + radio, x0 + radio * Math.Cos(220 * Math.PI / 180), y0-radio, c, ViewPort, grafico);
        s2.Encender();
        Segmento s3 = new Segmento(x0 + radio * Math.Cos(40 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(220 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s3.Encender();
        Segmento s4 = new Segmento(x0 + radio * Math.Cos(300 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio, c, ViewPort, grafico);
        //s4.Encender();
    }
         *  public void EncenderP( )
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0,0,c,ViewPort,grafico);
        //v.c = this.c;
        while (t <= 2 * Math.PI)
        {
            v.x0 = (this.x0 + this.radio * Math.Cos(t));
            v.y0 = this.y0 + this.radio * Math.Sin(t);
            if ((t <= (90 * Math.PI / 180) && t >= 0) || (t <= (2 * Math.PI) && t >= (270 * Math.PI / 180)))
            {
                v.Encender();
            }
            t += dt;
        }
        Segmento seg = new Segmento(0,0,0,0,c,ViewPort,grafico);

        seg.x0 = this.x0;
        seg.y0 = this.y0 + this.radio;
        seg.xf = this.x0;
        seg.yf = this.y0 - 2 * this.radio;
        seg.Encender();
    }
         * 
       public void EncenderS( )
    {
        double t = ((45 * Math.PI) / 180), dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
      
        while (t <= (270 * Math.PI) / 180)
        {
            v.x0 = (this.x0 + this.radio * Math.Cos(t));
            v.y0 = this.y0 + this.radio * Math.Sin(t);
            v.Encender();

            t += dt;
        }
        t = 0;
        this.y0 = this.y0 - this.radio * 0.5 - this.radio - this.radio;
        this.radio = this.radio + this.radio * 0.5;
        while (t <= 2 * Math.PI)
        {
            v.x0 = this.x0 + this.radio * Math.Cos(t);
            v.y0 = this.y0 + this.radio * Math.Sin(t);
            if ((t <= (90 * Math.PI / 180) && t >= 0) || (t <= (2 * Math.PI) && t >= (225 * Math.PI / 180)))
            {
                v.Encender();
            }
            t += dt;
        }

    }
    public void EncenderU()
    {
        double t = Math.PI, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
      
        while (t <= 2 * Math.PI)
        {
            v.x0 = this.x0 + this.radio * Math.Cos(t);
            v.y0 = this.y0 + this.radio * Math.Sin(t);
            v.Encender();
            t += dt;
        }
        Segmento s = new Segmento(0, 0, 0, 0, c, ViewPort, grafico);
        s.xf = this.x0 + this.radio * Math.Cos(Math.PI);
        s.yf = (this.y0 + this.radio * Math.Sin(Math.PI)) + this.radio * 2;
        s.x0 = this.x0 + this.radio * Math.Cos(Math.PI);
        s.y0 = this.y0 + this.radio * Math.Sin(Math.PI);
      
        s.Encender();

        Segmento s1 = new Segmento(0, 0, 0, 0, c, ViewPort, grafico);
        s1.xf = this.x0 + this.radio * Math.Cos(0);
        s1.yf = (this.y0 + this.radio * Math.Sin(0));
        s1.x0 = this.x0 + this.radio * Math.Cos(0);
        s1.y0 = (this.y0 + this.radio * Math.Sin(0)) + this.radio * 2;
       
        s1.Encender();
         }
    public void numero0()
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0,0,c,ViewPort,grafico);
        do
        {
            v.x0 = x0 + radio*0.6 * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        }while(t<=360*Math.PI/180);
    }
    public void numero1()
    {
        Segmento s = new Segmento(x0+radio*Math.Cos(120*Math.PI/180),y0+radio*Math.Sin(120*Math.PI/180),x0+radio*Math.Cos(90*Math.PI/180),y0+radio,c,ViewPort,grafico);
        s.Encender();
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(90 * Math.PI / 180), y0 + radio,x0 + radio * Math.Cos(90 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(120 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(60 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s2.Encender();
    }
    public void numero2()
    {
        double t = 20*Math.PI/180; dt = 0.001;
        Vector v = new Vector(0,0,c,ViewPort,grafico);
        do
        {
            v.x0 = x0 + radio * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        }while(t<=160*Math.PI/180);
        Segmento s = new Segmento(x0 + radio * Math.Cos(20 * Math.PI / 180), y0+radio*Math.Sin(20*Math.PI/180) , x0 + radio * Math.Cos(180 * Math.PI / 180), y0-radio, c, ViewPort, grafico);
        s.Encender();
        Segmento s2 = new Segmento(x0 + radio * Math.Cos(20 * Math.PI / 180), y0 - radio, x0 + radio * Math.Cos(160 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s2.Encender();
    }
    public void numero3()
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
        do
        {
            v.x0 = x0 + radio* Math.Cos(t);
            v.y0 = y0+ radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 100 * Math.PI / 180);
        t = 240 * Math.PI / 180;
        do
        {
            v.x0 = x0 + radio * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
        t = 0;
        do
        {
            v.x0 = x0 + radio* Math.Cos(t);
            v.y0 = y0+radio*2 +radio* Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 120 * Math.PI / 180);
        t = 260 * Math.PI / 180;
        do
        {
            v.x0 = x0 + radio* Math.Cos(t);
            v.y0 = y0+radio*2 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
          
    }
    public void numero4()
    {
        Segmento s = new Segmento(x0+radio*Math.Cos(90*Math.PI/180),y0+radio,x0+radio*Math.Cos(180*Math.PI/180),y0,c,ViewPort,grafico);
        s.Encender();
        Segmento s1 = new Segmento(x0+radio*Math.Cos(180*Math.PI/180),y0,x0+radio*0.3,y0,c,ViewPort,grafico);
        s1.Encender();
        Segmento s2 = new Segmento(x0+radio*Math.Cos(90*Math.PI/180),y0+radio,x0+radio*Math.Cos(90*Math.PI/180),y0-radio*0.7,c,ViewPort,grafico);
        s2.Encender();
    }
    public void numero5()
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
        do
        {
            v.x0 = x0 + radio * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 110 * Math.PI / 180);
        t = 250 * Math.PI / 180;
        do
        {
            v.x0 = x0 + radio * Math.Cos(t);
            v.y0 = y0 + radio * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
        Segmento s = new Segmento(x0 + radio * Math.Cos(110 * Math.PI / 180), y0 + radio*2, x0 + radio * Math.Cos(360 * Math.PI / 180), y0+radio*2, c, ViewPort, grafico);
        s.Encender();
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(110 * Math.PI / 180), y0 + radio*2, x0 + radio * Math.Cos(110 * Math.PI / 180), y0+ radio* Math.Sin(110 * Math.PI / 180), c, ViewPort, grafico);
        s1.Encender();
         
    }
    public void numero6()
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
        do
        {
            v.x0 = x0 + radio*0.8 * Math.Cos(t);
            v.y0 = y0 + radio*0.8 * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
        t = 70 * Math.PI / 180;
        do
        {
            v.x0 = x0+radio*0.2 + radio * Math.Cos(t);
            v.y0 = y0 + radio*2 * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 180 * Math.PI / 180);
    }
    public void numero7()
    {
        Segmento s = new Segmento(x0 + radio * Math.Cos(50 * Math.PI / 180), y0 + radio * Math.Sin(50 * Math.PI / 180), x0 + radio * Math.Cos(130 * Math.PI / 180), y0 + radio * Math.Sin(130 * Math.PI / 180), c, ViewPort, grafico);
        s.Encender();
        Segmento s1 = new Segmento(x0 + radio * Math.Cos(50 * Math.PI / 180), y0 + radio * Math.Sin(50 * Math.PI / 180), x0 + radio * Math.Cos(230 * Math.PI / 180), y0 - radio, c, ViewPort, grafico);
        s1.Encender();
    }
    public void numero9()
    {
        double t = 0, dt = 0.001;
        Vector v = new Vector(0, 0, c, ViewPort, grafico);
        do
        {
            v.x0 = x0 + radio * 0.8 * Math.Cos(t);
            v.y0 = y0 + radio * 0.8 * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
        t = 250 * Math.PI / 180;
        do
        {
            v.x0 = x0 - radio * 0.2 + radio * Math.Cos(t);
            v.y0 = y0 + radio * 2 * Math.Sin(t);
            v.Encender();
            t = t + dt;
        } while (t <= 360 * Math.PI / 180);
    }
         */
    }
}
