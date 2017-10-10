using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_GV_HS_THPT_BUS;
using QL_GV_HS_THPT_DAL;
using QL_GV_HS_THPT_FORM;
using QL_QV_HS_THPT_Entity;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace QL_GV_HS_THPT_FORM
{
    public partial class frmHocsinh : Form
    {
       
        void SetNull()
        {
            txtMaHS.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            cboMaLop.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.ResetText();
        }
        
    }
}
