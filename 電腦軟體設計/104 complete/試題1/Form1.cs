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
        TextBox[,] tb = new TextBox[4,4];
        object sel = new object();
        int[] num = new int[4];
        int[,] table = new int[4, 4];
        private void Button3_Click(object sender, EventArgs e)
        {
            ((TextBox)(sel)).Clear();
            if (sender.Equals(button3)) ((TextBox)(sel)).Text = 1 + "";
            if (sender.Equals(button4)) ((TextBox)(sel)).Text = 2 + "";
            if (sender.Equals(button5)) ((TextBox)(sel)).Text = 3 + "";
            if (sender.Equals(button6)) ((TextBox)(sel)).Text = 4 + "";
        }
        private void Initialize()
        {
            for (int i = 0; i < 4; i++)
            {
                num[i] = i + 1;
            }
        }
        private void getTable()
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(tb[i,j].Text=="")
                        table[i, j] = 0;
                    else
                        table[i, j] = Convert.ToInt32(tb[i, j].Text);
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            getTable();
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (tb[i, j].Text != "") continue;
                    Initialize();
                    rowCheck(i);
                    colCheck(j);
                    groupCheck(i,j);
                    addNum(tb[i, j]);
                }
            }
        }
        private void addNum(TextBox tb)
        {
            tb.Clear();
            for(int i = 0; i < 4; i++)
            {
                if (num[i] == 0) continue;
                else
                {
                    if (tb.Text != "") tb.Text += ",";
                    tb.Text += num[i];
                }
            }
        }
        private void rowCheck(int y)
        {
            for(int i = 0; i < 4; i++)
            {
                if (table[i, y] == 0) continue;
                num[table[i, y] - 1] = 0;
            }
        }
        private void colCheck(int x)
        {
            for (int i = 0; i < 4; i++)
            {
                if (table[x,i] == 0) continue;
                num[table[x,i] - 1] = 0;
            }
        }
        private void groupCheck(int x,int y)
        {
            if(x<2 && y < 2)
            {
                blockCheck(0, 0);
            }//group 1
            if (x >=2 && y < 2)
            {
                blockCheck(2, 0);
            }//group 2
            if (x < 2 && y >= 2)
            {
                blockCheck(0, 2);
            }//group 3
            if (x >= 2 && y >= 2)
            {
                blockCheck(2, 2);
            }//group 4
        }
        private void blockCheck(int x,int y)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (table[x + i, y + j] == 0) continue;
                    num[table[x + i, y + j] - 1] = 0;
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            getTable();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (tb[i, j].Text == "")
                    {
                        label1.Text = "錯誤";
                        return;
                    }
                    Initialize();
                    rowCheck(i);
                    for (int k = 0; k < 4; k++)
                    {
                        if (num[k] != 0)
                        {
                            label1.Text = "錯誤";
                            return;
                        }
                    }
                    Initialize();
                    colCheck(j);
                    for (int k = 0; k < 4; k++)
                    {
                        if (num[k] != 0)
                        {
                            label1.Text = "錯誤";
                            return;
                        }
                    }
                    Initialize();
                    groupCheck(i, j);
                    for (int k = 0; k < 4; k++)
                    {
                        if (num[k] != 0)
                        {
                            label1.Text = "錯誤";
                            return;
                        }
                    }

                }
            }
            label1.Text = "正確";
        }
        private void tb_Click(object sender,EventArgs e)
        {
            sel = sender ;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    tb[i, j] = new TextBox();
                    tb[i, j].SetBounds(45 * i+80, 45 * j+50, 40, 40);
                    tb[i, j].Text = "";
                    tb[i, j].ReadOnly = true;
                    tb[i,j].Click +=new EventHandler(tb_Click);
                    this.Controls.Add(tb[i, j]);
                }
            }
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (i == j) tb[i, j].Text = i + 1 + "";
                }
            }

        }
    }
}

