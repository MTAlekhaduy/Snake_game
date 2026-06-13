namespace RAN_SAN_MOI
{
    partial class FormBangXepHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBangXepHang));
            this.lvBangXepHang = new System.Windows.Forms.ListView();
            this.btnXoaTatCa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvBangXepHang
            // 
            this.lvBangXepHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvBangXepHang.FullRowSelect = true;
            this.lvBangXepHang.GridLines = true;
            this.lvBangXepHang.HideSelection = false;
            this.lvBangXepHang.Location = new System.Drawing.Point(133, 176);
            this.lvBangXepHang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvBangXepHang.MultiSelect = false;
            this.lvBangXepHang.Name = "lvBangXepHang";
            this.lvBangXepHang.Size = new System.Drawing.Size(263, 321);
            this.lvBangXepHang.TabIndex = 1;
            this.lvBangXepHang.UseCompatibleStateImageBehavior = false;
            this.lvBangXepHang.View = System.Windows.Forms.View.Details;
            // 
            // btnXoaTatCa
            // 
            this.btnXoaTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXoaTatCa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoaTatCa.BackgroundImage")));
            this.btnXoaTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTatCa.Location = new System.Drawing.Point(133, 540);
            this.btnXoaTatCa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaTatCa.Name = "btnXoaTatCa";
            this.btnXoaTatCa.Size = new System.Drawing.Size(116, 57);
            this.btnXoaTatCa.TabIndex = 0;
            this.btnXoaTatCa.UseVisualStyleBackColor = false;
            this.btnXoaTatCa.Click += new System.EventHandler(this.btnXoaTatCa_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDong.BackgroundImage")));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Location = new System.Drawing.Point(277, 540);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(108, 56);
            this.btnDong.TabIndex = 1;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FormBangXepHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(515, 629);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXoaTatCa);
            this.Controls.Add(this.lvBangXepHang);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormBangXepHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBangXepHang";
            this.Load += new System.EventHandler(this.FormBangXepHang_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvBangXepHang;
        private System.Windows.Forms.Button btnXoaTatCa;
        private System.Windows.Forms.Button btnDong;
    }
}