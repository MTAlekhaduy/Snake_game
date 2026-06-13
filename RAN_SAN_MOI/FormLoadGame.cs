using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static RAN_SAN_MOI.Moi;
using static RAN_SAN_MOI.Setting;
using System.IO;
namespace RAN_SAN_MOI
{
    public partial class FormLoadGame : Form
    {
        protected QuanLyVatCan _quanLyVatCan; // Obstacle manager
        protected QuanLyRan QuanLyRan;
        protected QuanLyMoi QuanLyMoi;
        protected int oNgang;
        protected int oDoc;
        protected int Diemso = 0;
        protected bool Tamdung = false;

        public FormLoadGame()
        {
            InitializeComponent();
            // Existing setup
            this.KeyPreview = true;                    // capture Esc key
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape && this.FormBorderStyle == FormBorderStyle.None)
                {
                    ExitFullscreen();
                }
            };

            typeof(PictureBox).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(picGame, true, null);

            picGame.Dock = DockStyle.Fill;
            // Subscribe to resize event to recalc grid size
            this.Resize += FormLoadGame_Resize;
            // Ensure UI controls stay on top after fullscreen setup
            button1.BringToFront();
            btnTamDung.BringToFront();
            panel1.BringToFront();

            // Initialize obstacle manager (no obstacles for this map)
            _quanLyVatCan = new QuanLyVatCan();
        }

        private Rectangle _normalBounds;

    
        private void EnterFullscreen()
        {
            // Save current bounds if not already in fullscreen
            if (this.FormBorderStyle != FormBorderStyle.None)
                _normalBounds = this.Bounds;

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal; // allow setting bounds
            var screen = Screen.FromControl(this);
            this.Bounds = screen.Bounds;
            this.TopMost = true;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            // Ensure the picture box fills the client area
            picGame.Dock = DockStyle.Fill;
        }

       
        private void ExitFullscreen()
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = false;
            // Restore previous bounds
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
        private void FormLoadGame_Resize(object sender, EventArgs e)
        {
           
            oNgang = picGame.Width / Setting.Rong;
            oDoc = picGame.Height / Setting.Cao;
            
            if (QuanLyMoi != null)
                QuanLyMoi.CapNhatMoiKhiResize(oNgang, oDoc);
        }

    
        protected virtual void FormLoadGame_Load(object sender, EventArgs e)
        {

            oNgang = picGame.Width / Setting.Rong;
            oDoc = picGame.Height / Setting.Cao;

            QuanLyRan = new QuanLyRan();
            QuanLyRan.KhoiTao();
            QuanLyMoi = new QuanLyMoi();

            QuanLyMoi.SinhMoi(oNgang, oDoc, QuanLyRan.ThanRan);
            lblDiem.Text = "Điểm Hiện Tại : 0";

            // Áp dụng background đã chọn
            if (Setting.BackgroundDangChon != null &&
                File.Exists(Setting.BackgroundDangChon.DuongDanFile))
            {
                byte[] data = File.ReadAllBytes(Setting.BackgroundDangChon.DuongDanFile);
                using (var ms = new System.IO.MemoryStream(data))
                    picGame.BackgroundImage = Image.FromStream(ms);

                picGame.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                picGame.BackgroundImage = null;  // dùng màu BackColor mặc định
            }
            QuanLyAmThanh.KhoiTao();
            QuanLyAmThanh.PhatNhacNen();

            GameTimer.Interval = 90;
            GameTimer.Start();

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
            {
                GameTimer.Stop();
                GameOver();
                return;
            }

            // Check collision with obstacles (if any)
            if (_quanLyVatCan != null && _quanLyVatCan.KiemTraVaCham(QuanLyRan.Head))
            {
                GameTimer.Stop();
                GameOver();
                return;
            }

            // Cập nhật mồi di chuyển/nhấp nháy
            QuanLyMoi.CapNhatTatCaMoi(oNgang, oDoc);

            // Cập nhật vật cản di chuyển (nếu có)
            if (_quanLyVatCan != null)
                _quanLyVatCan.CapNhatTatCaVatCan(oNgang, oDoc);

            // Kiểm tra ăn mồi
            Moi moiBiAn = QuanLyMoi.KiemTraVaLayMoi(QuanLyRan.Head);
            if (moiBiAn != null)
            {
                ApDungHieuUng(moiBiAn);
                QuanLyAmThanh.PhatAnMoi();

                // Cộng điểm (không xuống dưới 0)
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
                case HieuUngMoi.DaiThem1:
                    QuanLyRan.DaiThem();
                    break;

                case HieuUngMoi.ToBonSection:
                    for (int i = 0; i < 4; i++)
                        QuanLyRan.DaiThem();
                  
                    break;

                case HieuUngMoi.TruDiem:
                    
                    break;

                case HieuUngMoi.PhanThan:
                    
                    QuanLyRan.DaiThem();
                    break;
                case HieuUngMoi.TangKichThuoc:
                    QuanLyRan.TangKichThuoc();
                    QuanLyRan.DaiThem();
                    break;
                case HieuUngMoi.KhongCo:
                default:
                    break;
            }
        }
        private void VeHinhTronGoc(Graphics g, Brush brush, int x, int y, int w, int h, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
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

            // Vẽ mồi — mỗi loại tự vẽ hình dạng riêng
            foreach (var moi in QuanLyMoi.DanhSachMoi)
                moi.Ve(g, Setting.Rong, Setting.Cao);

            // Vẽ vật cản (nếu có)
            if (_quanLyVatCan != null)
            {
                foreach (var vc in _quanLyVatCan.DanhSachVatCan)
                    vc.Ve(g, Setting.Rong, Setting.Cao);
            }



            for (int i = 0; i < QuanLyRan.ThanRan.Count; i++)
            {
                Color mau = (i == 0) ? Setting.MauDauRan : Setting.MauThanRan;
                int x = QuanLyRan.ThanRan[i].X * Setting.Rong;
                int y = QuanLyRan.ThanRan[i].Y * Setting.Cao;
                int w = Setting.Rong;
                int h = Setting.Cao;
                int radius = (i == 0) ? 10 : 6; // đầu bo tròn nhiều hơn thân

                VeHinhTronGoc(g, new SolidBrush(mau), x, y, w, h, radius);

                // Vẽ mắt ở đầu
                if (i == 0)
                {
                    int eyeSize = Setting.KichThuocMui;
                    int offsetX = w / 4;
                    int offsetY = h / 4;

                    Rectangle leftEye = new Rectangle(x + offsetX, y + offsetY, eyeSize, eyeSize);
                    Rectangle rightEye = new Rectangle(x + w - offsetX - eyeSize, y + offsetY, eyeSize, eyeSize);

                    g.FillEllipse(Brushes.Red, leftEye);
                    g.FillEllipse(Brushes.Red, rightEye);

                    int pupilSize = eyeSize / 2;
                    g.FillEllipse(new SolidBrush(Setting.MauMui),
                        new Rectangle(leftEye.X + eyeSize / 4, leftEye.Y + eyeSize / 4, pupilSize, pupilSize));
                    g.FillEllipse(new SolidBrush(Setting.MauMui),
                        new Rectangle(rightEye.X + eyeSize / 4, rightEye.Y + eyeSize / 4, pupilSize, pupilSize));
                }
            }

        }

        private void TamDung()
        {
            Tamdung = !Tamdung;
            if (Tamdung)
            {
                GameTimer.Stop();
              
                QuanLyAmThanh.DungNhacNen();
            }
            else
            {
                GameTimer.Start();
             
                QuanLyAmThanh.PhatNhacNen();
            }
        }

        private void GameOver()
        {
            QuanLyAmThanh.DungNhacNen();
            QuanLyAmThanh.PhatChet();

            if (Diemso > Setting.High_score)
                Setting.High_score = Diemso;
            QuanLyDuLieu.LuuDiem(new BanGhiDiem
            {
                TenNguoiChoi = Setting.TenNguoiChoi,
                Diem = Diemso,
                DoKho = Setting.DoKhoDaChon.ToString(),
                ThoiGian = DateTime.Now
            });
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
                    QuanLyAmThanh.PhatNhacNen();
                    GameTimer.Start();
                }
                else 
                {
                    FormSelectLevelMap f1 = new FormSelectLevelMap();
                    f1.Show();
                    this.Close();
                }
            }
        }

        private void FormLoadGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            QuanLyAmThanh.DungNhacNen();
            QuanLyAmThanh.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TamDung();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           FormSetting f=new FormSetting();
            this.Close();
            f.Show();
        }
    }
}