using MySql.Data.MySqlClient;
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
    public partial class mngmnt_3_StockState : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public mngmnt_3_StockState()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dtHead = new DataTable();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string orderInfoHeadQuery = "SELECT manage_curmat.ware_no as 'stock_wareHouseCode', info_warehouse.ware_name as 'stock_wareHouseName', info_material.mat_name as 'stock_matName', info_material.mat_type as 'stock_matType', manage_curmat.curmat_count as 'stock_count', info_material.mat_spec as 'stock_matSpec', (select mat_name from info_material where mat_no in (select mat_no from info_material, info_bom where bom_parent_no = mat_no)) as 'stock_ProductName' " +
                "FROM manage_curmat, info_warehouse, info_material, info_bom " +
                "WHERE manage_curmat.ware_no = info_warehouse.ware_no AND manage_curmat.mat_no = info_material.mat_no AND info_bom.bom_no = info_material.mat_no " +
                "GROUP BY manage_curmat.ware_no, manage_curmat.mat_no " +
                "ORDER BY manage_curmat.ware_no;";

            cmd = new MySqlCommand(orderInfoHeadQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }

        private void btnSelectCondition_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            txtSelectWarehouseCode.Text = "";
            txtSelectWarehouseName.Text = "";
            txtMatName.Text             = "";
            comBoxMatType.Text          = "";
            txtProductName.Text         = "";
        }
    }
}
