using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TextBox[,] initial = new TextBox[3, 3];
        TextBox[,] goal = new TextBox[3, 3];
        /*
         [0,0] [0,1] [0,2]
         [1,0] [1,1] [1,2]
         [2,0] [2,1] [2,2]
             */
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    initial[i, j] = new TextBox();
                    this.Controls.Add(initial[i, j]);
                    initial[i, j].SetBounds(i * 45 + 80, j * 45 + 150, 40, 40);
                    initial[i, j].Multiline = true;
                    initial[i, j].TextAlign = HorizontalAlignment.Center;
                    initial[i, j].Font = new Font("微軟正黑體",12,FontStyle.Bold);

                    goal[i, j] = new TextBox();
                    this.Controls.Add(goal[i, j]);
                    goal[i, j].SetBounds(i * 45 + 400, j * 45 + 150, 40, 40);
                    goal[i, j].Multiline = true;
                    goal[i, j].TextAlign = HorizontalAlignment.Center;
                    goal[i, j].Font = new Font("微軟正黑體", 12, FontStyle.Bold);
                }
            }
        }//Initialize

        private void Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int[] rndTable = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int rndNum;
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rndNum = rnd.Next(0, 9);
                    while (rndTable[rndNum] == -1) rndNum = rnd.Next(0, 9);
                    if (rndTable[rndNum] == 0)  initial[i, j].Text = "";
                    else  initial[i, j].Text = rndTable[rndNum] + "";
                    rndTable[rndNum] = -1;
                }
            }
        }//Random Number Set

        private void Button2_Click(object sender, EventArgs e)
        {
            BFS();
            if (ans)
            {
                ticks = 0;
                backTracking();
                timer1.Enabled = true;
                timer1.Interval = 300;
            }
        }//HighSpeedRunning

        private void Button3_Click(object sender, EventArgs e)
        {     
            BFS();
            if (ans)
            {
                ticks = 0;
                backTracking();
                timer1.Enabled = true;
                timer1.Interval = 700;
            }
        }//LowSpeedRunning

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Exit
        int ticks = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(ans && ticks < path.Count)
            {
                label4.Text = "Steps:" + (ticks+1) + "/" + path.Count;
                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if ((path[ticks])[j, i] == 0) initial[i, j].Text = "";
                        else initial[i, j].Text = (path[ticks])[j, i]+"";
                    }
                }
                ticks++;
            }
        }
        bool ans = false;
        Queue<Node> openList = new Queue<Node>();
        SortedList<string,Node> closeList = new SortedList<string,Node>();
        List<int[,]> path = new List<int[,]>();
        private void BFS()
        {
            
            ans = false;
            openList.Clear();
            closeList.Clear();
            int[,] initMap = getMap(initial);
            int[,] goalMap = getMap(goal);
            openList.Enqueue(new Node(initMap, null));
            Node start = openList.Peek();
            closeList.Add(getHash(start.P), start);
            label5.Text = "Processing...";
            label4.Text = "Steps:";
            while (openList.Count > 0)
            {             
                Node now = openList.Dequeue();
                for (int i = 0; i < 3; i++) System.Diagnostics.Debug.Print(now.P[i, 0] + " " + now.P[i, 1] + " " + now.P[i, 2]);              
                System.Diagnostics.Debug.Print("\n");
                Point blank = getPoint(now.P, 0);
                if (getHash(goalMap) == getHash(now.P))
                {
                    ans = true;
                    break;
                }
                if (blank.Y - 1 >= 0) {
                    int[,] bufMap = (int[,])now.P.Clone();                   
                    swap(ref bufMap, blank, new Point(blank.X, blank.Y - 1));
                    if (!closeList.Keys.Contains(getHash(bufMap)))
                    {
                        openList.Enqueue(new Node(bufMap, now));
                        closeList.Add(getHash(bufMap),new Node(bufMap, now));
                    }
                }//上
                if (blank.Y + 1 < 3)
                {
                    int[,] bufMap = (int[,])now.P.Clone();
                    swap(ref bufMap, blank, new Point(blank.X, blank.Y + 1));
                    if (!closeList.Keys.Contains(getHash(bufMap)))
                    {
                        openList.Enqueue(new Node(bufMap, now));
                        closeList.Add(getHash(bufMap), new Node(bufMap, now));
                    }
                }//下
                if (blank.X - 1 >= 0)
                {
                    int[,] bufMap = (int[,])now.P.Clone();
                    swap(ref bufMap, blank, new Point(blank.X - 1, blank.Y));
                    if (!closeList.Keys.Contains(getHash(bufMap)))
                    {
                        openList.Enqueue(new Node(bufMap, now));
                        closeList.Add(getHash(bufMap), new Node(bufMap, now));
                    }
                }//左
                if (blank.X + 1 < 3)
                {
                    int[,] bufMap = (int[,])now.P.Clone();
                    swap(ref bufMap, blank, new Point(blank.X + 1, blank.Y));
                    if (!closeList.Keys.Contains(getHash(bufMap)))
                    {
                        openList.Enqueue(new Node(bufMap, now));
                        closeList.Add(getHash(bufMap), new Node(bufMap, now));
                    }
                }//右
               // System.Diagnostics.Debug.Print(openList.Count+"");
            }
            if (!ans) label5.Text = "無解";
            else label5.Text = "Done!";
        }
        class Node
        {
            public int[,] P;
            public Node Parent;
            public Node(int[,] _P,Node _Parent)
            {
                P = _P;
                Parent = _Parent;
            }
        };
        private void swap(ref int[,] map,Point a,Point b)
        {
            int buf;
            buf = map[a.Y, a.X];
            map[a.Y, a.X] = map[b.Y, b.X];
            map[b.Y, b.X] = buf;
        }
        private Point getPoint(int[,] map, int target)
        {
            Point p = new Point();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (map[i, j] == target)
                    {
                        p.X = j;
                        p.Y = i;
                    }
                }
            }
            return p;
        }
        private string getHash(int[,] map)
        {
            string str = "";
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    str += map[i, j] + "";
                }
            }
            return str;
        }//Check if goal is achieved
        private int[,] getMap(TextBox[,] tbx)
        {
            int[,] map = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++) {
                    if (tbx[i, j].Text != "") map[j, i] = Convert.ToInt32(tbx[i, j].Text);
                    else map[j, i] = 0;
                }
            }
            return map;
        }
        private void backTracking()
        {
            List<int[,]> pathReverse = new List<int[,]>();
            int[,] goalMap = getMap(goal);
            path.Clear();
            Node now = closeList[getHash(goalMap)];
            while (now.Parent!=null)
            {
                pathReverse.Add(now.P);
                now = now.Parent;
            }
            for(int i = pathReverse.Count - 1; i >= 0; i--)
            {
                path.Add(pathReverse[i]);
            }
        }
     
    }
}
