namespace Bomber
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonHighscore = new System.Windows.Forms.Button();
            this.labelShowScore = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonExitHelp = new System.Windows.Forms.Button();
            this.pictureHelp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BackColor = System.Drawing.Color.Olive;
            this.textBoxUserName.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.ForeColor = System.Drawing.Color.Transparent;
            this.textBoxUserName.Location = new System.Drawing.Point(377, 326);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(324, 36);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.Text = "NameBomber";
            this.textBoxUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Sienna;
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Enabled = false;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.Transparent;
            this.buttonStart.Location = new System.Drawing.Point(542, 372);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(159, 47);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.Transparent;
            this.buttonExit.Location = new System.Drawing.Point(542, 425);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(159, 47);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonHighscore
            // 
            this.buttonHighscore.BackColor = System.Drawing.Color.Orange;
            this.buttonHighscore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHighscore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHighscore.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHighscore.ForeColor = System.Drawing.Color.Transparent;
            this.buttonHighscore.Location = new System.Drawing.Point(377, 372);
            this.buttonHighscore.Name = "buttonHighscore";
            this.buttonHighscore.Size = new System.Drawing.Size(159, 47);
            this.buttonHighscore.TabIndex = 4;
            this.buttonHighscore.Text = "HighScore";
            this.buttonHighscore.UseVisualStyleBackColor = false;
            this.buttonHighscore.Click += new System.EventHandler(this.buttonHighscore_Click);
            // 
            // labelShowScore
            // 
            this.labelShowScore.BackColor = System.Drawing.Color.DimGray;
            this.labelShowScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelShowScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelShowScore.Location = new System.Drawing.Point(377, 277);
            this.labelShowScore.Name = "labelShowScore";
            this.labelShowScore.Size = new System.Drawing.Size(324, 47);
            this.labelShowScore.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(377, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonExitHelp
            // 
            this.buttonExitHelp.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitHelp.Location = new System.Drawing.Point(541, 120);
            this.buttonExitHelp.Name = "buttonExitHelp";
            this.buttonExitHelp.Size = new System.Drawing.Size(22, 25);
            this.buttonExitHelp.TabIndex = 9;
            this.buttonExitHelp.Text = "x";
            this.buttonExitHelp.UseVisualStyleBackColor = true;
            this.buttonExitHelp.Click += new System.EventHandler(this.buttonExitHelp_Click);
            // 
            // pictureHelp
            // 
            this.pictureHelp.Image = global::Bomber.Properties.Resources.howtoplay;
            this.pictureHelp.Location = new System.Drawing.Point(153, 111);
            this.pictureHelp.Name = "pictureHelp";
            this.pictureHelp.Size = new System.Drawing.Size(419, 245);
            this.pictureHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureHelp.TabIndex = 8;
            this.pictureHelp.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bomber.Properties.Resources.Login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 539);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelShowScore);
            this.Controls.Add(this.buttonHighscore);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonExitHelp);
            this.Controls.Add(this.pictureHelp);
            this.Font = new System.Drawing.Font("Forte", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonHighscore;
        private System.Windows.Forms.Label labelShowScore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonExitHelp;
        private System.Windows.Forms.PictureBox pictureHelp;
    }
}