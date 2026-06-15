using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static RAN_SAN_MOI.Setting;

namespace RAN_SAN_MOI
{
     public class QuanLyRan
    {
        public List<ToaDo> ThanRan = new List<ToaDo>();
        public Setting.HuongDiChuyen HuongHienTai = HuongDiChuyen.Phai;
        public ToaDo Head => ThanRan[0];

        public void KhoiTao()
        {
            ThanRan.Clear();
            HuongHienTai = HuongDiChuyen.Phai;
            for (int i = 0; i < 4; i++)
            {
                ThanRan.Add(new ToaDo(10 - i, 5));
            }
        }

        // Xuyentuong
        public void XuyenTuong(int oNgang,int oDoc)
        {
            if (ThanRan[0].X < 0) ThanRan[0].X = oNgang - 1;
            if (ThanRan[0].X >= oNgang) ThanRan[0].X = 0;
            if (ThanRan[0].Y < 0) ThanRan[0].Y=oDoc - 1;
            if (ThanRan[0].Y >= oDoc) ThanRan[0].Y = 0;
        }
        public void Dichuyen(int oNgang, int oDoc)
        {
         for(int i=ThanRan.Count-1;i>0;i--)
            {
                ThanRan[i].X = ThanRan[i - 1].X;
                ThanRan[i].Y = ThanRan[i - 1].Y;
            }
            switch (HuongHienTai)
            {
                case Setting.HuongDiChuyen.Phai:
                    ThanRan[0].X += 1;
                    break;

                case Setting.HuongDiChuyen.Trai:
                    ThanRan[0].X -= 1;
                    break;

                case Setting.HuongDiChuyen.Len:
                    ThanRan[0].Y -= 1;
                    break;

                case Setting.HuongDiChuyen.Xuong:
                    ThanRan[0].Y += 1;
                    break;
            }
            XuyenTuong(oNgang, oDoc);
        }
        private bool AnToan(int x, int y, List<ToaDo> vatCan)
        {
            foreach (var vc in vatCan)
            {
                if (vc.X == x && vc.Y == y)
                    return false;
            }

            return true;
        }
      public void DiChuyenTuDong(int oNgang, int oDoc, List<ToaDo> vatCan)
{
    int x = ThanRan[0].X;
    int y = ThanRan[0].Y;

    if (AnToan(x + 1, y, vatCan))
        HuongHienTai = Setting.HuongDiChuyen.Phai;

    else if (AnToan(x, y + 1, vatCan))
        HuongHienTai = Setting.HuongDiChuyen.Xuong;

    else if (AnToan(x - 1, y, vatCan))
        HuongHienTai = Setting.HuongDiChuyen.Trai;

    else if (AnToan(x, y - 1, vatCan))
        HuongHienTai = Setting.HuongDiChuyen.Len;

    Dichuyen(oNgang, oDoc);
}
        public void DaiThem()
        { 
          ToaDo Duoi = ThanRan[ThanRan.Count-1];
          ThanRan.Add(new ToaDo(Duoi.X, Duoi.Y));
        }
        public void TangKichThuoc()
        {
            float f = 1.2f;
            Setting.HeSoKichThuoc = f;
        }
        public bool CanVaoDuoi()
        {
            for(int i=1;i<ThanRan.Count;i++)
            {
                if (ThanRan[0].X == ThanRan[i].X && ThanRan[0].Y == ThanRan[i].Y)
                    return true;
            }
            return false;

        }
        }

}
