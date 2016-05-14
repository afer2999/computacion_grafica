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
//using System.Windows.Forms.VisualStyles;

namespace Compu
{
    public partial class Form1 : Form
    {
        Bitmap grafico;
        public string opcion;
        public double px, py, qx, qy;
        public double cx, cy;
        public int num = 3,contadorJ,contadorM,contadorSierpinsky;
        public double Ax, Ay, Bx, By, Cx, Cy;

        public ColorDialog paleta = new ColorDialog();
        Color[] paleta0 = new Color[16];
        Color[] paleta1 = new Color[16];
        

        public double[] vx = new double[1500];
        public double[] vy = new double[1500];
        public double[] vx1 = new double[1500];
        public double[] vy1 = new double[1500];
        public double[] vx2 = new double[1500];
        public double[] vy2 = new double[1500];
        public int poligonal = 0;
        public int band = 1;



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
            for (int i = 0; i < 15; i++)
            {
                paleta1[i] = Color.FromArgb( (17 * i),(17*i),0);
            }
        }

        //*********** LIMPIAR LA PANTALLA ***********
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            asignarcoordenadas();
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
        }

        // UTILIZADO CUANDO DAMOS CLIC SOBRE LA PANTALLA
        private void ViewPort_MouseUp(object sender, MouseEventArgs e)
        {
            ModelosMat.RealXY(e.X, e.Y, out qx, out qy);
            double d = Math.Sqrt(Math.Pow((px - qx), 2) + Math.Pow((py - qy), 2));

            switch (opcion)
            {
                case "Circunferencia":
                    Circuenferencia c = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                    c.x0 = px;
                    c.y0 = py;
                    c.radio = d;
                    c.c = Color.Red;
                    c.Encender();
                    break;

                case "Puntos":
                    double m, yn1, yn2;
                    Circuenferencia c2 = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                    c2.x0 = px;
                    c2.y0 = (225 - (px * px)) / 28;
                    c2.radio = 0.3;
                    c2.c = Color.Blue;
                    c2.Encender();

                    m = ((-2 * px) * 28) / Math.Pow(28, 2);

                    Segmento sg = new Segmento(0, 0, 0,0, Color.Blue, grafico, ViewPort, 0);
                    sg.segmento2(c2.x0, c2.y0, m, out yn1, out yn2);
                    sg.x0 = -15;
                    sg.y0 = yn1;
                    sg.xf = 15;
                    sg.yf = yn2;
                    sg.c = Color.Blue;
                    sg.Encender();
                    break;

                case "Segmento":
                    Segmento s = new Segmento(px, py, qx, qy, Color.Blue, grafico, ViewPort, 0);
                    s.Encender();
                    break;

                case "Circulo":
                    Circuenferencia c1 = new Circuenferencia(px, py, d, paleta.Color, grafico, ViewPort, 0);
                    c1.Encender();
                    break;

                case "Lazo":
                    Lazo l = new Lazo(px, py, d, Color.Black,grafico,ViewPort,0,0);
                    l.Encender();
                    break;

                case "Hipociclo":
                    Hipociclo h = new Hipociclo(px, py, d, paleta.Color, grafico, ViewPort,0);
                    h.Encender();
                    break;

                case "Poligono":
                    Poligono p = new Poligono(px, py, d, num, paleta.Color,grafico, ViewPort,0);
                    p.Encender();
                    break;

                case "CEntrecortada":
                    Circuenferencia c3 = new Circuenferencia(px, py, d, Color.BlueViolet,grafico, ViewPort, 2);
                    c3.Encender();
                    break;

                case "CLlenada":
                    Circuenferencia c4 = new Circuenferencia(px, py, d,paleta.Color,grafico, ViewPort, 3);
                    c4.Encender();
                    break;

                case "SEntrecortado":
                    Segmento s1 = new Segmento(px, py, qx, qy, Color.Blue, grafico, ViewPort, 1);
                    s1.Encender();
                    break;

                case "PAraña":
                    Poligono p1 = new Poligono(0,0,0,0,Color.Blue,grafico, ViewPort, 1);
                    for (int i = 1; i < 15; i++)
                    {
                        p1.x0 = px;
                        p1.y0 = py;
                        p1.radio = i;
                        p1.nlados = 10;
                        p1.c = paleta.Color;
                        p1.Encender();
                    }
                    break;

                case "Examen":

                    double m11, yn11, yn21;
                    Circuenferencia c21 = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                    c21.x0 = px;
                    c21.y0 = (7 * Math.Sin(px / 3));
                    c21.radio = 0.2;
                    c21.c = Color.Red;
                    c21.Encender();

                    m11 = (7 * (3 / Math.Pow(3, 2)) * Math.Cos(px / 3));

                    Segmento sg1 = new Segmento(0, 0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                    sg1.segmento2(c21.x0, c21.y0, m11, out yn11, out yn21);
                    sg1.x0 = -15;
                    sg1.y0 = yn11;
                    sg1.xf = 15;
                    sg1.yf = yn21;
                    sg1.c = Color.Blue;
                    sg1.Encender();
                    break;

                case "Curvas de Ajuste":
                    Circuenferencia aj = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                    aj.radio = 0.2;
                    aj.x0 = px;
                    aj.y0 = py;
                    vx[poligonal] = px;
                    vy[poligonal] = py;
                    poligonal++;
                    aj.c =paleta.Color;
                    aj.Encender();
                    break;

                case "Recta":
                    break;
                case "teta":
                    Letras teta = new Letras(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                    teta.radio = d;
                    teta.x0 = px;
                    teta.y0 = py;
                    teta.c = paleta.Color;
                    teta.Encender();
                    break;
                case "q":
                    Letras q = new Letras(0, 0, 0, Color.Blue, grafico, ViewPort, 34);
                    q.radio = d;
                    q.x0 = px;
                    q.y0 = py;
                    q.c = paleta.Color;
                    q.Encender();
                    break;
                case "t":
                    Letras t = new Letras(0, 0, 0, Color.Blue, grafico, ViewPort, 40);
                    t.radio = d;
                    t.x0 = px;
                    t.y0 = py;
                    t.c = paleta.Color;
                    t.Encender();
                    break;
                case "p":
                    Letras letrap = new Letras(0, 0, 0, Color.Blue, grafico, ViewPort, 32);
                    letrap.radio = d;
                    letrap.x0 = px;
                    letrap.y0 = py;
                    letrap.c = paleta.Color;
                    letrap.Encender();
                    break;
                case "letras":
                    Letras letra = new Letras(0, 0, 0, Color.Blue, grafico, ViewPort, 3);
                    letra.radio = d;
                    letra.x0 = px;
                    letra.y0 = py;
                    letra.c = paleta.Color;
                    letra.Encender();
                    break;
                case "ortogonal":
                    double ox,oy,or;
                    Segmento ortogonal = new Segmento(0, 0, 0,0, Color.Blue, grafico, ViewPort, 0);
                    if (band <2)
                    {
                        ortogonal.x0 = 0;
                        ortogonal.y0 = 0;
                        ortogonal.xf = px;
                        ortogonal.yf = py;
                        vx[0] = px;
                        vy[0] = py;
                        ortogonal.c = paleta.Color;
                        ortogonal.Encender();
                    }
                    else
                    {
                        if (band == 2)
                        {
                            ortogonal.x0 = 0;
                            ortogonal.y0 = 0;
                            ortogonal.xf = px;
                            ortogonal.yf = py;
                            ortogonal.c = paleta.Color;
                            ortogonal.Encender();
                            ortogonal.x0 = 0;
                            ortogonal.y0 = 0;
                            ortogonal.xf = px+vx[0];
                            ortogonal.yf = py+vx[0];
                            ortogonal.c = Color.Red;
                            ortogonal.Encender();
                            ox = vx[0] * px;
                            oy = vx[0] * py;
                            or = ox + oy;
                            if (or >= -0.5 && or <= 0.5)
                            {
                                toolStripStatusLabel.Text = "ES ORTOGONAL";
                                
                            }
                            else
                            {
                                toolStripStatusLabel.Text = "NO ES ORTOGONAL";
                                
                            }
                            label3.Text = Convert.ToString(Math.Abs(ortogonal.xf)+Math.Abs(ortogonal.yf));
                        }
                      
                    }
                    band++;
                   
                    break;
                case "triangulo90":
                    {
                        Segmento seg1 = new Segmento(px, py, qx, qy, Color.Blue, grafico, ViewPort, 0);
                        seg1.Encender();
                        Segmento seg2 = new Segmento(px, py, qx, py, Color.Blue, grafico, ViewPort, 0);
                        seg2.Encender();
                        Segmento seg3 = new Segmento(qx, qy, qx, py, Color.Blue, grafico, ViewPort, 0);
                        seg3.Encender();

                        double pendiente = ((qy - py) / (qx - px));
                        double mt = (-1) / pendiente;                          //pendiente negativa
                        double b = py - (mt * qx);     //Remplazando Formula

                        double puntoX0 = px;                      //Remplazando Valores de la Formula puntoMedioX se considera una referencia 
                        double puntoY0 = mt * (puntoX0) + b;                   //Remplazo fomula
                        double puntoXF = qx;
                        double puntoYF = mt * (puntoXF) + b;

                        Segmento segm = new Segmento(puntoX0, puntoY0, puntoXF, puntoYF, Color.Blue, grafico, ViewPort, 0);
                        segm.Encender();
                    }break;
                case "borrador":
                    {
                        for (double i = px; i <= qx; i = i + 0.02)
                        {
                            Segmento borrador = new Segmento(i, py, i + 0.02, qy, Color.Black, grafico, ViewPort,0);
                            borrador.Apagar(Color.Black);
                        }
                    }break;
                case "Flor":
                    {
                        Fractal ob = new Fractal(px,py,d,0,0,Color.Yellow,grafico,ViewPort);
                        ob.Flor();
                    }break;
                case "Nubes":
                    {
                        Fractal ob = new Fractal(px, py, d, 0, 0, Color.WhiteSmoke, grafico, ViewPort);
                        ob.Nubes();
                    } break;
               case "Estrellas":
                    {
                        Fractal ob = new Fractal(px, py, d, 0, 0, Color.WhiteSmoke, grafico, ViewPort);
                        ob.Nubes();
                    } break;
               case "Zoom":
                   {
                       double xf, yf;
                       double Lx = ModelosMat.x2 - ModelosMat.x1;
                       double Ly = ModelosMat.y2 - ModelosMat.y1;
                       double xf2, yf2;
                       double L = Lx / 15;
                       double L1 = Ly / 15;
                       label8.Text = Convert.ToString(L);
                       label9.Text = Convert.ToString(L1);

                       Segmento seg1 = new Segmento(px - L / 2, py + L1 / 2, px + L / 2, py + L1 / 2, Color.White,grafico, ViewPort,0);
                       seg1.Encender();
                       Segmento seg2 = new Segmento(px - L / 2, py - L1 / 2, px + L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                       seg2.Encender();
                       Segmento seg3 = new Segmento(px - L / 2, py + L1 / 2, px - L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                       seg3.Encender();
                       Segmento seg4 = new Segmento(px + L / 2, py + L1 / 2, px + L / 2, py - L1 / 2, Color.White, grafico, ViewPort, 0);
                       seg4.Encender();
                       Thread.Sleep(1000);
                       ViewPort.Refresh();
                       xf = px - L / 2;
                       yf = py - L1 / 2;
                       xf2 = px + L / 2;
                       yf2 = py + L1 / 2;
                       ModelosMat.x1 = xf;
                       ModelosMat.x2 = xf2;
                       ModelosMat.y1 = yf;
                       ModelosMat.y2 = yf2;
                       cmbfractal_SelectedIndexChanged(null, null);
                   }break;
               case "TrianguloEQ":
                   {
                       Circuenferencia trc = new Circuenferencia(px, py, d, paleta.Color, grafico, ViewPort, 6);
                       trc.Encender();
                   }break;
               case "TianguloObt":
                   {
                       Circuenferencia tob = new Circuenferencia(px, py, d, paleta.Color, grafico, ViewPort, 7);
                       tob.Encender();
                   }break;
               case "TrianguloPuntos":
                   {
                       double ab,bc,ac,per,sp,a;
                       Segmento tripuntos = new Segmento(0, 0, 0, 0, Color.Black, grafico, ViewPort, 0);
                       Circuenferencia aj1 = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                       aj1.radio = 0.2;
                       aj1.x0 = px;
                       aj1.y0 = py;
                       vx[poligonal] = px;
                       vy[poligonal] = py;
                       
                       aj1.c = paleta.Color;
                       aj1.Encender();
                       if (poligonal == 2)
                       {
                           tripuntos.x0 = vx[0];
                           tripuntos.y0 = vy[0];
                           tripuntos.xf = vx[1];
                           tripuntos.yf = vy[1];
                           tripuntos.Encender();
                           tripuntos.x0 = vx[1];
                           tripuntos.y0 = vy[1];
                           tripuntos.xf = vx[2];
                           tripuntos.yf = vy[2];
                           tripuntos.Encender();
                           tripuntos.x0 = vx[0];
                           tripuntos.y0 = vy[0];
                           tripuntos.xf = vx[2];
                           tripuntos.yf = vy[2];
                           tripuntos.Encender();
                           ab= Math.Sqrt(Math.Pow((vx[0]-vx[1]),2)+Math.Pow((vy[0]-vy[1]),2));
                           bc= Math.Sqrt(Math.Pow((vx[1]-vx[2]),2)+Math.Pow((vy[1]-vy[2]),2));
                           ac= Math.Sqrt(Math.Pow((vx[0]-vx[2]),2)+Math.Pow((vy[0]-vy[2]),2));
                           per=ab+bc+ac;
                           sp=per/2;
                           a=Math.Sqrt(sp*(sp-ab)*(sp-bc)*(sp-ac));
                           lblarea1.Text = Math.Round(a,2).ToString();
                           lblperimetro.Text = Math.Round(per,2).ToString();
                       }
                       poligonal++;
                   }break;
               case "PuntosSierpinsky":
                   {
                       Circuenferencia aj1 = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
                       aj1.radio = 0.1;
                       aj1.x0 = px;
                       aj1.y0 = py;
                       aj1.Encender();
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
                   } break;

               
            }

        }

        //*********** FIN ***********


        private void btnVector_Click(object sender, EventArgs e)
        {
            Vector v = new Vector(10, 5, Color.Red,grafico,ViewPort);
            /* v.x0 = 0;
             v.y0 = 0;
             v.c = Color.Red;*/
            v.Encender();
           
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
            Lazo l = new Lazo(10,5,3,Color.Blue,grafico,ViewPort,0,0);
            l.Encender();
            
        }

        private void btnHipociclo_Click(object sender, EventArgs e)
        {
            Hipociclo h = new Hipociclo(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
            h.x0 = 10;
            h.y0 = 5;
            h.radio = 3;
            h.c = Color.Blue;
            h.Encender();
            ViewPort.Image = grafico;
        }

        private void btnSegmento_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento(0, -5, 0, 5, Color.Blue, grafico, ViewPort, 0);
            s.Encender();
        }

        private void btnPractica1_Click(object sender, EventArgs e)
        {
            Circuenferencia c = new Circuenferencia(5, -5, 3, Color.Red, grafico, ViewPort, 0);
            c.Encender();

            Lazo l = new Lazo(5, 5, 3, Color.Blue,grafico,ViewPort,0,0);
            l.Encender();


            Hipociclo h = new Hipociclo(-5, 5, 3, Color.BlueViolet, grafico, ViewPort, 0);
            h.Encender();

            Segmento s = new Segmento(-5, -2, -5, -8, Color.Blue, grafico, ViewPort, 0);
            s.Encender();
            ViewPort.Image = grafico;

            ViewPort.Refresh();
            Thread.Sleep(100);
            c.Apagar(BackColor);
            ViewPort.Image = grafico;
            ViewPort.Refresh();
            Thread.Sleep(100);
            l.Apagar(BackColor);
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

            /*Segmento lk = new Segmento();
            lk.x0 = 2;
            lk.y0 = -2;
            lk.xf = 2;
            lk.yf = -8;
            lk.Letrak(grafico);
            ViewPort.Image = grafico;*/



        }

        private void btnPendiente_Click(object sender, EventArgs e)
        {
            double m1, m2, lx, ly;
            double x = 5, y = 3, x1 = 2, y1 = 2;
            Segmento st = new Segmento(0, 0, 0, 0, Color.Blue, grafico, ViewPort, 0);
            st.x0 = x;
            st.y0 = y;
            st.xf = x1;
            st.yf = y1;
            st.c = Color.Violet;
            st.Encender();
            Circuenferencia cirt = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
            cirt.x0 = x1;
            cirt.y0 = y1;
            cirt.radio = Math.Sqrt(Math.Pow((x1 - x), 2) + (Math.Pow((y1 - y), 2)));
            cirt.c = Color.Violet;
            cirt.Encender();
            m1 = (y1 - y) / (x1 - x);
            m2 = -(1 / m1);
            //lblVer.Text = Convert.ToString(m1);

            Vector tangente = new Vector(0,0,Color.Black,grafico,ViewPort);
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
                        tangente.Encender();
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
                        tangente.Encender();
                    }
                }



            }


        }


        private void btnPoligono_Click(object sender, EventArgs e)
        {
            Poligono pl = new Poligono(-8, -2, 5, 7, Color.Violet,grafico, ViewPort, 0);
            pl.Encender();
            ViewPort.Image = grafico;
        }

        private void cmbParcial1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double ax1 = -2, ax2 = 3, ay1 = 3, ay2 = -1, ra;
            double bx1 = ax1, bx2 = 5, by1 = ay1, by2 = 6, rb;
            double cx1 = ax2, cx2 = bx2, cy1 = ay2, cy2 = by2, rc;
            double ab, bc, xb, yb, a1, a2, h, c, p, ca, xa, ya, xc, yc;
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
            
            if (cmbParcial1.SelectedIndex == 4)
            {
                Segmento bi = new Segmento(ax1, ay1, ax2, ay2, Color.Black, grafico, ViewPort, 0);
                bi.Encender();
                bi.x0 = bx1;
                bi.xf = bx2;
                bi.y0 = by1;
                bi.yf = by2;
                bi.Encender();
                bi.x0 = cx1;
                bi.xf = cx2;
                bi.y0 = cy1;
                bi.yf = cy2;
                bi.Encender();
                /////////bisectriz b
                ab = Math.Sqrt(Math.Pow((ax1 - bx2), 2) + Math.Pow((ay1 - by2), 2));
                bc = Math.Sqrt(Math.Pow((bx2 - ax2), 2) + Math.Pow((by2 - ax2), 2));
                rb = ab / bc;
                xb = (ax1 + rb * ax2) / (1 + rb);
                yb = (ay1 + rb * ay2) / (1 + rb);
                bi.x0 = bx2;
                bi.y0 = by2;
                bi.xf = xb;
                bi.yf = yb;
                bi.c = Color.Green;
                bi.Encender();
                /////con la matriz puntos de los triangulos primer punto se repite
                a1 = (((ax1 * by2) + (bx2 * ay2) + (ax2 * ay1)) - ((bx2 * ay1) + (ax2 * by2) + (ax1 * ay2))) / 2;
                if (a1 < 0)
                {
                    a1 = a1 * -1;

                }
                lblarea1.Text = a1.ToString();
                /////calculando distancias
                c = Math.Sqrt(Math.Pow((ax2 - ax1), 2) + Math.Pow((ay2 - ay1), 2));
                h = Math.Sqrt(Math.Pow((xb - bx2), 2) + Math.Pow((yb - by2), 2));
                a2 = (c * h) / 2;
                lblarea2.Text = a2.ToString();
                p = ab + bc + c;
                lblperimetro.Text = p.ToString();
                ///////bisectriz de a
                ca = Math.Sqrt(Math.Pow((ax1 - ax2), 2) + Math.Pow((ay1 - ay2), 2));
                ra = ca / ab;
                xa = (ax2 + ra * bx2) / (1 + ra);
                ya = (ay2 + ra * by2) / (1 + ra);
                bi.x0 = ax1;
                bi.xf = xa;
                bi.y0 = ay1;
                bi.yf = ya;
                bi.c = Color.Green;
                bi.Encender();
                /////////bisectriz de c
                rc = bc / ca;
                xc = (bx2 + rc * ax1) / (1 + rc);
                yc = (by2 + rc * ay1) / (1 + rc);
                bi.x0 = ax2;
                bi.y0 = ay2;
                bi.xf = xc;
                bi.yf = yc;
                bi.c = Color.Green;
                bi.Encender();

            }
            if (cmbParcial1.SelectedIndex == 5)
            {
                double xma, xmb, xmc, yma, ymb, ymc, ma, mma, mb, mmb, mc, mmc, xa1, ya1, b, yb1, yc1;
                Segmento mediatriz = new Segmento(ax1, ay1, ax2, ay2, Color.Black, grafico, ViewPort, 0);
                mediatriz.Encender();
                mediatriz.x0 = bx1;
                mediatriz.xf = bx2;
                mediatriz.y0 = by1;
                mediatriz.yf = by2;
                mediatriz.Encender();
                mediatriz.x0 = cx1;
                mediatriz.xf = cx2;
                mediatriz.y0 = cy1;
                mediatriz.yf = cy2;
                mediatriz.Encender();
                xma = (ax1 + bx2) / 2;
                yma = (ay1 + by2) / 2;
                ma = (by2 - ay1) / (bx2 - ax1);
                mma = (-1 / ma);
                b = yma - mma * xma;
                xa1 = (1 / mma) * (yma - b);
                ya1 = mma * cx1 + b;
                mediatriz.x0 = xma;
                mediatriz.y0 = yma;
                mediatriz.xf = cx1;
                mediatriz.yf = ya1;
                mediatriz.c = Color.Red;
                mediatriz.Encender();
                xmb = (bx2 + cx1) / 2;
                ymb = (by2 + cy1) / 2;
                mb = (by2 - cy1) / (bx2 - cx1);
                mmb = (-1) / mb;
                b = ymb - mmb * xmb;
                yb1 = mmb * ax1 + b;
                mediatriz.x0 = xmb;
                mediatriz.y0 = ymb;
                mediatriz.xf = ax1;
                mediatriz.yf = yb1;
                mediatriz.c = Color.Red;
                mediatriz.Encender();
                xmc = (ax1 + cx1) / 2;
                ymc = (ay1 + cy1) / 2;
                mc = (cy1 - ay1) / (cx1 - ax1);
                mmc = (-1) / mc;
                b = ymc - mmc * xmc;
                yc1 = mmc * bx2 + b;
                mediatriz.x0 = xmc;
                mediatriz.y0 = ymc;
                mediatriz.xf = bx2;
                mediatriz.yf = yc1;
                mediatriz.c = Color.Red;
                mediatriz.Encender();

            }
            if (cmbParcial1.SelectedIndex==6)
            {
                opcion = "triangulo90";
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
            Vector v2 = new Vector(0,0,Color.Blue,grafico,ViewPort);
            do
            {
                v2.x0 = x;
                v2.y0 = (225 - x * x) / 28;
                v2.Encender();
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
            Circuenferencia c2 = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
            c2.x0 = px;
            c2.y0 = (225 - (px * px)) / 28;
            c2.radio = 0.3;
            c2.c = Color.Blue;
            c2.Encender();


            m = ((-2 * px) * 28) / Math.Pow(28, 2);

            Segmento sg = new Segmento(0, 0, 0, 0, Color.Blue, grafico, ViewPort, 0);
            sg.segmento2(px, c2.y0, m, out yn1, out yn2);
            sg.x0 = -15;
            sg.y0 = yn1;
            sg.xf = 15;
            sg.yf = yn2;
            sg.c = Color.Blue;
            sg.Encender();
        }

        private void gRÁFICOS2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = tabControl;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = null;
        }

        private void fRACTALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpFractales.Parent = tabControl;
            tpGraficos3d.Parent = null;
        }

        private void gRÁFICOS3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpFractales.Parent = null;
            tpGraficos3d.Parent = tabControl;
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
            tpEjercicios.Parent = tabControl;
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
            Circuenferencia c = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
            for (double i = 0; i < 2; i += 0.1)
            {
                c.x0 = 0;
                c.y0 = 0;
                c.radio = i;
                c.c = Color.Black;
                c.Encender();
            }
            Circuenferencia c1 = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);
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
                c1.Encender();
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
            Lazo l = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, 0, 0);
            do
            {
                l.x0 = w;
                l.y0 = 0;
                l.radio = 2.5;
                l.c = Color.Blue;
                l.Encender();
                ViewPort.Refresh();
                Thread.Sleep(20);
                l.Apagar(ViewPort.BackColor);
                w += dw;
            } while (w <= 12);
            l.c = Color.Blue;
            l.Encender();
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

            Circuenferencia c = new Circuenferencia(1, 1, 1, Color.Beige, grafico, ViewPort, 0);
            c.Encender();

            Circuenferencia c1 = new Circuenferencia(12, 3, 4, Color.Beige, grafico, ViewPort, 0);
            c1.Encender();


            double pasox = 1;
            Circuenferencia c21 = new Circuenferencia(0,0,0, Color.Blue, grafico, ViewPort, 0);
            while (pasox <= 12)
            {
                c21.x0 = pasox;
                c21.y0 = (1 * ((pasox - 12) / (1 - 12))) + (3 * ((pasox - 1) / (12 - 1)));
                c21.radio = (1 * ((pasox - 12) / (1 - 12))) + (4 * ((pasox - 1) / (12 - 1)));
                pasox += 0.1;
                c21.c = Color.FromArgb(Convert.ToInt32((250 * ((pasox - 12) / (1 - 12))) + (3 * ((pasox - 1) / (12 - 1)))),
                    Convert.ToInt32((0 * ((pasox - 12) / (1 - 12))) + (0 * ((pasox - 1) / (12 - 1)))),
                    Convert.ToInt32((255 * ((pasox - 12) / (1 - 12))) + (5 * ((pasox - 1) / (12 - 1)))));
                c21.Encender();
                //Thread.Sleep(10);
                ViewPort.Refresh();
                c21.Apagar(ViewPort.BackColor);

            }
            c21.c = Color.FromArgb(Convert.ToInt32((250 * ((pasox - 12) / (1 - 12))) + (3 * ((pasox - 1) / (12 - 1)))),
                   Convert.ToInt32((0 * ((pasox - 12) / (1 - 12))) + (0 * ((pasox - 1) / (12 - 1)))),
                   Convert.ToInt32((255 * ((pasox - 12) / (1 - 12))) + (5 * ((pasox - 1) / (12 - 1)))));
            c21.Encender();

        }

        private void btnAnimacion2_Click(object sender, EventArgs e)
        {
            double pasox = 7;
            Circuenferencia c = new Circuenferencia(0, 0, 0, Color.Blue, grafico, ViewPort, 0);


            while (pasox >= -3)
            {
                c.x0 = pasox;
                c.y0 = (3 * ((pasox + 3) / (7 + 3))) + (1 * ((pasox - 7) / (-3 - 7)));
                c.radio = (4 * ((pasox + 3) / (7 + 3))) + (1 * ((pasox - 7) / (-3 - 7)));
                pasox -= 0.1;
                c.c = Color.Blue;
                c.Encender();
                ViewPort.Refresh();
                c.Apagar(ViewPort.BackColor);
            }
            c.c = Color.Blue;
            c.Encender();
        }

        private void btnExamen_Click(object sender, EventArgs e)
        {

            double x = -15;
            double dx = 0.02;
            Vector v2 = new Vector(0, 0, Color.Blue, grafico, ViewPort);
            do
            {
                v2.x0 = x;
                v2.y0 = (7) * Math.Sin(x / 3);
                v2.c = Color.Blue;
                v2.Encender();
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
            double t = vx[0];
            double dt = 0.001;
            Vector v = new Vector(0, 0, Color.Blue, grafico, ViewPort);
            v.c = Color.Blue;
            if (cmbCurvasAjuste.SelectedIndex == 0)
            {
                while (t <= vx[poligonal - 1])
                {
                    v.x0 = t;
                    v.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    v.Encender();
                    t = t + dt;
                }
            }
            if (cmbCurvasAjuste.SelectedIndex == 1)
            {
                double bt = 0;
                double xbi, ybi;
                Vector vb = new Vector(0, 0, Color.Blue, grafico, ViewPort);
                while (bt <= 1)
                {
                    ModelosMat.Bezier(vx, vy, poligonal, bt, out xbi, out ybi);
                    vb.x0 = xbi;
                    vb.y0 = ybi;
                    vb.c = Color.Violet;
                    vb.Encender();
                    bt = bt + 0.001;
                }
            }
            if (cmbCurvasAjuste.SelectedIndex == 2)
            {
                Segmento s = new Segmento(0, 0, 0, 0, Color.Black, grafico, ViewPort, 0);
                for (int i = 0; i < poligonal - 1; i++)
                {
                    s.x0 = vx[i];
                    s.y0 = vy[i];
                    s.xf = vx[i + 1];
                    s.yf = vy[i + 1];
                    s.Encender();
                }
            }

        }

        private void btnNuevosPuntos_Click(object sender, EventArgs e)
        {

            poligonal = 0;

        }

        private void btnGrange_Click(object sender, EventArgs e)
        {
            Segmento sg = new Segmento(0, 0, 0, 0, Color.Blue, grafico, ViewPort, 0);
            for (int i = 1; i < poligonal; i++)
            {
                sg.x0 = vx[0];
                sg.y0 = vy[0];
                sg.xf = vx[i];
                sg.yf = vy[i];
                sg.c = Color.Black;
                sg.Encender();
                ViewPort.Image = grafico;
            }
        }
        private void cbletras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbletras.SelectedIndex == 0)
            {
                opcion = "teta";

            }
            if (cbletras.SelectedIndex == 1)
            {
                opcion = "q";
            }

            if (cbletras.SelectedIndex == 2)
            {
               opcion = "t";

            }
            if (cbletras.SelectedIndex == 3)
            {
                opcion = "p";

            }
            if (cbletras.SelectedIndex == 4)
            {
                opcion = "letras";

            }
        }

        private void btnejes_Click(object sender, EventArgs e)
        {
            ViewPort.Image = null;
            grafico = null;
            if (grafico == null)
            {
                grafico = new Bitmap(ViewPort.Width, ViewPort.Height);
            }
            /////
            Segmento seg1 = new Segmento(-15, 0, 15, 0, paleta.Color,grafico,ViewPort,0);
            seg1.Encender();
            Segmento seg2 = new Segmento(0, 10, 0, -10, paleta.Color, grafico, ViewPort, 0);
            seg2.Encender();

            ViewPort.Enabled = true;
            band = 1;
            opcion = "ortogonal";
        }

        private void cmbtaylor_SelectedIndexChanged(object sender, EventArgs e)
        {
            double x = -15,dx=0.01;
            int y;
            Vector vp = new Vector(0, 0, Color.Blue, grafico, ViewPort);
            if (cmbtaylor.SelectedIndex == 0)
            {
                do
                {
                    vp.x0 = x;
                    vp.y0 = 1 + (0.693 * x) + (Math.Pow(0.693, 2)/2) * Math.Pow(x, 2) + (Math.Pow(0.693, 3) / 6) * Math.Pow(x, 3) + (Math.Pow(0.693, 4) / 24) * Math.Pow(x, 4) + (Math.Pow(0.693, 5) / 120) * Math.Pow(x, 5);
                    vp.c = Color.Red;
                    vp.Encender();
                    vp.y0 = Math.Pow(2, x);
                    vp.c = Color.Blue;
                    vp.Encender();
                    x = x + dx;
                } while (x <= 15);
            }
            if (cmbtaylor.SelectedIndex == 1)
            {
                do
                {
                    vp.x0 = x;
                    //vp.y0 = 0 + x + 0 - ((1 / 6) * Math.Pow(x, 3)) + 0 + ((1 / 120) * Math.Pow(x, 5));
                    vp.y0 = 0 + x + 0 - Math.Pow(x, 3) / 6 + 0 + Math.Pow(x, 5) / 120;
                    vp.c = Color.Red;
                    vp.Encender();
                    vp.y0 = Math.Sin(x);
                    vp.c = Color.Blue;
                    vp.Encender();
                    x = x + dx;
                } while (x <= 15);
            }
            if (cmbtaylor.SelectedIndex == 2)
            {
                
                do
                {
                    vp.x0 = x;
                    //vp.y0 = 0 + x + 0 - ((1 / 6) * Math.Pow(x, 3)) + 0 + ((1 / 120) * Math.Pow(x, 5));
                    vp.y0 = 3 + 0 - Math.Pow(x, 2) / 6 + 0 + Math.Pow(x, 4) / 648 + 0 - Math.Pow(x, 6) / 174960 + 0 + Math.Pow(x, 8) / 88179840+0-(Math.Pow(x,10))/71425670400;
                    vp.c = Color.Red;
                    vp.Encender();
                    vp.y0 = 3*Math.Cos(x/3);
                    vp.c = Color.Blue;
                    vp.Encender();
                    x = x + dx;
                } while (x <= 15);
            }
            if (cmbtaylor.SelectedIndex == 3)
            {
                x = -2.8;
                do
                {
                    vp.x0 = x;
                    //vp.y0 = 1.1 + 0.33 * x - (0.11 / 2) * Math.Pow(x, 2) + (0.074 / 6) * Math.Pow(x, 3) - (0.074 / 24) * Math.Pow(x, 4) + (0.099 / 120) * Math.Pow(x, 5) - (0.16 / 720) * Math.Pow(x, 6) + (0.33 / 5040) * Math.Pow(x, 7) - (0.77 / 40320) * Math.Pow(x, 8);
                    vp.y0 = 1.1 + (0.33 * x) - ((0.11 / 2) * Math.Pow(x, 2)) + ((0.074 / 6) * Math.Pow(x, 3)) - ((0.074 / 24) * Math.Pow(x, 4)) + ((0.099 / 120) * Math.Pow(x, 5)) - (0.16 / 720) * Math.Pow(x, 6) + (0.33 / 5040) * Math.Pow(x, 7) - (0.77 / 40320) * Math.Pow(x, 8);
                    vp.c = Color.Red;
                    vp.Encender();
                    vp.y0 = Math.Log(3+x);
                    vp.c = Color.Blue;
                    vp.Encender();
                    x = x + dx;
                } while (x <= 15);
            }
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int colort=0;
            if (comboBox1.SelectedIndex==0)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(i, 2) + Math.Pow(j, 2))%15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }
                
            }
            if (comboBox1.SelectedIndex == 1)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((Math.Cosh(i) +1) + (Math.Sinh(j) + 1)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }

            }
            if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((Math.Sin(i)+1)*5+(Math.Sin(j)+1)*5)%15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }

            }
            if (comboBox1.SelectedIndex == 3)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(Math.Sqrt((Math.Pow(i, 2) + Math.Pow(j, 2))) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }

            }
            if (comboBox1.SelectedIndex == 4)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((i+ 2)*j) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }

            }
            if (comboBox1.SelectedIndex == 5)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32(((Math.Tanh(i)+15) * 5 + (Math.Sin(j) + 1) * 5) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 6)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow((Math.Tanh(i)), 2) + (Math.Pow(j, 2) * Math.Pow(i, 2)) % 15));
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 7)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 2) * Math.Pow(i, 2) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 8)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 5) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 9)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((Math.Pow(j, 3) + Math.Pow(i, 3)) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }
            }
            if (comboBox1.SelectedIndex == 10)
            {
                for (int i = 0; i < 600; i++)
                {
                    for (int j = 0; j < 400; j++)
                    {
                        colort = Convert.ToInt32((j + i) % 15);
                        grafico.SetPixel(i, j, paleta0[colort]);
                        ViewPort.Image = grafico;
                    }
                }
            } 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (comboBox2.SelectedIndex==0)
            {
                
               double w = 0;
               Lazo l = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w, 1);
            do
            {
                
                l.x0 = 2;
                l.y0 = 5;
                l.radio = 4;
                l.alfa = w;
                l.c = Color.Blue;
                l.Encender();
                ViewPort.Refresh();
                Thread.Sleep(20);
                l.Apagar(ViewPort.BackColor);
                w+= 0.2;
             } while (w<=2*Math.PI);
            l.c = Color.Blue;
            l.Encender();
            }
            if (comboBox2.SelectedIndex == 1)
            {
                Segmento s1 = new Segmento(-15, 2, -4, 2, paleta.Color, grafico, ViewPort, 0);
                s1.Encender();
                Segmento s2 = new Segmento(-4, 2, 3, -7, paleta.Color, grafico, ViewPort, 0);
                s2.Encender();
                Segmento s3 = new Segmento(3, -7, 15, -7, paleta.Color, grafico, ViewPort, 0);
                s3.Encender();

                double w = 0;
                Lazo l = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w, 1);

                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -3.8; i = i + 0.2)
                    {
                        l.x0 = 4;
                        l.y0 = i;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.Apagar(ViewPort.BackColor);
                        s1.Encender();
                        s2.Encender();
                        w += 0.2;
                    }

                    double paso = -3.4;
                    do
                    {
                        l.x0 = (2 * ((paso - 5) / -7)) - (7 * ((paso + 2) / 7));
                        l.y0 = paso;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.Apagar(ViewPort.BackColor);
                        s1.Encender();
                        s2.Encender();
                        s3.Encender();
                        w += 0.2;
                        paso += 0.2;
                    } while (paso <= 3.6);

                    for (double i = 3; i <= 13; i = i + 0.2)
                    {
                        l.x0 = -5;
                        l.y0 = i;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.Apagar(ViewPort.BackColor);
                        s2.Encender();
                        s3.Encender();
                        w += 0.2;
                    }

                }
                l.c = Color.Blue;
                l.Encender();
            }
            if (comboBox2.SelectedIndex == 2)
            {
                Segmento s1 = new Segmento(-15, 2, -4, 2, paleta.Color, grafico, ViewPort, 0);
                s1.Encender();
                Segmento s2 = new Segmento(-4, 2, 3, -7, paleta.Color, grafico, ViewPort, 0);
                s2.Encender();
                Segmento s3 = new Segmento(3, -7, 15, -7, paleta.Color, grafico, ViewPort, 0);
                s3.Encender();

                double w = 0;
                Lazo l = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w, 1);
                Circuenferencia c2 = new Circuenferencia(-4, 3, 2, Color.Black, grafico, ViewPort, 4);
                Vector v2 = new Vector(0, 0, Color.Black, grafico, ViewPort);

                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -4; i = i + 0.2)
                    {
                        l.x0 = 4;
                        l.y0 = i;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.Apagar(ViewPort.BackColor);
                        s1.Encender();
                        s2.Encender();
                        w += 0.2;
                    }

                }

                // PARABOLA INICIAL
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
                double t = vx[0];
                double dt = 0.02;
                double w1 = 0;
                Vector v = new Vector(0, 0, Color.Red, grafico, ViewPort);
                Lazo l1 = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w1, 1);
                while (t <= vx[2])
                {
                    v.x0 = t;
                    v.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    //v.Encender();
                    t = t + dt;
                }

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
                vy1[0] = 1;
                poligonal1++;

                vx1[1] = 2;
                vy1[1] = 0.5;
                poligonal1++;

                vx1[2] = 10;
                vy1[2] = 3;
                poligonal1++;

                // METAMORFOSIS PARABOLA SIN
                int poligonal2 = 0;

                vx2[0] = -4;
                vy2[0] = 1;
                poligonal2++;

                vx2[1] = 2;
                vy2[1] = 0.5;
                poligonal2++;

                vx2[2] = 10;
                vy2[2] = 2;
                poligonal2++;
                t = vx[0];
                dt = 0.05;
                w1 = 0;

                while (t <= vx[2])
                {
                    c2.x0 = t;
                    c2.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    c2.t1cos = ModelosMat.Lagrange(t, vx1, vy1, poligonal1);
                    c2.t1sen = ModelosMat.Lagrange(t, vx2, vy2, poligonal2);
                    v2.x0 = t;
                    v2.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    // v2.Encender();
                    c2.c = Color.Blue;
                    c2.Encender();
                    ViewPort.Refresh();
                    Thread.Sleep(5);
                    c2.Apagar(ViewPort.BackColor);
                    s1.Encender();
                    s2.Encender();
                    s3.Encender();
                    t = t + dt;
                }
                c2.c = Color.Blue;
                c2.Encender();
            }

            if (comboBox2.SelectedIndex == 3)
            {
                Segmento s1 = new Segmento(-15, 2, -4, 2, paleta.Color, grafico, ViewPort, 0);
                s1.Encender();
                Segmento s2 = new Segmento(-4, 2, 3, -7, paleta.Color, grafico, ViewPort, 0);
                s2.Encender();
                Segmento s3 = new Segmento(3, -7, 15, -7, paleta.Color, grafico, ViewPort, 0);
                s3.Encender();

                double w = 0;
                Lazo l = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w, 1);
                Circuenferencia c2 = new Circuenferencia(-4, 3, 2, Color.Black, grafico, ViewPort, 4);
                Vector v2 = new Vector(0, 0, Color.Black, grafico, ViewPort);

                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -4; i = i + 0.2)
                    {
                        l.x0 = 2;
                        l.y0 = i;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.Apagar(ViewPort.BackColor);
                        s1.Encender();
                        s2.Encender();
                        w += 0.2;
                    }
                }


                // METAMORFOSIS PARABOL RUTA
                poligonal = 0;
                vx[0] = -4;
                vy[0] = 2;
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
                    c2.x0 = t;
                    c2.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    c2.t1cos = ModelosMat.Lagrange(t, vx1, vy1, poligonal1);
                    c2.t1sen = ModelosMat.Lagrange(t, vx2, vy2, poligonal2);
                    v2.x0 = t;
                    v2.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    //v2.Encender();
                    c2.c = Color.Blue;
                    c2.Encender();
                    ViewPort.Refresh();
                    Thread.Sleep(5);
                    c2.Apagar(ViewPort.BackColor);
                    s1.Encender();
                    s2.Encender();
                    s3.Encender();
                    t = t + dt;
                    w1 = w1 + 0.2;
                }
                c2.c = Color.Blue;
                c2.Encender();
            }
            if (comboBox2.SelectedIndex == 4)
            {
                Segmento s1 = new Segmento(-15, 2, -4, 2, paleta.Color, grafico, ViewPort, 0);
                s1.Encender();
                Segmento s2 = new Segmento(-4, 2, 3, -7, paleta.Color, grafico, ViewPort, 0);
                s2.Encender();
                Segmento s3 = new Segmento(3, -7, 15, -7, paleta.Color, grafico, ViewPort, 0);
                s3.Encender();

                double w = 0;
                Lazo l = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w, 1);
                Circuenferencia c2 = new Circuenferencia(-4, 3, 2, Color.Black, grafico, ViewPort, 5);
                Vector v2 = new Vector(0, 0, Color.Black, grafico, ViewPort);

                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -4; i = i + 0.2)
                    {
                        l.x0 = 2;
                        l.y0 = i;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.Apagar(ViewPort.BackColor);
                        s1.Encender();
                        s2.Encender();
                        w += 0.2;
                    }

                    // PARABOLA INICIAL
                    poligonal = 0;

                    vx[0] = -4;
                    vy[0] = 2;
                    poligonal++;

                    vx[1] = 2;
                    vy[1] = 7;
                    poligonal++;

                    vx[2] = 10;
                    vy[2] = -7;
                    poligonal++;
                    double t = vx[0];
                    double dt = 0.2;
                    double w1 = 0;
                    Vector v = new Vector(0, 0, Color.White, grafico, ViewPort);
                    Lazo l1 = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w1, 1);
                    while (t <= vx[2])
                    {
                        v.x0 = t;
                        v.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                        v.Encender();
                        t = t + dt;
                    }

                    // METAMORFOSIS PARABOL RUTA
                    poligonal = 0;
                    vx[0] = -4;
                    vy[0] = 2;
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
                    vy1[0] = 2;
                    poligonal1++;

                    vx1[1] = 2;
                    vy1[1] = 1;
                    poligonal1++;

                    vx1[2] = 10;
                    vy1[2] = 1;
                    poligonal1++;

                    // METAMORFOSIS PARABOLA SIN
                    int poligonal2 = 0;

                    vx2[0] = -4;
                    vy2[0] = 3;
                    poligonal2++;

                    vx2[1] = 2;
                    vy2[1] = 1.5;
                    poligonal2++;

                    vx2[2] = 10;
                    vy2[2] = 1;
                    poligonal2++;
                    t = vx[0];
                    dt = 0.05;
                    w1 = 0;

                    while (t <= vx[2])
                    {
                        c2.x0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                        c2.y0 = t;
                        c2.t1cos = ModelosMat.Lagrange(t, vx1, vy1, poligonal1);
                        c2.t1sen = ModelosMat.Lagrange(t, vx2, vy2, poligonal2);
                        c2.alfa = w1;
                        v2.x0 = t;
                        v2.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                        //v2.Encender();
                        c2.c = Color.Blue;
                        c2.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(5);
                        c2.Apagar(ViewPort.BackColor);
                        s1.Encender();
                        s2.Encender();
                        s3.Encender();
                        t = t + dt;
                        w1 = w1 + 0.2;
                    }
                }
                c2.c = Color.Blue;
                c2.Encender();
            }
            if (comboBox2.SelectedIndex == 5)
            {
                Segmento s1 = new Segmento(-15, 2, -4, 2, paleta.Color, grafico, ViewPort, 0);
                s1.Encender();
                Segmento s2 = new Segmento(-4, 2, 3, -7, paleta.Color, grafico, ViewPort, 0);
                s2.Encender();
                Segmento s3 = new Segmento(3, -7, 15, -7, paleta.Color, grafico, ViewPort, 0);
                s3.Encender();

                double w = 0;
                Lazo l = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w, 1);
                Circuenferencia c2 = new Circuenferencia(-4, 3, 2, Color.Black, grafico, ViewPort, 5);
                Vector v2 = new Vector(0, 0, Color.Black, grafico, ViewPort);

                while (w <= 2 * Math.PI)
                {
                    for (double i = -15; i <= -4; i = i + 0.2)
                    {
                        l.x0 = 4;
                        l.y0 = i;
                        l.radio = 2;
                        l.alfa = w;
                        l.c = Color.Blue;
                        l.Encender();
                        ViewPort.Refresh();
                        Thread.Sleep(10);
                        l.Apagar(ViewPort.BackColor);
                        s1.Encender();
                        s2.Encender();
                        w += 0.2;
                    }

                }

                // PARABOLA INICIAL
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
                double t = vx[0];
                double dt = 0.02;
                double w1 = 0;
                Vector v = new Vector(0, 0, Color.Red, grafico, ViewPort);
                Lazo l1 = new Lazo(0, 0, 0, Color.Blue, grafico, ViewPort, w1, 1);
                while (t <= vx[2])
                {
                    v.x0 = t;
                    v.y0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    //v.Encender();
                    t = t + dt;
                }

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
                t = vx[0];
                dt = 0.05;
                w1 = 0;

                while (t <= vx[2])
                {
                    c2.x0 = ModelosMat.Lagrange(t, vx, vy, poligonal);
                    c2.y0 = t;
                    c2.t1cos = ModelosMat.Lagrange(t, vx1, vy1, poligonal1);
                    c2.t1sen = ModelosMat.Lagrange(t, vx2, vy2, poligonal2);
                    c2.alfa = w1;
                    c2.c = Color.Blue;
                    c2.Encender();
                    ViewPort.Refresh();
                    Thread.Sleep(5);
                    c2.Apagar(ViewPort.BackColor);
                    s1.Encender();
                    s2.Encender();
                    s3.Encender();
                    t = t + dt;
                    w1 = w1 + 0.2;
                }
                c2.c = Color.Blue;
                c2.Encender();
            }
        }

        private void btnluna_Click(object sender, EventArgs e)
        {
             double w=0,dw=0.05;

            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 250; j++)
                {
                    grafico.SetPixel(i, j, Color.Black);
                }
                ViewPort.Image = grafico;
            }

            for (int i = 0; i < 600; i++)
            {
                for (int j = 250; j < 389; j++)
                {
                    grafico.SetPixel(i, j, Color.FromArgb(Convert.ToInt32((0 * (j - 389) / (250 - 389)) + (20 * (j - 250) / (389 - 250))),
                    Convert.ToInt32((0 * (j - 389) / (250 - 389)) + (20 * (j - 250) / (389 - 250))),
                    Convert.ToInt32((0 * (j - 389) / (250 - 389)) + (255 * (j - 250) / (389 - 250)))));
                }
                ViewPort.Image = grafico;
            }
            double x = -15;
            Vector v = new Vector(0,0,Color.Violet,grafico,ViewPort);
            for (int i = 0; i < 600; i++)
            {
                for (int j = 389; j < 400; j++)
                {
                    grafico.SetPixel(i, j, Color.Black);
                }
                ViewPort.Image = grafico;
            }

                Circuenferencia cc = new Circuenferencia(-15, -10, 1, Color.Black, grafico, ViewPort, 3);
                cc.Encender();

                Circuenferencia c = new Circuenferencia(-13, -10, 1, Color.Black, grafico, ViewPort, 3);
                c.Encender();

                Circuenferencia c1 = new Circuenferencia(-10, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c1.Encender();

                Circuenferencia c2 = new Circuenferencia(-7, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c2.Encender();

                Circuenferencia c3 = new Circuenferencia(-4, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c3.Encender();

                Circuenferencia c4 = new Circuenferencia(-1, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c4.Encender();

                Circuenferencia c5 = new Circuenferencia(3, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c5.Encender();

                Circuenferencia c6 = new Circuenferencia(6, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c6.Encender();

                Circuenferencia c7 = new Circuenferencia(9, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c7.Encender();

                Circuenferencia c8 = new Circuenferencia(12, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c8.Encender();

                Circuenferencia c9 = new Circuenferencia(15, -9.8, 1, Color.Black, grafico, ViewPort, 3);
                c9.Encender();    

            Circuenferencia lu = new Circuenferencia(12, 7, 1, Color.FromArgb(200,200,200), grafico, ViewPort, 0);
            do
            {
                lu.radio = w;
                lu.Encender();
                w += dw;
                //ViewPort.BackColor = Color.FromArgb(200,200,200);
            } while (w <= 1.5);

            w = 1.5;
            do
            {
                lu.radio = w;
                lu.c = Color.FromArgb(Convert.ToInt32((200 * (w - 3) / (1.5 - 3)) + (255 * (w - 1.5) / (3 - 1.5))),
                    Convert.ToInt32((200 * (w - 3) / (1.5 - 3)) + (255 * (w - 1.5) / (3 - 1.5))),
                    Convert.ToInt32((200 * (w - 3) / (1.5 - 3)) + (255 * (w - 1.5) / (3 - 1.5))));
                lu.Encender();
                w = w + dw;
            } while (w <= 3);
            w = 3;
            do
            {
                lu.radio = w;
                lu.c = Color.FromArgb(Convert.ToInt32((40 * (w - 5) / (3 - 5)) + (0 * (w - 3) / (5 - 3))),
                    Convert.ToInt32((40 * (w - 5) / (3 - 5)) + (0 * (w - 3) / (5 - 3))),
                    Convert.ToInt32((40 * (w - 5) / (3 - 5)) + (0 * (w - 3) / (5 - 3))));
                lu.Encender();
                w = w + dw;
            } while (w <= 5);


            w = 0;
            dw = Math.PI / 10;
            Segmento es = new Segmento(-8, 7, 1, 1, paleta.Color, grafico, ViewPort, 0);
           
            do
            {
                es.xf = es.x0 + 0.5 * Math.Cos(w);
                es.yf = es.y0 + 0.5 * Math.Sin(w);
                es.c = Color.FromArgb(20,20,255);
                es.Encender();
                w = w + dw;
            } while (w <= 2*Math.PI);



            w = 0;
            dw = Math.PI / 10;
            es.x0 = 5;
            es.y0 = 7;
           
            do
            {
                es.xf = es.x0 + 0.4 * Math.Cos(w);
                es.yf = es.y0 + 0.4 * Math.Sin(w);
                es.c = Color.FromArgb(20, 20, 255);
                es.Encender();
                w = w + dw;
            } while (w <= 2 * Math.PI);

            w = 0;
            dw = Math.PI / 10;
            es.x0 = 0;
            es.y0 = 9;
            
            do
            {
                es.xf = es.x0 + 0.4 * Math.Cos(w);
                es.yf = es.y0 + 0.4 * Math.Sin(w);
                es.c = Color.FromArgb(102, 178, 255);
                es.Encender();
                w = w + dw;
            } while (w <= 2 * Math.PI);
            Fractal arbol = new Fractal(6, -9.5, 3, Math.PI / 2, Math.PI / 4, Color.FromArgb(209, 209, 209), grafico, ViewPort);
            arbol.ArbolF();
            Fractal arbol1 = new Fractal(-2, -9.5, 2, Math.PI / 2, Math.PI / 6, Color.FromArgb(209, 209, 209), grafico, ViewPort);
            arbol1.ArbolF();
            Fractal arbol2 = new Fractal(-10, -9.5, 3, Math.PI / 2, Math.PI / 2, Color.FromArgb(209, 209, 209), grafico, ViewPort);
            arbol2.ArbolF();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Fractal arbol = new Fractal(6, -9.5, 3, Math.PI / 2, Math.PI / 6, Color.Green, grafico, ViewPort);
            //arbol.ArbolF();
            for (double i = -15; i < 15; i=i+4.5)
            {
                arbol.x0 = i;
                arbol.y0 = -5.8;
                arbol.radio = 2;
                arbol.c = Color.DeepSkyBlue;
                arbol.gama = Math.PI / 2;
                arbol.beta = Math.PI / 2;
                arbol.ArbolF();
            }
            
            for (double i = -15; i <=15; i=i+2.5)
            {
                arbol.x0 = i;
                arbol.y0 = -5.8;
                arbol.radio = 1.5;
                arbol.c = Color.FromArgb(251, 252, 215);
                arbol.gama = Math.PI / 2;
                arbol.beta = Math.PI / 6;
                arbol.ArbolF();
            }
            for (double i = -15; i <= 15; i = i + 1.5)
            {
                arbol.x0 = i;
                arbol.y0 = -5.8;
                arbol.radio = 1.05;
                arbol.c = Color.White;
                arbol.gama = Math.PI / 2;
                arbol.beta = Math.PI / 6;
                arbol.ArbolF();
            }
            for (double i = -15; i <= 15; i = i + 0.5)
            {
                arbol.x0 = i;
                arbol.y0 = -5.8;
                arbol.radio = 0.65;
                arbol.c = Color.FromArgb(212,236,247);
                arbol.gama = Math.PI / 2;
                arbol.beta = Math.PI / 6;
                arbol.ArbolF();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ViewPort.BackColor = Color.Black;
            opcion = "borrador";
            ViewPort.Enabled = true;      
            
        }
        public void asignarcoordenadas()
        {
            ModelosMat.x1 = -15;
            ModelosMat.y1 = -10;
            ModelosMat.x2 = 15;
            ModelosMat.y2 = 10;
        }

        private void cmbfractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Fractal obj = new Fractal(0,0,0,0,0,Color.Black,grafico,ViewPort);
            if (cmbfractal.SelectedIndex==0)
            {
                contadorJ = 0;
                if (contadorM == 0)
                {
                    asignarcoordenadas();
                }
             int colorF;
            double x, y;
            for (int sx = 0; sx < 600; sx++)
            {
                for (int sy = 0; sy < 400; sy++)
			    {
                    if(chkPaleta0.Checked==true)
                    {
                        ModelosMat.RealXY(sx, sy, out x, out y);
                        obj.Mandelbrot(x, y, out colorF);
                        grafico.SetPixel(sx, sy, paleta0[colorF]);
                    }
                    if (chkPaleta1.Checked == true)
                    {
                        ModelosMat.RealXY(sx, sy, out x, out y);
                        obj.Mandelbrot(x, y, out colorF);
                        grafico.SetPixel(sx, sy, paleta1[colorF]);
                    }
                    
			    }
                
            }
            ViewPort.Image = grafico;
            contadorM++;
            opcion = "Zoom";
            }
            if (cmbfractal.SelectedIndex == 1)
            {
                contadorM = 0;
                if (contadorJ == 0)
                {
                    asignarcoordenadas();
                }
                int colorF;
                double x, y;
                for (int sx = 0; sx < 600; sx++)
                {
                    for (int sy = 0; sy < 400; sy++)
                    {
                        if(chkPaleta0.Checked==true)
                        {
                            ModelosMat.RealXY(sx, sy, out x, out y);
                            obj.Julia(x, y, out colorF);
                            grafico.SetPixel(sx, sy, paleta0[colorF]);
                        }
                        if (chkPaleta1.Checked == true)
                        {
                            ModelosMat.RealXY(sx, sy, out x, out y);
                            obj.Julia(x, y, out colorF);
                            grafico.SetPixel(sx, sy, paleta1[colorF]);
                        }
                       

                    }

                }
                ViewPort.Image = grafico;
                contadorJ++;
                opcion = "Zoom";
                ViewPort.Enabled = true;
            }
            if (cmbfractal.SelectedIndex == 2)
            {
                Fractal sp = new Fractal(0,0,0,0,0,Color.Red,grafico,ViewPort);
                 
                sp.Dibujar_Sierpinski( Ax,Ay, Bx,By, Cx,Cy, 4 );
            }
            if (cmbfractal.SelectedIndex == 3)
            {
                Fractal cantor = new Fractal(0, 0, 0, 0, 0, Color.Red, grafico, ViewPort);
                Segmento seg = new Segmento(-15, 9, 15, 9, Color.Red, grafico, ViewPort, 0);
                seg.Encender();
                cantor.Cantor(seg);
                
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < 600; i++)
            {
                for (int j = 320; j < 400; j++)
                {
                    grafico.SetPixel(i, j, Color.White);
                }
                ViewPort.Image = grafico;
            }*/
       

            for (int i = 0; i < 600; i++)
            {
                for (int j = 110; j < 319; j++)
                {
                    grafico.SetPixel(i, j, Color.FromArgb(Convert.ToInt32((10 * (j - 319) / (110 - 319)) + (96 * (j - 110) / (319 - 110))),
                    Convert.ToInt32((92 * (j - 319) / (110 - 319)) + (165 * (j - 110) / (319 - 110))),
                    Convert.ToInt32((169 * (j - 319) / (110 - 319)) + (231 * (j - 110) / (319 - 110)))));
                }
                ViewPort.Image = grafico;
            }
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j <= 109; j++)
                {
                    grafico.SetPixel(i, j, Color.FromArgb(Convert.ToInt32((3 * (j - 109) / (0 - 109)) + (10 * (j - 0) / (109 - 0))),
                    Convert.ToInt32((23 * (j - 109) / (0 - 109)) + (92 * (j - 0) / (109 - 0))),
                    Convert.ToInt32((78 * (j - 109) / (0 - 109)) + (169 * (j - 0) / (109 - 0)))));
                }
                ViewPort.Image = grafico;
            }
            Vector v = new Vector(0, 0, Color.White, grafico, ViewPort);
            for (double k = -5.8; k > -10; k = k - 0.01)
            {
                double x = -15;
                do
                {
                    v.x0 = x;
                    v.y0 = Math.Sin(x/4)+k;
                    x += 0.02;
                    v.c = Color.White;
                    v.Encender();
                } while (x <= 15);
            }
             for (double k = -5.5; k > -10; k = k - 0.01)
            {
                double x = -15;
                do
                {
                    v.x0 = x;
                    v.y0 = Math.Sin(x/2)+k;
                    v.c = Color.White;
                    x += 0.02;
                    v.Encender();
                } while (x <= 15);
            }
        }

        private void cmbpaisaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbpaisaje.SelectedIndex == 0)
            {
                opcion = "Flor";
            }
            if (cmbpaisaje.SelectedIndex==1)
            {
                opcion = "Nubes";
            }
            if (cmbpaisaje.SelectedIndex == 2)
            {
                double w = 0, dw = 0.05;
                Circuenferencia lu = new Circuenferencia(-5, 7, 1, Color.FromArgb(255, 255, 255), grafico, ViewPort, 0);
                do
                {
                    lu.radio = w;
                    lu.Encender();
                    w += dw;
                    //ViewPort.BackColor = Color.FromArgb(200,200,200);
                } while (w <= 1);

                w = 1;
                do
                {
                    lu.radio = w;
                    lu.c = Color.FromArgb(Convert.ToInt32((255 * (w - 1.5) / (1 - 1.5)) + (255 * (w - 1) / (1.5 - 1))),
                        Convert.ToInt32((255 * (w - 1.5) / (1 - 1.5)) + (255 * (w - 1) / (1.5 - 1))),
                        Convert.ToInt32((255 * (w - 1.5) / (1 - 1.5)) + (227 * (w - 1) / (1.5 - 1))));
                    lu.Encender();
                    w = w + dw;
                } while (w <= 1.5);
                w = 1.5;
                do
                {
                    lu.radio = w;
                    lu.c = Color.FromArgb(Convert.ToInt32((255 * (w - 2.5) / (1.5 - 2.5)) + (110 * (w - 1.5) / (2.5 - 1.5))),
                        Convert.ToInt32((255 * (w - 2.5) / (1.5 - 2.5)) + (110 * (w - 1.5) / (2.5 - 1.5))),
                        Convert.ToInt32((227 * (w - 2.5) / (1.5 - 2.5)) + (110 * (w - 1.5) / (2.5 - 1.5))));
                    lu.Encender();
                    w = w + dw;
                } while (w <= 2.5);
               
            }
            if (cmbpaisaje.SelectedIndex == 3)
            {
                Segmento re = new Segmento(-15, -5.5, 15, -5.5, Color.LightGray, grafico, ViewPort, 0);
                re.Encender();
                Segmento re1 = new Segmento(-15, -5.7, 15, -5.7, Color.LightGray, grafico, ViewPort, 0);
                re1.Encender();
                for (double i = -14; i <= 14; i = i +1)
                {
                        Segmento H = new Segmento(i, -5.3, i, -6.2, Color.FromArgb(13, 69, 19), grafico, ViewPort, 0);
                        H.Encender();
                }
            }

            if (cmbpaisaje.SelectedIndex==4)
            {
                Circuenferencia ocho = new Circuenferencia(0,0,0,Color.WhiteSmoke,grafico,ViewPort,3);
                ocho.radio = 2;
                ocho.x0 = 6.5;
                ocho.y0 = -6.5;
                ocho.c = Color.WhiteSmoke;
                ocho.Encender();
                Circuenferencia ci = new Circuenferencia(ocho.x0, (ocho.y0 + ocho.radio + ocho.radio * 0.6), (ocho.radio * 0.6),Color.WhiteSmoke,grafico,ViewPort,3);
                ci.Encender();
            }
            if (cmbpaisaje.SelectedIndex == 5)
            {
                Fractal arbol = new Fractal(6, -9.5, 3, Math.PI / 2, Math.PI / 6, Color.Green, grafico, ViewPort);

                for (double i =3.5; i > 0; i=i-0.1)
                {
                    arbol.x0 = 11;
                    arbol.y0 = -8;
                    arbol.radio = i;
                    arbol.c = Color.FromArgb(43, 132, 13);
                    arbol.gama = Math.PI / 2;
                    arbol.beta = Math.PI / 2;
                    arbol.ArbolF();
                }  
            }
        }

        private void eXAMENESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpExamenes.Parent = tabControl;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                opcion = "TrianguloEQ";
            }
            if (comboBox3.SelectedIndex==1)
            {
                opcion = "TianguloObt";
            }
            if (comboBox3.SelectedIndex == 2)
            {
                opcion = "TrianguloPuntos";
            }
            if (comboBox3.SelectedIndex == 3)
            {
                double t = -9.5;
                //do
                //{
                    Fractal arbol = new Fractal(6, -9.5, 3, Math.PI / 2, Math.PI / 6, Color.Green, grafico, ViewPort);
                    /*arbol.c = Color.FromArgb(
                                 (int)(255 * ((t - 3) / (-9.5- 3)) + 53 * ((t +9.5) / (3 +9.5))),
                                 (int)(255 * ((t - 3) / (-9.5 - 3)) + 53 * ((t + 9.5) / (3 + 9.5))),
                                 (int)(8 * ((t - 3) / (-9.5- 3)) + 53 * ((t +9.5) / (3 +9.5))));*/
                    arbol.ArbolF();
                    t = t + 0.1;
                //}while(t<=3);
                    t = 0;
                    double dw = Math.PI / 10;
                    Segmento es = new Segmento(-8, 7, 1, 1, paleta.Color, grafico, ViewPort, 0);

                    do
                    {
                        es.xf = es.x0 + 2 * Math.Cos(t);
                        es.yf = es.y0 + 2 * Math.Sin(t);
                        es.c = Color.FromArgb(
                Convert.ToInt32((0 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (5 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((255 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (0 * (t - 0) / ((2 * Math.PI) - 0))),
                Convert.ToInt32((0 * (t - (2 * Math.PI)) / (0 - (2 * Math.PI)))
                + (0 * (t - 0) / ((2 * Math.PI) - 0))));
                        es.Encender();
                        t = t + dw;
                    } while (t <= 2 * Math.PI);
               
            }
        }

        private void cmbParcial1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            double ax1 = -2, ax2 = 3, ay1 = 3, ay2 = -1, ra;
            double bx1 = ax1, bx2 = 5, by1 = ay1, by2 = 6, rb;
            double cx1 = ax2, cx2 = bx2, cy1 = ay2, cy2 = by2, rc;
            double ab, bc, xb, yb, a1, a2, h, c, p, ca, xa, ya, xc, yc;
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

            if (cmbParcial1.SelectedIndex == 4)
            {
                Segmento bi = new Segmento(ax1, ay1, ax2, ay2, Color.Black, grafico, ViewPort, 0);
                bi.Encender();
                bi.x0 = bx1;
                bi.xf = bx2;
                bi.y0 = by1;
                bi.yf = by2;
                bi.Encender();
                bi.x0 = cx1;
                bi.xf = cx2;
                bi.y0 = cy1;
                bi.yf = cy2;
                bi.Encender();
                /////////bisectriz b
                ab = Math.Sqrt(Math.Pow((ax1 - bx2), 2) + Math.Pow((ay1 - by2), 2));
                bc = Math.Sqrt(Math.Pow((bx2 - ax2), 2) + Math.Pow((by2 - ax2), 2));
                rb = ab / bc;
                xb = (ax1 + rb * ax2) / (1 + rb);
                yb = (ay1 + rb * ay2) / (1 + rb);
                bi.x0 = bx2;
                bi.y0 = by2;
                bi.xf = xb;
                bi.yf = yb;
                bi.c = Color.Green;
                bi.Encender();
                /////con la matriz puntos de los triangulos primer punto se repite
                a1 = (((ax1 * by2) + (bx2 * ay2) + (ax2 * ay1)) - ((bx2 * ay1) + (ax2 * by2) + (ax1 * ay2))) / 2;
                if (a1 < 0)
                {
                    a1 = a1 * -1;

                }
                lblarea1.Text = a1.ToString();
                /////calculando distancias
                c = Math.Sqrt(Math.Pow((ax2 - ax1), 2) + Math.Pow((ay2 - ay1), 2));
                h = Math.Sqrt(Math.Pow((xb - bx2), 2) + Math.Pow((yb - by2), 2));
                a2 = (c * h) / 2;
                lblarea2.Text = a2.ToString();
                p = ab + bc + c;
                lblperimetro.Text = p.ToString();
                ///////bisectriz de a
                ca = Math.Sqrt(Math.Pow((ax1 - ax2), 2) + Math.Pow((ay1 - ay2), 2));
                ra = ca / ab;
                xa = (ax2 + ra * bx2) / (1 + ra);
                ya = (ay2 + ra * by2) / (1 + ra);
                bi.x0 = ax1;
                bi.xf = xa;
                bi.y0 = ay1;
                bi.yf = ya;
                bi.c = Color.Green;
                bi.Encender();
                /////////bisectriz de c
                rc = bc / ca;
                xc = (bx2 + rc * ax1) / (1 + rc);
                yc = (by2 + rc * ay1) / (1 + rc);
                bi.x0 = ax2;
                bi.y0 = ay2;
                bi.xf = xc;
                bi.yf = yc;
                bi.c = Color.Green;
                bi.Encender();

            }
            if (cmbParcial1.SelectedIndex == 5)
            {
                double xma, xmb, xmc, yma, ymb, ymc, ma, mma, mb, mmb, mc, mmc, xa1, ya1, b, yb1, yc1;
                Segmento mediatriz = new Segmento(ax1, ay1, ax2, ay2, Color.Black, grafico, ViewPort, 0);
                mediatriz.Encender();
                mediatriz.x0 = bx1;
                mediatriz.xf = bx2;
                mediatriz.y0 = by1;
                mediatriz.yf = by2;
                mediatriz.Encender();
                mediatriz.x0 = cx1;
                mediatriz.xf = cx2;
                mediatriz.y0 = cy1;
                mediatriz.yf = cy2;
                mediatriz.Encender();
                xma = (ax1 + bx2) / 2;
                yma = (ay1 + by2) / 2;
                ma = (by2 - ay1) / (bx2 - ax1);
                mma = (-1 / ma);
                b = yma - mma * xma;
                xa1 = (1 / mma) * (yma - b);
                ya1 = mma * cx1 + b;
                mediatriz.x0 = xma;
                mediatriz.y0 = yma;
                mediatriz.xf = cx1;
                mediatriz.yf = ya1;
                mediatriz.c = Color.Red;
                mediatriz.Encender();
                xmb = (bx2 + cx1) / 2;
                ymb = (by2 + cy1) / 2;
                mb = (by2 - cy1) / (bx2 - cx1);
                mmb = (-1) / mb;
                b = ymb - mmb * xmb;
                yb1 = mmb * ax1 + b;
                mediatriz.x0 = xmb;
                mediatriz.y0 = ymb;
                mediatriz.xf = ax1;
                mediatriz.yf = yb1;
                mediatriz.c = Color.Red;
                mediatriz.Encender();
                xmc = (ax1 + cx1) / 2;
                ymc = (ay1 + cy1) / 2;
                mc = (cy1 - ay1) / (cx1 - ax1);
                mmc = (-1) / mc;
                b = ymc - mmc * xmc;
                yc1 = mmc * bx2 + b;
                mediatriz.x0 = xmc;
                mediatriz.y0 = ymc;
                mediatriz.xf = bx2;
                mediatriz.yf = yc1;
                mediatriz.c = Color.Red;
                mediatriz.Encender();

            }
            if (cmbParcial1.SelectedIndex == 6)
            {
                opcion = "triangulo90";
            }
        }

        private void tpSpline_Click(object sender, EventArgs e)
        {

        }

        private void ltbPares_SelectedIndexChanged(object sender, EventArgs e)
        {

           
           
        }

        private void BbtnIngresar_Click(object sender, EventArgs e)
        {
            if (poligonal >= Convert.ToInt32(txtNumero.Text)-1)
            {
                btnIngresar.Visible = false;
                //MessageBox.Show("Error");
            }

            if (this.txtX.Text!="" && this.txtY.Text!="" )
            {
                ltbPares.Items.Add("(" + this.txtX.Text + "," + this.txtY.Text + ")");
                 this.txtX.Focus();
                 this.txtY.Focus();
                 this.txtX.Clear();
                 this.txtY.Clear();
            }
            else
            {
                MessageBox.Show("Error");
                this.txtX.Focus();
                this.txtY.Focus();

            }
            poligonal++;

            for (int i = 0; i < poligonal; i++)
            {
                vx[i] = double.Parse(txtX.Text);
                vy[i] = double.Parse(txtY.Text);
                ltbPares.Items.Add( vx[i] + "," + vy[i] );
            }
        }

        private void btnSpline_Click(object sender, EventArgs e)
        {
            double a, b, c;
            double t = -15;
            double dt = 0.001;
            Vector v = new Vector(0, 0, Color.Blue, grafico, ViewPort);
            v.c = Color.Blue;
           
                while (t <= 15)
                {
                    v.x0 = t;
                    ModelosMat.Spline(vx, vy, poligonal, out a, out b, out c);
                    v.y0 = a * Math.Pow(t, 2) + b * t + c;
                    v.Encender();
                    t = t + dt;
                }
            
        }

        private void tpFractales_Click(object sender, EventArgs e)
        {

        }

        private void btnPuntosSierpinsky_Click(object sender, EventArgs e)
        {
            opcion = "PuntosSierpinsky";
            contadorSierpinsky = 0;
        }

        private void btnSierpinsky_Click(object sender, EventArgs e)
        {
            Fractal sp = new Fractal(0, 0, 0, 0, 0, paleta.Color, grafico, ViewPort);
            if (poligonal !=0)
            {
                sp.Dibujar_Sierpinski(Ax, Ay, Bx, By, Cx, Cy, contadorSierpinsky);
                contadorSierpinsky++;
            }
            else
            {
                MessageBox.Show("Ingrese los Puntos");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double tp = 1;
            int z; 
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

        private void button6_Click(object sender, EventArgs e)
        {
            int tp = 1, z,z1,z2;
            double x, y, w = 1.5, w1=2, d,d1, v = 9.3;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    ModelosMat.RealXY(i, j, out x, out y);
                    d = Math.Sqrt(Math.Pow((x + 4), 2) + Math.Pow(y, 2));
                    double k = w * (d - tp * v);
                    z1 = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);

                    d1 = Math.Sqrt(Math.Pow((x - 4), 2) + Math.Pow(y, 2));
                    double k1 = w1 * (d1 - tp * v);
                    z2 = Convert.ToInt32((Math.Sin(k1) + 1) * 7.5);

                    z = (z1 + z2) % 15;

                    grafico.SetPixel(i, j, paleta0[z]);
                }
            }
            ViewPort.Image = grafico;
        }

        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void crearInterferenciaOndas(double tp)
        {
            int  z, z1, z2;
            double x, y, w = 1.5, w1 = 2, d, d1, v = 9.3;
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    ModelosMat.RealXY(i, j, out x, out y);
                    d = Math.Sqrt(Math.Pow((x + 4), 2) + Math.Pow(y, 2));
                    double k = w * (d - tp * v);
                    z1 = Convert.ToInt32((Math.Sin(k) + 1) * 7.5);

                    d1 = Math.Sqrt(Math.Pow((x - 4), 2) + Math.Pow(y, 2));
                    double k1 = w1 * (d1 - tp * v);
                    z2 = Convert.ToInt32((Math.Sin(k1) + 1) * 7.5);

                    z = (z1 + z2) % 15;

                    grafico.SetPixel(i, j, paleta1[z]);
                }
            }
            ViewPort.Refresh();
            ViewPort.Image = grafico;
        }

     
        public void crearOndas(double tp)
        {
            int z;
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
        }
        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 18; i++)
            {
                double tp = i * 0.05;
                crearOndas(tp);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 18; i++)
            {
                double tp = i * 0.05;
                crearInterferenciaOndas(tp);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

    }
    
}
