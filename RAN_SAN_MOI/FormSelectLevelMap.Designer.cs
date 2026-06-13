namespace RAN_SAN_MOI
{
    partial class FormSelectLevelMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectLevelMap));
            this.btnDe = new System.Windows.Forms.Button();
            this.btnVua = new System.Windows.Forms.Button();
            this.btnKho = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDe
            // 
            this.btnDe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDe.BackgroundImage")));
            this.btnDe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDe.Location = new System.Drawing.Point(97, 174);
            this.btnDe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDe.Name = "btnDe";
            this.btnDe.Size = new System.Drawing.Size(231, 120);
            this.btnDe.TabIndex = 0;
            this.btnDe.UseVisualStyleBackColor = true;
            this.btnDe.Click += new System.EventHandler(this.btnDe_Click);
            // 
            // btnVua
            // 
            this.btnVua.BackColor = System.Drawing.Color.Transparent;
            this.btnVua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVua.BackgroundImage")));
            this.btnVua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVua.Location = new System.Drawing.Point(387, 174);
            this.btnVua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVua.Name = "btnVua";
            this.btnVua.Size = new System.Drawing.Size(239, 120);
            this.btnVua.TabIndex = 1;
            this.btnVua.UseVisualStyleBackColor = false;
            this.btnVua.Click += new System.EventHandler(this.btnVua_Click);
            // 
            // btnKho
            // 
            this.btnKho.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKho.BackgroundImage")));
            this.btnKho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKho.Location = new System.Drawing.Point(686, 174);
            this.btnKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKho.Name = "btnKho";
            this.btnKho.Size = new System.Drawing.Size(238, 120);
            this.btnKho.TabIndex = 2;
            this.btnKho.UseVisualStyleBackColor = true;
            this.btnKho.Click += new System.EventHandler(this.btnKho_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Location = new System.Drawing.Point(33, 413);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(152, 28);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetting.BackgroundImage")));
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Location = new System.Drawing.Point(830, 408);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(154, 39);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // FormSelectLevelMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1017, 460);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnKho);
            this.Controls.Add(this.btnVua);
            this.Controls.Add(this.btnDe);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectLevelMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelectLevelMap";
            this.Load += new System.EventHandler(this.FormSelectLevelMap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDe;
        private System.Windows.Forms.Button btnVua;
        private System.Windows.Forms.Button btnKho;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSetting;
    }
}