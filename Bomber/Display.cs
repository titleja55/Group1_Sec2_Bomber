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
using System.Media;

namespace Bomber
{
    public partial class Display : Form
    {
        #region gobolObject

        #region Sound
        private SoundPlayer _SoundHighscore = new SoundPlayer(Properties.Resources.Highscore);
        private SoundPlayer _SoundWin = new SoundPlayer(Properties.Resources.may_the_force);
        private SoundPlayer _SoundDead = new SoundPlayer(Properties.Resources.Sound01);
        private SoundPlayer _SoundGetItem = new SoundPlayer(Properties.Resources.SoundPickItem);
        private SoundPlayer _SoundSetBoom = new SoundPlayer(Properties.Resources.SetBoom);
        private SoundPlayer _SoundTickBoom = new SoundPlayer(Properties.Resources.TimerExplosion);
        private SoundPlayer _SoundBoom = new SoundPlayer(Properties.Resources.SoundBoom01);
        

        private bool _bHigscore = false;
        #endregion

        #region Score
        private string _Score_txt = File.ReadAllText(@"data\Score.txt");
        private string _Highscore_txt = File.ReadAllText(@"data\Highscore.txt");
        int _nScore;
        string _GameOver = "false";
        #endregion

        #region Wall and Box
        private int[] ran_Wall = new int[10];
        Random rand = new Random();
        private int Maps = 1;
        #region Wall
        PictureBox[] ar_Wall_x1 = new PictureBox[15];
        PictureBox[] ar_Wall_x2 = new PictureBox[10];
        PictureBox[] ar_Wall_x3 = new PictureBox[10];
        PictureBox[] ar_Wall_x4 = new PictureBox[10];
        PictureBox[] ar_Wall_x5 = new PictureBox[10];
        PictureBox[] ar_Wall_x6 = new PictureBox[10];
        PictureBox[] ar_Wall_x7 = new PictureBox[10];
        PictureBox[] ar_Wall_x8 = new PictureBox[15];

        PictureBox[] ar_Wall_y1 = new PictureBox[13];
        PictureBox[] ar_Wall_y8 = new PictureBox[13];
        #endregion
        #region Box
        PictureBox[] ar_Box_x1 = new PictureBox[10];
        PictureBox[] ar_Box_x2 = new PictureBox[10];
        PictureBox[] ar_Box_x3 = new PictureBox[10];
        PictureBox[] ar_Box_x4 = new PictureBox[10];
        PictureBox[] ar_Box_x5 = new PictureBox[10];
        PictureBox[] ar_Box_x6 = new PictureBox[10];
        PictureBox[] ar_Box_x7 = new PictureBox[10];
        //PictureBox[] ar_Box_x8 = new PictureBox[10];
        //PictureBox[] ar_Box_x9 = new PictureBox[10];
        //PictureBox[] ar_Box_x10 = new PictureBox[10];
        //PictureBox[] ar_Box_x11 = new PictureBox[10];
        //PictureBox[] ar_Box_x12 = new PictureBox[10];
        //PictureBox[] ar_Box_x13 = new PictureBox[10];
        #endregion
        #endregion

        #region Item
        PictureBox[] ar_Item = new PictureBox[2];
       
        int[][] _ar_positionItem = {    new int[] { 0, 0 },//UP
                                        new int[] { 0, 0 },//Down
                                        new int[] { 0, 0 },//Left
                                        new int[] { 0, 0 } };//Rigth
        int _nNumItem1 = 0;
        int _nNumItem2 = 0;
        //PictureBox[] ar_ItemDown = new PictureBox[3];
        //PictureBox[] ar_ItemLeft = new PictureBox[3];
        //PictureBox[] ar_ItemRigth1 = new PictureBox[3];
        #endregion

        #region Player
        private Bomber[] _myPlayer = null;
        private int _nHour = 0, _nMinute = 0, _nSecond = 0;
        private string _sFacing = null;
        private int _nFacing = 1;
        private int _nNBPlayer = 1;
        #endregion
        #region BoomPlayer
        PictureBox BoomCenter1 = new PictureBox();
        PictureBox[] BoomUp1 = null;
        PictureBox[] BoomDown1 = null;
        PictureBox[] BoomLeft1 = null;
        PictureBox[] BoomRigth1 = null;

        PictureBox BoomCenter2 = new PictureBox();
        PictureBox[] BoomUp2 = null;
        PictureBox[] BoomDown2 = null;
        PictureBox[] BoomLeft2 = null;
        PictureBox[] BoomRigth2 = null;

        PictureBox BoomCenter3 = new PictureBox();
        PictureBox[] BoomUp3 = null;
        PictureBox[] BoomDown3 = null;
        PictureBox[] BoomLeft3 = null;
        PictureBox[] BoomRigth3 = null;

        private int _nBoom_1_Tick = 1;
        private int _nBoom_2_Tick = 1;
        private int _nBoom_3_Tick = 1;

        private int _x, _y;//ตำแหน่งวางระเบิท
        #endregion


        #region MyAI
        private Bomber[] _myAi = new Bomber[3];
        private string _sFacing_AI = "Up";
        private int _nFacing_AI = 1;
        #endregion
        #region BoomAI1
        PictureBox ai1_BoomCenter1 = new PictureBox();
        PictureBox[] ai1_BoomUp1 = null;
        PictureBox[] ai1_BoomDown1 = null;
        PictureBox[] ai1_BoomLeft1 = null;
        PictureBox[] ai1_BoomRigth1 = null;

        PictureBox ai1_BoomCenter2 = new PictureBox();
        PictureBox[] ai1_BoomUp2 = null;
        PictureBox[] ai1_BoomDown2 = null;
        PictureBox[] ai1_BoomLeft2 = null;
        PictureBox[] ai1_BoomRigth2 = null;

        private int ai1_nBoom_1_Tick = 1;
        private int ai1_nBoom_2_Tick = 1;

        private int _xAI1, _yAI1;//ตำแหน่งวางระเบิท
        #endregion

        #endregion

        public Display()
        {
            InitializeComponent();
            
         
        }
        private void Display_Shown(object sender, EventArgs e)
        {
            FormLogin Login = new FormLogin();
            Login.Show();
           
        }
        private void Dead(ref PictureBox Rip)
        {
            switch (Rip.Name)
            {
                case "picturePlayer1":
                    Highscore Score = new Highscore();
                    Score.Cshift(label2.Text, _nScore);
                    _SoundDead.Play();
                    timerAI1.Stop();
                    Rip.Image = Properties.Resources.RIP;
                    PictureBox GameOver = new PictureBox();
                    GameOver.Image = Properties.Resources.GameOv;
                    GameOver.Height = 640;
                    GameOver.Width = 815;
                    GameOver.Top = 0;
                    GameOver.Left = 0;
                    GameOver.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(GameOver);
                    GameOver.BringToFront();
                    GameOver.BackColor = Color.Transparent;
                    _GameOver = "ture";
                    break;
                case "pictureAi1":
                    _SoundDead.Play();
                    Rip.Image = Properties.Resources.RIP;
                    _nScore += 100;
                    timerAI1.Stop();
                    timerBoomAI1_1.Stop();
                    timerBoomAI1_2.Stop();
                    _GameOver = "Win";
                    break;
            }
        }
        private void Display_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserName = "";
            Properties.Settings.Default.Save();
            timerStartGame.Start();
            _nScore = Convert.ToInt32(_Score_txt);
           
            labelMap.Controls.Add(picturePlayer1);
            labelMap.Controls.Add(pictureAi1);

            ar_Item[0] = new PictureBox();
            ar_Item[1] = new PictureBox();

            AddWall();
            AddBox();

            #region _myPlayer
            _myPlayer = new Bomber[_nNBPlayer];
            for (int i = 0; i < _myPlayer.Length; i++)
            {
                _myPlayer[i] = new Bomber();
            }
            #endregion
        }
        private void timerStartGame_Tick(object sender, EventArgs e)
        {
            label2.Text = Properties.Settings.Default.UserName;
            if (label2.Text == "") return;
            else
            {
                timerClock.Start();
                timerAI1.Start();
                label2.Text = Properties.Settings.Default.UserName;
                timerStartGame.Stop();
            }
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            timerClock.Interval = 1000;
            _nSecond++;
            if (_nSecond == 60)
            {
                _nSecond = 0;
                _nMinute++;
                if (_nMinute == 60)
                {
                    _nMinute = 0;
                    _nHour++;
                }
            }
            string[] spl = _Highscore_txt.Split(',');
            string sHighscore = spl[1];
            if (_nScore > Convert.ToInt32(sHighscore))
            {
                sHighscore = _nScore.ToString();
                if (_bHigscore == false)
                {
                    //_SoundHighscore.Play();
                    _bHigscore = true;
                }
            }
            labelScore.Text = "Time :" + _nHour.ToString("00") + ":" + _nMinute.ToString("00") + ":" + _nSecond.ToString("00")
            + Environment.NewLine + "Score :" + _nScore.ToString() + Environment.NewLine + "Highscore :" + sHighscore;

            picturePlayer1.Text = _sFacing;

            labelPlayer1.Text = _myPlayer[_nNBPlayer - 1].ToString();
            if (_GameOver == "ture") picturePlayer1.Image = Properties.Resources.RIP;
            else if (_GameOver == "Win")
            {
                pictureWin.BringToFront();
                _SoundWin.Play();
                timerClock.Stop();
            }
        }
        #region AddWall

        private void AddWall()
        {
            if (Maps == 1)
            {
                Wall_x1();
                Wall_x2();
                Wall_x3();
                Wall_x4();
                Wall_x5();
                Wall_x6();
                Wall_x7();
                Wall_x8();
                Wall_y1();
                Wall_y8();
            }
        }

