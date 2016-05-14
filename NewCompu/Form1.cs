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

namespace NewCompu
{
    public partial class Form1 : Form
    {
        double seg1x, seg1y;
        double seg2x, seg2y;
        public double px, py, qx, qy;
        public double cx, cy;
        string op;
        RepositorioMM obj = new RepositorioMM();
        public int poligonal = 0;

        Bitmap grafico;
        Color Color0;
        Bitmap[] mafv = new Bitmap[100];
        List<Bitmap> lista = new List<Bitmap>();


        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ejerciciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void asignarcoordreales()
        {
            RepositorioMM.xmin = -14;
            RepositorioMM.xmax = 14;
            RepositorioMM.ymin = -11;
            RepositorioMM.ymax = 11;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tpEjercicios.Parent = null;
            tpGraficos2d.Parent = null;
            tpDianmicos.Parent = null;

            grafico = new Bitmap(560, 440);
            VentanaP.Image = grafico;
            Color0 = Color.Black;
        }
        
        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            asignarcoordreales();
            grafico = null;
            grafico = new Bitmap(560, 440);
            VentanaP.Image = grafico;
            poligonal = 0;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //////un pixel linea

            //for (int i = 60; i < 200; i++)
            //{
            //    grafico.SetPixel(i, i, Color.Blue);

            //}
            //VentanaP.Image = grafico;

            /////llemar toda la pantalla

            //for (int i = 1; i < 560; i++)
            //{
            //    for (int j = 1; j < 440; j++)
            //    {
            //            grafico.SetPixel(i, j, Color.Blue);
                    
            //    }

            //}
            //VentanaP.Image = grafico;

            ////mezcla de dos colores horizontal

