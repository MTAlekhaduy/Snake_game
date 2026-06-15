using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public class MoiBinhThuong : Moi
    {
        public MoiBinhThuong(ToaDo vitri)
            : base(vitri,Setting.MauMoiBinhThuong, 10) { }

        public override HieuUngMoi LayHieuUng() => HieuUngMoi.DaiThem1;
    }
}
