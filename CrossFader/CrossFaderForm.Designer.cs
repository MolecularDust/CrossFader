namespace CrossFader
{
    partial class CrossFaderForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDownFadeTime = new System.Windows.Forms.NumericUpDown();
            this.labelCrossfadeTime = new System.Windows.Forms.Label();
            this.comboBoxRightCurve = new System.Windows.Forms.ComboBox();
            this.comboBoxLeftCurve = new System.Windows.Forms.ComboBox();
            this.labelRightCurve = new System.Windows.Forms.Label();
            this.labelLeftCurve = new System.Windows.Forms.Label();
            this.comboBoxTransitions = new System.Windows.Forms.ComboBox();
            this.comboBoxTimeUnit = new System.Windows.Forms.ComboBox();
            this.labelTimeUnit = new System.Windows.Forms.Label();
            this.pictureBoxDrawArea = new System.Windows.Forms.PictureBox();
            this.checkBoxAllowLoops = new System.Windows.Forms.CheckBox();
            this.comboBoxTransitionMode = new System.Windows.Forms.ComboBox();
            this.groupBoxCurves = new System.Windows.Forms.GroupBox();
            this.checkBoxChangeCurveType = new System.Windows.Forms.CheckBox();
            this.groupBoxTransitions = new System.Windows.Forms.GroupBox();
            this.comboBoxScriptMode = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawArea)).BeginInit();
            this.groupBoxCurves.SuspendLayout();
            this.groupBoxTransitions.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(51, 475);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 20, 3, 10);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(291, 35);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // numericUpDownFadeTime
            // 
            this.numericUpDownFadeTime.Location = new System.Drawing.Point(51, 58);
            this.numericUpDownFadeTime.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.numericUpDownFadeTime.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numericUpDownFadeTime.Name = "numericUpDownFadeTime";
            this.numericUpDownFadeTime.Size = new System.Drawing.Size(136, 20);
            this.numericUpDownFadeTime.TabIndex = 1;
            // 
            // labelCrossfadeTime
            // 
            this.labelCrossfadeTime.AutoSize = true;
            this.labelCrossfadeTime.Location = new System.Drawing.Point(48, 35);
            this.labelCrossfadeTime.Name = "labelCrossfadeTime";
            this.labelCrossfadeTime.Size = new System.Drawing.Size(90, 13);
            this.labelCrossfadeTime.TabIndex = 2;
            this.labelCrossfadeTime.Text = "Crossfade Length";
            // 
            // comboBoxRightCurve
            // 
            this.comboBoxRightCurve.FormattingEnabled = true;
            this.comboBoxRightCurve.Location = new System.Drawing.Point(23, 140);
            this.comboBoxRightCurve.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.comboBoxRightCurve.Name = "comboBoxRightCurve";
            this.comboBoxRightCurve.Size = new System.Drawing.Size(136, 21);
            this.comboBoxRightCurve.TabIndex = 3;
            this.comboBoxRightCurve.SelectedIndexChanged += new System.EventHandler(this.comboBoxRightCurve_SelectedIndexChanged);
            // 
            // comboBoxLeftCurve
            // 
            this.comboBoxLeftCurve.FormattingEnabled = true;
            this.comboBoxLeftCurve.Location = new System.Drawing.Point(23, 86);
            this.comboBoxLeftCurve.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.comboBoxLeftCurve.Name = "comboBoxLeftCurve";
            this.comboBoxLeftCurve.Size = new System.Drawing.Size(136, 21);
            this.comboBoxLeftCurve.TabIndex = 4;
            this.comboBoxLeftCurve.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeftCurve_SelectedIndexChanged);
            // 
            // labelRightCurve
            // 
            this.labelRightCurve.AutoSize = true;
            this.labelRightCurve.Location = new System.Drawing.Point(20, 117);
            this.labelRightCurve.Name = "labelRightCurve";
            this.labelRightCurve.Size = new System.Drawing.Size(63, 13);
            this.labelRightCurve.TabIndex = 5;
            this.labelRightCurve.Text = "Right Curve";
            // 
            // labelLeftCurve
            // 
            this.labelLeftCurve.AutoSize = true;
            this.labelLeftCurve.Location = new System.Drawing.Point(20, 63);
            this.labelLeftCurve.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelLeftCurve.Name = "labelLeftCurve";
            this.labelLeftCurve.Size = new System.Drawing.Size(56, 13);
            this.labelLeftCurve.TabIndex = 6;
            this.labelLeftCurve.Text = "Left Curve";
            // 
            // comboBoxTransitions
            // 
            this.comboBoxTransitions.FormattingEnabled = true;
            this.comboBoxTransitions.Location = new System.Drawing.Point(23, 60);
            this.comboBoxTransitions.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.comboBoxTransitions.Name = "comboBoxTransitions";
            this.comboBoxTransitions.Size = new System.Drawing.Size(291, 21);
            this.comboBoxTransitions.TabIndex = 8;
            // 
            // comboBoxTimeUnit
            // 
            this.comboBoxTimeUnit.FormattingEnabled = true;
            this.comboBoxTimeUnit.Location = new System.Drawing.Point(206, 58);
            this.comboBoxTimeUnit.Name = "comboBoxTimeUnit";
            this.comboBoxTimeUnit.Size = new System.Drawing.Size(136, 21);
            this.comboBoxTimeUnit.TabIndex = 9;
            // 
            // labelTimeUnit
            // 
            this.labelTimeUnit.AutoSize = true;
            this.labelTimeUnit.Location = new System.Drawing.Point(203, 35);
            this.labelTimeUnit.Name = "labelTimeUnit";
            this.labelTimeUnit.Size = new System.Drawing.Size(52, 13);
            this.labelTimeUnit.TabIndex = 10;
            this.labelTimeUnit.Text = "Time Unit";
            // 
            // pictureBoxDrawArea
            // 
            this.pictureBoxDrawArea.Location = new System.Drawing.Point(178, 28);
            this.pictureBoxDrawArea.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.pictureBoxDrawArea.Name = "pictureBoxDrawArea";
            this.pictureBoxDrawArea.Size = new System.Drawing.Size(136, 133);
            this.pictureBoxDrawArea.TabIndex = 12;
            this.pictureBoxDrawArea.TabStop = false;
            this.pictureBoxDrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDrawArea_Paint);
            // 
            // checkBoxAllowLoops
            // 
            this.checkBoxAllowLoops.AutoSize = true;
            this.checkBoxAllowLoops.Location = new System.Drawing.Point(51, 125);
            this.checkBoxAllowLoops.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.checkBoxAllowLoops.Name = "checkBoxAllowLoops";
            this.checkBoxAllowLoops.Size = new System.Drawing.Size(83, 17);
            this.checkBoxAllowLoops.TabIndex = 13;
            this.checkBoxAllowLoops.Text = "Allow Loops";
            this.checkBoxAllowLoops.UseVisualStyleBackColor = true;
            // 
            // comboBoxTransitionMode
            // 
            this.comboBoxTransitionMode.FormattingEnabled = true;
            this.comboBoxTransitionMode.Location = new System.Drawing.Point(23, 26);
            this.comboBoxTransitionMode.Margin = new System.Windows.Forms.Padding(20, 10, 3, 3);
            this.comboBoxTransitionMode.Name = "comboBoxTransitionMode";
            this.comboBoxTransitionMode.Size = new System.Drawing.Size(291, 21);
            this.comboBoxTransitionMode.TabIndex = 14;
            this.comboBoxTransitionMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransitionMode_SelectedIndexChanged);
            // 
            // groupBoxCurves
            // 
            this.groupBoxCurves.Controls.Add(this.checkBoxChangeCurveType);
            this.groupBoxCurves.Controls.Add(this.comboBoxRightCurve);
            this.groupBoxCurves.Controls.Add(this.comboBoxLeftCurve);
            this.groupBoxCurves.Controls.Add(this.pictureBoxDrawArea);
            this.groupBoxCurves.Controls.Add(this.labelRightCurve);
            this.groupBoxCurves.Controls.Add(this.labelLeftCurve);
            this.groupBoxCurves.Location = new System.Drawing.Point(28, 155);
            this.groupBoxCurves.Name = "groupBoxCurves";
            this.groupBoxCurves.Size = new System.Drawing.Size(338, 184);
            this.groupBoxCurves.TabIndex = 15;
            this.groupBoxCurves.TabStop = false;
            this.groupBoxCurves.Text = "Curves";
            // 
            // checkBoxChangeCurveType
            // 
            this.checkBoxChangeCurveType.AutoSize = true;
            this.checkBoxChangeCurveType.Location = new System.Drawing.Point(23, 28);
            this.checkBoxChangeCurveType.Name = "checkBoxChangeCurveType";
            this.checkBoxChangeCurveType.Size = new System.Drawing.Size(121, 17);
            this.checkBoxChangeCurveType.TabIndex = 13;
            this.checkBoxChangeCurveType.Text = "Change Curve Type";
            this.checkBoxChangeCurveType.UseVisualStyleBackColor = true;
            this.checkBoxChangeCurveType.CheckedChanged += new System.EventHandler(this.checkBoxChangeCurveType_CheckedChanged);
            // 
            // groupBoxTransitions
            // 
            this.groupBoxTransitions.Controls.Add(this.comboBoxTransitionMode);
            this.groupBoxTransitions.Controls.Add(this.comboBoxTransitions);
            this.groupBoxTransitions.Location = new System.Drawing.Point(28, 352);
            this.groupBoxTransitions.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBoxTransitions.Name = "groupBoxTransitions";
            this.groupBoxTransitions.Size = new System.Drawing.Size(338, 100);
            this.groupBoxTransitions.TabIndex = 16;
            this.groupBoxTransitions.TabStop = false;
            this.groupBoxTransitions.Text = "Video Transitions";
            // 
            // comboBoxScriptMode
            // 
            this.comboBoxScriptMode.FormattingEnabled = true;
            this.comboBoxScriptMode.Location = new System.Drawing.Point(51, 91);
            this.comboBoxScriptMode.Name = "comboBoxScriptMode";
            this.comboBoxScriptMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxScriptMode.Size = new System.Drawing.Size(291, 21);
            this.comboBoxScriptMode.TabIndex = 17;
            this.comboBoxScriptMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxScriptMode_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editScriptToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(395, 27);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStripMainMenu";
            // 
            // editScriptToolStripMenuItem
            // 
            this.editScriptToolStripMenuItem.Name = "editScriptToolStripMenuItem";
            this.editScriptToolStripMenuItem.Size = new System.Drawing.Size(82, 23);
            this.editScriptToolStripMenuItem.Text = "Edit Script";
            this.editScriptToolStripMenuItem.Click += new System.EventHandler(this.editScriptToolStripMenuItem_Click);
            // 
            // CrossFaderForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 544);
            this.Controls.Add(this.comboBoxScriptMode);
            this.Controls.Add(this.groupBoxTransitions);
            this.Controls.Add(this.groupBoxCurves);
            this.Controls.Add(this.checkBoxAllowLoops);
            this.Controls.Add(this.labelTimeUnit);
            this.Controls.Add(this.comboBoxTimeUnit);
            this.Controls.Add(this.labelCrossfadeTime);
            this.Controls.Add(this.numericUpDownFadeTime);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CrossFaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CrossFader";
            this.Load += new System.EventHandler(this.CrossFaderForm_Load);
            this.Shown += new System.EventHandler(this.CrossFaderForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawArea)).EndInit();
            this.groupBoxCurves.ResumeLayout(false);
            this.groupBoxCurves.PerformLayout();
            this.groupBoxTransitions.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numericUpDownFadeTime;
        private System.Windows.Forms.Label labelCrossfadeTime;
        private System.Windows.Forms.ComboBox comboBoxRightCurve;
        private System.Windows.Forms.ComboBox comboBoxLeftCurve;
        private System.Windows.Forms.Label labelRightCurve;
        private System.Windows.Forms.Label labelLeftCurve;
        private System.Windows.Forms.ComboBox comboBoxTransitions;
        private System.Windows.Forms.ComboBox comboBoxTimeUnit;
        private System.Windows.Forms.Label labelTimeUnit;
        private System.Windows.Forms.PictureBox pictureBoxDrawArea;
        private System.Windows.Forms.CheckBox checkBoxAllowLoops;
        private System.Windows.Forms.ComboBox comboBoxTransitionMode;
        private System.Windows.Forms.GroupBox groupBoxCurves;
        private System.Windows.Forms.GroupBox groupBoxTransitions;
        private System.Windows.Forms.CheckBox checkBoxChangeCurveType;
        private System.Windows.Forms.ComboBox comboBoxScriptMode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editScriptToolStripMenuItem;
    }
}