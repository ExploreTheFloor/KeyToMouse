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
using Keyboard;
using static KeyboardToMouse.KBM.MouseManager;
using static Keyboard.Messaging;

namespace KeyboardToMouse.Gui
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            WindowManager.SetTopMost(this.Handle);
            PopulateGui();
            LoadSettings();
        }

        private void PopulateGui()
        {
            cmbx_MouseMovementKey.DataSource = Enum.GetValues(typeof(MouseButton)).Cast<MouseButton>().ToList();
            cmbx_ForceMovementKey.DataSource = Enum.GetValues(typeof(VKeys)).Cast<VKeys>().ToList();
            //Movement Keys
            cmbx_ForwardKey.DataSource = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToList();
            cmbx_BackwardKey.DataSource = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToList();
            cmbx_LeftKey.DataSource = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToList();
            cmbx_RightKey.DataSource = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToList();
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
            //Force Movement
            cmbx_MouseMovementKey.Text = Global.Default.MouseMovementKey;
            chkbx_ForceMovement.Checked = Global.Default.ForceMovement;
            cmbx_ForceMovementKey.Text = Global.Default.ForceMovementKey;
            //
            cmbx_ForwardKey.Text = Global.Default.ForwardKey;
            cmbx_BackwardKey.Text = Global.Default.BackwardKey;
            cmbx_LeftKey.Text = Global.Default.LeftKey;
            cmbx_RightKey.Text = Global.Default.RightKey;
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
            //Force Movement
            Global.Default.MouseMovementKey = cmbx_MouseMovementKey.Text;
            Global.Default.ForceMovement = chkbx_ForceMovement.Checked;
            Global.Default.ForceMovementKey = cmbx_ForceMovementKey.Text;
            //
            Global.Default.ForwardKey = cmbx_ForwardKey.Text;
            Global.Default.BackwardKey = cmbx_BackwardKey.Text;
            Global.Default.LeftKey = cmbx_LeftKey.Text;
            Global.Default.RightKey = cmbx_RightKey.Text;
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

        private void chkbx_ForceMovement_CheckedChanged(object sender, EventArgs e)
        {
            Global.Default.ForceMovement = chkbx_ForceMovement.Checked;
            cmbx_ForceMovementKey.Enabled = chkbx_ForceMovement.Checked;
        }
    }
}
