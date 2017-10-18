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
using QL_GV_HS_THPT_BUS;

namespace QL_GV_HS_THPT_FORM
{
    public partial class frmQuantri : Form
    {
        EC_tblUser ecUser = new EC_tblUser();
        BUS_tblUser busUser = new BUS_tblUser();
        int dong = -1;
        public frmQuantri()
        {
            InitializeComponent();
        }
        private void frmQuantri_Load(object sender, EventArgs e)
        {
            dgvAcc.DataSource = busUser.getUserinfo("");
            for (int i = 0; i < dgvAcc.RowCount; i++)
            {
                if (dgvAcc.Rows[i].Cells["TenQuyen"].Value.ToString() == "Administrator") dgvAcc.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void frmQuantri_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Dispose();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dong < 0)
            {
                MessageBox.Show("Chưa chọn tài khoản để xóa .");
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa ?", "Hỏi", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ecUser.Username = dgvAcc.Rows[dong].Cells["Username"].Value.ToString();
                    ecUser.Password = dgvAcc.Rows[dong].Cells["Password"].Value.ToString();
                    busUser.delUser(ecUser);
                    frmQuantri_Load(sender, e);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }
        public void adas()
        {
            var source = new AutoCompleteStringCollection();

            DataTable tb = DAL_GV.getThongTinGV();
            cboGiaoVien.DataSource = tb;
            cboGiaoVien.DisplayMember = "HoTen";
            cboGiaoVien.ValueMember = "MaGV";
            for (int _i = 0; _i < tb.Rows.Count; _i++) source.Add(tb.Rows[_i]["HoTen"].ToString());
            cboGiaoVien.AutoCompleteCustomSource = source;

            tb = DAL_Lop.getAllLop();
            cboLop.DataSource = tb;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            for (int _i = 0; _i < tb.Rows.Count; _i++) source.Add(tb.Rows[_i]["TenLop"].ToString());
            cboLop.AutoCompleteCustomSource = source;

            dgvDanhSach.DataSource = DAL_Giang.getThongTinGD();
        }
        private void dgvAcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            ecUser.Username = dgvAcc.Rows[dong].Cells["Username"].Value.ToString();
            ecUser.Password = dgvAcc.Rows[dong].Cells["Password"].Value.ToString();
            ecUser.MaGV = dgvAcc.Rows[dong].Cells["MaGV"].Value.ToString();
            ecUser.Quyen = dgvAcc.Rows[dong].Cells["TenQuyen"].Value.ToString();
        }

        private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            ecUser.Username = dgvAcc.Rows[dong].Cells["Username"].Value.ToString();
            ecUser.Password = dgvAcc.Rows[dong].Cells["Password"].Value.ToString();
            ecUser.MaGV = dgvAcc.Rows[dong].Cells["MaGV"].Value.ToString();
            ecUser.Quyen = dgvAcc.Rows[dong].Cells["TenQuyen"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmThemtaikhoan frm = new frmThemtaikhoan();
            this.Hide();
            frm.Show();

            //this.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dong < 0)
            {
                MessageBox.Show("Chưa chọn tài khoản!");
                return;
            }
            frmThemtaikhoan frm = new frmThemtaikhoan(ecUser);
            frm.Show();
            this.Hide();
        }
    }
}
