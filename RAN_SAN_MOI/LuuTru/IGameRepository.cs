using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAN_SAN_MOI
{
    public interface IGameRepository
    {
        // Người chơi
        NguoiChoiRecord DangNhapHoacTao(string tenNguoiChoi);

        // Điểm
        void LuuDiem(ScoreRecord record);
        List<ScoreRecord> LayBangXepHang(int topN = 10);

        // Trạng thái game
        void LuuTrangThai(TrangThaiGameRecord record);
        TrangThaiGameRecord LayTrangThai(int nguoiChoiID);
        void XoaTrangThai(int nguoiChoiID);
        void XoaTatCaDiem();
    }
}
