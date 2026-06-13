using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAN_SAN_MOI
{
    public partial class FormSelectBackground : Form
    {
        private Setting.BackgroundRecord _tamChon = null;
        public FormSelectBackground()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FormSelectBackground_Load(object sender, EventArgs e)
        {
            NapTabNSX();
            NapTabGanNhat();
            KhoiPhucLuaChonCu();
        }
        private void NapTabNSX()
        {

            lstBackgroundNSX.Items.Clear();
            string folder = Setting.GetFolderNSX();
            if (!Directory.Exists(folder))
            {
                lstBackgroundNSX.Items.Add("( Chưa có ảnh nào trong folder NSX )");
                return;
            }

            string[] files = Directory.GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string f in files)
            {
                string ext = Path.GetExtension(f).ToLower();
                if (ext == ".png" || ext == ".jpg" ||
                    ext == ".jpeg" || ext == ".bmp" || ext == ".gif")
                {
                    lstBackgroundNSX.Items.Add(Path.GetFileNameWithoutExtension(f));
                }
            }
            if (Setting.BackgroundDangChon?.Loai == Setting.LoaiBackground.NhaSanXuat)
            {
                string tenDang = Path.GetFileNameWithoutExtension(
                    Setting.BackgroundDangChon.DuongDanFile);
                int idx = lstBackgroundNSX.Items.IndexOf(tenDang);
                if (idx >= 0) lstBackgroundNSX.SelectedIndex = idx;
            }
            else if (lstBackgroundNSX.Items.Count > 0)
            {
                lstBackgroundNSX.SelectedIndex = 0;
            }
        }
        private void lstBackgroundNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ten = lstBackgroundNSX.SelectedItem?.ToString();
            if (ten == null || ten.StartsWith("(")) return;

            string folder = Setting.GetFolderNSX();
            string duongDan = TimFileAnh(folder, ten);
            if (duongDan == null) return;

            HienThiPreview(picPreviewNSX, duongDan);
            lblTenNSX.Text = ten;

            _tamChon = new Setting.BackgroundRecord
            {
                TenHienThi = ten,
                DuongDanFile = duongDan,
                Loai = Setting.LoaiBackground.NhaSanXuat
            };
            CapNhatThanhDangChon(_tamChon);
        }

        private void btnDuyetFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh background";
                ofd.Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp|Tất cả|*.*";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                string nguon = ofd.FileName;

                // Copy vào folder NguoiDung
                string tenFile = Path.GetFileName(nguon);
                string dich = Path.Combine(Setting.GetFolderNguoiDung(), tenFile);

                // Nếu trùng tên thì đổi tên tránh ghi đè
                if (File.Exists(dich) && dich != nguon)
                {
                    string tenKhongExt = Path.GetFileNameWithoutExtension(tenFile);
                    string ext = Path.GetExtension(tenFile);
                    dich = Path.Combine(Setting.GetFolderNguoiDung(),
                        tenKhongExt + "_" + DateTime.Now.Ticks + ext);
                }

                try
                {
                    if (nguon != dich) File.Copy(nguon, dich);
                    txtDuongDan.Text = dich;
                    HienThiPreview(picPreviewLocal, dich);

                    _tamChon = new Setting.BackgroundRecord
                    {
                        TenHienThi = Path.GetFileNameWithoutExtension(dich),
                        DuongDanFile = dich,
                        Loai = Setting.LoaiBackground.MayTinh
                    };
                    CapNhatThanhDangChon(_tamChon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi copy file: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTaiVe_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL ảnh.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblTrangThaiURL.Text = "Đang tải...";
            lblTrangThaiURL.ForeColor = Color.Gray;
            pbTaiVe.Visible = true;
            pbTaiVe.Style = ProgressBarStyle.Marquee;
            btnTaiVe.Enabled = false;

            var worker = new System.ComponentModel.BackgroundWorker();
            worker.DoWork += (s, ev) =>
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "Mozilla/5.0");
                    byte[] data = wc.DownloadData((string)ev.Argument);
                    ev.Result = data;
                }
            };
            worker.RunWorkerCompleted += (s, ev) =>
            {
                pbTaiVe.Visible = false;
                btnTaiVe.Enabled = true;

                if (ev.Error != null)
                {
                    lblTrangThaiURL.Text = "❌ " + ev.Error.Message;
                    lblTrangThaiURL.ForeColor = Color.Red;
                    return;
                }

                try
                {
                    byte[] data = (byte[])ev.Result;

                    // Lưu vào folder NguoiDung
                    string tenFile = "internet_" + DateTime.Now.Ticks + ".png";
                    string dich = Path.Combine(Setting.GetFolderNguoiDung(), tenFile);

                    File.WriteAllBytes(dich, data);

                    HienThiPreview(picPreviewURL, dich);
                    lblTrangThaiURL.Text = $"✔ Tải xong — {data.Length / 1024} KB";
                    lblTrangThaiURL.ForeColor = Color.Green;

                    _tamChon = new Setting.BackgroundRecord
                    {
                        TenHienThi = tenFile,
                        DuongDanFile = dich,
                        Loai = Setting.LoaiBackground.Internet
                    };
                    CapNhatThanhDangChon(_tamChon);
                }
                catch (Exception ex)
                {
                    lblTrangThaiURL.Text = "❌ Không phải ảnh hợp lệ: " + ex.Message;
                    lblTrangThaiURL.ForeColor = Color.Red;
                }
            };
            worker.RunWorkerAsync(url);
        }
        private void NapTabGanNhat()
        {
            lvGanNhat.Items.Clear();
            lvGanNhat.View = View.Details;
            lvGanNhat.FullRowSelect = true;
            lvGanNhat.GridLines = true;

            if (lvGanNhat.Columns.Count == 0)
            {
                lvGanNhat.Columns.Add("Tên", 190);
                lvGanNhat.Columns.Add("Nguồn", 80);
                lvGanNhat.Columns.Add("Lần cuối", 120);
            }

            foreach (var r in Setting.LichSuBackground)
            {
                string ten = r.TenHienThi.Length > 30
                    ? r.TenHienThi.Substring(0, 27) + "..." : r.TenHienThi;

                string nguon = r.Loai == Setting.LoaiBackground.NhaSanXuat ? "NSX"
                             : r.Loai == Setting.LoaiBackground.MayTinh ? "Máy tính"
                             : "Internet";

                var item = new ListViewItem(ten);
                item.SubItems.Add(nguon);
                item.SubItems.Add(r.ThoiGian.ToString("dd/MM/yy HH:mm"));
                item.Tag = r;
                lvGanNhat.Items.Add(item);
            }

            bool coLichSu = lvGanNhat.Items.Count > 0;
            btnDungLai.Enabled = false;
            btnXoaLichSu.Enabled = false;

            if (!coLichSu)
            {
                lblTenGanNhat.Text = "Chưa có lịch sử";
                lblNguonGanNhat.Text = "";
                lblThoiGianGanNhat.Text = "";
            }
        }

        private void lvGanNhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGanNhat.SelectedItems.Count == 0) return;

            var r = (Setting.BackgroundRecord)lvGanNhat.SelectedItems[0].Tag;

            lblTenGanNhat.Text = r.TenHienThi;
            lblNguonGanNhat.Text = "Nguồn: " +
                (r.Loai == Setting.LoaiBackground.NhaSanXuat ? "Nhà sản xuất"
               : r.Loai == Setting.LoaiBackground.MayTinh ? "Máy tính cá nhân"
               : "Internet");
            lblThoiGianGanNhat.Text = "Lần cuối: " +
                r.ThoiGian.ToString("dd/MM/yyyy HH:mm");

            btnDungLai.Enabled = true;
            btnXoaLichSu.Enabled = true;

            HienThiPreview(picPreviewGanNhat, r.DuongDanFile);
        }

        private void btnDungLai_Click(object sender, EventArgs e)
        {
            if (lvGanNhat.SelectedItems.Count == 0) return;
            _tamChon = (Setting.BackgroundRecord)lvGanNhat.SelectedItems[0].Tag;
            CapNhatThanhDangChon(_tamChon);
            MessageBox.Show($"Đã chọn: {_tamChon.TenHienThi}\nNhấn Xác nhận để áp dụng.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaLichSu_Click(object sender, EventArgs e)
        {
            if (lvGanNhat.SelectedItems.Count == 0) return;
            var r = (Setting.BackgroundRecord)lvGanNhat.SelectedItems[0].Tag;
            Setting.LichSuBackground.Remove(r);
            NapTabGanNhat();
        }
        private void CapNhatThanhDangChon(Setting.BackgroundRecord r)
        {
            lblDangChonTen.Text = r.TenHienThi;
            lblDangChonNguon.Text = "Nguồn: " +
                (r.Loai == Setting.LoaiBackground.NhaSanXuat ? "Nhà sản xuất"
               : r.Loai == Setting.LoaiBackground.MayTinh ? "Máy tính"
               : "Internet");
            HienThiPreview(picThumbDangChon, r.DuongDanFile);
        }

        private void pnlDangChon_Paint(object sender, PaintEventArgs e)
        {
            // Do nothing
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void HienThiPreview(PictureBox pic, string duongDan)
        {
            if (!File.Exists(duongDan))
            {
                pic.Image = null;
                return;
            }
            try
            {
                // Load vào MemoryStream để không lock file gốc
                byte[] data = File.ReadAllBytes(duongDan);
                using (var ms = new MemoryStream(data))
                {
                    Image imgMoi = Image.FromStream(ms);
                    if (pic.Image != null) pic.Image.Dispose();
                    pic.Image = imgMoi;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                pic.Image = null;
            }
        }

        // Tìm file ảnh theo tên (không có extension)
        private string TimFileAnh(string folder, string tenKhongExt)
        {
            foreach (string ext in new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" })
            {
                string path = Path.Combine(folder, tenKhongExt + ext);
                if (File.Exists(path)) return path;
            }
            return null;
        }

        // Khi mở lại form: highlight lại lựa chọn cũ
        private void KhoiPhucLuaChonCu()
        {
            if (Setting.BackgroundDangChon == null) return;
            _tamChon = Setting.BackgroundDangChon;
            CapNhatThanhDangChon(_tamChon);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (_tamChon == null)
            {
                MessageBox.Show("Vui lòng chọn 1 background.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu vào Setting
            Setting.BackgroundDangChon = _tamChon;
            Setting.LuuLichSu(_tamChon);

            // Gán ảnh vào picGame của các form game
            // (form game sẽ tự đọc Setting.BackgroundDangChon khi Load)

            this.DialogResult = DialogResult.OK;
            FormSetting f = new FormSetting();
            f.Show();
            this.Close();

        }
    }
}


