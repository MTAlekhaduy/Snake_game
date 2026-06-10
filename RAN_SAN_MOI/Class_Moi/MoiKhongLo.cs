using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI.Class_Moi
{
   public class MoiKhongLo : Moi
    {
        public MoiKhongLo(ToaDo ViTri) : base(ViTri, Color.Gold, 40) { }
        public override void Ve(Graphics g, int rong, int cao)
        {
            
            using (var brush = new SolidBrush(MauSac))
            using (var pen = new Pen(Color.DarkGoldenrod, 2))
            {
                var rect = new Rectangle(
                    Vitri.X * rong, Vitri.Y * cao,
                    rong * 2, cao * 2);
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);
            }
        }
        public HieuUngMoi hieuUngMoi()
        {
            return HieuUngMoi.ToBonSection;
        }
    }
}
