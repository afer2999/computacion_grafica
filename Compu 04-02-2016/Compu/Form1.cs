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

namespace Compu
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
        Vector[] vectorSierpinski = new Vector[3];
        public double pmx, pmy;

        // FRACTAL CANTOR
        //double xf = 0, yf = 0;

        // CURVA SPLINE
        Vector[] vPoligonal = new Vector[100];

        // PALETA CUADRADO
        Bitmap[] foto = new Bitmap[1000];
        public int[] tapete= new int[1000];
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

        // INTERPOLACIÓN SEGUNDA PALETA 


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafico = new Bitmap(600, 400);
            ViewPort.Image = grafico;

            //*********** INICIO DE LAS OPCIONES DEL MENÚ ***********
            tpGraficos2d.Parent = null;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = null;
            tpEjercicios.Parent = null;
            tpExamenes.Parent = null;

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
                paleta1[i] = Color.FromArgb((int)((17 * i)), (int)((17 * i)),0);
            }

            for (int k = 0; k < 15; k++)
            {
                paleta2[k] = Color.FromArgb((int)(255 * (k - 15) / (0 - 15)) + (255 * (k - 0) / (15 - 0)), (int)(0 * (k - 15) / (0 - 15)) + (255 * (k - 0) / (15 - 0)), (int)(0 * (k - 15) / (0 - 15)) + (0 * (k - 0) / (15 - 0)));
            }
        }

        //*********** LIMPIAR LA PANTALLA ***********
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            asignarcoordreales();
            grafico = null;
            grafico = new Bitmap(600, 400);
            ViewPort.Image = grafico;
            poligonal = 0;
        }

        //*********** SALIR ***********
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //*********** INICIO ***********
        //*********** CREACION DE FIGURAS MEDIANTE EL MOUSE ***********
        // UTILIZADO CUANDO ARRATRAMOS UN PUNTO EN LA PANTALLA
        private void ViewPort_MouseDown(object sender, MouseEventArgs e)
        {
            ModelosMat.RealXY(e.X, e.Y, out px, out py);

            // BORRADOR
            if (opcion == "Borrador")
            {
                opcion = "borrador";
            }

        }

        // UTILIZADO CUANDO DAMOS CLIC SOBRE LA PANTALLA
        private void ViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            // BORRADOR
            if (opcion == "borrador")
            {
                opcion = "Borrador";
            }

            ModelosMat.RealXY(e.X, e.Y, out qx, out qy);
            double d = Math.Sqrt(Math.Pow((px - qx), 2) + Math.Pow((py - qy), 2));


            switch (opcion)
            {
                case "Circunferencia":
                    Circuenferencia c = new Circuenferencia();
                    c.x0 = px;
                    c.y0 = py;
                    c.radio = d;
                    c.c = Color.Red;
                    c.EncCircunferencia(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Puntos":
                    double m, yn1, yn2;
                    Circuenferencia c2 = new Circuenferencia();
                    c2.x0 = px;
                    c2.y0 = (225 - (px * px)) / 28;
                    c2.radio = 0.3;
                    c2.c = Color.Blue;
                    c2.EncCircunferencia(grafico);
                    ViewPort.Image = grafico;

                    m = ((-2 * px) * 28) / Math.Pow(28, 2);

                    Segmento sg = new Segmento();
                    sg.segmento2(c2.x0, c2.y0, m, out yn1, out yn2);
                    sg.x0 = -15;
                    sg.y0 = yn1;
                    sg.xf = 15;
                    sg.yf = yn2;
                    sg.c = Color.Blue;
                    sg.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Segmento":
                    Segmento s = new Segmento(px, py, qx, qy, Color.Blue);
                    s.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Circulo":
                    Circuenferencia c1 = new Circuenferencia(px, py, d, paleta.Color /*Color.BlueViolet*/);
                    c1.EncCircunferencia(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Lazo":
                    Lazo l = new Lazo(px, py, d,0.9, Color.Black);
                    l.EncenderLazoRotar(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Hipociclo":
                    Hipociclo h = new Hipociclo(px, py, d, Color.Orange);
                    h.EncenderHipociclo(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Poligono":
                    Poligono p = new Poligono(px, py, d, num, paleta.Color);
                    p.EncPoligono(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "CEntrecortada":
                    Circuenferencia c3 = new Circuenferencia(px, py, d, Color.BlueViolet);
                    c3.CEntrecortada(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "CLlenada":
                    Circuenferencia c4 = new Circuenferencia(px, py, d, Color.Blue);
                    c4.CLlenada(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "SEntrecortado":
                    Segmento s1 = new Segmento(px, py, qx, qy, Color.Blue);
                    s1.SEntrecortado(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "PAraña":
                    Poligono p1 = new Poligono();
                    for (int i = 1; i < 15; i++)
                    {
                        p1.x0 = px;
                        p1.y0 = py;
                        p1.radio = i;
                        p1.nlados = 12;
                        p1.c = paleta.Color;
                        p1.PAraña(grafico);
                        ViewPort.Image = grafico;
                    }
                    break;

                case "Examen":

                    double m11, yn11, yn21;
                    Circuenferencia c21 = new Circuenferencia();
                    c21.x0 = px;
                    c21.y0 = (7 * Math.Sin(px / 3));
                    c21.radio = 0.2;
                    c21.c = Color.Red;
                    c21.EncenderI(grafico);
                    ViewPort.Image = grafico;

                    m11 = (7 * (3 / Math.Pow(3, 2)) * Math.Cos(px / 3));

                    Segmento sg1 = new Segmento();
                    sg1.segmento2(c21.x0, c21.y0, m11, out yn11, out yn21);
                    sg1.x0 = -15;
                    sg1.y0 = yn11;
                    sg1.xf = 15;
                    sg1.yf = yn21;
                    sg1.c = Color.Blue;
                    sg1.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Curvas de Ajuste":
                    Circuenferencia aj = new Circuenferencia();
                    aj.radio = 0.2;
                    aj.x0 = px;
                    aj.y0 = py;
                    aj.c = Color.Red;
                    aj.EncenderI(grafico);
                    ViewPort.Image = grafico;
                    /*vx[poligonal] = px;
                    vy[poligonal] = py;
                    poligonal
                    */

                    Vector vector = new Vector();
                    vector.x0 = px;
                    vector.y0 = py;
                    vPoligonal[poligonal] = vector;
                    poligonal++;
                    aj.c = paleta.Color;
                    aj.Encender(grafico);
                    break;

                case "Vectores":
                    double ox, oy, or;
                    Segmento sv = new Segmento();
                    if (band < 2)
                    {
                        sv.x0 = 0;
                        sv.y0 = 0;
                        sv.xf = px;
                        sv.yf = py;
                        Suma[1] = px;
                        Suma[2] = py;
                        sv.c = Color.Blue;
                        sv.EncenderSegmento(grafico);
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
                            sv.EncenderSegmento(grafico);
                            ViewPort.Image = grafico;



                            sv.EncenderSegmento(grafico);
                            ViewPort.Image = grafico;
                            lblNormaUno.Text = Convert.ToString(Math.Abs(sv.xf) + Math.Abs(sv.yf));
                            ox = Suma[1] * px;
                            oy = Suma[2] * py;
                            or = ox + oy;
                            if (or >= -0.5 && or <= 0.5)
                            {

                                lblResultadoVector.Text = "ES ORTOGONAL";
                            }
                            else
                            {
                                lblResultadoVector.Text = "NO ES ORTOGONAL";
                            }

                        }
                    }
                    band++;
                    break;

                case "Teta":
                    Circuenferencia ltt = new Circuenferencia(px, py, d, Color.Black);
                    ltt.Letrateta(grafico);
                    ViewPort.Image = grafico;
                    break;


                case "q":
                    Circuenferencia lq = new Circuenferencia(px, py, d, Color.Black);
                    lq.Letraq(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "h":
                    Circuenferencia lh = new Circuenferencia(px, py, d, Color.Black);
                    lh.Letrah(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "f":
                    Circuenferencia lf = new Circuenferencia(px, py, d, Color.Black);
                    lf.Letraf(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "m":
                    Circuenferencia lm = new Circuenferencia(px, py, d, Color.Black);
                    lm.EncenderCirculoLm(grafico);
                    ViewPort.Image = grafico;
                    break;

            // NÚMEROS 

                case "1":
                    Circuenferencia uno = new Circuenferencia(px, py, d, Color.Black);
                    uno.EncenderUno(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "2":
                    Circuenferencia dos = new Circuenferencia(px, py, d, Color.Violet);
                    dos.EncenderDos(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "3":
                    Circuenferencia tres = new Circuenferencia(px, py, d, Color.Black);
                    tres.EncenderTres(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "4":
                    Circuenferencia cuatro = new Circuenferencia(px, py, d, Color.Violet);
                    cuatro.EncenderCuatro(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "5":
                    Circuenferencia cinco = new Circuenferencia(px, py, d, Color.Violet);
                    cinco.EncenderCinco(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "6":
                    Circuenferencia seis = new Circuenferencia(px, py, d, Color.Violet);
                    seis.EncenderSies(grafico);
                    ViewPort.Image = grafico;
                    break;
                    
                case "7":
                    Circuenferencia siete = new Circuenferencia(px, py, d, Color.Violet);
                    siete.EncenderSiete(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "8":
                    Circuenferencia ocho = new Circuenferencia();
                    ocho.radio = d;
                    ocho.x0 = qx;
                    ocho.y0 = py;
                    ocho.c = paleta.Color;
                    ocho.EncenderI(grafico);
                    ViewPort.Image = grafico;
                    Circuenferencia ci = new Circuenferencia(ocho.x0, (ocho.y0 + ocho.radio  + ocho.radio * 0.8), (ocho.radio * 0.8), paleta.Color);
                    ci.EncenderI(grafico);
                    break;

                case "9":
                    Circuenferencia nueve = new Circuenferencia(px, py, d, Color.Violet);
                    nueve.EncendeNueve(grafico);
                    ViewPort.Image = grafico;
                    break;

                case "Mandelbrot":
                    double Lx = ModelosMat.x2 - ModelosMat.x1;
                    double Ly = ModelosMat.y2 - ModelosMat.y1;
                    double xf2, yf2, xf, yf;
                    double L = Lx / 15;
                    double L1 = Ly / 15;
                    lblLX1.Text = Convert.ToString(L);
                    lblX2.Text = Convert.ToString(L1);
                    Segmento seg1 = new Segmento(px - L / 2, py + L1 / 2, px + L / 2, py + L1 / 2, Color.White);
                    seg1.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    Segmento seg2 = new Segmento(px - L / 2, py - L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                    seg2.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    Segmento seg3 = new Segmento(px - L / 2, py + L1 / 2, px - L / 2, py - L1 / 2, Color.White);
                    seg3.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    Segmento seg4 = new Segmento(px + L / 2, py + L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                    seg4.EncenderSegmento(grafico);
                    Thread.Sleep(1000);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    xf = px - L / 2;
                    yf = py - L1 / 2;
                    xf2 = px + L / 2;
                    yf2 = py + L1 / 2;
                    ModelosMat.x1 = xf;
                    ModelosMat.x2 = xf2;
                    ModelosMat.y1 = yf;
                    ModelosMat.y2 = yf2;
                    cmbFractales_SelectedIndexChanged(null, null);
                    //btnFractal_Click(null, null);
                    break;

                case "Julia":
                    Lx = 0;
                    Ly = 0;
                    Lx = ModelosMat.x2 - ModelosMat.x1;
                    Ly = ModelosMat.y2 - ModelosMat.y1;
                    L = Lx / 15;
                    L1 = Ly / 15;
                    lblLX1.Text = Convert.ToString(L);
                    lblX2.Text = Convert.ToString(L1);
                    Segmento seg5 = new Segmento(px - L / 2, py + L1 / 2, px + L / 2, py + L1 / 2, Color.White);
                    seg5.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    Segmento seg6 = new Segmento(px - L / 2, py - L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                    seg6.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    Segmento seg7 = new Segmento(px - L / 2, py + L1 / 2, px - L / 2, py - L1 / 2, Color.White);
                    seg7.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    Segmento seg8 = new Segmento(px + L / 2, py + L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                    seg8.EncenderSegmento(grafico);
                    Thread.Sleep(1000);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    xf = px - L / 2;
                    yf = py - L1 / 2;
                    xf2 = px + L / 2;
                    yf2 = py + L1 / 2;
                    ModelosMat.x1 = xf;
                    ModelosMat.x2 = xf2;
                    ModelosMat.y1 = yf;
                    ModelosMat.y2 = yf2;
                    cmbFractales_SelectedIndexChanged(null, null);
                    //btnFractal_Click(null, null);
                    break;

                case "PuntosSierpinsky":
                    {
                        Circuenferencia aj1 = new Circuenferencia(0, 0, 0, Color.Blue);
                        aj1.radio = 0.2;
                        aj1.x0 = px;
                        aj1.y0 = py;
                        aj1.EncenderI(grafico);
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
                    } break;

                case "CuadradoPuntos":
                     int ab, bc, ac, per, sp, a = 0;
                        Segmento tripuntos = new Segmento();
                        Circuenferencia aj2 = new Circuenferencia();
                        aj2.radio = 0.2;
                        aj2.x0 = px;
                        aj2.y0 = py;
                        vx[poligonal] = px;
                        vy[poligonal] = py;
                        poligonal++;
                        aj2.c = Color.Blue;
                        aj2.EncenderI(grafico);
                        ViewPort.Image = grafico;

                        for (int i = 0; i < poligonal - 1; i++)
                        {
                            tripuntos.x0 = vx[i];
                            tripuntos.y0 = vy[i];
                            tripuntos.xf = vx[i + 1];
                            tripuntos.yf = vy[i + 1];
                            tripuntos.c = Color.Black;
                            tripuntos.EncenderSegmento(grafico);
                            ViewPort.Image = grafico;
                           
                            if (poligonal == 4)
                            {
                                tripuntos.x0 = vx[3];
                                tripuntos.y0 = vy[3];
                                tripuntos.xf = vx[0];
                                tripuntos.yf = vy[0];
                                tripuntos.c = Color.Black;
                                tripuntos.EncenderSegmento(grafico);
                                ViewPort.Image = grafico;
                                
                            }
                        }

                    break;
            }
        }

        //*********** FIN ***********


        private void btnVector_Click(object sender, EventArgs e)
        {
            Vector v = new Vector(10, 5, Color.Red);
            v.Encender(grafico);
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            /*Thread.Sleep(20);
            v.Apagar(grafico);
            ViewPort.Image = grafico;*/
        }

        private void btnCircunferencia_Click(object sender, EventArgs e)
        {
            /*Circuenferencia c = new Circuenferencia();
            c.x0 = 0;
            c.y0 = 0;
            c.radio = 3;
            c.c = Color.Red;
            c.EncCircunferencia(grafico);
            ViewPort.Image = grafico;
            c.x0 = 8;
            c.EncCircunferencia(grafico);
            ViewPort.Image = grafico;
            c.y0 =-5;
            c.EncCircunferencia(grafico);
            ViewPort.Image = grafico;*/

            opcion = "Circunferencia";
        }


        private void btnLazo_Click(object sender, EventArgs e)
        {
            Lazo l = new Lazo();
            l.x0 = 10;
            l.y0 = 5;
            l.radio = 3;
            l.c = Color.Blue;
            l.EncenderLazo(grafico);
            ViewPort.Image = grafico;
        }

        private void btnHipociclo_Click(object sender, EventArgs e)
        {
            Hipociclo h = new Hipociclo();
            h.x0 = 10;
            h.y0 = 5;
            h.radio = 3;
            h.c = Color.Blue;
            h.EncenderHipociclo(grafico);
            ViewPort.Image = grafico;
        }

        private void btnSegmento_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento(0, -5, 0, 5, Color.Blue);
            s.EncenderSegmento(grafico);
            ViewPort.Image = grafico;
        }

        private void btnPractica1_Click(object sender, EventArgs e)
        {
            Circuenferencia c = new Circuenferencia(5, -5, 3, Color.Red);
            c.Encender(grafico);
            ViewPort.Image = grafico;

            Lazo l = new Lazo(5, 5, 3,1, Color.Blue);
            l.Encender(grafico);
            ViewPort.Image = grafico;

            Hipociclo h = new Hipociclo(-5, 5, 3, Color.BlueViolet);
            h.Encender(grafico);
            ViewPort.Image = grafico;

            Segmento s = new Segmento(-5, -2, -5, -8, Color.Blue);
            s.Encender(grafico);
            ViewPort.Image = grafico;

            ViewPort.Refresh();
            Thread.Sleep(100);
            c.Apagar(grafico);
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            Thread.Sleep(100);
            l.Apagar(grafico);
            ViewPort.Image = grafico;
        }

        private void btnLetras_Click(object sender, EventArgs e)
        {
            /* Circuenferencia aa = new Circuenferencia();
             aa.radio = 2;
             aa.x0 = 4;
             aa.y0 = 5;
             aa.c = Color.Red;
             aa.Letraa(grafico);
             ViewPort.Image = grafico;
             */

            /*Circuenferencia ld = new Circuenferencia();
            ld.radio = 2;
            ld.x0 = 4;
            ld.y0 = 5;
            ld.c = Color.Red;
            ld.Letrad(grafico);
            ViewPort.Image = grafico;
            
            
            Circuenferencia lb = new Circuenferencia();
            lb.radio = 2;
            lb.x0 = 4;
            lb.y0 = 5;
            lb.c = Color.Red;
            lb.Letrab(grafico);
            ViewPort.Image = grafico; 
            

            Circuenferencia lc = new Circuenferencia();
            lc.radio = 2;
            lc.x0 = 4;
            lc.y0 = 5;
            lc.c = Color.Red;
            lc.Letrac(grafico);
            ViewPort.Image = grafico;
            
             
            Circuenferencia le = new Circuenferencia();
            le.radio = 2;
            le.x0 = 4;
            le.y0 = 5;
            le.c = Color.Red;
            le.Letrae(grafico);
            ViewPort.Image = grafico;
            
            Circuenferencia lf = new Circuenferencia();
            lf.radio = 2;
            lf.x0 = 4;
            lf.y0 = 5;
            lf.c = Color.Red;
            lf.Letraf(grafico);
            ViewPort.Image = grafico;
            
            Circuenferencia lg = new Circuenferencia();
            lg.radio = 2;
            lg.x0 = 4;
            lg.y0 = 5;
            lg.c = Color.Red;
            lg.Letrag(grafico);
            ViewPort.Image = grafico;
             

            Circuenferencia lh = new Circuenferencia();
            lh.radio = 2;
            lh.x0 = -5;
            lh.y0 = -2;
            lh.c = Color.Red;
            lh.Letrah(grafico);
            ViewPort.Image = grafico;
            

            Circuenferencia li = new Circuenferencia();
            li.radio = 0.2;
            li.x0 = -5;
            li.y0 = -2;
            li.c = Color.Red;
            li.Letrai(grafico);
            ViewPort.Image = grafico;
            */

            Segmento lk = new Segmento();
            lk.x0 = 2;
            lk.y0 = -2;
            lk.xf = 2;
            lk.yf = -8;
            lk.Letrak(grafico);
            ViewPort.Image = grafico;
        }

        private void btnPendiente_Click(object sender, EventArgs e)
        {
            double m1, m2, lx, ly;
            double x = 5, y = 3, x1 = 2, y1 = 2;
            Segmento st = new Segmento();
            st.x0 = x;
            st.y0 = y;
            st.xf = x1;
            st.yf = y1;
            st.c = Color.Violet;
            st.EncenderSegmento(grafico);
            ViewPort.Image = grafico;
            Circuenferencia cirt = new Circuenferencia();
            cirt.x0 = x1;
            cirt.y0 = y1;
            cirt.radio = Math.Sqrt(Math.Pow((x1 - x), 2) + (Math.Pow((y1 - y), 2)));
            cirt.c = Color.Violet;
            cirt.EncCircunferencia(grafico);
            ViewPort.Image = grafico;
            m1 = (y1 - y) / (x1 - x);
            m2 = -(1 / m1);
            //lblVer.Text = Convert.ToString(m1);

            Vector tangente = new Vector();
            if (m1 > 0 || m1 < 0 || m1 == 0)
            {
                for (double i = -10; i < 10; i = i + 0.002)
                {
                    lx = ((i - y) / m2 + x);
                    if (lx > -15 && lx < 15)
                    {
                        tangente.x0 = lx;
                        tangente.y0 = i;
                        tangente.c = Color.Violet;
                        tangente.Encender(grafico);
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
                        tangente.x0 = i;
                        tangente.y0 = ly;
                        tangente.c = Color.Violet;
                        tangente.Encender(grafico);
                        ViewPort.Image = grafico;
                    }
                }
            }
        }


        private void btnPoligono_Click(object sender, EventArgs e)
        {
            Poligono pl = new Poligono(-8, -2, 5, 7, Color.Violet);
            pl.EncPoligono(grafico);
            ViewPort.Image = grafico;
        }

        private void cmbParcial1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParcial1.SelectedIndex == 0)
            {
                for (int i = 0; i < 300; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(255 * (i - 300) / (0 - 300)) + (0 * (i - 0) / (300 - 0)),
                            (int)(255 * (i - 300) / (0 - 300)) + (10 * (i - 0) / (300 - 0)),
                            (int)(0 * (i - 300) / (0 - 300)) + (255 * (i - 0) / (300 - 0))));
                    }
                }
                ViewPort.Image = grafico;

                for (int i = 300; i < 600; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(0 * (i - 600) / (300 - 600)) + (255 * (i - 300) / (600 - 300)),
                            (int)(10 * (i - 600) / (300 - 600)) + (5 * (i - 300) / (600 - 300)),
                            (int)(255 * (i - 600) / (300 - 600)) + (0 * (i - 300) / (600 - 300))));
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbParcial1.SelectedIndex == 1)
            {
                for (int i = 0; i < 300; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(0 * (i - 300) / (0 - 300)) + (0 * (i - 0) / (300 - 0)),
                            (int)(20 * (i - 300) / (0 - 300)) + (255 * (i - 0) / (300 - 0)),
                            (int)(255 * (i - 300) / (0 - 300)) + (200 * (i - 0) / (300 - 0))));
                    }
                }
                ViewPort.Image = grafico;

                for (int i = 300; i < 600; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(0 * (i - 600) / (300 - 600)) + (0 * (i - 300) / (600 - 300)),
                            (int)(255 * (i - 600) / (300 - 600)) + (255 * (i - 300) / (600 - 300)),
                            (int)(200 * (i - 600) / (300 - 600)) + (0 * (i - 300) / (600 - 300))));
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbParcial1.SelectedIndex == 2)
            {
                for (int i = 0; i < 300; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(255 * (i - 300) / (0 - 300)) + (240 * (i - 0) / (300 - 0)),
                            (int)(10 * (i - 300) / (0 - 300)) + (255 * (i - 0) / (300 - 0)),
                            (int)(0 * (i - 300) / (0 - 300)) + (0 * (i - 0) / (300 - 0))));
                    }
                }
                ViewPort.Image = grafico;

                for (int i = 300; i < 600; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(240 * (i - 600) / (300 - 600)) + (0 * (i - 300) / (600 - 300)),
                            (int)(255 * (i - 600) / (300 - 600)) + (0 * (i - 300) / (600 - 300)),
                            (int)(0 * (i - 600) / (300 - 600)) + (10 * (i - 300) / (600 - 300))));
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbParcial1.SelectedIndex == 3)
            {
                for (int i = 0; i < 300; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(255 * (i - 300) / (0 - 300)) + (0 * (i - 0) / (300 - 0)),
                            (int)(255 * (i - 300) / (0 - 300)) + (10 * (i - 0) / (300 - 0)),
                            (int)(0 * (i - 300) / (0 - 300)) + (255 * (i - 0) / (300 - 0))));
                    }
                }
                ViewPort.Image = grafico;

                for (int i = 300; i < 600; i++)
                {

                    for (int j = 0; j < 400; j++)
                    {

                        grafico.SetPixel(i, j, Color.FromArgb(
                            (int)(0 * (i - 600) / (300 - 600)) + (255 * (i - 300) / (600 - 300)),
                            (int)(10 * (i - 600) / (300 - 600)) + (5 * (i - 300) / (600 - 300)),
                            (int)(255 * (i - 600) / (300 - 600)) + (0 * (i - 300) / (600 - 300))));
                    }
                }
                ViewPort.Image = grafico;
            }
        }

        private void cmbInterpolacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInterpolacion.SelectedIndex == 0)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.Blue);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbInterpolacion.SelectedIndex == 1)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 200; j++)
                    {
                        grafico.SetPixel(i, j, Color.Red);
                    }
                }
                ViewPort.Image = grafico;
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 200; j < 400; j++)
                    {
                        grafico.SetPixel(i, j, Color.Yellow);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbInterpolacion.SelectedIndex == 2)
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
                        grafico.SetPixel(i, j, Color.FromArgb((int)(255 * (j - 400) / (200 - 400)) + (255 * (j - 200) / (400 - 200)), (int)(255 * (j - 400) / (200 - 400)) + (0 * (j - 0) / (400 - 200)), (int)(0 * (j - 400) / (200 - 400)) + (0 * (j - 200) / (400 - 200))));

                    }
                }
                ViewPort.Image = grafico;
            }
        }

        private void btnVec_Click(object sender, EventArgs e)
        {
            double x = -15;
            double dx = 0.1;
            Vector v2 = new Vector();
            do
            {
                v2.x0 = x;
                v2.y0 = (225 - x * x) / 28;
                v2.c = Color.Blue;
                v2.Encender(grafico);
                ViewPort.Image = grafico;
                x = x + dx;

            } while (x <= 15);
        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {
            opcion = "Puntos";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double m, yn1, yn2;
            Circuenferencia c2 = new Circuenferencia();
            c2.x0 = px;
            c2.y0 = (225 - (px * px)) / 28;
            c2.radio = 0.3;
            c2.c = Color.Blue;
            c2.EncCircunferencia(grafico);
            ViewPort.Image = grafico;

            m = ((-2 * px) * 28) / Math.Pow(28, 2);

            Segmento sg = new Segmento();
            sg.segmento2(px, c2.y0, m, out yn1, out yn2);
            sg.x0 = -15;
            sg.y0 = yn1;
            sg.xf = 15;
            sg.yf = yn2;
            sg.c = Color.Blue;
            sg.EncenderSegmento(grafico);
            ViewPort.Image = grafico;
        }

        private void gRÁFICOS2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = tabControl;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = null;
            tpEjercicios.Parent = null;
            tpExamenes.Parent = null;
        }

        private void fRACTALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpFractales.Parent = tabControl;
            tpGraficos3d.Parent = null;
            tpEjercicios.Parent = null;
            tpExamenes.Parent = null;
        }

        private void gRÁFICOS3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = tabControl;
            tpEjercicios.Parent = null;
            tpExamenes.Parent = null;
        }

        private void btnSegmentoxy_Click(object sender, EventArgs e)
        {
            opcion = "Segmento";
        }

        private void btnCircunferenciaxy_Click(object sender, EventArgs e)
        {
            opcion = "Circulo";
        }

        private void btnLazoxy_Click(object sender, EventArgs e)
        {
            opcion = "Lazo";
        }

        private void btnHipocicloxy_Click(object sender, EventArgs e)
        {
            opcion = "Hipociclo";
        }

        private void btnPoligonoxy_Click(object sender, EventArgs e)
        {
            opcion = "Poligono";
        }

        private void cLASESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = null;
            tpEjercicios.Parent = tabControl;
            tpExamenes.Parent = null;
        }

        private void ViewPort_MouseMove(object sender, MouseEventArgs e)
        {
            double x = e.X;
            double y = e.Y;

            double a, b;
            a = Math.Round(ModelosMat.RealX(cx), 3);
            b = Math.Round(ModelosMat.RealY(cy), 3);

            cx = x;
            cy = y;

            toolStripStatusLabel.Text = " COORDENADAS: " + a.ToString() + "  /  " + b.ToString();

            // BORRADOR 
            if (opcion == "borrador")
            {
                dibujar(a, b);
            }
        }
        
        void dibujar(double x, double y)
        {
            Circuenferencia cb = new Circuenferencia();
            cb.x0 = x;
            cb.y0 = y;
            cb.c = Color.Violet;
            cb.radio = 0.5;
            cb.EncenderI(grafico);
            cb.radio = 0.4;
            cb.EncenderI(grafico);
            cb.radio = 0.3;
            cb.EncenderI(grafico);
            cb.radio = 0.2;
            cb.EncenderI(grafico);
            cb.radio = 0.1;
            cb.EncenderI(grafico);
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            Thread.Sleep(10);
            apagar(x, y);
        }


        void apagar(double x, double y)
        {
            Circuenferencia cb = new Circuenferencia();
            cb.x0 = x;
            cb.y0 = y;
            cb.c = Color.White;
            cb.radio = 0.5;
            cb.EncenderI(grafico);
            cb.radio = 0.4;
            cb.EncenderI(grafico);
            cb.radio = 0.3;
            cb.EncenderI(grafico);
            cb.radio = 0.2;
            cb.EncenderI(grafico);
            cb.radio = 0.1;
            cb.EncenderI(grafico);
            ViewPort.Image = grafico;
        }

        private void asignarcoordreales()
        {
            ModelosMat.x1 = -15;
            ModelosMat.x2 = 15;
            ModelosMat.y1 = -10;
            ModelosMat.y2 = 10;
        }

        // FRACTAL CANTOR
        void Cantor(Segmento s)
        {

            if (s.yf <= -10)
            return;

            s.yf -= 1.5;
            double d = (s.xf - s.x0) / 3;

            Segmento s1 = new Segmento(s.x0, s.yf, s.x0 + d, s.yf, Color.Green);
            s1.EncenderSegmento(grafico);
            ViewPort.Image = grafico;
            Segmento s2 = new Segmento(s.xf - d, s.yf, s.xf, s.yf, Color.Blue);
            s2.EncenderSegmento(grafico);
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            Cantor(s1);
            Cantor(s2);

        }

        private void btnPaleta_Click(object sender, EventArgs e)
        {
            paleta.ShowDialog();
        }

        private void btnCEntrecortada_Click(object sender, EventArgs e)
        {
            opcion = "CEntrecortada";
        }

        private void btnSEntrecortado_Click(object sender, EventArgs e)
        {
            opcion = "SEntrecortado";
        }

        private void btnCLlenada_Click(object sender, EventArgs e)
        {
            opcion = "CLlenada";
        }

        private void btnPAraña_Click(object sender, EventArgs e)
        {
            opcion = "PAraña";
        }

        private void btnParcial_Click(object sender, EventArgs e)
        {
            Circuenferencia c = new Circuenferencia();
            for (double i = 0; i < 2; i += 0.1)
            {
                c.x0 = 0;
                c.y0 = 0;
                c.radio = i;
                c.c = Color.Black;
                c.EncCircunferencia(grafico);
                ViewPort.Image = grafico;
            }
            Circuenferencia c1 = new Circuenferencia();
            for (double j = 2; j < 3; j += 0.1)
            {
                c1.x0 = 0;
                c1.y0 = 0;
                c1.radio = j;
                c1.c = Color.FromArgb(
                Convert.ToInt32((0 * (j - 3) / (2 - 3))
                + (5 * (j - 2) / (3 - 2))),
                Convert.ToInt32((255 * (j - 3) / (2 - 3))
                + (0 * (j - 2) / (3 - 2))),
                Convert.ToInt32((0 * (j - 3) / (2 - 3))
                + (0 * (j - 2) / (3 - 2))));
                c1.EncenderI(grafico);
                ViewPort.Image = grafico;
            }
        }

        private void cmbNumeros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNumeros.SelectedIndex == 0)
            {
                num = 3;
            }
            if (cmbNumeros.SelectedIndex == 1)
            {
                num = 4;
            }
            if (cmbNumeros.SelectedIndex == 2)
            {
                num = 5;
            }
            if (cmbNumeros.SelectedIndex == 3)
            {
                num = 6;
            }
            if (cmbNumeros.SelectedIndex == 4)
            {
                num = 7;
            }
            if (cmbNumeros.SelectedIndex == 5)
            {
                num = 8;
            }
            if (cmbNumeros.SelectedIndex == 6)
            {
                num = 9;
            }
            if (cmbNumeros.SelectedIndex == 7)
            {
                num = 10;
            }
            if (cmbNumeros.SelectedIndex == 8)
            {
                num = 11;
            }
            if (cmbNumeros.SelectedIndex == 9)
            {
                num = 12;
            }
        }

        private void btnLazoo_Click(object sender, EventArgs e)
        {

        }

        private void btnAnimacionLazo_Click(object sender, EventArgs e)
        {
            double w = -12, dw = 0.3;
            Lazo l = new Lazo();
            do
            {
                l.x0 = w;
                l.y0 = 0;
                l.radio = 2.5;
                l.c = Color.Blue;
                l.EncenderLazoRotar(grafico);
                ViewPort.Image = grafico;

                ViewPort.Refresh();
                Thread.Sleep(20);

                l.ApagarLazo(grafico);
                w += dw;
            } while (w <= 12);
        }

        private void btnAnimacion_Click(object sender, EventArgs e)
        {
            /*Circuenferencia c = new Circuenferencia(-3,1,1,Color.Beige);
            c.EncenderI(grafico);
            ViewPort.Image = grafico;

            Circuenferencia c1 = new Circuenferencia(7, 3, 4, Color.Beige);
            c1.EncenderI(grafico);
            ViewPort.Image = grafico;


            double pasox = -3;
            Circuenferencia c21 = new Circuenferencia();
            while (pasox <= 7) 
            {
                c21.x0 = pasox;
                c21.y0 = (1 * ((pasox - 7) / (-3 - 7))) + (3 * ((pasox + 3) / (7 + 3)));
                c21.radio = (1 * ((pasox - 7) / (-3 - 7))) + (4 * ((pasox + 3) / (7 + 3)));
                pasox += 0.1;
                c21.c = Color.Red;
                c21.EncenderI(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                c21.ApagarCircunferencia(grafico);

            }*/

            Circuenferencia c = new Circuenferencia(1, 1, 1, Color.Beige);
            c.EncenderI(grafico);
            ViewPort.Image = grafico;

            Circuenferencia c1 = new Circuenferencia(12, 3, 4, Color.Beige);
            c1.EncenderI(grafico);
            ViewPort.Image = grafico;


            double pasox = 1;
            Circuenferencia c21 = new Circuenferencia();
            while (pasox <= 12)
            {
                c21.x0 = pasox;
                c21.y0 = (1 * ((pasox - 12) / (1 - 12))) + (3 * ((pasox - 1) / (12 - 1)));
                c21.radio = (1 * ((pasox - 12) / (1 - 12))) + (4 * ((pasox - 1) / (12 - 1)));
                pasox += 0.1;
                c21.c = Color.FromArgb(Convert.ToInt32((250 * ((pasox - 12) / (1 - 12))) + (3 * ((pasox - 1) / (12 - 1)))),
                    Convert.ToInt32((0 * ((pasox - 12) / (1 - 12))) + (0 * ((pasox - 1) / (12 - 1)))),
                    Convert.ToInt32((255 * ((pasox - 12) / (1 - 12))) + (5 * ((pasox - 1) / (12 - 1)))));
                c21.EncenderI(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                c21.ApagarCircunferencia(grafico);

            }
        }

        private void btnAnimacion2_Click(object sender, EventArgs e)
        {
            double pasox = 7;
            Circuenferencia c = new Circuenferencia();


            while (pasox >= -3)
            {
                c.x0 = pasox;
                c.y0 = (3 * ((pasox + 3) / (7 + 3))) + (1 * ((pasox - 7) / (-3 - 7)));
                c.radio = (4 * ((pasox + 3) / (7 + 3))) + (1 * ((pasox - 7) / (-3 - 7)));
                pasox -= 0.1;
                c.c = Color.Blue;
                c.EncenderI(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                c.ApagarCircunferencia(grafico);
            }
        }

        private void btnExamen_Click(object sender, EventArgs e)
        {

            double x = -15;
            double dx = 0.1;
            Vector v2 = new Vector();
            do
            {
                v2.x0 = x;
                v2.y0 = (7) * Math.Sin(x / 3);
                v2.c = Color.Blue;
                v2.Encender(grafico);
                ViewPort.Image = grafico;
                x = x + dx;

            } while (x <= 15);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            opcion = "Examen";
        }

        private void btnCurvasAjuste_Click(object sender, EventArgs e)
        {
            opcion = "Curvas de Ajuste";
        }

        private void cmbCurvasAjuste_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbCurvasAjuste.SelectedIndex == 0)
            {
                double t = vPoligonal[0].x0;
                double dt = 0.001;
                Vector v = new Vector();
                v.c = Color.Blue;

                while (t <= vPoligonal[poligonal-1].x0)
                {
                    v.x0 = t;
                    //v.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    v.y0 = ModelosMat.Lagrange1(t, vPoligonal, poligonal);
                    v.Encender(grafico);
                    ViewPort.Image = grafico;
                    t = t + dt;
                }
            }

            if (cmbCurvasAjuste.SelectedIndex == 1)
            {
                double bt = 0;
               // double xbi, ybi;
                Vector vb = new Vector();
                while (bt <= 1)
                {
                    //ModelosMat.Bezier(vx, vy, poligonal, bt, out xbi, out ybi);

                    vb.x0 = ModelosMat.Bezier1(vPoligonal, poligonal, bt).x0;
                    vb.y0 = ModelosMat.Bezier1(vPoligonal, poligonal, bt).y0;
                    
                    /*vb.x0 = xbi;
                    vb.y0 = ybi;*/
                    vb.c = Color.Violet;
                    vb.Encender(grafico);
                    ViewPort.Image = grafico;
                    bt = bt + 0.001;
                }

            }

            if (cmbCurvasAjuste.SelectedIndex == 2)
            {
                for (int i = 0; i < poligonal - 1; i++)
                {
                    Segmento seg = new Segmento();
                    seg.x0 = vPoligonal[i].x0;
                    seg.y0 = vPoligonal[i].y0;
                    seg.xf = vPoligonal[i + 1].x0;
                    seg.yf = vPoligonal[i + 1].y0;
                    /*seg.x0 = vx[i];
                    seg.y0 = vy[i];
                    seg.xf = vx[i + 1];
                    seg.yf = vy[i + 1];*/
                    seg.c = Color.Black;
                    seg.EncenderSegmento(grafico);
                }
                ViewPort.Image = grafico;
            }

            if (cmbCurvasAjuste.SelectedIndex == 3)
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
                    // y me devuelve su recorrido en YS

                    /* Paleta paleta = new Paleta(1);
                     int trozo = 0;*/
                    for (int i = 0; i < xs.Length; i++)
                    {
                        /*
                        if (vectorySpline[2] == ys[i])
                        {
                            MessageBox.Show(ys[i].ToString());
                            trozo = trozo + 1;
                        }
                        */
                        Vector vspline = new Vector();

                        vspline.x0 = xs[i];
                        vspline.y0 = ys[i];
                        vspline.c = Color.Green;
                        vspline.Encender(grafico);
                        ViewPort.Image = grafico;
                        vspline = null;
                    }
                }
            }

        }

        private void btnNuevosPuntos_Click(object sender, EventArgs e)
        {
            if (btnNuevosPuntos.Enabled == true)
            {
                poligonal = 0;
            }
        }

        private void btnGrange_Click(object sender, EventArgs e)
        {
            Segmento sg = new Segmento();
            for (int i = 1; i < poligonal; i++)
            {
                sg.x0 = vx[0];
                sg.y0 = vy[0];
                sg.xf = vx[i];
                sg.yf = vy[i];
                sg.c = Color.Black;
                sg.EncenderSegmento(grafico);
                ViewPort.Image = grafico;
            }
        }

        private void btnSumaVectores_Click(object sender, EventArgs e)
        {
            Segmento seg1 = new Segmento(-15, 0, 15, 0, paleta.Color);
            seg1.EncenderSegmento(grafico);
            ViewPort.Image = grafico;
            Segmento seg2 = new Segmento(0, 10, 0, -10, paleta.Color);
            seg2.EncenderSegmento(grafico);
            ViewPort.Image = grafico;

            opcion = "Vectores";
        }

        private void eXAMENESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = null;
            tpEjercicios.Parent = null;
            tpExamenes.Parent = tabControl;

        }


        private void cmbLetras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLetras.SelectedIndex == 0)
            {
                opcion = "f";
            }
            if (cmbLetras.SelectedIndex == 1)
            {
                opcion = "h";
            }
            if (cmbLetras.SelectedIndex == 2)
            {
                opcion = "q";
            }
             if (cmbLetras.SelectedIndex == 3)
            {
                opcion = "Teta";
            }
             if (cmbLetras.SelectedIndex == 4)
             {
                 opcion = "m";
             }
        }

        private void btnAlgebraVectorial_Click(object sender, EventArgs e)
        {
            Segmento seg1 = new Segmento(-15, 0, 15, 0, paleta.Color);
            seg1.EncenderSegmento(grafico);
            ViewPort.Image = grafico;
            Segmento seg2 = new Segmento(0, 10, 0, -10, paleta.Color);
            seg2.EncenderSegmento(grafico);
            ViewPort.Image = grafico;

            opcion = "Vectores";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Vector vec = new Vector();
                for (double i = -15; i < 15; i += 0.01)
                {
                    vec.x0 = i;
                    vec.y0 = Math.Pow(2, i);
                    vec.c = Color.Blue;
                    vec.Encender(grafico);
                    ViewPort.Image = grafico;
                    vec.x0 = i;
                    vec.y0 = (1 
                        + 0.693*i 
                        + (((Math.Pow(0.693, 2)) / 2)*(Math.Pow(i, 2)))
                        + (((Math.Pow(0.693, 3)) / 6)*(Math.Pow(i, 3)))
                        + (((Math.Pow(0.693, 4)) / 24)*(Math.Pow(i, 4)))
                         + (((Math.Pow(0.693, 5)) / 120) * (Math.Pow(i, 5))));
                    vec.c = Color.Purple;
                    vec.Encender(grafico);
                    ViewPort.Image = grafico;
                }
            }

            if (comboBox1.SelectedIndex == 1)
            {
                Vector vec = new Vector();
                for (double i = -15; i < 15; i += 0.01)
                {
                    vec.x0 = i;
                    //vec.y0 = 0 + i + 0 - (1/6) *Math.Pow(i, 3) + 0 + (1 / 120)*Math.Pow(i, 5);
                    vec.y0 = Math.Sin(i);
                    vec.c = Color.Purple;
                    vec.Encender(grafico);
                    ViewPort.Image = grafico;
                    vec.x0 = i;
                    //vec.y0 = 0 + i + 0 - (1/6) *Math.Pow(i, 3) + 0 + (1 / 120)*Math.Pow(i, 5);
                    vec.y0 = 0 + i + 0 - Math.Pow(i, 3) / 6 + 0 + Math.Pow(i, 5) / 120;
                    vec.c = Color.Blue;
                    vec.Encender(grafico);
                    ViewPort.Image = grafico;
                }
            }

            if (comboBox1.SelectedIndex == 2)
            {
                Vector vec = new Vector();
                for (double i = -15; i < 15; i += 0.01)
                {
                    vec.x0 = i;
                    vec.y0 = (3 * (Math.Cos(i/3)));
                     vec.c = Color.Blue;
                    vec.Encender(grafico);
                    vec.x0 = i;
                    vec.y0 = (3 - ((Math.Pow(i, 2)) / 6)
                        + ((Math.Pow(i, 4)) / 648)
                        - ((Math.Pow(i, 6)) / 174960)
                        + ((Math.Pow(i, 8)) / 88179840)
                        - ((Math.Pow(i, 10)) / 71425670400)); 
                    vec.c = Color.Red;
                    vec.Encender(grafico);
                    ViewPort.Image = grafico;
                }
            }
        }

        private void cmbPaleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int colort = 0;
            if (cmbPaleta.SelectedIndex == 0)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(i, 2) + Math.Pow(j, 2))%15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;   
            }

            if (cmbPaleta.SelectedIndex == 1)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        //colort = Convert.ToInt32(((Math.Cosh(i) + 1) + (Math.Sinh(j) + 1)) % 15);
                        colort = Convert.ToInt32(((Math.Sin(i) + 1) * 5 + (Math.Sin(j) + 1) * 5) % 15);
                       // colort = Convert.ToInt32(((Math.Cos(i)+2)+((Math.Sin(j)+9))) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbPaleta.SelectedIndex == 2)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((Math.Sqrt(Math.Pow((i * j), 2))) + (i + j + Math.Sin(j))) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbPaleta.SelectedIndex == 3)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((i + 2) * j) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbPaleta.SelectedIndex == 4)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((Math.Tanh(i) + 15) * 5 + (Math.Sin(j) + 1) * 5) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            
            if (cmbPaleta.SelectedIndex == 5)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow((Math.Tanh(i)), 2) + (Math.Pow(j, 2) * Math.Pow(i, 2)) % 15));
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbPaleta.SelectedIndex == 6)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 2) * Math.Pow(i, 2) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbPaleta.SelectedIndex == 7)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 5) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbPaleta.SelectedIndex == 8)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 3) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbPaleta.SelectedIndex == 9)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((j + i) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                    }
                }
                ViewPort.Image = grafico;
            }
        }

        private void btnAnimacionFigura_Click(object sender, EventArgs e)
        {
            Segmento s1 = new Segmento(-15,2,-4,2,Color.Blue);
            s1.EncenderSegmento(grafico);
            ViewPort.Image = grafico;

            Segmento s2 = new Segmento(-4,2,3,-7,Color.Blue);
            s2.EncenderSegmento(grafico);
            ViewPort.Image = grafico;

            Segmento s3 = new Segmento(3,-7,15,-7,Color.Blue);
            s3.EncenderSegmento(grafico);
            ViewPort.Image = grafico;



        }

        private void button2_Click(object sender, EventArgs e)
        {

            double w = 0;
            do
            {
                Lazo l = new Lazo();
                l.x0 = 5;
                l.y0 = 2;
                l.radio = 4;
                l.alfa = w;
                l.c = Color.Blue;
                l.EncenderLazoRotar(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                Thread.Sleep(10);
                l.ApagarLazoRotar(grafico);
                w+= 0.2;
             } while (w<=2*Math.PI);
        }

        private void btnPaisajeFractal_Click(object sender, EventArgs e)
        {
            double w=0.06, dw=0.05;
            Circuenferencia c = new Circuenferencia(12,7,1,Color.Aqua);
           
            do
            {
                c.x0 = 12;
                c.y0 = 7;
                c.radio = w;
                c.c = Color.White;
                c.EncenderI(grafico);
                ViewPort.Image = grafico;
                w += dw;
            } while (w<=1.5);

            w = 1.5;
            do
            {
                c.radio = w;
                c.c = Color.FromArgb(Convert.ToInt32((255 * ((w - 3) / (1.5 - 3))) + (60 * ((w - 1.5) / (3 - 1.5)))),
                    Convert.ToInt32((255 * ((w - 3) / (1.5 - 3))) + (60 * ((w - 1.5) / (3 - 1.5)))),
                    Convert.ToInt32((255 * ((w - 3) / (1.5 - 3))) + (60 * ((w - 1.5) / (3 - 1.5)))));
                c.EncenderI(grafico);
                ViewPort.Image = grafico;
                w += dw;
            } while (w <= 3);

            w = 3;
            do
            {
                c.radio = w;
                c.c = Color.FromArgb(Convert.ToInt32((50 * ((w - 9) / (3 - 9))) + (0 * ((w - 3) / (9 - 3)))),
                   Convert.ToInt32((50 * ((w - 9) / (3 - 9))) + (0 * ((w - 3) / (9 - 3)))),
                    Convert.ToInt32((50 * ((w - 9) / (3 - 9))) + (0 * ((w - 3) / (9 - 3)))));
                c.EncenderI(grafico);
                ViewPort.Image = grafico;
                w += dw;
            } while (w <= 9);

            w=0;
            dw = Math.PI / 6;
            Segmento s = new Segmento();
            s.x0 = -8;
            s.y0 = 7;
            do
            {
                s.xf = s.x0 + (0.6) * Math.Cos(w);
                s.yf = s.y0 + (0.6) * Math.Sin(w);
                s.c = Color.FromArgb(20, 20, 255);
                s.EncenderSegmento(grafico);
                ViewPort.Image = grafico;
                w += dw;
            } while (w<(2*Math.PI));

            w = 0;
            dw = Math.PI / 6;
            s.x0 = -5;
            s.y0 = 6;
            do
            {
                s.xf = s.x0 + (0.6) * Math.Cos(w);
                s.yf = s.y0 + (0.6) * Math.Sin(w);
                s.c = Color.FromArgb(102, 178, 255);
                s.EncenderSegmento(grafico);
                ViewPort.Image = grafico;
                w += dw;
            } while (w < (2 * Math.PI));

            w = 0;
            dw = Math.PI / 6;
            s.x0 = 2;
            s.y0 = 5;
            do
            {
                s.xf = s.x0 + (0.6) * Math.Cos(w);
                s.yf = s.y0 + (0.6) * Math.Sin(w);
                s.c = Color.FromArgb(255, 255, 204);
                s.EncenderSegmento(grafico);
                ViewPort.Image = grafico;
                w += dw;
            } while (w < (2 * Math.PI));
        }

      

        private void btnFondo_Click(object sender, EventArgs e)
        {
            ViewPort.BackColor = Color.Black;
        }

        private void btnArbol_Click(object sender, EventArgs e)
        {
            Fractal arbol = new Fractal(2, -3, 4, Color.White, Math.PI / 2, Math.PI / 6);
            arbol.ArbolF(grafico);
            ViewPort.Image = grafico;
        }

        private void cmbNumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNumero.SelectedIndex == 0)
            {
                opcion = "1";
            }

            if (cmbNumero.SelectedIndex == 1)
            {
                opcion = "2";
            }
            
            if (cmbNumero.SelectedIndex == 2)
            {
                opcion = "3";
            }

            if (cmbNumero.SelectedIndex == 3)
            {
                opcion = "4";
            }

            if (cmbNumero.SelectedIndex == 4)
            {
                opcion = "5";
            }

            if (cmbNumero.SelectedIndex == 5)
            {
                opcion = "6";
            }

            if (cmbNumero.SelectedIndex == 6)
            {
                opcion = "7";
            }

            if (cmbNumero.SelectedIndex == 7)
            {
                opcion = "8";
            }

            if (cmbNumero.SelectedIndex == 8)
            {
                opcion = "9";
            }

        }

        private void btnBorrador_Click(object sender, EventArgs e)
        {
            opcion = "Borrador";
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            Circuenferencia cir = new Circuenferencia(3, 2, 0.1, Color.Blue);
            vx[0] = cir.x0;
            vy[0] = cir.y0;
            cir.EncenderI(grafico);
            ViewPort.Image = grafico;

            Circuenferencia cir1 = new Circuenferencia(4, 1, 0.1, Color.Blue);
            vx[1] = cir1.x0;
            vy[1] = cir1.y0;
            cir1.EncenderI(grafico);
            ViewPort.Image = grafico;
            Circuenferencia cir2 = new Circuenferencia(5, 3, 0.1, Color.Blue);
            vx[2] = cir2.x0;
            vy[2] = cir2.y0;
            cir2.EncenderI(grafico);
            ViewPort.Image = grafico;


            double tl = vx[0];
            double dtl = 0.1;
            Vector v = new Vector();

            while (tl <= vx[2])
            {
                v.x0 = tl;
                v.y0 = ModelosMat.Lagrange(tl, vx, vy, 3);
                Circuenferencia ci = new Circuenferencia();
                ci.radio = (2 * (tl - vx[2]) / (vx[0] - vx[2])) + (3 * (tl - vx[0]) / (vx[2] - vx[0]));
                ci.x0 = v.x0;
                ci.y0 = v.y0;
                ci.c = Color.Blue;
                ci.EncenderI(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                Thread.Sleep(10);
                ci.ApagarCircunferencia(grafico);
                tl = tl + dtl;

            }

        }

        private void cmbFractales_SelectedIndexChanged(object sender, EventArgs e)
        {
                int sx, sy, colorF;
                double x, y;
                Fractal fm = new Fractal();

                if (cmbFractales.SelectedIndex == 0)
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
                            ModelosMat.RealXY(sx, sy, out x, out y);
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

                if (cmbFractales.SelectedIndex == 1)
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
                            ModelosMat.RealXY(sx, sy, out x, out y);
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

                if (cmbFractales.SelectedIndex == 2)
                {
                    Fractal sp = new Fractal();
                    sp.c = Color.Blue;

                    if (poligonal != 0)
                    {
                        sp.Dibujar_Sierpinski(Ax, Ay, Bx, By, Cx, Cy, contadorSierpinsky,grafico);
                        contadorSierpinsky++;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese los Puntos");
                    }
                    ViewPort.Image = grafico;
                }

                if (cmbFractales.SelectedIndex == 3)
                {
                    /*Fractal cantor = new Fractal();
                    cantor.c = Color.Blue;
                    ViewPort.Image = grafico;

                    Segmento seg = new Segmento(-15, 9, 15, 9, Color.Red);
                    seg.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    cantor.Cantor(seg,grafico);*/

                    Segmento seg = new Segmento(-10, 9, 10, 9, Color.Red);
                    seg.EncenderSegmento(grafico);
                    ViewPort.Image = grafico;
                    Cantor(seg);
                   
                }
        }

        

        private void chkPaleta0_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaleta0.Checked==true)
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

        private void btnPuntosSierpinski_Click(object sender, EventArgs e)
        {
            opcion = "PuntosSierpinsky";
            contadorSierpinsky = 0;
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
                    ModelosMat.RealXY(i, j, out x, out y);
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


        public Bitmap CrearOndaInterferencia(double tp)
        {
            int  z, z1, z2;
            grafico = new Bitmap(600, 400);

            double x, y, w1 = 1.5, w2 = 2, d1, d2, v = 9.3;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    ModelosMat.RealXY(i, j, out x, out y);
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
            int  z, z1;
            double x, y, d, w = 1.5, v = 9.3;
            grafico = new Bitmap(600, 400);

            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    z1 = 0;

                    for (int l = 0; l <= 20; l++)
                    {
                        ModelosMat.RealXY(i, j, out x, out y);
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

        private void cmbOnda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOnda.SelectedIndex==0)
            {
                //ONDA TIEMPO REAL
                int z, tp = 2;
                double x, y, w = 1.5, d, v = 9.3;
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {

                        ModelosMat.RealXY(i, j, out x, out y);
                        d = Math.Sqrt((x * x) + (y * y));
                        double k = w * (d - tp * v);
                        z = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);
                        grafico.SetPixel(i, j, paleta0[z]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbOnda.SelectedIndex == 1)
            {
                //ONDA INTERFERENCIA
                int tp = 1, z, z1, z2;
                double x, y, w1 = 1.5, w2 = 2, d1, d2, v = 9.3;
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        ModelosMat.RealXY(i, j, out x, out y);
                        d1 = Math.Sqrt((Math.Pow((x + 4), 2)) + (y * y));
                        double k = w1 * (d1 - tp * v);
                        z1 = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);

                        d2 = Math.Sqrt((Math.Pow((x - 4), 2)) + (y * y));
                        k = w2 * (d2 - tp * v);
                        z2 = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);

                        z = Convert.ToInt32(z1 + z2) % 14;
                        grafico.SetPixel(i, j, paleta1[z]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbOnda.SelectedIndex == 2)
            {
                double tp;
                for (int i = 1; i < 18; i++)
                {
                    tp = i * 0.05;
                    mafv[i] = CrearOnda(tp);
                }
            }

            if (cmbOnda.SelectedIndex == 3)
            {
                double tp;

                for (int i = 1; i < 18; i++)
                {
                    tp = i * 0.05;
                    mafv[i] = CrearOndaInterferencia(tp);
                }
            }

            if (cmbOnda.SelectedIndex == 4)
            {
                int tp = 1, z, z1;
                double x, y, d, w=1.5, v = 9.3;

                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        z1 = 0;

                        for (int l = 0; l <= 20; l++)
                        {
                            ModelosMat.RealXY(i, j, out x, out y);
                            d = (Math.Sqrt(Math.Pow((x - 10 + l), 2) + Math.Pow(y - 2, 2)));
                            double k = w * (d - (tp * v));
                            z = Convert.ToInt32(Math.Abs((Math.Sin(k)) + 1) * 7.5);
                            z1 = (z1 + z) %15;
                        }
                        grafico.SetPixel(i, j, paleta2[z1]);
                    }
                }
                ViewPort.Image = grafico;
            }

            if (cmbOnda.SelectedIndex == 5)
            {
                double tp;

                for (int i = 1; i < 18; i++)
                {
                    tp = i * 0.05;
                    mafv[i] = CrearOndaHuygens(tp);
                }
            }
        }

        private void btnFotograma_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 1; i < 18; i++)
                {
                    ViewPort.Image = mafv[i];
                    ViewPort.Refresh();
                    Thread.Sleep(50);
                }
            }

        }

        private void btnOnda_Click(object sender, EventArgs e)
        {
            int tp = 1, z = 0, z1;
            double x, y, w1 = 2,  d1, v = 9.3;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 400; j < 400; j++)
                {
                    for (int l = 0; l < 20; l++)
                    {
                        ModelosMat.RealXY(i, j, out x, out y);
                        d1 = Math.Sqrt((Math.Pow((x - 10 + l), 2)) + (Math.Pow((x + 2), 2)));
                        double k = w1 * (d1 - tp * v);
                        z1 = Convert.ToInt32((Math.Sin(k)) * 7.5);
                        z = (z1 + z) *(15/42);
                    }
                   
                    grafico.SetPixel(i, j, paleta2[z]);
                }
            }
                ViewPort.Image = grafico;
            

        }

        private void btnSegmento3D_Click(object sender, EventArgs e)
        {
            Segmento3D S3D = new Segmento3D(0,0,0,14,0,0,Color.Black);
            S3D.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
            S3D.xf = 0;
            S3D.yf = 8;
            S3D.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
            S3D.yf = 0;
            S3D.zf = 8;
            S3D.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

        }

        private void btnCubo_Click(object sender, EventArgs e)
        {
            Segmento3D s1 = new Segmento3D();

            s1.x0=3;
            s1.y0=-5;
            s1.z0=-1;
            s1.xf=7;
            s1.yf=-5;
            s1.zf=-1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

            s1.x0=7;
            s1.y0=-5;
            s1.z0=-1;
            s1.xf=7;
            s1.yf=-1;
            s1.zf=-1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

            s1.x0=7;
            s1.y0=-1;
            s1.z0=-1;
            s1.xf=3;
            s1.yf=-1;
            s1.zf=-1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

            s1.x0=3;
            s1.y0=-5;
            s1.z0=-1;
            s1.xf=3;
            s1.yf=-1;
            s1.zf=-1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

            s1.x0=3;
            s1.y0=-5;
            s1.z0=-1;
            s1.xf=3;
            s1.yf=-5;
            s1.zf=3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;
          
             s1.x0=3;
            s1.y0=-1;
            s1.z0=3;
            s1.xf=3;
            s1.yf=-1;
            s1.zf=-1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

             s1.x0=3;
            s1.y0=-5;
            s1.z0=3;
            s1.xf=3;
            s1.yf=-1;
            s1.zf=3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

             s1.x0=7;
            s1.y0=-5;
            s1.z0=3;
            s1.xf=7;
            s1.yf=-5;
            s1.zf=-1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

             s1.x0=7;
            s1.y0=-1;
            s1.z0=3;
            s1.xf=7;
            s1.yf=-1;
            s1.zf=-1;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

             s1.x0=7;
            s1.y0=-5;
            s1.z0=3;
            s1.xf=3;
            s1.yf=-5;
            s1.zf=3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

             s1.x0=7;
            s1.y0=-1;
            s1.z0=3;
            s1.xf=3;
            s1.yf=-1;
            s1.zf=3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;

             s1.x0=7;
            s1.y0=-5;
            s1.z0=3;
            s1.xf=7;
            s1.yf=-1;
            s1.zf=3;
            s1.c = Color.Blue;
            s1.EncSegmento3D(grafico);
            ViewPort.Image=grafico;
        }

        private void btnCuboCortado_Click(object sender, EventArgs e)
        {
            Segmento3D s1 = new Segmento3D();

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
           
            s1.x0 =0 ;
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

            s1.x0 =0 ;
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

        private void btnCurva_Click(object sender, EventArgs e)
        {
            
            Curva3D c3d = new Curva3D();
            c3d.c = Color.Violet;

            for (double i = 0.5; i <= 1.5; i += 0.3)
            {
                c3d.x0 = 3;
                c3d.y0 = -2;
                c3d.z0 = -5;
                c3d.b = 1*i*0.25;
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
               c3d.b = 1 * i*0.25;
               c3d.EncenderCurva3D(grafico);
               ViewPort.Image = grafico;
               ViewPort.Refresh();
               Thread.Sleep(200);
               c3d.ApagarCurva3D(grafico);
               ViewPort.Image = grafico;
           }

          /*
               Curva3D C3D = new Curva3D();
               C3D.x0=0;
               C3D.z0=0;
               C3D.z0=0;
               C3D.c = Color.Blue;
               C3D.EncenderCurva3D(grafico);
               ViewPort.Image = grafico;
               ViewPort.Refresh();
               Thread.Sleep(20);
               C3D.ApagarCurva3D(grafico);
               ViewPort.Image = grafico;
           */

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            Curva3D c3d = new Curva3D();
            c3d.EncenderCurva3D(grafico);
            ViewPort.Image = grafico;
                
                
        }

        private void cmbEspiralRotar_SelectedIndexChanged(object sender, EventArgs e)
        {
            double w = 0;
            Curva3D c3d = new Curva3D();

            
            if (cmbEspiralRotar.SelectedIndex == 0)
            {
                do
                {
                    c3d.x0 = 2;
                    c3d.y0 = -2;
                    c3d.z0 = 5;
                    c3d.a = 4;
                    c3d.b = 0.333;
                    c3d.eje = 1;
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

            if (cmbEspiralRotar.SelectedIndex == 1)
            {
                do
                {
                    c3d.x0 = 2;
                    c3d.y0 = -2;
                    c3d.z0 = 5;
                    c3d.a = 4;
                    c3d.b = 0.333;
                    c3d.eje = 2;
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

            if (cmbEspiralRotar.SelectedIndex == 2)
            {
                do
                {
                    c3d.x0 = 2;
                    c3d.y0 = -2;
                    c3d.z0 = 5;
                    c3d.a = 4;
                    c3d.b = 0.333;
                    c3d.eje = 3;
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
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Superficie s = new Superficie(2,3,-1,1,1,1, Color.Violet,0);
            s.EncSuperficie(grafico);
            ViewPort.Image = grafico;
        }

        private void cmbSuperficie_SelectedIndexChanged(object sender, EventArgs e)
        {
            double w = 0;
            if (cmbSuperficie.SelectedIndex == 0)
            {
               do
               {
                    Superficie s = new Superficie();
                    s.x0=2;
                    s.y0=3;
                    s.z0=-1;
                   s.gama = w; 
                   s.eje=eje;
                    s.tipo=0;
                    s.tipom = 0;
                    s.c = Color.Blue;
                    s.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                  ViewPort.Refresh();
                  Thread.Sleep(200);
                  s.ApagarSuperficie(grafico);
                  ViewPort.Image = grafico;
                  w += 0.2;
                } while (w<=2*Math.PI);
                
            }

            if (cmbSuperficie.SelectedIndex == 1)
            {

                do
                {
                    Superficie s = new Superficie();
                    s.x0 = 2;
                    s.y0 = 3;
                    s.z0 = -1;
                    s.gama = w;
                    s.eje = eje;
                    s.tipo = 1;
                    s.c = Color.Blue;
                    s.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);
            }

            if (cmbSuperficie.SelectedIndex == 2)
            {
                Superficie ts = new Superficie();
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
                    ts.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    ts.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);

            }

            if (cmbSuperficie.SelectedIndex == 3)
            {

                do
                {
                    Superficie s = new Superficie();
                    s.x0 = 2;
                    s.y0 = 0;
                    s.z0 = 7;
                    s.gama = w;
                    s.eje = eje;
                    s.tipo = 3;
                    s.c = Color.Blue;
                    s.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);
            }
            if (cmbSuperficie.SelectedIndex == 4)
            {

                do
                {
                    Superficie s1 = new Superficie();
                    s1.x0 = 2;
                    s1.y0 = 0;
                    s1.z0 = 7;
                    s1.gama = w;
                    s1.eje = eje;
                    s1.tipo = 4;
                    s1.c = Color.Blue;
                    s1.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s1.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);


            }
            if (cmbSuperficie.SelectedIndex == 5)
            {

                do
                {
                    Superficie s1 = new Superficie();
                    s1.x0 = 2;
                    s1.y0 = 0;
                    s1.z0 = 7;
                    s1.gama = w;
                    s1.eje = eje;
                    s1.tipo = 5;
                    s1.c = Color.Blue;
                    s1.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s1.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);


            }
            if (cmbSuperficie.SelectedIndex == 6)
            {

                do
                {
                    Superficie s1 = new Superficie();
                    s1.x0 = 2;
                    s1.y0 = 0;
                    s1.z0 = 7;
                    s1.gama = w;
                    s1.eje = eje;
                    s1.tipo = 6;
                    s1.c = Color.Blue;
                    s1.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s1.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);


            }
            if (cmbSuperficie.SelectedIndex == 7)
            {
                do
                {
                    Superficie s = new Superficie();
                    s.x0 = 2;
                    s.y0 = 3;
                    s.z0 = -1;
                    s.gama = w;
                    s.eje = eje;
                    s.tipo = 7;
                   // s.tipom = 0;
                    s.c = Color.Blue;
                    s.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    s.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);

            }
            if (cmbSuperficie.SelectedIndex == 8)
            {
                Superficie s = new Superficie(); 
                s.tipo = 8; 
                s.c = Color.Blue; 
                s.EncSuperficie(grafico); 
                ViewPort.Image = grafico;
            }
            if (cmbSuperficie.SelectedIndex == 9)
            {
                Superficie ts = new Superficie();
                do
                {
                    //Superficie ts = new Superficie();
                    ts.x0 = 2;
                    ts.y0 = 2;
                    ts.z0 = -2;
                    ts.tipo = 9;
                    ts.gama = w;
                    ts.eje = eje;
                    ts.radio = 3;
                    ts.radio1 = 1;
                    ts.c = Color.Blue;
                    ts.EncSuperficie(grafico);
                    ViewPort.Image = grafico;
                    ViewPort.Refresh();
                    Thread.Sleep(200);
                    ts.ApagarSuperficie(grafico);
                    ViewPort.Image = grafico;
                    w += 0.2;
                } while (w <= 2 * Math.PI);

            } 
            if (cmbSuperficie.SelectedIndex == 10)
            {
                Superficie ts = new Superficie();
                ts.x0 = 2;
                ts.y0 = 2;
                ts.z0 = -5;
                ts.tipo = 2;
                ts.gama = w;
                ts.eje = eje;
                ts.radio = 3;
                ts.radio1 = 1;
                ts.c = Color.Blue;
                ts.EncSuperficie(grafico);
                ViewPort.Image = grafico;
                
                for (int j = 0; j < 3; j++)
                {
                    double tp;
                    for (int i = 0; i < 10; i++)
                    {
                        tp = i * 0.05;
                        Superficie s = new Superficie();
                        s.tipo = 10;
                        s.c = Color.Blue;
                        s.EncenderSuperOnda(grafico, tp);
                        ViewPort.Image = grafico;

                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        s.ApagarSuperOnda(grafico, tp);
                        ViewPort.Image = grafico;
                        ts.EncSuperficie(grafico);
                        ViewPort.Image = grafico;

                    }

                }


            }

            if (cmbSuperficie.SelectedIndex == 11)
            {
                Superficie s = new Superficie();
                do
                {
                    s.eje=eje;
                    s.gama=w;
                
                for (int j = 0; j < 3; j++)
                {
                    double tp;
                    for (int i = 0; i < 10; i++)
                    {
                        tp = i * 0.05;
                        //Superficie s = new Superficie();
                        s.tipo = 8;
                        s.c = Color.Blue;
                        s.EncenderSuperOndaJugiens(grafico, tp);
                        ViewPort.Image = grafico;

                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        s.ApagarSuperOndaJugiens(grafico, tp);
                        ViewPort.Image = grafico;
                //      ts.EncSuperficie(grafico);
                        ViewPort.Image = grafico;

                    }

                }
                } while (w<=2*Math.PI);
                 

            }
            if (cmbSuperficie.SelectedIndex == 12)
            {
                //Superficie ts = new Superficie();
                //ts.x0 = 2;
                //ts.y0 = 2;
                //ts.z0 = -5;
                //ts.tipo = 11;
                //ts.gama = w;
                //ts.eje = eje;
                //ts.radio = 3;
                //ts.radio1 = 1;
                //ts.c = Color.Blue;
                //ts.EncSuperficie(grafico);
                //ViewPort.Image = grafico;

                for (int j = 0; j < 3; j++)
                {
                    double tp;
                    for (int i = 0; i < 10; i++)
                    {
                        tp = i * 0.05;
                        Superficie s = new Superficie();
                        s.tipo = 11;
                        s.gama = w;
                        s.eje = eje;
                        s.c = Color.Blue;
                        s.EncenderSuperOnda(grafico, tp);
                        ViewPort.Image = grafico;

                        ViewPort.Refresh();
                        Thread.Sleep(200);
                        s.ApagarSuperOnda(grafico, tp);
                        ViewPort.Image = grafico;
                        //ts.EncSuperficie(grafico);
                        ViewPort.Image = grafico;

                    }

                }


            }



        }

        private void btnPuntosPaleta_Click(object sender, EventArgs e)
        {
            opcion = "CuadradoPuntos";
        }

        private void cmbPaletaCuadrado_SelectedIndexChanged(object sender, EventArgs e)
        {
             int colort = 0;
            Graphics papel;
            papel = ViewPort.CreateGraphics();
            int k, l, z, u, k1, l1, k2, l2;
            ModelosMat.Pantalla(vx[0], vy[0], out k, out l);
            ModelosMat.Pantalla(vx[1], vy[1], out z, out u);
            ModelosMat.Pantalla(vx[2], vy[2], out k1, out l1);
            ModelosMat.Pantalla(vx[3], vy[3], out k2, out l2);
            Point point1 = new Point(k, l);
            Point point2 = new Point(z, u);
            Point point3 = new Point(k1, l1);
            Point point4 = new Point(k2, l2);
      
            Point[] puntos = { point1, point2, point3, point4 };
          
            if ( cmbPaletaCuadrado.SelectedIndex == 0)
            {

                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(i, 2) + Math.Pow(j, 2)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[0]=grafico;
                    }
                }
                Bitmap myImage = foto[0];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);


            }
           
            if ( cmbPaletaCuadrado.SelectedIndex == 1)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((Math.Sin(i) + 1) * 5 + (Math.Sin(j) + 1) * 5) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[1] = grafico;
                    }
                }
                Bitmap myImage = foto[1];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);

            }
            if ( cmbPaletaCuadrado.SelectedIndex == 2)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        //colort = Convert.ToInt32(Math.Sqrt((Math.Pow(i, 2) + Math.Pow(j, 2))) % 15);
                        colort = Convert.ToInt32(((Math.Sqrt(Math.Pow((i * j), 2))) + (i + j + Math.Sin(j))) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[2] = grafico;
                    }
                }
                Bitmap myImage = foto[2];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);

            }
            if ( cmbPaletaCuadrado.SelectedIndex == 3)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((i + 2) * j) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[3] = grafico;
                    }
                }
                Bitmap myImage = foto[3];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);

            }
            if ( cmbPaletaCuadrado.SelectedIndex == 4)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((Math.Tanh(i) + 15) * 5 + (Math.Sin(j) + 1) * 5) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[4] = grafico;
                    }
                }
                Bitmap myImage = foto[4];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);
            }
            if ( cmbPaletaCuadrado.SelectedIndex == 5)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow((Math.Tanh(i)), 2) + (Math.Pow(j, 2) * Math.Pow(i, 2)) % 15));
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[5] = grafico;
                    }
                }
                Bitmap myImage = foto[5];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);
            }
            if (cmbPaletaCuadrado.SelectedIndex == 6)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 2) * Math.Pow(i, 2) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[6] = grafico;
                    }
                }
                Bitmap myImage = foto[6];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);
            }
            if ( cmbPaletaCuadrado.SelectedIndex == 7)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 5) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[7] = grafico;
                    }
                }
                Bitmap myImage = foto[7];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);
            }
            if ( cmbPaletaCuadrado.SelectedIndex == 8)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 3) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[8] = grafico;
                    }
                }
                Bitmap myImage = foto[8];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);
            }
            if ( cmbPaletaCuadrado.SelectedIndex == 9)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((j + i) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        foto[9] = grafico;
                    }
                }
                Bitmap myImage = foto[9];
                TextureBrush myTextureBrush = new TextureBrush(myImage);
                Pen lapiz = new Pen(paleta0[0]);
                papel.DrawPolygon(lapiz, puntos);
                papel.FillPolygon(myTextureBrush, puntos);
            }
        }

        private void cmbEje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEje.SelectedIndex==0)
            {
                eje = 1;
            }

            if (cmbEje.SelectedIndex == 1)
            {
                eje = 2;
            }

            if (cmbEje.SelectedIndex == 2)
            {
                eje = 3;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


            //ModelosMat m = new ModelosMat();
            //if (comboBox2.SelectedIndex == 0)
            //{
            //    m.mCuadrilatero(0, -6, -3, 0, 3, 4, -1, -1, -6, ViewPort, grafico);
            //}
            //if (comboBox2.SelectedIndex == 1)
            //{
            //    m.mCuadrilatero(1, -6, -3, 0, 3, 4, -1, -1, -6, ViewPort, grafico);
            //}
            //if (comboBox2.SelectedIndex == 2)
            //{
            //    m.mCuadrilatero(2, -6, -3, 0, 3, 4, -1, -1, -6, ViewPort, grafico);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Segmento3D S = new Segmento3D();
            S.x0 = 2; 
            S.y0 = -3;
            S.z0 = 4;
            S.xf = 5;
            S.yf = -3;
            S.zf = 4;
            S.c = Color.Red;
            S.Encender3D(grafico);
            ViewPort.Image = grafico;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Segmento3D s = new Segmento3D();
            s.x0=3;
            s.y0=2;
            s.z0=1;
            s.xf=6;
            s.xf=2;
            s.xf=1;
            s.c=Color.Red;
           s.EncSegmento3D(grafico);
            ViewPort.Image=grafico;
            s.x0 = 6;
            s.y0 = 2;
            s.z0 = 1;
            s.xf = 6;
            s.xf = 7;
            s.xf = 1;
            s.c = Color.Red;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 6;
            s.y0 = 7;
            s.z0 = 1;
            s.xf = 3;
            s.xf = 7;
            s.xf = 1;
            s.c = Color.Red;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 6;
            s.y0 = 2;
            s.z0 = 1;
            s.xf = 4.5;
            s.xf = 2;
            s.xf = 4;
            s.c = Color.Red;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;


        }

        private void ejerciciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = null;
            tpEjercicios.Parent = tabControl;
            tpExamenes.Parent = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double w = 0;
            Curva3D c3d = new Curva3D();

            do
            {
                c3d.x0 = 2;
                c3d.y0 = -2;
                c3d.z0 = 5;
                c3d.a = 4;
                c3d.b = 0.333;
                c3d.eje = 1;
                //c3d.tipo = 2;
                c3d.gama = w;
                c3d.EncenderChuro(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                Thread.Sleep(200);
                c3d.ApagarChuro(grafico);
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
//                c3d.tipo = 2;
                c3d.gama = w;
                c3d.EncenderChuro(grafico);
                ViewPort.Image = grafico;
                ViewPort.Refresh();
                Thread.Sleep(200);
                c3d.ApagarChuro(grafico);
                ViewPort.Image = grafico;
                w += 0.2;
            } while (w <= 2 * Math.PI);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Segmento3D s = new Segmento3D(0, 0, 0, 0, 0, 0, Color.Red);
            s.x0 = 2;
            s.y0 = 1;
            s.z0 = 3;
            s.xf = 7;
            s.yf = 1;
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

        private void button9_Click(object sender, EventArgs e)
        {

            Segmento3D s = new Segmento3D(0, 0, 0, 0, 0, 0, Color.Red);
            s.x0 = 4;
            s.y0 = 5;
            s.z0 = -5;
            s.xf = 4;
            s.yf = 13;
            s.zf = -5;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
            s.x0 = 4;
            s.y0 = 5;
            s.z0 = -5;
            s.xf = 12;
            s.yf = 5;
            s.zf = -5;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 12;
            s.y0 = 5;
            s.z0 = -5;
            s.xf = 12;
            s.yf = 13;
            s.zf = -5;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 12;
            s.y0 = 13;
            s.z0 = -5;
            s.xf = 4;
            s.yf = 13;
            s.zf = -5;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 4;
            s.y0 = 5;
            s.z0 = -5;
            s.xf = 8;
            s.yf = 5;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 12;
            s.y0 = 5;
            s.z0 = -5;
            s.xf = 8;
            s.yf = 5;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 8;
            s.y0 = 13;
            s.z0 = 3;
            s.xf = 8;
            s.yf = 5;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;
            s.x0 = 4;
            s.y0 = 13;
            s.z0 = -5;
            s.xf = 8;
            s.yf = 13;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;

            s.x0 = 12;
            s.y0 = 13;
            s.z0 = -5;
            s.xf = 8;
            s.yf = 13;
            s.zf = 3;
            s.EncSegmento3D(grafico);
            ViewPort.Image = grafico;


        }

       
        }

       
        
}
