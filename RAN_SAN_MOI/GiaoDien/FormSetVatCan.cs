using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAN_SAN_MOI
{
    public partial class FormSetVatCan : Form
    {
        public FormSetVatCan()
        {
            InitializeComponent();
            rdbCoDinh.CheckedChanged += CheDo_CheckedChanged;
            rdbDiChuyen.CheckedChanged += CheDo_CheckedChanged;
            rdbNgauNhien.CheckedChanged += CheDo_CheckedChanged;
        }

        private void CheDo_CheckedChanged(object sender, EventArgs e)
        {
            picAnhHienThi.Invalidate();
        }

        private void btnMauCoDinh_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = btnMauCoDinh.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                btnMauCoDinh.BackColor = dlg.Color;
                picAnhHienThi.Invalidate(); // Vẽ lại preview với màu mới
            }
        }

        private void btnMauDiChuyen_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = btnMauDiChuyen.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                btnMauDiChuyen.BackColor = dlg.Color;
                picAnhHienThi.Invalidate(); // Vẽ lại preview với màu mới
            }
        }

        private void btnMauNgauNhien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chế độ ngẫu nhiên sẽ sử dụng cả Vật cản Cố định và Di chuyển!");
        }

        private void FormSetVatCan_Load(object sender, EventArgs e)
        {
            txtSoLuongTuong.Text = Setting.SoLuongTuongVatCan.ToString();
            btnMauCoDinh.BackColor = Setting.MauVatCanCoDinh;
            btnMauDiChuyen.BackColor = Setting.MauVatCanDiChuyen;
            if (Setting.CheDoVatCanDaChon == Setting.CheDoVatCan.CoDinh)
                rdbCoDinh.Checked = true;
            else if (Setting.CheDoVatCanDaChon == Setting.CheDoVatCan.DiChuyen)
                rdbDiChuyen.Checked = true;
            else
                rdbNgauNhien.Checked = true;
            picAnhHienThi.Invalidate();
        }

        private void picAnhHienThi_Click(object sender, EventArgs e)
        {

        }

        private void picAnhHienThi_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.DarkSlateGray); // Màu nền của khung preview
            // Tính toán kích thước ô vẽ thử nghiệm (ví dụ 40x40 pixel cho rõ nét)
            int size = 40;
            int startX = (picAnhHienThi.Width - (size * 3 + 20)) / 2; // Căn giữa 3 ô
            int startY = (picAnhHienThi.Height - size) / 2;
            Color mauCoDinh = btnMauCoDinh.BackColor;
            Color mauDiChuyen = btnMauDiChuyen.BackColor;
            // Tiến hành vẽ 3 ô đại diện cho "Tường vật cản"
            for (int i = 0; i < 3; i++)
            {
                int x = startX + i * (size + 10);
                int y = startY;
                // Xác định loại vật cản để vẽ dựa trên RadioButton được Check
                if (rdbCoDinh.Checked)
                {
                    VeOPreview(g, x, y, size, mauCoDinh, isDiChuyen: false);
                }
                else if (rdbDiChuyen.Checked)
                {
                    VeOPreview(g, x, y, size, mauDiChuyen, isDiChuyen: true);
                }
                else // NgauNhien
                {
                    // Ô đầu cố định, ô hai di chuyển, ô ba cố định để demo
                    bool coDinh = (i % 2 == 0);
                    VeOPreview(g, x, y, size, coDinh ? mauCoDinh : mauDiChuyen, isDiChuyen: !coDinh);
                }
            }

        }
        private void VeOPreview(Graphics g, int x, int y, int size, Color mau, bool isDiChuyen)
        {
            using (Brush brush = new SolidBrush(mau))
            {
                // Vẽ thân ô vuông bo tròn
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 8;
                path.AddArc(x, y, radius, radius, 180, 90);
                path.AddArc(x + size - radius, y, radius, radius, 270, 90);
                path.AddArc(x + size - radius, y + size - radius, radius, radius, 0, 90);
                path.AddArc(x, y + size - radius, radius, radius, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
            // Nếu là vật cản di chuyển, ta vẽ thêm mũi tên hướng di chuyển cho sinh động
            if (isDiChuyen)
            {
                using (Pen pen = new Pen(Color.White, 3))
                {
                    // Vẽ mũi tên trái - phải
                    g.DrawLine(pen, x + 8, y + size / 2, x + size - 8, y + size / 2);
                    g.DrawLine(pen, x + 15, y + size / 2 - 5, x + 8, y + size / 2);
                    g.DrawLine(pen, x + 15, y + size / 2 + 5, x + 8, y + size / 2);
                    g.DrawLine(pen, x + size - 15, y + size / 2 - 5, x + size - 8, y + size / 2);
                    g.DrawLine(pen, x + size - 15, y + size / 2 + 5, x + size - 8, y + size / 2);
                }
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // 1. Lưu cấu hình vật cản như cũ
            if (int.TryParse(txtSoLuongTuong.Text, out int soLuong))
            {
                Setting.SoLuongTuongVatCan = Math.Max(1, Math.Min(soLuong, 8));
            }
            else
            {
                Setting.SoLuongTuongVatCan = 3;
            }
            Setting.MauVatCanCoDinh = btnMauCoDinh.BackColor;
            Setting.MauVatCanDiChuyen = btnMauDiChuyen.BackColor;
            if (rdbCoDinh.Checked)
                Setting.CheDoVatCanDaChon = Setting.CheDoVatCan.CoDinh;
            else if (rdbDiChuyen.Checked)
                Setting.CheDoVatCanDaChon = Setting.CheDoVatCan.DiChuyen;
            else
                Setting.CheDoVatCanDaChon = Setting.CheDoVatCan.NgauNhien;
            // 2. CHUYỂN TIẾP SANG SET MỒI NẾU THEO LUỒNG TỰ SETUP
            if (Setting.IsCustomSetupFlow)
            {
                FormSelect fMoi = new FormSelect(); // Class FormSelect nằm trong Form2.cs
                fMoi.Show();
            }
            this.Close();
        }
    }
}

