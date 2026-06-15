namespace RAN_SAN_MOI
{
    partial class FormMapVatCan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMapVatCan));
            this.lblDiem = new System.Windows.Forms.Label();
            this.picGame = new System.Windows.Forms.PictureBox();
            this.btnTamDung = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelGame = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.BackColor = System.Drawing.Color.Transparent;
            this.lblDiem.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDiem.Location = new System.Drawing.Point(114, 49);
            this.lblDiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(209, 31);
            this.lblDiem.TabIndex = 2;
            this.lblDiem.Text = "Điểm Hiện Tại : ";
            this.lblDiem.Click += new System.EventHandler(this.lblDiem_Click);
            // 
            // picGame
            // 
            this.picGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picGame.BackgroundImage")));
            this.picGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picGame.Location = new System.Drawing.Point(4, 4);
            this.picGame.Margin = new System.Windows.Forms.Padding(4);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(1177, 623);
            this.picGame.TabIndex = 3;
            this.picGame.TabStop = false;
            this.picGame.Paint += new System.Windows.Forms.PaintEventHandler(this.picGame_Paint);
            this.picGame.Resize += new System.EventHandler(this.picGame_Resize);
            // 
            // btnTamDung
            // 
            this.btnTamDung.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTamDung.BackgroundImage")));
            this.btnTamDung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTamDung.FlatAppearance.BorderSize = 0;
            this.btnTamDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamDung.Location = new System.Drawing.Point(534, 4);
            this.btnTamDung.Margin = new System.Windows.Forms.Padding(4);
            this.btnTamDung.Name = "btnTamDung";
            this.btnTamDung.Size = new System.Drawing.Size(126, 54);
            this.btnTamDung.TabIndex = 4;
            this.btnTamDung.UseVisualStyleBackColor = true;
            this.btnTamDung.Click += new System.EventHandler(this.btnTamDung_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Location = new System.Drawing.Point(668, 4);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(121, 54);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(417, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 6;
            // 
            // panelHeader
            // 
            this.panelHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelHeader.BackgroundImage")));
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.Controls.Add(this.btnTamDung);
            this.panelHeader.Controls.Add(this.btnThoat);
            this.panelHeader.Controls.Add(this.lblDiem);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1185, 100);
            this.panelHeader.TabIndex = 7;
            // 
            // panelGame
            // 
            this.panelGame.Controls.Add(this.picGame);
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 100);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1185, 627);
            this.panelGame.TabIndex = 8;
            // 
            // FormMapVatCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 727);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel1);
            this.Name = "FormMapVatCan";
            this.Text = "FormMapVatCan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMapVatCan_FormClosed);
            this.Load += new System.EventHandler(this.FormMapVatCan_Load);
            this.Resize += new System.EventHandler(this.FormMapVatCan_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelGame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblDiem;
        protected System.Windows.Forms.PictureBox picGame;
        protected System.Windows.Forms.Button btnTamDung;
        protected System.Windows.Forms.Button btnThoat;
        protected System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelGame;
    }
}