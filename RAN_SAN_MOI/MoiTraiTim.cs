using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public class MoiTraiTim: Moi
    {
        private double goc = 0;
        private const double BUOC_GOC = 0.05;
        private int  gocX, gocY;
        public MoiTraiTim(ToaDo vitri)   : base(vitri,Setting.MauMoiTraiTim, 30)
        {
            gocX = vitri.X; gocY=vitri.Y;
        }
        public override void CapNhat(int oNgang, int oDoc)
        {
            goc += BUOC_GOC;
            int dx = (int)(4 * Math.Pow(Math.Sin(goc), 3));
            int dy = -(int)(3 * Math.Cos(goc) - 1.25 * Math.Cos(2 * goc)
                          - 0.5 * Math.Cos(3 * goc) - 0.25 * Math.Cos(4 * goc));

            Vitri.X = (gocX + dx + oNgang) % oNgang;
            Vitri.Y = (gocY + dy + oDoc) % oDoc;
        }
        public override void Ve(Graphics g, int rong, int cao)
        {
            // Vẽ hình trái tim nhỏ = 2 ellipse + 1 tam giác
            int x = Vitri.X * rong;
            int y = Vitri.Y * cao;
            int w = rong; int h = cao;
            using (var brush = new SolidBrush(MauSac))
            {
                g.FillEllipse(brush, x, y, w / 2, h / 2);
                g.FillEllipse(brush, x + w / 2, y, w / 2, h / 2);
                Point[] tam = {
                    new Point(x, y + h / 4),
                    new Point(x + w, y + h / 4),
                    new Point(x + w / 2, y + h)
                };
                g.FillPolygon(brush, tam);
            }
        }
        public override HieuUngMoi LayHieuUng()
        {
            return HieuUngMoi.DaiThem1;
        }
    }
}
