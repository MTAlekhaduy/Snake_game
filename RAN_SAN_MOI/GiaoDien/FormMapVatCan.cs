using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static RAN_SAN_MOI.Moi;
using static RAN_SAN_MOI.Setting;

namespace RAN_SAN_MOI
{
    public partial class FormMapVatCan : Form
    {
        private QuanLyVatCan _quanLyVatCan;
        private QuanLyRan QuanLyRan;
        private QuanLyMoi QuanLyMoi;
        private int oNgang;
        private int oDoc;
        private int Diemso = 0;
        private bool Tamdung = false;
        private bool isGameOver = false;
        private Rectangle _normalBounds;

        public FormMapVatCan()
        {
            InitializeComponent();
            this.FormClosing += FormMapVatCan_FormClosing;
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape &&
                    this.FormBorderStyle == FormBorderStyle.None)
                    ExitFullscreen();
            };

            typeof(PictureBox)
                .GetProperty("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(picGame, true, null);

            picGame.Dock = DockStyle.Fill;
            this.Resize += FormMapVatCan_Resize;
            btnTamDung.BringToFront();
            btnThoat.BringToFront();
            lblDiem.BringToFront();

            _quanLyVatCan = new QuanLyVatCan();
        }

        private void EnterFullscreen()
        {
            if (this.FormBorderStyle != FormBorderStyle.None)
                _normalBounds = this.Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;
            this.Bounds = Screen.FromControl(this).Bounds;
            this.TopMost = true;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            picGame.Dock = DockStyle.Fill;
        }

