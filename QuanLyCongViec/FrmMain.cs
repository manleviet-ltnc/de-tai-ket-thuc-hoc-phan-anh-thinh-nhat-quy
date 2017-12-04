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
    public partial class FrmMain : Form
    {
        
        public FrmMain()
        {
            InitializeComponent();
            chkChuaHoanThanh.CheckedChanged += UpdateDataGridView;
            chkTatCa.CheckedChanged += UpdateDataGridView;
            chkHoanThanh.CheckedChanged += UpdateDataGridView;
        }

        #region Hàm chức năng

        private CongViec getCongViecWithID()
        {
            try
            {
                int id = (int) dgvCongViec.SelectedRows[0].Cells["ID"].Value;
                CongViec ans = ModelContext.CongViecs.Where(p => p.ID == id).FirstOrDefault();
                return ans;
            }
            catch
            {
                return new CongViec();
            }
        }

        #endregion


        #region Sự kiện
        private void btnThem_Click(object sender, EventArgs e)
        {
            CongViec a = new CongViec();
            a.ID = 0;
            FrmChiTietCongViec form = new FrmChiTietCongViec(a);
            form.ShowDialog();
            LoadDgv();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            CongViec a = getCongViecWithID();

            if (a.ID == 0)
            {
                MessageBox.Show("Chưa có công việc nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            FrmChiTietCongViec form = new FrmChiTietCongViec(a);
            form.ShowDialog();
            LoadDgv();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CongViec tg = getCongViecWithID();
            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có công việc nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa công việc này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.Cancel) return;

            ModelContext.XoaCongViec(tg);

            MessageBox.Show("Xóa công việc thành công",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            LoadDgv();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region LoadForm

        private void LoadDgv()
        {
            try
            {
                int i = 0;
                var listCongViec = ModelContext.CongViecs;

                if (chkHoanThanh.Checked) listCongViec = listCongViec.Where(p => p.TrangThai == 1).ToList();
                if (chkChuaHoanThanh.Checked) listCongViec = listCongViec.Where(p => p.TrangThai == 0).ToList();

                dgvCongViec.DataSource = listCongViec
                                         .Select(p => new
                                         {
                                             ID = p.ID,
                                             STT = ++i,
                                             TenCongViec = p.Ten,
                                             TrangThai = (p.TrangThai == 0) ? "Chưa hoàn thành" : "Đã hoàn thành"
                                         })
                                         .ToList();
            }
            catch { }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }

        private void UpdateDataGridView(object sender, EventArgs e)
        {
            LoadDgv();
        }
        #endregion
    }
}
