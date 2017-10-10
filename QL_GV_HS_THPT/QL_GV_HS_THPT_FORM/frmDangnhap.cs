using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using QL_GV_HS_THPT_BUS;
using QL_QV_HS_THPT_Entity;

namespace QL_GV_HS_THPT_FORM
{
    public partial class frmDangnhap : Form
    {
        BUS_tblUser busUser = new BUS_tblUser();
        public frmDangnhap()
        {
            InitializeComponent();
        }
    }
}
