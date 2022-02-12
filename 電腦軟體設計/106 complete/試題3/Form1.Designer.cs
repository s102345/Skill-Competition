namespace 試題3
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.F = new System.Windows.Forms.Button();
            this.B = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.Button();
            this.E = new System.Windows.Forms.Button();
            this.G = new System.Windows.Forms.Button();
            this.A = new System.Windows.Forms.Button();
            this.D = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // F
            // 
            this.F.Location = new System.Drawing.Point(158, 93);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(42, 107);
            this.F.TabIndex = 0;
            this.F.UseVisualStyleBackColor = true;
            this.F.Click += new System.EventHandler(this.F_Click);
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(361, 93);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(42, 107);
            this.B.TabIndex = 1;
            this.B.UseVisualStyleBackColor = true;
            this.B.Click += new System.EventHandler(this.B_Click);
            // 
            // C
            // 
            this.C.Location = new System.Drawing.Point(361, 241);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(42, 111);
            this.C.TabIndex = 2;
            this.C.UseVisualStyleBackColor = true;
            this.C.Click += new System.EventHandler(this.C_Click);
            // 
            // E
            // 
            this.E.Location = new System.Drawing.Point(158, 241);
            this.E.Name = "E";
            this.E.Size = new System.Drawing.Size(42, 111);
            this.E.TabIndex = 3;
            this.E.UseVisualStyleBackColor = true;
            this.E.Click += new System.EventHandler(this.E_Click);
            // 
            // G
            // 
            this.G.Location = new System.Drawing.Point(158, 206);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(245, 29);
            this.G.TabIndex = 4;
            this.G.UseVisualStyleBackColor = true;
            this.G.Click += new System.EventHandler(this.G_Click);
            // 
            // A
            // 
            this.A.BackColor = System.Drawing.Color.Transparent;
            this.A.Location = new System.Drawing.Point(158, 58);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(245, 29);
            this.A.TabIndex = 5;
            this.A.UseVisualStyleBackColor = false;
            this.A.Click += new System.EventHandler(this.A_Click);
            // 
            // D
            // 
            this.D.Location = new System.Drawing.Point(158, 358);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(245, 29);
            this.D.TabIndex = 6;
            this.D.UseVisualStyleBackColor = true;
            this.D.Click += new System.EventHandler(this.D_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "簡易辨認數字系統";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(114, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "數字為：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(218, 403);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(185, 22);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(539, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 94);
            this.button1.TabIndex = 10;
            this.button1.Text = "Random Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(539, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 94);
            this.button2.TabIndex = 11;
            this.button2.Text = "Recognizing";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(539, 361);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 64);
            this.button3.TabIndex = 12;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.D);
            this.Controls.Add(this.A);
            this.Controls.Add(this.G);
            this.Controls.Add(this.E);
            this.Controls.Add(this.C);
            this.Controls.Add(this.B);
            this.Controls.Add(this.F);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button F;
        private System.Windows.Forms.Button B;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button E;
        private System.Windows.Forms.Button G;
        private System.Windows.Forms.Button A;
        private System.Windows.Forms.Button D;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

