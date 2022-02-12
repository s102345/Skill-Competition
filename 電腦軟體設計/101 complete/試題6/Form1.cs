using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 試題6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] map = new int[8,8];
        bool[,] visited = new bool[8, 8];
        private void Button1_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(textBox1.Text);
            StreamReader sr = fi.OpenText();
            for(int i = 0; i < 8; i++) {
                string[] str = sr.ReadLine().Split(' ');
                for (int j = 0; j < 8; j++)
                {
                    map[i,j] = Convert.ToInt32(str[j]);
                    visited[i, j]= false;
                }
            }
            Point p = new Point();
            p.X = 0;
            p.Y = 0;
            SolveMaze(p);
            richTextBox1.Text += "(" +7 + "," + 7 + ")";
        }
        bool flag = false;
        private void SolveMaze(Point p)
        {
            if (p.X == 7 && p.Y == 7) flag=true;
            if (flag) return;
            richTextBox1.Text += "(" + p.Y + "," + p.X + ")";
            visited[p.Y, p.X] = true;
            Point p1=new Point();
            if (p.Y-1 >=0){
                if(map[p.Y-1, p.X] == 0 && !visited[p.Y - 1, p.X])
                {
                    p1.X = p.X;
                    p1.Y = p.Y-1;
                    System.Diagnostics.Debug.Print("北");
                    SolveMaze(p1);
                }    
            }//北 Y-1
            if (p.Y - 1 >= 0 && p.X+1<8)
            {
                if (map[p.Y-1, p.X+1] == 0 && !visited[p.Y - 1, p.X + 1])
                {
                    p1.X = p.X + 1;
                    p1.Y = p.Y - 1;
                    System.Diagnostics.Debug.Print("東北");
                    SolveMaze(p1);
                }
            }//東北 X+1 Y-1
            if (p.X + 1 < 8)
            {
                if (map[p.Y, p.X+1] == 0 && !visited[p.Y, p.X + 1]) 
                {
                    p1.X = p.X + 1;
                    p1.Y = p.Y;         
                    System.Diagnostics.Debug.Print("東");
                    SolveMaze(p1);
                }
            }//東 X+1
            if (p.X + 1 < 8 && p. Y + 1 < 8)
            {
                if (map[p. Y + 1, p. X + 1 ] == 0 && !visited[p.Y + 1, p.X + 1])
                {
                    p1.X = p.X + 1;
                    p1.Y = p.Y + 1;                
                    System.Diagnostics.Debug.Print("東南");
                    SolveMaze(p1);
                }
            }//東南 X+1 Y+1
            if (p.Y + 1 < 8)
            {
                if (map[p.Y+1, p.X] == 0 && !visited[p.Y + 1, p.X])
                {
                    p1.X = p.X;
                    p1.Y = p.Y+1;
                    System.Diagnostics.Debug.Print("南");
                    SolveMaze(p1);
                }
            }//南 Y+1
            if (p.X - 1 >= 0 && p.Y+1<8)
            {
                if (map[p.Y+1, p.X-1] == 0 && !visited[p.Y + 1, p.X - 1])
                {
                    p1.X = p.X - 1;
                    p1.Y = p.Y - 1;
                    System.Diagnostics.Debug.Print("西南");
                    SolveMaze(p1);
                }
            }//西南 X-1 Y+1
            if (p.X - 1 >= 0)
            {
                if (map[p.Y, p.X-1] == 0 && !visited[p.Y, p.X - 1])
                {
                    p1.X = p.X - 1;
                    p1.Y = p.Y;
                    System.Diagnostics.Debug.Print("西");
                    SolveMaze(p1);
                }
            }//西 X-1
            if (p.X - 1 >= 0 && p.Y-1>=0)
            {
                if (map[p.Y - 1, p.X-1] == 0 && !visited[p.Y - 1, p.X - 1])
                {
                    p1.X = p.X - 1;
                    p1.Y = p.Y - 1;                 
                    System.Diagnostics.Debug.Print("西北");
                    SolveMaze(p1);
                }
            }//西北 X-1 Y-1
            return;
        }
    }
}
