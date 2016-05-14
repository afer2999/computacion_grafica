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
        Color Color0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 600; i++)
            {
                for (int j = 1; j < 400; j++)
                {
                    grafico.SetPixel(i, j, Color.Red);

                }
            }
            ViewPort.Image = grafico;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafico= new Bitmap(600,400);
            ViewPort.Image=grafico;
            Color0 = Color.Black;
            
        }

        private void ViewPort_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 600; i++)
            {
                for (int j = 1; j < 400; j++)
                {
                    if (j <= 200)
                    {
                        grafico.SetPixel(i, j, Color.Red);
                    }
                    else
                    {
                        grafico.SetPixel(i, j, Color.Yellow);
                    }
                    

                }
            }
            ViewPort.Image = grafico;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 600; i++)
            {
                for (int j = 1; j < 400; j++)
                {
                    //grafico.SetPixel(i, j, Color.FromArgb(255,(int)(0.64*(j-1)),0));
                    grafico.SetPixel(i, j, Color.FromArgb(255, (int)((255 * (j - 400)) / (-400)), 0));

                }
            }
            ViewPort.Image = grafico;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 600; i++)
            {
                for (int j = 1; j < 400; j++)
                {
                    if (j < 200)
                    {
                        grafico.SetPixel(i, j, Color.FromArgb(255, (int)((255 * j) / 200), 0));
                    }
                    else
                    {
                        grafico.SetPixel(i, j, Color.FromArgb((int)((255*2)-255),(int)(255*(j-400)/(-200)), 0));
                    }
                }
            }
            ViewPort.Image = grafico;
        }

        private void bVector_Click(object sender, EventArgs e)
        {
            Vector v = new Vector(0, 0, Color.Red, grafico, ViewPort);
            v.Encender();
            v.x0 = 10;
            v.y0 = 5;
            v.Encender();
            Thread.Sleep(1000);
            v.Apagar(ViewPort.BackColor);
            
        }

        private void bVector2_Click(object sender, EventArgs e)
        {
            Vector v = new Vector(10, 5, Color.Red, grafico, ViewPort);
            v.Encender();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia(0,0, 3, Color0,grafico, ViewPort,0);
            c.Encender();
            

            //Thread.Sleep(20);
            //c.Apagar();
        
            c.x0 = 8;
            c.c = Color.Green;
            c.Encender();
            
            c.y0 = -5;
            c.c = Color.Violet;
            c.Encender();
           
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Lazo l = new Lazo(0, 0,0, Color0, grafico, ViewPort,0);
            l.x0 = 10;
            l.y0 = 5;
            l.radio = 3;
            l.Encender();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
            Hipociclo l = new Hipociclo(0, 0, 0, Color0, grafico, ViewPort,0);
            l.x0 = -5;
            l.y0 = 5;
            l.radio = 4;
            l.Encender();
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento(0, 0,0,0,Color0, grafico, ViewPort,0);
            s.x0 = 0;
            s.y0 = -5;
            s.xf = 0;
            s.yf = 5;
            s.Encender();
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia(0,0,3,Color.Red,grafico,ViewPort,0);
            c.Encender();
            Thread.Sleep(1000);
            c.Apagar(ViewPort.BackColor);

            Lazo l = new Lazo(10, 5, 2, Color.Gray, grafico, ViewPort,0);
            l.Encender();

            Hipociclo l1 = new Hipociclo(-5, 5, 4, Color.Blue, grafico, ViewPort,0);
            l1.Encender();


            Segmento s = new Segmento(5, -1, 1, 5, Color.Maroon, grafico, ViewPort,0);
            s.Encender();
            Thread.Sleep(1000);
            s.Apagar(ViewPort.BackColor);
            
            
        }

        private void btnSgInt_Click(object sender, EventArgs e)
        {
            Segmento segint = new Segmento(-5,3,6,8,Color0,grafico,ViewPort,1);
            segint.Encender();
        }

        private void btnSegColor_Click(object sender, EventArgs e)
        {
            Segmento segcolor = new Segmento(11,-2,6,9,Color0,grafico,ViewPort,2);
            segcolor.Encender();
        }

        private void btnSegInt3_Click(object sender, EventArgs e)
        {
            Segmento SgInt3 = new Segmento(6,-3,10,10,Color0,grafico,ViewPort,3);
            SgInt3.Encender();
        }

        private void btnCirInt_Click(object sender, EventArgs e)
        {
            Circunferencia cirint = new Circunferencia(-2,0,3,Color0,grafico,ViewPort,1);
            cirint.Encender();
        }

        private void btnCirColor_Click(object sender, EventArgs e)
        {
            Circunferencia circolor = new Circunferencia(5,0,3,Color0,grafico,ViewPort,2);
            circolor.Encender();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Circunferencia cirint3 = new Circunferencia(0,0,3,Color0,grafico,ViewPort,3);
            cirint3.Encender();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double xi = 0, yi = 2, xif = -2, yif = -2, xa, ya, xb, yb, xc, yc;
            /////ocho
            Circunferencia ocho = new Circunferencia(-1, 0, 2, Color0, grafico, ViewPort, 0);
            //ocho.Encender();
            ocho.x0 = -1;
            ocho.y0 = -5;
            ocho.radio = 3;
            //ocho.Encender();

            ////letra L
            Segmento sg = new Segmento(0, 0, 0, 4, Color0, grafico, ViewPort, 0);
            //sg.Encender();
            sg.x0 = 0;
            sg.y0 = 0;
            sg.xf = 2.5;
            sg.yf = 0;
            //sg.Encender();
            //////letra T
            Segmento T = new Segmento(0, 0, 0, 4, Color0, grafico, ViewPort, 0);
            //T.Encender();
            T.x0 = -1.5;
            T.y0 = 4;
            T.xf = 1.5;
            //T.Encender();
            /////cuadrado
            Segmento cuadrado = new Segmento(-2,2,-2,-2,Color0,grafico,ViewPort,0);
            //cuadrado.Encender();
            cuadrado.x0 = 2;
            cuadrado.xf = 2;
            //cuadrado.Encender();
            cuadrado.x0 = -2;
            cuadrado.y0 = 2;
            cuadrado.xf = 2;
            cuadrado.yf = 2;
            //cuadrado.Encender();
            cuadrado.x0 = -2;
            cuadrado.y0 = -2;
            cuadrado.xf = 2;
            cuadrado.yf = -2;
            //cuadrado.Encender();
            ///circulo en el cuadrado
            ocho.x0 = 0;
            ocho.y0 = 0;
            ocho.radio = 2;
            ocho.c = Color.Red;
            //ocho.Encender();
            //triangulo en el cuadrado
            cuadrado.x0 = 0;
            cuadrado.y0 = 2;
            cuadrado.xf = -2;
            cuadrado.yf = -2;
            cuadrado.c = Color.Purple;
            cuadrado.Encender();
            //////////punto medio A
            xa = (cuadrado.x0 + cuadrado.xf) / 2;
            ya = (cuadrado.y0 + cuadrado.yf) / 2;
            cuadrado.xf = 2;
            //////punto medio b
            xb = (cuadrado.x0 + cuadrado.xf) / 2;
            yb = (cuadrado.y0 + cuadrado.yf) / 2;
            cuadrado.Encender();
            /////////mediana a
            cuadrado.x0 = xa;
            cuadrado.y0 = ya;
            cuadrado.c = Color.Green;
            cuadrado.Encender();
            /////mediana b
            cuadrado.x0 = xb;
            cuadrado.y0 = yb;
            cuadrado.xf = -2;
            cuadrado.yf = -2;
            cuadrado.Encender();
            
            cuadrado.x0 = -2;
            cuadrado.y0 = -2;
            cuadrado.xf = 2;
            cuadrado.yf = -2;
            cuadrado.c = Color.Purple;
            ///////punto medio c
            xc = (cuadrado.x0 + cuadrado.xf) / 2;
            yc = (cuadrado.y0 + cuadrado.yf) / 2;
            cuadrado.Encender();
            /////////media c
            cuadrado.x0 = xc;
            cuadrado.y0 = yc;
            cuadrado.xf = 0;
            cuadrado.yf = 2;
            cuadrado.c = Color.Green;
            cuadrado.Encender();
            cuadrado.x0 = 0;
            cuadrado.y0 = 2;
            cuadrado.xf = 2;
            cuadrado.yf = 0;
            cuadrado.c = Color.Green;
            //cuadrado.Encender();
            cuadrado.x0 = 0;
            cuadrado.y0 = 2;
            cuadrado.xf = -2;
            cuadrado.yf = 0;
            //cuadrado.Encender();
            cuadrado.x0 = -2;
            cuadrado.y0 = 0;
            cuadrado.xf = 2;
            cuadrado.yf = 0;
            //cuadrado.Encender();
            
            
        }

        private void cbrepaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            double ax1 = -2, ax2 = 3, ay1 = 3, ay2 = -1,ra;
            double bx1 = ax1, bx2 = 5, by1 = ay1, by2 = 6,rb;
            double cx1 = ax2, cx2=bx2, cy1=ay2,cy2=by2,rc;
            double ab, bc,xb,yb,a1,a2,h,c,p,ca,xa,ya,xc,yc;
            if (cbrepaso.SelectedIndex==0)
            {
                Segmento bi = new Segmento(ax1, ay1, ax2, ay2, Color0, grafico, ViewPort, 0);
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
                ab = Math.Sqrt(Math.Pow((ax1-bx2),2)+Math.Pow((ay1-by2),2));
                bc = Math.Sqrt(Math.Pow((bx2-ax2),2)+Math.Pow((by2-ax2),2));
                rb = ab / bc;
                xb = (ax1 + rb * ax2)/(1+rb);
                yb = (ay1 + rb * ay2)/(1+rb);
                bi.x0 = bx2;
                bi.y0 = by2;
                bi.xf = xb;
                bi.yf = yb;
                bi.c = Color.Green;
                bi.Encender();
                /////con la matriz puntos de los triangulos primer punto se repite
                a1=(((ax1*by2)+(bx2*ay2)+(ax2*ay1))-((bx2*ay1)+(ax2*by2)+(ax1*ay2)))/2;
                if (a1 < 0)
                {
                    a1 = a1 * -1;

                }
                lblarea1.Text = a1.ToString();
                /////calculando distancias
                c=Math.Sqrt(Math.Pow((ax2 - ax1), 2) + Math.Pow((ay2 - ay1), 2));
                h = Math.Sqrt(Math.Pow((xb - bx2), 2) + Math.Pow((yb - by2), 2));
                a2 = (c * h) / 2;
                lblarea2.Text = a2.ToString();
                p=ab + bc + c;
                lblperimetro.Text = p.ToString();
                ///////bisectriz de a
                ca = Math.Sqrt(Math.Pow((ax1-ax2),2)+Math.Pow((ay1-ay2),2));
                ra = ca / ab;
                xa = (ax2 + ra * bx2)/(1+ra);
                ya = (ay2 + ra * by2)/(1+ra);
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
            if (cbrepaso.SelectedIndex == 1)
            {
                double xma, xmb, xmc, yma, ymb, ymc,ma,mma,mb,mmb,mc,mmc,xa1,ya1,b,yb1,yc1;
                Segmento mediatriz = new Segmento(ax1, ay1, ax2, ay2, Color0, grafico, ViewPort, 0);
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
                ya1 = mma *cx1 + b;
                mediatriz.x0 = xma;
                mediatriz.y0 = yma;
                mediatriz.xf= cx1;
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
                mmc=(-1)/mc;
                b = ymc - mmc * xmc;
                yc1 = mmc * bx2 + b;
                mediatriz.x0 = xmc;
                mediatriz.y0 = ymc;
                mediatriz.xf = bx2;
                mediatriz.yf = yc1;
                mediatriz.c = Color.Red;
                mediatriz.Encender();
                
            }
            if (cbrepaso.SelectedIndex==2)
            {
                double x = -2, y = 1, r = 2,px=x+r,py=y+1,m,mo,b,yt;
                Circunferencia cir = new Circunferencia(x, y, r, Color0, grafico, ViewPort, 0);
                cir.Encender();
                m = (py - y) / (px - x);
                mo = -1 / m;
                b = py - mo * px;
                yt = mo * (x + r) + b;
                Segmento tangente = new Segmento(x+r,yt+r,x+r,y-r,Color.Red,grafico,ViewPort,0);
                tangente.Encender();


            }
            if (cbrepaso.SelectedIndex==3)
            {
                Circunferencia cr = new Circunferencia(1, 2, 4, Color0, grafico, ViewPort, 4);
                cr.Encender();
                Segmento cn = new Segmento(5, 2, 1,-4, Color0, grafico, ViewPort, 0);
                cn.Encender();
                cn.x0 = -3;
                cn.y0 = 2;
                cn.xf = 1;
                cn.yf = -4;
                cn.Encender();
            }
            if (cbrepaso.SelectedIndex==4)
            {
                Circunferencia cd = new Circunferencia(0, 0, 3, Color0, grafico, ViewPort, 5);
                cd.Encender();
            }
            //////letra teta
            if (cbrepaso.SelectedIndex==5)
            {
                Circunferencia teta = new Circunferencia(-1, -2, 4, Color0, grafico, ViewPort, 6);
                teta.Encender();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
             for (int i = 1; i < 400; i++)
            {
                for (int j = 1; j < 600; j++)
                {
                    grafico.SetPixel(i, j, Color.FromArgb((int)((10 * (i - 600) / (0 - 600))) + (230 * (i - 0)), (int)(255 * (j - 400) / (-200)), 0));
                }
            }
            ViewPort.Image = grafico;
        }

       
    }
}
