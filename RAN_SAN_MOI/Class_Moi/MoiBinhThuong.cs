using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI.Class_Moi
{
    public class MoiBinhThuong : Moi
    {
        public MoiBinhThuong(ToaDo ViTri) :base(ViTri, Color.Red,10) { }
        public override HieuUngMoi LayHieuUng()
        {
            return HieuUngMoi.DaiThem1;
        }
     }
}
