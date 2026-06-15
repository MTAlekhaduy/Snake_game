using System;
using System.Collections.Generic;

namespace RAN_SAN_MOI
{
    /// <summary>
    /// Snapshot trạng thái game — tương ứng bảng TrangThaiLuu trong DB.
    /// Mỗi người chơi chỉ có tối đa 1 slot lưu.
    /// </summary>
    public class TrangThaiGameRecord
    {
        public int ID { get; set; }
        public int NguoiChoiID { get; set; }

        // ── Thông tin game ──
        public string DoKho { get; set; }           // "De" / "Vua" / "Kho"
        public int DiemHienTai { get; set; }

        // ── Vị trí rắn ── format: "10,5|10,6|10,7" (đầu → đuôi)
        public string ViTriRan { get; set; }

        // ── Hướng di chuyển ── 0=Len, 1=Xuong, 2=Trai, 3=Phai
        public int ChieuDi { get; set; }

        // ── Danh sách mồi ── format: "BinhThuong,3,4|TraiTim,8,2"
        public string DanhSachMoi { get; set; }

        // ── Danh sách vật cản ── format: "CoDinh,5,5|DiChuyen,6,6,1"
        public string DanhSachVatCan { get; set; }

        // ── Meta ──
        public DateTime ThoiGianLuu { get; set; }
        public bool ConHieuLuc { get; set; }
        public byte[] AnhGame { get; set; }
        public string DuongDanBackground { get; set; }

        // ══════════════════════════════════════════════════════════
        // HELPER: Serialize / Deserialize rắn
        // ══════════════════════════════════════════════════════════

        
        /// Chuyển List ToaDo → chuỗi "10,5|10,6|10,7"
       
        public static string SerializeRan(List<ToaDo> thanRan)
        {
            var parts = new List<string>();
            foreach (var td in thanRan)
                parts.Add($"{td.X},{td.Y}");
            return string.Join("|", parts);
        }

      
        /// Chuyển chuỗi "10,5|10,6|10,7" → List ToaDo
     
        public static List<ToaDo> DeserializeRan(string data)
        {
            var ds = new List<ToaDo>();
            if (string.IsNullOrWhiteSpace(data)) return ds;

            foreach (string part in data.Split('|'))
            {
                string[] xy = part.Split(',');
                if (xy.Length == 2)
                    ds.Add(new ToaDo(int.Parse(xy[0]), int.Parse(xy[1])));
            }
            return ds;
        }

        // ══════════════════════════════════════════════════════════
        // HELPER: Serialize / Deserialize hướng di chuyển
        // ══════════════════════════════════════════════════════════

        public static int HuongToInt(Setting.HuongDiChuyen huong)
        {
            switch (huong)
            {
                case Setting.HuongDiChuyen.Len: return 0;
                case Setting.HuongDiChuyen.Xuong: return 1;
                case Setting.HuongDiChuyen.Trai: return 2;
                case Setting.HuongDiChuyen.Phai: return 3;
                default: return 3;
            }
        }

        public static Setting.HuongDiChuyen IntToHuong(int val)
        {
            switch (val)
            {
                case 0: return Setting.HuongDiChuyen.Len;
                case 1: return Setting.HuongDiChuyen.Xuong;
                case 2: return Setting.HuongDiChuyen.Trai;
                case 3: return Setting.HuongDiChuyen.Phai;
                default: return Setting.HuongDiChuyen.Phai;
            }
        }

        // ══════════════════════════════════════════════════════════
        // HELPER: Serialize / Deserialize mồi
        // ══════════════════════════════════════════════════════════

       
        /// Chuyển List Moi → "BinhThuong,3,4|TraiTim,8,2|KhongLo,1,1"
      
        public static string SerializeMoi(List<Moi> danhSach)
        {
            var parts = new List<string>();
            foreach (var m in danhSach)
            {
                string loai = LayTenLoaiMoi(m);
                parts.Add($"{loai},{m.Vitri.X},{m.Vitri.Y}");
            }
            return string.Join("|", parts);
        }

       
        /// Chuyển chuỗi → List Moi
  
        public static List<Moi> DeserializeMoi(string data)
        {
            var ds = new List<Moi>();
            if (string.IsNullOrWhiteSpace(data)) return ds;

            foreach (string part in data.Split('|'))
            {
                string[] tokens = part.Split(',');
                if (tokens.Length < 3) continue;

                string loai = tokens[0];
                int x = int.Parse(tokens[1]);
                int y = int.Parse(tokens[2]);
                ToaDo vitri = new ToaDo(x, y);

                Moi moi = TaoMoiTheoLoai(loai, vitri);
                if (moi != null) ds.Add(moi);
            }
            return ds;
        }

     
        /// Serialize vật cản: "CoDinh,5,5|DiChuyen,6,6,1"
        /// (DiChuyen có thêm tham số: 1=doc, 0=ngang)
      
        public static string SerializeVatCan(List<VatCan> danhSach)
        {
            var parts = new List<string>();
            foreach (var vc in danhSach)
            {
                if (vc is VatCanDiChuyen)
                    parts.Add($"DiChuyen,{vc.Vitri.X},{vc.Vitri.Y}");
                else
                    parts.Add($"CoDinh,{vc.Vitri.X},{vc.Vitri.Y}");
            }
            return string.Join("|", parts);
        }

        public static List<VatCan> DeserializeVatCan(string data)
        {
            var ds = new List<VatCan>();
            if (string.IsNullOrWhiteSpace(data)) return ds;

            foreach (string part in data.Split('|'))
            {
                string[] tokens = part.Split(',');
                if (tokens.Length < 3) continue;

                string loai = tokens[0];
                int x = int.Parse(tokens[1]);
                int y = int.Parse(tokens[2]);
                ToaDo vitri = new ToaDo(x, y);

                if (loai == "DiChuyen")
                    ds.Add(new VatCanDiChuyen(vitri, true));
                else
                    ds.Add(new VatCanCoDinh(vitri));
            }
            return ds;
        }

        // ── Private helpers ──
        private static string LayTenLoaiMoi(Moi m)
        {
            if (m is MoiBinhThuong) return "BinhThuong";
            if (m is MoiTraiTim) return "TraiTim";
            if (m is MoiPhanThan) return "PhanThan";
            if (m is MoiKhongLo) return "KhongLo";
            if (m is MoiTruDiem) return "TruDiem";
            if (m is MoiTangKichThuoc) return "TangKichThuoc";
            return "BinhThuong";
        }

        private static Moi TaoMoiTheoLoai(string loai, ToaDo vitri)
        {
            switch (loai)
            {
                case "BinhThuong": return new MoiBinhThuong(vitri);
                case "TraiTim": return new MoiTraiTim(vitri);
                case "PhanThan": return new MoiPhanThan(vitri);
                case "KhongLo": return new MoiKhongLo(vitri);
                case "TruDiem": return new MoiTruDiem(vitri);
                case "TangKichThuoc": return new MoiTangKichThuoc(vitri);
                default: return null;
            }
        }
    }
}