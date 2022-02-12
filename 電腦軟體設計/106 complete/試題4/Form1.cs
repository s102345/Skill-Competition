using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace 試題4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 選擇檔案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                StreamReader sr = fi.OpenText();
                while (sr.Peek() > 0)
                {
                    richTextBox1.Text += sr.ReadLine() + '\n';
                }
            };
        }
        double[] w = new double[3];
        private void Button1_Click(object sender, EventArgs e)
        {
            double n;
            n = Convert.ToDouble(textBox3.Text);           
            string[] b = new string[3];
            double[] x = new double[3];
            double y, f;
            int o;
            textBox5.Text = "";
            b = textBox4.Text.Split(';');
            for (int i = 0; i < 3; i++)
            {
                w[i] = Convert.ToDouble(b[i]);
            }
            double E = 0;
            string buf;
            for (int i = 0; i < 3; i++)
            {
                buf = richTextBox1.Lines[i];
                b = buf.Split(' ');
                for (int j = 0; j < 3; j++)
                {
                    x[j] = Convert.ToDouble(b[j]);
                }
                y = Convert.ToDouble(b[3]);
                f = F(w, x);
                o = O(f);
                w = W(n, y, x, o, w);
                E = EE(E, y, o);
            }
            while (E != 0)
            {
                E = 0;
                for (int i = 0; i < 3; i++)
                {
                    buf = richTextBox1.Lines[i];
                    b = buf.Split(' ');
                    for (int j = 0; j < 3; j++)
                    {
                        x[j] = Convert.ToDouble(b[j]);
                    }
                    y = Convert.ToDouble(b[3]);
                    f = F(w, x);
                    o = O(f);
                    w = W(n, y, x, o, w);
                    E = EE(E, y, o);
                }
            }
            for(int i = 0; i < 3; i++)
            {
                if(i!=2)
         
                    textBox5.Text += w[i]+"0;";
                else
                    textBox5.Text += w[i]+"0";
            }
        }
        private double F(double[] w, double[] x)
        {
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += w[i] * x[i];
            }
            return sum;
        }
        private int O(double f)
        {
            if (f >= 0) return 1;
            return -1;
        }
        private double[] W(double n, double y, double[] x, int o,double[] w)
        {
            double[] nw = new double[3];
            for (int i = 0; i < 3; i++)
            {
                nw[i] = w[i] + n*(y - o) * x[i];
            }
            return nw;
        }
        private double EE(double e,double y,int o)
        {
            return e + 0.5 * (y - o) * (y - o);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string[] b = textBox9.Text.Split(';');
            double[] x = new double[3];
            for (int i = 0; i < 3; i++)
            {
                x[i] = Convert.ToDouble(b[i]);
            }
            double f = F(w, x);
            int o = O(f);
            if (o == 1)
                label7.Text = "機器人向:1(左)";
            else
                label7.Text = "機器人向:-1(右)";
        }
    }
}
