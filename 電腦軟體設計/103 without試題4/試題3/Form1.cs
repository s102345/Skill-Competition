using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox)
                {
                    ((TextBox)(c)).Clear();
                }
            }//清除所有textbox內容
            rndBinary();
        }
        private void rndBinary()
        {
            Random rnd = new Random();
            for(int i = 0; i < 8; i++)
            {
                textBox1.Text += rnd.Next(0,2)+"";
                textBox2.Text += rnd.Next(0,2)+"";
            }
        }
        private int BinConvertToInt(string str)
        {
            int r=0;
            int[] bin = new int[8];
            bool flag = false;
            for(int i = 0; i < 8; i++)
            {
                bin[i] = str[i] - '0';
            }
            if (bin[0] == 1)
            {
                flag = true;          
                for (int i = 0; i < 8; i++)
                {
                    if (bin[i] == 1) bin[i] = 0;
                    else if (bin[i] == 0) bin[i] = 1;
                }
                bin[7] += 1;
                for (int i = 7; i >= 0; i--)
                {
                    if (bin[i] > 1 && i != 0)
                    {
                        bin[i - 1] += 1;
                        bin[i] -= 2;
                    }
                    System.Diagnostics.Debug.Print(bin[i]+"");
                }
            }
            //將2的數值轉換成有效數值
            for(int i = 1; i < 8; i++)
            {
                r += Convert.ToInt32(bin[i] * Math.Pow(2, 7 - i));
            }//Binary to Decimal
            if (flag) r *= -1;
            return r;
        }
        private void BinPlus(string a,string b)
        {
            textBox3.Clear();
            int[] A = new int[8];
            int[] B = new int[8];
            int[] r = new int[8];
            for (int i = 0; i < 8; i++)
            {
                A[i] = a[i]-'0';
                B[i] = b[i]-'0';
                r[i] = 0;
            }
            for(int i = 7; i >= 0; i--)
            {
                r[i] += A[i] + B[i];
                if (r[i] > 1)
                {
                    if(i!=0) r[i - 1] += 1;
                    r[i] -= 2;
                }
            }
            for(int i = 0; i < 8; i++)
            {
                textBox3.Text += r[i]+"";
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox7.Visible = false;
            textBox8.Visible = false;
            BinPlus(textBox1.Text,textBox2.Text);
            int A, B, sum;
            A = BinConvertToInt(textBox1.Text);
            B = BinConvertToInt(textBox2.Text);
            sum= BinConvertToInt(textBox3.Text);
            if (A > 0 & B > 0 && sum < 0)
            {
                textBox7.Visible = true;
                textBox7.Text = "overflow";
            }
            if (A < 0 & B < 0 && sum > 0)
            {
                textBox7.Visible = true;
                textBox7.Text = "underflow";
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            int A, B, sum;
            A = BinConvertToInt(textBox1.Text);
            B = BinConvertToInt(textBox2.Text);
            sum = BinConvertToInt(textBox3.Text);
            textBox4.Text = A + "";
            textBox5.Text = B + "";
            textBox6.Text = sum + "";
            if (A > 0 & B > 0 && sum < 0)
            {
                textBox8.Visible = true;
                textBox8.Text = "溢位";
            }
            if (A < 0 & B < 0 && sum > 0)
            {
                textBox8.Visible = true;
                textBox8.Text = "不足位";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
