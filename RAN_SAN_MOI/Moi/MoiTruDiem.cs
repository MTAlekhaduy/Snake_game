using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public class MoiTruDiem : Moi
    {
        private bool nhapNhay = false;

        public MoiTruDiem(ToaDo vitri)
            : base(vitri,Setting.MauMoiTruDiem, -15) { }

        public override void CapNhat(int oNgang, int oDoc)
        {
            nhapNhay = !nhapNhay;
            MauSac = nhapNhay ? Color.Black : Color.DimGray;
        }

        public override HieuUngMoi LayHieuUng() => HieuUngMoi.TruDiem;
    }
}
