using System;
using System.Drawing;

namespace RAN_SAN_MOI
{
    /// <summary>
    /// Lớp cơ sở cho tất cả vật cản trong game.
    /// </summary>
    public abstract class VatCan
    {
        public ToaDo Vitri { get; set; }
        public Color MauSac { get; set; }

        protected VatCan(ToaDo vitri, Color mauSac)
        {
            Vitri = vitri;
            MauSac = mauSac;
        }

        /// <summary>Cập nhật trạng thái mỗi tick (dùng cho vật cản di chuyển).</summary>
        public virtual void CapNhat(int oNgang, int oDoc) { }

        /// <summary>Vẽ vật cản lên màn hình.</summary>
        public virtual void Ve(Graphics g, int rong, int cao)
        {
            int x = Vitri.X * rong;
            int y = Vitri.Y * cao;

            // Vẽ hình chữ nhật bo góc cho vật cản
            using (var brush = new SolidBrush(MauSac))
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 4;
                path.AddArc(x,              y,              radius, radius, 180, 90);
                path.AddArc(x + rong - radius, y,              radius, radius, 270, 90);
                path.AddArc(x + rong - radius, y + cao - radius, radius, radius, 0,   90);
                path.AddArc(x,              y + cao - radius, radius, radius, 90,  90);
                path.CloseFigure();
                g.FillPath(brush, path);

                // Viền
                using (var pen = new Pen(Color.FromArgb(200, Color.Black), 1.5f))
                    g.DrawPath(pen, path);
            }
        }

        /// <summary>Kiểm tra va chạm với toạ độ (đầu rắn).</summary>
        public bool KiemTraVaCham(ToaDo dau)
        {
            return dau.X == Vitri.X && dau.Y == Vitri.Y;
        }
    }
}
