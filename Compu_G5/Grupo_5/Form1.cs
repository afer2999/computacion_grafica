using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Grupo_5
{
    public partial class Form1 : Form
    {
        //creamos una variable bitmap para poder trabajar en el picturebox
        public Bitmap Grafico;
        public Color Color0;
        double x, y;
        double x1, y1;
        double rx1;
        double ry1;
        double fy2;
        double fx2;
        double xr;
        double yr;
        double dx, dy;
        double l=30, l1=20;



        double[] vx = new double[1000];
        double[] vy = new double[1000];
        int contador;



        int Habilitado;
        int ban = 0;
        //double sx=0, sy=0,rx=0, ry=0;

        Color[] Paleta = new Color[16];

        Color[] Paleta2 = new Color[16];


        public Form1()
        {
            InitializeComponent();
            //inicializamos la variable con el tamaño de la ventana(ViewPort).
            //Es la ubicacion el pixel a visualizar de color rojo
            Grafico = new Bitmap(600, 400);
            Color0 = colorDialog1.Color;
            ViewPort.MouseDown += new MouseEventHandler(ViewPort_MouseDown);
            ViewPort.MouseUp += new MouseEventHandler(ViewPort_MouseUp);
            ViewPort.MouseMove += new MouseEventHandler(ViewPort_MouseMove);







        }
        private void ViewPort_MouseDown(object sender, MouseEventArgs e)
        {

            LibreriaMat mol = new LibreriaMat();
            mol.Carta(e.X, e.Y, out rx1, out ry1);

            

        }

        private void ViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            if (Habilitado == 1)
            {
                //Permite dibujar el segmento 
                LibreriaMat mol = new LibreriaMat();
                mol.Carta(e.X, e.Y, out fx2, out fy2);
                Segmento seg1 = new Segmento(rx1, ry1, fx2, fy2, Color0, ViewPort, Grafico);
                seg1.Encender();
            }

            if (Habilitado == 2)
            {
                LibreriaMat mol = new LibreriaMat();
                mol.Carta(e.X, e.Y, out fx2, out fy2);
                double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                cir.Radio = rad;
                cir.Encender();
            }
            if (Habilitado == 3)
            {
                LibreriaMat mol = new LibreriaMat();
                mol.Carta(e.X, e.Y, out fx2, out fy2);
                double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                Letra let = new Letra(rx1, ry1, rad, Color0, ViewPort, Grafico);

                let.Encender();
            }
            if (Habilitado == 4)
            {
                LibreriaMat mol = new LibreriaMat();
                mol.Carta(e.X, e.Y, out fx2, out fy2);
                double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                Circunferencia cirf = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                Circunferencia cir = new Circunferencia(rx1, ry1 + (rad * 0.5) + rad, rad * 0.5, Color0, ViewPort, Grafico);
                cirf.Encender();
                cir.Encender();
            }
            if (Habilitado == 5)
            {
                LibreriaMat mol = new LibreriaMat();
                mol.Carta(e.X, e.Y, out fx2, out fy2);
                double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                Letra l = new Letra(rx1, ry1, rad, Color0, ViewPort, Grafico);
                l.letrad();
                Segmento seg = new Segmento(rx1 + rad, ry1 + (2 * rad), rx1 + rad, ry1 - rad, Color0, ViewPort, Grafico);
                seg.Encender();
            }
            if (Habilitado == 6)
            {
                LibreriaMat mol = new LibreriaMat();
                mol.Carta(e.X, e.Y, out fx2, out fy2);
                double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                Letra l = new Letra(rx1, ry1, rad, Color0, ViewPort, Grafico);
                l.letrat();
            }
            if (Habilitado == 7)
            {
                LibreriaMat mol = new LibreriaMat();
                mol.Carta(e.X, e.Y, out fx2, out fy2);
                double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                double u = 0;
                double alfa;
                cCurva obj;
                Vector vec = new Vector(rx1, ry1, Color.Black, ViewPort, Grafico);
                while (u <= (Math.PI * 2))
                {
                    alfa = u;
                    obj = new cCurva(5, rad, vec, Color0, alfa, ViewPort, Grafico);
                    obj.pCurvaVOn();
                    ViewPort.Refresh();
                    ViewPort.Image = Grafico;
                    u = u + 1;
                    obj.Color = Color0;
                    obj.apagar(ViewPort.BackColor);
                    ViewPort.Image = Grafico;
                }
                obj = new cCurva(5, rad, vec, Color0, u, ViewPort, Grafico);
                obj.pCurvaVOn();
                ViewPort.Image = Grafico;
                   /* double u = 0;
                    double alfa;
                    cCurva obj;
                    Vector vec = new Vector(rx1, ry1, Color0,ViewPort,Grafico);
                    while (u <= (Math.PI * 2))
                    {
                        alfa = u;
                        //vec.X0 = rx1 + Math.Cos(u);
                       // vec.Y0 = ry1 + Math.Sin(u);
                        obj = new cCurva(5, rad, vec, Color0, alfa,ViewPort,Grafico);
                        obj.pCurvaVOn();
                        ViewPort.Image = Grafico;
                        ViewPort.Refresh();
                         u = u +1;
                         Thread.Sleep(100);
                         obj.apagar(ViewPort.BackColor);
                        ViewPort.Image = Grafico;
                    }
                    obj = new cCurva(5, rad, vec, Color0, u+1, ViewPort, Grafico);
                    obj.pCurvaVOn();
                    ViewPort.Image = Grafico;*/
                }

                if (Habilitado == 8)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    CurvaV c = new CurvaV(rx1, ry1, rad, 1, Color0, ViewPort, Grafico);
                    c.Encender();

                }
                if (Habilitado == 9)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    CurvaV c = new CurvaV(rx1, ry1, rad, 2, Color0, ViewPort, Grafico);
                    c.Encender();

                }
                if (Habilitado == 10)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    CurvaV c = new CurvaV(rx1, ry1, rad, 0, Color0, ViewPort, Grafico);
                    c.Encender();
                    CurvaV c1 = new CurvaV(rx1 + 5, ry1, rad, 1, Color0, ViewPort, Grafico);
                    c1.Encender();
                    CurvaV c2 = new CurvaV(rx1 + 10, ry1, rad, 2, Color0, ViewPort, Grafico);
                    c2.Encender();

                }
                if (Habilitado == 11)
                {
                    //Permite dibujar el segmento 
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    Segmento seg1 = new Segmento(rx1, ry1, fx2, fy2, Color0, ViewPort, Grafico);
                    seg1.Encender();
                    Segmento seg = new Segmento(100, ((-1) * (1 / ((fy2 - ry1) / (fx2 - rx1)))) * (100), (rx1 + fx2) / 2, (ry1 + fy2) / 2, Color0, ViewPort, Grafico);
                    seg.Encender();
                    Segmento segm = new Segmento(-100, ((-1) * (1 / ((fy2 - ry1) / (fx2 - rx1)))) * (-100), (rx1 + fx2) / 2, (ry1 + fy2) / 2, Color0, ViewPort, Grafico);
                    segm.Encender();
                    //Segmento seg = new Segmento((rx1 + fx2) / 2, (ry1 + fy2) / 2, 200, (-1)*((fy2-ry1)/(fx2-rx1)) , Color0, ViewPort, Grafico);
                    //seg.Encender();
                }
                if (Habilitado == 12)
                {
                    if (ban == 0)
                    {

                        LibreriaMat mol = new LibreriaMat();
                        mol.Carta(e.X, e.Y, out x, out y);
                        Segmento s = new Segmento(0, 0, x, y, Color0, ViewPort, Grafico);
                        s.Encender();
                        ban++;

                    }
                    else
                    {
                        LibreriaMat mol = new LibreriaMat();
                        mol.Carta(e.X, e.Y, out x1, out y1);
                        Segmento s1 = new Segmento(0, 0, x1, y1, Color0, ViewPort, Grafico);
                        s1.Encender();
                        Segmento ss1 = new Segmento(x, y, x + x1, y + y1, Color.Red, ViewPort, Grafico);
                        Segmento ss2 = new Segmento(x1 + x, y1 + y, x1, y1, Color.Red, ViewPort, Grafico);
                        Segmento s2 = new Segmento(x + x1, y + y1, 0, 0, Color.Green, ViewPort, Grafico);
                        s2.Encender();
                        double norma1s = Math.Abs(x + x1) + Math.Abs(y + y1);
                        double norma2s = Math.Round(Math.Sqrt((Math.Abs(x + x1) * Math.Abs(x + x1)) + (Math.Abs(y + y1) * Math.Abs(y + y1))));
                        double norma3s = Math.Max(Math.Abs(x + x1), Math.Abs(y + y1));
                        norma1.Text = norma1s.ToString();
                        norma2.Text = norma2s.ToString();
                        norma3.Text = norma3s.ToString();

                        Segmento s5 = new Segmento(x1 - x, y1 - y, 0, 0, Color.Blue, ViewPort, Grafico);
                        s5.Encender();
                        ss1.Encender1();
                        ss2.Encender1();
                        double p = x * x1 + y * y1;
                        if (p >= -0.5 && p <= 0.5)
                        {
                            MessageBox.Show("El conjunto  es ortogonal");
                            ban = 0;
                        }
                        else
                        {
                            MessageBox.Show("El conjunto no es ortogonal");
                            ban = 0;
                        }
                    }
                }
                if (Habilitado == 13)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                    cir.EncenderTrianguloCirculo();
                }
                if (Habilitado == 14)
                {
                    //Realiza el numero seis (6)
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                    cir.Radio = rad;
                    cir.encenderSeis();
                    cir.encenderSeis2();
                }
                if (Habilitado == 15)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                    cir.Radio = rad;
                    cir.encenderDos();
                    cir.encenderDos1();
                }
                if (Habilitado == 16)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                    cir.Radio = rad;
                    cir.encenderAnillo();
                }
                if (Habilitado == 17)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    Segmento seg = new Segmento(rx1, ry1, fx2, ry1, Color0, ViewPort, Grafico);
                    seg.Encender();
                    Segmento seg1 = new Segmento(rx1, ry1, (rx1 + fx2) / 2, ry1 + 2, Color0, ViewPort, Grafico);
                    seg1.Encender();
                    Segmento seg2 = new Segmento(fx2, ry1, (rx1 + fx2) / 2, ry1 + 2, Color0, ViewPort, Grafico);
                    seg2.Encender();
                    double rad = (rx1 + fx2) / 2;
                    Circunferencia cir = new Circunferencia((rx1 + fx2) / 2, ry1 + 1, rad, Color0, ViewPort, Grafico);
                    cir.Radio = rad;
                    cir.Encender();
                }
                if (Habilitado == 18)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));

                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                    cir.EncenderCuadradoCirculo();
                }
                if (Habilitado == 19)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    Poligonos pol = new Poligonos(rx1, ry1, rad, 5, Color0, ViewPort, Grafico);
                    pol.Encender();
                }

                if (Habilitado == 20)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));

                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                    cir.EncenderPentagonoCirculo();
                }
                if (Habilitado == 21)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    CurvaV c = new CurvaV(rx1, ry1, rad, 3, Color0, ViewPort, Grafico);
                    c.Encender();

                }
                if (Habilitado == 22)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));

                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color0, ViewPort, Grafico);
                    cir.EncenderInterpolacion();
                }
                if (Habilitado == 23)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));
                    Segmento cir = new Segmento(rx1, ry1, fx2, fy2, Color0, ViewPort, Grafico);
                    cir.EncenderInter();
                }
                if (Habilitado == 24)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = 0.1;
                    Circunferencia cir = new Circunferencia(rx1, ry1, rad, Color.Red, ViewPort, Grafico);
                    cir.Radio = rad;
                    cir.Encender();

                    vx[contador] = rx1;
                    vy[contador] = ry1;
                    contador++;
                }
                if (Habilitado == 25)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    double rad = Math.Sqrt(Math.Pow((rx1 - fx2), 2) + Math.Pow((ry1 - fy2), 2));

                    double u = 0;
                    double alfa;
                    cCurva obj;
                    Vector vec = new Vector(rx1, ry1, Color0, ViewPort, Grafico);
                    while (u <= (Math.PI * 2))
                    {
                        alfa = u;
                        obj = new cCurva(6, rad, vec, Color0, alfa, ViewPort, Grafico);
                        obj.pCurvaVOn();
                        ViewPort.Image = Grafico;
                        ViewPort.Refresh();
                        u = u + 1;
                        Thread.Sleep(100);
                        obj.apagar(ViewPort.BackColor);
                        ViewPort.Image = Grafico;
                    }
                    obj = new cCurva(6, rad, vec, Color0, u + 1, ViewPort, Grafico);
                    obj.pCurvaVOn();
                    ViewPort.Image = Grafico;
                }
                if (Habilitado == 26)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                   for (double i = rx1; i <= fx2; i=i+0.02)
                   {

                        Segmento s1 = new Segmento(i, ry1,i+0.02,fy2, Color0, ViewPort, Grafico);
                        //s1.Encender
                        //Thread.Sleep(10);
                        //ViewPort.Refresh();
                       s1.apagar(ViewPort.BackColor);
                        /*Segmento s2 = new Segmento( fx2, fy2,fx2,fy2+2, Color0, ViewPort, Grafico);
                        s2.apagar(ViewPort.BackColor);
                        Segmento s3 = new Segmento(rx1, ry1, rx1, ry1 + 2, Color0, ViewPort, Grafico);
                        s3.apagar(ViewPort.BackColor);
                        Segmento s4 = new Segmento(rx1, ry1+2, fx2, fy2 + 2, Color0, ViewPort, Grafico);
                        s4.apagar(ViewPort.BackColor);*/
                  }
                }

                if (Habilitado == 27)
                {
                    //Permite dibujar el segmento 
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    Segmento seg1 = new Segmento(rx1, ry1, fx2, fy2, Color0, ViewPort, Grafico);
                    seg1.Encender();
                    Segmento seg2 = new Segmento(rx1, ry1, fx2, ry1, Color0, ViewPort, Grafico);
                    seg2.Encender();
                    Segmento seg3 = new Segmento(fx2, fy2, fx2, ry1, Color0, ViewPort, Grafico);
                    seg3.Encender();
                    Segmento segm = new Segmento(-100, ((-1) * (1 / ((fy2 - ry1) / (fx2 - rx1)))) * (-100), fx2, ry1, Color0, ViewPort, Grafico);
                    segm.Encender();
                }

                if (Habilitado == 28)
                {
                    LibreriaMat mol = new LibreriaMat();
                    mol.Carta(e.X, e.Y, out fx2, out fy2);
                    l = l / 5;
                    l1 = l1 / 5;
                    Segmento seg1 = new Segmento(rx1 - l / 2, ry1 + l1 / 2, rx1 + l / 2, ry1 + l1 / 2, Color.White, ViewPort, Grafico);
                    seg1.Encender();
                    Segmento seg2 = new Segmento(rx1 - l / 2, ry1 - l1 / 2, rx1 + l / 2, ry1 - l1 / 2, Color.White, ViewPort, Grafico);
                    seg2.Encender();
                    Segmento seg3 = new Segmento(rx1 - l / 2, ry1 + l1 / 2, rx1 - l / 2, ry1 - l1 / 2, Color.White, ViewPort, Grafico);
                    seg3.Encender();
                    Segmento seg4 = new Segmento(rx1 + l / 2, ry1 + l1 / 2, rx1 + l / 2, ry1 - l1 / 2, Color.White, ViewPort, Grafico);
                    seg4.Encender();

                }

            }
        private void ViewPort_MouseMove(object sender, MouseEventArgs e)
        {
            LibreriaMat mol = new LibreriaMat();
            mol.Carta(e.X, e.Y, out fx2, out fy2);
            barra.Text = "X= " + e.Location.X.ToString() + "   Y= " + e.Location.Y.ToString()+"           " +"X = " + Math.Round(fx2, 2) + " Y= " + Math.Round(fy2, 2);
            //barra.Text = "X= " + Convert.ToDouble(e.X) + "   Y= " + Convert.ToDouble(e.Y) + " " + "Rx = " + Math.Round(e.X, 2) + " Ry= " + Math.Round(e.Y, 2);


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Habilitado = 1;
            ViewPort.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Paleta[0] = Color.Black;
            Paleta[1] = Color.Blue;
            Paleta[2] = Color.Green;
            Paleta[3] = Color.Cyan;
            Paleta[4] = Color.Red;
            Paleta[5] = Color.Magenta;
            Paleta[6] = Color.Maroon;
            Paleta[7] = Color.LightGray;
            Paleta[8] = Color.DarkGray;
            Paleta[9] = Color.Navy;
            Paleta[10] = Color.Linen;
            Paleta[11] = Color.Aqua;
            Paleta[12] = Color.Pink;
            Paleta[13] = Color.Fuchsia;
            Paleta[14] = Color.Yellow;
            Paleta[15] = Color.White;
           Paleta2 = new Color[16];
            for (int i = 0; i <= 15; i++)
            {
                Paleta2[i] = Color.FromArgb((int)(255 * (i) / (15)), (int)(255 * (i) / (15)), (int)((255 * (i - 15) / (-15))));
            }
  }
        public double factorial(double valor)
        {
            double factorial = 1;

            if (valor == 0)
                factorial = 1;

            else
                for (int i = 1; i <= valor; i++)
                {
                    factorial = factorial * i;
                }
            return (factorial);
        }  
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ViewPort.Image = null;
            Grafico = null;
            if (Grafico == null)
            {
                Grafico = new Bitmap(ViewPort.Width, ViewPort.Height);
            }
            ban = 0;
            contador = 0;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color0 = colorDialog1.Color;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Habilitado = 11;
            ViewPort.Enabled = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            double Rx = -15;
            Vector vec = new Vector(5, 3, Color0, ViewPort, Grafico);
            do
            {
                vec.X0 = Rx;
                vec.Y0 = Math.Tan(Rx / 4) * 0.3;//ondas mas altas (y*val)
                vec.Encender();
                Rx = Rx + 0.002;
            } while (Rx <= 15);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewPort.Image = null;
            Grafico = null;
            if (Grafico == null)
            {
                Grafico = new Bitmap(ViewPort.Width, ViewPort.Height);
            }
            /////
            Segmento seg1 = new Segmento(-15, 0, 15, 0, Color0, ViewPort, Grafico);
            seg1.Encender();
            Segmento seg2 = new Segmento(0, 10, 0, -10, Color0, ViewPort, Grafico);
            seg2.Encender();
            Habilitado = 12;
            ViewPort.Enabled = true;
        }
        private void btncirtriangulo_Click(object sender, EventArgs e)
        {
            Habilitado = 13;
            ViewPort.Enabled = true;

        }
        private void btnanillo_Click(object sender, EventArgs e)
        {
            Habilitado = 16;
            ViewPort.Enabled = true;
        }
        private void btncuadradocir_Click(object sender, EventArgs e)
        {
            Habilitado = 18;
            ViewPort.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Habilitado = 19;
            ViewPort.Enabled = true;
        }

        private void btnpentagono_Click(object sender, EventArgs e)
        {
            Habilitado = 20;
            ViewPort.Enabled = true;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //habilita la casa
            Habilitado = 22;
            ViewPort.Enabled = true;
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Tapete 1
            int ColorT = 0;
            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < 600; i++)
                    for (int j = 0; j < 400; j++)
                    {
                        ColorT = ((i * i) + (j * j)) % 15;
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }
            //Tapete 2
            if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        ColorT = (i * i + j * i * j) % 15;
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta2[ColorT]);
                        }

                        ViewPort.Image = Grafico;
                    }
                }
            }
            //Tapete 3
            if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < 600; i++)
                    for (int j = 0; j < 400; j++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(i) * 8) + (Math.Sin(j) * 8))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta2[ColorT]);
                        }

                    }
                ViewPort.Image = Grafico;

            }
            //Tapete 4
            if (comboBox1.SelectedIndex == 3)
            {
                for (int i = 0; i < 600; i++)
                    for (int j = 0; j < 400; j++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(i) * 9) + (Math.Sin(j) * 9))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }
            //Tapete 5
            if (comboBox1.SelectedIndex == 4)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(sx) * 15) + (Math.Sin(sy) * 15))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }

            if (comboBox1.SelectedIndex == 5)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(sx) * 16) + (Math.Sin(sy) * 16))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta2[ColorT]);
                        }

                    }
                ViewPort.Image = Grafico;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(sx) * 20) + (Math.Sin(sy) * 10))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }
            if (comboBox1.SelectedIndex == 7)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(sx) * 21) + (Math.Sin(sy) * 21))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;

            }
            if (comboBox1.SelectedIndex == 8)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(sx) * 22) + (Math.Sin(sy) * 22))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }
            if (comboBox1.SelectedIndex == 9)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(sx) * 17) + (Math.Sin(sy) * 17))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }
            if (comboBox1.SelectedIndex == 10)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Sin(sx) * 18) + (Math.Sin(sy) * 18))) % 15);
                        if (checkBox1.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                        }
                        if (checkBox2.Checked == true)
                        {
                            Grafico.SetPixel(sx, sy, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }
            if (comboBox1.SelectedIndex == 11)
            {
                for (int sx = 0; sx < 600; sx++)
                    for (int sy = 0; sy < 400; sy++)
                    {
                        ColorT = Math.Abs(((int)((Math.Cos(sx) * 19) + (Math.Sin(sy) * 19))) % 15);
                        Grafico.SetPixel(sx, sy, Paleta[ColorT]);
                    }
                ViewPort.Image = Grafico;

            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }
        private void btnLagrange_Click(object sender, EventArgs e)
        {
            //
            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);

            Segmento s = new Segmento(0, 0, 0, 0, Color0, ViewPort, Grafico);
            for (int i = 0; i < contador - 1; i++)
            {
                s.X0 = vx[i];
                s.Y0 = vy[i];
                s.XF = vx[i + 1];
                s.YF = vy[i + 1];

                double t = vx[0];
                while (t <= vx[contador - 1])
                {
                    v.X0 = t;
                    v.Y0 = LibreriaMat.Lagrange(t, vx, vy, contador);
                    v.Encender();
                    t = t + 0.01;
                }
            }
        }
        private void btnOcho_Click(object sender, EventArgs e)
        {
            //numero 8
            Habilitado = 4;
            ViewPort.Enabled = true;
        }
        private void btndos_Click(object sender, EventArgs e)
        {
            //numero 2
            Habilitado = 15;
            ViewPort.Enabled = true;
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            //escribe numero seis
            Habilitado = 14;
            ViewPort.Enabled = true;
        }
        private void tbnTheta_Click(object sender, EventArgs e)
        {
            Habilitado = 3;
            ViewPort.Enabled = true;
        }
        private void btnLetraT_Click_1(object sender, EventArgs e)
        {
            Habilitado = 6;
            ViewPort.Enabled = true;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Habilitado = 9;
            ViewPort.Enabled = true;
        }
        private void button8_Click_2(object sender, EventArgs e)
        {
            Habilitado = 7;
            ViewPort.Enabled = true;
        }

        private void btnCircunferencia_Click(object sender, EventArgs e)
        {
            Habilitado = 2;
            ViewPort.Enabled = true;
        }

        private void tbnCircufGruesa_Click(object sender, EventArgs e)
        {
            Habilitado = 16;
            ViewPort.Enabled = true;
        }
        private void btnTodas_Click(object sender, EventArgs e)
        {
            Habilitado = 10;
            ViewPort.Enabled = true;
        }
        private void button5_Click_4(object sender, EventArgs e)
        {
            Habilitado = 21;
            ViewPort.Enabled = true;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                chkLagranje.Checked = false;
                checkBox3.Checked = false;
            
            //contador = 0;
            Segmento s = new Segmento(0, 0, 0, 0, Color0, ViewPort, Grafico);
                for (int i = 0; i < contador - 1; i++)
                {
                    s.X0 = vx[i];
                    s.Y0 = vy[i];
                    s.XF = vx[i + 1];
                    s.YF = vy[i + 1];
                    s.Encender();
                }
            }
        }
        private void chkLagranje_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLagranje.Checked == true)
            {

                checkBox4.Checked = false;
                checkBox3.Checked = false;
                Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
                Segmento s = new Segmento(0, 0, 0, 0, Color0, ViewPort, Grafico);
                for (int i = 0; i < contador - 1; i++)
                {
                    s.X0 = vx[i];
                    s.Y0 = vy[i];
                    s.XF = vx[i + 1];
                    s.YF = vy[i + 1];
                    double t = vx[0];
                    while (t <= vx[contador - 1])
                    {
                        v.X0 = t;
                        v.Y0 = LibreriaMat.Lagrange(t, vx, vy, contador);
                        v.Encender();
                        t = t + 0.01;
                    }
                }
            }
        }
        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Puntos")
            {
                chkLagranje.Enabled=true;
                checkBox4.Enabled = true;
                checkBox3.Enabled = true;
                Habilitado = 24;
            }
        }
        private void btnHiperciclo_Click(object sender, EventArgs e)
        {
            Habilitado = 8;
            ViewPort.Enabled = true;
        }
        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox3.Checked==true){
                contador = 0;
            }
        }
        private void button6_Click_2(object sender, EventArgs e)
        {
            Habilitado = 22;
            ViewPort.Enabled=true;
        }
        private void btnSegmentoInterpolado_Click(object sender, EventArgs e)
        {
            Habilitado = 23;
            ViewPort.Enabled = true;
        }
        private void btnPlano_Click(object sender, EventArgs e)
        {
            ViewPort.Image = null;
            Grafico = null;
            if (Grafico == null)
            {
                Grafico = new Bitmap(ViewPort.Width, ViewPort.Height);
            }
            /////
            Segmento seg1 = new Segmento(-15, 0, 15, 0, Color0, ViewPort, Grafico);
            seg1.Encender();
            Segmento seg2 = new Segmento(0, 10, 0, -10, Color0, ViewPort, Grafico);
            seg2.Encender();
            Habilitado = 12;
            ViewPort.Enabled = true;
        }

        private void button6_Click_3(object sender, EventArgs e)
        {
            Habilitado = 5;
            ViewPort.Enabled = true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            double Rx = -15;
            Vector vec = new Vector(10, 5, Color0, ViewPort, Grafico);
            do
            {
                vec.X0 = Rx * 2;//ondas mas anchas (x*val)
                vec.Y0 = Math.Sin(Rx) * 5;//ondas mas altas (y*val)
                vec.Encender();
                Rx = Rx + 0.02;
            } while (Rx <= 15);
        
        }
        private void button8_Click_3(object sender, EventArgs e)
        {
           for (int i = 0; i < 600; i++)
            {

                for (int j = 0; j < 400; j++)
                {
                    Grafico.SetPixel(i, j, Color.FromArgb(Convert.ToInt16((200 * (j - 400) / -400) + 20 * (j) / 400), Convert.ToInt16((230 * (j - 400) / -400) + 10 * (j) / 400), Convert.ToInt16((10 * (j - 400) / -400) + 30 * (j) / 400)));
                    ViewPort.Image = Grafico;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 600; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    Grafico.SetPixel(i, j, Color.FromArgb((int)(255 * (j - 400) / -400) + (255 * j) / 400, (int)((255 * j) / 400), (int)(0)));
                    ViewPort.Image = Grafico;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 600; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    Grafico.SetPixel(i, j, Color.Red);
                    ViewPort.Image = Grafico;
                }
                for (j = 200; j < 400; j++)
                {
                    Grafico.SetPixel(i, j, Color.Yellow);
                    ViewPort.Image = Grafico;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //encender un pixel en la ventana
            Grafico.SetPixel(150, 100, Color.Red);
            ViewPort.Image = Grafico;
        }

        private void formasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            grpformas.Visible = true;
            grpBoxNumerosLetras.Visible = false;
            grpBoxCurvas.Visible = false;
            grpPaleta_Tapetes.Visible = false;
            grpCurvasAjuste.Visible = false;
            grpAnalisisvectorial.Visible = false;
            grpInterpolaciones.Visible = false;
            grpPixel.Visible = false;
        }

        private void númerosYLetrasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            grpformas.Visible = false;
            grpBoxNumerosLetras.Visible = true;
            grpBoxCurvas.Visible = false;
            grpPaleta_Tapetes.Visible = false;
            grpCurvasAjuste.Visible = false;
            grpAnalisisvectorial.Visible = false;
            grpInterpolaciones.Visible = false;
            grpPixel.Visible = false;
        }

        private void curvasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            grpformas.Visible = false;
            grpBoxNumerosLetras.Visible = false;
            grpBoxCurvas.Visible = true;
            grpPaleta_Tapetes.Visible = false;
            grpCurvasAjuste.Visible = false;
            grpAnalisisvectorial.Visible = false;
            grpInterpolaciones.Visible = false;
            grpPixel.Visible = false;
        }

        private void análisisVectorialToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            grpformas.Visible = false;
            grpBoxNumerosLetras.Visible = false;
            grpBoxCurvas.Visible = false;
            grpPaleta_Tapetes.Visible = false;
            grpCurvasAjuste.Visible = false;
            grpAnalisisvectorial.Visible = true;
            grpInterpolaciones.Visible = false;
            grpPixel.Visible = false;
        }

        private void paletasYTapetesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            grpformas.Visible = false;
            grpBoxNumerosLetras.Visible = false;
            grpBoxCurvas.Visible = false;
            grpPaleta_Tapetes.Visible = true;
            grpCurvasAjuste.Visible = false;
            grpAnalisisvectorial.Visible = false;
            grpInterpolaciones.Visible = false;
            grpPixel.Visible = false;
        }

        private void curvasDeAjustesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpformas.Visible = false;
            grpBoxNumerosLetras.Visible = false;
            grpBoxCurvas.Visible = false;
            grpPaleta_Tapetes.Visible = false;
            grpCurvasAjuste.Visible = true;
            grpAnalisisvectorial.Visible = false;
            grpInterpolaciones.Visible = false;
            grpPixel.Visible = false;
        }

        private void paletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color0 = colorDialog1.Color;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewPort.Image = null;
            Grafico = null;
            if (Grafico == null)
            {
                Grafico = new Bitmap(ViewPort.Width, ViewPort.Height);
            }
            ban = 0;
            contador = 0;
        }
        private void pixelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpformas.Visible = false;
            grpBoxNumerosLetras.Visible = false;
            grpBoxCurvas.Visible = false;
            grpPaleta_Tapetes.Visible = false;
            grpCurvasAjuste.Visible = false;
            grpAnalisisvectorial.Visible = false;
            grpInterpolaciones.Visible = false;
            grpPixel.Visible = true;
        }

        private void interpolacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpformas.Visible = false;
            grpBoxNumerosLetras.Visible = false;
            grpBoxCurvas.Visible = false;
            grpPaleta_Tapetes.Visible = false;
            grpCurvasAjuste.Visible = false;
            grpAnalisisvectorial.Visible = false;
            grpInterpolaciones.Visible = true;
            grpPixel.Visible = false;
        }
        private void cmb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb3.SelectedIndex == 0)
            {
                Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);

                Segmento s = new Segmento(0, 0, 0, 0, Color0, ViewPort, Grafico);
                for (int i = 0; i < contador - 1; i++)
                {
                    s.X0 = vx[i];
                    s.Y0 = vy[i];
                    s.XF = vx[i + 1];
                    s.YF = vy[i + 1];

                    double t = vx[0];
                    while (t <= vx[contador - 1])
                    {
                        v.X0 = t;
                        v.Y0 = LibreriaMat.Lagrange(t, vx, vy, contador);
                        v.Encender();
                        t = t + 0.01;
                    }

                }   
            }

            if (cmb3.SelectedIndex == 1)
            {
                double t1;
                double xbi, ybi;
                t1 = 0;
                LibreriaMat mat = new LibreriaMat();

                while (t1 <= 1)
                {

                    mat.bezier(t1, out xbi, out ybi, contador, vx, vy);
                    Vector v = new Vector(xbi, ybi, Color0, ViewPort, Grafico);
                    v.Encender();
                    t1 = t1 + 0.001;
                }
            }

            if (cmb3.SelectedIndex == 2)
            {
                Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
                double x2 = 0, x = 0, y = 0, xy = 0, b, m, cambio = -15, dt = 0.001;
                for (int j = 0; j < contador; j++)
                {
                    //calculo de los terminos
                    x2 += vx[j] * vx[j];
                    y += vy[j];
                    x += vx[j];
                    xy += vx[j] * vy[j];
                }
                //COEFICIENTE PARCIAL DE REGRESION
                m = (contador * xy - (x * y)) / (contador * x2 - Math.Pow(x, 2));
                b = (y - m * x) / contador;
                do
                {
                    v.X0 = cambio;
                    v.Y0 = m * cambio + b;
                    v.Encender();
                    cambio = cambio + dt;
                }
                while (cambio <= 15);
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            double t1;
            double xbi, ybi;
            t1 = 0;
            LibreriaMat mat = new LibreriaMat();

            while (t1 <= 1)
            {

                mat.bezier(t1, out xbi, out ybi, contador, vx, vy);
                Vector v = new Vector(xbi, ybi, Color0, ViewPort, Grafico);
                v.Encender();
                t1 = t1 + 0.001;
            };
        }
        private void button18_Click(object sender, EventArgs e)
        {
            double u = 0;
            double du = 0.1;
            double alfa;
            Vector vec = new Vector(0, 6, Color.Black,ViewPort,Grafico);
            while (u <= (Math.PI * 2))
            {
                alfa = u;
                cCurva obj = new cCurva(5, 4, vec, Color.Black, alfa, ViewPort, Grafico);
                obj.pCurvaVOn();
                ViewPort.Refresh();
                ViewPort.Image = Grafico;
                u = u + du;
                obj.Color = Color0;
                obj.pCurvaVOn();
                ViewPort.Image = Grafico;
            }

        }

        private void cbmanimacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmanimacion.SelectedIndex == 0)
            {
                Circunferencia cir = new Circunferencia(6, 0, 0, Color.Blue, ViewPort, Grafico);
                double w = -10;
                cir.Radio = 2;
                do
                {
                    cir.X0 = ((w - 1));
                    cir.Y0 = ((w - 1)) + 3.5;

                    cir.Encender();
                    w = w + 1;
                    ViewPort.Refresh();
                    Thread.Sleep(100);
                    cir.Apagar(ViewPort.BackColor);
                    ViewPort.Refresh();
                } while (w < 8);

                cir.Encender();
                ViewPort.Refresh();
            }
            if (cbmanimacion.SelectedIndex == 1)
            {
                Circunferencia cir = new Circunferencia(6, 0, 0, Color.Blue, ViewPort, Grafico);
                double w = -9;
                cir.Radio = 2;
                do
                {
                    cir.X0 = w;
                    cir.Y0 = -(w * w) / 8;

                    cir.Encender();
                    w = w + 1;
                    ViewPort.Refresh();
                    Thread.Sleep(100);
                    cir.Apagar(ViewPort.BackColor);
                    ViewPort.Refresh();
                } while (w < 9);

                cir.Encender();
                ViewPort.Refresh();
            }
            if (cbmanimacion.SelectedIndex == 2)
            {
                Circunferencia cir = new Circunferencia(6, 0, 0, Color.Blue, ViewPort, Grafico);
                double w = -10;
                cir.Radio = 2;
                do
                {
                    cir.X0 = w * 2;
                    cir.Y0 = Math.Sin(w) * 5;

                    cir.Encender();
                    w = w + 0.5;
                    ViewPort.Refresh();
                    Thread.Sleep(100);
                    cir.Apagar(ViewPort.BackColor);
                    ViewPort.Refresh();
                } while (w < 8);

                cir.Encender();
                ViewPort.Refresh();
            }
            if (cbmanimacion.SelectedIndex == 3)
            {
                Habilitado = 7;
                ViewPort.Enabled = true;
            }
            if (cbmanimacion.SelectedIndex == 4)
            {
                Habilitado = 25;
                ViewPort.Enabled = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Segmento sg = new Segmento(-12,5,-3,5,Color0,ViewPort,Grafico);
            sg.Encender();
            Segmento sg1 = new Segmento(-3, 5, 4, -2, Color0, ViewPort, Grafico);
            sg1.Encender();
            Segmento sg2 = new Segmento(4,-2,10,-2,Color0,ViewPort,Grafico);
            sg2.Encender();
            int a = 0;
            for (double i = -12; i <= -3 ; i = i + 0.5)
            {
                CurvaV c = new CurvaV(i,7,2,0,Color0, ViewPort, Grafico);
                c.Color0 = Paleta[a];
                c.Encender();
                a++;
                if (a == 16)
                {
                    a = 0;
                }
                ViewPort.Refresh();
                Thread.Sleep(100);
                c.apagar(ViewPort.BackColor);
                ViewPort.Refresh();
                ViewPort.Image = Grafico;
            }
            double k = 7;
            for (double j = -3; j <= 4; j=j+1 )
             {
                 
                    CurvaV c = new CurvaV(j, k, 2, 0, Color0, ViewPort, Grafico);
                    c.Color0 = Paleta[a];
                    c.Encender();
                    a++;
                    if (a == 16)
                    {
                        a = 0;
                    }
                    c.Encender();
                    ViewPort.Refresh();
                    Thread.Sleep(100);
                    c.apagar(ViewPort.BackColor);
                    ViewPort.Refresh();
                    ViewPort.Image = Grafico;
                    k = k - 1;
                    sg.Encender();
                }
            for (double i = 4; i <= 10; i = i + 1)
            {
                CurvaV c = new CurvaV(i,0, 2, 0, Color0, ViewPort, Grafico);
                c.Color0 = Paleta[a];
                c.Encender();
                a++;
                if (a == 16)
                {
                    a = 0;
                }
                c.Encender();
                ViewPort.Refresh();
                Thread.Sleep(100);
                c.apagar(ViewPort.BackColor);
                ViewPort.Refresh();
                ViewPort.Image = Grafico;
                sg1.Encender();
                sg2.Encender();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Segmento sg = new Segmento(-12, 5, -3, 5, Color0, ViewPort, Grafico);
            sg.Encender();
            Segmento sg1 = new Segmento(-3, 5, 4, -2, Color0, ViewPort, Grafico);
            sg1.Encender();
            Segmento sg2 = new Segmento(4, -2, 10, -2, Color0, ViewPort, Grafico);
            sg2.Encender();
            for (double i = -12; i <= -3; i = i + 1)
            {
                double u = Math.PI * 2;
                double alfa;
                cCurva obj;
                Vector vec = new Vector(i, 7, Color.Black, ViewPort, Grafico);
                while (u >= 0)
                {
                    alfa = u;
                    obj = new cCurva(6, 2, vec, Color0, alfa, ViewPort, Grafico);
                    obj.Color= Color.FromArgb((int)((10 * (u - (2 * Math.PI)) / (-(2 * Math.PI)))), (int)(255 * (u) / ((2 * Math.PI))), (int)((255 * (u - (2 * Math.PI)) / (-(2 * Math.PI))) + ((255 * (u)) / (2 * Math.PI))));
                    obj.pCurvaVOn();
                    ViewPort.Refresh();
                    ViewPort.Image = Grafico;
                    u = u - 0.3;
                    obj.Color = Color0;
                    obj.apagar(ViewPort.BackColor);
                    ViewPort.Image = Grafico;
                }
              
            }
            double k = 7;
            for (double j = -3; j <= 4; j = j +1)
            {

                CurvaV c = new CurvaV(j, k, 2, 0, Color0, ViewPort, Grafico);
                c.Encender();
                double u = Math.PI * 2;
                double alfa;
                cCurva obj;
                Vector vec = new Vector(j, k, Color.Black, ViewPort, Grafico);
                while (u >=0)
                {
                    alfa = u;
                    obj = new cCurva(6, 2, vec, Color0, alfa, ViewPort, Grafico);
                    obj.Color = Color.FromArgb((int)((10 * (u - (2 * Math.PI)) / (-(2 * Math.PI)))), (int)(255 * (u) / ((2 * Math.PI))), (int)((255 * (u - (2 * Math.PI)) / (-(2 * Math.PI))) + ((255 * (u)) / (2 * Math.PI))));
                    obj.pCurvaVOn();
                    ViewPort.Refresh();
                    ViewPort.Image = Grafico;
                    u = u - 0.3;
                    obj.Color = Color0;
                    obj.apagar(ViewPort.BackColor);
                    ViewPort.Image = Grafico;
                }
                
                k = k - 1;
                sg.Encender();
            }
            for (double i = 4; i <= 10; i = i + 1)
            {
                double u = Math.PI * 2;
                double alfa;
                cCurva obj;
                Vector vec = new Vector(i, 0, Color.Black, ViewPort, Grafico);
                while (u >= 0)
                {
                    alfa = u;
                    obj = new cCurva(6, 2, vec, Color0, alfa, ViewPort, Grafico);
                    obj.Color = Color.FromArgb((int)((10 * (u - (2 * Math.PI)) / (-(2 * Math.PI)))), (int)(255 * (u) / ((2 * Math.PI))), (int)((255 * (u - (2 * Math.PI)) / (-(2 * Math.PI))) + ((255 * (u)) / (2 * Math.PI))));
                    obj.pCurvaVOn();
                    ViewPort.Refresh();
                    ViewPort.Image = Grafico;
                    u = u - 0.3;
                    obj.Color = Color0;
                    obj.apagar(ViewPort.BackColor);
                    ViewPort.Image = Grafico;
                }
              
                sg1.Encender();
                sg2.Encender();
               
            }
            Vector vec1 = new Vector(10, 0, Color.Black, ViewPort, Grafico);
            cCurva obj1 = new cCurva(6, 2, vec1, Color0, 0, ViewPort, Grafico);
            obj1.pCurvaVOn();
            ViewPort.Image = Grafico;
        }

        private void ViewPort_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            double pl = 0;
            
            for (double i = -15 ; i <= 15; i=i+0.01)
            {
                //pl = pl - 3 * Math.Cos(i / 3) * (i) - (Math.Sin(i / 3) / 1) * i - ((Math.Cos(i / 3) / 3) / 2) * (i * i) + ((Math.Sin(i / 3) / 9) / 6) * (i * i * i) + ((Math.Cos(i / 3) / 27) / 24) * (i * i * i * i) - (((Math.Sin(i / 3)) / 81) / 120) * (i * i * i * i * i) - (((Math.Cos(i / 3)) / 243) / 720) * (i * i * i * i * i * i) + (((Math.Sin(i / 3)) / 729) / 5040) * (i * i * i * i * i * i * i) + (((Math.Cos(i / 3)) / 2187) / 40320) * (i * i * i * i * i * i * i * i);
                pl = 3 - (i * i) / 6 + (i * i * i * i) / 648 - (i * i * i * i * i * i) / 174960 + (i * i * i * i * i * i * i * i) / 88179840;
                Vector v = new Vector(i,pl,Color0,ViewPort,Grafico);
                v.Encender();
                   
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            double pl = 0;

            for (double i = -2.8; i <= 15; i = i + 0.01)
            {
                //pl = pl - 3 * Math.Cos(i / 3) * (i) - (Math.Sin(i / 3) / 1) * i - ((Math.Cos(i / 3) / 3) / 2) * (i * i) + ((Math.Sin(i / 3) / 9) / 6) * (i * i * i) + ((Math.Cos(i / 3) / 27) / 24) * (i * i * i * i) - (((Math.Sin(i / 3)) / 81) / 120) * (i * i * i * i * i) - (((Math.Cos(i / 3)) / 243) / 720) * (i * i * i * i * i * i) + (((Math.Sin(i / 3)) / 729) / 5040) * (i * i * i * i * i * i * i) + (((Math.Cos(i / 3)) / 2187) / 40320) * (i * i * i * i * i * i * i * i);
                //pl = 1 + i + (i * i) / 2 + (i * i * i)/6 + (i * i * i * i)/24 + (i * i * i * i * i)/120 + (i * i * i * i * i * i)/720 + (i * i * i * i * i * i*i)/5040 + (i * i * i * i * i * i * i * i)/40320;
                pl = 1 + i + Math.Pow(i, 2) / 2 + Math.Pow(i, 3) / 6 + Math.Pow(i, 4) / 24 + Math.Pow(i, 5) / 120 + Math.Pow(i, 6) / 720 + Math.Pow(i, 7) / 5040 + Math.Pow(i, 8) / 40320;
                Vector v = new Vector(i, pl, Color0, ViewPort, Grafico);
                v.Encender();
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            double pl = 0;

            for (double i = -2.8 ; i <= 15; i = i + 0.01)
            {
                pl = 1.1 + 0.33 * i - (0.11 / 2) * Math.Pow(i, 2) + (0.074 / 6) * Math.Pow(i, 3) - (0.074 / 24) * Math.Pow(i, 4) + (0.099 / 120) * Math.Pow(i, 5) - (0.16 / 720) * Math.Pow(i, 6) + (0.33 / 5040) * Math.Pow(i, 7) - (0.77 / 40320) * Math.Pow(i, 8);
                Vector v = new Vector(i, pl, Color0, ViewPort, Grafico);
                v.Encender();

            }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            Habilitado = 26;
            ViewPort.Enabled = true;
           
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Habilitado = 27;
            ViewPort.Enabled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
             double rad = 0.1;
            Circunferencia cir = new Circunferencia(-8, 1, rad, Color.Red, ViewPort, Grafico);
            cir.Radio = rad;
            cir.Encender();
            vx[contador] = -8;
            vy[contador] = 1;
            contador++;
            Circunferencia cir1 = new Circunferencia(1, 8, rad, Color.Red, ViewPort, Grafico);
            cir1.Radio = rad;
            cir1.Encender();
            vx[contador] = 1;
            vy[contador] = 8;
            contador++;

            Circunferencia cir2 = new Circunferencia(5, 4, rad, Color.Red, ViewPort, Grafico);
            cir2.Radio = rad;
            cir2.Encender();
            vx[contador] = 5;
            vy[contador] = 4;
            contador++;

            Vector v = new Vector(0, 0, Color0, ViewPort, Grafico);
            Segmento s = new Segmento(0, 0, 0, 0, Color0, ViewPort, Grafico);
            ViewPort.Image = Grafico;
            cmb3.SelectedIndex=0;
            
                double t = vx[0];

                while (t <= vx[2])
                {
                    v.X0 = t;
                    v.Y0 = LibreriaMat.Lagrange(t, vx, vy, contador);
                    double r = (1 * (t - vx[2]) / (vx[0] - vx[2])) + (3 * (t - vx[0]) / (vx[2] - vx[0]));
                    Circunferencia db = new Circunferencia(v.X0, v.Y0, r, Color0, ViewPort, Grafico);
                    db.Encender();
                   
                    t = t + 0.1;

                    ViewPort.Refresh();
                    Thread.Sleep(10);
                    db.Color0 = ViewPort.BackColor;
                    db.Encender();
                    //cir.Apagar(ViewPort.BackColor);
                    ViewPort.Refresh();

                }
                //ViewPort.Refresh();

                //db.Encender();

            

        }

        private void button21_Click(object sender, EventArgs e)
        {
            cFractalMandelbrot fra = new cFractalMandelbrot();
            LibreriaMat reales= new LibreriaMat();
            double x=0, y=0;
            int  color;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
              
                   reales.Carta(i,j,out x,out y);
                   color= fra.FractalManderbrot(x,y);
                    if (color > 0)
                    {
                        color = (color % 14) + 1;
                    }
                       Grafico.SetPixel(i, j, Paleta[color]);
                    }
                 ViewPort.Image = Grafico;
             
                
            }
            Habilitado = 28;
            ViewPort.Enabled = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            cFractalJulia fra = new cFractalJulia();
            LibreriaMat reales = new LibreriaMat();
            double x = 0, y = 0;
            int color;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {

                    reales.Carta(i, j, out x, out y);
                    color = fra.FractalJulia(x, y);
                    if (color > 0)
                    {
                        color = (color % 14) + 1;
                    }
                    Grafico.SetPixel(i, j, Paleta[color]);
                }
                ViewPort.Image = Grafico;


            }
            Habilitado = 28;
            ViewPort.Enabled = true;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox5.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox6.Checked = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cFractalMandelbrot fra = new cFractalMandelbrot();
            LibreriaMat reales = new LibreriaMat();
            cFractalJulia fra1= new cFractalJulia();
            double x = 0, y = 0;
            int color;
            int ColorT = 0;
            if (comboBox3.SelectedIndex == 0)
            {
                for (int i = 0; i < 600; i++)
                    for (int j = 0; j < 400; j++)
                    {
                        //ColorT = ((i * i) + (j * j)) % 15;
                        if (checkBox6.Checked == true)
                        {
                            reales.Carta(i, j, out x, out y);
                            ColorT = fra.FractalManderbrot(x, y);
                            if (ColorT > 0)
                            {
                                ColorT = (ColorT % 14) + 1;
                            }
                            Grafico.SetPixel(i, j, Paleta[ColorT]);
                        }
                        if (checkBox5.Checked == true)
                        {
                            Grafico.SetPixel(i, j, Paleta2[ColorT]);
                        }
                    }
                ViewPort.Image = Grafico;
            }
                if (comboBox3.SelectedIndex == 1)
                {
                    for (int i = 0; i < 600; i++)
                        for (int j = 0; j < 400; j++)
                        {
                            //ColorT = ((i * i) + (j * j)) % 15;
                            if (checkBox6.Checked == true)
                            {
                                reales.Carta(i, j, out x, out y);
                                ColorT = fra1.FractalJulia(x, y);
                                if (ColorT > 0)
                                {
                                    ColorT = (ColorT % 14) + 1;
                                }
                                Grafico.SetPixel(i, j, Paleta[ColorT]);
                            }
                            if (checkBox5.Checked == true)
                            {
                                Grafico.SetPixel(i, j, Paleta2[ColorT]);
                            }
                        }
                    ViewPort.Image = Grafico;
                }
            
                Habilitado = 28;
                ViewPort.Enabled = true;
        }
    }
}
