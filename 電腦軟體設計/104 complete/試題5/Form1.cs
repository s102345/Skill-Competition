using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextBox[,] tb1 = new TextBox[7, 7];
        TextBox[,] tb2 = new TextBox[3, 3];
        TextBox[,] tb3 = new TextBox[7, 7];
        int[,] NK = new int[3, 3];

        private void Button1_Click(object sender, EventArgs e)
        {
            printO();
            getMSE();
            getMAE();
            getPSNR();
        }
        private void getMSE()
        {
            double MSE=0;
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    MSE+=(Convert.ToInt32(tb1[i,j].Text)-Convert.ToInt32(tb3[i,j].Text))* (Convert.ToInt32(tb1[i, j].Text) - Convert.ToInt32(tb3[i, j].Text));
                }
            }
            textBox1.Text=MSE / 49+"";
        }
        private void getMAE()
        {
            double MAE = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    MAE += Math.Abs((Convert.ToInt32(tb1[i, j].Text) - Convert.ToInt32(tb3[i, j].Text)));
                }
            }
            textBox2.Text = MAE / 49 + "";
        }
        private void getPSNR()
        {
            textBox3.Text = 10 * Math.Log10(255*255 / Convert.ToDouble(textBox1.Text))+"";
        }
        private void printO()
        {
            int[,] buf = new int[3, 3];
            flipK();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    reset(buf);
                    for (int a = -1; a < 2; a++)
                    {
                        for (int b = -1; b < 2; b++)
                        {
                            if (i + a < 0 || j + b < 0 || i + a > 6 || j + b > 6)
                            {
                                continue;
                            }
                            buf[a + 1, b + 1] = Convert.ToInt32(tb1[i + a, j + b].Text);
                            tb3[i, j].Text = getO(buf) + "";
                        }
                    }
                }
            }
        }
        private void reset(int[,] buf)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    buf[i, j] = 0;
                }
            }
        }
        private int getO(int[,] I)
        {
            int sum = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    sum += I[i, j] * NK[i, j];
                }
            }
            return sum;
        }
        private void flipK()
        {
            int a, b;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0) a = 2;
                    else if (i == 2) a = 0;
                    else a = 1;
                    if (j == 0) b = 2;
                    else if (j == 2) b = 0;
                    else b = 1;
                    NK[a, b] = Convert.ToInt32(tb2[i, j].Text);
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
 
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    tb1[i, j] = new TextBox();
                    tb1[i, j].Name="I"+i*7+j;
                    tb1[i, j].SetBounds(50*(i+1),50*(j+2),30,30);
                    this.Controls.Add(tb1[i, j]);
                    tb1[i, j].Text = 0+"";
                    tb1[i, j].TextAlign = HorizontalAlignment.Center;
                }
            }
           
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tb2[i, j] = new TextBox();
                    tb2[i, j].Name = "K" + i * 3 + j;
                    tb2[i, j].SetBounds(50 * (i+10), 50 * (j+2), 30, 30);
                    this.Controls.Add(tb2[i, j]);
                    tb2[i, j].Text = 0 + "";
                    tb2[i, j].TextAlign = HorizontalAlignment.Center;
                }
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    tb3[i, j] = new TextBox();
                    tb3[i, j].Name = "I" + i * 7 + j;
                    tb3[i, j].SetBounds(50 * (i + 16), 50 * (j + 2), 30, 30);
                    this.Controls.Add(tb3[i, j]);
                    tb3[i, j].Text = 0 + "";
                    tb3[i, j].TextAlign = HorizontalAlignment.Center;
                }
            }
        }
    }
}
