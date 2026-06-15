using RAN_SAN_MOI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class SqlGameRepository : IGameRepository
{
    private readonly string _conn = "Data Source=LaptopVision\\SQLEXPRESS;Initial Catalog=SnakeGameDB;Integrated Security=True;TrustServerCertificate=True";

    // ── Đăng nhập hoặc tạo người chơi mới ──
    public NguoiChoiRecord DangNhapHoacTao(string ten)
    {
        SqlConnection sqlCon = new SqlConnection(_conn);
        sqlCon.Open();

        // Kiểm tra tồn tại
        string str = $"SELECT COUNT(*) FROM NguoiChoi WHERE TenNguoiChoi='{ten}'";
        SqlCommand sqlCmd = new SqlCommand(str, sqlCon);
        int count = (int)sqlCmd.ExecuteScalar();

        if (count == 0)
        {
            // Tạo mới
            str = $"INSERT INTO NguoiChoi(TenNguoiChoi) VALUES('{ten}')";
            sqlCmd = new SqlCommand(str, sqlCon);
            sqlCmd.ExecuteNonQuery();
        }
        else
        {
            // Cập nhật lần cuối đăng nhập
            str = $"UPDATE NguoiChoi SET LanCuoiDangNhap=GETDATE() WHERE TenNguoiChoi='{ten}'";
            sqlCmd = new SqlCommand(str, sqlCon);
            sqlCmd.ExecuteNonQuery();
        }

        // Trả về record
        str = $"SELECT * FROM NguoiChoi WHERE TenNguoiChoi='{ten}'";
        sqlCmd = new SqlCommand(str, sqlCon);
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();
        sqlReader.Read();

        NguoiChoiRecord nguoiChoi = new NguoiChoiRecord();
        nguoiChoi.ID = (int)sqlReader["ID"];
        nguoiChoi.TenNguoiChoi = sqlReader["TenNguoiChoi"].ToString();
        nguoiChoi.NgayTao = (DateTime)sqlReader["NgayTao"];
        nguoiChoi.LanCuoiDangNhap = (DateTime)sqlReader["LanCuoiDangNhap"];

        sqlReader.Close();
        sqlCon.Close();

        return nguoiChoi;
    }

    // ── Lưu điểm ──
    public void LuuDiem(ScoreRecord record)
    {
        SqlConnection sqlCon = new SqlConnection(_conn);
        sqlCon.Open();

        string str = $@"INSERT INTO LichSuDiem (NguoiChoiID, Diem, DoKho, ThoiLuong)
                        VALUES({record.NguoiChoiID}, {record.Diem}, '{record.DoKho}', {record.ThoiLuong})";
        SqlCommand sqlCmd = new SqlCommand(str, sqlCon);
        sqlCmd.ExecuteNonQuery();

        sqlCon.Close();
    }

    // ── Bảng xếp hạng ──
    public List<ScoreRecord> LayBangXepHang(int topN = 10)
    {
        SqlConnection sqlCon = new SqlConnection(_conn);
        sqlCon.Open();

        string str = $@"SELECT TOP {topN}
                            n.TenNguoiChoi, l.Diem, l.DoKho, l.ThoiGian
                        FROM LichSuDiem l
                        JOIN NguoiChoi n ON l.NguoiChoiID = n.ID
                        ORDER BY l.Diem DESC";
        SqlCommand sqlCmd = new SqlCommand(str, sqlCon);
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();

        List<ScoreRecord> ds = new List<ScoreRecord>();
        while (sqlReader.Read())
        {
            ScoreRecord score = new ScoreRecord();
            score.TenNguoiChoi = sqlReader["TenNguoiChoi"].ToString();
            score.Diem = (int)sqlReader["Diem"];
            score.DoKho = sqlReader["DoKho"].ToString();
            score.ThoiGian = (DateTime)sqlReader["ThoiGian"];
            ds.Add(score);
        }

        sqlReader.Close();
        sqlCon.Close();

        return ds;
    }

    private void KiemTraVaTaoCotAnhGame(SqlConnection con)
    {
        string checkColSql = @"
            IF NOT EXISTS (
                SELECT * FROM sys.columns 
                WHERE object_id = OBJECT_ID('TrangThaiLuu') AND name = 'AnhGame'
            )
            BEGIN
                ALTER TABLE TrangThaiLuu ADD AnhGame VARBINARY(MAX) NULL;
            END;
            
            IF NOT EXISTS (
                SELECT * FROM sys.columns 
                WHERE object_id = OBJECT_ID('TrangThaiLuu') AND name = 'DuongDanBackground'
            )
            BEGIN
                ALTER TABLE TrangThaiLuu ADD DuongDanBackground NVARCHAR(500) NULL;
            END;";
        using (SqlCommand cmd = new SqlCommand(checkColSql, con))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // ── Lưu trạng thái game ──
    public void LuuTrangThai(TrangThaiGameRecord rec)
    {
        string moi = (rec.DanhSachMoi ?? "").Replace("'", "''");
        string vc = (rec.DanhSachVatCan ?? "").Replace("'", "''");

        SqlConnection sqlCon = new SqlConnection(_conn);
        sqlCon.Open();
        KiemTraVaTaoCotAnhGame(sqlCon);

        string str = $@"
            IF EXISTS (SELECT 1 FROM TrangThaiLuu WHERE NguoiChoiID={rec.NguoiChoiID})
                UPDATE TrangThaiLuu SET
                    DoKho='{rec.DoKho}', DiemHienTai={rec.DiemHienTai},
                    ViTriRan='{rec.ViTriRan}', ChieuDi={rec.ChieuDi},
                    DanhSachMoi='{moi}', DanhSachVatCan='{vc}',
                    ThoiGianLuu=GETDATE(), ConHieuLuc=1,
                    AnhGame=@AnhGame, DuongDanBackground=@DuongDanBackground
                WHERE NguoiChoiID={rec.NguoiChoiID}
            ELSE
                INSERT INTO TrangThaiLuu
                (NguoiChoiID, DoKho, DiemHienTai, ViTriRan,
                 ChieuDi, DanhSachMoi, DanhSachVatCan, ConHieuLuc, AnhGame, DuongDanBackground)
                VALUES({rec.NguoiChoiID}, '{rec.DoKho}', {rec.DiemHienTai}, '{rec.ViTriRan}',
                       {rec.ChieuDi}, '{moi}', '{vc}', 1, @AnhGame, @DuongDanBackground)";
        SqlCommand sqlCmd = new SqlCommand(str, sqlCon);
        sqlCmd.Parameters.Add("@AnhGame", System.Data.SqlDbType.VarBinary).Value = (object)rec.AnhGame ?? DBNull.Value;
        sqlCmd.Parameters.Add("@DuongDanBackground", System.Data.SqlDbType.NVarChar).Value = (object)rec.DuongDanBackground ?? DBNull.Value;
        sqlCmd.ExecuteNonQuery();

        sqlCon.Close();
    }

    // ── Lấy trạng thái đã lưu ──
    public TrangThaiGameRecord LayTrangThai(int nguoiChoiID)
    {
        SqlConnection sqlCon = new SqlConnection(_conn);
        sqlCon.Open();
        KiemTraVaTaoCotAnhGame(sqlCon);

        string str = $"SELECT * FROM TrangThaiLuu WHERE NguoiChoiID={nguoiChoiID} AND ConHieuLuc=1";
        SqlCommand sqlCmd = new SqlCommand(str, sqlCon);
        SqlDataReader sqlReader = sqlCmd.ExecuteReader();

        if (!sqlReader.Read())
        {
            sqlReader.Close();
            sqlCon.Close();
            return null;
        }

        TrangThaiGameRecord trangThai = new TrangThaiGameRecord();
        trangThai.ID = (int)sqlReader["ID"];
        trangThai.NguoiChoiID = (int)sqlReader["NguoiChoiID"];
        trangThai.DoKho = sqlReader["DoKho"].ToString();
        trangThai.DiemHienTai = (int)sqlReader["DiemHienTai"];
        trangThai.ViTriRan = sqlReader["ViTriRan"].ToString();
        trangThai.ChieuDi = (int)sqlReader["ChieuDi"];
        trangThai.DanhSachMoi = sqlReader["DanhSachMoi"].ToString();
        trangThai.DanhSachVatCan = sqlReader["DanhSachVatCan"].ToString();
        trangThai.ThoiGianLuu = (DateTime)sqlReader["ThoiGianLuu"];
        trangThai.ConHieuLuc = (bool)sqlReader["ConHieuLuc"];

        int anhGameColOrdinal = sqlReader.GetOrdinal("AnhGame");
        if (!sqlReader.IsDBNull(anhGameColOrdinal))
        {
            trangThai.AnhGame = (byte[])sqlReader["AnhGame"];
        }
        else
        {
            trangThai.AnhGame = null;
        }

        int bgColOrdinal = sqlReader.GetOrdinal("DuongDanBackground");
        if (!sqlReader.IsDBNull(bgColOrdinal))
        {
            trangThai.DuongDanBackground = sqlReader["DuongDanBackground"].ToString();
        }
        else
        {
            trangThai.DuongDanBackground = null;
        }

        sqlReader.Close();
        sqlCon.Close();

        return trangThai;
    }

    // ── Xóa slot lưu ──
    public void XoaTrangThai(int nguoiChoiID)
    {
        SqlConnection sqlCon = new SqlConnection(_conn);
        sqlCon.Open();

        string str = $"UPDATE TrangThaiLuu SET ConHieuLuc=0 WHERE NguoiChoiID={nguoiChoiID}";
        SqlCommand sqlCmd = new SqlCommand(str, sqlCon);
        sqlCmd.ExecuteNonQuery();

        sqlCon.Close();
    }
    public void XoaTatCaDiem()
    {
        using (var con = new SqlConnection(_conn))
        {
            con.Open();
            new SqlCommand("DELETE FROM LichSuDiem", con).ExecuteNonQuery();
        }
    }
}