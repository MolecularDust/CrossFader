using ScriptPortal.Vegas;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossFader
{
    public partial class CrossFaderForm : Form
    {
        public Settings Settings { get; set; }

        bool IsInitializing = true;

        Graphics DrawArea;
        Pen Pen;
        PictureBox Box;
        int BoxRight;
        int BoxBottom;

        public CrossFaderForm(Settings settings)
        {
            InitializeComponent();

            Settings = settings;

            DrawArea = pictureBoxDrawArea.CreateGraphics();
            DrawArea.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Box = pictureBoxDrawArea;
            BoxRight = Box.Width - 2;            BoxBottom = Box.Height - 2;
            Pen = new Pen(Color.LightGray, 4);

            this.numericUpDownFadeTime.DataBindings.Add( "Value", Settings, "CrossFadeLength", false, DataSourceUpdateMode.OnPropertyChanged);

            this.comboBoxTimeUnit.DataSource = Enum.GetValues(typeof(TimeUnit));
            this.comboBoxTimeUnit.DataBindings.Add("SelectedItem", Settings, "TimeUnit", false, DataSourceUpdateMode.OnPropertyChanged);
            
            this.checkBoxAllowLoops.DataBindings.Add("Checked", Settings, "AllowLoops", false, DataSourceUpdateMode.OnPropertyChanged);

            this.comboBoxScriptMode.DataSource = new BindingSource(Settings.ScriptModesList, null);
            this.comboBoxScriptMode.DisplayMember = "Value";
            this.comboBoxScriptMode.ValueMember = "Key";
            this.comboBoxScriptMode.DataBindings.Add("SelectedValue", Settings, "ScriptMode", false, DataSourceUpdateMode.OnPropertyChanged);

            this.checkBoxChangeCurveType.DataBindings.Add("Checked", Settings, "ChangeCurveType", false, DataSourceUpdateMode.OnPropertyChanged);

            this.comboBoxLeftCurve.DataSource = new BindingSource(Settings.LeftCurveTypes, null);
            this.comboBoxLeftCurve.DisplayMember = "Value";
            this.comboBoxLeftCurve.ValueMember = "Key";
            this.comboBoxLeftCurve.DataBindings.Add("SelectedValue", Settings, "LeftCurveType", false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxLeftCurve.Enabled = Settings.ChangeCurveType;

            this.comboBoxRightCurve.DataSource = new BindingSource(Settings.RightCurveTypes, null);
            this.comboBoxRightCurve.DisplayMember = "Value";
            this.comboBoxRightCurve.ValueMember = "Key";
            this.comboBoxRightCurve.DataBindings.Add("SelectedValue", Settings, "RightCurveType", false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxRightCurve.Enabled = Settings.ChangeCurveType;

            this.comboBoxTransitionMode.DataSource = new BindingSource(Settings.TransitionModeList, null);
            this.comboBoxTransitionMode.DisplayMember = "Value";
            this.comboBoxTransitionMode.ValueMember = "Key";
            this.comboBoxTransitionMode.DataBindings.Add("SelectedValue", Settings, "TransitionMode", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void comboBoxTransitionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxTransitionModeEnableStatus();
            UpdateTransitionsList();
        }

        void ComboBoxTransitionModeEnableStatus()
        {
            if (Settings.TransitionMode == TransitionMode.AddTransition )
                this.comboBoxTransitions.Enabled = true;
            else
                this.comboBoxTransitions.Enabled = false;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CrossFaderForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.numericUpDownFadeTime;
            this.numericUpDownFadeTime.Select(0, numericUpDownFadeTime.Text.Length);
        }

        private async void CrossFaderForm_Shown(object sender, EventArgs e)
        {
            await Task.Delay(100); // Wait until form renders
            IsInitializing = false;
            UpdateTransitionsList();
        }

        void UpdateTransitionsList()
        {
            if (!IsInitializing && Settings.TransitionMode == TransitionMode.AddTransition && this.comboBoxTransitions.DataSource == null)
            {
                    Cursor.Current = Cursors.WaitCursor;
                    this.comboBoxTransitions.DataSource = Settings.GetTransitions().ToArray();
                    this.comboBoxTransitions.DataBindings.Add("SelectedItem", Settings, "TransitionAndPresetName", false, DataSourceUpdateMode.OnPropertyChanged);
                    Settings.TransitionAndPresetName = this.comboBoxTransitions.SelectedItem.ToString();
                    Cursor.Current = Cursors.Default;
            }
        }

        private void checkBoxChangeCurveType_CheckedChanged(object sender, EventArgs e)
        {
            var state = this.checkBoxChangeCurveType.Checked;
            this.comboBoxRightCurve.Enabled = state;
            this.comboBoxLeftCurve.Enabled = state;
        }

        private void comboBoxLeftCurve_SelectedIndexChanged(object sender, EventArgs e)
        {
            Box.Invalidate(); // Causes graphics redraw
        }

        private void comboBoxRightCurve_SelectedIndexChanged(object sender, EventArgs e)
        {
            Box.Invalidate(); // Causes graphics redraw
        }

        private void pictureBoxDrawArea_Paint(object sender, PaintEventArgs e)
        {
            DrawCurves(e.Graphics);
        }

        enum FadeIs
        {
            Left,
            Right
        }

        void DrawCurve(FadeIs fadeIs, CurveType curve, Graphics graphics)
        {
            Point p1 = new Point();
            Point c1 = new Point();
            Point c2 = new Point();
            Point p2 = new Point();

            if (fadeIs == FadeIs.Left)
            {
                switch (curve)
                {
                    case CurveType.Slow:
                        // Left Slow Curve
                        p1 = new Point(1, 1);   // Start point
                        c1 = new Point(Convert.ToInt32(BoxRight * 0.5), 1);   // First control point
                        c2 = new Point(BoxRight, Convert.ToInt32(BoxBottom * 0.5));  // Second control point
                        p2 = new Point(BoxRight, BoxBottom);  // Endpoint
                        break;
                    case CurveType.Linear:
                        // Left Linear Curve
                        p1 = new Point(1, 1);   // Start point
                        c1 = new Point(1, 1);   // First control point
                        c2 = new Point(BoxRight, BoxBottom);  // Second control point
                        p2 = new Point(BoxRight, BoxBottom);  // Endpoint
                        break;
                    case CurveType.Sharp:
                        // Left Sharp Curve
                        p1 = new Point(1, 1);   // Start point
                        c1 = new Point(1, Convert.ToInt32(BoxBottom * 0.66));   // First control point
                        c2 = new Point(BoxRight, Convert.ToInt32(BoxBottom * 0.33));  // Second control point
                        p2 = new Point(BoxRight, BoxBottom);  // Endpoint
                        break;
                    case CurveType.Fast:
                        // Left Fast Curve
                        p1 = new Point(1, 1);   // Start point
                        c1 = new Point(1, Convert.ToInt32(BoxBottom * 0.5));   // First control point
                        c2 = new Point(Convert.ToInt32(BoxRight * 0.5), BoxBottom);  // Second control point
                        p2 = new Point(BoxRight, BoxBottom);  // Endpoint
                        break;
                    case CurveType.Smooth:
                        // Left Smooth Curve
                        p1 = new Point(1, 1);   // Start point
                        c1 = new Point(Convert.ToInt32(BoxRight * 0.66), 1);   // First control point
                        c2 = new Point(Convert.ToInt32(BoxRight * 0.33), BoxBottom);  // Second control point
                        p2 = new Point(BoxRight, BoxBottom);  // Endpoint
                        break;
                }
            }
            else // Right
            {
                switch (curve)
                {
                    case CurveType.Slow:
                        // Right Fast Curve
                        p1 = new Point(1, BoxBottom);   // Start point
                        c1 = new Point(Convert.ToInt32(BoxRight * 0.5), BoxBottom);   // First control point
                        c2 = new Point(BoxRight, Convert.ToInt32(BoxBottom * 0.5));  // Second control point
                        p2 = new Point(BoxRight, 1);  // Endpoint
                        break;
                    case CurveType.Linear:
                        // Right Linear Curve
                        p1 = new Point(1, BoxBottom);   // Start point
                        c1 = new Point(1, BoxBottom);   // First control point
                        c2 = new Point(BoxRight, 1);  // Second control point
                        p2 = new Point(BoxRight, 1);  // Endpoint
                        break;
                    case CurveType.Sharp:
                        // Right Sharp Curve
                        p1 = new Point(1, BoxBottom);   // Start point
                        c1 = new Point(1, Convert.ToInt32(BoxBottom * 0.33));   // First control point
                        c2 = new Point(BoxRight, Convert.ToInt32(BoxBottom * 0.66));  // Second control point
                        p2 = new Point(BoxRight, 1);  // Endpoint
                        break;
                    case CurveType.Fast:
                        // Right Slow Curve
                        p1 = new Point(1, BoxBottom);   // Start point
                        c1 = new Point(1, Convert.ToInt32(BoxBottom * 0.5));   // First control point
                        c2 = new Point(Convert.ToInt32(BoxRight * 0.5), 1);  // Second control point
                        p2 = new Point(BoxRight, 1);  // Endpoint
                        break;
                    case CurveType.Smooth:
                        // Right Smooth Curve
                        p1 = new Point(1, BoxBottom);   // Start point
                        c1 = new Point(Convert.ToInt32(BoxRight * 0.66), BoxBottom);   // First control point
                        c2 = new Point(Convert.ToInt32(BoxRight * 0.33), 1);  // Second control point
                        p2 = new Point(BoxRight, 1);  // Endpoint
                        break;
                }
            }
            graphics.DrawBezier(Pen, p1, c1, c2, p2);
        }

        void DrawCurves(Graphics graphics)
        {
            if (this.comboBoxLeftCurve.SelectedItem != null && this.comboBoxRightCurve.SelectedItem != null)
            {
                graphics.DrawRectangle(Pen, 1, 1, BoxRight, BoxBottom);
                DrawCurve(FadeIs.Left, (CurveType)this.comboBoxLeftCurve.SelectedValue, graphics);
                DrawCurve(FadeIs.Right, (CurveType)this.comboBoxRightCurve.SelectedValue, graphics);
            }
        }

        private void comboBoxScriptMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Settings.ScriptMode == ScriptMode.RemoveCrossfades || Settings.ScriptMode == ScriptMode.DoNothingWithCrossfades)
            {
                this.numericUpDownFadeTime.Enabled = false;
                this.comboBoxTimeUnit.Enabled = false;
                this.checkBoxAllowLoops.Enabled = false;
                this.checkBoxAllowLoops.Checked = false;
                this.checkBoxChangeCurveType.Enabled = false;
                this.checkBoxChangeCurveType.Checked = false;
            }
            else
            {
                this.numericUpDownFadeTime.Enabled = true;
                this.comboBoxTimeUnit.Enabled = true;
                this.checkBoxAllowLoops.Enabled = true;
                this.checkBoxChangeCurveType.Enabled = true;
                if (Settings.ScriptMode == ScriptMode.ChangeExistingCrossfades)
                {
                    this.checkBoxChangeCurveType.Checked = true;
                    this.numericUpDownFadeTime.Enabled = false;
                    this.comboBoxTimeUnit.Enabled = false;
                }
                    
                if (Settings.ScriptMode == ScriptMode.CreateNewCrossfades)
                    this.checkBoxChangeCurveType.Checked = false;
            }
        }

        private void editScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fullPath = Settings.Vegas.InstallationDirectory + "\\Script Menu" + "\\" + Settings.ScriptFileName; ;
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "notepad.exe";
                proc.StartInfo.Arguments = fullPath;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message != "The operation was canceled by the user")
                    MessageBox.Show(
                        string.Format("Failed to open {0} in Notepad.", fullPath) + Environment.NewLine + Environment.NewLine + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}
