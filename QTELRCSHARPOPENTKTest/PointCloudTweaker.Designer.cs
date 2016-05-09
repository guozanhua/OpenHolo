namespace OpenHolo
{
    partial class PointCloudTweaker
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
            this.title = new System.Windows.Forms.Label();
            this.vectorLabel = new System.Windows.Forms.Label();
            this.vectorxlabel = new System.Windows.Forms.Label();
            this.vectorylabel = new System.Windows.Forms.Label();
            this.vectorzlabel = new System.Windows.Forms.Label();
            this.quatLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textbox_vx = new System.Windows.Forms.TextBox();
            this.textbox_vy = new System.Windows.Forms.TextBox();
            this.textbox_vz = new System.Windows.Forms.TextBox();
            this.textbox_qx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_qy = new System.Windows.Forms.TextBox();
            this.textbox_qz = new System.Windows.Forms.TextBox();
            this.textbox_qw = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(13, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(151, 13);
            this.title.TabIndex = 0;
            this.title.Text = "Euclidean Transform Attributes";
            // 
            // vectorLabel
            // 
            this.vectorLabel.AutoSize = true;
            this.vectorLabel.Location = new System.Drawing.Point(13, 30);
            this.vectorLabel.Name = "vectorLabel";
            this.vectorLabel.Size = new System.Drawing.Size(38, 13);
            this.vectorLabel.TabIndex = 1;
            this.vectorLabel.Text = "Vector";
            // 
            // vectorxlabel
            // 
            this.vectorxlabel.AutoSize = true;
            this.vectorxlabel.Location = new System.Drawing.Point(13, 43);
            this.vectorxlabel.Name = "vectorxlabel";
            this.vectorxlabel.Size = new System.Drawing.Size(48, 13);
            this.vectorxlabel.TabIndex = 2;
            this.vectorxlabel.Text = "Vector X";
            // 
            // vectorylabel
            // 
            this.vectorylabel.AutoSize = true;
            this.vectorylabel.Location = new System.Drawing.Point(67, 43);
            this.vectorylabel.Name = "vectorylabel";
            this.vectorylabel.Size = new System.Drawing.Size(48, 13);
            this.vectorylabel.TabIndex = 3;
            this.vectorylabel.Text = "Vector Y";
            // 
            // vectorzlabel
            // 
            this.vectorzlabel.AutoSize = true;
            this.vectorzlabel.Location = new System.Drawing.Point(121, 43);
            this.vectorzlabel.Name = "vectorzlabel";
            this.vectorzlabel.Size = new System.Drawing.Size(48, 13);
            this.vectorzlabel.TabIndex = 4;
            this.vectorzlabel.Text = "Vector Z";
            // 
            // quatLabel
            // 
            this.quatLabel.AutoSize = true;
            this.quatLabel.Location = new System.Drawing.Point(13, 93);
            this.quatLabel.Name = "quatLabel";
            this.quatLabel.Size = new System.Drawing.Size(59, 13);
            this.quatLabel.TabIndex = 5;
            this.quatLabel.Text = "Quaternion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Quaternion X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Quaternion Y";
            // 
            // textbox_vx
            // 
            this.textbox_vx.Location = new System.Drawing.Point(16, 60);
            this.textbox_vx.Name = "textbox_vx";
            this.textbox_vx.Size = new System.Drawing.Size(45, 20);
            this.textbox_vx.TabIndex = 8;
            // 
            // textbox_vy
            // 
            this.textbox_vy.Location = new System.Drawing.Point(70, 59);
            this.textbox_vy.Name = "textbox_vy";
            this.textbox_vy.Size = new System.Drawing.Size(45, 20);
            this.textbox_vy.TabIndex = 9;
            // 
            // textbox_vz
            // 
            this.textbox_vz.Location = new System.Drawing.Point(122, 58);
            this.textbox_vz.Name = "textbox_vz";
            this.textbox_vz.Size = new System.Drawing.Size(47, 20);
            this.textbox_vz.TabIndex = 10;
            // 
            // textbox_qx
            // 
            this.textbox_qx.Location = new System.Drawing.Point(17, 122);
            this.textbox_qx.Name = "textbox_qx";
            this.textbox_qx.Size = new System.Drawing.Size(65, 20);
            this.textbox_qx.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Quaternion Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quaternion W";
            // 
            // textbox_qy
            // 
            this.textbox_qy.Location = new System.Drawing.Point(89, 121);
            this.textbox_qy.Name = "textbox_qy";
            this.textbox_qy.Size = new System.Drawing.Size(68, 20);
            this.textbox_qy.TabIndex = 14;
            // 
            // textbox_qz
            // 
            this.textbox_qz.Location = new System.Drawing.Point(166, 120);
            this.textbox_qz.Name = "textbox_qz";
            this.textbox_qz.Size = new System.Drawing.Size(66, 20);
            this.textbox_qz.TabIndex = 15;
            // 
            // textbox_qw
            // 
            this.textbox_qw.Location = new System.Drawing.Point(241, 120);
            this.textbox_qw.Name = "textbox_qw";
            this.textbox_qw.Size = new System.Drawing.Size(70, 20);
            this.textbox_qw.TabIndex = 16;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(17, 165);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 17;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // PointCloudTweaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 205);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.textbox_qw);
            this.Controls.Add(this.textbox_qz);
            this.Controls.Add(this.textbox_qy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_qx);
            this.Controls.Add(this.textbox_vz);
            this.Controls.Add(this.textbox_vy);
            this.Controls.Add(this.textbox_vx);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quatLabel);
            this.Controls.Add(this.vectorzlabel);
            this.Controls.Add(this.vectorylabel);
            this.Controls.Add(this.vectorxlabel);
            this.Controls.Add(this.vectorLabel);
            this.Controls.Add(this.title);
            this.Name = "PointCloudTweaker";
            this.Text = "PointCloudTweaker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label vectorLabel;
        private System.Windows.Forms.Label vectorxlabel;
        private System.Windows.Forms.Label vectorylabel;
        private System.Windows.Forms.Label vectorzlabel;
        private System.Windows.Forms.Label quatLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textbox_vx;
        private System.Windows.Forms.TextBox textbox_vy;
        private System.Windows.Forms.TextBox textbox_vz;
        private System.Windows.Forms.TextBox textbox_qx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_qy;
        private System.Windows.Forms.TextBox textbox_qz;
        private System.Windows.Forms.TextBox textbox_qw;
        private System.Windows.Forms.Button updateButton;
    }
}