using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RAN_SAN_MOI
{
    public static class Setting
    {
        // ── Kích thước pixel ──
        public static int Rong = 20;
        public static int Cao = 20;

        // ── Hướng di chuyển ──
        public enum HuongDiChuyen { Phai, Trai, Len, Xuong }

        // ── Độ khó ──
        public enum DoKho { De, Vua, Kho }
        public static DoKho DoKhoDaChon = DoKho.De;

        // ── Game State ──
        public static HuongDiChuyen Huong = HuongDiChuyen.Phai;
        public static int High_score = 0;

        // ── Màu rắn ──
        public static Color MauDauRan = Color.Black;
        public static Color MauThanRan = Color.Black;

        // ── Mắt rắn ──
        public static Color MauMui = Color.Black;
        public static int KichThuocMui = 4;

        // ── Chế độ mồi ──
        public enum CheDoMoi
        {
            PhanThan,
            TraiTim,
            BinhThuong
        }

        public static float HeSoKichThuoc = 1f;

        // ── Số lượng mồi đồng thời ──
        public static int SoLuongMoiBinhThuong = 1;
        public static int SoLuongMoiTraiTim = 1;
        public static int SoLuongMoiPhanThan = 1;
        public static int SoLuongMoiKhongLo = 0;
        public static int SoLuongMoiTruDiem = 0;

        // ── Màu mồi ──
        public static Color MauMoiBinhThuong = Color.Red;
        public static Color MauMoiTraiTim = Color.HotPink;
        public static Color MauMoiPhanThan = Color.Blue;
        public static Color MauMoiKhongLo = Color.Gold;
        public static Color MauMoiTruDiem = Color.Black;

        // ── Người chơi ──
        public static string TenNguoiChoiCu { get; set; } = "";  // nhớ tên lần trước
        public static string TenNguoiChoi { get; set; } = "Khách";

        // ── Background ──
        public enum LoaiBackground
        {
            NhaSanXuat,
            MayTinh,
            Internet
        }

        public class BackgroundRecord
        {
            public string TenHienThi { get; set; }
            public string DuongDanFile { get; set; }
            public LoaiBackground Loai { get; set; }
            public DateTime ThoiGian { get; set; }
        }

        public static BackgroundRecord BackgroundDangChon { get; set; } = null;
        public static List<BackgroundRecord> LichSuBackground { get; set; } = new List<BackgroundRecord>();

        public static void LuuLichSu(BackgroundRecord r)
        {
            LichSuBackground.RemoveAll(x => x.DuongDanFile == r.DuongDanFile);
            r.ThoiGian = DateTime.Now;
            LichSuBackground.Insert(0, r);
            if (LichSuBackground.Count > 20)
                LichSuBackground.RemoveAt(LichSuBackground.Count - 1);
        }

        public static string GetFolderNguoiDung()
        {
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Backgrounds", "NguoiDung");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public static string GetFolderNSX()
        {
            return Path.Combine(
                Application.StartupPath,
                "Backgrounds", "NSX");
        }
        public static int TocDoRan = 5;
        public static int LayIntervalTheoTocDo()
        {
            return 170-(TocDoRan*12);
        }
    }
}