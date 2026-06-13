namespace RAN_SAN_MOI
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.btnSound = new System.Windows.Forms.Button();
            this.btnLui = new System.Windows.Forms.Button();
            this.btnTiep = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSound
            // 
            this.btnSound.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSound.BackgroundImage")));
            this.btnSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSound.Location = new System.Drawing.Point(215, 277);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(231, 54);
            this.btnSound.TabIndex = 0;
            this.btnSound.UseVisualStyleBackColor = true;
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            // 
            // btnLui
            // 
            this.btnLui.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLui.BackgroundImage")));
            this.btnLui.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLui.Location = new System.Drawing.Point(104, 308);
            this.btnLui.Name = "btnLui";
            this.btnLui.Size = new System.Drawing.Size(70, 54);
            this.btnLui.TabIndex = 1;
            this.btnLui.UseVisualStyleBackColor = true;
            this.btnLui.Click += new System.EventHandler(this.btnLui_Click);
            // 
            // btnTiep
            // 
            this.btnTiep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTiep.BackgroundImage")));
            this.btnTiep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTiep.Location = new System.Drawing.Point(499, 308);
            this.btnTiep.Name = "btnTiep";
            this.btnTiep.Size = new System.Drawing.Size(70, 57);
            this.btnTiep.TabIndex = 2;
            this.btnTiep.UseVisualStyleBackColor = true;
            this.btnTiep.Click += new System.EventHandler(this.btnTiep_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetting.BackgroundImage")));
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Location = new System.Drawing.Point(215, 370);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(231, 59);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(215, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 60);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(196, 583);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(264, 67);
            this.btnStart.TabIndex = 5;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 744);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnTiep);
            this.Controls.Add(this.btnLui);
            this.Controls.Add(this.btnSound);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSetting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.Button btnLui;
        private System.Windows.Forms.Button btnTiep;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnStart;
    }
}