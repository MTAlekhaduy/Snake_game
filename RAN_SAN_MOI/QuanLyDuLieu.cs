using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RAN_SAN_MOI
{
    public class BanGhiDiem 
    
    { 
        public string TenNguoiChoi { get; set; }
        public int Diem {  get; set; }
        public string DoKho { get; set; }
        public DateTime ThoiGian {  get; set; }

    }

   public static class QuanLyDuLieu
    {
        // đường dẫn file 
        private static readonly string _fileNguoiChoi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nguoichoi.txt");
        private static readonly string _fileBangDiem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bangdiem.txt");
        // đọc - lưu tên người chơi
        public static void LuuTenNguoiChoi(string ten)
        {
            File.WriteAllText(_fileNguoiChoi, ten.Trim());
            Setting.TenNguoiChoi= ten.Trim();
        }
        public static string DocTenNguoiChoi()
        {
            if (!File.Exists(_fileNguoiChoi)) return "";
            return File.ReadAllText(_fileNguoiChoi).Trim();
        }
        // ════════════════════════════════════════════
        // BẢNG XẾP HẠNG
        // ════════════════════════════════════════════

        // Lưu 1 kết quả mới vào file
        public static void LuuDiem(BanGhiDiem bg)
        {
            // Format mỗi dòng: TenNguoiChoi|Diem|DoKho|ThoiGian
            string dong = $"{bg.TenNguoiChoi}|{bg.Diem}|{bg.DoKho}|" +
                          $"{bg.ThoiGian:yyyy-MM-dd HH:mm:ss}";
            File.AppendAllText(_fileBangDiem, dong + Environment.NewLine);
        }

        // Đọc top 10 điểm cao nhất (toàn bộ độ khó)
        public static List<BanGhiDiem> DocTop10()
        {
            if (!File.Exists(_fileBangDiem))
                return new List<BanGhiDiem>();

            var danhSach = new List<BanGhiDiem>();

            foreach (string dong in File.ReadAllLines(_fileBangDiem))
            {
                if (string.IsNullOrWhiteSpace(dong)) continue;
                string[] parts = dong.Split('|');
                if (parts.Length < 4) continue;

                try
                {
                    danhSach.Add(new BanGhiDiem
                    {
                        TenNguoiChoi = parts[0],
                        Diem = int.Parse(parts[1]),
                        DoKho = parts[2],
                        ThoiGian = DateTime.Parse(parts[3])
                    });
                }
                catch { /* bỏ qua dòng lỗi */ }
            }

            // Sắp xếp giảm dần theo điểm, lấy top 10
            return danhSach
                .OrderByDescending(x => x.Diem)
                .Take(10)
                .ToList();
        }

        // Xóa toàn bộ bảng điểm
        public static void XoaBangDiem()
        {
            if (File.Exists(_fileBangDiem))
                File.Delete(_fileBangDiem);
        }

    }
}
