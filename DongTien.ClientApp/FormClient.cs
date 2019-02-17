using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongTien.ClientApp
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
            ConfigForm();
        }

        private void ConfigForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
    }
}
