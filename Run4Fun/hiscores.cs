using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Run4Fun
{
    public partial class hiscoresForm : Form
    {
        public hiscoresForm()
        {
            InitializeComponent();
        }

        private void hiscoresForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
