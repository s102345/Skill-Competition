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
        Random rnd = new Random();
        private void Button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string rndcode="";
            textBox3.Clear();
            textBox5.Clear();
            for(int i = 0; i < 25; i++)
            {
                switch (rnd.Next(0, 5))
                {
                    case 0:
                        rndcode += "10";
                        flag += 2;
                        break;
                    case 1:
                        rndcode += "01";
                        flag += 2;
                        break;
                    case 2:
                        rndcode += "11";
                        flag += 2;
                        break;
                    case 3:
                        rndcode += "001";
                        flag += 3;
                        break;
                    case 4:
                        rndcode += "000";
                        flag += 3;
                        break;
                }
                if (flag > rnd.Next(26, 50))
                {
                    break;
                }
            }
            textBox1.Text = rndcode;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox6.Clear();
            int flag = 0;
            string rndcode = "";
            for (int i = 0; i < 25; i++)
            {
                rndcode += rnd.Next(0, 2);
                flag++;
                if (flag > rnd.Next(26, 50))
                {
                    break;
                }
            }
            textBox2.Text = rndcode;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string code1, code2;
            code1 = textBox1.Text;
            code2 = textBox2.Text;
            string decode1 = "", decode2 = "";
            int buf=0;
            bool flag1 =true,flag2 = true;
            for(int i = 0; i < code1.Length; i++)
            {
                if (code1[i] == '0')
                {
                    if (i + 1 == code1.Length)
                    {
                        flag1 = false;
                        break;
                    }
                    if (code1[i+1] == '1')
                    {
                        decode1 += "B";
                        buf = 1;
                    }
                    if (code1[i+1] == '0')
                    {
                        if (i + 2 == code1.Length)
                        {
                            flag1 = false;
                            break;
                        }
                        if (code1[i + 2] == '0')
                        {
                            decode1 += "E";
                            buf = 2;
                        }
                        if (code1[i + 2] == '1')
                        {
                            decode1 += "D";
                            buf = 2;
                        }
                    }
                }
                if (code1[i] == '1')
                {
                    if (i + 1 == code1.Length)
                    {
                        flag1 = false;
                        break;
                    }
                    if (code1[i+1] == '0')
                    {
                        decode1 += "A";
                        buf = 1;
                    }
                    if (code1[i+1] == '1')
                    {
                        decode1 += "C";
                        buf = 1;
                    }
                }
                i += buf;
            }
            if (!flag1)
            {
                textBox3.Text="不合格";
                textBox5.Text = "";
            }
            else
            {
                textBox3.Text = "";
                textBox5.Text = decode1;
            }
            for (int i = 0; i < code2.Length; i++)
            {
                if (code2[i] == '0')
                {
                    if (i + 1 == code2.Length)
                    {
                        flag2 = false;
                        break;
                    }
                    if (code1[i + 1] == '1')
                    {
                        decode2 += "B";
                        buf = 1;
                    }
                    if (code2[i + 1] == '0')
                    {
                        if (i + 2 == code2.Length)
                        {
                            flag2 = false;
                            break;
                        }
                        if (code2[i + 2] == '0')
                        {
                            decode2 += "E";
                            buf = 2;
                        }
                        if (code2[i + 2] == '1')
                        {
                            decode2 += "D";
                            buf = 2;
                        }
                    }
                }
                if (code2[i] == '1')
                {
                    if (i + 1 == code2.Length)
                    {
                        flag2 = false;
                        break;
                    }
                    if (code2[i + 1] == '0')
                    {
                        decode2 += "A";
                        buf = 1;
                    }
                    if (code2[i + 1] == '1')
                    {
                        decode2 += "C";
                        buf = 1;
                    }
                }
                i += buf;
            }
            if (!flag2)
            {
                textBox4.Text = "不合格";
                textBox6.Text = "";
            }
            else
            {
                textBox4.Text = "";
                textBox6.Text = decode2;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
