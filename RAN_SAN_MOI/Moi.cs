using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Win32;
namespace RAN_SAN_MOI
{
    public abstract class Moi
    {
        public enum HieuUngMoi
        {
            KhongCo,
            DaiThem1,
            ToBonSection,
            NhoBot2,
            PhanThan,
            TruDiem,
            TangKichThuoc
        }
        public ToaDo Vitri { get; set; }
        public Color MauSac {  get; set; }
        public int DiemThuong {  get; set; }
        public bool ConSong { get; set; } = true;

        public Moi(ToaDo vitri, Color mauSac,int diemthuong)
        {
            Vitri = vitri;
            MauSac = mauSac;
            DiemThuong = diemthuong;
        }
        public virtual void CapNhat(int oNgang ,int oDoc) { }
        public virtual void Ve(Graphics g, int oNgang ,int oDoc)
        {
            g.FillEllipse(new SolidBrush(MauSac),
               Vitri.X *oNgang, Vitri.Y *oDoc,oNgang,oDoc);
        }
        public abstract HieuUngMoi LayHieuUng();
    }
}
