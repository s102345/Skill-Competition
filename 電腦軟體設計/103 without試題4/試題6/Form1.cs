using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            int X, P, N, M ,t;
            bool flag = false;
            X = Convert.ToInt32(textBox1.Text);
            P = Convert.ToInt32(textBox2.Text);
            N = Convert.ToInt32(textBox3.Text);
            M = FindMatch(X, N);
            t = P / 2;
            if (P % 2 > 0)
            {
                flag = true;
            }
            int last=1;
            if (flag) last *= X;
            last *= GetTarget(M, t, N);
            //System.Diagnostics.Debug.Print(GetTarget(M, t, N) + "");
            last %= N;
            label4.Text = "餘數="+last;
        }
        //形式：( X ^ 2 ) % N = M % N ( X ^ P ) % N= ( ( 如果P為奇數才會乘X ) ( X ) ) ( M ^ t ) % N
        private int FindMatch(int X,int N)
        {
            return (X * X) % N;
        }
        private int GetTarget(int M,int t,int N)
        {
            while (t != 1)
            {
                M = (M * M) % N;
                t /= 2;
               System.Diagnostics.Debug.Print(t + "");
            }
            return M;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
