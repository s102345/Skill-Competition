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
        struct Score
        {
            public double e;
            public double m;
        };
        public Form1()
        {
            InitializeComponent();
        }
        int[] Eng = new int[30] {28,67,66,12,41,28,72,28,90,83,39,50,69,83,61,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
        int[] math = new int[30] { 57, 33, 46, 71, 88, 72, 2, 67, 44, 44, 12, 81, 32, 25, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] group = new int[30];
        double[] MSE = new double[20];
        int n, q;
        private void Button1_Click(object sender, EventArgs e)
        {
            n = 0;
            label3.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            Random rnd = new Random();
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                n += textBox1.Text[i]-'0';
                n *= 10;
            }
            n /= 10;
            for(int i = 0; i < n; i++)
            {
                label3.Text += i + 1 + " ";
               // Eng[i] = rnd.Next(0, 100);
                textBox3.Text += Eng[i] + "  ";
             //   math[i] = rnd.Next(0, 100);
                textBox4.Text += math[i] + "  ";
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            Score u1, u2,sum1, sum2;
            int g1, g2;
            double d1, d2;
            int r1, r2;
            Random rnd = new Random();
            r1 = rnd.Next(0, n);
            r2 = rnd.Next(0, n);
            u1.m = math[r1]; u1.e = Eng[r1];
            u2.m = math[r2]; u2.e = Eng[r2];

            q = 0;
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                q += textBox2.Text[i] - '0';
                q *= 10;
            }
            q /= 10;

            for (int p = 0; p < q; p++)
            {
                sum1.m = 0; sum1.e = 0; sum2.m = 0; sum2.e = 0 ;g1 = 0; g2 = 0;
                for(int i = 0; i < n; i++)
                {
                    d1 = Math.Pow(Math.Pow((math[i] - u1.m), 2) + Math.Pow((Eng[i] - u1.e), 2),0.5);
                    d2 = Math.Pow(Math.Pow((math[i] - u2.m), 2) + Math.Pow((Eng[i] - u2.e), 2),0.5);
                    if (d1 > d2)
                    {
                        group[i] = 2;
                        g2++;
                        sum2.m += math[i];
                        sum2.e += Eng[i];
                    }
                    else
                    {
                        group[i] = 1;
                        g1++;
                        sum1.m += math[i];
                        sum1.e += Eng[i];
                    }
                }
                /*System.Diagnostics.Debug.Print("u1.e:" + u1.e);
                System.Diagnostics.Debug.Print("u1.m:" + u1.m);
                System.Diagnostics.Debug.Print("u2.e:" + u2.e);
                System.Diagnostics.Debug.Print("u2.m:" + u2.m);
    */            
                u1.e = sum1.e / g1; u1.m = sum1.m / g1;u2.e = sum2.e / g2; u2.m = sum2.m / g2;
                
                double o1=0,o2=0;
                for(int i = 0; i < n; i++)
                {
                    if (group[i] == 1)
                    {
                        o1 +=Math.Pow((math[i] - u1.m)* (math[i] - u1.m) + (Eng[i] - u1.e)*(Eng[i] - u1.e),0.5);

                    }
                    else
                    {
                        o2 += Math.Pow((math[i] - u2.m) * (math[i] - u2.m) + (Eng[i] - u2.e) * (Eng[i] - u2.e), 0.5);
                    }
                 }
                System.Diagnostics.Debug.Print("o1.e:" + o1);
                System.Diagnostics.Debug.Print("o2.m:" + o2);
                MSE[p] = (o1 + o2) / n;
            }
            //label7.Text += MSE[0];
            for (int i = 0; i < n; i++)
            {
                textBox5.Text += group[i] + " ";
            }
        }

        private void Form1_Load(object sender, EventArgs e){
            chart1.ChartAreas[0].AxisX.Maximum = 10;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval=2;
            chart1.ChartAreas[0].AxisY.Interval = 2;
            chart1.ChartAreas[0].AxisX.Title = "疊代次數";
            chart1.ChartAreas[0].AxisY.Title = "MSE";
            chart1.ChartAreas[0].AxisY.Maximum = 28;
            chart1.ChartAreas[0].AxisY.Minimum = 14;
        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < q; i++)
            {
                chart1.Series[0].Points.AddXY(i,MSE[i]);
            }
        }
    }
}
