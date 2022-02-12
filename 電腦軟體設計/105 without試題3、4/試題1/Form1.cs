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
        int a;
        int b;
        string[] table = { "0 ", "1 ", "2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 ", "9 ", "A ","B ","C ", "D ", "E ","F ","G ", "H ", "I " , "J " };
        private void Button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox2.Text);
            textBox3.Clear();
            if (a != 0)
            {
                convert(a, b);
            }    
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            a = 0;
        }
        private void convert(int a,int b)
        {
            string result = "";
            if (b > 0)
            {
                while (a != 0) { 
                result += table[a % b] + " ";
                a /= b;
                }
            }
            if (b < 0)
            {
                while (a != 0)
                {
                    int c = 0;
                    while (!(a >= 0 && a < Math.Abs(b))){
                        if (a > 0)
                        {
                            a -= Math.Abs(b);
                            c--;
                        }
                        if (a < 0)
                        {
                            a -= b;
                            c++;
                        }
                    }
                    result += table[a] + " ";
                    a = c;
                }
            }
            for(int i = result.Length - 1; i >= 0; i--)
            {
                textBox3.Text += result[i];
            }
        }
    }
}
