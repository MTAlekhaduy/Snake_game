using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI.Class_Moi
{
     public class MoiPhanThan :Moi 
    {
        private bool nhapNhay = false;
        public MoiPhanThan(ToaDo ViTri) : base(ViTri, Color.MediumOrchid, 20) { }
        public override void CapNhat(int oNgang , int oDoc )
        {
            nhapNhay = !nhapNhay;
            if (nhapNhay)
            { 
                MauSac = Color.MediumOrchid;
             } 
            else
            {
                MauSac = Color.Plum;
            }
        }
        public HieuUngMoi hieuUngMoi()
        {
            return HieuUngMoi.PhanThan;
        }
    }
}
