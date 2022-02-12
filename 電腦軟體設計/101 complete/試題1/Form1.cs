using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int a, b;
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            a = Convert.ToInt32(textBox1.Text)/10;
            b = Convert.ToInt32(textBox1.Text) % 10;
            DrawLine1(a, b);
            a = Convert.ToInt32(textBox2.Text) / 10;
            b = Convert.ToInt32(textBox2.Text) % 10;
            DrawLine2(a, b);
        }
        private void DrawLine1(int a,int b)
        { 
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Red);
            Pen p0 = new Pen(Color.Red);
            p0.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            int x =600, y =60 ,m=250;
            if (a == 0) g.DrawLine(p0, x, y, x - m, y + m);
            else
            {
                for(int i = 0; i < a; i++)
                {
                    g.DrawLine(p, x, y, x - m, y + m);
                    x += 10;
                    y += 10;
                }
            }
            x += 80;
            y += 80;
            if (b == 0) g.DrawLine(p0, x, y, x - m, y + m);
            else
            {
                for (int i = 0; i < b; i++)
                {
                    g.DrawLine(p, x, y, x - m, y + m);
                    x += 10;
                    y += 10;
                }
            }
        }
        private void DrawLine2(int a, int b)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            Pen p0 = new Pen(Color.Blue);
            p0.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            int x = 300, y = 150, m =280;
            if (a == 0) g.DrawLine(p0, x, y, x + m, y + m);
            else
            {
                for (int i = 0; i < a; i++)
                {
                    g.DrawLine(p, x, y, x + m, y + m);
                    x += 10;
                    y -= 10;
                }
            }
            x += 80;
            y -= 80;
            if (b == 0) g.DrawLine(p0, x, y, x + m, y + m);
            else
            {
                for (int i = 0; i < b; i++)
                {
                    g.DrawLine(p, x, y, x + m, y + m);
                    x += 10;
                    y -= 10;
                }
            }
        }
    }
}
