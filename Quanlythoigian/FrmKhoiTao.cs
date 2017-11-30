using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlythoigian
{
    public partial class FrmKhoiTao : Form
    {
        public FrmKhoiTao()
        {
            InitializeComponent();
        }

        private void FrmKhoiTao_Load(object sender, EventArgs e)
        {
            this.Hide();
            _str_form.FrmQuanLyThoiGian.ShowDialog();
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }
    }
}