        private void ExitFullscreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = false;
            if (_normalBounds != Rectangle.Empty)
                this.Bounds = _normalBounds;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ToggleFullscreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
                ExitFullscreen();
            else
                EnterFullscreen();
        }

      
        private void FormMapVatCan_Load(object sender, EventArgs e)
        {
            oNgang = picGame.Width / Setting.Rong;
            oDoc = picGame.Height / Setting.Cao;

            QuanLyRan = new QuanLyRan();
            QuanLyMoi = new QuanLyMoi();

            TrangThaiGameRecord snapshot = this.Tag as TrangThaiGameRecord;
            if (snapshot != null)
            {
                Diemso = snapshot.DiemHienTai;
                lblDiem.Text = "Điểm Hiện Tại : " + Diemso;
                QuanLyRan.ThanRan = TrangThaiGameRecord.DeserializeRan(snapshot.ViTriRan);
                QuanLyRan.HuongHienTai = TrangThaiGameRecord.IntToHuong(snapshot.ChieuDi);
                QuanLyMoi.DanhSachMoi = TrangThaiGameRecord.DeserializeMoi(snapshot.DanhSachMoi);
                _quanLyVatCan.DanhSachVatCan =
                    TrangThaiGameRecord.DeserializeVatCan(snapshot.DanhSachVatCan);

                if (!string.IsNullOrEmpty(snapshot.DuongDanBackground) && System.IO.File.Exists(snapshot.DuongDanBackground))
                {
                    Setting.BackgroundDangChon = new Setting.BackgroundRecord
                    {
                        TenHienThi = System.IO.Path.GetFileNameWithoutExtension(snapshot.DuongDanBackground),
                        DuongDanFile = snapshot.DuongDanBackground,
                        Loai = snapshot.DuongDanBackground.Contains("NSX") ? Setting.LoaiBackground.NhaSanXuat : Setting.LoaiBackground.MayTinh
                    };
                }
            }
            else
            {
                QuanLyRan.KhoiTao();
                QuanLyMoi.SinhMoi(oNgang, oDoc, QuanLyRan.ThanRan);
                lblDiem.Text = "Điểm Hiện Tại : 0";
                _quanLyVatCan.SinhVatCanMacDinh(oNgang, oDoc);
            }

            if (Setting.BackgroundDangChon != null &&
                System.IO.File.Exists(Setting.BackgroundDangChon.DuongDanFile))
            {
                byte[] data = System.IO.File.ReadAllBytes(
                    Setting.BackgroundDangChon.DuongDanFile);
                using (var ms = new System.IO.MemoryStream(data))
                    picGame.BackgroundImage = Image.FromStream(ms);
                picGame.BackgroundImageLayout = ImageLayout.Stretch;
            }

            QuanLyAmThanh.KhoiTao();
            QuanLyAmThanh.PhatNhacNen();
            GameTimer.Interval = Setting.LayIntervalTheoTocDo();
            GameTimer.Start();
        }

        private void FormMapVatCan_Resize(object sender, EventArgs e)
        {
            oNgang = picGame.Width / Setting.Rong;
            oDoc = picGame.Height / Setting.Cao;
            if (QuanLyMoi != null)
                QuanLyMoi.CapNhatMoiKhiResize(oNgang, oDoc);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.D:
                    if (QuanLyRan.HuongHienTai != HuongDiChuyen.Trai)
                        QuanLyRan.HuongHienTai = HuongDiChuyen.Phai;
                    return true;
                case Keys.Left:
                case Keys.A:
                    if (QuanLyRan.HuongHienTai != HuongDiChuyen.Phai)
                        QuanLyRan.HuongHienTai = HuongDiChuyen.Trai;
                    return true;
                case Keys.Up:
                case Keys.W:
                    if (QuanLyRan.HuongHienTai != HuongDiChuyen.Xuong)
                        QuanLyRan.HuongHienTai = HuongDiChuyen.Len;
                    return true;
                case Keys.Down:
                case Keys.S:
                    if (QuanLyRan.HuongHienTai != HuongDiChuyen.Len)
                        QuanLyRan.HuongHienTai = HuongDiChuyen.Xuong;
                    return true;
                case Keys.Tab:
                    ToggleFullscreen();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            QuanLyRan.Dichuyen(oNgang, oDoc);

            if (QuanLyRan.CanVaoDuoi())
            { GameTimer.Stop(); GameOver(); return; }

            if (_quanLyVatCan.KiemTraVaCham(QuanLyRan.Head))
            { GameTimer.Stop(); GameOver(); return; }

            QuanLyMoi.CapNhatTatCaMoi(oNgang, oDoc);
            _quanLyVatCan.CapNhatTatCaVatCan(oNgang, oDoc);

            Moi moiBiAn = QuanLyMoi.KiemTraVaLayMoi(QuanLyRan.Head);
            if (moiBiAn != null)
            {
                ApDungHieuUng(moiBiAn);
                QuanLyAmThanh.PhatAnMoi();
                Diemso += moiBiAn.DiemThuong;
                if (Diemso < 0) Diemso = 0;
                lblDiem.Text = "Điểm Hiện Tại : " + Diemso;
                QuanLyMoi.SinhMoi(oNgang, oDoc, QuanLyRan.ThanRan);
            }

            picGame.Invalidate();
        }

        private void ApDungHieuUng(Moi moi)
        {
            switch (moi.LayHieuUng())
            {
                case HieuUngMoi.DaiThem1: QuanLyRan.DaiThem(); break;
                case HieuUngMoi.ToBonSection:
                    for (int i = 0; i < 4; i++) QuanLyRan.DaiThem();
                    break;
                case HieuUngMoi.PhanThan: QuanLyRan.DaiThem(); break;
                case HieuUngMoi.TangKichThuoc:
                    QuanLyRan.TangKichThuoc();
                    QuanLyRan.DaiThem();
                    break;
                case HieuUngMoi.TruDiem:
                case HieuUngMoi.KhongCo:
                default: break;
            }
        }

        private void VeHinhTronGoc(Graphics g, Brush brush,
            int x, int y, int w, int h, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, radius, radius, 180, 90);
            path.AddArc(x + w - radius, y, radius, radius, 270, 90);
            path.AddArc(x + w - radius, y + h - radius, radius, radius, 0, 90);
            path.AddArc(x, y + h - radius, radius, radius, 90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }

        private void picGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var moi in QuanLyMoi.DanhSachMoi)
                moi.Ve(g, Setting.Rong, Setting.Cao);

            foreach (var vc in _quanLyVatCan.DanhSachVatCan)
                vc.Ve(g, Setting.Rong, Setting.Cao);

            for (int i = 0; i < QuanLyRan.ThanRan.Count; i++)
            {
                Color mau = (i == 0) ? Setting.MauDauRan : Setting.MauThanRan;
                int x = QuanLyRan.ThanRan[i].X * Setting.Rong;
                int y = QuanLyRan.ThanRan[i].Y * Setting.Cao;
                int radius = (i == 0) ? 10 : 6;

                VeHinhTronGoc(g, new SolidBrush(mau),
                    x, y, Setting.Rong, Setting.Cao, radius);

                if (i == 0)
                {
                    int eyeSize = Setting.KichThuocMui;
                    int ox = Setting.Rong / 4;
                    int oy = Setting.Cao / 4;
                    Rectangle matTrai = new Rectangle(x + ox, y + oy, eyeSize, eyeSize);
                    Rectangle matPhai = new Rectangle(
                        x + Setting.Rong - ox - eyeSize, y + oy, eyeSize, eyeSize);

                    g.FillEllipse(Brushes.Red, matTrai);
                    g.FillEllipse(Brushes.Red, matPhai);

                    int ps = eyeSize / 2;
                    g.FillEllipse(new SolidBrush(Setting.MauMui),
                        new Rectangle(matTrai.X + eyeSize / 4, matTrai.Y + eyeSize / 4, ps, ps));
                    g.FillEllipse(new SolidBrush(Setting.MauMui),
                        new Rectangle(matPhai.X + eyeSize / 4, matPhai.Y + eyeSize / 4, ps, ps));
                }
            }
        }

        private void TamDung()
        {
            Tamdung = !Tamdung;
            if (Tamdung) { GameTimer.Stop(); QuanLyAmThanh.DungNhacNen(); }
            else { GameTimer.Start(); QuanLyAmThanh.PhatNhacNen(); }
        }

        // ════════════════════════════════════════════
        // GAME OVER — thêm ScoreManager
        // ════════════════════════════════════════════
        private void GameOver()
        {
            isGameOver = true;
            QuanLyAmThanh.DungNhacNen();
            QuanLyAmThanh.PhatChet();

            if (Diemso > Setting.High_score)
                Setting.High_score = Diemso;

            // ← Thêm 2 dòng này
            ScoreManager.LuuDiem(Diemso, Setting.DoKhoDaChon.ToString());
            ScoreManager.XoaTrangThaiLuu();

            using (FormGameOver f = new FormGameOver())
            {
                DialogResult kq = f.ShowDialog();
                if (kq == DialogResult.Yes)
                {
                    Diemso = 0;
                    lblDiem.Text = "Điểm Hiện Tại : 0";
                    QuanLyRan.KhoiTao();
                    QuanLyMoi.DanhSachMoi.Clear();
                    QuanLyMoi.SinhMoi(oNgang, oDoc, QuanLyRan.ThanRan);
                    _quanLyVatCan.SinhVatCanMacDinh(oNgang, oDoc);
                    QuanLyAmThanh.PhatNhacNen();
                    GameTimer.Start();
                    isGameOver = false;
                }
                else
                {
                    new FormSelectLevelMap().Show();
                    this.Close();
                }
            }
        }

        // ════════════════════════════════════════════
        // THOÁT — thêm hỏi lưu game
        // ════════════════════════════════════════════
        private void XuLyThoatGame()
        {
            GameTimer.Stop();
            QuanLyAmThanh.DungNhacNen();
            new FormSelectLevelMap().Show();
            this.Close();
        }

        private byte[] ChupManHinhGame()
        {
            using (var bmp = new Bitmap(picGame.Width, picGame.Height))
            {
                picGame.DrawToBitmap(bmp, new Rectangle(0, 0, picGame.Width, picGame.Height));
                using (var ms = new System.IO.MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        private void FormMapVatCan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isGameOver && QuanLyRan != null && QuanLyRan.ThanRan != null && QuanLyRan.ThanRan.Count > 0)
            {
                var snapshot = new TrangThaiGameRecord
                {
                    DoKho = "VatCan",
                    DiemHienTai = Diemso,
                    ViTriRan = TrangThaiGameRecord.SerializeRan(QuanLyRan.ThanRan),
                    ChieuDi = TrangThaiGameRecord.HuongToInt(QuanLyRan.HuongHienTai),
                    DanhSachMoi = TrangThaiGameRecord.SerializeMoi(QuanLyMoi.DanhSachMoi),
                    DanhSachVatCan = TrangThaiGameRecord.SerializeVatCan(_quanLyVatCan.DanhSachVatCan),
                    AnhGame = ChupManHinhGame(),
                    DuongDanBackground = Setting.BackgroundDangChon?.DuongDanFile ?? ""
                };
                ScoreManager.LuuTrangThai(snapshot);
            }
        }

        private void btnTamDung_Click(object sender, EventArgs e) => TamDung();
        private void lblDiem_Click(object sender, EventArgs e) { }
        private void picGame_Resize(object sender, EventArgs e) { }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            XuLyThoatGame(); // ← đổi ở đây
        }

        private void FormMapVatCan_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuanLyAmThanh.DungNhacNen();
            QuanLyAmThanh.Dispose();
        }
    }
}