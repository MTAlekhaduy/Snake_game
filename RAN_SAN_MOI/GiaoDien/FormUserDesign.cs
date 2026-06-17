using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RAN_SAN_MOI
{
    // Kế thừa toàn bộ logic chơi game, vẽ hình, bắt phím của FormLoadGame
    public partial class FormUserDesign : FormLoadGame
    {
        public FormUserDesign() : base()
        {
            InitializeComponent();
        }

        protected override void FormLoadGame_Load(object sender, EventArgs e)
        {
            // 1. Gọi hàm Load gốc để khởi tạo rắn, mồi, nhạc nền và tốc độ game
            base.FormLoadGame_Load(sender, e);

            // 2. Nạp thêm vật cản đã được user setup từ FormSetVatCan
            if (_quanLyVatCan == null)
            {
                _quanLyVatCan = new QuanLyVatCan();
            }

            // Sinh các tường vật cản (độ dài 3 ô hàng ngang) dựa trên số lượng user đã lưu
            _quanLyVatCan.SinhVatCanMacDinh(oNgang, oDoc);

            // 3. Đảm bảo cập nhật lại PictureBox để hiển thị đúng ngay từ đầu
            if (picGame != null)
            {
                picGame.Invalidate();
            }
        }
    }
}
