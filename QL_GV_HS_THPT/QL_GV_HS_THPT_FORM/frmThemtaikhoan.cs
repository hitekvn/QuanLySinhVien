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
    public partial class frmThemtaikhoan : Form
    {
        int them = 1;
        EC_tblUser ecUser = new EC_tblUser();
        BUS_tblUser busUser = new BUS_tblUser();
        BUS_tblGiaovien busGiaovien = new BUS_tblGiaovien();
        public frmThemtaikhoan()
        {
            InitializeComponent();
        }
       
    }
}
