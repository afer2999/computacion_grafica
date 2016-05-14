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
    class Circuenferencia : Vector
    {
        public double radio;
        public int tipo;
        public double t1cos;
        public double t1sen, alfa;

        public Circuenferencia() { }
        public Circuenferencia(double x, double y, double r, Color c,Bitmap gra, PictureBox view,int tp)
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
            switch(tipo)
            {
                    ///encender circunferencia
                case 0:
                    {

                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.Encender();
                            t += dt;
                        } while (t <= 2 * Math.PI);
                    } break;
                    ///encender interpolacion
                case 1:
                    {
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.c = Color.FromArgb(
                Convert.ToInt32((0 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (5 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((255 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (0 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((0 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (0 * (t - 0) / ((2 * Math.PI) - 0))));
                            vc.Encender();
                            t += dt;
                        } while (t <= 2 * Math.PI);
                    }break;
                    //circunferencia entrecortada
                case 2:
                    {
                        double contador = 0;
                        do
                        {
                            vc.x0 = x0 + radio * Math.Cos(t);
                            vc.y0 = y0 + radio * Math.Sin(t);
                            vc.c = this.c;
                            if (contador % 25 == 0)
                            {
                                vc.Encender();
                            }
                            t += dt;
                            contador += 1;
                        } while (t <= 2 * Math.PI);
                    }break;
                    //circunferencia llena
                case 3:
                    {
                        do
                        {
                            for (double i = 0; i < radio; i += 0.02)
                            {
                                vc.x0 = x0 + i * Math.Cos(t);
                                vc.y0 = y0 + i * Math.Sin(t);
                                vc.c = this.c;
                                vc.Encender();
                            }
                            t += dt;
                        } while (t <= 2 * Math.PI);
                    }break;
                case 4:
                    {
                        double t1 = 0, dt1 = 0.003;
                        Vector seg = new Vector(0, 0, c, grafico, ViewPort);//aki quede los parametros
                        do
                        {

                            seg.x0 = x0 + (radio) * Math.Cos(t1cos * t1);
                            seg.y0 = y0 + (radio) * Math.Sin(t1sen * t1);
                            seg.Encender();
                            t1 = t1 + dt1;
                        } while (t1 <= 2 * Math.PI);
                    } break;
                case 5:
                    {
                        t = 0;
                        dt = 0.001;
                        Vector vl = new Vector(0, 0, c, grafico, ViewPort);
                        Vector W = new Vector(0, 0, c, grafico, ViewPort);
                        do
                        {
                            vl.x0 = x0 + Math.Sin(t1sen * t) * radio;
                            vl.y0 = y0 + Math.Cos(t1cos * t) * radio;
                            Rotar(vl.x0, vl.y0, x0, y0, alfa, out W.x0, out W.y0);
                            W.Encender();
                            t += dt;
                        } while (t <= 2 * Math.PI);
                    } break;
                    //circunferencia dentro de triangulo equilatero
                case 6:
                    {
                        t = 0;
                        double m1, m2, lx, px, py, m3, m4, lx1, px1, py1, m5, m6, lx2, px2, py2,y2,y1;
                        dt = 0.001;
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        v.c = this.c;
                        while (t <= 2 * Math.PI)
                        {
                            v.x0 = this.x0 + this.radio * Math.Cos(t);
                            v.y0 = this.y0 + this.radio * Math.Sin(t);

                            v.Encender();
                            t += dt;
                        }

                        Segmento SegmentoT = new Segmento(0, 0, 0, 0, c, grafico, ViewPort, 0);
                        Segmento SegmentoT1 = new Segmento(0, 0, 0, 0, c, grafico, ViewPort, 0);
                        Segmento SegmentoT2 = new Segmento(0, 0, 0, 0, c, grafico, ViewPort, 0);
                        this.radio = this.radio + (this.radio);//para que lacircunferencia este dentro del triangulo
                        //SegmentoT.c = Color.Blue;
                        SegmentoT.x0 = this.x0 + this.radio * Math.Cos(Math.PI / 2);
                        SegmentoT.y0 = this.y0 + this.radio * Math.Sin(Math.PI / 2);
                        SegmentoT.xf = this.x0 + this.radio * Math.Cos((210 * Math.PI) / 180);
                        SegmentoT.yf = this.y0 + this.radio * Math.Sin((210 * Math.PI) / 180);
                        SegmentoT.Encender();

                        //SegmentoT1.c = Color.Red;
                        SegmentoT1.x0 = this.x0 + this.radio * Math.Cos((210 * Math.PI) / 180);
                        SegmentoT1.y0 = this.y0 + this.radio * Math.Sin((210 * Math.PI) / 180);
                        SegmentoT1.xf = this.x0 + this.radio * Math.Cos((330 * Math.PI) / 180);
                        SegmentoT1.yf = this.y0 + this.radio * Math.Sin((330 * Math.PI) / 180);
                        SegmentoT1.Encender();

                        //SegmentoT2.c = Color.Green;
                        SegmentoT2.x0 = this.x0 + this.radio * Math.Cos((330 * Math.PI) / 180);
                        SegmentoT2.y0 = this.y0 + this.radio * Math.Sin((330 * Math.PI) / 180);
                        SegmentoT2.xf = this.x0 + this.radio * Math.Cos(Math.PI / 2);
                        SegmentoT2.yf = this.y0 + this.radio * Math.Sin(Math.PI / 2);
                        SegmentoT2.Encender();

                        Vector linea = new Vector(0, 0, c, grafico, ViewPort);

                        m1 = (SegmentoT.yf - SegmentoT.y0) / (SegmentoT.xf - SegmentoT.x0);
                        m2 = -(1 / m1);

                        px = ((SegmentoT.x0 + SegmentoT.xf) / 2);
                        py = ((SegmentoT.y0 + SegmentoT.yf) / 2);

                        SegmentoT.segmento2(px,py,m2,out y1, out y2);
                        SegmentoT.x0 = -15;
                        SegmentoT.y0 = y1;
                        SegmentoT.xf = 15;
                        SegmentoT.yf = y2;
                        SegmentoT.c = Color.Red;
                        SegmentoT.Encender();

                        m3 = (SegmentoT1.yf - SegmentoT1.y0) / (SegmentoT1.xf - SegmentoT1.x0);
                        m4 = -(1 / m3);

                        px1 = ((SegmentoT1.x0 + SegmentoT1.xf) / 2);
                        py1 = ((SegmentoT1.y0 + SegmentoT1.yf) / 2);

                        SegmentoT1.segmento2(px1, py1, m4, out y1, out y2);
                        SegmentoT1.x0 = -15;
                        SegmentoT1.y0 = y1;
                        SegmentoT1.xf = 15;
                        SegmentoT1.yf = y2;
                        SegmentoT1.c = Color.Red;
                        SegmentoT1.Encender();

                        m5 = (SegmentoT2.yf - SegmentoT2.y0) / (SegmentoT2.xf - SegmentoT2.x0);
                        m6 = -(1 / m5);


                        px2 = ((SegmentoT2.x0 + SegmentoT2.xf) / 2);
                        py2 = ((SegmentoT2.y0 + SegmentoT2.yf) / 2);

                        SegmentoT.segmento2(px2, py2, m6, out y1, out y2);
                        SegmentoT.x0 = -15;
                        SegmentoT.y0 = y1;
                        SegmentoT.xf = 15;
                        SegmentoT.yf = y2;
                        SegmentoT.c = Color.Red;
                        SegmentoT.Encender();

                       /* if (m3 > 0 || m3 < 0 || m3 == 0)
                        {
                            for (double j = -50; j < 50; j = j + 0.002)
                            {
                                lx1 = ((j - py1) / m4 + px1);

                                if (lx1 > -50 && lx1 < 50)
                                {
                                    linea.x0 = lx1;
                                    linea.y0 = j;
                                    linea.c = Color.Violet;
                                    linea.Encender();

                                }
                            }

                        }*/

                      
                    }break;
                case 7:
                    {
                        t = 0; dt = 0.001;
                        double m1, m2, lx, px, py, m3, m4, lx1, px1, py1, m5, m6, lx2, px2, py2, y2, y1;
                        Vector v = new Vector(0, 0, c, grafico, ViewPort);
                        v.c = this.c;
                        while (t <= 2 * Math.PI)
                        {
                            v.x0 = this.x0 + this.radio * Math.Cos(t);
                            v.y0 = this.y0 + this.radio * Math.Sin(t);
                            v.Encender();
                            t += dt;
                        }

                        Segmento SegmentoT = new Segmento(0,0,0, 0, c, grafico, ViewPort,0);
                        // this.r = this.r + (this.r);
                        SegmentoT.c = this.c;
                        SegmentoT.x0 = this.x0 - this.radio;
                        SegmentoT.y0 = this.y0 - this.radio;
                        SegmentoT.xf = this.x0 + this.radio * 3;
                        SegmentoT.yf = this.y0 - this.radio;
                        SegmentoT.Encender();
                        m1 = (SegmentoT.yf - SegmentoT.y0) / (SegmentoT.xf - SegmentoT.x0);
                        m2 = -(1 / m1);

                        px = ((SegmentoT.x0 + SegmentoT.xf) / 2);
                        py = ((SegmentoT.y0 + SegmentoT.yf) / 2);

                        SegmentoT.segmento2(px, py, m2, out y1, out y2);
                        SegmentoT.x0 = -15;
                        SegmentoT.y0 = y1;
                        SegmentoT.xf = 15;
                        SegmentoT.yf = y2;
                        SegmentoT.c = Color.Red;
                        SegmentoT.Encender();

                        SegmentoT.x0 = this.x0 - this.radio;
                        SegmentoT.y0 = this.y0 - this.radio;
                        SegmentoT.xf = this.x0 - this.radio;
                        SegmentoT.yf = this.y0 + this.radio * 2;
                        SegmentoT.c = this.c;
                        SegmentoT.Encender();
                        m3 = (SegmentoT.yf - SegmentoT.y0) / (SegmentoT.xf - SegmentoT.x0);
                        m4 = -(1 / m3);

                        px1 = ((SegmentoT.x0 + SegmentoT.xf) / 2);
                        py1 = ((SegmentoT.y0 + SegmentoT.yf) / 2);

                        SegmentoT.segmento2(px1, py1, m4, out y1, out y2);
                        SegmentoT.x0 = -15;
                        SegmentoT.y0 = y1;
                        SegmentoT.xf = 15;
                        SegmentoT.yf = y2;
                        SegmentoT.c = Color.Red;
                        SegmentoT.Encender();

                        SegmentoT.x0 = this.x0 + this.radio * 3;
                        SegmentoT.y0 = this.y0 - this.radio;
                        SegmentoT.xf = this.x0 - this.radio;
                        SegmentoT.yf = this.y0 + this.radio * 2;
                        SegmentoT.c = this.c;
                        SegmentoT.Encender();
                        m5 = (SegmentoT.yf - SegmentoT.y0) / (SegmentoT.xf - SegmentoT.x0);
                        m6 = -(1 / m5);


                        px2 = ((SegmentoT.x0 + SegmentoT.xf) / 2);
                        py2 = ((SegmentoT.y0 + SegmentoT.yf) / 2);

                        SegmentoT.segmento2(px2, py2, m6, out y1, out y2);
                        SegmentoT.x0 = -15;
                        SegmentoT.y0 = y1;
                        SegmentoT.xf = 15;
                        SegmentoT.yf = y2;
                        SegmentoT.c = Color.Red;
                        SegmentoT.Encender();
                    }break;
            }
            
        }

    }
}
