using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossFader
{
    public partial class CrossFaderForm : Form
    {
        public CrossFaderForm(decimal time)
        {
            InitializeComponent();
            this.numericUpDownFadeTime.Value = time;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CrossFaderForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void CrossFaderForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.numericUpDownFadeTime;
            this.numericUpDownFadeTime.Select(0, numericUpDownFadeTime.Text.Length);
        }

        private void checkBoxTransitions_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxChangeCurveType_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
