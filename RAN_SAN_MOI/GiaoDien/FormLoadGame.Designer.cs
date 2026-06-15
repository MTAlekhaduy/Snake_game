namespace RAN_SAN_MOI
{
    partial class FormLoadGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadGame));
            this.picGame = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.btnTamDung = new System.Windows.Forms.Button();
            this.lblDiem = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelGame = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGame
            // 
            this.picGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picGame.BackgroundImage")));
            this.picGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picGame.Location = new System.Drawing.Point(4, 0);
            this.picGame.Margin = new System.Windows.Forms.Padding(4);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(1386, 747);
            this.picGame.TabIndex = 0;
            this.picGame.TabStop = false;
            this.picGame.Paint += new System.Windows.Forms.PaintEventHandler(this.picGame_Paint);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // btnTamDung
            // 
            this.btnTamDung.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTamDung.BackgroundImage")));
            this.btnTamDung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTamDung.FlatAppearance.BorderSize = 0;
            this.btnTamDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTamDung.Location = new System.Drawing.Point(735, 4);
            this.btnTamDung.Margin = new System.Windows.Forms.Padding(4);
            this.btnTamDung.Name = "btnTamDung";
            this.btnTamDung.Size = new System.Drawing.Size(118, 55);
            this.btnTamDung.TabIndex = 3;
            this.btnTamDung.UseVisualStyleBackColor = true;
            this.btnTamDung.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblDiem
            // 
            this.lblDiem.BackColor = System.Drawing.Color.Transparent;
            this.lblDiem.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDiem.Location = new System.Drawing.Point(141, 47);
            this.lblDiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(278, 37);
            this.lblDiem.TabIndex = 1;
            this.lblDiem.Text = "Điểm Hiện Tại : ";
            this.lblDiem.Click += new System.EventHandler(this.lblDiem_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(598, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 55);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelHeader.BackgroundImage")));
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.Controls.Add(this.btnTamDung);
            this.panelHeader.Controls.Add(this.lblDiem);
            this.panelHeader.Controls.Add(this.button1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1394, 100);
            this.panelHeader.TabIndex = 4;
            // 
            // panelGame
            // 
            this.panelGame.Controls.Add(this.picGame);
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 100);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1394, 751);
            this.panelGame.TabIndex = 5;
            // 
            // FormLoadGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1394, 851);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelHeader);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLoadGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLoadGame";
            this.Load += new System.EventHandler(this.FormLoadGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelGame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.PictureBox picGame;
        protected System.Windows.Forms.Timer GameTimer;
        protected System.Windows.Forms.Button btnTamDung;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelGame;
    }
}