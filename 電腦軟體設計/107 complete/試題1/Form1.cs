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
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 3);
            g.DrawLine(p, 100, 50, 100, 400);
            g.DrawLine(p, 150, 50, 150, 400);
            g.DrawLine(p, 50, 325, 700, 325);
            g.DrawLine(p, 50, 275, 700, 275);
        }
        private int state = 1;
        private void ButtonON_Click(object sender, EventArgs e)
        {
            Graphics light = this.CreateGraphics();
            
            if (sender.Equals(buttonON))
            {
                state = 1;
                DrawTrafficlight(light, state);
                
            }
            else if (sender.Equals(buttonSwitch))
            {
                light.Clear(Color.White);
                state++;
                
                if (state > 6)
                {
                    state = 1;
                    
                }
                DrawTrafficlight(light, state);
            }
            else
            {
                state = 1;
                light.Clear(Color.White);
            }
        }
        private void DrawTrafficlight(Graphics light,int state)
        {
            Pen p = new Pen(Color.Black, 3);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            SolidBrush green = new SolidBrush(Color.Green);
            switch (state)
            {
                case 1:
                    light.DrawEllipse(p, 40, 50, 50, 50);
                    light.FillEllipse(red, 40, 50, 50, 50);
                    light.DrawEllipse(p, 650, 350, 50, 50);
                    light.FillEllipse(green, 650, 350, 50, 50);
                    break;
                case 2:
                    light.DrawEllipse(p, 40, 50, 50, 50);
                    light.FillEllipse(red, 40, 50, 50, 50);
                    light.DrawEllipse(p, 600, 350, 50, 50);
                    light.FillEllipse(yellow, 600, 350, 50, 50);
                    break;
                case 3:
                    light.DrawEllipse(p, 40, 50, 50, 50);
                    light.FillEllipse(red, 40, 50, 50, 50);
                    light.DrawEllipse(p, 550, 350, 50, 50);
                    light.FillEllipse(red, 550, 350, 50, 50);
                    break;
                case 4:
                    light.DrawEllipse(p, 40, 150, 50, 50);
                    light.FillEllipse(green, 40, 150, 50, 50);
                    light.DrawEllipse(p, 550, 350, 50, 50);
                    light.FillEllipse(red, 550, 350, 50, 50);
                    break;
                case 5:
                    light.DrawEllipse(p, 40, 100, 50, 50);
                    light.FillEllipse(yellow, 40, 100, 50, 50);
                    light.DrawEllipse(p, 550, 350, 50, 50);
                    light.FillEllipse(red, 550, 350, 50, 50);
                    break;
                case 6:
                    light.DrawEllipse(p, 550, 350, 50, 50);
                    light.FillEllipse(red, 550, 350, 50, 50);
                    light.DrawEllipse(p, 40, 50, 50, 50);
                    light.FillEllipse(red, 40, 50, 50, 50);
                    break;
            }
        }
    }
}
