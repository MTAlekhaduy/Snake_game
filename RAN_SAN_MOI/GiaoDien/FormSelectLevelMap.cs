using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace RAN_SAN_MOI
{
    public partial class FormSelectLevelMap : Form
    {
        public FormSelectLevelMap()
        {
            InitializeComponent();
        }

        private void btnDe_Click(object sender, EventArgs e)
        {
            Setting.DoKhoDaChon = Setting.DoKho.De;
            FormSelect fs = new FormSelect();
            this.Hide();
            fs.Show();
        }

        private void FormSelectLevelMap_Load(object sender, EventArgs e)
        {
            // Không tự động chuyển form, ở lại màn hình chọn độ khó.
        }

        private void btnVua_Click(object sender, EventArgs e)
        {
            Setting.DoKhoDaChon = Setting.DoKho.Vua;
            FormSelect fs = new FormSelect();
            this.Hide();
            fs.Show();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            Setting.DoKhoDaChon = Setting.DoKho.Kho;
            FormSelect fs = new FormSelect();
            this.Hide();
            fs.Show();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
           FormSetting f =new FormSetting();
            this.Hide();
            f.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
                "Hãy Chọn Mức Độ Của Game !",
                 "Thông Báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }
    }
}
