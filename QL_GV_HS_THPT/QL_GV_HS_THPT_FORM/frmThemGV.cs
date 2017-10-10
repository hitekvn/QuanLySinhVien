using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QL_GV_HS_THPT_DAL;
using QL_QV_HS_THPT_Entity;
namespace QL_GV_HS_THPT_FORM
{
    public partial class frmThemGV : Form
    {
        SQL_tblGiaovien giaovien = new SQL_tblGiaovien();
        EC_tblGiaovien gv = new EC_tblGiaovien();
        DataTable dt = new DataTable();
        public void SetNull()
        {
            txtHo.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtMaGV.Text = "";
            txtSDT.Text = "";
            txtLuong.Text = "";
        }
        public frmThemGV()
        {
            InitializeComponent();
        }

      
    }
}
