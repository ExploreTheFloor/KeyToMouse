using System.Collections.Concurrent;
using System.Diagnostics;
using KeyboardToMouse.KBM;
using KeyboardToMouse.Win;

namespace KeyboardToMouse.Gui
{
    public partial class KeyToMouse : Form
    {
        public KeyToMouse()
        {
            InitializeComponent();
            WindowManager.SetTopMost(this.Handle);
        }

        bool _isStarted = false;
        IntPtr _hwnd;
        private Point _centerPoint = Point.Empty;
        private readonly ConcurrentDictionary<string, Keys> _keys = new();
        private Thread? _workerThread;
        LowLevelKeyboardHook _kbh;

        public enum SupportedApplications
        {
            Diablo,
            MsPaint,
            Notepad
        }

        #region Form Events

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private void KeyToMouse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinApi.ReleaseCapture();
                WinApi.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void KeyToMouse_Load(object sender, EventArgs e)
        {
            lbl_PressedKeys.Text = String.Empty;
            //Console.WriteLine($"Hooking Keyboard");
            _kbh = new LowLevelKeyboardHook();

            List<string> processes = new List<string>();
            foreach (Process p in SupportedProcesses)
            {
                processes.Add($@"{p.ProcessName.Split(" ")[0]} {p.Id}");
            }

            cmbx_ProcessSelection.DataSource = processes.OrderBy(x => x).ToList();
            Activate();
        }

        private void KeyToMouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            _isStarted = false;
            _workerThread?.Join();

            //Console.WriteLine($"Unhooking Keyboard");
        }

        private void btn_ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_StartStop_Click(object sender, EventArgs e)
        {
            if (!_isStarted)
            {
                var selectedProcess = Process.GetProcesses().FirstOrDefault(x =>
                    x.ProcessName.ToLower().Contains(cmbx_ProcessSelection.SelectedItem.ToString()?.Split(" ")[0].ToLower() ?? string.Empty) &&
                    x.Id == Convert.ToInt32(cmbx_ProcessSelection.SelectedItem.ToString()?.Split(" ")[1].ToLower() ?? string.Empty));

                if (selectedProcess == null)
                {
                    MessageBox.Show($"Process {cmbx_ProcessSelection.SelectedItem} does not exist.");
                    return;
                }

                var windowRect = WindowManager.GetActualWindowRectangle(selectedProcess.MainWindowHandle);
                _centerPoint = windowRect.GetWindowMiddlePoint();
                _hwnd = selectedProcess.MainWindowHandle;

                this.Location = new Point(windowRect.X + (windowRect.Width - windowRect.X) / 2, windowRect.Y + 35);
                FormBorderStyle = FormBorderStyle.None;
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Maroon;
                TransparencyKey = Color.Maroon;

                _isStarted = true;
                btn_StartStop.Text = "Stop";
                btn_StartStop.ForeColor = Color.Red;
                _kbh.OnKeyPressed += kbh_OnKeyPressed;
                _kbh.OnKeyUnpressed += kbh_OnKeyUnPressed;
                _kbh.HookKeyboard();
                _workerThread = new Thread(MouseMovement);
                _workerThread.Start();
                return;
            }
            FormBorderStyle = FormBorderStyle.Fixed3D;
            SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            BackColor = Color.FromArgb(64, 64, 64); ;
            TransparencyKey = Color.Maroon;

            _isStarted = false;
            btn_StartStop.Text = "Start";
            btn_StartStop.ForeColor = Color.YellowGreen;
            _kbh.OnKeyPressed -= kbh_OnKeyPressed;
            _kbh.OnKeyUnpressed -= kbh_OnKeyUnPressed;
            _kbh.UnHookKeyboard();
            _workerThread?.Join();
            _workerThread = null;
        }

        private void cmbx_ProcessSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedProcess = Process.GetProcesses().FirstOrDefault(x => //x.MainWindowHandle > 0 &&
                x.ProcessName.ToLower().Contains(cmbx_ProcessSelection.SelectedItem.ToString()?.Split(" ")[0].ToLower() ?? string.Empty) &&
                x.Id == Convert.ToInt32(cmbx_ProcessSelection.SelectedItem.ToString()?.Split(" ")[1].ToLower() ?? string.Empty));

            if (selectedProcess == null)
            {
                MessageBox.Show($"Process {cmbx_ProcessSelection.SelectedItem} does not exist.");
                return;
            }

