using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FabianYunda
{
    public partial class Form1 : Form
    {
        Bitmap grafico;
        Bitmap[] mafv = new Bitmap[100];
        List<Bitmap> lista = new List<Bitmap>();

        public string opcion;
        public double px, py, qx, qy;
        public double band = 1;
        public double cx, cy;
        public int num = 3;
        public int eje = 0;
        public int contadorJ, contadorM, contadorSierpinsky;
        public double Ax, Ay, Bx, By, Cx, Cy;

        // FRACTAL SIERPINSKI
        cVector[] vectorSierpinski = new cVector[3];
        public double pmx, pmy;

        // FRACTAL CANTOR
        //double xf = 0, yf = 0;

        // CURVA SPLINE
        cVector[] vPoligonal = new cVector[100];

        // PALETA CUADRADO
        Bitmap[] foto = new Bitmap[1000];
        public int[] tapete = new int[1000];
        SolidBrush pencil;
        Graphics papel;

        public ColorDialog paleta = new ColorDialog();
        Color[] paleta0 = new Color[16];
        Color[] paleta1 = new Color[15];
        Color[] paleta2 = new Color[15];

        public double[] vx = new double[1500];
        public double[] vy = new double[1500];

        public double[] vx1 = new double[1500];
        public double[] vy1 = new double[1500];
        public double[] vx2 = new double[1500];
        public double[] vy2 = new double[1500];

        public int poligonal = 0;

        public double[] Suma = new double[4];
        public Form1()
        {
            
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafico = new Bitmap(600, 400);
            ViewPort.Image = grafico;

            //*********** INICIO DE LAS OPCIONES DEL MENÚ ***********
         
            Grafico2D.Parent = null;
            Fractales.Parent = null;
            Grafico3D.Parent = null;
            Ejercicios.Parent = null;
            Examenes.Parent = null;

            //*********** PALETA DE COLORES ***********
            paleta0[0] = Color.Black;
            paleta0[1] = Color.Navy;
            paleta0[2] = Color.Green;
            paleta0[3] = Color.Aqua;
            paleta0[4] = Color.Red;
            paleta0[5] = Color.Purple;
            paleta0[6] = Color.Maroon;
            paleta0[7] = Color.LightGray;
            paleta0[8] = Color.DarkGray;
            paleta0[9] = Color.Blue;
            paleta0[10] = Color.Lime;
            paleta0[11] = Color.Silver;
            paleta0[12] = Color.Teal;
            paleta0[13] = Color.Fuchsia;
            paleta0[14] = Color.Yellow;
            paleta0[15] = Color.White;

            for (int i = 0; i <= 14; i++)
            {
                paleta1[i] = Color.FromArgb((int)((17 * i)), (int)((17 * i)), 0);
            }

            for (int k = 0; k < 15; k++)
            {
                paleta2[k] = Color.FromArgb((int)(255 * (k - 15) / (0 - 15)) + (255 * (k - 0) / (15 - 0)), (int)(0 * (k - 15) / (0 - 15)) + (255 * (k - 0) / (15 - 0)), (int)(0 * (k - 15) / (0 - 15)) + (0 * (k - 0) / (15 - 0)));
            }

        }

        //*********** INICIO ***********
        //*********** CREACION DE FIGURAS MEDIANTE EL MOUSE ***********
        // UTILIZADO CUANDO ARRATRAMOS UN PUNTO EN LA PANTALLA
        private void ViewPort_MouseDown(object sender, MouseEventArgs e)
        {
            cModelosMat.RealXY(e.X, e.Y, out px, out py);
            double d = Math.Sqrt(Math.Pow((px - qx), 2) + Math.Pow((py - qy), 2));

            // BORRADOR
            if (opcion == "Borrador")
            {
                opcion = "borrador";
            }
        }
        
        //************************* UTILIZADO CUANDO DAMOS CLIC SOBRE LA PANTALLA*********************************************************


        private void ViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            cModelosMat.RealXY(e.X, e.Y, out qx, out qy);
            double d = Math.Sqrt(Math.Pow((px - qx), 2) + Math.Pow((py - qy), 2));

            // BORRADOR
            if (opcion == "borrador")
            {
                opcion = "Borrador";
            }
            switch (opcion)
            {
                case "circulo"://circulodinamico

                    cCircunferencia c = new cCircunferencia(px, py, d, Color.Red, grafico, ViewPort, 0);
                    c.EcenderC();
                    ViewPort.Image = grafico;
                    break;

                case "segmento"://semento dinamico
                    cSegmento s = new cSegmento(px, py, qx, qy, Color.Red, grafico, ViewPort, 0);

                    s.EcenderS();
                    ViewPort.Image = grafico;
                    break;

               

                case "Puntos":
                    double m, yn1, yn2;
                    cCircunferencia c2 = new cCircunferencia(px, py, d, Color.Red, grafico, ViewPort, 0);
                    c2.x0 = px;
                    c2.y0 = (225 - (px * px)) / 28;
                    c2.radio = 0.3;
                    c2.c = Color.Blue;
                    c2.EcenderC();
                    ViewPort.Image = grafico;

                    m = ((-2 * px) * 28) / Math.Pow(28, 2);

                    cSegmento sg = new cSegmento();
                    sg.segmento2(c2.x0, c2.y0, m, out yn1, out yn2);
                    sg.x0 = -15;
                    sg.y0 = yn1;
                    sg.xf = 15;
                    sg.yf = yn2;
                    sg.c = Color.Blue;
                    sg.EcenderS();
                    ViewPort.Image = grafico;
                    break;

               
               

                case "Lazo":
                    cLazo l = new cLazo(px, py,d, Color.Black,grafico,ViewPort,0.9,0);
                    l.EncenderLazo();
                    ViewPort.Image = grafico;
                    break;

                //case "Hipociclo":
                //    Hipociclo h = new Hipociclo(px, py, d, Color.Orange);
                //    h.EncenderHipociclo(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "Poligono":
                //    Poligono p = new Poligono(px, py, d, num, paleta.Color);
                //    p.EncPoligono(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "CEntrecortada":
                //    cCircuenferencia c3 = new Circuenferencia(px, py, d, Color.BlueViolet);
                //    c3.CEntrecortada(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "CLlenada":
                //    Circuenferencia c4 = new Circuenferencia(px, py, d, Color.BlueViolet);
                //    c4.CLlenada(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "SEntrecortado":
                //    Segmento s1 = new Segmento(px, py, qx, qy, Color.Blue);
                //    s1.SEntrecortado(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                case "PAraña":
                     cPoligono p1 = new cPoligono();
                    int nla= int.Parse(textBox2.Text);
                    for (int i = 1; i < 15; i++)
                    {
                        p1.x0 = px;
                        p1.y0 = py;
                        p1.radio = i;
                        p1.nlados = nla;
                        p1.c = paleta.Color;
                        p1.PAraña(grafico);
                        ViewPort.Image = grafico;
                    }
                    break;

                case "Examen":

                    double m11, yn11, yn21;
                    cCircunferencia c21 = new cCircunferencia();
                    c21.x0 = px;
                    c21.y0 = (7 * Math.Sin(px / 3));
                    c21.radio = 0.2;
                    c21.c = Color.Red;
                    c21.EcenderC();
                    ViewPort.Image = grafico;

                    m11 = (7 * (3 / Math.Pow(3, 2)) * Math.Cos(px / 3));

                    cSegmento sg1 = new cSegmento();
                    sg1.segmento2(c21.x0, c21.y0, m11, out yn11, out yn21);
                    sg1.x0 = -15;
                    sg1.y0 = yn11;
                    sg1.xf = 15;
                    sg1.yf = yn21;
                    sg1.c = Color.Blue;
                    sg1.EcenderS();
                    ViewPort.Image = grafico;
                    break;

                

                case "Vectores":
                    double ox, oy, or;
                    cSegmento sv = new cSegmento();
                    if (band < 2)
                    {
                        sv.x0 = 0;
                        sv.y0 = 0;
                        sv.xf = px;
                        sv.yf = py;
                        Suma[1] = px;
                        Suma[2] = py;
                        sv.c = Color.Blue;
                        sv.EcenderS();
                        ViewPort.Image = grafico;
                    }
                    else
                    {
                        if (band == 2)
                        {
                            sv.x0 = 0;
                            sv.y0 = 0;
                            sv.xf = px;
                            sv.yf = py;
                            sv.c = Color.Blue;
                            sv.EcenderS();
                            ViewPort.Image = grafico;

                            /*sv.x0 = 0;
                            sv.y0 = 0;
                            sv.xf = Suma[1] + px;
                            sv.yf = Suma[2] + py;
                            //label3.Text = Convert.ToString(sv.xf);
                            //label4.Text = Convert.ToString(sv.yf);
                            sv.c = paleta.Color;*/


                            sv.EcenderS();
                            ViewPort.Image = grafico;
                           // lblNormaUno.Text = Convert.ToString(Math.Abs(sv.xf) + Math.Abs(sv.yf));
                            

                            ox = Suma[1] * px;
                            oy = Suma[2] * py;
                            or = ox + oy;
                            if (or >= -0.5 && or <= 0.5)
                            {

                            //    lblResultadoVector.Text = "ES ORTOGONAL";
                            }
                            else
                            {
                              //  lblResultadoVector.Text = "NO ES ORTOGONAL";
                            }

                          
                        }
                    }
                    band++;
                    break;

                //case "Teta":
                //    Circuenferencia ltt = new Circuenferencia(px, py, d, Color.Black);
                //    ltt.Letrateta(grafico);
                //    ViewPort.Image = grafico;
                //    break;


                //case "q":
                //    Circuenferencia lq = new Circuenferencia(px, py, d, Color.Black);
                //    lq.Letraq(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "h":
                //    Circuenferencia lh = new Circuenferencia(px, py, d, Color.Black);
                //    lh.Letrah(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "f":
                //    Circuenferencia lf = new Circuenferencia(px, py, d, Color.Black);
                //    lf.Letraf(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "m":
                //    Circuenferencia lm = new Circuenferencia(px, py, d, Color.Black);
                //    lm.EncenderCirculoLm(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //// NÚMEROS 

                //case "1":
                //    Circuenferencia uno = new Circuenferencia(px, py, d, Color.Black);
                //    uno.EncenderUno(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "2":
                //    Circuenferencia dos = new Circuenferencia(px, py, d, Color.Violet);
                //    dos.EncenderDos(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "3":
                //    Circuenferencia tres = new Circuenferencia(px, py, d, Color.Black);
                //    tres.EncenderTres(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "4":
                //    Circuenferencia cuatro = new Circuenferencia(px, py, d, Color.Violet);
                //    cuatro.EncenderCuatro(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "5":
                //    Circuenferencia cinco = new Circuenferencia(px, py, d, Color.Violet);
                //    cinco.EncenderCinco(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "6":
                //    Circuenferencia seis = new Circuenferencia(px, py, d, Color.Violet);
                //    seis.EncenderSies(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "7":
                //    Circuenferencia siete = new Circuenferencia(px, py, d, Color.Violet);
                //    siete.EncenderSiete(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                //case "8":
                //    Circuenferencia ocho = new Circuenferencia();
                //    ocho.radio = d;
                //    ocho.x0 = qx;
                //    ocho.y0 = py;
                //    ocho.c = paleta.Color;
                //    ocho.EncenderI(grafico);
                //    ViewPort.Image = grafico;
                //    Circuenferencia ci = new Circuenferencia(ocho.x0, (ocho.y0 + ocho.radio + ocho.radio * 0.8), (ocho.radio * 0.8), paleta.Color);
                //    ci.EncenderI(grafico);
                //    break;

                //case "9":
                //    Circuenferencia nueve = new Circuenferencia(px, py, d, Color.Violet);
                //    nueve.EncendeNueve(grafico);
                //    ViewPort.Image = grafico;
                //    break;

                case "Mandelbrot":
                    double Lx = cModelosMat.x2 - cModelosMat.x1;
                    double Ly = cModelosMat.y2 - cModelosMat.y1;
                    double xf2, yf2, xf, yf;
                    double L = Lx / 15;
                    double L1 = Ly / 15;
                    label19.Text = Convert.ToString(L);
                    label19.Text = Convert.ToString(L1);
                    cSegmento seg1 = new cSegmento(px - L / 2, py + L1 / 2, px + L / 2, py + L1 / 2, Color.White,grafico,ViewPort,0);
                    seg1.EcenderS();
                    ViewPort.Image = grafico;
                    cSegmento seg2 = new cSegmento(px - L / 2, py - L1 / 2, px + L / 2, py - L1 / 2, Color.White,grafico, ViewPort, 0);
                    seg2.EcenderS();
                    ViewPort.Image = grafico;
                    cSegmento seg3 = new cSegmento(px - L / 2, py + L1 / 2, px - L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                    seg3.EcenderS();
                    ViewPort.Image = grafico;
                    cSegmento seg4 = new cSegmento(px + L / 2, py + L1 / 2, px + L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                    seg4.EcenderS();
                    Thread.Sleep(1000);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    xf = px - L / 2;
                    yf = py - L1 / 2;
                    xf2 = px + L / 2;
                    yf2 = py + L1 / 2;
                    cModelosMat.x1 = xf;
                    cModelosMat.x2 = xf2;
                    cModelosMat.y1 = yf;
                    cModelosMat.y2 = yf2;
                     comboBox18_SelectedIndexChanged(null, null);
                    //btnFractal_Click(null, null);
                    break;

                case "Julia":
                    Lx = 0;
                    Ly = 0;
                    Lx = cModelosMat.x2 - cModelosMat.x1;
                    Ly = cModelosMat.y2 - cModelosMat.y1;
                    L = Lx / 15;
                    L1 = Ly / 15;
                   label19.Text = Convert.ToString(L);
                    label19.Text = Convert.ToString(L1);
                    cSegmento seg5 = new cSegmento(px - L / 2, py + L1 / 2, px + L / 2, py + L1 / 2, Color.White,grafico, ViewPort, 0);
                    seg5.EcenderS();
                    ViewPort.Image = grafico;
                    cSegmento seg6 = new cSegmento(px - L / 2, py - L1 / 2, px + L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                    seg6.EcenderS();
                    ViewPort.Image = grafico;
                    cSegmento seg7 = new cSegmento(px - L / 2, py + L1 / 2, px - L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                    seg7.EcenderS();
                    ViewPort.Image = grafico;
                    cSegmento seg8 = new cSegmento(px + L / 2, py + L1 / 2, px + L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                    seg8.EcenderS();
                    Thread.Sleep(1000);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    xf = px - L / 2;
                    yf = py - L1 / 2;
                    xf2 = px + L / 2;
                    yf2 = py + L1 / 2;
                    cModelosMat.x1 = xf;
                    cModelosMat.x2 = xf2;
                    cModelosMat.y1 = yf;
                    cModelosMat.y2 = yf2;
                    comboBox18_SelectedIndexChanged(null, null);
                    //btnFractal_Click(null, null);
                    break;

                case "PuntosSierpinsky":
                    {
                       
                        for (poligonal = 0; poligonal <= 2; poligonal++)
			            { 
                        cCircunferencia aj1 = new cCircunferencia(0, 0, 0, Color.Blue,grafico,ViewPort,0);
                        aj1.radio = 0.2;
                        aj1.x0 = px;
                        aj1.y0 = py;
                        aj1.EcenderC();
                        vx[poligonal] = px;
                        vy[poligonal] = py;

                        if (poligonal == 2)
                        {
                            Ax = vx[0];
                            Ay = vy[0];
                            Bx = vx[1];
                            By = vy[1];
                            Cx = vx[2];
                            Cy = vy[2];
                        }
                        poligonal++;
                        ViewPort.Image = grafico;
                            }
                    } break;

                case "CuadradoPuntos":
                    int ab, bc, ac, per, sp, a = 0;
                    cSegmento tripuntos = new cSegmento();
                    cCircunferencia aj2 = new cCircunferencia();
                    aj2.radio = 0.2;
                    aj2.x0 = px;
                    aj2.y0 = py;
                    vx[poligonal] = px;
                    vy[poligonal] = py;
                    poligonal++;
                    aj2.c = Color.Blue;
                    aj2.EcenderC();
                    ViewPort.Image = grafico;

                    for (int i = 0; i < poligonal - 1; i++)
                    {
                        tripuntos.x0 = vx[i];
                        tripuntos.y0 = vy[i];
                        tripuntos.xf = vx[i + 1];
                        tripuntos.yf = vy[i + 1];
                        tripuntos.c = Color.Black;
                        tripuntos.EcenderS();
                        ViewPort.Image = grafico;

                        if (poligonal == 4)
                        {
                            tripuntos.x0 = vx[3];
                            tripuntos.y0 = vy[3];
                            tripuntos.xf = vx[0];
                            tripuntos.yf = vy[0];
                            tripuntos.c = Color.Black;
                            tripuntos.EcenderS();
                            ViewPort.Image = grafico;

                        }
                    }

                    break;

                case "Curva A"://semento dinamico
                    cCircunferencia s1 = new cCircunferencia(px, py,0.2, Color.Red, grafico, ViewPort, 0);
                   // vx[poligonal] = px;
                   // vy[poligonal] = py;
                    //++;
                    s1.EcenderC();
                    ViewPort.Image = grafico;
                    cVector vector = new cVector(0,0,Color.Green,grafico,ViewPort);
                    vector.x0 = px;
                    vector.y0 = py;
                    vPoligonal[poligonal] = vector;
                    poligonal++;
                    s1.c = Color.Green;
                    s1.EcenderC();
                    break;
               

               
            }


        }
       
        private void graficos2DToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Grafico2D.Parent = tabControl1;
            Fractales.Parent = null;
            Grafico3D.Parent = null;
            Ejercicios.Parent = null;
            Examenes.Parent = null;

        }

        private void graficos3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafico2D.Parent = null;
            Fractales.Parent = null;
            Grafico3D.Parent = tabControl1;
            Ejercicios.Parent = null;
            Examenes.Parent = null;
        }

        private void fractalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafico2D.Parent = null;
            Fractales.Parent = tabControl1;
            Grafico3D.Parent = null;
            Ejercicios.Parent = null;
            Examenes.Parent = null;
        }

        private void ejercicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafico2D.Parent = null;
            Fractales.Parent = null;
            Grafico3D.Parent = null;
            Ejercicios.Parent =tabControl1;
            Examenes.Parent = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.Red);
                    }
                }
                ViewPort.Image = grafico;
               
            }

            if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.FromArgb((int)(255 * (j - 400) / (0 - 400)) + (255 * (j - 0) / (400 - 0)), (int)(0 * (j - 400) / (0 -400)) + (255 * (j - 0) / (400 - 0)), (int)(0 * (j - 400) / (0 - 200)) + (0 * (j - 0) / (400 - 0))));

                    }
                }
                ViewPort.Image = grafico;

            }
            if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 200; j++)
                    {
                        grafico.SetPixel(i, j, Color.FromArgb((int)(255 * (j - 200) / (0 - 200)) + (255 * (j - 0) / (200 - 0)), (int)(0 * (j - 200) / (0 - 200)) + (255 * (j - 0) / (200 - 0)), (int)(0 * (j - 200) / (0 - 200)) + (0 * (j - 0) / (200 - 0))));

                    }
                }
                ViewPort.Image = grafico;
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 200; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.FromArgb((int)(255 * (j - 400) / (200 - 400)) + (255 * (j - 200) / (400 - 200)), (int)(255 * (j - 400) / (200 - 400)) + (0 * (j - 200) / (400 - 200)), (int)(0 * (j - 400) / (200 - 400)) + (0 * (j - 200) / (400 - 200))));

                    }
                }
                ViewPort.Image = grafico;

            }
            if (comboBox1.SelectedIndex == 3)
            {
                for (int i = 0; i < 200; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.FromArgb((int)(0 * (i - 200) / (0 - 200)) + (0 * (i - 0) / (200 - 0)), (int)(255 * (i - 200) / (0 - 200)) + (0 * (i - 0) / (200 - 0)), (int)(0 * (i - 200) / (0 - 200)) + (255 * (i - 0) / (200 - 0))));

                    }
                }
                ViewPort.Image = grafico;
                for (int i = 200; i < 400; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.FromArgb((int)(0 * (i - 400) / (200 - 400)) + (255 * (i - 200) / (400 - 200)), (int)(0 * (i - 400) / (200 - 400)) + (255 * (i - 200) / (400 - 200)), (int)(255 * (i - 400) / (200 - 400)) + (0 * (i - 200) / (400 - 200))));

                    }
                }
                ViewPort.Image = grafico;
                ViewPort.Image = grafico;
                for (int i = 400; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.FromArgb((int)(255 * (i - 600) / (400 - 600)) + (255 * (i - 400) / (600 - 400)), (int)(255* (i - 600) / (400 - 600)) + (0 * (i - 400) / (600 - 400)), (int)(0 * (i - 600) / (400 - 600)) + (0 * (i - 400) / (600 - 400))));

                    }
                }
                ViewPort.Image = grafico;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cVector v = new cVector(4, 5, Color.Red, grafico,ViewPort);
            v.EcenderV();
            ViewPort.Image = grafico;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cSegmento s = new cSegmento(0, 0, 0, 0, Color.Red, grafico, ViewPort, 0);
            s.x0 = 0;
            s.y0 = 0;
            s.xf = 0;
            s.yf = 5;
            s.tipo = 1;
            s.c=Color.Blue;
            s.EcenderS();
            ViewPort.Image = grafico;
            s.x0 = 0;
            s.y0 = 5;
            s.xf = 5;
            s.yf = 5;
            s.tipo = 0;
            s.c = Color.BlueViolet;
            s.EcenderS();
            ViewPort.Image = grafico;
            s.x0 = 5;
            s.y0 = 5;
            s.xf = 5;
            s.yf = 0;
            s.tipo = 2;
            s.c = Color.Brown;
            s.EcenderS();
            ViewPort.Image = grafico;
            s.x0 = 0;
            s.y0 = 0;
            s.xf = 5;
            s.yf = 0;
            s.tipo = 3;
            s.c = Color.Tomato;
            s.EcenderS();
            ViewPort.Image = grafico;

            s.x0 = 4;
            s.y0 = 5;
            s.xf = 7;
            s.yf = 2;
            s.tipo = 3;
            s.c = Color.Blue;
            s.EcenderS();
        }

      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox2.SelectedIndex == 0)
            {
                cCircunferencia c = new cCircunferencia(2, 3, 3, Color.Red, grafico, ViewPort, 0);
                c.EcenderC();
                ViewPort.Image = grafico;

            }
            //color interpolado 
            if (comboBox2.SelectedIndex ==1)
            {
                cCircunferencia c1 = new cCircunferencia(0, 3, 3, Color.Red, grafico, ViewPort, 1);
                c1.EcenderC();
                ViewPort.Image = grafico;

            }
            //circunferencia entrecortada
            if (comboBox2.SelectedIndex == 2)
            {
                cCircunferencia c3 = new cCircunferencia(4, 3, 3, Color.Green, grafico, ViewPort,2);
                c3.EcenderC();
                ViewPort.Image = grafico;

            }
            //circunfrecnia rellena
            if (comboBox2.SelectedIndex == 3)
            {
                cCircunferencia c4 = new cCircunferencia(4, 3, 1, Color.Green, grafico, ViewPort, 3);
                c4.EcenderC();
                ViewPort.Image = grafico;

            }
            //circulo interponado posicion, color, radio
            if (comboBox2.SelectedIndex == 4)
            {
                cCircunferencia c4 = new cCircunferencia(0, 0, 0, Color.YellowGreen, grafico, ViewPort, 0);
                double i = 0;
                while(i<= 14)
                {
                    c4.x0 = i;
                    c4.y0 = (0 * ((i -14) / (0 - 14))) + (6 * ((i -0) / (14 -0)));

                    c4.radio = (1 * ((i - 14) / (0 - 14))) + (4 * ((i - 0) / (14 - 0)));
                    i += 0.02;
                    c4.c = Color.FromArgb(Convert.ToInt32((255 * ((i - 14) / (0 - 14))) + (0 * ((i - 0) / (14 - 0)))),
                    Convert.ToInt32((0 * ((i - 14) / (0 - 14))) + (0 * ((i - 0) / (14 - 0)))),
                    Convert.ToInt32((0 * ((i - 14) / (0 - 14))) + (255 * ((i - 0) / (14 - 0)))));
                    c4.EcenderC();
                    ViewPort.Image = grafico;
                  
                    ViewPort.Refresh();
                    c4.ApagarC();

                }

             }
            //circulointerpolado en tres colores desde radio cero
         if (comboBox2.SelectedIndex == 5)
            {
                cCircunferencia c = new cCircunferencia(0, 0, 0, Color.YellowGreen, grafico, ViewPort, 0);
                for (double j = 0; j < 1; j += 0.1)
                 {
                    c.x0 = 5;
                    c.y0 = 5;
                    c.radio = j;
                    c.c = Color.FromArgb(Convert.ToInt32((0 * ((j - 1) / (0 - 1))) + (255 * ((j - 0) / (1 - 0)))),
                     Convert.ToInt32((0 * ((j - 1) / (0 - 1))) + (0 * ((j - 0) / (1 - 0)))),
                     Convert.ToInt32((0 * ((j - 1) / (0 - 1))) + (0 * ((j - 0) / (1 - 0)))));
                    c.EcenderC();
                    ViewPort.Image = grafico;
                 }
                cCircunferencia c1 = new cCircunferencia(0, 0, 0, Color.YellowGreen, grafico, ViewPort, 0);
                for (double j = 1; j < 2; j += 0.1)
                {
                    c1.x0 = 5;
                    c1.y0 = 5;
                    c1.radio = j;
                    c1.c = Color.FromArgb(Convert.ToInt32((255 * ((j - 2) / (1 - 2))) + (255 * ((j - 1) / (2 - 1)))),
                                          Convert.ToInt32((0 * ((j - 2) / (1 - 2))) + (255 * ((j - 1) / (2 - 1)))),
                                          Convert.ToInt32((0 * ((j - 2) / (1 - 2))) + (0 * ((j - 1) / (2 - 1)))));
                    c1.EcenderC();
                    ViewPort.Image = grafico;
                }
            }
            
            //circulo animado en seno
         if (comboBox2.SelectedIndex == 6)
         {
             cCircunferencia s = new cCircunferencia(0, 0, 0, Color.Red, grafico, ViewPort, 0);
             double t = -15, dt = 0.03;
             do
             {
                 s.x0 = t;
                 s.y0 = Math.Sin(t);
                 s.radio = 2;
                 s.c = Color.Green;
                 s.EcenderC();
                 ViewPort.Image = grafico;
                 ViewPort.Refresh();
                 s.ApagarC();
                 t = t + dt;


             } while (t <= 15);

         }
            //circulo animado en tres segmentos 
         if (comboBox2.SelectedIndex == 7)
         {
           
             cSegmento s = new cSegmento(-15, 2, -4, 2, Color.Red, grafico, ViewPort, 0);
             s.c = Color.RoyalBlue;
             s.EcenderS();
             ViewPort.Image = grafico;
             cSegmento s2 = new cSegmento(-4, 2, 0, -7, Color.Red, grafico, ViewPort, 0);
             s2.c = Color.RoyalBlue;
             s2.EcenderS();
             ViewPort.Image = grafico;
             cSegmento s3 = new cSegmento(0, -7, 15, -7, Color.Red, grafico, ViewPort, 0);
             s3.c = Color.RoyalBlue;
             s3.EcenderS();
             ViewPort.Image = grafico;
             double t = -15, dt = 0.03;
             cCircunferencia c = new cCircunferencia(0, 0, 0, Color.Red, grafico, ViewPort, 0);
             do
             {
                 c.x0 = t;
                 c.y0 = 4;
                 c.radio = 2;
                 c.c = Color.Green;
                 c.EcenderC();
                 ViewPort.Image = grafico;
                 ViewPort.Refresh();
                 s.EcenderS();
                 c.ApagarC();
                 t = t + dt;
                 
             } while (t <= -2.5);
             t = -2.5;
             dt = 0.03;
             cCircunferencia c1 = new cCircunferencia(0, 0, 0, Color.Red, grafico, ViewPort, 0);
             do
             {
                 c1.x0 = t;
                 c1.y0 = (4 * ((t - 2) / (-2.5 - 2))) + (-5 * ((t +2.5) / (2+2.5))); ;
                 c1.radio = 2;
                 c1.c = Color.Green;
                 c1.EcenderC();
                 ViewPort.Image = grafico;
                 ViewPort.Refresh();
                 s.EcenderS();
                 s2.EcenderS();
                 c1.ApagarC();
                 t = t + dt;

             } while (t <= 2);

             t = 2;
            dt = 0.03;
             cCircunferencia c2 = new cCircunferencia(0, 0, 0, Color.Red, grafico, ViewPort, 0);
             do
             {
                 c2.x0 = t;
                 c2.y0 = -5;
                 c2.radio = 2;
                 c2.c = Color.Green;
                 c2.EcenderC();
                 ViewPort.Image = grafico;
                 ViewPort.Refresh();
                 s2.EcenderS();
                 s3.EcenderS();
                 c2.ApagarC();
                 t = t + dt;

             } while (t <= 15);


           
         }
        

         
       }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pendiente con el circulo
            if (comboBox3.SelectedIndex == 0)
            {
                double m1, m2, lx, ly;
                double x = 3, y = 3;
                double x1 = 2, y1 = 2;
                cSegmento s = new cSegmento(0, 0, 0, 0, Color.Red, grafico, ViewPort, 0);
                s.x0 = x;
                s.y0 = y;
                s.xf = x1;
                s.yf = y1;
                s.c = Color.RoyalBlue;
                s.EcenderS();
                ViewPort.Image = grafico;

                cCircunferencia c = new cCircunferencia(0,0, 0, Color.Red, grafico, ViewPort, 0);
                c.x0 = x1;
                c.y0 = y1;
                c.radio = Math.Sqrt(Math.Pow((x1 - x), 2) + Math.Pow((y1 - y), 2));
               c.EcenderC();
                ViewPort.Image = grafico;

                m1 = ((y1 - y) / (x1 - x));
                m2 = -(1 / m1);
                cVector v = new cVector(0, 0, Color.Blue, grafico, ViewPort);
                if (m1 > 0 || m1 < 0 || m1 == 0)
                {
                    for (double i = -10; i < 10; i+=0.02)
                    {
                        lx=((i-y)/m2+x);
                        if (lx > -15 && lx < 15)
                        {
                            v.x0 = lx;
                            v.y0 = i;
                            v.c = Color.GreenYellow;
                            v.EcenderV();
                            ViewPort.Image = grafico;



                        }
                        
                    }

                    
                }
                if (m1.ToString() == "-Infinito")
                {
                    for (double i = -15; i < 15; i = i + 0.002)
                    {
                        ly = (m2 * (i - x) + y);

                        if (ly > -10 && ly < 10)
                        {
                            v.x0 = i;
                            v.y0 = ly;
                            v.c = Color.Violet;
                            v.EcenderV();
                            ViewPort.Image = grafico;
                        }
                    }
                }

            }

            if (comboBox3.SelectedIndex == 1)
            {
                double m1, m2, lx, ly;
                double x = 0, y = 2;
                double p1, p2;
                double x1 = 5, y1 = 5;
                cSegmento s = new cSegmento(0, 0, 0, 0, Color.Red, grafico, ViewPort, 0);
                s.x0 = x;
                s.y0 = y;
                s.xf = x1;
                s.yf = y1;
                s.c = Color.RoyalBlue;
                s.EcenderS();
                ViewPort.Image = grafico;

            

                p1 = (x + x1)/2;
                p2 = (y + y1)/2;

                m1 = ((y1 - y) / (x1 - x));
                m2 = -(1 / m1);
                cVector v = new cVector(0, 0, Color.Blue, grafico, ViewPort);
               
                    for (double i = p2; i < 10; i += 0.02)
                    {
                        lx = ((i - y) / m2 + x);
                        if (lx > -15 && lx < 15)
                        {
                            v.x0 = p1;
                            v.y0 = i;
                            v.c = Color.GreenYellow;
                            v.EcenderV();
                            ViewPort.Image = grafico;



                        }

                   }

            }


                    
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {   //lazo naormal
            if (comboBox4.SelectedIndex ==0)
            {
                cLazo l = new cLazo(5, 3, 3, Color.Red, grafico, ViewPort, 0, 0);
                l.EncenderLazo();
                ViewPort.Image = grafico;
            }
            //lazo rotado
            if (comboBox4.SelectedIndex == 1)
            {
                double w = 0;
                do
                {
                    cLazo ll = new cLazo(5, 3, 6,  Color.Red, grafico, ViewPort,w, 1);
                    ll.EncenderLazo();
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    //Thread.Sleep(10);
                    ll.ApagarLazo();
                    w = w + 0.03;

                } while (w <= 2 * Math.PI);
                

            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox5.SelectedIndex == 0)
            {
                double t = -15, dt = 0.02;
                cVector v = new cVector(0, 0, Color.Blue, grafico, ViewPort);
                cVector v1 = new cVector(0, 0, Color.Blue, grafico, ViewPort);
                do
                {
                    v.x0 = t;
                    v.y0 = Math.Pow(2, t);
                    v.c = Color.Turquoise;
                    v.EcenderV();
                    ViewPort.Image = grafico;
                    v.x0 = t;
                    v.y0 = (1 + (0.69 * t) + ((0.47 * Math.Pow(t, 2)) / 2) + ((0.32 * Math.Pow(t, 3)) / 6) + ((0.22 * Math.Pow(t, 4)) / 24) + ((0.15 * Math.Pow(t, 5)) / 120));
                    v.c = Color.Turquoise;
                    v.EcenderV();
                    ViewPort.Image = grafico;

                    t = t + dt;


                } while (t <= 15);
              
               

            }
            
            if (comboBox5.SelectedIndex == 1)
            {
              
                cVector v = new cVector(0, 0, Color.Blue, grafico, ViewPort);
                for (double t = -15; t < 15; t+=0.02)
                {               
               
                    v.x0 = t;
                    v.y0 = Math.Sin(t); 
                    v.c = Color.Thistle;
                    v.EcenderV();
                    ViewPort.Image = grafico;
                    //v.x0 = t;
                    v.y0 = 0+t+0 + (Math.Pow(t, 3) / 6) +0+ (Math.Pow(t, 5) / 120);
                    v.c = Color.Tomato;
                    v.EcenderV();
                    ViewPort.Image = grafico;
                    


                } 
                
            }
            if (comboBox5.SelectedIndex == 2)
            {
                cVector vec = new cVector(0, 0, Color.Blue, grafico, ViewPort);
                for (double i = -15; i < 15; i += 0.01) 
                {
                    vec.x0 = i;
                    vec.y0 = (3 * (Math.Cos(i / 3)));
                    vec.c = Color.Blue;
                    vec.EcenderV();
                    vec.x0 = i;
                    vec.y0 = (3 - ((Math.Pow(i, 2)) / 6)
                        + ((Math.Pow(i, 4)) / 648)
                        - ((Math.Pow(i, 6)) / 174960)
                        + ((Math.Pow(i, 8)) / 88179840)
                        - ((Math.Pow(i, 10)) / 71425670400));
                    vec.c = Color.Red;
                    vec.EcenderV();
                    ViewPort.Image = grafico;
                }
            }
            



        }

        private void button3_Click(object sender, EventArgs e)
        {
            opcion = "Curva A";
            poligonal = 0;
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox7.SelectedIndex == 0)
            {
                opcion ="circulo";
            }
            
            if (comboBox7.SelectedIndex == 1)
            {
                opcion ="segmento";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //double t = vx[0];
            //double dt = 0.01;
            //cVector v = new cVector(0, 0, Color.Blue, grafico, ViewPort);
            //v.c = Color.Blue;
            //if (comboBox6.SelectedIndex == 0)
            //{

            //    while (t <= vx[poligonal - 1])
            //    {
            //        v.x0 = t;
            //        v.y0 = cModelosMat.Lagrange(t, vx, vy, poligonal);
            //        v.EcenderV();
            //        t = t + dt;
            //    }
            //}
            if (comboBox6.SelectedIndex ==0)
            {
               double t = vPoligonal[0].x0;
                double dt = 0.001;
                cVector v = new cVector();
                v.c = Color.Blue;

                while (t <= vPoligonal[poligonal - 1].x0)
                {
                    v.x0 = t;
                    //v.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    v.y0 = cModelosMat.Lagrange1(t, vPoligonal, poligonal);
                    v.Encender(grafico);
                    ViewPort.Image = grafico;
                    t = t + dt;
                }

            }
            if (comboBox6.SelectedIndex == 1)
            {
                double bt = 0;
                // double xbi, ybi;
                cVector vb = new cVector();
                while (bt <= 1)
                {
                    //ModelosMat.Bezier(vx, vy, poligonal, bt, out xbi, out ybi);

                    vb.x0 = cModelosMat.Bezier1(vPoligonal, poligonal, bt).x0;
                    vb.y0 = cModelosMat.Bezier1(vPoligonal, poligonal, bt).y0;

                    /*vb.x0 = xbi;
                    vb.y0 = ybi;*/
                    vb.c = Color.Violet;
                    vb.Encender(grafico);
                    ViewPort.Image = grafico;
                    bt = bt + 0.001;
                }

            }
            if (comboBox6.SelectedIndex == 2)
            {
                for (int i = 0; i <poligonal-1; i++)

                {
                    cSegmento s = new cSegmento(0,0,0,0,Color.Azure,grafico,ViewPort,0);
                    

                    s.x0 =vPoligonal[i].x0;
                    s.y0 = vPoligonal[i].y0;
                    s.xf = vPoligonal[i+1].x0;
                    s.yf = vPoligonal[i+1].y0;

                    s.c = Color.Pink;
                    s.EcenderS();
                    ViewPort.Image = grafico;
                   
                }

            }
            if (comboBox6.SelectedIndex == 3)
            {
                if (poligonal < 3)
                {
                    MessageBox.Show("Ingrese al menos 3 puntos");
                }
                else
                {
                    float[] x = new float[poligonal];
                    float[] y = new float[poligonal];

                    for (int i = 0; i < poligonal; i++)
                    {
                        x[i] = (float)(vPoligonal[i].x0);
                        y[i] = (float)(vPoligonal[i].y0);
                    }


                    int n = 500; //da la pauta  razon entre puntos
                    float[] xs = new float[n];
                    //xs = vectorx.;

                    float stepSize = (x[x.Length - 1] - x[0]) / n;
                    for (int i = 0; i < n; i++)
                    {
                        xs[i] = x[0] + i * stepSize;//lleno con puntos  en X  ke esten  en el dominio de la grafica 
                    }

                    CubicSpline spline = new CubicSpline();
                    float[] ys = spline.FitAndEval(x, y, xs);// doy ;ps vectores  el vector con puntos en X (dominio)
                   
                    for (int i = 0; i < xs.Length; i++)
                    {
                        cVector vspline = new cVector();

                        vspline.x0 = xs[i];
                        vspline.y0 = ys[i];
                        vspline.c = Color.Peru;
                        vspline.Encender(grafico);
                        ViewPort.Image = grafico;
                        vspline = null;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox10.SelectedIndex == 0)
            {
                cFractal f = new cFractal(0, 1, 3, Math.PI / 2, Math.PI / 3, Color.Red, grafico, ViewPort);
                f.ArbolFractal();
                ViewPort.Image = grafico;
            }


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.SelectedIndex == 0)
            {
                double w = 0;
                cCurva3D c3d = new cCurva3D();
                    do
                    {
                        c3d.x0 = 2;
                        c3d.y0 = -2;
                        c3d.z0 = 5;
                        c3d.a = 4;
                        c3d.b = 0.333;
                        c3d.eje = 1;
                        c3d.tipo = 1;
                        c3d.gama = w;
                        c3d.c = Color.Green;
                         
                        c3d.EncenderCurva3D(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        c3d.ApagarCurva3D(grafico);
                        ViewPort.Image = grafico;
                        w += 0.2;
                    } while (w <= 2 * Math.PI);

                    w = 0;

                    do
                    {
                        c3d.x0 = 2;
                        c3d.y0 = -2;
                        c3d.z0 = 5;
                        c3d.a = 4;
                        c3d.b = 0.333;
                        c3d.eje = 2;
                        c3d.tipo = 1;
                        c3d.gama = w;
                        c3d.c = Color.Green;
                        c3d.EncenderCurva3D(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        c3d.ApagarCurva3D(grafico);
                        ViewPort.Image = grafico;
                        w += 0.2;
                    } while (w <= 2 * Math.PI);
                    w = 0;

                    do
                    {
                        c3d.x0 = 2;
                        c3d.y0 = -2;
                        c3d.z0 = 5;
                        c3d.a = 4;
                        c3d.b = 0.333;
                        c3d.eje = 3;
                        c3d.tipo = 1;
                        c3d.gama = w;
                        c3d.c = Color.Green;
                        c3d.EncenderCurva3D(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        c3d.c = Color.Yellow;
                        c3d.ApagarCurva3D(grafico);
                        ViewPort.Image = grafico;
                        w += 0.2;
                    } while (w <= 2 * Math.PI);
                }
            if (comboBox13.SelectedIndex == 1)
            {
                double w = 0;
                cCurva3D c3d = new cCurva3D();

                do
                {
                    c3d.x0 = 2;
                    c3d.y0 = -2;
                    c3d.z0 = 5;
                    c3d.a = 4;
                    c3d.b = 0.333;
                    c3d.eje = 1;
                    c3d.tipo = 2;
                    c3d.gama = w;
                    c3d.EncenderCurva3D(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    c3d.ApagarCurva3D(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);

                w = 0;
                do
                {
                    c3d.x0 = 2;
                    c3d.y0 = -2;
                    c3d.z0 = 5;
                    c3d.a = 4;
                    c3d.b = 0.333;
                    c3d.eje = 2;
                    c3d.tipo = 2;
                    c3d.gama = w;
                    c3d.EncenderCurva3D(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    c3d.ApagarCurva3D(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);
            }


            if (comboBox13.SelectedIndex == 2)
            {
                ViewPort.BackColor = Color.Black;
                cCurva3D ob = new cCurva3D(3, 2, -4, 4, 0.23, 0, 0, Color.White, 0);
                double w, h;
                for (int i = 0; i < 2; i++)
                {
                    h = 0.13; w = 0.005;
                    do
                    {
                        ob = new cCurva3D(3, 2, -4, 4, h, 0, 0,Color.White,0);
                        ob.EncenderCurva3D(grafico);
                        ViewPort.Image = grafico;

                        ViewPort.Refresh();

                        h = h + w;
                        ob.c = Color.Black;
                        ob.EncenderCurva3D(grafico);
                        ViewPort.Image = grafico;
                    } while (h <= 0.5);

                    do
                    {
                        ob = new cCurva3D(3, 2, -4, 4, h, 0, 0, Color.White, 0);
                        ob.EncenderCurva3D(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();

                        h = h - w;
                        ob.c = Color.Black;
                        ob.EncenderCurva3D(grafico);
                        ViewPort.Image = grafico;

                    } while (h >= 0.13);
                }
                ob.EncenderCurva3D(grafico);
                ViewPort.Image = grafico;






             }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int radio = 4;
            int Nlados = int.Parse(textBox1.Text);
            double alfa=2*Math.PI/Nlados, beta = Math.PI / 2;

            for (int i = 0; i < Nlados; i++)
            {
                cSegmento s = new cSegmento(0, 0, 0, 0, Color.Red, grafico, ViewPort, 0);
                s.x0 = radio * Math.Sin(beta);
                s.y0 = radio * Math.Cos(beta);
                s.xf = radio * Math.Sin(beta + alfa);
                s.yf = radio * Math.Cos(beta + alfa);
                s.c = Color.Red;
                s.EcenderS();
                ViewPort.Image = grafico;
                beta = beta + alfa;
                
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.SelectedIndex == 0)
            {

                cSegmento s = new cSegmento(-15, 2, -4, 2, Color.Red, grafico, ViewPort, 0);
               
                s.EcenderS();
                ViewPort.Image = grafico;
                cSegmento s2 = new cSegmento(-4, 2, 0, -7, Color.Red, grafico, ViewPort, 0);
             
                s2.EcenderS();
                ViewPort.Image = grafico;
                cSegmento s3 = new cSegmento(0, -7, 15, -7, Color.Red, grafico, ViewPort, 0);
               
                s3.EcenderS();
                ViewPort.Image = grafico;
                
                
                double w = 0;
                cLazo l = new cLazo(0, -4, 0, Color.Blue, grafico, ViewPort,w, 1);
                cCircunferencia c2 = new cCircunferencia(-4, 3, 2, Color.Black, grafico, ViewPort, 4);
                cVector v2 = new cVector(0, 0, Color.Black, grafico, ViewPort);

                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -4; i = i + 0.2)
                    {
                        
                        l.y0 = i;
                        l.x0 = 4;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.EncenderLazo();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.ApagarLazo();
                        s.EcenderS();
                        s2.EcenderS();
                        w += 0.2;
                    }

                }

             
                //interpolacion de luga
                // METAMORFOSIS PARABOL RUTA
                poligonal = 0;
                vx[0] = -4;
                vy[0] = 4;
                poligonal++;

                vx[1] = 2;
                vy[1] = 7;
                poligonal++;

                vx[2] = 10;
                vy[2] = -7;
                poligonal++;

                // METAMORFOSIS PARABOLA COS
                int poligonal1 = 0;
                double []vx1=new double [100];
                double[] vy1 = new double[100];
                vx1[0] = -4;
                vy1[0] = 3;
                poligonal1++;

                vx1[1] = 2;
                vy1[1] = 1.5;
                poligonal1++;

                vx1[2] = 10;
                vy1[2] = 1;
                poligonal1++;

                // METAMORFOSIS PARABOLA SIN
                double[] vx2 = new double[100];
                double[] vy2 = new double[100];
                int poligonal2 = 0;

                vx2[0] = -4;
                vy2[0] = 2;
                poligonal2++;

                vx2[1] = 2;
                vy2[1] = 1;
                poligonal2++;

                vx2[2] = 10;
                vy2[2] = 1;
                poligonal2++;
                double t = vx[0];
                double dt = 0.05;
                double  w1 = 0;

                while (t <= vx[2])
                {
                    c2.x0 = cModelosMat.Lagrange(t, vx, vy, poligonal);
                    c2.y0 = t;
                    c2.t1cos = cModelosMat.Lagrange(t, vx1, vy1, poligonal1);
                    c2.t1sen = cModelosMat.Lagrange(t, vx2, vy2, poligonal2);
                    c2.alfa = w1;
                    c2.c = Color.Blue;
                    c2.EcenderC();
                    ViewPort.Refresh();
                    Thread.Sleep(5);
                    c2.ApagarC();
                    s.EcenderS();
                    s2.EcenderS();
                    s3.EcenderS();
                    t = t + dt;
                    w1 = w1 + 0.2;
                }
                c2.c = Color.Blue;
                c2.EcenderC();





            
            
            
            }
        


        }

        private void Grafico3D_Click(object sender, EventArgs e)
        {

        }

        private void btnPaleta_Click(object sender, EventArgs e)
        {
            paleta.ShowDialog();
        }

        private void btnFondo_Click(object sender, EventArgs e)
        {
            ViewPort.BackColor = Color.Black;
        }

        private void btnBorrador_Click(object sender, EventArgs e)
        {
            opcion = "Borrador";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.SelectedIndex==0)
            {
                ViewPort.BackColor = Color.Black;
                eje = 1;
            }

            if (comboBox15.SelectedIndex == 1)
            {
                ViewPort.BackColor = Color.Black;
                eje = 2;
            }

            if (comboBox15.SelectedIndex == 2)
            {
                ViewPort.BackColor = Color.Black;
                eje = 3;
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            double w = 0;
            if (comboBox16.SelectedIndex == 0)
            {

                do
                {
                    cSuperficie s = new cSuperficie();
                    s.x0 = 2;
                    s.y0 = 3;
                    s.z0 = -1;
                    s.gama = w;
                    s.eje = eje;
                    s.tipo = 0;
                   // s.tipom = 0;
                    s.c = Color.Blue;
                    s.EncencerSuper(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s.ApagarSuper(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);

            }
            if (comboBox16.SelectedIndex == 1)
            {
                do
                {
                    cSuperficie s = new cSuperficie();
                    s.x0 = 2;
                    s.y0 = 3;
                    s.z0 = -1;
                    s.gama = w;
                    s.eje = eje;
                    s.tipo = 1;
                    // s.tipom = 0;
                    s.c = Color.Blue;
                    s.EncencerSuper(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s.ApagarSuper(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);

            }
            if (comboBox16.SelectedIndex == 2)
            {
                cSuperficie ts = new cSuperficie();
                do
                {
                    //Superficie ts = new Superficie();
                    ts.x0 = 2;
                    ts.y0 = 2;
                    ts.z0 = -2;
                    ts.tipo = 2;
                    ts.gama = w;
                    ts.eje = eje;
                    ts.radio = 3;
                    ts.radio1 = 1;
                    ts.c = Color.Blue;
                    ts.EncencerSuper(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    ts.ApagarSuper(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);

            }
            if (comboBox16.SelectedIndex == 3)
            {
                do
                {
                    cSuperficie s = new cSuperficie();
                    s.x0 = 2;
                    s.y0 = 0;
                    s.z0 = 7;
                    s.gama = w;
                    s.eje = eje;
                    s.tipo = 3;
                    s.c = Color.Blue;
                    s.EncencerSuper(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s.ApagarSuper(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);
                } 
                if (comboBox16.SelectedIndex == 4)
                {

                    do
                    {
                        cSuperficie s = new cSuperficie();
                        s.x0 = 2;
                        s.y0 = 0;
                        s.z0 = 7;
                        s.gama = w;
                        s.eje = eje;
                        s.tipo = 4;
                        s.c = Color.Blue;
                        s.EncencerSuper(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        s.ApagarSuper(grafico);
                        ViewPort.Image = grafico;
                        w += 0.2;
                    } while (w <= 2 * Math.PI);


                }
                if (comboBox16.SelectedIndex == 5)
                {

                    do
                    {
                        cSuperficie s1 = new cSuperficie();
                        s1.x0 = 2;
                        s1.y0 = 0;
                        s1.z0 = 7;
                        s1.gama = w;
                        s1.eje = eje;
                        s1.tipo = 5;
                        s1.c = Color.Blue;
                        s1.EncencerSuper(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        s1.ApagarSuper(grafico);
                        ViewPort.Image = grafico;
                        w += 0.2;
                    } while (w <= 2 * Math.PI);


                }
                if (comboBox16.SelectedIndex == 6)
                {

                    do
                    {
                        cSuperficie s1 = new cSuperficie();
                        s1.x0 = 2;
                        s1.y0 = 0;
                        s1.z0 = 7;
                        s1.gama = w;
                        s1.eje = eje;
                        s1.tipo = 6;
                        s1.c = Color.Blue;
                        s1.EncencerSuper(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        s1.ApagarSuper(grafico);
                        ViewPort.Image = grafico;
                        w += 0.2;
                    } while (w <= 2 * Math.PI);


                }
                if (comboBox16.SelectedIndex == 7)
                {
                    do
                    {
                        cSuperficie s = new cSuperficie();
                        s.x0 = 2;
                        s.y0 = 3;
                        s.z0 = -1;
                        s.gama = w;
                        s.eje = eje;
                        s.tipo = 7;
                        // s.tipom = 0;
                        s.c = Color.Blue;
                        s.EncencerSuper(grafico);
                        ViewPort.Image = grafico;
                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        s.ApagarSuper(grafico);
                        ViewPort.Image = grafico;
                        w += 0.2;
                    } while (w <= 2 * Math.PI);

                }
                if (comboBox16.SelectedIndex == 8)
                {
                    cSuperficie s = new cSuperficie();
                    s.tipo = 8;
                    s.c = Color.Blue;
                    s.EncencerSuper(grafico);
                    ViewPort.Image = grafico;
                }
                if (comboBox16.SelectedIndex == 9)
                {
                    cSuperficie ts = new cSuperficie();
                   //  do
                    //{
                        //Superficie ts = new Superficie();
                        ts.x0 = 2;
                        ts.y0 = 2;
                        ts.z0 = -2;
                        ts.tipo = 2;
                        ts.gama = w;
                        ts.eje = eje;
                        ts.radio = 3;
                        ts.radio1 = 1;
                        ts.c = Color.Blue;
                        ts.EncencerSuper(grafico);
                        ViewPort.Image = grafico;
                        //ViewPort.Refresh();
                        //Thread.Sleep(200);
                        //ts.ApagarSuper(grafico);
                        //ViewPort.Image = grafico;
                        //w += 0.2;
                    //} while (w <= 2 * Math.PI);


                    
                    for (int j = 0; j < 3; j++)
                    {

                        double tp;
                        for (int i = 0; i < 10; i++)
                        {
                            
                            tp = i * 0.05;

                            cSuperficie s = new cSuperficie();
                            s.tipo = 9;
                            s.c = Color.Blue;
                            s.EncenderSuperOnda(grafico, tp);
                            ViewPort.Image = grafico;

                            ViewPort.Refresh();
                            Thread.Sleep(200);
                            s.ApagarSuperOnda(grafico, tp);
                            ViewPort.Image = grafico;
                             ts.EncencerSuper(grafico);
                             ViewPort.Image = grafico;

                        }

                    }
                    
                    
                }
                if (comboBox16.SelectedIndex == 10)
                {

                    for (int j = 0; j < 3; j++)
                    {

                        double tp;
                        for (int i = 0; i < 10; i++)
                        {
                            tp = i * 0.05;

                            cSuperficie s = new cSuperficie();
                            s.tipo = 9;
                            s.c = Color.Blue;
                            s.EncenderSuperOndaJugiens(grafico, tp);
                            ViewPort.Image = grafico;

                            ViewPort.Refresh();
                            Thread.Sleep(200);
                            s.ApagarSuperOndaJugiens(grafico, tp);
                            ViewPort.Image = grafico;

                        }

                    }


                }

                







            }

        private void btnNuevosPuntos_Click(object sender, EventArgs e)
        {

        }
        public Bitmap CrearOnda(double tp)
        {
            int z;
            grafico = new Bitmap(600, 400);
            double x, y, w = 1.5, d, v = 9.3;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    cModelosMat.RealXY(i, j, out x, out y);
                    d = Math.Sqrt((x * x) + (y * y));
                    double k = w * (d - tp * v);
                    z = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);
                    grafico.SetPixel(i, j, paleta0[z]);
                }
            }

            ViewPort.Refresh();
            ViewPort.Image = grafico;
            return grafico;
        }
        public Bitmap CrearOndaInferencia(double tp){
         int  z, z1, z2;
            grafico = new Bitmap(600, 400);

            double x, y, w1 = 1.5, w2 = 2, d1, d2, v = 9.3;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    cModelosMat.RealXY(i, j, out x, out y);
                    d1 = Math.Sqrt((Math.Pow((x + 4), 2)) + (y * y));
                    double k = w1 * (d1 - tp * v);
                    z1 = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);

                    d2 = Math.Sqrt((Math.Pow((x - 4), 2)) + (y * y));
                    k = w1 * (d2 - tp * v);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                    z2 = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);

                    z = Convert.ToInt32(z1 + z2) % 14;
                    grafico.SetPixel(i, j, paleta1[z]);
                    
                }
                
            }
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            
            return grafico;
        }
        public Bitmap CrearOndaHuygens(double tp)
        {
            int z, z1;
            double x, y, d, w = 1.5, v = 9.3;
            grafico = new Bitmap(600, 400);

            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    z1 = 0;

                    for (int l = 0; l <= 20; l++)
                    {
                        cModelosMat.RealXY(i, j, out x, out y);
                        d = (Math.Sqrt(Math.Pow((x - 10 + l), 2) + Math.Pow(y - 2, 2)));
                        double k = w * (d - (tp * v));
                        z = Convert.ToInt32(Math.Abs((Math.Sin(k)) + 1) * 7.5);
                        z1 = (z1 + z) % 15;
                    }
                    grafico.SetPixel(i, j, paleta2[z1]);
                }
            }
            ViewPort.Refresh();
            ViewPort.Image = grafico;
            return grafico;
        }


        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox17.SelectedIndex ==0)
            {
                //ONDA TIEMPO REAL
                int z, tp = 2;
                double x, y, w = 1.5, d, v = 9.3;
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {

                        cModelosMat.RealXY(i, j, out x, out y);
                        d = Math.Sqrt((x * x) + (y * y));
                        double k = w * (d - tp * v);
                        z = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);
                        grafico.SetPixel(i, j, paleta0[z]);
                    }
                }
                ViewPort.Image = grafico;
             }
            if (comboBox17.SelectedIndex == 1)
            {
                //ONDA TIEMPO REAL
                int z = 0, tp = 1, z1, z2;
                double x, y, w = 1.5,w2=2, d, d1, v = 9.3;
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {

                        cModelosMat.RealXY(i, j, out x, out y);
                        d = Math.Sqrt(Math.Pow((x + 4), 2) + (y * y));
                        double k = w * (d - tp * v);
                        z1 = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);

                        d1 = Math.Sqrt(Math.Pow((x - 4), 2) + (y * y));
                        double k1 = w2 * (d1 - tp * v);
                        z2 = Convert.ToInt32((Math.Sin(k1) + 1) * 7.5);

                        z = Convert.ToInt32((z1 + z2) % 14);

                        grafico.SetPixel(i, j, paleta1[z]);
                    }
                }
                ViewPort.Image = grafico;
            }
            if (comboBox17.SelectedIndex ==2)
            {
                double tp;
                for (int i = 0; i < 18; i++)
                {
                    tp=i*0.05;
                    mafv[i] = CrearOnda(tp);
                    
                }
            }
            if (comboBox17.SelectedIndex ==3)
            {
                double tp;
                for (int i = 0; i < 18; i++)
                {
                    tp = i * 0.05;
                    mafv[i] = CrearOndaInferencia(tp);

                }
            }
            if (comboBox17.SelectedIndex == 4)
            {
                //ONDA TIEMPO REAL
                int z,z1, tp = 1;
                double x, y, w = 1.5, d, v = 9.3;
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        z1 = 0;
                        for (int m = 0; m <21; m++)
                        {
                            cModelosMat.RealXY(i, j, out x, out y);
                            d = Math.Sqrt(Math.Pow((x -10 +m),2) + Math.Pow((y -2),2));
                            double k = w * (d - tp * v);
                            z = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);
                           z1=(z1+z)%15;
                            
                        }
                        grafico.SetPixel(i, j, paleta2[z1]);
                       
                    }
                }
                ViewPort.Image = grafico;
            }
            if (comboBox17.SelectedIndex == 5)
            {
                double tp;
                for (int i = 0; i < 18; i++)
                {
                    tp = i * 0.05;
                    mafv[i] = CrearOndaHuygens(tp);

                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <3; i++)
            {
                for (int j = 1; j < 18; j++)
                {

                    ViewPort.Image = mafv[j];
                    ViewPort.Refresh();
                    Thread.Sleep(50);
                }
            }
        }
        void Cantor(cSegmento s)
        {

            if (s.yf <= -10)
            return;

            s.yf -= 1.5;
            double d = (s.xf - s.x0) / 3;

            cSegmento s1 = new cSegmento(s.x0, s.yf, s.x0 + d, s.yf, Color.Green,grafico,ViewPort,0);
            s1.EcenderS();
            ViewPort.Image = grafico;
            cSegmento s2 = new cSegmento(s.xf - d, s.yf, s.xf, s.yf, Color.Blue,grafico,ViewPort,0);
            s1.EcenderS();
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            Cantor(s1);
            Cantor(s2);
        }
        private void asignarcoordreales()
        {
            cModelosMat.x1 = -15;
            cModelosMat.x2 = 15;
            cModelosMat.y1 = -10;
            cModelosMat.y2 = 10;
        }
        private void ViewPort_MouseMove(object sender, MouseEventArgs e)
        {
            double x = e.X;
            double y = e.Y;

            double a, b;
            a = Math.Round(cModelosMat.RealX(cx), 3);
            b = Math.Round(cModelosMat.RealY(cy), 3);

            cx = x;
            cy = y;

            label24.Text = " COORDENADAS: " + a.ToString() + "  /  " + b.ToString();

            // BORRADOR 
            if (opcion == "borrador")
            {
                dibujar(a, b);
            }
        }

        void dibujar(double x, double y)
        {
           cCircunferencia  cb = new cCircunferencia(0,0,0,Color.Red,grafico,ViewPort,0);
            cb.x0 = x;
            cb.y0 = y;
            cb.c = Color.Violet;
            cb.radio = 0.5;
            cb.EcenderC();
            cb.radio = 0.4;
            cb.EcenderC();
            cb.radio = 0.3;
            cb.EcenderC();
            cb.radio = 0.2;
            cb.EcenderC();
            cb.radio = 0.1;
            cb.EcenderC();
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            Thread.Sleep(10);
            apagar(x, y);
        }


        void apagar(double x, double y)
        {
            cCircunferencia cb = new cCircunferencia(0, 0, 0, Color.Red, grafico, ViewPort, 0);
            cb.x0 = x;
            cb.y0 = y;
            cb.c = Color.White;
            cb.radio = 0.5;
            cb.EcenderC();
            cb.radio = 0.4;
            cb.EcenderC();
            cb.radio = 0.3;
            cb.EcenderC();
            cb.radio = 0.2;
            cb.EcenderC();
            cb.radio = 0.1;
            cb.EcenderC();
            ViewPort.Image = grafico;
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sx, sy, colorF;
            double x, y;
            cFractal fm = new cFractal(0,0,0,0,0,Color.Red,grafico,ViewPort);

            if (comboBox18.SelectedIndex == 0)
            {
                contadorJ = 0;
                if (contadorM == 0)
                {
                    asignarcoordreales();
                }
                for (sx = 0; sx < 600; sx++)
                {
                    for (sy = 0; sy < 400; sy++)
                    {
                        cModelosMat.RealXY(sx, sy, out x, out y);
                        fm.Mandelbrot(x, y, out colorF);
                        opcion = "Mandelbrot";
                        if (chkPaleta0.Checked == true)
                        {
                            grafico.SetPixel(sx, sy, paleta0[colorF]);
                        }
                        if (chkPaleta1.Checked == true)
                        {
                            grafico.SetPixel(sx, sy, paleta1[colorF]);
                        }
                    }
                }
                contadorM++;
                ViewPort.Image = grafico;
            }

            if (comboBox18.SelectedIndex == 1)
            {
                contadorM = 0;
                if (contadorJ == 0)
                {
                    asignarcoordreales();
                }
                for (sx = 0; sx < 600; sx++)
                {
                    for (sy = 0; sy < 400; sy++)
                    {
                        cModelosMat.RealXY(sx, sy, out x, out y);
                        fm.Julia(x, y, out colorF);
                        opcion = "Julia";
                        if (chkPaleta0.Checked == true)
                        {
                            grafico.SetPixel(sx, sy, paleta0[colorF]);
                        }
                        if (chkPaleta1.Checked == true)
                        {
                            grafico.SetPixel(sx, sy, paleta1[colorF]);
                        }
                    }
                }
                contadorJ++;
                ViewPort.Image = grafico;

            }

            if (comboBox18.SelectedIndex == 2)
            {
                cFractal sp = new cFractal(0,0,0,0,0,Color.Red,grafico,ViewPort);
                sp.c = Color.Blue;

                if (poligonal != 0)
                {
                    sp.Dibujar_Sierpinski(Ax, Ay, Bx, By, Cx, Cy, contadorSierpinsky, grafico);
                    contadorSierpinsky++;
                }
                else
                {
                    MessageBox.Show("Ingrese los Puntos");
                }
                ViewPort.Image = grafico;
            }

            if (comboBox18.SelectedIndex == 3)
            {
                

                cSegmento seg = new cSegmento(-10, 9, 10, 9, Color.Red,grafico,ViewPort,0);
                seg.ApagarS();
                ViewPort.Image = grafico;
                Cantor(seg);

            }

        }

        private void btnPuntosSierpinski_Click(object sender, EventArgs e)
        {
            opcion = "PuntosSierpinsky";
            
        }

        private void chkPaleta0_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaleta0.Checked == true)
            {
                chkPaleta1.Checked = false;
            }
        }

        private void chkPaleta1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaleta1.Checked == true)
            {
                chkPaleta0.Checked = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            opcion = "PAraña";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cSegmento3D s1 = new cSegmento3D();

            s1.x0 = 3;
            s1.y0 = -5;
            s1.z0 = -1;
            s1.xf = 7;
            s1.yf = -5;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 7;
            s1.y0 = -5;
            s1.z0 = -1;
            s1.xf = 7;
            s1.yf = -1;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 7;
            s1.y0 = -1;
            s1.z0 = -1;
            s1.xf = 3;
            s1.yf = -1;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 3;
            s1.y0 = -5;
            s1.z0 = -1;
            s1.xf = 3;
            s1.yf = -1;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 3;
            s1.y0 = -5;
            s1.z0 = -1;
            s1.xf = 3;
            s1.yf = -5;
            s1.zf = 3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 3;
            s1.y0 = -1;
            s1.z0 = 3;
            s1.xf = 3;
            s1.yf = -1;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 3;
            s1.y0 = -5;
            s1.z0 = 3;
            s1.xf = 3;
            s1.yf = -1;
            s1.zf = 3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 7;
            s1.y0 = -5;
            s1.z0 = 3;
            s1.xf = 7;
            s1.yf = -5;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 7;
            s1.y0 = -1;
            s1.z0 = 3;
            s1.xf = 7;
            s1.yf = -1;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 7;
            s1.y0 = -5;
            s1.z0 = 3;
            s1.xf = 3;
            s1.yf = -5;
            s1.zf = 3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 7;
            s1.y0 = -1;
            s1.z0 = 3;
            s1.xf = 3;
            s1.yf = -1;
            s1.zf = 3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 7;
            s1.y0 = -5;
            s1.z0 = 3;
            s1.xf = 7;
            s1.yf = -1;
            s1.zf = 3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
        }

        private void btnCuboCortado_Click(object sender, EventArgs e)
        {
            cSegmento3D s1 = new cSegmento3D();

            s1.x0 = -3;
            s1.y0 = 5;
            s1.z0 = -1;
            s1.xf = 0;
            s1.yf = 5;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;


            s1.x0 = 0;
            s1.y0 = 5;
            s1.z0 = -1;
            s1.xf = 0;
            s1.yf = 11;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 11;
            s1.z0 = -1;
            s1.xf = 0;
            s1.yf = 11;
            s1.zf = 2;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 8;
            s1.z0 = 2;
            s1.xf = 0;
            s1.yf = 11;
            s1.zf = 2;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 8;
            s1.z0 = 5;
            s1.xf = 0;
            s1.yf = 8;
            s1.zf = 2;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 5;
            s1.z0 = 5;
            s1.xf = 0;
            s1.yf = 8;
            s1.zf = 5;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 5;
            s1.z0 = 5;
            s1.xf = 0;
            s1.yf = 5;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 5;
            s1.z0 = 5;
            s1.xf = -3;
            s1.yf = 5;
            s1.zf = 5;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 8;
            s1.z0 = 5;
            s1.xf = -3;
            s1.yf = 8;
            s1.zf = 5;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = -3;
            s1.y0 = 5;
            s1.z0 = 5;
            s1.xf = -3;
            s1.yf = 8;
            s1.zf = 5;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 5;
            s1.z0 = -1;
            s1.xf = -3;
            s1.yf = 5;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = -3;
            s1.y0 = 5;
            s1.z0 = 5;
            s1.xf = -3;
            s1.yf = 5;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 11;
            s1.z0 = -1;
            s1.xf = -3;
            s1.yf = 11;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = -3;
            s1.y0 = 11;
            s1.z0 = -1;
            s1.xf = -3;
            s1.yf = 11;
            s1.zf = 2;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = -3;
            s1.y0 = 11;
            s1.z0 = 2;
            s1.xf = -3;
            s1.yf = 8;
            s1.zf = 2;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = -3;
            s1.y0 = 8;
            s1.z0 = 2;
            s1.xf = -3;
            s1.yf = 8;
            s1.zf = 5;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = 0;
            s1.y0 = 11;
            s1.z0 = 2;
            s1.xf = -3;
            s1.yf = 11;
            s1.zf = 2;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = -3;
            s1.y0 = 5;
            s1.z0 = -1;
            s1.xf = -3;
            s1.yf = 11;
            s1.zf = -1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s1.x0 = -3;
            s1.y0 = 8;
            s1.z0 = 2;
            s1.xf = 0;
            s1.yf = 8;
            s1.zf = 2;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cCurva3D c3d = new cCurva3D();
            c3d.c = Color.Violet;

            for (double i = 0.5; i <= 1.5; i += 0.3)
            {
                c3d.x0 = 3;
                c3d.y0 = -2;
                c3d.z0 = -5;
                c3d.b = 1 * i * 0.25;
                c3d.EncenderCurva3D(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                Thread.Sleep(200);
                c3d.ApagarCurva3D(grafico);
                ViewPort.Refresh();
            }



            for (double i = 1.5; i >= 0.5; i -= 0.3)
            {
                c3d.x0 = 3;
                c3d.y0 = -2;
                c3d.z0 = -5;
                c3d.b = 1 * i * 0.25;
                c3d.EncenderCurva3D(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                Thread.Sleep(200);
                c3d.ApagarCurva3D(grafico);
                ViewPort.Image = grafico;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            cCircunferencia c = new cCircunferencia(-4, 3, 2, Color.Black, grafico, ViewPort,3);
            c.EcenderC();
            ViewPort.Image = grafico;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            cSegmento3D s = new cSegmento3D(0, 0, 0, 0, 0, 0, Color.Red);
            s.x0 =2;
            s.y0 =1;
            s.z0 =3;
            s.xf =7;
            s.yf =1;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
            s.x0 = 7;
            s.y0 = 1;
            s.z0 = 3;
            s.xf = 7;
            s.yf = 6;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 7;
            s.y0 = 1;
            s.z0 = 3;
            s.xf = 4.5;
            s.yf = 3.5;
            s.zf = 8;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 4.5;
            s.y0 = 3.5;
            s.z0 = 8;
            s.xf = 7;
            s.yf = 6;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
           
            s.x0 = 4.5;
            s.y0 = 3.5;
            s.z0 = 8;
            s.xf = 2;
            s.yf = 6;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 2;
            s.y0 = 6;
            s.z0 = 3;
            s.xf = 7;
            s.yf = 6;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
            s.x0 = 2;
            s.y0 = 1;
            s.z0 = 3;
            s.xf = 2;
            s.yf = 6;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 2;
            s.y0 = 1;
            s.z0 = 3;
            s.xf = 4.5;
            s.yf = 3.5;
            s.zf = 8;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void Fractales_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox19.SelectedIndex == 0)
            {
                cSegmento s = new cSegmento(-15, 2, -4, 2, Color.Red, grafico, ViewPort, 0);

                s.EcenderS();
                ViewPort.Image = grafico;
                cSegmento s2 = new cSegmento(-4, 2, 0, -7, Color.Red, grafico, ViewPort, 0);

                s2.EcenderS();
                ViewPort.Image = grafico;
                cSegmento s3 = new cSegmento(0, -7, 15, -7, Color.Red, grafico, ViewPort, 0);

                s3.EcenderS();
                ViewPort.Image = grafico;

                double w = 0;
                cLazo l = new cLazo(0, -4, 0, Color.Blue, grafico, ViewPort, w, 3);
                cCircunferencia c2 = new cCircunferencia(-4, 3, 2, Color.Black, grafico, ViewPort, 4);
                cVector v2 = new cVector(0, 0, Color.Black, grafico, ViewPort);
                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -2.5; i = i + 0.2)
                    {   l.y0 = i;
                        l.x0 = 4;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.EncenderLazo();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.ApagarLazo();
                        s.EcenderS();
                        s2.EcenderS();
                        w += 0.2;
                    }

                }



                //interpolacion de luga
                // METAMORFOSIS PARABOL RUTA
                poligonal = 0;
                vx[0] = -4;
                vy[0] = 4;
                poligonal++;

                vx[1] = 2;
                vy[1] = 7;
                poligonal++;

                vx[2] = 10;
                vy[2] = -7;
                poligonal++;

                // METAMORFOSIS PARABOLA COS
                int poligonal1 = 0;
             
                vx1[0] = -4;
                vy1[0] = 3;
                poligonal1++;

                vx1[1] = 2;
                vy1[1] = 1.5;
                poligonal1++;

                vx1[2] = 10;
                vy1[2] = 1;
                poligonal1++;

                // METAMORFOSIS PARABOLA SIN
              
                int poligonal2 = 0;

                vx2[0] = -4;
                vy2[0] = 2;
                poligonal2++;

                vx2[1] = 2;
                vy2[1] = 1;
                poligonal2++;

                vx2[2] = 10;
                vy2[2] = 1;
                poligonal2++;
                double t = vx[0];
                double dt = 0.05;
                double w1 = 0;

                while (t <= vx[2])
                {
                    l.x0 = cModelosMat.Lagrange(t, vx, vy, poligonal);
                    l.y0 = t;
                    l.t1cos = cModelosMat.Lagrange(t, vx1, vy1, poligonal1);
                    l.t1sen = cModelosMat.Lagrange(t, vx2, vy2, poligonal2);
                    l.alfa = w1;
                    l.c = Color.Blue;
                    l.tipo = 4;
                    l.EcenderC();
                    ViewPort.Refresh();
                    Thread.Sleep(5);
                    l.ApagarC();
                    s.EcenderS();
                    s2.EcenderS();
                    s3.EcenderS();
                    t = t + dt;
                    w1 = w1 + 0.2;
                }
                c2.c = Color.Blue;
                c2.EcenderC();








            }
            if (comboBox19.SelectedIndex == 1)
            {
                cSegmento s = new cSegmento(-15, 2, -4, 2, Color.Red, grafico, ViewPort, 0);

                s.EcenderS();
                ViewPort.Image = grafico;
                cSegmento s2 = new cSegmento(-4, 2, 0, -7, Color.Red, grafico, ViewPort, 0);

                s2.EcenderS();
                ViewPort.Image = grafico;
                cSegmento s3 = new cSegmento(0, -7, 15, -7, Color.Red, grafico, ViewPort, 0);

                s3.EcenderS();
                ViewPort.Image = grafico;

                double w = 0;
                cLazo l = new cLazo(0, -4, 0, Color.Blue, grafico, ViewPort, w, 1);
                cCircunferencia c2 = new cCircunferencia(0, 0, 0, Color.Black, grafico, ViewPort, 0);
                cVector v2 = new cVector(0, 0, Color.Black, grafico, ViewPort);
                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -2.5; i = i + 0.2)
                    {
                        c2.y0 = 4;
                        c2.x0 = i;
                        c2.radio = 2;
                        c2.alfa = w;
                        c2.c = Color.Blue;
                        c2.EcenderC();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        c2.ApagarC();
                        s.EcenderS();
                        s2.EcenderS();
                        w += 0.2;
                    }

                }



                //interpolacion de luga
                // METAMORFOSIS PARABOL RUTA
                poligonal = 0;
                vx[0] = -4;
                vy[0] = 4;
                poligonal++;

                vx[1] = 2;
                vy[1] = 7;
                poligonal++;

                vx[2] = 10;
                vy[2] = -7;
                poligonal++;

                // METAMORFOSIS PARABOLA COS
                int poligonal1 = 0;

                vx1[0] = -4;
                vy1[0] = 3;
                poligonal1++;

                vx1[1] = 2;
                vy1[1] = 1.5;
                poligonal1++;

                vx1[2] = 10;
                vy1[2] = 1;
                poligonal1++;

                // METAMORFOSIS PARABOLA SIN

                int poligonal2 = 0;

                vx2[0] = -4;
                vy2[0] = 2;
                poligonal2++;

                vx2[1] = 2;
                vy2[1] = 1;
                poligonal2++;

                vx2[2] = 10;
                vy2[2] = 1;
                poligonal2++;
                double t = vx[0];
                double dt = 0.05;
                double w1 = 0;

                while (t <= vx[2])
                {
                    c2.x0 = cModelosMat.Lagrange(t, vx, vy, poligonal);
                    c2.y0 = t;
                    c2.t1cos = cModelosMat.Lagrange(t, vx1, vy1, poligonal1);
                    c2.t1sen = cModelosMat.Lagrange(t, vx2, vy2, poligonal2);
                    c2.alfa = w1;
                    c2.c = Color.Blue;
                    c2.tipo = 4;
                    c2.EcenderC();
                    ViewPort.Refresh();
                    Thread.Sleep(5);
                    c2.ApagarC();
                    s.EcenderS();
                    s2.EcenderS();
                    s3.EcenderS();
                    t = t + dt;
                    w1 = w1 + 0.2;
                }
                c2.c = Color.Blue;
                c2.EcenderC();








            }
       
  
        
        
        
        
        
     }
    }
   }
    
  
   

