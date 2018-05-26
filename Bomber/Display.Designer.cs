namespace Bomber
{
    partial class Display
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Display));
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerBoom_1 = new System.Windows.Forms.Timer(this.components);
            this.timerWalk = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timerBoom_2 = new System.Windows.Forms.Timer(this.components);
            this.timerBoom_3 = new System.Windows.Forms.Timer(this.components);
            this.labelNamePlayer2 = new System.Windows.Forms.Label();
            this.pictureAi1 = new System.Windows.Forms.PictureBox();
            this.picturePlayer1 = new System.Windows.Forms.PictureBox();
            this.labelMap = new System.Windows.Forms.Label();
            this.timerAI1 = new System.Windows.Forms.Timer(this.components);
            this.timerBoomAI1_1 = new System.Windows.Forms.Timer(this.components);
            this.timerBoomAI1_2 = new System.Windows.Forms.Timer(this.components);
            this.timerStartGame = new System.Windows.Forms.Timer(this.components);
            this.pictureWin = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAi1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWin)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPlayer1.Font = new System.Drawing.Font("Forte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.Location = new System.Drawing.Point(605, 40);
            this.labelPlayer1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(185, 80);
            this.labelPlayer1.TabIndex = 2;
            this.labelPlayer1.Click += new System.EventHandler(this.labelPlayer1_Click);
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPlayer2.Font = new System.Drawing.Font("Forte", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2.Location = new System.Drawing.Point(605, 150);
            this.labelPlayer2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(185, 87);
            this.labelPlayer2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(607, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "แกนY";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "แกนX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(647, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "x";
            // 
            // labelScore
            // 
            this.labelScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelScore.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(603, 237);
            this.labelScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(187, 140);
            this.labelScore.TabIndex = 19;
            this.labelScore.Text = "Time:";
            // 
            // timerClock
            // 
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerBoom_1
            // 
            this.timerBoom_1.Tick += new System.EventHandler(this.timerBoom_1_Tick);
            // 
            // timerWalk
            // 
            this.timerWalk.Tick += new System.EventHandler(this.timerWalk_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(600, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 600);
            this.label1.TabIndex = 21;
            // 
            // timerBoom_2
            // 
            this.timerBoom_2.Tick += new System.EventHandler(this.timerBoom_2_Tick);
            // 
            // timerBoom_3
            // 
            this.timerBoom_3.Tick += new System.EventHandler(this.timerBoom_3_Tick);
            // 
            // labelNamePlayer2
            // 
            this.labelNamePlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelNamePlayer2.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNamePlayer2.ForeColor = System.Drawing.Color.Red;
            this.labelNamePlayer2.Image = global::Bomber.Properties.Resources.Stone_Floor;
            this.labelNamePlayer2.Location = new System.Drawing.Point(605, 120);
            this.labelNamePlayer2.Name = "labelNamePlayer2";
            this.labelNamePlayer2.Size = new System.Drawing.Size(185, 30);
            this.labelNamePlayer2.TabIndex = 23;
            this.labelNamePlayer2.Text = "Dark Vader";
            this.labelNamePlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureAi1
            // 
            this.pictureAi1.BackColor = System.Drawing.Color.Transparent;
            this.pictureAi1.Image = ((System.Drawing.Image)(resources.GetObject("pictureAi1.Image")));
            this.pictureAi1.Location = new System.Drawing.Point(520, 520);
            this.pictureAi1.Name = "pictureAi1";
            this.pictureAi1.Size = new System.Drawing.Size(40, 40);
            this.pictureAi1.TabIndex = 26;
            this.pictureAi1.TabStop = false;
            // 
            // picturePlayer1
            // 
            this.picturePlayer1.BackColor = System.Drawing.Color.Transparent;
            this.picturePlayer1.Image = ((System.Drawing.Image)(resources.GetObject("picturePlayer1.Image")));
            this.picturePlayer1.Location = new System.Drawing.Point(40, 40);
            this.picturePlayer1.Name = "picturePlayer1";
            this.picturePlayer1.Size = new System.Drawing.Size(40, 40);
            this.picturePlayer1.TabIndex = 20;
            this.picturePlayer1.TabStop = false;
            // 
            // labelMap
            // 
            this.labelMap.BackColor = System.Drawing.Color.White;
            this.labelMap.Image = ((System.Drawing.Image)(resources.GetObject("labelMap.Image")));
            this.labelMap.Location = new System.Drawing.Point(0, 0);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(600, 600);
            this.labelMap.TabIndex = 0;
            // 
            // timerAI1
            // 
            this.timerAI1.Tick += new System.EventHandler(this.timerAI1_Tick);
            // 
            // timerBoomAI1_1
            // 
            this.timerBoomAI1_1.Tick += new System.EventHandler(this.timerBoomAI1_Tick);
            // 
            // timerBoomAI1_2
            // 
            this.timerBoomAI1_2.Tick += new System.EventHandler(this.timerBoomAI2_Tick);
            // 
            // timerStartGame
            // 
            this.timerStartGame.Tick += new System.EventHandler(this.timerStartGame_Tick);
            // 
            // pictureWin
            // 
            this.pictureWin.BackColor = System.Drawing.Color.Transparent;
            this.pictureWin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureWin.Image = global::Bomber.Properties.Resources.Victor;
            this.pictureWin.Location = new System.Drawing.Point(0, 120);
            this.pictureWin.Name = "pictureWin";
            this.pictureWin.Size = new System.Drawing.Size(600, 320);
            this.pictureWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureWin.TabIndex = 27;
            this.pictureWin.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Image = global::Bomber.Properties.Resources.Stone_Floor;
            this.label2.Location = new System.Drawing.Point(602, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 30);
            this.label2.TabIndex = 28;
            this.label2.Text = "Dark Vader";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 601);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureAi1);
            this.Controls.Add(this.labelNamePlayer2);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picturePlayer1);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.pictureWin);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Display";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "สะตาวอ";
            this.Load += new System.EventHandler(this.Display_Load);
            this.Shown += new System.EventHandler(this.Display_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Display_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Display_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAi1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.PictureBox picturePlayer1;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerBoom_1;
        private System.Windows.Forms.Timer timerWalk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerBoom_2;
        private System.Windows.Forms.Timer timerBoom_3;
        private System.Windows.Forms.Label labelNamePlayer2;
        private System.Windows.Forms.PictureBox pictureAi1;
        private System.Windows.Forms.Timer timerAI1;
        private System.Windows.Forms.Timer timerBoomAI1_1;
        private System.Windows.Forms.Timer timerBoomAI1_2;
        private System.Windows.Forms.Timer timerStartGame;
        private System.Windows.Forms.PictureBox pictureWin;
        private System.Windows.Forms.Label label2;
    }
}

