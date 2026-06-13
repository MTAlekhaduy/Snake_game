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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            string tenCu = QuanLyDuLieu.DocTenNguoiChoi();
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
                DialogResult kq = MessageBox.Show(
                    "Vui lòng nhập tên người chơi!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            // Lưu tên nếu chọn ghi nhớ
            if (chkLuuTen.Checked)
               QuanLyDuLieu.LuuTenNguoiChoi(ten);
            else
                Setting.TenNguoiChoi = ten;   

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblLoi_TextChanged(object sender, EventArgs e)
        {
         //   lblLoi.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           new FormBangXepHang().ShowDialog();
           
        }
    }
}