            for (int i = 1; i < 560; i++)
            {
                for (int j = 1; j < 440; j++)
                {
                    if (i <= 280)
                    {
                        grafico.SetPixel(i, j, Color.Blue);
                    }
                    else
                    {
                        grafico.SetPixel(i, j, Color.Green);
                    }
                }

            }
            VentanaP.Image = grafico;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 560; i++)
            {
                for (int j = 1; j < 440; j++)
                {
                    Color0 = Color.FromArgb(0,(int)(0.4553)*(i),(int)(0.4553)*(560-i));
                    grafico.SetPixel(i, j, Color0);
                }

            }
            VentanaP.Image = grafico;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 560; i++)
            {
                for (int j = 1; j < 440; j++)
                {
                    Color0 = Color.FromArgb((int)(255 * i) / 560, (int)255 * (i - 560) / (-560) + 10 * (i) / 560, (int)(240 * (i - 560) / (-560) + (5 * i) / 560));
                    grafico.SetPixel(i, j, Color0);
                }

            }
            VentanaP.Image = grafico;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 560; i++)
            {
                for (int j = 1; j < 440; j++)
                {
                    if (i<j)
                    {
                        Color0 = Color.FromArgb((int)(255 * (i - 560) / (-560) + ((255 * i) / 560)), (int)245 * (i - 560) / (-560) + 10 * (i) / 560, 0);
                        grafico.SetPixel(i, j, Color0);
                    }
                    else
                    {
                        Color0 = Color.FromArgb((int)(255 * i) / 560, (int)255 * (i - 560) / (-560) + 10 * (i) / 560, (int)(240 * (i - 560) / (-560) + (5 * i) / 560));
                        grafico.SetPixel(i, j, Color0);
                    }
                    
                }

            }
            VentanaP.Image = grafico;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            v.x0 = 0;
            v.y0 = 0;
            v.color0 = Color.Red;
            v.Encender(grafico);
            VentanaP.Image = grafico;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento();
            s.x0 = 8;
            s.y0 = -8;
            s.xf = 0;
            s.yf = 0;
            s.color0 = Color.Black;
            s.Encender(grafico);
            VentanaP.Image = grafico;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento();
            Segmento s1 = new Segmento();
            s.x0 = 14;
            s.y0 = -14;
            s.xf = 0;
            s.yf = 0;
            s.color0 = Color.Black;
            s.Encender(grafico);
            s1.x0 = 0;
            s1.y0 = 0;
            s1.xf = 11;
            s1.yf =-11;
            s1.color0 = Color.Black;
            s1.Encender(grafico);
            VentanaP.Image = grafico;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento();
            s.x0 =-14;
            s.y0 = 0;
            s.xf = 14;
            s.yf = 0;
            s.color0 = Color.Green;
            s.Encender(grafico);

            s.x0 = 0;
            s.y0 = 11;
            s.xf = 0;
            s.yf = -11;
            s.color0 = Color.Green;
            s.Encender(grafico);

            VentanaP.Image = grafico;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia();
            c.x0 = 0;
            c.y0 = 0;
            c.radio = 5;
            c.color0 = this.Color0;
            c.EncCircunferencia(grafico);

            c.x0 = 7;
            c.y0 = 7;
            c.radio = 2;
            c.color0 = this.Color0;
            c.EncCircunferencia(grafico);

            c.x0 = 7;
            c.y0 = -7;
            c.radio = 3;
            c.color0 = this.Color0;
            c.EncCircunferencia(grafico);

            Segmento s = new Segmento();
            s.x0 = 4;
            s.y0 = -4;
            s.xf = 10;
            s.yf = -10;
            s.color0 = Color.Black;
            s.Encender(grafico);

            VentanaP.Image = grafico;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Lazo l = new Lazo(5, 5, 3, Color.Black);
            l.EncenderLazo(grafico);
            VentanaP.Refresh();
            VentanaP.Image = grafico;

           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CurvaV h = new CurvaV(-6, 6, 3, Color.Black);
            h.Encender(grafico);
            VentanaP.Image = grafico;

           

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Margarita h = new Margarita(-5, -6, 4, Color.Black);
            h.Encender(grafico);
            VentanaP.Image = grafico;
           
        }

        private void BtnCircunferencia_Click(object sender, EventArgs e)
        {
            op = "Circunferencia";
        }

        private void BtnSegmento_Click(object sender, EventArgs e)
        {
            op = "Segmento";
        }

       
        private void button3_Click_1(object sender, EventArgs e)
        {
            op = "Circunferencia";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            op = "Segmento";
        }

        void apagar(double x, double y)
        {
            Circunferencia cb = new Circunferencia();
            cb.x0 = x;
            cb.y0 = y;
            cb.color0 = Color.White;
            cb.radio = 0.5;
            cb.Encender(grafico);
            cb.radio = 0.4;
            cb.Encender(grafico);
            cb.radio = 0.3;
            cb.Encender(grafico);
            cb.radio = 0.2;
            cb.Encender(grafico);
            cb.radio = 0.1;
            cb.Encender(grafico);
            VentanaP.Image = grafico;
        }

        private void VentanaP_MouseUp(object sender, MouseEventArgs e)
        {

            if (op == "borrador")
            {
                op = "Borrador";
            }

            RepositorioMM.Carta(e.X, e.Y, out qx, out qy);
            double d = Math.Sqrt(Math.Pow((px - qx), 2) + Math.Pow((py - qy), 2));


            switch (op)
            {
                case "Circunferencia":
                    Circunferencia c = new Circunferencia();
                    c.x0 = px;
                    c.y0 = py;
                    c.radio = d;
                    c.color0 = Color0;
                    c.EncCircunferencia(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "Segmento":
                    Segmento s = new Segmento(px, py, qx, qy, Color0);
                    s.Encender(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "Margarita":
                    Margarita m = new Margarita(px, py, d, Color0);
                    m.Encender(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "Lazo":
                    Lazo l = new Lazo(px, py, d, Color0);
                    l.EncenderLazo(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "Lemiscata":
                    CurvaV Cv = new CurvaV(px, py, d, Color0);
                    Cv.Encender(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "cic":
                    
                    Circunferencia c2 = new Circunferencia();
                    c2.x0 = px;
                    c2.y0 = (px + 13) * (13 - px) / 30;
                    c2.radio = 0.3;
                    c2.color0 = Color.Blue;
                    c2.EncCircunferencia(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "seggg":
                    Segmento seg = new Segmento();
                    seg.Recta(px, py, d);
                    seg.Encender(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "d":
                    Circunferencia ld = new Circunferencia(px, py, d, paleta.Color);
                    ld.Ld(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "n":
                    Circunferencia ln = new Circunferencia(px, py, d, paleta.Color);
                    ln.Ln(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "m":
                    Circunferencia lm = new Circunferencia(px, py, d, paleta.Color);
                    lm.Lm(grafico);
                    VentanaP.Image = grafico;
                    break;
                // NÚMEROS 

                case "1":
                    Circunferencia uno = new Circunferencia(px, py, d, paleta.Color);
                    uno.EncenderUno(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "2":
                    Circunferencia dos = new Circunferencia(px, py, d, paleta.Color);
                    dos.EncenderDos(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "3":
                    Circunferencia tres = new Circunferencia(px, py, d, paleta.Color);
                    tres.EncenderTres(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "4":
                    Circunferencia cuatro = new Circunferencia(px, py, d, paleta.Color);
                    cuatro.EncenderCuatro(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "5":
                    Circunferencia cinco = new Circunferencia(px, py, d, paleta.Color);
                    cinco.EncenderCinco(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "6":
                    Circunferencia seis = new Circunferencia(px, py, d, paleta.Color);
                    seis.EncenderSies(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "7":
                    Circunferencia siete = new Circunferencia(px, py, d, paleta.Color);
                    siete.EncenderSiete(grafico);
                    VentanaP.Image = grafico;
                    break;

                case "8":
                    Circunferencia cirf = new Circunferencia(px, py, d, paleta.Color);
                    Circunferencia cir = new Circunferencia(px, py + (d * 0.5) + d, d * 0.5, paleta.Color);
                    cirf.EncCircunferencia(grafico);
                     cir.EncCircunferencia(grafico);                    
                    VentanaP.Image = grafico;
                    break;

                case "9":
                    Circunferencia nueve = new Circunferencia(px, py, d, paleta.Color);
                    nueve.EncendeNueve(grafico);
                    VentanaP.Image = grafico;
                    break;
                    // m = ((-2 * px) * 28) / Math.Pow(28, 2);
                    /* case "Circunferencia":
                         Circunferencia c = new Circunferencia();
                         c.x0 = px;
                         c.y0 = py;
                         c.radio = d;
                         c.c = Color.Red;
                         c.EncCircunferencia(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "Puntos":
                         double m, yn1, yn2;
                         Circunferencia c2 = new Circunferencia();
                         c2.x0 = px;
                         c2.y0 = (225 - (px * px)) / 28;
                         c2.radio = 0.3;
                         c2.c = Color.Blue;
                         c2.EncCircunferencia(grafico);
                         VentanaP.Image = grafico;

                         m = ((-2 * px) * 28) / Math.Pow(28, 2);

                         Segmento sg = new Segmento();
                         sg.segmento2(c2.x0, c2.y0, m, out yn1, out yn2);
                         sg.x0 = -15;
                         sg.y0 = yn1;
                         sg.xf = 15;
                         sg.yf = yn2;
                         sg.c = Color.Blue;
                         sg.EncenderSegmento(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "Segmento":
                         Segmento s = new Segmento(px, py, qx, qy, Color.Blue);
                         s.EncenderSegmento(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "Circulo":
                         Circunferencia c1 = new Circunferencia(px, py, d, paleta.Color );
                         c1.EncCircunferencia(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "Lazo":
                         Lazo l = new Lazo(px, py, d, 0.9, Color.Black);
                         l.EncenderLazoRotar(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "Hipociclo":
                         Hipociclo h = new Hipociclo(px, py, d, Color.Orange);
                         h.EncenderHipociclo(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "Poligono":
                         Poligono p = new Poligono(px, py, d, num, paleta.Color);
                         p.EncPoligono(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "CEntrecortada":
                         Circunferencia c3 = new Circunferencia(px, py, d, Color.BlueViolet);
                         c3.CEntrecortada(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "CLlenada":
                         Circunferencia c4 = new Circunferencia(px, py, d, Color.Blue);
                         c4.CLlenada(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "SEntrecortado":
                         Segmento s1 = new Segmento(px, py, qx, qy, Color.Blue);
                         s1.SEntrecortado(grafico);
                         VentanaP.Image = grafico;
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
                             VentanaP.Image = grafico;
                         }
                         break;

                     case "Examen":

                         double m11, yn11, yn21;
                         Circunferencia c21 = new Circunferencia();
                         c21.x0 = px;
                         c21.y0 = (7 * Math.Sin(px / 3));
                         c21.radio = 0.2;
                         c21.c = Color.Red;
                         c21.EncenderI(grafico);
                         VentanaP.Image = grafico;

                         m11 = (7 * (3 / Math.Pow(3, 2)) * Math.Cos(px / 3));

                         Segmento sg1 = new Segmento();
                         sg1.segmento2(c21.x0, c21.y0, m11, out yn11, out yn21);
                         sg1.x0 = -15;
                         sg1.y0 = yn11;
                         sg1.xf = 15;
                         sg1.yf = yn21;
                         sg1.c = Color.Blue;
                         sg1.EncenderSegmento(grafico);
                         VentanaP.Image = grafico;
                         break;

                     case "Curvas de Ajuste":
                         Circunferencia aj = new Circunferencia();
                         aj.radio = 0.2;
                         aj.x0 = px;
                         aj.y0 = py;
                         aj.c = Color.Red;
                         aj.EncenderI(grafico);
                         VentanaP.Image = grafico;*/
                    /*vx[poligonal] = px;
                    vy[poligonal] = py;
                    poligonal
                    */

                    /*  Vector vector = new Vector();
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
                          VentanaP.Image = grafico;
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
                              VentanaP.Image = grafico;



                              sv.EncenderSegmento(grafico);
                              VentanaP.Image = grafico;
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
                      Circunferencia ltt = new Circunferencia(px, py, d, Color.Black);
                      ltt.Letrateta(grafico);
                      VentanaP.Image = grafico;
                      break;


                  case "q":
                      Circunferencia lq = new Circunferencia(px, py, d, Color.Black);
                      lq.Letraq(grafico);
                      VentanaP.Image = grafico;
                      break;

                  case "h":
                      Circunferencia lh = new Circunferencia(px, py, d, Color.Black);
                      lh.Letrah(grafico);
                      VentanaP.Image = grafico;
                      break;

                  case "f":
                      Circunferencia lf = new Circunferencia(px, py, d, Color.Black);
                      lf.Letraf(grafico);
                      VentanaP.Image = grafico;
                      break;

                  case "m":
                      Circunferencia lm = new Circunferencia(px, py, d, Color.Black);
                      lm.EncenderCirculoLm(grafico);
                      VentanaP.Image = grafico;
                      break;

                  

                  case "Mandelbrot":
                      double Lx = .x2 - RepositorioMM.x1;
                      double Ly = RepositorioMM.y2 - RepositorioMM.y1;
                      double xf2, yf2, xf, yf;
                      double L = Lx / 15;
                      double L1 = Ly / 15;
                      lblLX1.Text = Convert.ToString(L);
                      lblX2.Text = Convert.ToString(L1);
                      Segmento seg1 = new Segmento(px - L / 2, py + L1 / 2, px + L / 2, py + L1 / 2, Color.White);
                      seg1.EncenderSegmento(grafico);
                      VentanaP.Image = grafico;
                      Segmento seg2 = new Segmento(px - L / 2, py - L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                      seg2.EncenderSegmento(grafico);
                      VentanaP.Image = grafico;
                      Segmento seg3 = new Segmento(px - L / 2, py + L1 / 2, px - L / 2, py - L1 / 2, Color.White);
                      seg3.EncenderSegmento(grafico);
                      VentanaP.Image = grafico;
                      Segmento seg4 = new Segmento(px + L / 2, py + L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                      seg4.EncenderSegmento(grafico);
                      Thread.Sleep(1000);
                      VentanaP.Image = grafico;
                      VentanaP.Refresh();
                      xf = px - L / 2;
                      yf = py - L1 / 2;
                      xf2 = px + L / 2;
                      yf2 = py + L1 / 2;
                      RepositorioMM.x1 = xf;
                      RepositorioMM.x2 = xf2;
                      RepositorioMM.y1 = yf;
                      RepositorioMM.y2 = yf2;
                      cmbFractales_SelectedIndexChanged(null, null);
                      //btnFractal_Click(null, null);
                      break;

                  case "Julia":
                      Lx = 0;
                      Ly = 0;
                      Lx = RepositorioMM.x2 - RepositorioMM.x1;
                      Ly = RepositorioMM.y2 - RepositorioMM.y1;
                      L = Lx / 15;
                      L1 = Ly / 15;
                      lblLX1.Text = Convert.ToString(L);
                      lblX2.Text = Convert.ToString(L1);
                      Segmento seg5 = new Segmento(px - L / 2, py + L1 / 2, px + L / 2, py + L1 / 2, Color.White);
                      seg5.EncenderSegmento(grafico);
                      VentanaP.Image = grafico;
                      Segmento seg6 = new Segmento(px - L / 2, py - L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                      seg6.EncenderSegmento(grafico);
                      VentanaP.Image = grafico;
                      Segmento seg7 = new Segmento(px - L / 2, py + L1 / 2, px - L / 2, py - L1 / 2, Color.White);
                      seg7.EncenderSegmento(grafico);
                      VentanaP.Image = grafico;
                      Segmento seg8 = new Segmento(px + L / 2, py + L1 / 2, px + L / 2, py - L1 / 2, Color.White);
                      seg8.EncenderSegmento(grafico);
                      Thread.Sleep(1000);
                      VentanaP.Image = grafico;
                      VentanaP.Refresh();
                      xf = px - L / 2;
                      yf = py - L1 / 2;
                      xf2 = px + L / 2;
                      yf2 = py + L1 / 2;
                      RepositorioMM.x1 = xf;
                      RepositorioMM.x2 = xf2;
                      RepositorioMM.y1 = yf;
                      RepositorioMM.y2 = yf2;
                      cmbFractales_SelectedIndexChanged(null, null);
                      //btnFractal_Click(null, null);
                      break;

                  case "PuntosSierpinsky":
                      {
                          Circunferencia aj1 = new Circunferencia(0, 0, 0, Color.Blue);
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
                          VentanaP.Image = grafico;
                      }
                      break;

                  case "CuadradoPuntos":
                      int ab, bc, ac, per, sp, a = 0;
                      Segmento tripuntos = new Segmento();
                      Circunferencia aj2 = new Circunferencia();
                      aj2.radio = 0.2;
                      aj2.x0 = px;
                      aj2.y0 = py;
                      vx[poligonal] = px;
                      vy[poligonal] = py;
                      poligonal++;
                      aj2.c = Color.Blue;
                      aj2.EncenderI(grafico);
                      VentanaP.Image = grafico;

                      for (int i = 0; i < poligonal - 1; i++)
                      {
                          tripuntos.x0 = vx[i];
                          tripuntos.y0 = vy[i];
                          tripuntos.xf = vx[i + 1];
                          tripuntos.yf = vy[i + 1];
                          tripuntos.c = Color.Black;
                          tripuntos.EncenderSegmento(grafico);
                          VentanaP.Image = grafico;

                          if (poligonal == 4)
                          {
                              tripuntos.x0 = vx[3];
                              tripuntos.y0 = vy[3];
                              tripuntos.xf = vx[0];
                              tripuntos.yf = vy[0];
                              tripuntos.c = Color.Black;
                              tripuntos.EncenderSegmento(grafico);
                              VentanaP.Image = grafico;

                          }
                      }

                      break;*/
            }


            //*********** FIN ***********






        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            op = "Margarita";
        }

        private void dinamicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tpGraficos2d.Parent = null;
            tpEjercicios.Parent = null;
            tpDianmicos.Parent = tabControl;
        }

        private void ejerciciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tpEjercicios.Parent = tabControl;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            op = "Lazo";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            op = "Lemiscata";
        }

        private void BtnColores_Click(object sender, EventArgs e)
        {
            paleta.ShowDialog();
            Color0 = paleta.Color;
        }

        private void limpiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            asignarcoordreales();
            grafico = null;
            grafico = new Bitmap(560, 440);
            VentanaP.Image = grafico;
            poligonal = 0;
        }

        private void BtnFunciones_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            double x, dx;
            x = -13;
            dx = 0.001;
            do
            {
                v.x0 = x;
                v.y0 = (x + 13) * (13 - x) / 30;
                //v.y0 = 5*Math.Sin(x);
                //v.y0 = Math.Pow(2,x);
                //v.y0 = Math.Tan(x);
                v.color0 = paleta.Color;
                v.Encender(grafico);
                x = x +dx;
                op = "cic";
            }
            while (x <= 13);
            VentanaP.Image = grafico;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Segmento seg = new Segmento();
            seg.Recta(0,0,0);
            seg.Encender(grafico);
            VentanaP.Image = grafico;
            op = "seggg";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            op = "m";
        }

        private void cbNumeros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNumeros.SelectedIndex == 0)
            {
                op = "1";
            }
            if (cbNumeros.SelectedIndex == 1)
            {
                op = "2";
            }
            if (cbNumeros.SelectedIndex == 2)
            {
                op = "3";
            }
            if (cbNumeros.SelectedIndex == 3)
            {
                op = "4";
            }
            if (cbNumeros.SelectedIndex == 4)
            {
                op = "5";
            }
            if (cbNumeros.SelectedIndex == 5)
            {
                op = "6";

            }
            if (cbNumeros.SelectedIndex == 6)
            {
                op = "7";
            }
            if (cbNumeros.SelectedIndex == 7)
            {
                op = "8";
            }
            if (cbNumeros.SelectedIndex == 8)
            {
                op = "9";
            }
        }

        private void cbLetras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNumeros.SelectedIndex == 0)
            {
                op = "m";
            }
            if (cbNumeros.SelectedIndex == 1)
            {
                op = "n";
            }
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            Margarita ma = new Margarita();

            double w = -10, dw = 0.3;
     {
                Margarita m = new Margarita();
                do
                {
                    m.x0 = w;
                    m.y0 = Math.Sin(w);
                    m.radio = 2;
                    m.color0 = Color.Red;
                    m.Encender(grafico);
                    
                    Thread.Sleep(200);
                    
                    
                    m.Apagar(grafico);
                    Refresh();
                    w = w + dw;

                    m.Encender(grafico);
                } while (w <= 10);
                VentanaP.Image = grafico;
            }
         }

        private void button9_Click_1(object sender, EventArgs e)
        {
            double w = 0, dw = 0.3;
            Margarita m = new Margarita();
            m.x0 = 0;
            m.y0 = 0;
            m.radio = 2;
            m.Encender(grafico);

            do
            {
                m.alfa = w;
                m.color0 = Color.Red;
               
                m.Encender(grafico);
                Thread.Sleep(200);
                m.Apagar(grafico);
                Refresh();
                w = w + dw;

            } while (w <= 2 * Math.PI);
            VentanaP.Image = grafico;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Vector v = new Vector();
            double x = -4, dx = 0.001;
            do
            {
                v.x0 = x;
                v.y0 = -(x-4)*(x+4)/4;
                v.color0 = Color.Black;
                v.Encender(grafico);
                x = x + dx;
            } while (x <= 4);
            VentanaP.Image = grafico;

            Segmento s = new Segmento();
            s.x0 = -12;
            s.y0 = 0;
            s.xf = -4;
            s.yf = 0;
            s.color0 = Color.Black;
            s.Encender(grafico);
            VentanaP.Image = grafico;

            s.x0 = 4;
            s.y0 = 0;
            s.xf = 12;
            s.yf = 0;
            s.color0 = Color.Black;
            s.Encender(grafico);
            VentanaP.Image = grafico;

            Margarita m = new Margarita();
            double w = -12, dw = 0.5;
            do
            {
                m.x0 = w;
                m.y0 = 1.7;
                m.radio = 1.5;
                m.alfa = w;
                m.color0 = Color.Red;
                m.Encender(grafico);
                VentanaP.Image = grafico;
                VentanaP.Refresh();
                Thread.Sleep(200);
                m.Apagar(grafico);
                w = w + dw;
            } while (w <= -4);


            w = -4; dw = 0.5;
            do
            {
                m.x0 = w;
                m.y0 = -(w - 4) * (w+ 4)/4+3;
                m.radio = 1.5;
                m.alfa = w;
                m.color0 = Color.Red;
                m.Encender(grafico);
                VentanaP.Image = grafico;
                VentanaP.Refresh();
                Thread.Sleep(200);
                m.Apagar(grafico);
                w = w + dw;
            } while (w <= 4);

            w = 4; dw = 0.5;
            do
            {
                m.x0 = w;
                m.y0 = 1.7;
                m.radio = 1.5;
                m.alfa = w;
                m.color0 = Color.Red;
                m.Encender(grafico);
                VentanaP.Image = grafico;
                VentanaP.Refresh();
                Thread.Sleep(200);
                m.Apagar(grafico);
                w = w + dw;
            } while (w <= 12);
            m.color0 = Color.Red;
            m.Encender(grafico);
        }

        private void BtnBorrardor_Click(object sender, EventArgs e)
        {
            op = "BORRA";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Margarita m = new Margarita(-5, -6, 4, Color.Black);
            m.Encender(grafico);
            VentanaP.Image = grafico;
            Segmento s = new Segmento();
            s.x0 = -3;
            s.y0 = -5;
            s.xf = -8;
            s.yf = -8;
            s.color0 = Color.Black;
            s.Encender(grafico);

            VentanaP.Image = grafico;


            CurvaV c = new CurvaV(-6, 6, 3, Color.Black);
            c.Encender(grafico);
            VentanaP.Image = grafico;
          
           

            Segmento s1 = new Segmento();
            s1.x0 = -3;
            s1.y0 = 5;
            s1.xf = -8;
            s1.yf = 8;
            s1.color0 = Color.Black;
           

            VentanaP.Image = grafico;


            

            Lazo l = new Lazo(5, 5, 3, Color.Black);
            l.EncenderLazo(grafico);
            VentanaP.Refresh();
            VentanaP.Image = grafico;

            Segmento s2 = new Segmento();
            s2.x0 = 10;
            s2.y0 = 10;
            s2.xf = 1;
            s2.yf = 1;
            s2.color0 = Color.Black;
            s2.Encender(grafico);

            VentanaP.Image = grafico;


            Circunferencia cir = new Circunferencia();
           

            cir.x0 = 7;
            cir.y0 = -7;
            cir.radio = 3;
            cir.color0 = this.Color0;
            cir.EncCircunferencia(grafico);
           

            Segmento s3 = new Segmento();
            s3.x0 = 4;
            s3.y0 = -4;
            s3.xf = 10;
            s3.yf = -10;
            s3.color0 = Color.Black;
            s3.Encender(grafico);

            VentanaP.Image = grafico;


            Segmento s4 = new Segmento();
            s4.x0 = -14;
            s4.y0 = 0;
            s4.xf = 14;
            s4.yf = 0;
            s4.color0 = Color.Green;
            s4.Encender(grafico);

            s4.x0 = 0;
            s4.y0 = 11;
            s4.xf = 0;
            s4.yf = -11;
            s4.color0 = Color.Green;
            s4.Encender(grafico);

            VentanaP.Image = grafico;


            c.Encender(grafico);
            Refresh();
            Thread.Sleep(2000);
            c.Apagar(grafico);
            Refresh();
            Thread.Sleep(2000);
            cir.Apagar(grafico);

            Refresh();
            Thread.Sleep(2000);
            c.Apagar(grafico);
        }

        private void Apagar_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            v.x0 = 7;
            v.y0 = 6;
            v.Encender(grafico);
            //Thread.Sleep(2000);

            v.color0 = Color.Red;
            VentanaP.Image = grafico;
                
            
        }

        private void VentanaP_MouseMove(object sender, MouseEventArgs e)
        {


            double x = e.X;
            double y = e.Y;
            double a, b;
            a = Math.Round(RepositorioMM.CartaX(cx), 3);
            b = Math.Round(RepositorioMM.CartaX(cy), 3);

            cx = x;
            cy = y;

            toolStripStatusLabel.Text = " COORDENADAS: " + a.ToString() + "  /  " + b.ToString();

            // BORRADOR 
            if (op == "borrador")
            {
                dibujar(a, b);
            }

        }

        void dibujar(double x, double y)
        {
            Circunferencia cb = new Circunferencia();
            cb.x0 = x;
            cb.y0 = y;
            cb.color0 = Color.Violet;
            cb.radio = 0.5;
            cb.Encender(grafico);
            cb.radio = 0.4;
            cb.Encender(grafico);
            cb.radio = 0.3;
            cb.Encender(grafico);
            cb.radio = 0.2;
            cb.Encender(grafico);
            cb.radio = 0.1;
            cb.Encender(grafico);
            VentanaP.Image = grafico;
            VentanaP.Refresh();
            Thread.Sleep(10);
            apagar(x, y);
        }

        private void VentanaP_MouseDown(object sender, MouseEventArgs e)
        {
            
            RepositorioMM.Carta(e.X,e.Y,out px, out py);
            
            if (op == "BORRA")
            {
                op = "borrardor";
            }
        }
    }
}
