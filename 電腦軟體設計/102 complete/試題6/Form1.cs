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
        int steps = 0;//第一個動作 輸入 第二個動作 處理後輸出
        int matrixCounts;
        List<TextBox> matrixCol = new List<TextBox>();
        List<TextBox> matrixRow = new List<TextBox>();
        List<Label> lb = new List<Label>();
        private void Button1_Click(object sender, EventArgs e)
        {         
            if (steps == 0)
            {
                System.Diagnostics.Debug.Print("第一步");
                matrixCounts = Convert.ToInt32(textBox1.Text);
                label2.Text = "請輸入m1~m" + matrixCounts+"的矩陣大小<維度>：";
                for (int i = 0; i < matrixCounts; i++)
                {
                    lb.Add(new Label());
                    lb[i].Text = "m" + (i+1) + "的矩陣大小：";
                    lb[i].SetBounds(50, i * 30 + 100, 100, 20);
                    this.Controls.Add(lb[i]);
                    matrixCol.Add(new TextBox());
                    matrixCol[i].SetBounds(200,i * 30 + 100, 60, 40);
                    this.Controls.Add(matrixCol[i]);
                    matrixRow.Add(new TextBox());
                    matrixRow[i].SetBounds(300, i * 30 + 100, 60, 40);
                    this.Controls.Add(matrixRow[i]);
                }
            }
            if(steps == 1)
            {
                System.Diagnostics.Debug.Print("第二步");
                List<int> col = new List<int>();
                List<int> row = new List<int>();
                for(int i = 0; i < matrixCounts; i++)
                {
                    col.Add(Convert.ToInt32(matrixCol[i].Text));
                    row.Add(Convert.ToInt32(matrixRow[i].Text));
                }
                int[,] m = new int[matrixCounts, matrixCounts];
                int[,] s = new int[matrixCounts, matrixCounts];
                for(int i = 0;i < matrixCounts; i++)
                {
                    for(int j = 0; j < matrixCounts; j++)
                    {
                        m[i, j] = 99999;
                        s[i, j] = 0;
                    }
                }
                for (int i = 0; i < matrixCounts; i++)
                {
                    for (int j = i; j >= 0; j--)                      
                    {
                        if (i == j)
                        {
                            m[i, j] = 0;
                            continue;
                        }
                        for (int k = i-1; k >= 0; k--)
                        {
                            if (m[j, i] > m[j, k] + m[k + 1, i] + col[j] * row[k] * row[i])
                            {
                                m[j, i] = m[j, k] + m[k + 1, i] + col[j] * row[k] * row[i];
                                s[j, i] = k;
                            }
                            //System.Diagnostics.Debug.Print(s[j,i]+"");
                            //m[j, i] = min(m[j, i], m[j,k] + m[k+1,i] + col[j] * row[k] * row[i]);
                        }
                    }
                }
                label3.Text = "矩陣相乘的次序為：<";
                List<string> result = new List<string>();
                for (int i = 0; i < matrixCounts ; i++)
                {
                    result.Add("m" + (i + 1));
                }
                for (int i = matrixCounts-1; i > 1; i--)
                {
                    System.Diagnostics.Debug.Print(s[0,i] + "");
                    if (s[0, i] + 1 > matrixCounts / 2)
                    {
                        result[0]= result[0].Insert(0,"<");
                        result[s[0, i]] += ">";
                    }
                    else
                    {
                        result[s[0, i]] += "<";
                        result[s[0, i] + 2] += ">";
                    }
                }
                foreach(string str in result)
                {
                    label3.Text += str;
                }
                label3.Text +=">";
                foreach(string str in result) System.Diagnostics.Debug.Print(str);
                label4.Text = "最少的乘法運算次數：" + m[0, matrixCounts - 1];
                /*
                 [0,0] [0,1] [0,2] [0,3]
                       [1,1] [1,2] [1,3]
                             [2,2] [2,3]
                                   [3,3]
                 */
            }
            steps++;
        }
        
    }
}
