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
        TextBox[,] tbin = new TextBox[6, 6];
        TextBox[,] tbw = new TextBox[3, 3];
        private void Button1_Click(object sender, EventArgs e)
        {

            int[,] Input = getInput();
            Func1(Input);
            textBox3.Text = Encode(Input)+"";
        }
        private int[,] getInput()
        {
            int x, y;
            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);
            int[,] Input = new int[3, 3];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Input[i, j] = Convert.ToInt32(tbin[i + x, j + y].Text);
                }
            }
            return Input;
        }
        private void Func1(int[,] Input)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1) continue;
                    Input[i, j] = Func2(Input[i , j]-Input[1, 1]); 
                }
            }
        }
        private int Func2(int a)
        {
            if (a >= 0) return 1;
            return 0;
        }
        private int Encode(int[,] Input)
        {
            int result = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1) continue;
                    result += Input[i, j] * Convert.ToInt32(tbw[i, j].Text);
                }
            }
            return result;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    tbin[i,j] = new TextBox();
                    tbin[i, j].SetBounds(i * 35+50, j * 35+100, 30, 30);
                    this.Controls.Add(tbin[i, j]);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tbw[i, j] = new TextBox();
                    tbw[i, j].SetBounds(i * 35+350, j * 35+100, 30, 30);
                    this.Controls.Add(tbw[i, j]);
                }
            }
        }
    }
}
