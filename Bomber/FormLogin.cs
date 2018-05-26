using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Bomber
{
    public partial class FormLogin : Form
    {
        private int _y1,_y2;
        private SoundPlayer _SoundLogin = new SoundPlayer(Properties.Resources.Sound02);
        public FormLogin()
        {
            InitializeComponent();
            this.KeyPreview = false;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            _y1 = buttonExitHelp.Top;
            _y2 = pictureHelp.Top;
            buttonExitHelp.Top = 800;
            pictureHelp.Top = 800;
            _SoundLogin.Play();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            #region VB.NET
            Properties.Settings.Default.UserName = textBoxUserName.Text;
            Properties.Settings.Default.Save();
            #endregion
            _SoundLogin.Stop();
            this.Close();
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUserName.Text != "NameBomBer"&& textBoxUserName.Text != "") buttonStart.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonHighscore_Click(object sender, EventArgs e)
        {
            string _Highscore_txt = File.ReadAllText(@"data\Highscore.txt", Encoding.GetEncoding("Windows-874"));
            string[] spl = _Highscore_txt.Split(',');

            int nshift = 17;
            string Input = "";
            char[] ar_Char = null;
            ar_Char = spl[0].ToCharArray();

            int temp;
            for (int i = 0; i < spl[0].Length; i++)
            {
                temp = (int)(ar_Char[i] - nshift);
                Input += (char)temp;
            }
            if (labelShowScore.Text != "") labelShowScore.Text = "";
            else labelShowScore.Text = "Name :" + Input + Environment.NewLine + "Score :" + spl[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureHelp.Top = _y2;
            buttonExitHelp.Top = _y1;

            pictureHelp.BringToFront();
            buttonExitHelp.BringToFront();
        }

        private void buttonExitHelp_Click(object sender, EventArgs e)
        {
            pictureHelp.SendToBack();
        }
    }
}
