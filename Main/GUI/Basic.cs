using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.GUI
{
    public class Basic
    {
        public String GenerMa(String _Ma)
        {
            string manv = "";
            if (_Ma == null)
            {
                manv = "NV0001";
            }
            string KTD = _Ma.Substring(0, 2);
            int SoTang = Convert.ToInt32(_Ma.Substring(2)) + 1;

            if (SoTang >= 0 && SoTang < 10)
            {
                manv = KTD + "000" + SoTang;
            }
            if (SoTang >= 10 && SoTang < 100)
            {
                manv = KTD + "00" + SoTang;
            }
            if (SoTang >= 100 && SoTang < 1000)
            {
                manv = KTD + "0" + SoTang;
            }
            if (SoTang >= 1000 && SoTang < 10000)
            {
                manv = KTD  + SoTang;
            }
            //if (SoTang >= 10000 && SoTang < 100000)
            //{
            //    manv = KTD + SoTang;
            //}
            if (SoTang >= 100000)
            {
                manv = "Không thể tăng hơn nữa";
            }
            return manv;
        }
    }
}
