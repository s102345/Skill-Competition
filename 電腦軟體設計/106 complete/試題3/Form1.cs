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
        bool[] led = new bool[] { false, false, false, false, false, false, false };
        private void A_Click(object sender, EventArgs e)
        {
            if (!led[0])
                led[0] = true;
        
            else
                led[0] = false;
            Light();
        }
        private void B_Click(object sender, EventArgs e)
        {
            if (!led[1])
                led[1] = true;
            else 
                led[1] = false;
            Light();
        } 
        private void C_Click(object sender, EventArgs e)
        {
            if (!led[2])
                led[2] = true;
            else
                led[2] = false;
            Light();
        }
        private void D_Click(object sender, EventArgs e)
        {
            if (!led[3])
                led[3] = true;
            else 
                led[3] = false;
            Light();
        }
        private void E_Click(object sender, EventArgs e)
        {
            if (!led[4])
            {
                led[4] = true;
            }
            else
                led[4] = false;
            Light();
        }
        private void F_Click(object sender, EventArgs e)
        {
            if (!led[5])
                led[5] = true;
            else
                led[5] = false;
            Light();
        }
        private void G_Click(object sender, EventArgs e)
        {
            if (!led[6])
                led[6] = true;
            else       
                led[6] = false;
            Light();
        }
        private void Light()
        {
            if (led[0]) A.BackColor = Color.Red;
            else A.BackColor = Color.Transparent;
            if (led[1]) B.BackColor = Color.Red;
            else B.BackColor = Color.Transparent;
            if (led[2]) C.BackColor = Color.Red;
            else C.BackColor = Color.Transparent;
            if (led[3]) D.BackColor = Color.Red;
            else D.BackColor = Color.Transparent;
            if (led[4]) E.BackColor = Color.Red;
            else E.BackColor = Color.Transparent;
            if (led[5]) F.BackColor = Color.Red;
            else F.BackColor = Color.Transparent;
            if (led[6]) G.BackColor = Color.Red;
            else G.BackColor = Color.Transparent;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                if (rnd.Next(-1, 1) == 0)
                {
                    led[i] = false;
                }
                else
                {
                    led[i] = true;
                }
            }
            Light();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool[] zero = new bool[] { true, true , true, true , true, true ,false};
            bool[] one_1 = new bool[] { false, true, true, false, false, false, false };
            bool[] one_2 = new bool[] { false, false, false, false, true, true, false };
            bool[] two = new bool[] { true, true, false, true, true, false ,true };
            bool[] three = new bool[] { true, true, true, true, false, false, true };
            bool[] four = new bool[] { false, true, true, false, false, true, true };
            bool[] five = new bool[] { true, false, true, true, false, true, true };
            bool[] six_1 = new bool[] { true, false, true, true, true, true, true };
            bool[] six_2 = new bool[] { false, false, true, true, true, true, true };
            bool[] seven = new bool[] { true, true, true, false, false, false, false };
            bool[] eight = new bool[] { true, true, true, true, true, true, true };
            bool[] nine_1 = new bool[] { true, true, true, true, false, true,true};
            bool[] nine_2 = new bool[] { true, true, true, false, false, true, true };
            if (recognize(zero)) textBox1.Text = "0";
            else if (recognize(one_1)) textBox1.Text = "1";
            else if (recognize(one_2)) textBox1.Text = "1";
            else if (recognize(two)) textBox1.Text = "2";
            else if (recognize(three)) textBox1.Text = "3";
            else if (recognize(four)) textBox1.Text = "4";
            else if (recognize(five)) textBox1.Text = "5";
            else if (recognize(six_1)) textBox1.Text = "6";
            else if (recognize(six_2)) textBox1.Text = "6";
            else if (recognize(seven)) textBox1.Text = "7";
            else if (recognize(eight)) textBox1.Text = "8";
            else if (recognize(nine_1)) textBox1.Text = "9";
            else if (recognize(nine_2)) textBox1.Text = "9";
            else textBox1.Text = "非數字";
        }
        private bool recognize(bool[] num)
        {
            bool flag=true;
            for (int i = 0; i < 7; i++)
            {
                if (led[i] != num[i]) flag = false;
            }
            return flag;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
