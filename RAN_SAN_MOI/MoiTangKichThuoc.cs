using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public class MoiTangKichThuoc : Moi
    {
        public MoiTangKichThuoc(ToaDo vitri) : base(vitri, Color.Pink, 40) { }
        public override HieuUngMoi LayHieuUng()
        {
            return HieuUngMoi.TangKichThuoc;
        }
    }
}
