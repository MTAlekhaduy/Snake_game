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
    public partial class FormBangXepHang : Form
    {
        public FormBangXepHang()
        {
            InitializeComponent();
        }

        private void FormBangXepHang_Load(object sender, EventArgs e)
        {
            CauHinhCot();
            NapDuLieu();
        }
        private void CauHinhCot()
        {
            lvBangXepHang.Columns.Clear();
            lvBangXepHang.Columns.Add("Hạng", 55, HorizontalAlignment.Center);
            lvBangXepHang.Columns.Add("Tên người chơi", 170, HorizontalAlignment.Left);
            lvBangXepHang.Columns.Add("Điểm", 80, HorizontalAlignment.Center);
            lvBangXepHang.Columns.Add("Độ khó", 80, HorizontalAlignment.Center);
            lvBangXepHang.Columns.Add("Thời gian", 130, HorizontalAlignment.Center);
        }
        private void NapDuLieu()
        {
            lvBangXepHang.Items.Clear();
            List<BanGhiDiem> top10 = QuanLyDuLieu.DocTop10();

            if (top10.Count == 0)
            {
                var item = new ListViewItem("—");
                item.SubItems.Add("Chưa có dữ liệu");
                item.SubItems.Add("—");
                item.SubItems.Add("—");
                item.SubItems.Add("—");
                item.ForeColor = Color.Gray;
                lvBangXepHang.Items.Add(item);
                return;
            }

            for (int i = 0; i < top10.Count; i++)
            {
                var r = top10[i];
                var item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(r.TenNguoiChoi);
                item.SubItems.Add(r.Diem.ToString("N0"));
                item.SubItems.Add(r.DoKho);
                item.SubItems.Add(r.ThoiGian.ToString("dd/MM/yyyy HH:mm"));

                // Màu theo thứ hạng
                if (i == 0) item.BackColor = Color.Gold;
                else if (i == 1) item.BackColor = Color.Silver;
                else if (i == 2) item.BackColor = Color.FromArgb(205, 127, 50); // đồng

                // Highlight người chơi hiện tại
                if (r.TenNguoiChoi == Setting.TenNguoiChoi)
                    item.Font = new Font(lvBangXepHang.Font, FontStyle.Bold);

                lvBangXepHang.Items.Add(item);
            }
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            var kq = MessageBox.Show(
                "Xóa toàn bộ bảng xếp hạng?\nHành động này không thể hoàn tác.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (kq != DialogResult.Yes) return;

            QuanLyDuLieu.XoaBangDiem();
            NapDuLieu();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
