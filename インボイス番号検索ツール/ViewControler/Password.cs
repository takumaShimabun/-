using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace インボイス番号検索ツール.ViewControler
{
    internal partial class Password : Form
    {
        private string _myPass = "Atr8937?";
        private readonly SearchBox _frmParent;
        public Password(SearchBox frmParent)
        {
            InitializeComponent();
            _frmParent = frmParent;
        }

        private void TxtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text == _myPass)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
