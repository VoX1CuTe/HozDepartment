using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HozDepartment
{
    public partial class RedactAndAddUsers : Form
    {
        public RedactAndAddUsers()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pbcollapse_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TextPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && !char.IsControl(c) && c != '+' && c != '-' && c != '(' && c != ')')
            {
                e.Handled = true;
            }
        }

        private void TextSeriaPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }

        private void TextNumberPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsDigit(c) && !char.IsControl(c))
            {
                e.Handled = true;
            }
        }
    }
}
