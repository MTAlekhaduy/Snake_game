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
    public partial class FormChoiTiep : Form
    {
        private TrangThaiGameRecord _snapshot;

        public FormChoiTiep(TrangThaiGameRecord snapshot)
        {
            InitializeComponent();
            _snapshot = snapshot;
        }

        private void FormChoiTiep_Load(object sender, EventArgs e)
        {
            lblTenNguoiChoi.Text = "Người chơi: " +
                 (ScoreManager.NguoiChoiHienTai != null
                     ? ScoreManager.NguoiChoiHienTai.TenNguoiChoi
                     : "Khách");
            lblDiem.Text = "Điểm: " + _snapshot.DiemHienTai;
            lblDoKho.Text = "Độ khó: " + GetFriendlyDoKho(_snapshot.DoKho);
            lblThoiGian.Text = "Lưu lúc: \n" + _snapshot.ThoiGianLuu.ToString("dd/MM/yyyy HH:mm");

            if (_snapshot.AnhGame != null && _snapshot.AnhGame.Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(_snapshot.AnhGame))
                    {
                        picAnhGame.Image = (Image)Image.FromStream(ms).Clone();
                    }
                }
                catch (Exception)
                {
                    // Bỏ qua lỗi nếu dữ liệu ảnh lỗi
                }
            }
        }
        private string GetFriendlyDoKho(string doKho)
        {
            switch (doKho)
            {
                case "De": return "Dễ";
                case "Vua": return "Vừa";
                case "VatCan": return "Vừa (Vật cản)";
                case "VatCanlv2": return "Khó";
                default: return doKho;
            }
        }

        private void btnChuTiep_Click(object sender, EventArgs e)
        {
            Form formGame;

            switch (_snapshot.DoKho)
            {
                case "VatCan":
                case "Vua":
                    formGame = new FormMapVatCan();
                    break;
                case "VatCanlv2":
                case "Kho":
                    formGame = new FormMapVatCanlv2();
                    break;
                default:
                    formGame = new FormLoadGame();
                    break;
            }

            formGame.Tag = _snapshot;
            formGame.Show();

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnVanMoi_Click(object sender, EventArgs e)
        {
            ScoreManager.XoaTrangThaiLuu();

            new FormSetting().Show();

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
