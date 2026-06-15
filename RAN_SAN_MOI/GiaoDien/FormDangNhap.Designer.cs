namespace RAN_SAN_MOI
{
    partial class FormDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkLuuTen = new System.Windows.Forms.CheckBox();
            this.lblLoi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTen
            // 
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(279, 155);
            this.txtTen.MaxLength = 20;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(278, 21);
            this.txtTen.TabIndex = 2;
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.White;
            this.btnBatDau.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBatDau.BackgroundImage")));
            this.btnBatDau.FlatAppearance.BorderSize = 0;
            this.btnBatDau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(148, 303);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(181, 51);
            this.btnBatDau.TabIndex = 4;
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(369, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 51);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkLuuTen
            // 
            this.chkLuuTen.AutoSize = true;
            this.chkLuuTen.BackColor = System.Drawing.Color.White;
            this.chkLuuTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLuuTen.Location = new System.Drawing.Point(60, 230);
            this.chkLuuTen.Name = "chkLuuTen";
            this.chkLuuTen.Size = new System.Drawing.Size(117, 24);
            this.chkLuuTen.TabIndex = 6;
            this.chkLuuTen.Text = "Ghi nhớ tên";
            this.chkLuuTen.UseVisualStyleBackColor = false;
            // 
            // lblLoi
            // 
            this.lblLoi.AutoSize = true;
            this.lblLoi.Location = new System.Drawing.Point(276, 230);
            this.lblLoi.Name = "lblLoi";
            this.lblLoi.Size = new System.Drawing.Size(0, 16);
            this.lblLoi.TabIndex = 7;
            this.lblLoi.Click += new System.EventHandler(this.lblLoi_Click);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(641, 445);
            this.Controls.Add(this.lblLoi);
            this.Controls.Add(this.chkLuuTen);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.txtTen);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDangNhap";
            this.Load += new System.EventHandler(this.FormDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkLuuTen;
        private System.Windows.Forms.Label lblLoi;
    }
}