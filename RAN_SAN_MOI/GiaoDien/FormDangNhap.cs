using System;
using System.Windows.Forms;

namespace RAN_SAN_MOI
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            // ── Đọc tên cũ từ Settings ──
            string tenCu = Properties.Settings.Default.TenNguoiChoiCu;
            if (!string.IsNullOrEmpty(tenCu))
            {
                txtTen.Text = tenCu;
                chkLuuTen.Checked = true;
                txtTen.SelectAll();
            }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text.Trim();
            if (string.IsNullOrEmpty(ten))
            {
                lblLoi.Text = "Vui lòng nhập tên!";
                lblLoi.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Lưu/xóa tên theo checkbox
            if (chkLuuTen.Checked)
                Setting.TenNguoiChoiCu = ten;
            else
                Setting.TenNguoiChoiCu = "";

            // Đăng nhập DB
            ScoreManager.DangNhapHoacTao(ten);

            // Kiểm tra có game đang lưu không
            var snapshot = ScoreManager.LayTrangThai();
            if (snapshot != null && snapshot.ConHieuLuc)
            {
                // ── Thay MessageBox bằng FormChoiTiep ──
                using (var fChoiTiep = new FormChoiTiep(snapshot))
                {
                    var kq = fChoiTiep.ShowDialog();

                    if (kq == DialogResult.Yes)
                    {
                        // FormChoiTiep đã xử lý (chơi tiếp hoặc ván mới)
                        this.Close();
                        return;
                    }
                    // kq = Cancel (bấm X) → giữ nguyên FormDangNhap, không làm gì
                    return;
                }
            }

            // Không có game lưu → vào menu bình thường
            new FormSetting().Show();
            this.Close();
        }

        private void lblLoi_TextChanged(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormBangXepHang().ShowDialog();
        }

        private void lblLoi_Click(object sender, EventArgs e)
        {

        }
    }
}