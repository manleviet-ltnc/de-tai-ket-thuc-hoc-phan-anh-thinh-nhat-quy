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
    public partial class FrmTenCongViec : Form
    {
        public FrmTenCongViec()
        {
            InitializeComponent();
        }

        private void FrmTenCongViec_Load(object sender, EventArgs e)
        {

        }
        private void _NhanDuLieu()
        {
            tbxTenCongViec.Text = _str_global.TenCongViec;
        }

        private void FrmTenCongViec_Shown(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                _str_form.FrmQuanLyThoiGian._SuKien_TruyenDataTuQuanLyThoiGian += new FrmQuanLyThoiGian.SuKien_TruyenDataTuQuanLyThoiGian(_NhanDuLieu);
                Opacity = 100;
            }
        }
        private void FrmTenCongViec_FormClosing(object sender, FormClosingEventArgs e)

        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void FrmTenCongViec_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        Close();
                        break;
                    }
                case Keys.Enter:
                    {

                        break;
                    }
                case Keys.F5:
                    {

                        break;
                    }
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbxTenCongViec.ResetText();
        }
        public delegate void SuKien_TruyenDataTuTenCongViec();
        public event SuKien_TruyenDataTuTenCongViec _SuKien_TruyenDataTuTenCongViec;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _str_global.TenCongViec = tbxTenCongViec.Text.Trim();

                if (_str_form.FrmQuanLyThoiGian.Visible == true)
                {
                    _SuKien_TruyenDataTuTenCongViec();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