            WinApi.SetForegroundWindow(selectedProcess.MainWindowHandle);
        }

        #endregion Form Events

        #region Functions

        public static List<Process> SupportedProcesses
        {
            get
            {
                return Process.GetProcesses().Where(x =>
                        x.MainWindowHandle != IntPtr.Zero && Enum.GetNames(typeof(SupportedApplications))
                            .Any(y => x.ProcessName.RemoveAllNonAlphaNumeric().ToLower().Contains(y.ToLower())))
                    .OrderBy(x => x.ProcessName).ToList();
            }
        }

        private Keys _lastKeyPushed = Keys.None;
        public void kbh_OnKeyPressed(object sender, Keys e)
        {
            //Console.WriteLine($"{e} key pressed.");
            Invoke(() => lbl_PressedKeys.Text += $"{e},");

            if (e is Keys.A or Keys.W or Keys.S or Keys.D)
            {
                if (!_keys.ContainsKey(e.ToString()))
                {
                    Invoke(() => _lastKeyPushed = e);
                    Invoke(() => _keys.TryAdd(e.ToString(), e));
                }
            }
        }

        public void kbh_OnKeyUnPressed(object sender, Keys e)
        {
            Invoke(() => lbl_PressedKeys.Text = lbl_PressedKeys.Text.Replace($"{e},", String.Empty));
            try
            {
                //Console.WriteLine($"{e} key unpressed.");
                if (e == Keys.Escape)
                {
                    _isStarted = false;
                    _workerThread?.Join();
                    Application.Exit();
                }

                if (e is Keys.A or Keys.W or Keys.S or Keys.D)
                {
                    Invoke(() => _keys.TryRemove(e.ToString(), out e));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void MouseMovement()
        {
            while (_isStarted)
            {
                Invoke(() => _keys);
                if (Global.Default.RandomizeClickDelay)
                {
                    var rand = new Random();
                    var random = rand.Next(0, Global.Default.RandomClickDelay);
                    Thread.Sleep(Global.Default.ClickDelay + random);
                }
                else
                    Thread.Sleep(Global.Default.ClickDelay);

                var windowRect = WindowManager.GetInnerWindowRectangle(_hwnd);
                _centerPoint = windowRect.GetMiddlePoint();

                //var ctrlKey = new Key(Messaging.VKeys.KEY_Q);
                //ctrlKey.Down(_hwnd, false);

                //Single Keys

                #region Radial Turning

                if (Global.Default.UseRadialTurning)
                {
                    if (_keys.ContainsKey(Keys.A.ToString()) && _keys.ContainsKey(Keys.S.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.A:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.S:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    //A + W KEYS
                    else if (_keys.ContainsKey(Keys.A.ToString()) && _keys.ContainsKey(Keys.W.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.A:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.W:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    //D + S KEYS
                    else if (_keys.ContainsKey(Keys.D.ToString()) && _keys.ContainsKey(Keys.S.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.D:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.S:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    //D + W KEYS
                    else if (_keys.ContainsKey(Keys.D.ToString()) && _keys.ContainsKey(Keys.W.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.D:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.W:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    //W KEY
                    else if (_keys.ContainsKey(Keys.W.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.A:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.D:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    //S KEY
                    else if (_keys.ContainsKey(Keys.S.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.A:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.D:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    //D KEY
                    else if (_keys.ContainsKey(Keys.D.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.W:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.S:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    //A KEY
                    else if (_keys.ContainsKey(Keys.A.ToString()))
                    {
                        switch (_lastKeyPushed)
                        {
                            case Keys.W:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            case Keys.S:
                                MouseManager.LinearSmoothClick(_hwnd,
                                    MouseManager.MouseButton.Left,
                                    new Point(_centerPoint.X + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    5,
                                    Global.Default.ClickDelay);
                                break;
                            default:
                                MouseManager.ClickAtPosition(_hwnd,
                                    new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                                        _centerPoint.Y + Global.Default.YOffset),
                                    MouseManager.MouseButton.Left);
                                break;
                        }
                    }
                    else
                    {
                        continue;
                    }

                    _lastKeyPushed = Keys.None;
                    continue;
                }

                #endregion Radial Turning

                #region Max Range Turning

                if (Global.Default.ClickMaxDistance)
                {
                    if (_keys.ContainsKey(Keys.A.ToString()) && _keys.ContainsKey(Keys.S.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(
                                _centerPoint.X - windowRect.Width/2 + 10,
                                _centerPoint.Y + windowRect.Height/2 - 10
                                ),
                            MouseManager.MouseButton.Left);
                        continue;
                    }

                    if (_keys.ContainsKey(Keys.A.ToString()) && _keys.ContainsKey(Keys.W.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(
                                _centerPoint.X - windowRect.Width / 2 + 10,
                                _centerPoint.Y - windowRect.Height / 2 + 10
                            ),
                            MouseManager.MouseButton.Left);
                        continue;
                    }

                    if (_keys.ContainsKey(Keys.D.ToString()) && _keys.ContainsKey(Keys.S.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(
                                _centerPoint.X + windowRect.Width / 2 - 10,
                                _centerPoint.Y + windowRect.Height / 2 - 10
                            ),
                            MouseManager.MouseButton.Left);
                        continue;
                    }

                    if (_keys.ContainsKey(Keys.D.ToString()) && _keys.ContainsKey(Keys.W.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(
                                _centerPoint.X + windowRect.Width / 2 - 10,
                                _centerPoint.Y - windowRect.Height / 2 + 10
                            ),
                            MouseManager.MouseButton.Left);
                        continue;
                    }

                    //Single Keys
                    if (_keys.ContainsKey(Keys.W.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(_centerPoint.X + Global.Default.XOffset,
                                _centerPoint.Y - windowRect.Height / 2 + 10),
                            MouseManager.MouseButton.Left);
                        continue;
                    }

                    if (_keys.ContainsKey(Keys.S.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(_centerPoint.X + Global.Default.XOffset,
                                _centerPoint.Y + windowRect.Height / 2 + 10),
                            MouseManager.MouseButton.Left);
                        continue;
                    }

                    if (_keys.ContainsKey(Keys.D.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(_centerPoint.X + windowRect.Width / 2 - 10,
                                _centerPoint.Y + Global.Default.YOffset), MouseManager.MouseButton.Left);
                        continue;
                    }

                    if (_keys.ContainsKey(Keys.A.ToString()))
                    {
                        MouseManager.ClickAtPosition(_hwnd,
                            new Point(_centerPoint.X - windowRect.Width / 2 - 10,
                                _centerPoint.Y + Global.Default.YOffset), MouseManager.MouseButton.Left);
                        continue;
                    }
                }

                #endregion Max Range Turning

                #region Regular Turning

                if (_keys.ContainsKey(Keys.A.ToString()) && _keys.ContainsKey(Keys.S.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                            _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                        MouseManager.MouseButton.Left);
                    continue;
                }

                if (_keys.ContainsKey(Keys.A.ToString()) && _keys.ContainsKey(Keys.W.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X - Global.Default.ClickDistance + Global.Default.XOffset,
                            _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                        MouseManager.MouseButton.Left);
                    continue;
                }

                if (_keys.ContainsKey(Keys.D.ToString()) && _keys.ContainsKey(Keys.S.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                            _centerPoint.Y + Global.Default.ClickDistance + Global.Default.YOffset),
                        MouseManager.MouseButton.Left);
                    continue;
                }

                if (_keys.ContainsKey(Keys.D.ToString()) && _keys.ContainsKey(Keys.W.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X + Global.Default.ClickDistance + Global.Default.XOffset,
                            _centerPoint.Y - Global.Default.ClickDistance + Global.Default.YOffset),
                        MouseManager.MouseButton.Left);
                    continue;
                }

                //Single Keys
                if (_keys.ContainsKey(Keys.W.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X + Global.Default.XOffset,
                            _centerPoint.Y - Global.Default.ClickDistance),
                        MouseManager.MouseButton.Left);
                    continue;
                }

                if (_keys.ContainsKey(Keys.S.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X + Global.Default.XOffset,
                            _centerPoint.Y + Global.Default.ClickDistance),
                        MouseManager.MouseButton.Left);
                    continue;
                }

                if (_keys.ContainsKey(Keys.D.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X + Global.Default.ClickDistance,
                            _centerPoint.Y + Global.Default.YOffset), MouseManager.MouseButton.Left);
                    continue;
                }

                if (_keys.ContainsKey(Keys.A.ToString()))
                {
                    MouseManager.ClickAtPosition(_hwnd,
                        new Point(_centerPoint.X - Global.Default.ClickDistance,
                            _centerPoint.Y + Global.Default.YOffset), MouseManager.MouseButton.Left);
                    continue;
                }

                #endregion Regular Turning

                //ctrlKey.Up(_hwnd, false);
            }
        }

        #endregion Functions

        private OptionsForm optionsForm;
        private bool optionsFormShown = false;
        private void btn_Options_Click(object sender, EventArgs e)
        {
            if (optionsFormShown)
            {
                optionsForm.Close();
                optionsFormShown = false;
                return;
            }
            optionsForm = new OptionsForm();
            if (_isStarted)
            {
                optionsForm.FormBorderStyle = FormBorderStyle.None;
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                optionsForm.BackColor = Color.Maroon;
                optionsForm.TransparencyKey = Color.Maroon;
                optionsForm.Left = Location.X - 75;
                optionsForm.Top = Location.Y + 20;
            }
            else
            {
                optionsForm.Left = Location.X - 75;
                optionsForm.Top = Location.Y + 101;
            }

            optionsFormShown = true;
            optionsForm.Show();
        }
    }
}