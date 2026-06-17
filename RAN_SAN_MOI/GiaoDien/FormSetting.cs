using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RAN_SAN_MOI.Moi;

namespace RAN_SAN_MOI
{
    public partial class FormSetting : Form
    {
        private QuanLyMoi QuanLyMoi;
        private QuanLyRan QuanLyRan;
        public FormSetting()
        {
            InitializeComponent();
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void btnTiep_Click(object sender, EventArgs e)
        {
            FormSelectLevelMap f=new FormSelectLevelMap();
            this.Hide();
            f.Show();
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
              "Bạn Muốn Tắt Am Thanh Không ?",
               "Thông Báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                QuanLyAmThanh.DungNhacNen();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DialogResult testSetup = MessageBox.Show(
        "Bạn có muốn tự thiết lập game (Tự chọn Background, Vật cản, Mồi...) không?",
        "Xác nhận thiết lập",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );
            if (testSetup == DialogResult.Yes)
            {
                // 1. Kích hoạt cờ luồng tự setup
                Setting.IsCustomSetupFlow = true;
                // 2. Chuyển sang Form chọn Background đầu tiên
                FormSelectBackground fBackground = new FormSelectBackground();
                this.Hide();
                fBackground.Show();
            }
            else
            {
                // 3. Nếu chọn NO, quay lại luồng cũ của bạn
                Setting.IsCustomSetupFlow = false;
                MessageBox.Show(
                   "Vui lòng nhấn 'Tiếp' để chọn độ khó trước khi vào game!",
                   "Thông Báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // Mở màn hình chọn độ khó thay vì mở thẳng FormSelect
            FormSelectBackground f=new FormSelectBackground();
            this.Hide();
            f.Show();
        }
    }
}
