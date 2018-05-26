using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bomber
{
    class Highscore
    {
        private string _sUser;
        private int _nScore;
        private string _Highscore_txt = File.ReadAllText(@"data\Highscore.txt", Encoding.GetEncoding("Windows-874"));
        private string[][] _ar2_Highscore_txt = null;
        public void Cshift(string str, int nScore)
        {
            int nshift = 17;
            _nScore = nScore;
            string Output = "";
            char[] ar_Char = null;
            ar_Char = str.ToCharArray();
            int temp;
            for (int i = 0; i < str.Length; i++)
            {
                temp = (int)(ar_Char[i] + nshift);
                Output += (char)temp;
            }
            _sUser = Convert.ToString(Output);
            SaveScore();
        }
        public string Bshift(string str, int nshift)
        {
            string UserOutput = "";
            char[] A = null;
            A = str.ToCharArray();
            int temp;

            for (int i = 0; i < str.Length; i++)
            {
                temp = (int)(A[i] - nshift);
                UserOutput += (char)temp;
            }

            return UserOutput;
        }

        public void SaveScore()
        {
            string[] spl = _Highscore_txt.Split(',');
            if (Convert.ToInt32(spl[1]) >= _nScore) return;
            File.WriteAllText(@"data\Highscore.txt", _sUser + "," + _nScore.ToString());
        }
    }
}
