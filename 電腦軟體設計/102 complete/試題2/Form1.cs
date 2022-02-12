using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            textBox1.Text = rnd.Next(0,9999)+Math.Round(rnd.NextDouble(),4)+"";    
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double v = Convert.ToDouble(textBox1.Text) ;
            int a = Convert.ToInt32(Math.Floor(v));
            double b =Math.Round(v % 1,4);
            textBox2.Text = intConvert(a)+"."+doubleConvert(b);
            textBox3.Text = intConvert(a)+"." + RealBin(doubleConvert(b));
        }
        private string intConvert(int v)
        {
            string str="";
            while (v > 0)
            {
                str += Convert.ToString(v % 2);
                v /= 2;
            }
            return Reverse(str);
        }
        private string doubleConvert(double v)
        {
            string str = "";
            for(int i = 0; i < 10; i++)
            {
                v *= 2;
                if (v > 1)
                {
                    str += "1";
                    v -= 1;
                }
                else str += "0";
            }
            return str;
        }
        private string Reverse(string str)
        {
            string rstr="";
            for(int i = 0; i < str.Length; i++)
            {
                rstr += str[str.Length-i-1];
            }
            return rstr;
        }
        private string RealBin(string d)
        {
            string str="";
            int flag=0;
            for (int i = d.Length - 1; i >= 0; i--)
            {
                if (d[i] != '0')
                {
                    flag = i;
                    break;
                }
            }
            for(int i = 0; i <= flag; i++)
            {
                str += d[i];
            }
            return str;
        }
    }
}
