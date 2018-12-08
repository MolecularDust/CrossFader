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
            this.comboBoxFadeInCurve = new System.Windows.Forms.ComboBox();
            this.comboBoxFadeOutCurve = new System.Windows.Forms.ComboBox();
            this.labelFadeInCurve = new System.Windows.Forms.Label();
            this.labelFadeOutCurve = new System.Windows.Forms.Label();
            this.checkBoxTransitions = new System.Windows.Forms.CheckBox();
            this.comboBoxTransitions = new System.Windows.Forms.ComboBox();
            this.comboBoxTimeUnit = new System.Windows.Forms.ComboBox();
            this.labelTimeUnit = new System.Windows.Forms.Label();
            this.checkBoxChangeCurveType = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(47, 265);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 20, 3, 10);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(267, 35);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // numericUpDownFadeTime
            // 
            this.numericUpDownFadeTime.Location = new System.Drawing.Point(47, 60);
            this.numericUpDownFadeTime.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.numericUpDownFadeTime.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numericUpDownFadeTime.Name = "numericUpDownFadeTime";
            this.numericUpDownFadeTime.Size = new System.Drawing.Size(124, 20);
            this.numericUpDownFadeTime.TabIndex = 1;
            // 
            // labelCrossfadeTime
            // 
            this.labelCrossfadeTime.AutoSize = true;
            this.labelCrossfadeTime.Location = new System.Drawing.Point(44, 37);
            this.labelCrossfadeTime.Name = "labelCrossfadeTime";
            this.labelCrossfadeTime.Size = new System.Drawing.Size(90, 13);
            this.labelCrossfadeTime.TabIndex = 2;
            this.labelCrossfadeTime.Text = "Crossfade Length";
            // 
            // comboBoxFadeInCurve
            // 
            this.comboBoxFadeInCurve.FormattingEnabled = true;
            this.comboBoxFadeInCurve.Location = new System.Drawing.Point(190, 143);
            this.comboBoxFadeInCurve.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.comboBoxFadeInCurve.Name = "comboBoxFadeInCurve";
            this.comboBoxFadeInCurve.Size = new System.Drawing.Size(124, 21);
            this.comboBoxFadeInCurve.TabIndex = 3;
            // 
            // comboBoxFadeOutCurve
            // 
            this.comboBoxFadeOutCurve.FormattingEnabled = true;
            this.comboBoxFadeOutCurve.Location = new System.Drawing.Point(47, 143);
            this.comboBoxFadeOutCurve.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.comboBoxFadeOutCurve.Name = "comboBoxFadeOutCurve";
            this.comboBoxFadeOutCurve.Size = new System.Drawing.Size(124, 21);
            this.comboBoxFadeOutCurve.TabIndex = 4;
            // 
            // labelFadeInCurve
            // 
            this.labelFadeInCurve.AutoSize = true;
            this.labelFadeInCurve.Location = new System.Drawing.Point(44, 120);
            this.labelFadeInCurve.Name = "labelFadeInCurve";
            this.labelFadeInCurve.Size = new System.Drawing.Size(74, 13);
            this.labelFadeInCurve.TabIndex = 5;
            this.labelFadeInCurve.Text = "Fade In Curve";
            // 
            // labelFadeOutCurve
            // 
            this.labelFadeOutCurve.AutoSize = true;
            this.labelFadeOutCurve.Location = new System.Drawing.Point(187, 120);
            this.labelFadeOutCurve.Name = "labelFadeOutCurve";
            this.labelFadeOutCurve.Size = new System.Drawing.Size(82, 13);
            this.labelFadeOutCurve.TabIndex = 6;
            this.labelFadeOutCurve.Text = "Fade Out Curve";
            // 
            // checkBoxTransitions
            // 
            this.checkBoxTransitions.AutoSize = true;
            this.checkBoxTransitions.Location = new System.Drawing.Point(47, 184);
            this.checkBoxTransitions.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.checkBoxTransitions.Name = "checkBoxTransitions";
            this.checkBoxTransitions.Size = new System.Drawing.Size(135, 17);
            this.checkBoxTransitions.TabIndex = 7;
            this.checkBoxTransitions.Text = "Video Transition Preset";
            this.checkBoxTransitions.UseVisualStyleBackColor = true;
            this.checkBoxTransitions.CheckedChanged += new System.EventHandler(this.checkBoxTransitions_CheckedChanged);
            // 
            // comboBoxTransitions
            // 
            this.comboBoxTransitions.FormattingEnabled = true;
            this.comboBoxTransitions.Location = new System.Drawing.Point(47, 214);
            this.comboBoxTransitions.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.comboBoxTransitions.Name = "comboBoxTransitions";
            this.comboBoxTransitions.Size = new System.Drawing.Size(267, 21);
            this.comboBoxTransitions.TabIndex = 8;
            // 
            // comboBoxTimeUnit
            // 
            this.comboBoxTimeUnit.FormattingEnabled = true;
            this.comboBoxTimeUnit.Location = new System.Drawing.Point(190, 59);
            this.comboBoxTimeUnit.Name = "comboBoxTimeUnit";
            this.comboBoxTimeUnit.Size = new System.Drawing.Size(124, 21);
            this.comboBoxTimeUnit.TabIndex = 9;
            // 
            // labelTimeUnit
            // 
            this.labelTimeUnit.AutoSize = true;
            this.labelTimeUnit.Location = new System.Drawing.Point(187, 37);
            this.labelTimeUnit.Name = "labelTimeUnit";
            this.labelTimeUnit.Size = new System.Drawing.Size(52, 13);
            this.labelTimeUnit.TabIndex = 10;
            this.labelTimeUnit.Text = "Time Unit";
            // 
            // checkBoxChangeCurveType
            // 
            this.checkBoxChangeCurveType.AutoSize = true;
            this.checkBoxChangeCurveType.Location = new System.Drawing.Point(47, 93);
            this.checkBoxChangeCurveType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.checkBoxChangeCurveType.Name = "checkBoxChangeCurveType";
            this.checkBoxChangeCurveType.Size = new System.Drawing.Size(121, 17);
            this.checkBoxChangeCurveType.TabIndex = 11;
            this.checkBoxChangeCurveType.Text = "Change Curve Type";
            this.checkBoxChangeCurveType.UseVisualStyleBackColor = true;
            this.checkBoxChangeCurveType.CheckedChanged += new System.EventHandler(this.checkBoxChangeCurveType_CheckedChanged);
            // 
            // CrossFaderForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 336);
            this.Controls.Add(this.checkBoxChangeCurveType);
            this.Controls.Add(this.labelTimeUnit);
            this.Controls.Add(this.comboBoxTimeUnit);
            this.Controls.Add(this.comboBoxTransitions);
            this.Controls.Add(this.checkBoxTransitions);
            this.Controls.Add(this.labelFadeOutCurve);
            this.Controls.Add(this.labelFadeInCurve);
            this.Controls.Add(this.comboBoxFadeOutCurve);
            this.Controls.Add(this.comboBoxFadeInCurve);
            this.Controls.Add(this.labelCrossfadeTime);
            this.Controls.Add(this.numericUpDownFadeTime);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CrossFaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CrossFader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CrossFaderForm_FormClosed);
            this.Load += new System.EventHandler(this.CrossFaderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFadeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numericUpDownFadeTime;
        private System.Windows.Forms.Label labelCrossfadeTime;
        private System.Windows.Forms.ComboBox comboBoxFadeInCurve;
        private System.Windows.Forms.ComboBox comboBoxFadeOutCurve;
        private System.Windows.Forms.Label labelFadeInCurve;
        private System.Windows.Forms.Label labelFadeOutCurve;
        private System.Windows.Forms.CheckBox checkBoxTransitions;
        private System.Windows.Forms.ComboBox comboBoxTransitions;
        private System.Windows.Forms.ComboBox comboBoxTimeUnit;
        private System.Windows.Forms.Label labelTimeUnit;
        private System.Windows.Forms.CheckBox checkBoxChangeCurveType;
    }
}