using System;
using System.Drawing;

namespace RAN_SAN_MOI
{
    /// <summary>
    /// Vật cản di chuyển — tuần hoàn theo chiều dọc hoặc ngang.
    /// </summary>
    public class VatCanDiChuyen : VatCan
    {
        private bool _diTheoChieuDoc;   // true = di chuyển dọc (Y), false = ngang (X)
        private int  _huong = 1;        // +1 hoặc -1
        private int  _buocDi = 0;
        private const int MAX_BUOC = 4;

        // Constructor mặc định (màu cam cố định)
        public VatCanDiChuyen(ToaDo vitri, bool diTheoChieuDoc)
            : base(vitri, Color.FromArgb(220, 100, 30))
        {
            _diTheoChieuDoc = diTheoChieuDoc;
        }

        // Constructor nhận màu từ bên ngoài (dùng bởi QuanLyVatCan.TaoVatCanTheoCheDo)
        public VatCanDiChuyen(ToaDo vitri, bool diTheoChieuDoc, Color mauSac)
            : base(vitri, mauSac)
        {
            _diTheoChieuDoc = diTheoChieuDoc;
        }

        public override void CapNhat(int oNgang, int oDoc)
        {
            _buocDi++;
            if (_buocDi < 7) return;   // di chuyển chậm hơn rắn
            _buocDi = 0;

            if (_diTheoChieuDoc)
            {
                Vitri.Y += _huong;
                if (Vitri.Y <= 0 || Vitri.Y >= oDoc - 1) _huong = -_huong;
            }
            else
            {
                Vitri.X += _huong;
                if (Vitri.X <= 0 || Vitri.X >= oNgang - 1) _huong = -_huong;
            }
        }

        public override void Ve(Graphics g, int rong, int cao)
        {
            int x = Vitri.X * rong;
            int y = Vitri.Y * cao;

            // Màu cam nổi bật cho vật cản di chuyển
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Rectangle(x, y, rong, cao),
                Color.FromArgb(255, 140, 50),
                Color.FromArgb(200, 70,  10),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 5;
                path.AddArc(x,               y,               radius, radius, 180, 90);
                path.AddArc(x + rong - radius, y,               radius, radius, 270, 90);
                path.AddArc(x + rong - radius, y + cao - radius, radius, radius, 0,   90);
                path.AddArc(x,               y + cao - radius, radius, radius, 90,  90);
                path.CloseFigure();

                g.FillPath(brush, path);

                using (var pen = new Pen(Color.FromArgb(160, 50, 0), 1.5f))
                    g.DrawPath(pen, path);

                // Mũi tên chỉ hướng di chuyển
                using (var penArrow = new Pen(Color.FromArgb(220, Color.White), 1.5f))
                {
                    int cx = x + rong / 2;
                    int cy = y + cao / 2;
                    int a  = Math.Min(rong, cao) / 4;
                    if (_diTheoChieuDoc)
                    {
                        g.DrawLine(penArrow, cx, cy - a, cx, cy + a);
                        if (_huong > 0)
                        {
                            g.DrawLine(penArrow, cx - a / 2, cy + a / 2, cx, cy + a);
                            g.DrawLine(penArrow, cx + a / 2, cy + a / 2, cx, cy + a);
                        }
                        else
                        {
                            g.DrawLine(penArrow, cx - a / 2, cy - a / 2, cx, cy - a);
                            g.DrawLine(penArrow, cx + a / 2, cy - a / 2, cx, cy - a);
                        }
                    }
                    else
                    {
                        g.DrawLine(penArrow, cx - a, cy, cx + a, cy);
                        if (_huong > 0)
                        {
                            g.DrawLine(penArrow, cx + a / 2, cy - a / 2, cx + a, cy);
                            g.DrawLine(penArrow, cx + a / 2, cy + a / 2, cx + a, cy);
                        }
                        else
                        {
                            g.DrawLine(penArrow, cx - a / 2, cy - a / 2, cx - a, cy);
                            g.DrawLine(penArrow, cx - a / 2, cy + a / 2, cx - a, cy);
                        }
                    }
                }
            }
        }
    }
}
