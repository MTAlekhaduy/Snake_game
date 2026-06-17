using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace RAN_SAN_MOI
{
    /// <summary>
    /// Quản lý toàn bộ vật cản trong game: sinh mới, cập nhật, kiểm tra va chạm.
    /// </summary>
    public class QuanLyVatCan
    {
        public List<VatCan> DanhSachVatCan { get; set; } = new List<VatCan>();

        private static readonly Random _rnd = new Random();

        // ────────────────────────────────────────────────────────────
        // Khởi tạo vật cản mặc định khi bắt đầu game mới
        // ────────────────────────────────────────────────────────────
        public void SinhVatCanMacDinh(int oNgang, int oDoc)
        {
            DanhSachVatCan.Clear();
            // Số lượng tường (mỗi tường dài 3 ô nằm ngang)
            int soLuongTuong = Math.Max(1, Math.Min(Setting.SoLuongTuongVatCan, 8));
            for (int i = 0; i < soLuongTuong; i++)
            {
               
                ToaDo vitriDau = TimViTriDattuong(oNgang, oDoc, new List<ToaDo>(), new List<Moi>());
                if (vitriDau == null) break;
                
                for (int dx = 0; dx < 3; dx++)
                {
                    ToaDo vitriO = new ToaDo(vitriDau.X + dx, vitriDau.Y);
                    DanhSachVatCan.Add(TaoVatCanTheoCheDo(vitriO));
                }
            }
        }
        public void SinhTuong(int oNgang,int oDoc,int x,int y)
        {
            DanhSachVatCan.Add(new VatCanCoDinh(new ToaDo(oNgang / x, oDoc / y)));
            DanhSachVatCan.Add(new VatCanCoDinh(new ToaDo((oNgang / x) - 1, (oDoc / y))));
            DanhSachVatCan.Add(new VatCanCoDinh(new ToaDo((oNgang / x) - 2, (oDoc / y))));
        }
        // ────────────────────────────────────────────────────────────
        // Sinh thêm 1 vật cản sau mỗi khoảng thời gian (VatCanTimer)
        // ────────────────────────────────────────────────────────────
        public void SinhThemMotVatCan(int oNgang, int oDoc,
                                      List<ToaDo>  thanRan,
                                      List<Moi>    danhSachMoi)
        {
            const int MAX_VAT_CAN = 8;
            if (DanhSachVatCan.Count >= MAX_VAT_CAN) return;

            ToaDo vitri = TimViTriRanh(oNgang, oDoc, thanRan, danhSachMoi);
            if (vitri == null) return;

            // Sinh theo chế độ người chơi đã chọn trong FormSetVatCan
            DanhSachVatCan.Add(TaoVatCanTheoCheDo(vitri));
        }

        /// <summary>
        /// Tạo VatCan phù hợp với Setting.CheDoVatCanDaChon.
        /// CoDinh   → luôn tạo VatCanCoDinh màu Setting.MauVatCanCoDinh
        /// DiChuyen → luôn tạo VatCanDiChuyen màu Setting.MauVatCanDiChuyen
        /// NgauNhien→ ngẫu nhiên 1/3 di chuyển, 2/3 cố định
        /// </summary>
        private VatCan TaoVatCanTheoCheDo(ToaDo vitri)
        {
            switch (Setting.CheDoVatCanDaChon)
            {
                case Setting.CheDoVatCan.CoDinh:
                    return new VatCanCoDinh(vitri, Setting.MauVatCanCoDinh);

                case Setting.CheDoVatCan.DiChuyen:
                    return new VatCanDiChuyen(vitri, _rnd.Next(2) == 0,
                                             Setting.MauVatCanDiChuyen);

                default: 
                    if (_rnd.Next(3) == 0)
                        return new VatCanDiChuyen(vitri, _rnd.Next(2) == 0,
                                                 Setting.MauVatCanDiChuyen);
                    else
                        return new VatCanCoDinh(vitri, Setting.MauVatCanCoDinh);
            }
        }

        // ────────────────────────────────────────────────────────────
        // Cập nhật tất cả vật cản mỗi tick
        // ────────────────────────────────────────────────────────────
        public void CapNhatTatCaVatCan(int oNgang, int oDoc)
        {
            foreach (var vc in DanhSachVatCan)
                vc.CapNhat(oNgang, oDoc);
        }

        // ────────────────────────────────────────────────────────────
        // Kiểm tra va chạm: trả về true nếu đầu rắn chạm vật cản nào
        // ────────────────────────────────────────────────────────────
        public bool KiemTraVaCham(ToaDo dauRan)
        {
            foreach (var vc in DanhSachVatCan)
                if (vc.KiemTraVaCham(dauRan))
                    return true;
            return false;
        }

        // ────────────────────────────────────────────────────────────
        // Private: tìm vị trí trống để sinh vật cản
        // ────────────────────────────────────────────────────────────
        private ToaDo TimViTriRanh(int oNgang, int oDoc,
                                   List<ToaDo> thanRan,
                                   List<Moi>   danhSachMoi)
        {
            for (int attempt = 0; attempt < 50; attempt++)
            {
                // Tránh vùng biên 1 ô và khu vực giữa (nơi rắn xuất phát)
                int x = _rnd.Next(2, oNgang - 2);
                int y = _rnd.Next(2, oDoc  - 2);

                bool trungRan    = thanRan.Any(td => td.X == x && td.Y == y);
                bool trungMoi    = danhSachMoi.Any(m => m.Vitri.X == x && m.Vitri.Y == y);
                bool trungVatCan = DanhSachVatCan.Any(vc => vc.Vitri.X == x && vc.Vitri.Y == y);

                if (!trungRan && !trungMoi && !trungVatCan)
                    return new ToaDo(x, y);
            }
            return null; // không tìm được chỗ trống
        }
        private ToaDo TimViTriDattuong(int oNgang , int oDoc , List<ToaDo> thanRan,List<Moi> danhSachMoi)
        {
            for (int attempt = 0; attempt < 100; attempt++)
            {
                // Tránh biên và đảm bảo đủ chỗ cho x + 2 ô ngang
                int x = _rnd.Next(2, oNgang - 4);
                int y = _rnd.Next(2, oDoc - 2);
                bool hopLe = true;
                // Kiểm tra cả 3 ô nằm ngang liên tiếp
                for (int dx = 0; dx < 3; dx++)
                {
                    int checkX = x + dx;
                    int checkY = y;
                    bool trungRan = thanRan.Any(td => td.X == checkX && td.Y == checkY);
                    bool trungMoi = danhSachMoi.Any(m => m.Vitri.X == checkX && m.Vitri.Y == checkY);
                    bool trungVatCan = DanhSachVatCan.Any(vc => vc.Vitri.X == checkX && vc.Vitri.Y == checkY);
                    // Kiểm tra tránh vùng xuất phát của rắn (thường ở giữa màn hình)
                    bool ganGiua = Math.Abs(checkX - oNgang / 2) < 4 && Math.Abs(checkY - oDoc / 2) < 4;
                    if (trungRan || trungMoi || trungVatCan || ganGiua)
                    {
                        hopLe = false;
                        break;
                    }
                }
                if (hopLe)
                {
                    return new ToaDo(x, y);
                }
            }
            return null;
        }

        // Định nghĩa sinh vật cản theo độ khó mới
        public void SinhVatCanTheoDoKho(Setting.DoKho doKho, int oNgang, int oDoc)
        {
         
            DanhSachVatCan.Clear();
            ToaDo vitri = TimViTriRanh(oNgang, oDoc, new List<ToaDo>(), new List<Moi>());
            if (doKho == Setting.DoKho.De)
            {
                return;
            }
            else if (doKho == Setting.DoKho.Vua)
            {
                // Vừa: 2 tường, mỗi tường 2 vật cản cố định xếp hàng ngang
                for (int i = 0; i < 2; i++)
                {
                    ToaDo vitriDau = TimViTriTrongChoDoDai(2, oNgang, oDoc, new List<ToaDo>(), new List<Moi>());
                    if (vitriDau == null) break;
                    for (int dx = 0; dx < 2; dx++)
                    {
                        ToaDo vitriO = new ToaDo(vitriDau.X + dx, vitriDau.Y);
                        DanhSachVatCan.Add(new VatCanCoDinh(vitriO, Setting.MauVatCanCoDinh));
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    ToaDo vitriDiChuyen = TimViTriRanh(oNgang, oDoc, new List<ToaDo>(), new List<Moi>());
                    if (vitriDiChuyen == null) break;
                    DanhSachVatCan.Add(new VatCanDiChuyen(vitriDiChuyen, _rnd.Next(2) == 0, Setting.MauVatCanDiChuyen));
                }
            }
            else if (doKho == Setting.DoKho.Kho)
            {
                // Khó: 3 tường, mỗi tường 3 vật cản cố định xếp hàng ngang
                for (int i = 0; i < 3; i++)
                {
                    ToaDo vitriDau = TimViTriTrongChoDoDai(3, oNgang, oDoc, new List<ToaDo>(), new List<Moi>());
                    if (vitriDau == null) break;
                    for (int dx = 0; dx < 3; dx++)
                    {
                        ToaDo vitriO = new ToaDo(vitriDau.X + dx, vitriDau.Y);
                        DanhSachVatCan.Add(new VatCanCoDinh(vitriO, Setting.MauVatCanCoDinh));
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    ToaDo vitriDiChuyen = TimViTriRanh(oNgang, oDoc, new List<ToaDo>(), new List<Moi>());
                    if (vitriDiChuyen == null) break;
                    DanhSachVatCan.Add(new VatCanDiChuyen(vitriDiChuyen, _rnd.Next(2) == 0, Setting.MauVatCanDiChuyen));
                }
            }
        }

        private ToaDo TimViTriTrongChoDoDai(int doDai, int oNgang, int oDoc, List<ToaDo> thanRan, List<Moi> danhSachMoi)
        {
            for (int attempt = 0; attempt < 100; attempt++)
            {
                int x = _rnd.Next(2, oNgang - (doDai + 1));
                int y = _rnd.Next(2, oDoc - 2);
                bool hopLe = true;
                for (int dx = 0; dx < doDai; dx++)
                {
                    int checkX = x + dx;
                    int checkY = y;
                    bool trungRan = thanRan.Any(td => td.X == checkX && td.Y == checkY);
                    bool trungMoi = danhSachMoi.Any(m => m.Vitri.X == checkX && m.Vitri.Y == checkY);
                    bool trungVatCan = DanhSachVatCan.Any(vc => vc.Vitri.X == checkX && vc.Vitri.Y == checkY);
                    bool ganGiua = Math.Abs(checkX - oNgang / 2) < 4 && Math.Abs(checkY - oDoc / 2) < 4;
                    if (trungRan || trungMoi || trungVatCan || ganGiua)
                    {
                        hopLe = false;
                        break;
                    }
                }
                if (hopLe)
                {
                    return new ToaDo(x, y);
                }
            }
            return null;
        }

        // Tự sinh thêm ngẫu nhiên 1 vật cản cố định hoặc 1 vật cản di chuyển
        public void SinhThemMotVatCanNgauNhien(int oNgang, int oDoc, List<ToaDo> thanRan, List<Moi> danhSachMoi)
        {
            const int MAX_VAT_CAN = 30;
            if (DanhSachVatCan.Count >= MAX_VAT_CAN) return;

            ToaDo vitri = TimViTriRanh(oNgang, oDoc, thanRan, danhSachMoi);
            if (vitri == null) return;

            if (_rnd.Next(2) == 0)
            {
                DanhSachVatCan.Add(new VatCanCoDinh(vitri, Setting.MauVatCanCoDinh));
            }
            else
            {
                DanhSachVatCan.Add(new VatCanDiChuyen(vitri, _rnd.Next(2) == 0, Setting.MauVatCanDiChuyen));
            }
        }
    }
}
