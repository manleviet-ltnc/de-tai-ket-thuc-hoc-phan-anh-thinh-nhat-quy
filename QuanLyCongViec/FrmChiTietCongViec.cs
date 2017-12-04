using QuanLyCongViec.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCongViec
{
    public partial class FrmChiTietCongViec : Form
    {
        private CongViec cv = new CongViec();
        public FrmChiTietCongViec(CongViec a)
        {
            InitializeComponent();
            cv = a;
        }


        private bool Check()
        {
            if (txtTenCongViec.Text == "")
            {
                MessageBox.Show("Tên công việc không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateKetThuc.Value< dateBatDau.Value)
            {
                MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region Sự kiện
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                cv.Ten = txtTenCongViec.Text;
                cv.BatDau = dateBatDau.Value;
                cv.KetThuc = dateKetThuc.Value;
                cv.TrangThai = cbxTrangThai.SelectedIndex;

                if (cv.ID == 0)
                {
                    ModelContext.ThemCongViec(cv);
                    MessageBox.Show("Thêm công việc thành công",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    
                }
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void FrmChiTietCongViec_Load(object sender, EventArgs e)
        {
            if (cv.ID == 0)
            {
                txtTenCongViec.Text = "";
                dateBatDau.Value = DateTime.Now;
                dateKetThuc.Value = DateTime.Now;
                cbxTrangThai.SelectedIndex = 0;
            }
                else
            {
                txtTenCongViec.Text = cv.Ten;
                dateBatDau.Value = cv.BatDau;
                dateKetThuc.Value = cv.KetThuc;
                cbxTrangThai.SelectedIndex = cv.TrangThai;
            }
        }
    }
}
