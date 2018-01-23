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
        //khai báo các biến toàn cục

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
                int id = (int)dgvCongViec.SelectedRows[0].Cells["ID"].Value;
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
            //sự kiện thêm mới công việc
        {
            CongViec a = new CongViec();
            a.ID = 0;
            FrmChiTietCongViec form = new FrmChiTietCongViec(a);
            form.ShowDialog();
            LoadDgv();
        }

        private void btnSua_Click(object sender, EventArgs e)
            //sự kiện sửa đội công việc
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
            //hiển thị thêm form chi tiết công việc
            FrmChiTietCongViec form = new FrmChiTietCongViec(a);
            form.ShowDialog();
            LoadDgv();
        }

        private void btnXoa_Click(object sender, EventArgs e)
            //sự kiện xóa công việc
        {
            CongViec tg = getCongViecWithID();
            if (tg.ID == 0)
            {
                MessageBox.Show("Chưa có công việc nào được chọn","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa công việc này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.Cancel) return;

            ModelContext.XoaCongViec(tg);

            MessageBox.Show("Xóa công việc thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadDgv();
        }
        private void btnXuong_Click(object sender, EventArgs e)
            //sự kiện di chuyển vùng chọn xuống dưới
        {
            hang++;
            if (hang < dgvCongViec.Rows.Count) dgvCongViec.Rows[hang].Selected = true;
            else hang = dgvCongViec.Rows.Count - 1;
           
        }
        private void btnLen_Click(object sender, EventArgs e)
            //sự kiện di chuyển vùng chọn lên trên
        {
            hang--;
            if (hang >= 0) dgvCongViec.Rows[hang].Selected = true;
            else hang = 0;
        }
        private void btnDau_Click(object sender, EventArgs e)
            //sự kiện di chuyển vùng chọn lên đầu tiên
        {
            hang = 0;
            dgvCongViec.Rows[hang].Selected = true;
        }
        private void btnCuoi_Click(object sender, EventArgs e)
            //sự kiện di chuyển vùng chọn xuống cuối cùng
        {
            hang = dgvCongViec.Rows.Count - 1;
            dgvCongViec.Rows[hang].Selected = true;
        }
        private void btnThoat_Click(object sender, EventArgs e)
            //sự kiện thoát ứng dụng
        {
            this.Close();
        }
        #endregion

        #region LoadForm

        private void LoadDgv()
            //tạo đối tượng datagridview
        {
            try
            {
                int i = 0;
                var listCongViec = ModelContext.CongViecs;

                if (chkHoanThanh.Checked) listCongViec = listCongViec.Where(p => p.TrangThai == 1).ToList();
                if (chkChuaHoanThanh.Checked) listCongViec = listCongViec.Where(p => p.TrangThai == 0).ToList();

                dgvCongViec.DataSource = listCongViec.Select(p => new {ID = p.ID,
                                                                       STT = ++i,
                                                                       TenCongViec = p.Ten,
                                                                       TrangThai = (p.TrangThai == 0) ? "Chưa hoàn thành" : "Đã hoàn thành"
                                                                      }).ToList();
            }
            catch { }
        }
        int hang = -1;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //tạo đối tượng connection
            LoadDgv();
            if (dgvCongViec.Rows.Count > 0) hang = 0;
        }

        private void UpdateDataGridView(object sender, EventArgs e)
            //cập nhật dữ liệu
        {
            LoadDgv();
        }

        #endregion
    }
}
