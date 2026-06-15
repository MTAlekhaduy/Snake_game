using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public static class ScoreManager
    {
        private static SqlGameRepository _repo = new SqlGameRepository();

        // Người chơi hiện tại (set sau khi đăng nhập)
        public static NguoiChoiRecord NguoiChoiHienTai;

        // ── Đăng nhập hoặc tạo người chơi mới ──
        public static void DangNhapHoacTao(string ten)
        {
            NguoiChoiRecord nguoiChoi = _repo.DangNhapHoacTao(ten);
            NguoiChoiHienTai = nguoiChoi;
        }

        // ── Lưu điểm ──
        public static void LuuDiem(int diem, string doKho)
        {
            if (NguoiChoiHienTai == null) return;

            ScoreRecord record = new ScoreRecord();
            record.NguoiChoiID = NguoiChoiHienTai.ID;
            record.Diem = diem;
            record.DoKho = doKho;
            record.ThoiGian = DateTime.Now;

            _repo.LuuDiem(record);
        }

        // ── Lấy bảng xếp hạng ──
        public static List<ScoreRecord> LayBangXepHang()
        {
            List<ScoreRecord> ds = _repo.LayBangXepHang(10);
            return ds;
        }

        // ── Lưu trạng thái game ──
        public static void LuuTrangThai(TrangThaiGameRecord snap)
        {
            if (NguoiChoiHienTai == null) return;

            snap.NguoiChoiID = NguoiChoiHienTai.ID;
            _repo.LuuTrangThai(snap);
        }

        // ── Lấy trạng thái đã lưu ──
        public static TrangThaiGameRecord LayTrangThai()
        {
            if (NguoiChoiHienTai == null) return null;

            TrangThaiGameRecord trangThai = _repo.LayTrangThai(NguoiChoiHienTai.ID);
            return trangThai;
        }

        // ── Xóa slot lưu ──
        public static void XoaTrangThaiLuu()
        {
            if (NguoiChoiHienTai == null) return;

            _repo.XoaTrangThai(NguoiChoiHienTai.ID);
        }
        public static void XoaTatCaDiem()
        {
            _repo.XoaTatCaDiem();
        }
    }
}
