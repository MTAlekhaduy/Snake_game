using System.Drawing;

namespace RAN_SAN_MOI
{
    /// <summary>
    /// Vật cản cố định — không di chuyển, vẽ màu xám đậm.
    /// </summary>
    public class VatCanCoDinh : VatCan
    {
        // Constructor mặc định (màu xám cố định — dùng khi không có FormSetVatCan)
        public VatCanCoDinh(ToaDo vitri)
            : base(vitri, Color.FromArgb(100, 100, 110))
        {
        }

        // Constructor nhận màu từ bên ngoài (dùng bởi QuanLyVatCan.TaoVatCanTheoCheDo)
        public VatCanCoDinh(ToaDo vitri, Color mauSac)
            : base(vitri, mauSac)
        {
        }

        public override void Ve(System.Drawing.Graphics g, int rong, int cao)
        {
            int x = Vitri.X * rong;
            int y = Vitri.Y * cao;

            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new System.Drawing.Rectangle(x, y, rong, cao),
                Color.FromArgb(130, 130, 145),
                Color.FromArgb(70,  70,  80),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 4;
                path.AddArc(x,               y,               radius, radius, 180, 90);
                path.AddArc(x + rong - radius, y,               radius, radius, 270, 90);
                path.AddArc(x + rong - radius, y + cao - radius, radius, radius, 0,   90);
                path.AddArc(x,               y + cao - radius, radius, radius, 90,  90);
                path.CloseFigure();

                g.FillPath(brush, path);

                using (var pen = new System.Drawing.Pen(Color.FromArgb(50, 50, 60), 1.5f))
                    g.DrawPath(pen, path);

                // Dấu X nhỏ để phân biệt
                using (var penX = new System.Drawing.Pen(Color.FromArgb(200, Color.White), 1.2f))
                {
                    int pad = 4;
                    g.DrawLine(penX, x + pad, y + pad, x + rong - pad, y + cao - pad);
                    g.DrawLine(penX, x + rong - pad, y + pad, x + pad, y + cao - pad);
                }
            }
        }
    }
}
