using System;
using System.Collections.Generic;
using System.Linq;
namespace RAN_SAN_MOI
{
    public class QuanLyVatCan
    {
        public List<VatCan> DanhSachVatCan = new List<VatCan>();
        private Random rand = new Random();
        // Cập nhật tất cả vật cản tuần tra mỗi tick
        public void CapNhatTatCaVatCan(int oNgang, int oDoc)
        {
            foreach (var vc in DanhSachVatCan)
            {
                vc.CapNhat(oNgang, oDoc);
            }
        }
        // Sinh vật cản mặc định cố định cho Map 2
        public void SinhVatCanMacDinh(int oNgang, int oDoc)
        {
            DanhSachVatCan.Clear();
            int midX = oNgang / 2;
            int midY = oDoc / 2;
            // Bức tường 1 (bên trái tâm, nằm ngang)
            for (int x = midX - 6; x <= midX - 2; x++)
            {
                DanhSachVatCan.Add(new VatCanCoDinh(new ToaDo(x, midY - 3)));
            }
            // Bức tường 2 (bên phải tâm, nằm ngang)
            for (int x = midX + 2; x <= midX + 6; x++)
            {
                DanhSachVatCan.Add(new VatCanCoDinh(new ToaDo(x, midY + 3)));
            }
            // Thêm 2 vật cản di động tuần tra ở hai phía
            DanhSachVatCan.Add(new VatCanDiChuyen(new ToaDo(4, 4), true));
            DanhSachVatCan.Add(new VatCanDiChuyen(new ToaDo(oNgang - 5, oDoc - 5), true));
        }
       
       
        public void SinhThemMotVatCan(int oNgang, int oDoc, List<ToaDo> thanRan, List<Moi> danhSachMoi)
        {
            ToaDo vitri = TimViTriTrong(oNgang, oDoc, thanRan, danhSachMoi);
            if (vitri == null) return;

           
            if (rand.Next(10) < 4)
                DanhSachVatCan.Add(new VatCanDiChuyen(vitri, rand.Next(2) == 0));
            else
                DanhSachVatCan.Add(new VatCanCoDinh(vitri));
        }
        // Kiểm tra va chạm đầu rắn với bất kỳ vật cản nào
        public bool KiemTraVaCham(ToaDo dauRan)
        {
            return DanhSachVatCan.Any(vc => vc.Vitri.X == dauRan.X && vc.Vitri.Y == dauRan.Y);
        }
        // Tìm vị trí ô trống không trùng rắn, mồi và vật cản khác
        private ToaDo TimViTriTrong(int oNgang, int oDoc, List<ToaDo> thanRan, List<Moi> danhSachMoi)
        {
            int panelRows = (int)Math.Ceiling(49.0 / Setting.Cao);
            for (int attempt = 0; attempt < 300; attempt++)
            {
                // Giới hạn biên để không sinh quá sát mép tường
                var v = new ToaDo(rand.Next(2, oNgang - 2), rand.Next(panelRows + 1, oDoc - 3));
                // Tránh khu vực xuất phát của đầu rắn (thường ở X: 10, Y: 5)
                if (Math.Abs(v.X - 10) < 5 && Math.Abs(v.Y - 5) < 3)
                {
                    continue;
                }
                // Kiểm tra trùng lắp
                bool trungRan = thanRan.Any(t => t.X == v.X && t.Y == v.Y);
                bool trungMoi = danhSachMoi.Any(m => m.Vitri.X == v.X && m.Vitri.Y == v.Y);
                bool trungVatCan = DanhSachVatCan.Any(vc => vc.Vitri.X == v.X && vc.Vitri.Y == v.Y);
                if (!trungRan && !trungMoi && !trungVatCan)
                {
                    return v;
                }
            }
            return null;
        }
    }
}