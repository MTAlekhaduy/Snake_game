using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RAN_SAN_MOI
{
    public static class Setting
    {
        // kich thuoc pixel
        public static int Rong = 20;
        public static int Cao = 20;

        // Huong di chuyen
        public enum HuongDiChuyen { Phai, Trai, Len, Xuong }

        // Độ khó người dùng đã chọn
        public enum DoKho { De, Vua, Kho }
        public static DoKho DoKhoDaChon = DoKho.De;


       
        // Game State 
        public static HuongDiChuyen Huong = HuongDiChuyen.Phai;
        
        public static int High_score = 0;

        // Màu rắn
        public static Color MauDauRan = Color.Black;
        public static Color MauThanRan = Color.Black;
        // Snake eye settings
        public static Color MauMui = Color.Black;
        public static int KichThuocMui = 4;
        public enum CheDoMoi
        {
            PhanThan,       // 2
            TraiTim,        // 3
            BinhThuong      // 5
        }
        public static float HeSoKichThuoc=1f;

        // ── Cấu hình số lượng mồi xuất hiện đồng thời  ──
        public static int SoLuongMoiBinhThuong = 1;   
        public static int SoLuongMoiTraiTim    = 1;   
        public static int SoLuongMoiPhanThan   = 1;   
        public static int SoLuongMoiKhongLo    = 0;   
        public static int SoLuongMoiTruDiem    = 0;   

        // ── Màu sắc từng loại mồi (người chơi có thể đổi) ──────────────────
        public static Color MauMoiBinhThuong = Color.Red;
        public static Color MauMoiTraiTim    = Color.HotPink;
        public static Color MauMoiPhanThan   = Color.Blue;
        public static Color MauMoiKhongLo    = Color.Gold;
        public static Color MauMoiTruDiem    = Color.Black;
        // =================== USER =====================
        public static string TenNguoiChoi { get; set; } = "Khách";
        // ===================== BACKGROUND =====================
        public enum LoaiBackground
        {
            NhaSanXuat,
            MayTinh,
            Internet
        }
        public class BackgroundRecord
        { 
             public string TenHienThi { get; set; }
             public string DuongDanFile {  get; set; }
             public LoaiBackground Loai {  get; set; }
             public DateTime ThoiGian {  get; set; }
        }
        public static BackgroundRecord BackgroundDangChon { get; set; } = null;
        public static List<BackgroundRecord> LichSuBackground { get; set; }= new List<BackgroundRecord>();
        public static void LuuLichSu(BackgroundRecord r)
        {
            LichSuBackground.RemoveAll(x=>x.DuongDanFile==r.DuongDanFile);
            r.ThoiGian= DateTime.Now;
            LichSuBackground.Insert(0, r);
            if(LichSuBackground.Count>20)
            {
                LichSuBackground.RemoveAt(LichSuBackground.Count - 1);
            }
        }
        public static string GetFolderNguoiDung()
        {
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Backgrounds", "NguoiDung");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        public static string GetFolderNSX()
        {
            return Path.Combine(
                Application.StartupPath,
                "Backgrounds",
                "NSX"
            );
        }
    }
}
