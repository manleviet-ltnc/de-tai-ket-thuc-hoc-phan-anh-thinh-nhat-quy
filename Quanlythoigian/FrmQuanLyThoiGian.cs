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
    public partial class FrmQuanLyThoiGian : Form
    {
        public FrmQuanLyThoiGian()
        {
            InitializeComponent();
        }
        private void FrmQuanLyThoiGian_Load(object sender, EventArgs e)
        {

        }
        private void _NhanDuLieu()
        {
            tbxTenCongViec.Text = _str_global.TenCongViec;

        }
        private void FrmQuanLyThoiGian_Shown(object sender, EventArgs e)
        {
        
            if (Opacity == 0)
            {

                _str_form.FrmTenCongViec._SuKien_TruyenDataTuTenCongViec += new FrmTenCongViec.SuKien_TruyenDataTuTenCongViec(_NhanDuLieu);
                Opacity = 100;

            }
        }
        private void FrmQuanLyThoiGian_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmQuanLyThoiGian_KeyDown(object sender, KeyEventArgs e)
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            tbxTenCongViec.ResetText();
        }
        public delegate void SuKien_TruyenDataTuQuanLyThoiGian();
        public event SuKien_TruyenDataTuQuanLyThoiGian _SuKien_TruyenDataTuQuanLyThoiGian;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                tbxTenCongViec.Text = _str_global.TenCongViec;

                if (_str_form.FrmTenCongViec.Visible == true)
                {
                    _SuKien_TruyenDataTuQuanLyThoiGian();
                }
            }
            catch (Exception)
            {

            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
                try
                {
                    _str_form.FrmTenCongViec.Show();
                }
                catch (Exception)
                {

                }
            
        }
    }
}
