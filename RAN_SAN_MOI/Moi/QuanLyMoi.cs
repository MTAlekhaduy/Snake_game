using System;
using System.Collections.Generic;
using System.Linq;

namespace RAN_SAN_MOI
{
    public class QuanLyMoi
    {
        public List<Moi> DanhSachMoi = new List<Moi>();
        private Random rand = new Random();

        
        public void SinhMoi(int oNgang, int oDoc, List<ToaDo> thanRan)
        {
            SinhTheoSoLuong(Setting.SoLuongMoiBinhThuong, oNgang, oDoc, thanRan,
                vitri => new MoiBinhThuong(vitri),
                m => m is MoiBinhThuong);

            SinhTheoSoLuong(Setting.SoLuongMoiTraiTim, oNgang, oDoc, thanRan,
                vitri => new MoiTraiTim(vitri),
                m => m is MoiTraiTim);

            SinhTheoSoLuong(Setting.SoLuongMoiPhanThan, oNgang, oDoc, thanRan,
                vitri => new MoiPhanThan(vitri),
                m => m is MoiPhanThan);

            SinhTheoSoLuong(Setting.SoLuongMoiKhongLo, oNgang, oDoc, thanRan,
                vitri => new MoiKhongLo(vitri),
                m => m is MoiKhongLo);

            SinhTheoSoLuong(Setting.SoLuongMoiTruDiem, oNgang, oDoc, thanRan,
                vitri => new MoiTruDiem(vitri),
                m => m is MoiTruDiem);
        }

       
        private void SinhTheoSoLuong(int soLuong, int oNgang, int oDoc,
            List<ToaDo> thanRan,
            Func<ToaDo, Moi> taoMoi,
            Func<Moi, bool> laBLoai)
        {
            int hienTai = DanhSachMoi.Count(laBLoai);
            for (int i = hienTai; i < soLuong; i++)
            {
                ToaDo vitri = TimViTriHopLe(oNgang, oDoc, thanRan);
                if (vitri == null) break;   
                DanhSachMoi.Add(taoMoi(vitri));
            }
        }

        // ── Cập nhật tất cả mồi mỗi tick ─────────────────────────────────
        public void CapNhatTatCaMoi(int oNgang, int oDoc)
        {
            foreach (var moi in DanhSachMoi)
                moi.CapNhat(oNgang, oDoc);
        }

        // ── Điều chỉnh vị trí mồi sau khi resize cửa sổ ──────────────────
        public void CapNhatMoiKhiResize(int oNgang, int oDoc)
        {
            foreach (var moi in DanhSachMoi)
            {
                if (moi.Vitri.X >= oNgang)
                    moi.Vitri = new ToaDo(oNgang - 1, moi.Vitri.Y);
                if (moi.Vitri.Y >= oDoc)
                    moi.Vitri = new ToaDo(moi.Vitri.X, oDoc - 1);
            }
        }

        // ── Kiểm tra và lấy mồi bị ăn ────────────────────────────────────
       
        public Moi KiemTraVaLayMoi(ToaDo dauRan)
        {
            Moi moiBiAn = null;

            foreach (var m in DanhSachMoi)
            {
                if (m is MoiKhongLo)
                {
                    if (dauRan.X >= m.Vitri.X && dauRan.X <= m.Vitri.X + 1 &&
                        dauRan.Y >= m.Vitri.Y && dauRan.Y <= m.Vitri.Y + 1)
                    {
                        moiBiAn = m;
                        break;
                    }
                }
                else
                {
                    if (m.Vitri.X == dauRan.X && m.Vitri.Y == dauRan.Y)
                    {
                        moiBiAn = m;
                        break;
                    }
                }
            }

            if (moiBiAn != null)
                DanhSachMoi.Remove(moiBiAn);

            return moiBiAn;
        }

        // ── Tìm vị trí ô trống không trùng rắn hay mồi khác ──────────────
        private ToaDo TimViTriHopLe(int oNgang, int oDoc, List<ToaDo> thanRan)
        {
            int panelRows = (int)Math.Ceiling(49.0 / Setting.Cao);
            for (int thu = 0; thu < 200; thu++)
            {
                int y = rand.Next(panelRows, oDoc - 2);
                var vitri = new ToaDo(rand.Next(oNgang - 2), y);
                if (!TrungVoiRanHoacMoi(vitri, thanRan))
                    return vitri;
            }
            return null;   
        }

        private bool TrungVoiRanHoacMoi(ToaDo vitri, List<ToaDo> thanRan)
        {
            foreach (var d in thanRan)
                if (d.X == vitri.X && d.Y == vitri.Y) return true;

            foreach (var m in DanhSachMoi)
                if (m.Vitri.X == vitri.X && m.Vitri.Y == vitri.Y) return true;

            return false;
        }
    }
}