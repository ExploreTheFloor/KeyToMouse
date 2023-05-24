using KeyboardToMouse.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KeyboardToMouse.KBM.MouseManager;

namespace KeyboardToMouse.Gui
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            LoadSettings();
            WindowManager.SetTopMost(this.Handle);
            PopulateGui();
        }

        private void PopulateGui()
        {
            cmbx_MouseMovementKey.DataSource = Enum.GetValues(typeof(MouseButton)).Cast<MouseButton>().ToList();
            cmbx_ForceMovementKey.DataSource = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToList();
        }
        private void LoadSettings()
        {
            trkbr_ClickRange.Value = Global.Default.ClickDistance;
            txtbx_XOffset.Text = Global.Default.XOffset.ToString();
            txtbx_YOffset.Text = Global.Default.YOffset.ToString();
            txtbx_ClickDelay.Text = Global.Default.ClickDelay.ToString();
            chkbx_RandomizeClickDelay.Checked = Global.Default.RandomizeClickDelay;
            chkbx_UseRadialTurning.Checked = Global.Default.UseRadialTurning;
            chkbx_ClickMaxDistance.Checked = Global.Default.ClickMaxDistance;
            txtbx_RandomizeClickDelay.Text = Global.Default.RandomClickDelay.ToString();
            cmbx_MouseMovementKey.SelectedText = Global.Default.MouseMovementKey;
            chkbx_ForceMovement.Checked = Global.Default.ForceMovement;
            cmbx_ForceMovementKey.SelectedText = Global.Default.ForceMovementKey;
        }

        private void SaveSettings()
        {
            Global.Default.ClickDistance = Convert.ToInt32(txtbx_ClickRange.Text);
            Global.Default.XOffset = Convert.ToInt32(txtbx_XOffset.Text);
            Global.Default.YOffset = Convert.ToInt32(txtbx_YOffset.Text);
            Global.Default.ClickDelay = Convert.ToInt32(txtbx_ClickDelay.Text);
            Global.Default.RandomizeClickDelay = chkbx_RandomizeClickDelay.Checked;
            Global.Default.UseRadialTurning = chkbx_UseRadialTurning.Checked;
            Global.Default.ClickMaxDistance = chkbx_ClickMaxDistance.Checked;
            Global.Default.RandomClickDelay = Convert.ToInt32(txtbx_RandomizeClickDelay.Text);
            Global.Default.MouseMovementKey = cmbx_MouseMovementKey.SelectedText;
            Global.Default.ForceMovement = chkbx_ForceMovement.Checked;
            Global.Default.ForceMovementKey = cmbx_ForceMovementKey.SelectedText;
            Global.Default.Save();

        }
        private void OptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void trkbr_ClickRange_ValueChanged(object sender, EventArgs e)
        {
            txtbx_ClickRange.Text = trkbr_ClickRange.Value.ToString();
        }

        private void chkbx_RandomizeClickDelay_CheckedChanged(object sender, EventArgs e)
        {
            txtbx_RandomizeClickDelay.Enabled = chkbx_RandomizeClickDelay.Checked;
            Global.Default.RandomizeClickDelay = chkbx_RandomizeClickDelay.Checked;
        }

        private void chkbx_ClickMaxDistance_CheckedChanged(object sender, EventArgs e)
        {
            Global.Default.ClickMaxDistance = chkbx_ClickMaxDistance.Checked;
        }

        private void chkbx_UseRadialTurning_CheckedChanged(object sender, EventArgs e)
        {
            Global.Default.UseRadialTurning = chkbx_UseRadialTurning.Checked;
        }

        private void cmbx_ForceMovementKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.Default.ForceMovementKey = cmbx_ForceMovementKey.SelectedText;
        }

        private void cmbx_MouseMovementKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.Default.MouseMovementKey = cmbx_MouseMovementKey.SelectedText;
        }

        private void chkbx_ForceMovement_CheckedChanged(object sender, EventArgs e)
        {
            Global.Default.ForceMovement = chkbx_ForceMovement.Checked;
            cmbx_ForceMovementKey.Enabled = chkbx_ForceMovement.Checked;
        }
    }
}
