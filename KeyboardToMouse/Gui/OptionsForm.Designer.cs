namespace KeyboardToMouse.Gui
{
    partial class OptionsForm
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
            groupBox1 = new GroupBox();
            txtbx_YOffset = new TextBox();
            label2 = new Label();
            txtbx_XOffset = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            chkbx_ClickMaxDistance = new CheckBox();
            chkbx_UseRadialTurning = new CheckBox();
            txtbx_ClickRange = new TextBox();
            trkbr_ClickRange = new TrackBar();
            groupBox3 = new GroupBox();
            txtbx_RandomizeClickDelay = new TextBox();
            chkbx_RandomizeClickDelay = new CheckBox();
            txtbx_ClickDelay = new TextBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            label4 = new Label();
            chkbx_ForceMovement = new CheckBox();
            cmbx_ForceMovementKey = new ComboBox();
            cmbx_MouseMovementKey = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkbr_ClickRange).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtbx_YOffset);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtbx_XOffset);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.DarkKhaki;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(129, 83);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "X | Y Offset";
            // 
            // txtbx_YOffset
            // 
            txtbx_YOffset.Location = new Point(63, 49);
            txtbx_YOffset.Name = "txtbx_YOffset";
            txtbx_YOffset.Size = new Size(56, 23);
            txtbx_YOffset.TabIndex = 3;
            txtbx_YOffset.Text = "0";
            txtbx_YOffset.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 52);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 2;
            label2.Text = "Y Offset";
            // 
            // txtbx_XOffset
            // 
            txtbx_XOffset.Location = new Point(63, 20);
            txtbx_XOffset.Name = "txtbx_XOffset";
            txtbx_XOffset.Size = new Size(56, 23);
            txtbx_XOffset.TabIndex = 1;
            txtbx_XOffset.Text = "0";
            txtbx_XOffset.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "X Offset";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkbx_ClickMaxDistance);
            groupBox2.Controls.Add(chkbx_UseRadialTurning);
            groupBox2.Controls.Add(txtbx_ClickRange);
            groupBox2.Controls.Add(trkbr_ClickRange);
            groupBox2.ForeColor = Color.DarkKhaki;
            groupBox2.Location = new Point(147, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(266, 83);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Click Range";
            // 
            // chkbx_ClickMaxDistance
            // 
            chkbx_ClickMaxDistance.AutoSize = true;
            chkbx_ClickMaxDistance.Location = new Point(132, 58);
            chkbx_ClickMaxDistance.Name = "chkbx_ClickMaxDistance";
            chkbx_ClickMaxDistance.Size = new Size(126, 19);
            chkbx_ClickMaxDistance.TabIndex = 9;
            chkbx_ClickMaxDistance.Text = "Click Max Distance";
            chkbx_ClickMaxDistance.UseVisualStyleBackColor = true;
            chkbx_ClickMaxDistance.CheckedChanged += chkbx_ClickMaxDistance_CheckedChanged;
            // 
            // chkbx_UseRadialTurning
            // 
            chkbx_UseRadialTurning.AutoSize = true;
            chkbx_UseRadialTurning.Location = new Point(6, 58);
            chkbx_UseRadialTurning.Name = "chkbx_UseRadialTurning";
            chkbx_UseRadialTurning.Size = new Size(124, 19);
            chkbx_UseRadialTurning.TabIndex = 8;
            chkbx_UseRadialTurning.Text = "Use Radial Turning";
            chkbx_UseRadialTurning.UseVisualStyleBackColor = true;
            chkbx_UseRadialTurning.CheckedChanged += chkbx_UseRadialTurning_CheckedChanged;
            // 
            // txtbx_ClickRange
            // 
            txtbx_ClickRange.Enabled = false;
            txtbx_ClickRange.Location = new Point(200, 20);
            txtbx_ClickRange.Name = "txtbx_ClickRange";
            txtbx_ClickRange.Size = new Size(56, 23);
            txtbx_ClickRange.TabIndex = 4;
            txtbx_ClickRange.Text = "75";
            txtbx_ClickRange.TextAlign = HorizontalAlignment.Center;
            // 
            // trkbr_ClickRange
            // 
            trkbr_ClickRange.LargeChange = 50;
            trkbr_ClickRange.Location = new Point(6, 20);
            trkbr_ClickRange.Maximum = 300;
            trkbr_ClickRange.Minimum = 75;
            trkbr_ClickRange.Name = "trkbr_ClickRange";
            trkbr_ClickRange.Size = new Size(188, 45);
            trkbr_ClickRange.SmallChange = 10;
            trkbr_ClickRange.TabIndex = 0;
            trkbr_ClickRange.TickFrequency = 25;
            trkbr_ClickRange.Value = 75;
            trkbr_ClickRange.ValueChanged += trkbr_ClickRange_ValueChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtbx_RandomizeClickDelay);
            groupBox3.Controls.Add(chkbx_RandomizeClickDelay);
            groupBox3.Controls.Add(txtbx_ClickDelay);
            groupBox3.Controls.Add(label3);
            groupBox3.ForeColor = Color.DarkKhaki;
            groupBox3.Location = new Point(222, 101);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(191, 78);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Click Delay";
            // 
            // txtbx_RandomizeClickDelay
            // 
            txtbx_RandomizeClickDelay.Location = new Point(126, 43);
            txtbx_RandomizeClickDelay.Name = "txtbx_RandomizeClickDelay";
            txtbx_RandomizeClickDelay.Size = new Size(56, 23);
            txtbx_RandomizeClickDelay.TabIndex = 7;
            txtbx_RandomizeClickDelay.Text = "10";
            txtbx_RandomizeClickDelay.TextAlign = HorizontalAlignment.Center;
            // 
            // chkbx_RandomizeClickDelay
            // 
            chkbx_RandomizeClickDelay.AutoSize = true;
            chkbx_RandomizeClickDelay.Location = new Point(6, 45);
            chkbx_RandomizeClickDelay.Name = "chkbx_RandomizeClickDelay";
            chkbx_RandomizeClickDelay.Size = new Size(117, 19);
            chkbx_RandomizeClickDelay.TabIndex = 6;
            chkbx_RandomizeClickDelay.Text = "Randomize Delay";
            chkbx_RandomizeClickDelay.UseVisualStyleBackColor = true;
            chkbx_RandomizeClickDelay.CheckedChanged += chkbx_RandomizeClickDelay_CheckedChanged;
            // 
            // txtbx_ClickDelay
            // 
            txtbx_ClickDelay.Location = new Point(126, 14);
            txtbx_ClickDelay.Name = "txtbx_ClickDelay";
            txtbx_ClickDelay.Size = new Size(56, 23);
            txtbx_ClickDelay.TabIndex = 5;
            txtbx_ClickDelay.Text = "10";
            txtbx_ClickDelay.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 22);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Delay";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(chkbx_ForceMovement);
            groupBox4.Controls.Add(cmbx_ForceMovementKey);
            groupBox4.Controls.Add(cmbx_MouseMovementKey);
            groupBox4.ForeColor = Color.DarkKhaki;
            groupBox4.Location = new Point(12, 101);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(204, 78);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Movement Keys";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 22);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 3;
            label4.Text = "Mouse Key";
            // 
            // chkbx_ForceMovement
            // 
            chkbx_ForceMovement.AutoSize = true;
            chkbx_ForceMovement.Location = new Point(6, 45);
            chkbx_ForceMovement.Name = "chkbx_ForceMovement";
            chkbx_ForceMovement.Size = new Size(88, 19);
            chkbx_ForceMovement.TabIndex = 2;
            chkbx_ForceMovement.Text = "Force Move";
            chkbx_ForceMovement.UseVisualStyleBackColor = true;
            chkbx_ForceMovement.CheckedChanged += chkbx_ForceMovement_CheckedChanged;
            // 
            // cmbx_ForceMovementKey
            // 
            cmbx_ForceMovementKey.FormattingEnabled = true;
            cmbx_ForceMovementKey.Location = new Point(112, 43);
            cmbx_ForceMovementKey.Name = "cmbx_ForceMovementKey";
            cmbx_ForceMovementKey.Size = new Size(86, 23);
            cmbx_ForceMovementKey.TabIndex = 1;
            cmbx_ForceMovementKey.SelectedIndexChanged += cmbx_ForceMovementKey_SelectedIndexChanged;
            // 
            // cmbx_MouseMovementKey
            // 
            cmbx_MouseMovementKey.FormattingEnabled = true;
            cmbx_MouseMovementKey.Location = new Point(112, 14);
            cmbx_MouseMovementKey.Name = "cmbx_MouseMovementKey";
            cmbx_MouseMovementKey.Size = new Size(86, 23);
            cmbx_MouseMovementKey.TabIndex = 0;
            cmbx_MouseMovementKey.SelectedIndexChanged += cmbx_MouseMovementKey_SelectedIndexChanged;
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(423, 191);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = Color.GreenYellow;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(443, 146);
            Name = "OptionsForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Config";
            TopMost = true;
            FormClosed += OptionsForm_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkbr_ClickRange).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtbx_YOffset;
        private Label label2;
        private TextBox txtbx_XOffset;
        private Label label1;
        private GroupBox groupBox2;
        private TrackBar trkbr_ClickRange;
        private TextBox txtbx_ClickRange;
        private GroupBox groupBox3;
        private TextBox txtbx_ClickDelay;
        private Label label3;
        private CheckBox chkbx_RandomizeClickDelay;
        private TextBox txtbx_RandomizeClickDelay;
        private CheckBox chkbx_UseRadialTurning;
        private CheckBox chkbx_ClickMaxDistance;
        private GroupBox groupBox4;
        private CheckBox chkbx_ForceMovement;
        private ComboBox cmbx_ForceMovementKey;
        private ComboBox cmbx_MouseMovementKey;
        private Label label4;
    }
}