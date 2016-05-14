using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Grupo_5
{
    class cCurva
    {
        int tipo;
        Vector V;
        double radio;
        Color color;
        Bitmap grafico;
        PictureBox ViewPort;
        double alfa = Math.PI / 2;

        public double Alfa
        {
            get { return alfa; }
            set { alfa = value; }
        }
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public double Radio
        {
            get { return radio; }
            set { radio = value; }
        }
        internal Vector V1
        {
            get { return V; }
            set { V = value; }
        }
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public cCurva() { }


        public cCurva(int tipo, double radio, Vector V, Color color)
        {
            this.tipo = tipo;
            this.radio = radio;
            this.V = V;
            this.color = color;
           
        }

        public cCurva(int tipo, double radio, Vector V, Color color, double alfa, PictureBox nViewPort, Bitmap nGrafico)
        {
            this.tipo = tipo;
            this.radio = radio;
            this.V = V;
            this.color = color;
            this.alfa = alfa;
            this.grafico = nGrafico;
            this.ViewPort = nViewPort;
        }

        public void pCurvaVOn()
        {
            double t = 0;
            double dt = 0.001;
            Vector vec = new Vector(0, 0,color,ViewPort,grafico);
            Vector w = new Vector(0, 0, color, ViewPort, grafico);
            LibreriaMat obj = new LibreriaMat();
            switch (Tipo)
            {
                case 1: //Laso
                    do
                    {
                        vec.X0 = V.X0 + (Radio * Math.Cos(3 * t));
                        vec.Y0 = V.Y0 + (Radio * Math.Sin(2 * t));
                        //w = obj.pRotar(vec.X, vec.Y, alfa, color);
                        //w.pVectorOn(mapa);
                        vec.Encender();
                        t = t + dt;
                    }
                    while (t <= (2 * Math.PI));
                    break;
                case 2://Churo
                    do
                    {
                        vec.X0 = V.X0 + Radio * (Math.Pow(Math.Sin(t), 3));
                        vec.Y0 = V.Y0 + Radio * (Math.Pow(Math.Cos(t), 3));
                        vec.Encender();
                        t = t + dt;
                    }
                    while (t <= (2 * Math.PI));
                    break;
                case 3://Espiral
                    do
                    {
                        vec.X0 = V.X0 + Radio * ((t / 10) * Math.Cos(t));
                        vec.Y0 = V.Y0 + Radio * ((t / 10) * Math.Sin(t));
                        vec.Encender();
                        t = t + dt;
                    }
                    while (t <= (8 * Math.PI));
                    break;
                case 4://Margarita
                    do
                    {
                        vec.X0 = V.X0 + Radio * (0.7 * Math.Cos(6 * t) * Math.Cos(t));
                        vec.Y0 = V.Y0 + Radio * (0.7 * Math.Cos(6 * t) * Math.Sin(t));
                        vec.Encender();
                        t = t + dt;
                    }
                    while (t <= (2 * Math.PI));
                    break;
                case 5: //Rotar1
                    do
                    {
                        vec.X0 = V.X0 + (Radio * Math.Sin(2 * t));
                        vec.Y0 = V.Y0 + (Radio * Math.Cos(3 * t));
                        w = obj.pRotar(vec.X0, vec.Y0, alfa, color, ViewPort, grafico);
                        w.Encender();
                        t = t + dt;
                    }
                    while (t <= (2 * Math.PI));
                    break;
                case 6: //Rotar2
                    do
                    {
                        vec.X0 = V.X0 + Radio *Math.Sin(2 * t);
                        vec.Y0 = V.Y0 + Radio * Math.Cos(3 * t);
                        w = obj.pRotar2(vec.X0, vec.Y0, alfa, V.X0, V.Y0, color,ViewPort,grafico);//aquí nada más debíamos enviar
                        w.Encender();
                        t = t + dt;
                    }
                    while (t <= (2 * Math.PI));
                    break;
            }
        }
        public virtual void apagar(Color col)
        {
            color = col;
            pCurvaVOn();
        }
    }
}