        #region Addwallx
        private void Wall_x1()
        {
            for (int i = 0; i < ar_Wall_x1.Length; i++)
            {
                ar_Wall_x1[i] = new PictureBox();
                ar_Wall_x1[i].Name = "picWall" + i;
                ar_Wall_x1[i].Width = 40;
                ar_Wall_x1[i].Height = 40;
                ar_Wall_x1[i].Left = 0 + i * 40;
                ar_Wall_x1[i].Top = 0;
                ar_Wall_x1[i].Image = Properties.Resources.Stone02;
                ar_Wall_x1[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x1[i]);
            }
        }
        private void Wall_x2()
        {
            for (int i = 0; i < ar_Wall_x2.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Wall_x2[i] = new PictureBox();
                ar_Wall_x2[i].Name = "picWall" + i;
                ar_Wall_x2[i].Width = 40;
                ar_Wall_x2[i].Height = 40;
                ar_Wall_x2[i].Left = 40 + (ran_Wall[i] * 40);
                ar_Wall_x2[i].Top = 80;
                ar_Wall_x2[i].Image = Properties.Resources.Stone02;
                ar_Wall_x2[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x2[i]);
            }
        }
        private void Wall_x3()
        {
            for (int i = 0; i < ar_Wall_x3.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Wall_x3[i] = new PictureBox();
                ar_Wall_x3[i].Name = "picWall" + i;
                ar_Wall_x3[i].Width = 40;
                ar_Wall_x3[i].Height = 40;
                ar_Wall_x3[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Wall_x3[i].Top = 160;
                ar_Wall_x3[i].Image = Properties.Resources.Stone02;
                ar_Wall_x3[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x3[i]);
            }
        }
        private void Wall_x4()
        {
            for (int i = 0; i < ar_Wall_x4.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 14);
                ar_Wall_x4[i] = new PictureBox();
                ar_Wall_x4[i].Name = "picWall" + i;
                ar_Wall_x4[i].Width = 40;
                ar_Wall_x4[i].Height = 40;
                ar_Wall_x4[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Wall_x4[i].Top = 240;
                ar_Wall_x4[i].Image = Properties.Resources.Stone02;
                ar_Wall_x4[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x4[i]);
            }
        }
        private void Wall_x5()
        {
            for (int i = 0; i < ar_Wall_x5.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 14);
                ar_Wall_x5[i] = new PictureBox();
                ar_Wall_x5[i].Name = "picWall" + i;
                ar_Wall_x5[i].Width = 40;
                ar_Wall_x5[i].Height = 40;
                ar_Wall_x5[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Wall_x5[i].Top = 320;
                ar_Wall_x5[i].Image = Properties.Resources.Stone02;
                ar_Wall_x5[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x5[i]);
            }
        }
        private void Wall_x6()
        {
            for (int i = 0; i < ar_Wall_x6.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 14);
                ar_Wall_x6[i] = new PictureBox();
                ar_Wall_x6[i].Name = "picWall" + i;
                ar_Wall_x6[i].Width = 40;
                ar_Wall_x6[i].Height = 40;
                ar_Wall_x6[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Wall_x6[i].Top = 400;
                ar_Wall_x6[i].Image = Properties.Resources.Stone02;
                ar_Wall_x6[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x6[i]);
            }
        }
        private void Wall_x7()
        {
            for (int i = 0; i < ar_Wall_x7.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 14);
                ar_Wall_x7[i] = new PictureBox();
                ar_Wall_x7[i].Name = "picWall" + i;
                ar_Wall_x7[i].Width = 40;
                ar_Wall_x7[i].Height = 40;
                if (ran_Wall[i] == 14 || ran_Wall[i] == 13) ar_Wall_x7[i].Left = 480;
                else ar_Wall_x7[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Wall_x7[i].Top = 480;
                ar_Wall_x7[i].Image = Properties.Resources.Stone02;
                ar_Wall_x7[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x7[i]);
            }
        }
        private void Wall_x8()
        {
            for (int i = 0; i < ar_Wall_x8.Length; i++)
            {
                ar_Wall_x8[i] = new PictureBox();
                ar_Wall_x8[i].Name = "picWall" + i;
                ar_Wall_x8[i].Width = 40;
                ar_Wall_x8[i].Height = 40;
                ar_Wall_x8[i].Left = 0 + (i * 40);
                ar_Wall_x8[i].Top = 560;
                ar_Wall_x8[i].Image = Properties.Resources.Stone02;
                ar_Wall_x8[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_x8[i]);
            }
        }
        #endregion
        #region Addwally
        private void Wall_y1()
        {
            for (int i = 0; i < ar_Wall_y1.Length; i++)
            {
                ar_Wall_y1[i] = new PictureBox();
                ar_Wall_y1[i].Name = "picWall" + i;
                ar_Wall_y1[i].Width = 40;
                ar_Wall_y1[i].Height = 40;
                ar_Wall_y1[i].Left = 0;
                ar_Wall_y1[i].Top = 40 + i * 40;
                ar_Wall_y1[i].Image = Properties.Resources.Stone02;
                ar_Wall_y1[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_y1[i]);
            }
        }
        private void Wall_y8()
        {
            for (int i = 0; i < ar_Wall_y8.Length; i++)
            {
                ar_Wall_y8[i] = new PictureBox();
                ar_Wall_y8[i].Name = "picWall" + i;
                ar_Wall_y8[i].Width = 40;
                ar_Wall_y8[i].Height = 40;
                ar_Wall_y8[i].Left = 560;
                ar_Wall_y8[i].Top = 40 + (i * 40);
                ar_Wall_y8[i].Image = Properties.Resources.Stone02;
                ar_Wall_y8[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Wall_y8[i]);
            }
        }
        #endregion

        #endregion
        #region AddBox
        private void AddBox()
        {
            Box_x1();
            Box_x2();
            Box_x3();
            Box_x4();
            Box_x5();
            Box_x6();
            Box_x7();
            //Box_x8();
            //Box_x9();
            //Box_x10();
            //Box_x11();
            //Box_x12();
            //Box_x13();
        }
        private void Box_x1()
        {
            for (int i = 0; i < ar_Box_x1.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Box_x1[i] = new PictureBox();
                ar_Box_x1[i].Name = "picWall" + i;
                ar_Box_x1[i].Width = 40;
                ar_Box_x1[i].Height = 40;
                ar_Box_x1[i].Left = 120 + (ran_Wall[i] * 40);
                ar_Box_x1[i].Top = 40;
                ar_Box_x1[i].Image = Properties.Resources.box;
                ar_Box_x1[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Box_x1[i]);
            }
        }
        private void Box_x2()
        {
            for (int i = 0; i < ar_Box_x2.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Box_x2[i] = new PictureBox();
                ar_Box_x2[i].Name = "picWall" + i;
                ar_Box_x2[i].Width = 40;
                ar_Box_x2[i].Height = 40;
                ar_Box_x2[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Box_x2[i].Top = 120;
                ar_Box_x2[i].Image = Properties.Resources.box;
                ar_Box_x2[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Box_x2[i]);
            }
        }
        private void Box_x3()
        {
            for (int i = 0; i < ar_Box_x3.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Box_x3[i] = new PictureBox();
                ar_Box_x3[i].Name = "picWall" + i;
                ar_Box_x3[i].Width = 40;
                ar_Box_x3[i].Height = 40;
                ar_Box_x3[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Box_x3[i].Top = 200;
                ar_Box_x3[i].Image = Properties.Resources.box;
                ar_Box_x3[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Box_x3[i]);
            }
        }
        private void Box_x4()
        {
            for (int i = 0; i < ar_Box_x4.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Box_x4[i] = new PictureBox();
                ar_Box_x4[i].Name = "picWall" + i;
                ar_Box_x4[i].Width = 40;
                ar_Box_x4[i].Height = 40;
                ar_Box_x4[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Box_x4[i].Top = 280;
                ar_Box_x4[i].Image = Properties.Resources.box;
                ar_Box_x4[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Box_x4[i]);
            }
        }
        private void Box_x5()
        {
            for (int i = 0; i < ar_Box_x5.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Box_x5[i] = new PictureBox();
                ar_Box_x5[i].Name = "picWall" + i;
                ar_Box_x5[i].Width = 40;
                ar_Box_x5[i].Height = 40;
                ar_Box_x5[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Box_x5[i].Top = 360;
                ar_Box_x5[i].Image = Properties.Resources.box;
                ar_Box_x5[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Box_x5[i]);
            }
        }
        private void Box_x6()
        {
            for (int i = 0; i < ar_Box_x6.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Box_x6[i] = new PictureBox();
                ar_Box_x6[i].Name = "picWall" + i;
                ar_Box_x6[i].Width = 40;
                ar_Box_x6[i].Height = 40;
                ar_Box_x6[i].Left = 0 + (ran_Wall[i] * 40);
                ar_Box_x6[i].Top = 440;
                ar_Box_x6[i].Image = Properties.Resources.box;
                ar_Box_x6[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Box_x6[i]);
            }
        }
        private void Box_x7()
        {
            for (int i = 0; i < ar_Box_x7.Length; i++)
            {
                ran_Wall[i] = rand.Next(1, 13);
                ar_Box_x7[i] = new PictureBox();
                ar_Box_x7[i].Name = "picWall" + i;
                ar_Box_x7[i].Width = 40;
                ar_Box_x7[i].Height = 40;
                ar_Box_x7[i].Left = -80 + (ran_Wall[i] * 40);
                ar_Box_x7[i].Top = 520;
                ar_Box_x7[i].Image = Properties.Resources.box;
                ar_Box_x7[i].BackColor = Color.Transparent;
                labelMap.Controls.Add(ar_Box_x7[i]);
            }
        }
        #endregion
       
        #region MyPlayer1

        #region AllKeyBroad
        public void Display_KeyDown(object sender, KeyEventArgs e)
        {
            if (_nSecond == 0) return;
            if (_GameOver == "ture") return;
            #region Move
            switch (e.KeyCode)
            {
                case Keys.Up:
                    timerWalk.Start();
                    _sFacing = "Up";
                    PlayerUp();
                    break;
                case Keys.Down:
                    timerWalk.Start();
                    _sFacing = "Down";
                    PlayerDown();
                    break;
                case Keys.Left:
                    timerWalk.Start();
                    _sFacing = "Left";
                    PlayerLeft();
                    break;
                case Keys.Right:
                    timerWalk.Start();
                    _sFacing = "Right";
                    PlayerRight();
                    break;
            }
            label3.Text = picturePlayer1.Left.ToString();
            label4.Text = picturePlayer1.Top.ToString();
            #endregion

            #region Boom
            if (e.KeyCode == Keys.Space && picturePlayer1.Top % 40 == 0 && picturePlayer1.Left % 40 == 0)
            {
                _SoundSetBoom.Play();
                _x = picturePlayer1.Left;
                _y = picturePlayer1.Top;

                #region setBoom
                if (_myPlayer[_nNBPlayer - 1].NumberBoom == 1)
                {
                    if (_nBoom_1_Tick == 1)
                    {
                        timerBoom_1.Start();
                    }
                }
                if (_myPlayer[_nNBPlayer - 1].NumberBoom == 2)
                {
                    if (_nBoom_1_Tick == 1)
                    {
                        timerBoom_1.Start();
                    }
                    else if (_nBoom_1_Tick != 1 && _nBoom_2_Tick == 1)
                    {
                        timerBoom_2.Start();
                    }
                }
                if (_myPlayer[_nNBPlayer - 1].NumberBoom == 3)
                {
                    if (_nBoom_1_Tick == 1)
                    {
                        timerBoom_1.Start();
                    }
                    else if (_nBoom_1_Tick != 1 && _nBoom_2_Tick == 1)
                    {
                        timerBoom_2.Start();
                    }
                    else if (_nBoom_2_Tick != 1 && _nBoom_3_Tick == 1)
                    {
                        timerBoom_3.Start();
                    }
                }
                #endregion
            }
            #endregion

            #region Item
            if (_nBoom_1_Tick == 1 && _nBoom_2_Tick == 1 && _nBoom_3_Tick == 1)
            {
                for (int i = 0; i < ar_Item.Length; i++)
                {
                    if (picturePlayer1.Location == ar_Item[i].Location)
                    {
                        _SoundGetItem.Play();
                        switch (ar_Item[i].Name)
                        {
                            case "Speed":
                                _myPlayer[_nNBPlayer - 1].Speed += 1;
                                if (i == 0) _nNumItem1 = 0;
                                if (i == 1) _nNumItem2 = 0;
                                break;
                            case "Power":
                                _myPlayer[_nNBPlayer - 1].Power += 1;
                                if (i == 0) _nNumItem1 = 0;
                                if (i == 1) _nNumItem2 = 0;
                                break;
                            case "NBBoom":
                                _myPlayer[_nNBPlayer - 1].NumberBoom += 1;
                                if (i == 0) _nNumItem1 = 0;
                                if (i == 1) _nNumItem2 = 0;
                                break;
                        }
                        
                        labelMap.Controls.Remove(ar_Item[i]);
                        ar_Item[i].Top = 0;
                        ar_Item[i].Left = 0;
                    }
                }
            }
            #endregion

        }
        private void Display_KeyUp(object sender, KeyEventArgs e)
        {
            #region Move
            timerWalk.Stop();
            #endregion
        }
        #endregion

        #region CheckMove
        private void PlayerUp()
        {
            if (picturePlayer1.Right % 40 != 0) return;
            #region Wall
            for (int i = 0; i < ar_Wall_x1.Length; i++)
            {
                if (picturePlayer1.Top == ar_Wall_x1[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x2.Length; i++)
            {
                if (picturePlayer1.Top == ar_Wall_x2[i].Bottom && picturePlayer1.Right > ar_Wall_x2[i].Left && picturePlayer1.Right <= ar_Wall_x2[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Wall_x2[i].Bottom && picturePlayer1.Left > ar_Wall_x2[i].Left && picturePlayer1.Right > ar_Wall_x2[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x3.Length; i++)
            {
                if (picturePlayer1.Top == ar_Wall_x3[i].Bottom && picturePlayer1.Right > ar_Wall_x3[i].Left && picturePlayer1.Right <= ar_Wall_x3[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Wall_x3[i].Bottom && picturePlayer1.Left > ar_Wall_x3[i].Left && picturePlayer1.Right > ar_Wall_x3[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x4.Length; i++)
            {
                if (picturePlayer1.Top == ar_Wall_x4[i].Bottom && picturePlayer1.Right > ar_Wall_x4[i].Left && picturePlayer1.Right <= ar_Wall_x4[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Wall_x4[i].Bottom && picturePlayer1.Left > ar_Wall_x4[i].Left && picturePlayer1.Right > ar_Wall_x4[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x5.Length; i++)
            {
                if (picturePlayer1.Top == ar_Wall_x5[i].Bottom && picturePlayer1.Right > ar_Wall_x5[i].Left && picturePlayer1.Right <= ar_Wall_x5[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Wall_x5[i].Bottom && picturePlayer1.Left > ar_Wall_x5[i].Left && picturePlayer1.Right > ar_Wall_x5[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x6.Length; i++)
            {
                if (picturePlayer1.Top == ar_Wall_x6[i].Bottom && picturePlayer1.Right > ar_Wall_x6[i].Left && picturePlayer1.Right <= ar_Wall_x6[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Wall_x6[i].Bottom && picturePlayer1.Left > ar_Wall_x6[i].Left && picturePlayer1.Right > ar_Wall_x6[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x7.Length; i++)
            {
                if (picturePlayer1.Top == ar_Wall_x7[i].Bottom && picturePlayer1.Right > ar_Wall_x7[i].Left && picturePlayer1.Right <= ar_Wall_x7[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Wall_x7[i].Bottom && picturePlayer1.Left > ar_Wall_x7[i].Left && picturePlayer1.Right > ar_Wall_x7[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            #endregion
            #region Box
            for (int i = 0; i < ar_Box_x1.Length; i++)
            {
                if (picturePlayer1.Top == ar_Box_x1[i].Bottom && picturePlayer1.Right > ar_Box_x1[i].Left && picturePlayer1.Right <= ar_Box_x1[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Box_x1[i].Bottom && picturePlayer1.Left > ar_Box_x1[i].Left && picturePlayer1.Right > ar_Box_x1[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x2.Length; i++)
            {
                if (picturePlayer1.Top == ar_Box_x2[i].Bottom && picturePlayer1.Right > ar_Box_x2[i].Left && picturePlayer1.Right <= ar_Box_x2[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Box_x2[i].Bottom && picturePlayer1.Left > ar_Box_x2[i].Left && picturePlayer1.Right > ar_Box_x2[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x3.Length; i++)
            {
                if (picturePlayer1.Top == ar_Box_x3[i].Bottom && picturePlayer1.Right > ar_Box_x3[i].Left && picturePlayer1.Right <= ar_Box_x3[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Box_x3[i].Bottom && picturePlayer1.Left > ar_Box_x3[i].Left && picturePlayer1.Right > ar_Box_x3[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x4.Length; i++)
            {
                if (picturePlayer1.Top == ar_Box_x4[i].Bottom && picturePlayer1.Right > ar_Box_x4[i].Left && picturePlayer1.Right <= ar_Box_x4[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Box_x4[i].Bottom && picturePlayer1.Left > ar_Box_x4[i].Left && picturePlayer1.Right > ar_Box_x4[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x5.Length; i++)
            {
                if (picturePlayer1.Top == ar_Box_x5[i].Bottom && picturePlayer1.Right > ar_Box_x5[i].Left && picturePlayer1.Right <= ar_Box_x5[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Box_x5[i].Bottom && picturePlayer1.Left > ar_Box_x5[i].Left && picturePlayer1.Right > ar_Box_x5[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x6.Length; i++)
            {
                if (picturePlayer1.Top == ar_Box_x6[i].Bottom && picturePlayer1.Right > ar_Box_x6[i].Left && picturePlayer1.Right <= ar_Box_x6[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Top == ar_Box_x6[i].Bottom && picturePlayer1.Left > ar_Box_x6[i].Left && picturePlayer1.Right > ar_Box_x6[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            #endregion
            #region Boom
            if (picturePlayer1.Right == BoomCenter1.Right & picturePlayer1.Top == BoomCenter1.Bottom) return;
            if (picturePlayer1.Right == BoomCenter2.Right & picturePlayer1.Top == BoomCenter2.Bottom) return;
            if (picturePlayer1.Right == BoomCenter3.Right & picturePlayer1.Top == BoomCenter3.Bottom) return;
            if (picturePlayer1.Right == ai1_BoomCenter1.Right & picturePlayer1.Top == ai1_BoomCenter1.Bottom) return;
            if (picturePlayer1.Right == ai1_BoomCenter2.Right & picturePlayer1.Top == ai1_BoomCenter2.Bottom) return;
            #endregion
            picturePlayer1.Top -= 2 * _myPlayer[_nNBPlayer - 1].Speed;
        }
        private void PlayerDown()
        {
            if (picturePlayer1.Right % 40 != 0) return;
            #region Wall
            for (int i = 0; i < ar_Wall_x2.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x2[i].Top && picturePlayer1.Right > ar_Wall_x2[i].Left && picturePlayer1.Right <= ar_Wall_x2[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Wall_x2[i].Top && picturePlayer1.Left > ar_Wall_x2[i].Left && picturePlayer1.Right > ar_Wall_x2[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x3.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x3[i].Top && picturePlayer1.Right > ar_Wall_x3[i].Left && picturePlayer1.Right <= ar_Wall_x3[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Wall_x3[i].Top && picturePlayer1.Left > ar_Wall_x3[i].Left && picturePlayer1.Right > ar_Wall_x3[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x4.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x4[i].Top && picturePlayer1.Right > ar_Wall_x4[i].Left && picturePlayer1.Right <= ar_Wall_x4[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Wall_x4[i].Top && picturePlayer1.Left > ar_Wall_x4[i].Left && picturePlayer1.Right > ar_Wall_x4[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x5.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x5[i].Top && picturePlayer1.Right > ar_Wall_x5[i].Left && picturePlayer1.Right <= ar_Wall_x5[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Wall_x5[i].Top && picturePlayer1.Left > ar_Wall_x5[i].Left && picturePlayer1.Right > ar_Wall_x5[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x6.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x6[i].Top && picturePlayer1.Right > ar_Wall_x6[i].Left && picturePlayer1.Right <= ar_Wall_x6[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Wall_x6[i].Top && picturePlayer1.Left > ar_Wall_x6[i].Left && picturePlayer1.Right > ar_Wall_x6[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x7.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x7[i].Top && picturePlayer1.Right > ar_Wall_x7[i].Left && picturePlayer1.Right <= ar_Wall_x7[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Wall_x7[i].Top && picturePlayer1.Left > ar_Wall_x7[i].Left && picturePlayer1.Right > ar_Wall_x7[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x8.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x8[i].Top)
                {
                    return;
                }
            }
            #endregion
            #region Box
            for (int i = 0; i < ar_Box_x2.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Box_x2[i].Top && picturePlayer1.Right > ar_Box_x2[i].Left && picturePlayer1.Right <= ar_Box_x2[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Box_x2[i].Top && picturePlayer1.Left > ar_Box_x2[i].Left && picturePlayer1.Right > ar_Box_x2[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x3.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Box_x3[i].Top && picturePlayer1.Right > ar_Box_x3[i].Left && picturePlayer1.Right <= ar_Box_x3[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Box_x3[i].Top && picturePlayer1.Left > ar_Box_x3[i].Left && picturePlayer1.Right > ar_Box_x3[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }

            for (int i = 0; i < ar_Box_x4.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Box_x4[i].Top && picturePlayer1.Right > ar_Box_x4[i].Left && picturePlayer1.Right <= ar_Box_x4[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Box_x4[i].Top && picturePlayer1.Left > ar_Box_x4[i].Left && picturePlayer1.Right > ar_Box_x4[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }

            for (int i = 0; i < ar_Box_x5.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Box_x5[i].Top && picturePlayer1.Right > ar_Box_x5[i].Left && picturePlayer1.Right <= ar_Box_x5[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Box_x5[i].Top && picturePlayer1.Left > ar_Box_x5[i].Left && picturePlayer1.Right > ar_Box_x5[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }

            for (int i = 0; i < ar_Box_x6.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Box_x6[i].Top && picturePlayer1.Right > ar_Box_x6[i].Left && picturePlayer1.Right <= ar_Box_x6[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Box_x6[i].Top && picturePlayer1.Left > ar_Box_x6[i].Left && picturePlayer1.Right > ar_Box_x6[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }

            for (int i = 0; i < ar_Box_x7.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Box_x7[i].Top && picturePlayer1.Right > ar_Box_x7[i].Left && picturePlayer1.Right <= ar_Box_x7[i].Right)
                {
                    return;
                }
                if (picturePlayer1.Bottom == ar_Box_x7[i].Top && picturePlayer1.Left > ar_Box_x7[i].Left && picturePlayer1.Right > ar_Box_x7[i].Right && picturePlayer1.Right % 40 != 0)
                {
                    return;
                }
            }


            #endregion
            #region Boom
            if (picturePlayer1.Right == BoomCenter1.Right & picturePlayer1.Bottom == BoomCenter1.Top) return;
            if (picturePlayer1.Right == BoomCenter2.Right & picturePlayer1.Bottom == BoomCenter2.Top) return;
            if (picturePlayer1.Right == BoomCenter3.Right & picturePlayer1.Bottom == BoomCenter3.Top) return;
            if (picturePlayer1.Right == ai1_BoomCenter1.Right & picturePlayer1.Bottom == ai1_BoomCenter1.Top) return;
            if (picturePlayer1.Right == ai1_BoomCenter2.Right & picturePlayer1.Bottom == ai1_BoomCenter2.Top) return;
            #endregion
            picturePlayer1.Top += 2 * _myPlayer[_nNBPlayer - 1].Speed;
        }
        private void PlayerLeft()
        {
            if (picturePlayer1.Top % 40 != 0) return;
            #region Wall
            for (int i = 0; i < ar_Wall_y1.Length; i++)
            {
                if (picturePlayer1.Left == ar_Wall_y1[i].Right)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x2.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x2[i].Bottom && picturePlayer1.Left == ar_Wall_x2[i].Right)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x3.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x3[i].Bottom && picturePlayer1.Left == ar_Wall_x3[i].Right)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x4.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x4[i].Bottom && picturePlayer1.Left == ar_Wall_x4[i].Right)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x5.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x5[i].Bottom && picturePlayer1.Left == ar_Wall_x5[i].Right)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x6.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x6[i].Bottom && picturePlayer1.Left == ar_Wall_x6[i].Right)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x7.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x7[i].Bottom && picturePlayer1.Left == ar_Wall_x7[i].Right)
                {
                    return;
                }
            }
            #endregion
            #region Box
            for (int i = 0; i < ar_Box_x1.Length; i++)
            {
                if (picturePlayer1.Left == ar_Box_x1[i].Right && picturePlayer1.Bottom == ar_Box_x1[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x2.Length; i++)
            {
                if (picturePlayer1.Left == ar_Box_x2[i].Right && picturePlayer1.Bottom == ar_Box_x2[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x3.Length; i++)
            {
                if (picturePlayer1.Left == ar_Box_x3[i].Right && picturePlayer1.Bottom == ar_Box_x3[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x4.Length; i++)
            {
                if (picturePlayer1.Left == ar_Box_x4[i].Right && picturePlayer1.Bottom == ar_Box_x4[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x5.Length; i++)
            {
                if (picturePlayer1.Left == ar_Box_x5[i].Right && picturePlayer1.Bottom == ar_Box_x5[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x6.Length; i++)
            {
                if (picturePlayer1.Left == ar_Box_x6[i].Right && picturePlayer1.Bottom == ar_Box_x6[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x7.Length; i++)
            {
                if (picturePlayer1.Left == ar_Box_x7[i].Right && picturePlayer1.Bottom == ar_Box_x7[i].Bottom)
                {
                    return;
                }
            }
            #endregion
            #region Boom
            if (picturePlayer1.Top == BoomCenter1.Top & picturePlayer1.Left == BoomCenter1.Right) return;
            if (picturePlayer1.Top == BoomCenter2.Top & picturePlayer1.Left == BoomCenter2.Right) return;
            if (picturePlayer1.Top == BoomCenter3.Top & picturePlayer1.Left == BoomCenter3.Right) return;
            if (picturePlayer1.Top == ai1_BoomCenter1.Top & picturePlayer1.Left == ai1_BoomCenter1.Right) return;
            if (picturePlayer1.Top == ai1_BoomCenter2.Top & picturePlayer1.Left == ai1_BoomCenter2.Right) return;
            #endregion
            picturePlayer1.Left -= 2 * _myPlayer[_nNBPlayer - 1].Speed;
        }
        private void PlayerRight()
        {
            if (picturePlayer1.Top % 40 != 0) return;
            #region Wall
            for (int i = 0; i < ar_Wall_y8.Length; i++)
            {
                if (picturePlayer1.Right == ar_Wall_y8[i].Left)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x2.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x2[i].Bottom && picturePlayer1.Right == ar_Wall_x2[i].Left)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x3.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x3[i].Bottom && picturePlayer1.Right == ar_Wall_x3[i].Left)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x4.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x4[i].Bottom && picturePlayer1.Right == ar_Wall_x4[i].Left)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x5.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x5[i].Bottom && picturePlayer1.Right == ar_Wall_x5[i].Left)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x6.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x6[i].Bottom && picturePlayer1.Right == ar_Wall_x6[i].Left)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Wall_x7.Length; i++)
            {
                if (picturePlayer1.Bottom == ar_Wall_x7[i].Bottom && picturePlayer1.Right == ar_Wall_x7[i].Left)
                {
                    return;
                }
            }
            #endregion
            #region Box
            for (int i = 0; i < ar_Box_x1.Length; i++)
            {
                if (picturePlayer1.Right == ar_Box_x1[i].Left && picturePlayer1.Bottom == ar_Box_x1[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x2.Length; i++)
            {
                if (picturePlayer1.Right == ar_Box_x2[i].Left && picturePlayer1.Bottom == ar_Box_x2[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x3.Length; i++)
            {
                if (picturePlayer1.Right == ar_Box_x3[i].Left && picturePlayer1.Bottom == ar_Box_x3[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x4.Length; i++)
            {
                if (picturePlayer1.Right == ar_Box_x4[i].Left && picturePlayer1.Bottom == ar_Box_x4[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x5.Length; i++)
            {
                if (picturePlayer1.Right == ar_Box_x5[i].Left && picturePlayer1.Bottom == ar_Box_x5[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x6.Length; i++)
            {
                if (picturePlayer1.Right == ar_Box_x6[i].Left && picturePlayer1.Bottom == ar_Box_x6[i].Bottom)
                {
                    return;
                }
            }
            for (int i = 0; i < ar_Box_x7.Length; i++)
            {
                if (picturePlayer1.Right == ar_Box_x7[i].Left && picturePlayer1.Bottom == ar_Box_x7[i].Bottom)
                {
                    return;
                }
            }
            #endregion
            #region Boom
            if (picturePlayer1.Top == BoomCenter1.Top & picturePlayer1.Right == BoomCenter1.Left) return;
            if (picturePlayer1.Top == BoomCenter2.Top & picturePlayer1.Right == BoomCenter2.Left) return;
            if (picturePlayer1.Top == BoomCenter3.Top & picturePlayer1.Right == BoomCenter3.Left) return;
            if (picturePlayer1.Top == ai1_BoomCenter1.Top & picturePlayer1.Right == ai1_BoomCenter1.Left) return;
            if (picturePlayer1.Top == ai1_BoomCenter2.Top & picturePlayer1.Right == ai1_BoomCenter2.Left) return;
            #endregion

            picturePlayer1.Left += 2 * _myPlayer[_nNBPlayer - 1].Speed;
        }
        #endregion

        #region AddItem
        private void positionItem()
        {
            for (int i = 0; i < _ar_positionItem.Length; i++)
            {
                if (_ar_positionItem[i][0] != 0)
                {
                    RandomItem(_ar_positionItem[i][0], _ar_positionItem[i][1]);
                    break;
                }
            }
        }
        private void RandomItem(int y, int x)
        {
            int[] nRandomItem = new int[3];
            for (int i = 0; i < ar_Item.Length; i++)
            {
                #region RandomItem1
                if (_nNumItem1 == 0)
                {
                    nRandomItem[i] = rand.Next(0, 5);
                    if (nRandomItem[i] == 0)
                    {
                        ar_Item[0] = new PictureBox();
                        ar_Item[0].Name = "Speed";
                        ar_Item[0].Width = 40;
                        ar_Item[0].Height = 40;
                        ar_Item[0].Top = y;
                        ar_Item[0].Left = x;
                        ar_Item[0].Image = Properties.Resources.PlayerSpeed;
                        ar_Item[0].BackColor = Color.Transparent;
                        labelMap.Controls.Add(ar_Item[0]);
                        _nNumItem1 = 1;
                        break;
                    }
                    else if (nRandomItem[i] == 1)
                    {
                        ar_Item[0] = new PictureBox();
                        ar_Item[0].Name = "Power";
                        ar_Item[0].Width = 40;
                        ar_Item[0].Height = 40;
                        ar_Item[0].Top = y;
                        ar_Item[0].Left = x;
                        ar_Item[0].Image = Properties.Resources.PowerBomb;
                        ar_Item[0].BackColor = Color.Transparent;
                        labelMap.Controls.Add(ar_Item[0]);
                        _nNumItem1 = 1;
                        break;
                    }
                    else if (nRandomItem[i] == 2)
                    {
                        ar_Item[0] = new PictureBox();
                        ar_Item[0].Name = "NBBoom";
                        ar_Item[0].Width = 40;
                        ar_Item[0].Height = 40;
                        ar_Item[0].Top = y;
                        ar_Item[0].Left = x;
                        ar_Item[0].Image = Properties.Resources.NumberBomb;
                        ar_Item[0].BackColor = Color.Transparent;
                        labelMap.Controls.Add(ar_Item[0]);
                        _nNumItem1 = 1;
                        break;
                    }
                    else _nNumItem1 = 0;
                }
                #endregion
                #region RandomItem2
                if (_nNumItem2 == 0)
                {
                    nRandomItem[i] = rand.Next(0, 5);
                    if (nRandomItem[i] == 0)
                    {
                        ar_Item[1] = new PictureBox();
                        ar_Item[1].Name = "Speed";
                        ar_Item[1].Width = 40;
                        ar_Item[1].Height = 40;
                        ar_Item[1].Top = y;
                        ar_Item[1].Left = x;
                        ar_Item[1].Image = Properties.Resources.PlayerSpeed;
                        ar_Item[1].BackColor = Color.Transparent;
                        labelMap.Controls.Add(ar_Item[1]);
                        _nNumItem2 = 1;
                        break;
                    }
                    else if (nRandomItem[i] == 1)
                    {
                        ar_Item[1] = new PictureBox();
                        ar_Item[1].Name = "Power";
                        ar_Item[1].Width = 40;
                        ar_Item[1].Height = 40;
                        ar_Item[1].Top = y;
                        ar_Item[1].Left = x;
                        ar_Item[1].Image = Properties.Resources.PowerBomb;
                        ar_Item[1].BackColor = Color.Transparent;
                        labelMap.Controls.Add(ar_Item[1]);
                        _nNumItem2 = 1;
                        break;
                    }
                    else if (nRandomItem[i] == 2)
                    {
                        ar_Item[1] = new PictureBox();
                        ar_Item[1].Name = "NBBoom";
                        ar_Item[1].Width = 40;
                        ar_Item[1].Height = 40;
                        ar_Item[1].Top = y;
                        ar_Item[1].Left = x;
                        ar_Item[1].Image = Properties.Resources.NumberBomb;
                        ar_Item[1].BackColor = Color.Transparent;
                        labelMap.Controls.Add(ar_Item[1]);
                        _nNumItem2 = 1;
                        break;
                    }
                    else _nNumItem2 = 0;
                }
                #endregion
            }
            for (int i = 0; i < _ar_positionItem.Length; i++)
            {
                for (int j = 0; j < _ar_positionItem[i].Length; j++)
                {
                    _ar_positionItem[i][j] = 0;
                }
            }
        }
        #endregion

        #region AllTimePlayer
        #region Boom
        private void timerBoom_1_Tick(object sender, EventArgs e)
        {
            int nPower = _myPlayer[_nNBPlayer - 1].Power;
            timerBoom_1.Interval = 1500;
            switch (_nBoom_1_Tick)
            {
                case 1:
                    BoomUp1 = new PictureBox[nPower];
                    BoomDown1 = new PictureBox[nPower];
                    BoomLeft1 = new PictureBox[nPower];
                    BoomRigth1 = new PictureBox[nPower];
                    BoomCenter1.Top = _y;
                    BoomCenter1.Left = _x;
                    BoomCenter1.Height = 40;
                    BoomCenter1.Width = 40;
                    BoomCenter1.Image = Properties.Resources.Bomb;
                    BoomCenter1.BackColor = Color.Transparent;
                    labelMap.Controls.Add(BoomCenter1);
                    BoomCenter1.BringToFront();
                    _nBoom_1_Tick = 2;
                    break;
                case 2:
                    _SoundTickBoom.Play();
                    BoomCenter1.Image = Properties.Resources.Bomb;
                    _nBoom_1_Tick = 3;
                    break;
                case 3:
                    BoomCenter1.Image = Properties.Resources.Bomb;

                    Boom(ref nPower, ref BoomUp1, ref BoomDown1, ref BoomLeft1, ref BoomRigth1, ref BoomCenter1);
                    _SoundBoom.Play();
                    Dead(ref nPower, ref BoomUp1, ref BoomDown1, ref BoomLeft1, ref BoomRigth1, ref BoomCenter1, ref timerBoom_1);
                    positionItem();
                    timerBoom_1.Interval = 300;
                    _nBoom_1_Tick = 4;
                    break;
                case 4:
                    labelMap.Controls.Remove(BoomCenter1);
                    for (int i = 0; i < nPower; i++)
                    {
                        labelMap.Controls.Remove(BoomUp1[i]);
                        labelMap.Controls.Remove(BoomDown1[i]);
                        labelMap.Controls.Remove(BoomRigth1[i]);
                        labelMap.Controls.Remove(BoomLeft1[i]);
                    }
                    BoomCenter1.Top = -40;
                    _nBoom_1_Tick = 1;
                    timerBoom_1.Interval = 1;
                    timerBoom_1.Stop();
                    break;
            }
        }
        private void timerBoom_2_Tick(object sender, EventArgs e)
        {
            int nPower = _myPlayer[_nNBPlayer - 1].Power;
            timerBoom_2.Interval = 1500;
            switch (_nBoom_2_Tick)
            {
                case 1:
                    BoomUp2 = new PictureBox[nPower];
                    BoomDown2 = new PictureBox[nPower];
                    BoomLeft2 = new PictureBox[nPower];
                    BoomRigth2 = new PictureBox[nPower];
                    BoomCenter2.Top = _y;
                    BoomCenter2.Left = _x;
                    BoomCenter2.Height = 40;
                    BoomCenter2.Width = 40;
                    BoomCenter2.Image = Properties.Resources.Bomb;
                    BoomCenter2.BackColor = Color.Transparent;
                    labelMap.Controls.Add(BoomCenter2);
                    BoomCenter2.BringToFront();
                    _nBoom_2_Tick = 2;
                    break;
                case 2:
                    _SoundTickBoom.Play();
                    BoomCenter2.Image = Properties.Resources.Bomb;
                    _nBoom_2_Tick = 3;
                    break;
                case 3:
                    BoomCenter2.Image = Properties.Resources.Bomb;

                    Boom(ref nPower, ref BoomUp2, ref BoomDown2, ref BoomLeft2, ref BoomRigth2, ref BoomCenter2);
                    _SoundBoom.Play();
                    Dead(ref nPower, ref BoomUp2, ref BoomDown2, ref BoomLeft2, ref BoomRigth2, ref BoomCenter2, ref timerBoom_2);
                    positionItem();
                    timerBoom_2.Interval = 300;
                    _nBoom_2_Tick = 4;
                    break;
                case 4:
                    labelMap.Controls.Remove(BoomCenter2);
                    for (int i = 0; i < nPower; i++)
                    {
                        labelMap.Controls.Remove(BoomUp2[i]);
                        labelMap.Controls.Remove(BoomDown2[i]);
                        labelMap.Controls.Remove(BoomRigth2[i]);
                        labelMap.Controls.Remove(BoomLeft2[i]);
                    }
                    _nBoom_2_Tick = 1;
                    BoomCenter2.Top = -40;
                    timerBoom_2.Interval = 1;
                    timerBoom_2.Stop();
                    break;
            }
        }
        private void timerBoom_3_Tick(object sender, EventArgs e)
        {
            int nPower = _myPlayer[_nNBPlayer - 1].Power;
            timerBoom_3.Interval = 1500;
            switch (_nBoom_3_Tick)
            {
                case 1:
                    BoomUp3 = new PictureBox[nPower];
                    BoomDown3 = new PictureBox[nPower];
                    BoomLeft3 = new PictureBox[nPower];
                    BoomRigth3 = new PictureBox[nPower];
                    BoomCenter3.Top = _y;
                    BoomCenter3.Left = _x;
                    BoomCenter3.Height = 40;
                    BoomCenter3.Width = 40;
                    BoomCenter3.Image = Properties.Resources.Bomb;
                    BoomCenter3.BackColor = Color.Transparent;
                    labelMap.Controls.Add(BoomCenter3);
                    BoomCenter3.BringToFront();
                    _nBoom_3_Tick = 2;
                    break;
                case 2:
                    _SoundTickBoom.Play();
                    BoomCenter3.Image = Properties.Resources.Bomb;
                    _nBoom_3_Tick = 3;
                    break;
                case 3:
                    BoomCenter3.Image = Properties.Resources.Bomb;

                    Boom(ref nPower, ref BoomUp3, ref BoomDown3, ref BoomLeft3, ref BoomRigth3, ref BoomCenter3);
                    _SoundBoom.Play();
                    Dead(ref nPower, ref BoomUp3, ref BoomDown3, ref BoomLeft3, ref BoomRigth3, ref BoomCenter3, ref timerBoom_3);
                    positionItem();
                    timerBoom_3.Interval = 300;
                    _nBoom_3_Tick = 4;
                    break;
                case 4:
                    labelMap.Controls.Remove(BoomCenter3);
                    for (int i = 0; i < nPower; i++)
                    {
                        labelMap.Controls.Remove(BoomUp3[i]);
                        labelMap.Controls.Remove(BoomDown3[i]);
                        labelMap.Controls.Remove(BoomRigth3[i]);
                        labelMap.Controls.Remove(BoomLeft3[i]);
                    }
                    _nBoom_3_Tick = 1;
                    BoomCenter3.Top = -40;
                    timerBoom_3.Interval = 1;
                    timerBoom_3.Stop();
                    break;
            }
        }
        private void Boom(ref int Power, ref PictureBox[] BoomUp, ref PictureBox[] BoomDown, ref PictureBox[] BoomLeft, ref PictureBox[] BoomRigth, ref PictureBox BoomCenter)
        {
            #region BoomUp
            for (int i = 0; i < Power; i++)
            {
                BoomUp[i] = new PictureBox();
                BoomUp[i].Top = BoomCenter.Top;
                BoomUp[i].Left = BoomCenter.Left;
                BoomUp[i].Height = 40;
                BoomUp[i].Width = 40;
                labelMap.Controls.Add(BoomUp[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomUp[i].Top = BoomCenter.Top - 40 * (i + 1);
                BoomUp[i].Left = BoomCenter.Left;
                BoomUp[i].Image = Properties.Resources.RaCenter2;
                BoomUp[i].BackColor = Color.Transparent;
                BoomUp[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_x1.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x1[j].Location)
                    {
                        BoomUp[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion
                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomUp[j]);
                        BoomUp[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    _ar_positionItem[0][0] = BoomUp[i].Top;
                    _ar_positionItem[0][1] = BoomUp[i].Left;
                    _nScore++;
                    break;
                }
            }
            #endregion
            #region BoomDown
            for (int i = 0; i < Power; i++)
            {
                BoomDown[i] = new PictureBox();
                BoomDown[i].Top = BoomCenter.Top;
                BoomDown[i].Left = BoomCenter.Left;
                BoomDown[i].Height = 40;
                BoomDown[i].Width = 40;
                labelMap.Controls.Add(BoomDown[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomDown[i].Top = BoomCenter.Top + 40 * (i + 1);
                BoomDown[i].Left = BoomCenter.Left;
                BoomDown[i].Image = Properties.Resources.RaCenter2;
                BoomDown[i].BackColor = Color.Transparent;
                BoomDown[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x8.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x8[j].Location)
                    {
                        BoomDown[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion

                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomDown[j]);
                        BoomDown[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    _ar_positionItem[1][0] = BoomDown[i].Top;
                    _ar_positionItem[1][1] = BoomDown[i].Left;
                    _nScore++;
                    break;
                }
                
            }
            
            #endregion
            #region BoomLeft
            for (int i = 0; i < Power; i++)
            {
                BoomLeft[i] = new PictureBox();
                BoomLeft[i].Top = BoomCenter.Top;
                BoomLeft[i].Left = BoomCenter.Left;
                BoomLeft[i].Height = 40;
                BoomLeft[i].Width = 40;
                labelMap.Controls.Add(BoomLeft[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomLeft[i].Top = BoomCenter.Top;
                BoomLeft[i].Left = BoomCenter.Left - 40 * (i + 1);
                BoomLeft[i].Image = Properties.Resources.RaCenter;
                BoomLeft[i].BackColor = Color.Transparent;
                BoomLeft[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_y1.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_y1[j].Location)
                    {
                        BoomLeft[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion

                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomLeft[j]);
                        BoomLeft[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    _ar_positionItem[2][0] = BoomLeft[i].Top;
                    _ar_positionItem[2][1] = BoomLeft[i].Left;
                    _nScore++;
                    break;
                }

            }

            #endregion
            #region BoomRigth
            for (int i = 0; i < Power; i++)
            {
                BoomRigth[i] = new PictureBox();
                BoomRigth[i].Top = BoomCenter.Top;
                BoomRigth[i].Left = BoomCenter.Left;
                BoomRigth[i].Height = 40;
                BoomRigth[i].Width = 40;
                labelMap.Controls.Add(BoomRigth[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomRigth[i].Top = BoomCenter.Top;
                BoomRigth[i].Left = BoomCenter.Left + 40 * (i + 1);
                BoomRigth[i].Image = Properties.Resources.RaCenter;
                BoomRigth[i].BackColor = Color.Transparent;
                BoomRigth[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_y8.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_y8[j].Location)
                    {
                        BoomRigth[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion

                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomRigth[j]);
                        BoomRigth[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    _ar_positionItem[3][0] = BoomRigth[i].Top;
                    _ar_positionItem[3][1] = BoomRigth[i].Left;
                    _nScore++;
                    break;
                }
            }
            #endregion
        }
        private void Dead(ref int Power, ref PictureBox[] BoomUp, ref PictureBox[] BoomDown, ref PictureBox[] BoomLeft, ref PictureBox[] BoomRigth, ref PictureBox BoomCenter, ref Timer TimeBoomIndex)
        {
            #region DeadCenter
            if (BoomCenter.Location == picturePlayer1.Location)
            {
                Dead(ref picturePlayer1);
            }
            if (BoomCenter.Location == pictureAi1.Location)
            {
                Dead(ref pictureAi1);
            }
            #endregion
            #region DeadUp
            for (int i = 0; i < Power; i++)
            {
                #region Player
                if (BoomUp[i].Top < picturePlayer1.Bottom && BoomUp[i].Right == picturePlayer1.Right && BoomUp[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomUp[i].Bottom > picturePlayer1.Top && BoomUp[i].Right == picturePlayer1.Right && BoomUp[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomUp[i].Right > picturePlayer1.Left && BoomUp[i].Top == picturePlayer1.Top && BoomUp[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomUp[i].Left < picturePlayer1.Right && BoomUp[i].Top == picturePlayer1.Top && BoomUp[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                #endregion
                #region AI1
                ///////////////////////////////////////////////
                if (BoomUp[i].Top < pictureAi1.Bottom && BoomUp[i].Right == pictureAi1.Right && BoomUp[i].Bottom >= pictureAi1.Bottom)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomUp[i].Bottom > pictureAi1.Top && BoomUp[i].Right == pictureAi1.Right && BoomUp[i].Top <= pictureAi1.Top)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomUp[i].Right > pictureAi1.Left && BoomUp[i].Top == pictureAi1.Top && BoomUp[i].Right <= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomUp[i].Left < pictureAi1.Right && BoomUp[i].Top == pictureAi1.Top && BoomUp[i].Right >= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                #endregion
            }
            #endregion
            #region DeadDown
            for (int i = 0; i < Power; i++)
            {
                #region Player
                if (BoomDown[i].Top < picturePlayer1.Bottom && BoomDown[i].Right == picturePlayer1.Right && BoomDown[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomDown[i].Bottom > picturePlayer1.Top && BoomDown[i].Right == picturePlayer1.Right && BoomDown[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomDown[i].Right > picturePlayer1.Left && BoomDown[i].Top == picturePlayer1.Top && BoomDown[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomDown[i].Left < picturePlayer1.Right && BoomDown[i].Top == picturePlayer1.Top && BoomDown[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                #endregion
                #region AI1
                if (BoomDown[i].Top < pictureAi1.Bottom && BoomDown[i].Right == pictureAi1.Right && BoomDown[i].Bottom >= pictureAi1.Bottom)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomDown[i].Bottom > pictureAi1.Top && BoomDown[i].Right == pictureAi1.Right && BoomDown[i].Top <= pictureAi1.Top)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomDown[i].Right > pictureAi1.Left && BoomDown[i].Top == pictureAi1.Top && BoomDown[i].Right <= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomDown[i].Left < pictureAi1.Right && BoomDown[i].Top == pictureAi1.Top && BoomDown[i].Right >= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                #endregion
            }
            #endregion
            #region DeadLeft
            for (int i = 0; i < Power; i++)
            {
                #region Player
                if (BoomLeft[i].Top < picturePlayer1.Bottom && BoomLeft[i].Right == picturePlayer1.Right && BoomLeft[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomLeft[i].Bottom > picturePlayer1.Top && BoomLeft[i].Right == picturePlayer1.Right && BoomLeft[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomLeft[i].Right > picturePlayer1.Left && BoomLeft[i].Top == picturePlayer1.Top && BoomLeft[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomLeft[i].Left < picturePlayer1.Right && BoomLeft[i].Top == picturePlayer1.Top && BoomLeft[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                #endregion
                #region AI1
                if (BoomLeft[i].Top < pictureAi1.Bottom && BoomLeft[i].Right == pictureAi1.Right && BoomLeft[i].Bottom >= pictureAi1.Bottom)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomLeft[i].Bottom > pictureAi1.Top && BoomLeft[i].Right == pictureAi1.Right && BoomLeft[i].Top <= pictureAi1.Top)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomLeft[i].Right > pictureAi1.Left && BoomLeft[i].Top == pictureAi1.Top && BoomLeft[i].Right <= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomLeft[i].Left < pictureAi1.Right && BoomLeft[i].Top == pictureAi1.Top && BoomLeft[i].Right >= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                #endregion
            }
            #endregion
            #region DeadRight
            for (int i = 0; i < Power; i++)
            {
                #region Player
                if (BoomRigth[i].Top < picturePlayer1.Bottom && BoomRigth[i].Right == picturePlayer1.Right && BoomRigth[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomRigth[i].Bottom > picturePlayer1.Top && BoomRigth[i].Right == picturePlayer1.Right && BoomRigth[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomRigth[i].Right > picturePlayer1.Left && BoomRigth[i].Top == picturePlayer1.Top && BoomRigth[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomRigth[i].Left < picturePlayer1.Right && BoomRigth[i].Top == picturePlayer1.Top && BoomRigth[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                #endregion
                #region AI1
                if (BoomRigth[i].Top < pictureAi1.Bottom && BoomRigth[i].Right == pictureAi1.Right && BoomRigth[i].Bottom >= pictureAi1.Bottom)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomRigth[i].Bottom > pictureAi1.Top && BoomRigth[i].Right == pictureAi1.Right && BoomRigth[i].Top <= pictureAi1.Top)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomRigth[i].Right > pictureAi1.Left && BoomRigth[i].Top == pictureAi1.Top && BoomRigth[i].Right <= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                if (BoomRigth[i].Left < pictureAi1.Right && BoomRigth[i].Top == pictureAi1.Top && BoomRigth[i].Right >= pictureAi1.Right)
                {
                    Dead(ref pictureAi1);
                    break;
                }
                #endregion
            }
            #endregion
        }
        #endregion
        private void timerWalk_Tick(object sender, EventArgs e)
        {
            if (_sFacing == "Up")
            {
                switch (_nFacing)
                {
                    case 1:
                        picturePlayer1.Image = Properties.Resources.robotB01;
                        _nFacing = 2;
                        break;
                    case 2:
                        picturePlayer1.Image = Properties.Resources.robotB01;
                        _nFacing = 3;
                        break;
                    case 3:
                        picturePlayer1.Image = Properties.Resources.robotB01;
                        _nFacing = 1;
                        break;
                }
            }
            else if (_sFacing == "Down")
            {
                switch (_nFacing)
                {
                    case 1:
                        picturePlayer1.Image = Properties.Resources.robot01;
                        _nFacing = 2;
                        break;
                    case 2:
                        picturePlayer1.Image = Properties.Resources.robot01;
                        _nFacing = 3;
                        break;
                    case 3:
                        picturePlayer1.Image = Properties.Resources.robot01;
                        _nFacing = 1;
                        break;
                }
            }
            else if (_sFacing == "Left")
            {
                switch (_nFacing)
                {
                    case 1:
                        picturePlayer1.Image = Properties.Resources.robotL01;
                        _nFacing = 2;
                        break;
                    case 2:
                        picturePlayer1.Image = Properties.Resources.robotL01;
                        _nFacing = 3;
                        break;
                    case 3:
                        picturePlayer1.Image = Properties.Resources.robotL01;
                        _nFacing = 1;
                        break;
                }
            }
            else if (_sFacing == "Right")
            {
                switch (_nFacing)
                {
                    case 1:
                        picturePlayer1.Image = Properties.Resources.robotR01;
                        _nFacing = 2;
                        break;
                    case 2:
                        picturePlayer1.Image = Properties.Resources.robotR01;
                        _nFacing = 3;
                        break;
                    case 3:
                        picturePlayer1.Image = Properties.Resources.robotR01;
                        _nFacing = 1;
                        break;
                }
            }
        }
        #endregion
        #endregion
        
        #region MyAI1
        private void timerAI1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < _myAi.Length; i++)
            {
                _myAi[i] = new Bomber();
            }
            _myAi[0].Power = 4;
            _myAi[0].Speed = 2;
            _myAi[0].NumberBoom = 1;
            labelPlayer2.Text = _myAi[0].ToString();
            AI_AnimationMove(ref pictureAi1);
        }
        private void AI_AnimationMove(ref PictureBox AI)
        {
            switch (_sFacing_AI)
            {
                case "Up":
                    switch (_nFacing_AI)
                    {
                        case 1:
                            AI.Image = Properties.Resources.DarkB02;
                            _nFacing_AI = 2;
                            AI_CheckMove(ref AI, "Up");
                            break;
                        case 2:
                            AI.Image = Properties.Resources.DarkB03;
                            _nFacing_AI = 3;
                            AI_CheckMove(ref AI, "Up");
                            break;
                        case 3:
                            AI.Image = Properties.Resources.DarkB02;
                            _nFacing_AI = 1;
                            AI_CheckMove(ref AI, "Up");
                            break;
                    }
                    break;
                case "Down":
                    switch (_nFacing_AI)
                    {
                        case 1:
                            AI.Image = Properties.Resources.Dark02;
                            _nFacing_AI = 2;
                            AI_CheckMove(ref AI, "Down");
                            break;
                        case 2:
                            AI.Image = Properties.Resources.Dark03;
                            _nFacing_AI = 3;
                            AI_CheckMove(ref AI, "Down");
                            break;
                        case 3:
                            AI.Image = Properties.Resources.Dark02;
                            _nFacing_AI = 1;
                            AI_CheckMove(ref AI, "Down");
                            break;
                    }
                    break;
                case "Left":
                    switch (_nFacing_AI)
                    {
                        case 1:
                            AI.Image = Properties.Resources.DarkL02;
                            _nFacing_AI = 2;
                            AI_CheckMove(ref AI, "Left");
                            break;
                        case 2:
                            AI.Image = Properties.Resources.DarkL03;
                            _nFacing_AI = 3;
                            AI_CheckMove(ref AI, "Left");
                            break;
                        case 3:
                            AI.Image = Properties.Resources.DarkL02;
                            _nFacing_AI = 1;
                            AI_CheckMove(ref AI, "Left");
                            break;
                    }
                    break;
                case "Right":
                    switch (_nFacing_AI)
                    {
                        case 1:
                            AI.Image = Properties.Resources.DarkR02;
                            _nFacing_AI = 2;
                            AI_CheckMove(ref AI, "Right");
                            break;
                        case 2:
                            AI.Image = Properties.Resources.DarkR03;
                            _nFacing_AI = 3;
                            AI_CheckMove(ref AI, "Right");
                            break;
                        case 3:
                            AI.Image = Properties.Resources.DarkR02;
                            _nFacing_AI = 1;
                            AI_CheckMove(ref AI, "Right");
                            break;
                    }
                    break;
            }
        }

        #region AllTimeAI1Boom
        private void timerBoomAI1_Tick(object sender, EventArgs e)
        {
            int nPower = _myAi[0].Power;
            timerBoomAI1_1.Interval = 1500;
            switch (ai1_nBoom_1_Tick)
            {
                case 1:
                    _SoundSetBoom.Play();
                    ai1_BoomUp1 = new PictureBox[nPower];
                    ai1_BoomDown1 = new PictureBox[nPower];
                    ai1_BoomLeft1 = new PictureBox[nPower];
                    ai1_BoomRigth1 = new PictureBox[nPower];
                    ai1_BoomCenter1.Top = _yAI1;
                    ai1_BoomCenter1.Left = _xAI1;
                    ai1_BoomCenter1.Height = 40;
                    ai1_BoomCenter1.Width = 40;
                    ai1_BoomCenter1.Image = Properties.Resources.Bomb;
                    ai1_BoomCenter1.BackColor = Color.Transparent;
                    labelMap.Controls.Add(ai1_BoomCenter1);
                    ai1_BoomCenter1.BringToFront();
                    ai1_nBoom_1_Tick = 2;
                    break;
                case 2:
                    _SoundTickBoom.Play();
                    ai1_BoomCenter1.Image = Properties.Resources.Bomb;
                    ai1_nBoom_1_Tick = 3;
                    break;
                case 3:
                    ai1_BoomCenter1.Image = Properties.Resources.Bomb;

                    AI1_Boom(ref nPower, ref ai1_BoomUp1, ref ai1_BoomDown1, ref ai1_BoomLeft1, ref ai1_BoomRigth1, ref ai1_BoomCenter1);
                    _SoundBoom.Play();
                    AI1_Dead(ref nPower, ref ai1_BoomUp1, ref ai1_BoomDown1, ref ai1_BoomLeft1, ref ai1_BoomRigth1, ref ai1_BoomCenter1, ref timerBoomAI1_1);
                    timerBoomAI1_1.Interval = 300;
                    ai1_nBoom_1_Tick = 4;
                    break;
                case 4:
                    labelMap.Controls.Remove(ai1_BoomCenter1);
                    for (int i = 0; i < nPower; i++)
                    {
                        labelMap.Controls.Remove(ai1_BoomUp1[i]);
                        labelMap.Controls.Remove(ai1_BoomDown1[i]);
                        labelMap.Controls.Remove(ai1_BoomRigth1[i]);
                        labelMap.Controls.Remove(ai1_BoomLeft1[i]);
                    }
                    ai1_nBoom_1_Tick = 1;
                    ai1_BoomCenter1.Top = -40;
                    timerBoomAI1_1.Interval = 1;
                    timerBoomAI1_1.Stop();
                    break;
            }
        }
        private void timerBoomAI2_Tick(object sender, EventArgs e)
        {
            int nPower = _myAi[0].Power;
            timerBoomAI1_2.Interval = 1500;
            switch (ai1_nBoom_2_Tick)
            {
                case 1:
                    _SoundSetBoom.Play();
                    ai1_BoomUp2 = new PictureBox[nPower];
                    ai1_BoomDown2 = new PictureBox[nPower];
                    ai1_BoomLeft2 = new PictureBox[nPower];
                    ai1_BoomRigth2 = new PictureBox[nPower];
                    ai1_BoomCenter2.Top = _yAI1;
                    ai1_BoomCenter2.Left = _xAI1;
                    ai1_BoomCenter2.Height = 40;
                    ai1_BoomCenter2.Width = 40;
                    ai1_BoomCenter2.Image = Properties.Resources.Bomb;
                    ai1_BoomCenter2.BackColor = Color.Transparent;
                    labelMap.Controls.Add(ai1_BoomCenter2);
                    ai1_BoomCenter2.BringToFront();
                    ai1_nBoom_2_Tick = 2;
                    break;
                case 2:
                    _SoundTickBoom.Play();
                    ai1_BoomCenter2.Image = Properties.Resources.Bomb;
                    ai1_nBoom_2_Tick = 3;
                    break;
                case 3:
                    ai1_BoomCenter2.Image = Properties.Resources.Bomb;

                    AI1_Boom(ref nPower, ref ai1_BoomUp2, ref ai1_BoomDown2, ref ai1_BoomLeft2, ref ai1_BoomRigth2, ref ai1_BoomCenter2);
                    _SoundBoom.Play();
                    AI1_Dead(ref nPower, ref ai1_BoomUp2, ref ai1_BoomDown2, ref ai1_BoomLeft2, ref ai1_BoomRigth2, ref ai1_BoomCenter2, ref timerBoomAI1_2);
                    timerBoomAI1_2.Interval = 300;
                    ai1_nBoom_2_Tick = 4;
                    break;
                case 4:
                    labelMap.Controls.Remove(ai1_BoomCenter2);
                    for (int i = 0; i < nPower; i++)
                    {
                        labelMap.Controls.Remove(ai1_BoomUp2[i]);
                        labelMap.Controls.Remove(ai1_BoomDown2[i]);
                        labelMap.Controls.Remove(ai1_BoomRigth2[i]);
                        labelMap.Controls.Remove(ai1_BoomLeft2[i]);
                    }
                    ai1_nBoom_2_Tick = 1;
                    ai1_BoomCenter2.Top = -40;
                    timerBoomAI1_2.Interval = 1;
                    timerBoomAI1_2.Stop();
                    break;
            }
        }
        private void AI1_Boom(ref int Power, ref PictureBox[] BoomUp, ref PictureBox[] BoomDown, ref PictureBox[] BoomLeft, ref PictureBox[] BoomRigth, ref PictureBox BoomCenter)
        {
            #region BoomUp
            for (int i = 0; i < Power; i++)
            {
                BoomUp[i] = new PictureBox();
                BoomUp[i].Top = BoomCenter.Top;
                BoomUp[i].Left = BoomCenter.Left;
                BoomUp[i].Height = 40;
                BoomUp[i].Width = 40;
                labelMap.Controls.Add(BoomUp[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomUp[i].Top = BoomCenter.Top - 40 * (i + 1);
                BoomUp[i].Left = BoomCenter.Left;
                BoomUp[i].Image = Properties.Resources.RaCenter2Dark;
                BoomUp[i].BackColor = Color.Transparent;
                BoomUp[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_x1.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x1[j].Location)
                    {
                        BoomUp[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomUp[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion
                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomUp[j]);
                        BoomUp[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    break;
                }
            }
            #endregion
            #region BoomDown
            for (int i = 0; i < Power; i++)
            {
                BoomDown[i] = new PictureBox();
                BoomDown[i].Top = BoomCenter.Top;
                BoomDown[i].Left = BoomCenter.Left;
                BoomDown[i].Height = 40;
                BoomDown[i].Width = 40;
                labelMap.Controls.Add(BoomDown[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomDown[i].Top = BoomCenter.Top + 40 * (i + 1);
                BoomDown[i].Left = BoomCenter.Left;
                BoomDown[i].Image = Properties.Resources.RaCenter2Dark;
                BoomDown[i].BackColor = Color.Transparent;
                BoomDown[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x8.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Wall_x8[j].Location)
                    {
                        BoomDown[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomDown[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion

                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomDown[j]);
                        BoomDown[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    break;
                }
            }
            #endregion
            #region BoomLeft
            for (int i = 0; i < Power; i++)
            {
                BoomLeft[i] = new PictureBox();
                BoomLeft[i].Top = BoomCenter.Top;
                BoomLeft[i].Left = BoomCenter.Left;
                BoomLeft[i].Height = 40;
                BoomLeft[i].Width = 40;
                labelMap.Controls.Add(BoomLeft[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomLeft[i].Top = BoomCenter.Top;
                BoomLeft[i].Left = BoomCenter.Left - 40 * (i + 1);
                BoomLeft[i].Image = Properties.Resources.RaCenterDark;
                BoomLeft[i].BackColor = Color.Transparent;
                BoomLeft[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_y1.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_y1[j].Location)
                    {
                        BoomLeft[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomLeft[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion

                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomLeft[j]);
                        BoomLeft[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    break;
                }

            }

            #endregion
            #region BoomRigth
            for (int i = 0; i < Power; i++)
            {
                BoomRigth[i] = new PictureBox();
                BoomRigth[i].Top = BoomCenter.Top;
                BoomRigth[i].Left = BoomCenter.Left;
                BoomRigth[i].Height = 40;
                BoomRigth[i].Width = 40;
                labelMap.Controls.Add(BoomRigth[i]);
            }
            for (int i = 0; i < Power; i++)
            {
                string sStopBoom = "";
                BoomRigth[i].Top = BoomCenter.Top;
                BoomRigth[i].Left = BoomCenter.Left + 40 * (i + 1);
                BoomRigth[i].Image = Properties.Resources.RaCenterDark;
                BoomRigth[i].BackColor = Color.Transparent;
                BoomRigth[i].BringToFront();
                #region Wall
                for (int j = 0; j < ar_Wall_y8.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_y8[j].Location)
                    {
                        BoomRigth[i].SendToBack();
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x2.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x2[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x3.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x3[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x4.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x4[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x5.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x5[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x6.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x6[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                for (int j = 0; j < ar_Wall_x7.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Wall_x7[j].Location)
                    {
                        sStopBoom = "wall";
                        break;
                    }
                }
                #endregion
                #region Box
                for (int j = 0; j < ar_Box_x1.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x1[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x1[j]);
                        ar_Box_x1[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x2.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x2[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x2[j]);
                        ar_Box_x2[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x3.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x3[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x3[j]);
                        ar_Box_x3[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x4.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x4[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x4[j]);
                        ar_Box_x4[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x5.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x5[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x5[j]);
                        ar_Box_x5[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x6.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x6[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x6[j]);
                        ar_Box_x6[j].Top = 0;
                    }
                }
                for (int j = 0; j < ar_Box_x7.Length; j++)
                {
                    if (BoomRigth[i].Location == ar_Box_x7[j].Location)
                    {
                        sStopBoom = "box";
                        labelMap.Controls.Remove(ar_Box_x7[j]);
                        ar_Box_x7[j].Top = 0;
                    }
                }
                #endregion

                if (sStopBoom == "wall")
                {
                    for (int j = i; j < Power; j++)
                    {
                        labelMap.Controls.Remove(BoomRigth[j]);
                        BoomRigth[j].Top = 0;
                    }
                    break;
                }
                if (sStopBoom == "box")
                {
                    break;
                }
            }
            #endregion
        }

        private void labelPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void AI1_Dead(ref int Power, ref PictureBox[] BoomUp, ref PictureBox[] BoomDown, ref PictureBox[] BoomLeft, ref PictureBox[] BoomRigth, ref PictureBox BoomCenter, ref Timer TimeBoomIndex)
        {
            #region DeadCenter
            if (BoomCenter.Location == picturePlayer1.Location)
            {
                Dead(ref picturePlayer1);
            }
            #endregion
            #region DeadUp
            for (int i = 0; i < Power; i++)
            {
                if (BoomUp[i].Top < picturePlayer1.Bottom && BoomUp[i].Right == picturePlayer1.Right && BoomUp[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomUp[i].Bottom > picturePlayer1.Top && BoomUp[i].Right == picturePlayer1.Right && BoomUp[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomUp[i].Right > picturePlayer1.Left && BoomUp[i].Top == picturePlayer1.Top && BoomUp[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomUp[i].Left < picturePlayer1.Right && BoomUp[i].Top == picturePlayer1.Top && BoomUp[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
            }
            #endregion
            #region DeadDown
            for (int i = 0; i < Power; i++)
            {
                if (BoomDown[i].Top < picturePlayer1.Bottom && BoomDown[i].Right == picturePlayer1.Right && BoomDown[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomDown[i].Bottom > picturePlayer1.Top && BoomDown[i].Right == picturePlayer1.Right && BoomDown[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomDown[i].Right > picturePlayer1.Left && BoomDown[i].Top == picturePlayer1.Top && BoomDown[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomDown[i].Left < picturePlayer1.Right && BoomDown[i].Top == picturePlayer1.Top && BoomDown[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
            }
            #endregion
            #region DeadLeft
            for (int i = 0; i < Power; i++)
            {
                if (BoomLeft[i].Top < picturePlayer1.Bottom && BoomLeft[i].Right == picturePlayer1.Right && BoomLeft[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomLeft[i].Bottom > picturePlayer1.Top && BoomLeft[i].Right == picturePlayer1.Right && BoomLeft[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomLeft[i].Right > picturePlayer1.Left && BoomLeft[i].Top == picturePlayer1.Top && BoomLeft[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomLeft[i].Left < picturePlayer1.Right && BoomLeft[i].Top == picturePlayer1.Top && BoomLeft[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
            }
            #endregion
            #region DeadRight
            for (int i = 0; i < Power; i++)
            {
                if (BoomRigth[i].Top < picturePlayer1.Bottom && BoomRigth[i].Right == picturePlayer1.Right && BoomRigth[i].Bottom >= picturePlayer1.Bottom)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomRigth[i].Bottom > picturePlayer1.Top && BoomRigth[i].Right == picturePlayer1.Right && BoomRigth[i].Top <= picturePlayer1.Top)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomRigth[i].Right > picturePlayer1.Left && BoomRigth[i].Top == picturePlayer1.Top && BoomRigth[i].Right <= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
                if (BoomRigth[i].Left < picturePlayer1.Right && BoomRigth[i].Top == picturePlayer1.Top && BoomRigth[i].Right >= picturePlayer1.Right)
                {
                    Dead(ref picturePlayer1);
                    break;
                }
            }
            #endregion
        }
        #endregion

        private void AI_CheckMove(ref PictureBox AI, string sFacing)
        {
            if (pictureAi1.Location == picturePlayer1.Location) AI_SetBoom(AI.Left, AI.Top);
            #region Up
            if (_sFacing_AI == "Up")
            {
                if (AI.Right % 40 != 0) return;
                #region Wall
                for (int i = 0; i < ar_Wall_x1.Length; i++)
                {
                    if (AI.Top == ar_Wall_x1[i].Bottom)
                    {
                        AI_RandomMove();
                        return;
                    }
                }
                for (int i = 0; i < ar_Wall_x2.Length; i++)
                {
                    if (AI.Top == ar_Wall_x2[i].Bottom && AI.Right > ar_Wall_x2[i].Left && AI.Right <= ar_Wall_x2[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Top == ar_Wall_x2[i].Bottom && AI.Left > ar_Wall_x2[i].Left && AI.Right > ar_Wall_x2[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x3.Length; i++)
                {
                    if (AI.Top == ar_Wall_x3[i].Bottom && AI.Right > ar_Wall_x3[i].Left && AI.Right <= ar_Wall_x3[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Top == ar_Wall_x3[i].Bottom && AI.Left > ar_Wall_x3[i].Left && AI.Right > ar_Wall_x3[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x4.Length; i++)
                {
                    if (AI.Top == ar_Wall_x4[i].Bottom && AI.Right > ar_Wall_x4[i].Left && AI.Right <= ar_Wall_x4[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Top == ar_Wall_x4[i].Bottom && AI.Left > ar_Wall_x4[i].Left && AI.Right > ar_Wall_x4[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x5.Length; i++)
                {
                    if (AI.Top == ar_Wall_x5[i].Bottom && AI.Right > ar_Wall_x5[i].Left && AI.Right <= ar_Wall_x5[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Top == ar_Wall_x5[i].Bottom && AI.Left > ar_Wall_x5[i].Left && AI.Right > ar_Wall_x5[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x6.Length; i++)
                {
                    if (AI.Top == ar_Wall_x6[i].Bottom && AI.Right > ar_Wall_x6[i].Left && AI.Right <= ar_Wall_x6[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Top == ar_Wall_x6[i].Bottom && AI.Left > ar_Wall_x6[i].Left && AI.Right > ar_Wall_x6[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x7.Length; i++)
                {
                    if (AI.Top == ar_Wall_x7[i].Bottom && AI.Right > ar_Wall_x7[i].Left && AI.Right <= ar_Wall_x7[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Top == ar_Wall_x7[i].Bottom && AI.Left > ar_Wall_x7[i].Left && AI.Right > ar_Wall_x7[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                #endregion
                #region Box
                for (int i = 0; i < ar_Box_x1.Length; i++)
                {
                    if (AI.Top == ar_Box_x1[i].Bottom && AI.Right > ar_Box_x1[i].Left && AI.Right <= ar_Box_x1[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                    if (AI.Top == ar_Box_x1[i].Bottom && AI.Left > ar_Box_x1[i].Left && AI.Right > ar_Box_x1[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x2.Length; i++)
                {
                    if (AI.Top == ar_Box_x2[i].Bottom && AI.Right > ar_Box_x2[i].Left && AI.Right <= ar_Box_x2[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                    if (AI.Top == ar_Box_x2[i].Bottom && AI.Left > ar_Box_x2[i].Left && AI.Right > ar_Box_x2[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x3.Length; i++)
                {
                    if (AI.Top == ar_Box_x3[i].Bottom && AI.Right > ar_Box_x3[i].Left && AI.Right <= ar_Box_x3[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                    if (AI.Top == ar_Box_x3[i].Bottom && AI.Left > ar_Box_x3[i].Left && AI.Right > ar_Box_x3[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x4.Length; i++)
                {
                    if (AI.Top == ar_Box_x4[i].Bottom && AI.Right > ar_Box_x4[i].Left && AI.Right <= ar_Box_x4[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                    if (AI.Top == ar_Box_x4[i].Bottom && AI.Left > ar_Box_x4[i].Left && AI.Right > ar_Box_x4[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x5.Length; i++)
                {
                    if (AI.Top == ar_Box_x5[i].Bottom && AI.Right > ar_Box_x5[i].Left && AI.Right <= ar_Box_x5[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                    if (AI.Top == ar_Box_x5[i].Bottom && AI.Left > ar_Box_x5[i].Left && AI.Right > ar_Box_x5[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x6.Length; i++)
                {
                    if (AI.Top == ar_Box_x6[i].Bottom && AI.Right > ar_Box_x6[i].Left && AI.Right <= ar_Box_x6[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                    if (AI.Top == ar_Box_x6[i].Bottom && AI.Left > ar_Box_x6[i].Left && AI.Right > ar_Box_x6[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                #endregion
                AI.Top -= 2 * _myAi[0].Speed;
            }
            #endregion
            #region Down
            if (_sFacing_AI == "Down")
            {
                if (AI.Right % 40 != 0) return;
                #region Wall
                for (int i = 0; i < ar_Wall_x2.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x2[i].Top && AI.Right > ar_Wall_x2[i].Left && AI.Right <= ar_Wall_x2[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Bottom == ar_Wall_x2[i].Top && AI.Left > ar_Wall_x2[i].Left && AI.Right > ar_Wall_x2[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x3.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x3[i].Top && AI.Right > ar_Wall_x3[i].Left && AI.Right <= ar_Wall_x3[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Bottom == ar_Wall_x3[i].Top && AI.Left > ar_Wall_x3[i].Left && AI.Right > ar_Wall_x3[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x4.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x4[i].Top && AI.Right > ar_Wall_x4[i].Left && AI.Right <= ar_Wall_x4[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Bottom == ar_Wall_x4[i].Top && AI.Left > ar_Wall_x4[i].Left && AI.Right > ar_Wall_x4[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x5.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x5[i].Top && AI.Right > ar_Wall_x5[i].Left && AI.Right <= ar_Wall_x5[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Bottom == ar_Wall_x5[i].Top && AI.Left > ar_Wall_x5[i].Left && AI.Right > ar_Wall_x5[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x6.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x6[i].Top && AI.Right > ar_Wall_x6[i].Left && AI.Right <= ar_Wall_x6[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Bottom == ar_Wall_x6[i].Top && AI.Left > ar_Wall_x6[i].Left && AI.Right > ar_Wall_x6[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x7.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x7[i].Top && AI.Right > ar_Wall_x7[i].Left && AI.Right <= ar_Wall_x7[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                    if (AI.Bottom == ar_Wall_x7[i].Top && AI.Left > ar_Wall_x7[i].Left && AI.Right > ar_Wall_x7[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x8.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x8[i].Top)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                #endregion
                #region Box
                for (int i = 0; i < ar_Box_x2.Length; i++)
                {
                    if (AI.Bottom == ar_Box_x2[i].Top && AI.Right > ar_Box_x2[i].Left && AI.Right <= ar_Box_x2[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                    if (AI.Bottom == ar_Box_x2[i].Top && AI.Left > ar_Box_x2[i].Left && AI.Right > ar_Box_x2[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x3.Length; i++)
                {
                    if (AI.Bottom == ar_Box_x3[i].Top && AI.Right > ar_Box_x3[i].Left && AI.Right <= ar_Box_x3[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                    if (AI.Bottom == ar_Box_x3[i].Top && AI.Left > ar_Box_x3[i].Left && AI.Right > ar_Box_x3[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }

                for (int i = 0; i < ar_Box_x4.Length; i++)
                {
                    if (AI.Bottom == ar_Box_x4[i].Top && AI.Right > ar_Box_x4[i].Left && AI.Right <= ar_Box_x4[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                    if (AI.Bottom == ar_Box_x4[i].Top && AI.Left > ar_Box_x4[i].Left && AI.Right > ar_Box_x4[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }

                for (int i = 0; i < ar_Box_x5.Length; i++)
                {
                    if (AI.Bottom == ar_Box_x5[i].Top && AI.Right > ar_Box_x5[i].Left && AI.Right <= ar_Box_x5[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                    if (AI.Bottom == ar_Box_x5[i].Top && AI.Left > ar_Box_x5[i].Left && AI.Right > ar_Box_x5[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }

                for (int i = 0; i < ar_Box_x6.Length; i++)
                {
                    if (AI.Bottom == ar_Box_x6[i].Top && AI.Right > ar_Box_x6[i].Left && AI.Right <= ar_Box_x6[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                    if (AI.Bottom == ar_Box_x6[i].Top && AI.Left > ar_Box_x6[i].Left && AI.Right > ar_Box_x6[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }

                for (int i = 0; i < ar_Box_x7.Length; i++)
                {
                    if (AI.Bottom == ar_Box_x7[i].Top && AI.Right > ar_Box_x7[i].Left && AI.Right <= ar_Box_x7[i].Right)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                    if (AI.Bottom == ar_Box_x7[i].Top && AI.Left > ar_Box_x7[i].Left && AI.Right > ar_Box_x7[i].Right && AI.Right % 40 != 0)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                #endregion
                AI.Top += 2 * _myAi[0].Speed;
            }
            #endregion
            #region Left
            if (_sFacing_AI == "Left")
            {
                if (AI.Top % 40 != 0) return;
                #region Wall
                for (int i = 0; i < ar_Wall_y1.Length; i++)
                {
                    if (AI.Left == ar_Wall_y1[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x2.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x2[i].Bottom && AI.Left == ar_Wall_x2[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x3.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x3[i].Bottom && AI.Left == ar_Wall_x3[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x4.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x4[i].Bottom && AI.Left == ar_Wall_x4[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x5.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x5[i].Bottom && AI.Left == ar_Wall_x5[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x6.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x6[i].Bottom && AI.Left == ar_Wall_x6[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x7.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x7[i].Bottom && AI.Left == ar_Wall_x7[i].Right)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                #endregion
                #region Box
                for (int i = 0; i < ar_Box_x1.Length; i++)
                {
                    if (AI.Left == ar_Box_x1[i].Right && AI.Bottom == ar_Box_x1[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x2.Length; i++)
                {
                    if (AI.Left == ar_Box_x2[i].Right && AI.Bottom == ar_Box_x2[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x3.Length; i++)
                {
                    if (AI.Left == ar_Box_x3[i].Right && AI.Bottom == ar_Box_x3[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x4.Length; i++)
                {
                    if (AI.Left == ar_Box_x4[i].Right && AI.Bottom == ar_Box_x4[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x5.Length; i++)
                {
                    if (AI.Left == ar_Box_x5[i].Right && AI.Bottom == ar_Box_x5[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x6.Length; i++)
                {
                    if (AI.Left == ar_Box_x6[i].Right && AI.Bottom == ar_Box_x6[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x7.Length; i++)
                {
                    if (AI.Left == ar_Box_x7[i].Right && AI.Bottom == ar_Box_x7[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                #endregion
                AI.Left -= 2 * _myAi[0].Speed;
            }
            #endregion
            #region Right
            if (_sFacing_AI == "Right")
            {
                if (AI.Top % 40 != 0) return;
                #region Wall
                for (int i = 0; i < ar_Wall_y8.Length; i++)
                {
                    if (AI.Right == ar_Wall_y8[i].Left)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x2.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x2[i].Bottom && AI.Right == ar_Wall_x2[i].Left)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x3.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x3[i].Bottom && AI.Right == ar_Wall_x3[i].Left)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x4.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x4[i].Bottom && AI.Right == ar_Wall_x4[i].Left)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x5.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x5[i].Bottom && AI.Right == ar_Wall_x5[i].Left)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x6.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x6[i].Bottom && AI.Right == ar_Wall_x6[i].Left)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                for (int i = 0; i < ar_Wall_x7.Length; i++)
                {
                    if (AI.Bottom == ar_Wall_x7[i].Bottom && AI.Right == ar_Wall_x7[i].Left)
                    {
                        AI_RandomMove();
                        return;

                    }
                }
                #endregion
                #region Box
                for (int i = 0; i < ar_Box_x1.Length; i++)
                {
                    if (AI.Right == ar_Box_x1[i].Left && AI.Bottom == ar_Box_x1[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x2.Length; i++)
                {
                    if (AI.Right == ar_Box_x2[i].Left && AI.Bottom == ar_Box_x2[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x3.Length; i++)
                {
                    if (AI.Right == ar_Box_x3[i].Left && AI.Bottom == ar_Box_x3[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x4.Length; i++)
                {
                    if (AI.Right == ar_Box_x4[i].Left && AI.Bottom == ar_Box_x4[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                for (int i = 0; i < ar_Box_x5.Length; i++)
                {
                    if (AI.Right == ar_Box_x5[i].Left && AI.Bottom == ar_Box_x5[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x6.Length; i++)
                {
                    if (AI.Right == ar_Box_x6[i].Left && AI.Bottom == ar_Box_x6[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;

                    }
                }
                for (int i = 0; i < ar_Box_x7.Length; i++)
                {
                    if (AI.Right == ar_Box_x7[i].Left && AI.Bottom == ar_Box_x7[i].Bottom)
                    {
                        AI_RandomMove();
                        AI_SetBoom(AI.Left, AI.Top);
                        return;
                    }
                }
                #endregion
                AI.Left += 2 * _myAi[0].Speed;
            }
            #endregion
        }
        private void AI_SetBoom(int x,int y)
        {
            _xAI1 = x;
            _yAI1 = y;
            #region setBoom
            if (_myAi[0].NumberBoom == 1)
            {
                if (ai1_nBoom_1_Tick == 1)
                {
                    timerBoomAI1_1.Start();
                }
            }
            if (_myAi[0].NumberBoom == 2)
            {
                if (ai1_nBoom_1_Tick == 1)
                {
                    timerBoomAI1_1.Start();
                }
                else if (ai1_nBoom_1_Tick != 1 && ai1_nBoom_2_Tick == 1)
                {
                    timerBoomAI1_2.Start();
                }
            }
            #endregion
        }
        private void AI_RandomMove()
        {
            int[] randwalk = new int[4];
            for (int i = 0; i < randwalk.Length; i++)
            {
                randwalk[i] = rand.Next(1, 5);
                if (randwalk[i] == 1) _sFacing_AI = "Up";
                if (randwalk[i] == 2) _sFacing_AI = "Down";
                if (randwalk[i] == 3) _sFacing_AI = "Left";
                if (randwalk[i] == 4) _sFacing_AI = "Right";
            }
        }
        #endregion

        private void labelNamePlayer01_Click(object sender, EventArgs e)
        {

        }

    }
}