using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCompu
{
    public partial class Form1 : Form
    {
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
            tpEjercicios.Parent = tabControl;
            
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

            grafico = new Bitmap(560, 440);
            VentanaP.Image = grafico;
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
    }
}
