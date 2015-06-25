using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.GUI
{
    public class Basic
    {
        private String Ma;
        public Basic(String Ma)
        {
            this.Ma = Ma;
        }

        private string getNextIndex(String ma)
        {
            int SoTang = Convert.ToInt32(ma) + 1;
            string index = "";
            if (SoTang >= 0 && SoTang < 10)
            {
                index = "000" + SoTang;
            }
            if (SoTang >= 10 && SoTang < 100)
            {
                index = "00" + SoTang;
            }
            if (SoTang >= 100 && SoTang < 1000)
            {
                index = "0" + SoTang;
            }
            if (SoTang >= 1000 && SoTang < 10000)
            {
                index = "" + SoTang;
            }
            if (SoTang >= 100000)
            {
                index = "Không thể tăng hơn nữa";
            }

            return index;
        }

        public String GenerMaNhanVien(String _Ma)
        {
            string manv = "";
            if (_Ma == null)
            {
                manv = "NV0001";
                return manv;
            }
            string KTD = _Ma.Substring(0, 2);
            manv = KTD + getNextIndex(_Ma.Substring(2));
            return manv;
        }

        public String GenerMaKhachHang(String _Ma)
        {
            string maKH = "";
            if (_Ma == null)
            {
                maKH = "KH0001";
                return maKH;
            }

            string KTD = _Ma.Substring(0, 2);
            maKH = KTD + getNextIndex(_Ma.Substring(2));
            return maKH;
        }

        public String GenerMaHopDong(String _Ma)
        {
            string maHD = "";
            if (_Ma == null)
            {
                maHD = "HD0001";
                return maHD;
            }
            string KTD = _Ma.Substring(0, 2);
            maHD = KTD + getNextIndex(_Ma.Substring(2));
            
            return maHD;
        }

        public String GenerMaGiaoDich(String _Ma)
        {
            string maGD = "";
            if (string.IsNullOrEmpty(_Ma))
            {
                maGD = "GD0001";
                return maGD;
            }
            string KTD = _Ma.Substring(0, 2);
            maGD = KTD + getNextIndex(_Ma.Substring(2));
            return maGD;
        }

        public String GenerMaGuiMail(String _Ma)
        {
            string maGM = "";
            if (string.IsNullOrEmpty(_Ma))
            {
                maGM = "GM0001";
                return maGM;
            }
            string KTD = _Ma.Substring(0, 2);
            maGM = KTD + getNextIndex(_Ma.Substring(2));
            return maGM;
        }

        public String GenerMaThuChi(String _Ma)
        {
            string MaTK = "";
            if (string.IsNullOrEmpty(_Ma))
            {
                MaTK = "TK0001";
                return MaTK;
            }
            string KTD = _Ma.Substring(0, 2);
            MaTK = KTD + getNextIndex(_Ma.Substring(2));
            return MaTK;
        }

        public String GenerMaSanPham(String _Ma)
        {
            string maSP = "";
            if (_Ma == null)
            {
                maSP = "SP0001";
                return maSP;
            }
            string KTD = _Ma.Substring(0, 2);
            maSP = KTD + getNextIndex(_Ma.Substring(2));
            return maSP;
        }

        public String GenerMaLichHen(String _Ma)
        {
            string maLH = "";
            if (_Ma == null)
            {
                maLH = "LH0001";
                return maLH;
            }
            string KTD = _Ma.Substring(0, 2);
            maLH = KTD + getNextIndex(_Ma.Substring(2));
            return maLH;
        }

        public String GenerMaHoTro(String _Ma)
        {
            string maHT = "";
            if (_Ma == null)
            {
                maHT = "HT0001";
                return maHT;
            }
            string KTD = _Ma.Substring(0, 2);
            maHT = KTD + getNextIndex(_Ma.Substring(2));
            return maHT;
        }

        public String GenerMaNhomKhachHang(String _Ma)
        {
            string maNKH = "";
            if (_Ma == null)
            {
                maNKH = "NKH0001";
                return maNKH;
            }
            string KTD = _Ma.Substring(0, 3);
            maNKH = KTD + getNextIndex(_Ma.Substring(3));
            return maNKH;
        }

        public String GenerMaNhomNguoiDung(String _Ma)
        {
            string maNND = "";
            if (_Ma == null)
            {
                maNND = "NND0001";
                return maNND;
            }
            string KTD = _Ma.Substring(0, 3);
            maNND = KTD + getNextIndex(_Ma.Substring(3));
            return maNND;
        }
    }
}
