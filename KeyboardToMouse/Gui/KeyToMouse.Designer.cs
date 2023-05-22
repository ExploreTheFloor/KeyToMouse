using System.ComponentModel;

namespace KeyboardToMouse.Gui
{
    partial class KeyToMouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            lbl_PressedKeys = new Label();
            cmbx_ProcessSelection = new ComboBox();
            btn_StartStop = new Button();
            btn_ExitApplication = new Button();
            btn_Options = new Button();
            SuspendLayout();
            // 
            // lbl_PressedKeys
            // 
            lbl_PressedKeys.AutoSize = true;
            lbl_PressedKeys.Location = new Point(0, 22);
            lbl_PressedKeys.Name = "lbl_PressedKeys";
            lbl_PressedKeys.Size = new Size(225, 50);
            lbl_PressedKeys.TabIndex = 0;
            lbl_PressedKeys.Text = "Placeholder";
            // 
            // cmbx_ProcessSelection
            // 
            cmbx_ProcessSelection.BackColor = SystemColors.ActiveCaption;
            cmbx_ProcessSelection.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbx_ProcessSelection.ForeColor = SystemColors.ActiveCaptionText;
            cmbx_ProcessSelection.FormattingEnabled = true;
            cmbx_ProcessSelection.Location = new Point(0, 1);
            cmbx_ProcessSelection.Name = "cmbx_ProcessSelection";
            cmbx_ProcessSelection.Size = new Size(112, 21);
            cmbx_ProcessSelection.TabIndex = 1;
            cmbx_ProcessSelection.SelectedValueChanged += cmbx_ProcessSelection_SelectedValueChanged;
            // 
            // btn_StartStop
            // 
            btn_StartStop.BackColor = Color.FromArgb(64, 64, 64);
            btn_StartStop.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_StartStop.ForeColor = Color.GreenYellow;
            btn_StartStop.Location = new Point(172, 0);
            btn_StartStop.Name = "btn_StartStop";
            btn_StartStop.Size = new Size(60, 21);
            btn_StartStop.TabIndex = 2;
            btn_StartStop.Text = "Start";
            btn_StartStop.UseVisualStyleBackColor = false;
            btn_StartStop.Click += btn_StartStop_Click;
            // 
            // btn_ExitApplication
            // 
            btn_ExitApplication.BackColor = Color.Red;
            btn_ExitApplication.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ExitApplication.ForeColor = SystemColors.ActiveCaptionText;
            btn_ExitApplication.Location = new Point(231, 0);
            btn_ExitApplication.Name = "btn_ExitApplication";
            btn_ExitApplication.Size = new Size(52, 21);
            btn_ExitApplication.TabIndex = 3;
            btn_ExitApplication.Text = "Exit";
            btn_ExitApplication.UseVisualStyleBackColor = false;
            btn_ExitApplication.Click += btn_ExitApplication_Click;
            // 
            // btn_Options
            // 
            btn_Options.BackColor = Color.FromArgb(128, 128, 255);
            btn_Options.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Options.ForeColor = Color.Ivory;
            btn_Options.Location = new Point(113, 0);
            btn_Options.MaximumSize = new Size(60, 21);
            btn_Options.MinimumSize = new Size(60, 21);
            btn_Options.Name = "btn_Options";
            btn_Options.Size = new Size(60, 21);
            btn_Options.TabIndex = 5;
            btn_Options.Text = "Config";
            btn_Options.UseVisualStyleBackColor = false;
            btn_Options.Click += btn_Options_Click;
            // 
            // KeyToMouse
            // 
            AutoScaleDimensions = new SizeF(22F, 50F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(283, 69);
            Controls.Add(btn_Options);
            Controls.Add(btn_ExitApplication);
            Controls.Add(btn_StartStop);
            Controls.Add(cmbx_ProcessSelection);
            Controls.Add(lbl_PressedKeys);
            Font = new Font("Sitka Text", 26.2499962F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.GreenYellow;
            Margin = new Padding(9, 10, 9, 10);
            MaximizeBox = false;
            MaximumSize = new Size(299, 108);
            MinimizeBox = false;
            MinimumSize = new Size(299, 108);
            Name = "KeyToMouse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KeyToMouse";
            TopMost = true;
            FormClosed += KeyToMouse_FormClosed;
            Load += KeyToMouse_Load;
            MouseDown += KeyToMouse_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_PressedKeys;
        private ComboBox cmbx_ProcessSelection;
        private Button btn_StartStop;
        private Button btn_ExitApplication;
        private TextBox lbl_offset;
        private Button btn_Options;
    }
}