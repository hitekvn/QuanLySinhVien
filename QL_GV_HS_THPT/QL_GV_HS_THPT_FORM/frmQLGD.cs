using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_QV_HS_THPT_Entity;
using QL_GV_HS_THPT_DAL;

namespace QL_GV_HS_THPT_FORM
{
    public partial class frmQLGD : Form
    {
        public frmQLGD()
        {
            InitializeComponent();
        }

        private SQL_tblGiangday DAL_Giang = new SQL_tblGiangday();
        private SQL_tblGiaovien DAL_GV = new SQL_tblGiaovien();
        private SQL_tblLop DAL_Lop = new SQL_tblLop();
        private EC_tblGiangday EC_Giang = new EC_tblGiangday();
        private bool _them = false;
        private string dk = "";
        private void frmQLGD_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvDanhSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count - 1)
            {
                txtTiet.Text = dgvDanhSach.Rows[e.RowIndex].Cells["Tiet"].Value.ToString();
                cmbThu.Text = dgvDanhSach.Rows[e.RowIndex].Cells["Thu"].Value.ToString();
                cboGiaoVien.Text = dgvDanhSach.Rows[e.RowIndex].Cells["TenGV"].Value.ToString();
                cboLop.Text = dgvDanhSach.Rows[e.RowIndex].Cells["Lop"].Value.ToString();
            }
            else
            {
                ResetData();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoBtn();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            ResetData();

            _them = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTiet.Enabled = true;
            btnLuu.Enabled = true;
            dgvDanhSach.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void cboGiaoVien_Validated(object sender, EventArgs e)
        {
            if (cboGiaoVien.SelectedValue == null)
            {
                MessageBox.Show("Không có giáo viên");
                cboGiaoVien.Focus();
            }
        }

        private void cboLop_Validated(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null)
            {
                MessageBox.Show("Không có lớp");
                cboLop.Focus();
            }
        }

        private void Reset()
        {
            dgvDanhSach.DataSource = DAL_Giang.getThongTinGD();
        }

        private void MoBtn()
        {
            txtTiet.Enabled = true;
            cboLop.Enabled = true;
            cboGiaoVien.Enabled = true;
            cmbThu.Enabled = true;
            btnLuu.Enabled = true;
            dgvDanhSach.Enabled = false;
        }

        private void KhoaBtn()
        {
            txtTiet.Enabled = false;
            cboLop.Enabled = false;
            cboGiaoVien.Enabled = false;
            cmbThu.Enabled = false;
            btnLuu.Enabled = false;
            dgvDanhSach.Enabled = true;
        }

        private void ResetData()
        {
            cboGiaoVien.ResetText();
            cboLop.ResetText();
            txtTiet.ResetText();
            cmbThu.ResetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            EC_Giang.Tietday = txtTiet.Text;
            EC_Giang.Thu = cmbThu.Text;
            EC_Giang.MaLop = cboLop.SelectedValue.ToString();
            EC_Giang.MaGV = cboGiaoVien.SelectedValue.ToString();
            DAL_Giang.delGiangday(EC_Giang);
            Reset();
        }

        private void txtTimGV_TextChanged(object sender, EventArgs e)
        {
            if (txtTimGV.Text != "") dk = "and (Ho + ' ' + Ten) like N'%" + txtTimGV.Text + "%'";
            else dk = "";
            if (txtTimLop.Text != "") dk += "and TenLop like '%" + txtTimLop.Text + "%'";
            dgvDanhSach.DataSource = DAL_Giang.getThongTinGD(dk);
        }

        private void txtTimLop_TextChanged(object sender, EventArgs e)
        {
            if (txtTimLop.Text != "") dk = "and TenLop like '%" + txtTimLop.Text + "%'";
            else dk = "";
            if (txtTimGV.Text != "") dk += "and (Ho + ' ' + Ten) like N'%" + txtTimGV.Text + "%'";
            dgvDanhSach.DataSource = DAL_Giang.getThongTinGD(dk);
        }

        private void frmQLGD_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Dispose();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
