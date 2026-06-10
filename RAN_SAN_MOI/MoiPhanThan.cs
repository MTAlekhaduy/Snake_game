using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public class MoiPhanThan : Moi
    {
        private bool nhapNhay = false;

        public MoiPhanThan(ToaDo vitri)
            : base(vitri,Setting.MauMoiPhanThan, 80) { }

        public override void CapNhat(int oNgang, int oDoc)
        {
            MauSac = Setting.MauMoiPhanThan;
           
        }
        public override void Ve(Graphics g, int rong, int cao)
        {
            // Vẽ 2x2 ô với viền
            using (var brush = new SolidBrush(MauSac))
            using (var pen = new Pen(Color.Blue, 2))
            {
                var rect = new Rectangle(
                    Vitri.X * rong, Vitri.Y * cao,
                    rong/2 , cao/2);
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);
            }
        }
        public override HieuUngMoi LayHieuUng() => HieuUngMoi.PhanThan;
    }
}
