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
    public partial class FormSelect : Form
    {
        public FormSelect()
        {
            InitializeComponent();
        }

        private void FalsSelect_Load(object sender, EventArgs e)
        {
        
          
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            Setting.SoLuongMoiBinhThuong = tbBinhThuong.Value;
            Setting.SoLuongMoiTraiTim    = tbTraiTim.Value;
            Setting.SoLuongMoiPhanThan   = tbPhanThan.Value;
            Setting.SoLuongMoiKhongLo   = tbKhongLo.Value;
            Setting.SoLuongMoiTruDiem   = tbTruDiem.Value;

            Setting.MauMoiBinhThuong = btnMauBinhThuong.BackColor;
            Setting.MauMoiTraiTim    = btnMauTraiTim.BackColor;
            Setting.MauMoiPhanThan   = btnMauPhanThan.BackColor;
            Setting.MauMoiKhongLo   = btnMauKhongLo.BackColor;
            Setting.MauMoiTruDiem   = btnMauTruDiem.BackColor;

            this.Hide();

            // Mở form game theo độ khó người dùng đã chọn
            switch (Setting.DoKhoDaChon)
            {
                case Setting.DoKho.De:
                    new FormLoadGame().Show();
                    break;
                case Setting.DoKho.Vua:
                    new FormMapVatCan().Show();
                    break;
                case Setting.DoKho.Kho:
                    new FormMapVatCanlv2().Show();
                    break;
            }
        }


        private void lblKhongLo_Click(object sender, EventArgs e) { }

        private void tbBinhThuong_Scroll(object sender, EventArgs e)
        {
            lblBinhThuong.Text = tbBinhThuong.Value.ToString();
        }

        private void tbTraiTim_Scroll(object sender, EventArgs e)
        {
            lblTraiTim.Text = tbTraiTim.Value.ToString();
        }

        private void tbPhanThan_Scroll(object sender, EventArgs e)
        {
            lblPhanThan.Text = tbPhanThan.Value.ToString();
        }

        private void tbKhongLo_Scroll(object sender, EventArgs e)
        {
            lblKhongLo.Text = tbKhongLo.Value.ToString();
        }

        private void tbTruDiem_Scroll(object sender, EventArgs e)
        {
            lblTruDiem.Text = tbTruDiem.Value.ToString();
        }

        private void btnMauBinhThuong_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = btnMauBinhThuong.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                btnMauBinhThuong.BackColor = dlg.Color;
        }

        private void btnMauTraiTim_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = btnMauTraiTim.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                btnMauTraiTim.BackColor = dlg.Color;
        }

        private void btnMauPhanThan_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = btnMauPhanThan.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                btnMauPhanThan.BackColor = dlg.Color;
        }

        private void btnMauKhongLo_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = btnMauKhongLo.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                btnMauKhongLo.BackColor = dlg.Color;
        }

        private void btnMauTruDiem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = btnMauTruDiem.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                btnMauTruDiem.BackColor = dlg.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSelectLevelMap f=new FormSelectLevelMap();
            this.Hide();
            f.Show();
        }
    }
}