using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber
{
    class Bomber
    {
        #region 
        private int _nSpeed;//เดิน
        private int _nPower;//การระเบิท
        private int _nNbBoom;//จำนวนระเบิท
        #endregion

        #region 
        public Bomber()
        {
            _nSpeed = 1;//max5
            _nPower = 1;//max5
            _nNbBoom = 1;//max3
        }
        #endregion

        #region Methods
        private void MaxSpeed(int nSpeed)
        {
            if (nSpeed == 3) _nSpeed = 4;
            else if (nSpeed > 5) return;
            else _nSpeed = nSpeed;
        }
        private void MaxPower(int nPower)
        {
            if (nPower > 5) return;
            else _nPower = nPower;
        }
        private void MaxNumberBom(int nNumberBoom)
        {
            if (nNumberBoom > 3) return;
            else _nNbBoom = nNumberBoom;
        }
        #endregion

        #region 
        public int Speed
        {
            set { MaxSpeed(value); }
            get { return _nSpeed; }
        }
        public int Power
        {
            set { MaxPower(value); }
            get { return _nPower; }
        }
        public int NumberBoom
        {
            set { MaxNumberBom(value); }
            get { return _nNbBoom; }
        }
        #endregion

        public override string ToString()
        {
            return Environment.NewLine + "Speed :" + _nSpeed.ToString() + Environment.NewLine +
            "Power :" + _nPower.ToString() + Environment.NewLine +
                "Boom :" + _nNbBoom.ToString();
        }
    }
}
