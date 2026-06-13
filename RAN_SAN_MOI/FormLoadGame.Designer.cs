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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDiem = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.btnTamDung = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGame
            // 
            this.picGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picGame.BackgroundImage")));
            this.picGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picGame.Location = new System.Drawing.Point(84, 46);
            this.picGame.Name = "picGame";
            this.picGame.Size = new System.Drawing.Size(836, 518);
            this.picGame.TabIndex = 0;
            this.picGame.TabStop = false;
            this.picGame.Paint += new System.Windows.Forms.PaintEventHandler(this.picGame_Paint);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(822, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 44);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.lblDiem);
            this.panel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(296, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 37);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblDiem
            // 
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDiem.Location = new System.Drawing.Point(3, 0);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(168, 26);
            this.lblDiem.TabIndex = 1;
            this.lblDiem.Text = "Điểm Hiện Tại : ";
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
            this.btnTamDung.Location = new System.Drawing.Point(710, 2);
            this.btnTamDung.Name = "btnTamDung";
            this.btnTamDung.Size = new System.Drawing.Size(94, 44);
            this.btnTamDung.TabIndex = 3;
            this.btnTamDung.UseVisualStyleBackColor = true;
            this.btnTamDung.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormLoadGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 611);
            this.Controls.Add(this.btnTamDung);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picGame);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLoadGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLoadGame";
            this.Load += new System.EventHandler(this.FormLoadGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGame)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.PictureBox picGame;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Timer GameTimer;
        protected System.Windows.Forms.Button btnTamDung;
        protected System.Windows.Forms.Label lblDiem;
    }
}