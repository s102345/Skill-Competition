using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);
            g.DrawLine(p, 400, 30, 400,330);
            g.DrawLine(p, 40, 180, 760, 180);
            for (int i = 0; i < 10; i++)
            {
                g.DrawEllipse(p, 40 + 90 * i - 3, 180 - 3, 5, 5);
                g.FillEllipse(b, 40 + 90 * i - 3, 180 - 3, 5, 5);
            }
            for (int i = 0; i < 8; i++)
            {
                g.DrawEllipse(p, 400 - 3, 30 + i * 50 - 3, 5, 5);
                g.FillEllipse(b, 400 - 3, 30 + i * 50 - 3, 5, 5);
            }
        }
        int A, B, C, D, E,F;
        int x1, x2,x3,x4, y1, y2,y3,y4;
        private void Button1_Click(object sender, EventArgs e)
        {
            bool L1 = false, L2 = false;
            Line1();
            Line2();
            double N, O;
            
            N = -(C * E - B * F) / Convert.ToDouble(A * E - B * D);
            O = -(C * D - A * F) / Convert.ToDouble(B * D - A * E);
            N = Math.Round(N, 2);
            O = Math.Round(O, 2);
            if ((x2 >= N && x1 <= N)|| (x2 <= N && x1 >= N))
            {
                if ((y2 >= O && y1 <= O) || (y2 <= O && y1 >= O))
                {
                    L1 = true;
                }
            }
            if ((x4 >= N && x3 <= N) || (x4 <= N && x3 >= N))
            {
                if ((y4 >= O && y3 <= O) || (y4 <= O && y3 >= O))
                {
                    L2 = true;
                }
            }
            System.Diagnostics.Debug.Print(N+" "+O);
            if (L1 && L2)
            {
                textBox5.Text = "有相交";
                textBox6.Text = N + "," + O;
            }
            else
            {
                textBox5.Text = "未相交";
            }
        }
        private void Line1()
        {
            string[] str = textBox1.Text.Split(',');
            x1 = Convert.ToInt32(str[0]);
            y1 = Convert.ToInt32(str[1]);
            str = textBox2.Text.Split(',');
            x2 = Convert.ToInt32(str[0]);
            y2 = Convert.ToInt32(str[1]);
            DrawLine(x1, y1, x2, y2);
            A = -(y2 - y1);
            B = (x2 - x1);
            C = (y2 - y1) * x1 - (x2 - x1) * y1;
            //System.Diagnostics.Debug.Print(C+"");
        }
        private void Line2()
        {
            string[] str = textBox3.Text.Split(',');
            x3 = Convert.ToInt32(str[0]);
            y3 = Convert.ToInt32(str[1]);
            str = textBox4.Text.Split(',');
            x4 = Convert.ToInt32(str[0]);
            y4 = Convert.ToInt32(str[1]);
            DrawLine(x3, y3, x4, y4);
            D = -(y4 - y3);
            E = (x4 - x3);
            F = (y4 - y3) * x3 - (x4 - x3) * y3;
        }
        private void DrawLine(int x1, int y1, int x2, int y2)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            x1 = (40 + 90 * (x1 + 40) / 10);
            y1 = (30 + 50 * (-y1 + 30) / 10);
            x2 = (40 + 90 * (x2 + 40) / 10);
            y2 = (30 + 50 * (-y2 + 30) / 10);
            g.DrawLine(p, x1, y1, x2, y2);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            foreach(Control c in Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)(c)).Clear();
                }
            }
        }
    }
}
