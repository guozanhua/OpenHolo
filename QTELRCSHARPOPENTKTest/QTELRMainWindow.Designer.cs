namespace QTELR_Interface
{
    partial class QTELRMainWindow
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
            this.glControl1 = new OpenTK.GLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heatMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medium4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medium5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.low10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Capture = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 27);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1004, 632);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyListener);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseMove);
            this.glControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseWheel);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1027, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colourModeToolStripMenuItem,
            this.qualityToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // colourModeToolStripMenuItem
            // 
            this.colourModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBToolStripMenuItem,
            this.allWhiteToolStripMenuItem,
            this.heatMapToolStripMenuItem});
            this.colourModeToolStripMenuItem.Name = "colourModeToolStripMenuItem";
            this.colourModeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.colourModeToolStripMenuItem.Text = "Colour Mode";
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.rGBToolStripMenuItem.Text = "RGB";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.rGBToolStripMenuItem_Click);
            // 
            // allWhiteToolStripMenuItem
            // 
            this.allWhiteToolStripMenuItem.Name = "allWhiteToolStripMenuItem";
            this.allWhiteToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.allWhiteToolStripMenuItem.Text = "All White";
            this.allWhiteToolStripMenuItem.Click += new System.EventHandler(this.allWhiteToolStripMenuItem_Click);
            // 
            // heatMapToolStripMenuItem
            // 
            this.heatMapToolStripMenuItem.Name = "heatMapToolStripMenuItem";
            this.heatMapToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.heatMapToolStripMenuItem.Text = "Heat Map";
            this.heatMapToolStripMenuItem.Click += new System.EventHandler(this.heatMapToolStripMenuItem_Click);
            // 
            // qualityToolStripMenuItem
            // 
            this.qualityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highestToolStripMenuItem,
            this.medium4ToolStripMenuItem,
            this.medium5ToolStripMenuItem,
            this.low10ToolStripMenuItem});
            this.qualityToolStripMenuItem.Name = "qualityToolStripMenuItem";
            this.qualityToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.qualityToolStripMenuItem.Text = "Quality";
            // 
            // highestToolStripMenuItem
            // 
            this.highestToolStripMenuItem.Name = "highestToolStripMenuItem";
            this.highestToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.highestToolStripMenuItem.Text = "Highest (1)";
            this.highestToolStripMenuItem.Click += new System.EventHandler(this.highestToolStripMenuItem_Click);
            // 
            // medium4ToolStripMenuItem
            // 
            this.medium4ToolStripMenuItem.Name = "medium4ToolStripMenuItem";
            this.medium4ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.medium4ToolStripMenuItem.Text = "Medium (4)";
            this.medium4ToolStripMenuItem.Click += new System.EventHandler(this.medium4ToolStripMenuItem_Click);
            // 
            // medium5ToolStripMenuItem
            // 
            this.medium5ToolStripMenuItem.Name = "medium5ToolStripMenuItem";
            this.medium5ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.medium5ToolStripMenuItem.Text = "Medium (5)";
            this.medium5ToolStripMenuItem.Click += new System.EventHandler(this.medium5ToolStripMenuItem_Click);
            // 
            // low10ToolStripMenuItem
            // 
            this.low10ToolStripMenuItem.Name = "low10ToolStripMenuItem";
            this.low10ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.low10ToolStripMenuItem.Text = "Low (10)";
            this.low10ToolStripMenuItem.Click += new System.EventHandler(this.low10ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button_Capture
            // 
            this.button_Capture.Location = new System.Drawing.Point(12, 665);
            this.button_Capture.Name = "button_Capture";
            this.button_Capture.Size = new System.Drawing.Size(75, 23);
            this.button_Capture.TabIndex = 2;
            this.button_Capture.Text = "Capture";
            this.button_Capture.UseVisualStyleBackColor = true;
            this.button_Capture.Click += new System.EventHandler(this.button_Capture_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(93, 665);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 3;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // QTELRMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 694);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Capture);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QTELRMainWindow";
            this.Text = "Quick Telemtetry Relay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closeForm);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyListener);
            this.Resize += new System.EventHandler(this.mainWindow_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colourModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heatMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medium4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medium5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem low10ToolStripMenuItem;
        private System.Windows.Forms.Button button_Capture;
        private System.Windows.Forms.Button button_Clear;
    }
}