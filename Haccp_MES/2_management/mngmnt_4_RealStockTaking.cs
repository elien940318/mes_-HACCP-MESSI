using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haccp_MES._2_management
{
    public partial class mngmnt_4_RealStockTaking : Form
    {
        public mngmnt_4_RealStockTaking()
        {
            InitializeComponent();
        }

        private void mngmnt_4_RealStockTaking_Load(object sender, EventArgs e)
        {

        }

        private void btnChangedHistory_Click(object sender, EventArgs e)
        {
            gridManageInputHead.Columns.Clear();
            gridManageInputHead.ColumnCount = 8;
            gridManageInputHead.Columns[0].HeaderText = "날짜";
            gridManageInputHead.Columns[1].HeaderText = "창고코드";
            gridManageInputHead.Columns[2].HeaderText = "창고명";
            gridManageInputHead.Columns[3].HeaderText = "품목코드";
            gridManageInputHead.Columns[4].HeaderText = "품목명";
            gridManageInputHead.Columns[5].HeaderText = "실사유형";
            gridManageInputHead.Columns[6].HeaderText = "변경수량";
            gridManageInputHead.Columns[7].HeaderText = "관리자";

        }

        private void btnSelectNow_Click(object sender, EventArgs e)
        {
            gridManageInputHead.Columns.Clear();
            gridManageInputHead.ColumnCount = 6;
            gridManageInputHead.Columns[0].HeaderText = "창고코드";
            gridManageInputHead.Columns[1].HeaderText = "창고명";
            gridManageInputHead.Columns[2].HeaderText = "품목코드";
            gridManageInputHead.Columns[3].HeaderText = "품목명";
            gridManageInputHead.Columns[4].HeaderText = "수량";
            gridManageInputHead.Columns[5].HeaderText = "수불단위";
        }
    }
}
