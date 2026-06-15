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
    public partial class FormGameOver : Form
    {
        public FormGameOver()
        {
            InitializeComponent();
            this.Load += FormGameOver_Load;
            this.btnYes.Click += btnYes_Click;
            this.btnNo.Click += btnNo_Click;

        }

        private void FormGameOver_Load(object sender, EventArgs e)
        {
        
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.No;
            this.Close ();
        }

        private void lblHighScore_Click(object sender, EventArgs e)
        {

        }
    }
}
