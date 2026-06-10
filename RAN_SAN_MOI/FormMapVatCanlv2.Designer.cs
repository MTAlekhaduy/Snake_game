namespace RAN_SAN_MOI
{
    partial class FormMapVatCanlv2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMapVatCanlv2));
            this.picGame = new System.Windows.Forms.PictureBox();
            this.btnTamDung = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblDiem = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.VatCanTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            this.SuspendLayout();
            // 
            // picGame
            // 
            this.picGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picGame.BackgroundImage")));
            this.picGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picGame.Location = new System.Drawing.Point(22, 74);
            this.picGame.Margin = new System.Windows.Forms.Padding(4);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(1289, 657);
            this.picGame.TabIndex = 4;
            this.picGame.TabStop = false;
            this.picGame.Paint += new System.Windows.Forms.PaintEventHandler(this.picGame_Paint);
            // 
            // btnTamDung
            // 
            this.btnTamDung.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTamDung.BackgroundImage")));
            this.btnTamDung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTamDung.FlatAppearance.BorderSize = 0;
            this.btnTamDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamDung.Location = new System.Drawing.Point(961, 12);
            this.btnTamDung.Margin = new System.Windows.Forms.Padding(4);
            this.btnTamDung.Name = "btnTamDung";
            this.btnTamDung.Size = new System.Drawing.Size(126, 54);
            this.btnTamDung.TabIndex = 5;
            this.btnTamDung.UseVisualStyleBackColor = true;
            this.btnTamDung.Click += new System.EventHandler(this.btnTamDung_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Location = new System.Drawing.Point(1109, 13);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(141, 54);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDiem.Location = new System.Drawing.Point(387, 36);
            this.lblDiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(209, 31);
            this.lblDiem.TabIndex = 7;
            this.lblDiem.Text = "Điểm Hiện Tại : ";
            this.lblDiem.Click += new System.EventHandler(this.lblDiem_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 60;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // VatCanTimer
            // 
            this.VatCanTimer.Interval = 5000;
            this.VatCanTimer.Tick += new System.EventHandler(this.VatCanTimer_Tick);
            // 
            // FormMapVatCanlv2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 795);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTamDung);
            this.Controls.Add(this.picGame);
            this.Name = "FormMapVatCanlv2";
            this.Text = "FormMapVatCanlv2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMapVatCanlv2_FormClosed);
            this.Load += new System.EventHandler(this.FormMapVatCanlv2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox picGame;
        protected System.Windows.Forms.Button btnTamDung;
        protected System.Windows.Forms.Button btnThoat;
        protected System.Windows.Forms.Label lblDiem;
        protected System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer VatCanTimer;
    }
}