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
        MySqlDataAdapter adapter, adapter2;
        DataTable dtHead, dtbody;

        public mngmnt_3_StockState()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dtHead = new DataTable();
        }
        private void mngmnt_3_StockState_Load(object sender, EventArgs e)
        {
            itemBoxDeleteAndFill();
        }

        public void itemBoxDeleteAndFill()
        {
            comBoxMatType.Items.Clear();
            comBoxMatType.Items.Add("제품");
            comBoxMatType.Items.Add("부재료");
            comBoxMatType.Items.Add("원재료");

            //comBoxProductName.Items.Clear();
            //comBoxProductName.Items.Add("멸치국수");
            //comBoxProductName.Items.Add("김치국수");
            //comBoxProductName.Items.Add("소고기국수");
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string StockHeadQuery = "SELECT manage_curmat.ware_no as 'stock_wareHouseCode', info_warehouse.ware_name as 'stock_wareHouseName', info_material.mat_name as 'stock_matName', info_material.mat_type as 'stock_matType', manage_curmat.curmat_count as 'stock_count', info_material.mat_spec as 'stock_matSpec' " + //, (select mat_name from info_material where mat_no in (select mat_no from info_material, info_bom where bom_parent_no = mat_no)) as 'stock_ProductName' " +
                "FROM manage_curmat, info_warehouse, info_material, info_bom " +
                "WHERE manage_curmat.ware_no = info_warehouse.ware_no " +
                    "AND manage_curmat.mat_no = info_material.mat_no " +
                    "AND info_bom.bom_no = info_material.mat_no " +
                "GROUP BY manage_curmat.ware_no, manage_curmat.mat_no " +
                "ORDER BY manage_curmat.ware_no;";

            cmd = new MySqlCommand(StockHeadQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }

        private void btnSelectCondition_Click(object sender, EventArgs e)
        {
            conn.Open();

            string[] selectCondition = new string[4] {txtSelectWarehouseCode.Text, txtSelectWarehouseName.Text, txtMatName.Text, comBoxMatType.Text};

            dtHead.Clear();

            string ConStockHeadQuery =
                "SELECT manage_curmat.ware_no as 'stock_wareHouseCode', info_warehouse.ware_name as 'stock_wareHouseName', info_material.mat_name as 'stock_matName', info_material.mat_type as 'stock_matType', manage_curmat.curmat_count as 'stock_count', info_material.mat_spec as 'stock_matSpec' " + //, (select mat_name from info_material where mat_no in (select mat_no from info_material, info_bom where bom_parent_no = mat_no)) as 'stock_ProductName' " +
                "FROM manage_curmat, info_warehouse, info_material, info_bom " +
                "WHERE manage_curmat.ware_no = info_warehouse.ware_no " +
                    "AND manage_curmat.mat_no = info_material.mat_no " +
                    "AND info_bom.bom_no = info_material.mat_no ";
            if (txtSelectWarehouseCode.Text != "")
            {
                ConStockHeadQuery += "AND manage_curmat.ware_no like '%@WARE_NO%' ";
            }
            if (txtSelectWarehouseName.Text != "")
            {
                ConStockHeadQuery += "AND ware_name like '%@WARE_NAME%' ";
            }
            if (txtMatName.Text != "")
            {
                ConStockHeadQuery += "AND mat_name like '%@MAT_NAME%' ";
            }
            if (comBoxMatType.Text != "")
            {
                ConStockHeadQuery += "AND mat_type like '%@MAT_TYPE%' ";
            }
            
                ConStockHeadQuery += "GROUP BY manage_curmat.ware_no, manage_curmat.mat_no " +
                                     "ORDER BY manage_curmat.ware_no;";

            cmd = new MySqlCommand(ConStockHeadQuery, conn);

            cmd.Parameters.AddWithValue("@WARE_NO"      , selectCondition[0]);
            cmd.Parameters.AddWithValue("@WARE_NAME"    , selectCondition[1]);
            cmd.Parameters.AddWithValue("@MAT_NAME"     , selectCondition[2]);
            cmd.Parameters.AddWithValue("@MAT_TYPE"     , selectCondition[3]);

            adapter2 = new MySqlDataAdapter(cmd);
            adapter2.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }
        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            //그룹박스 내의 검색 조건들을 한 번에 지워주는 기능.
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text  = "";
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
            }
            /* 아래의 코드처럼 사용하여도 됨.
            txtSelectWarehouseCode.Text = "";
            txtSelectWarehouseName.Text = "";
            txtMatName.Text             = "";
            comBoxMatType.Text          = "";
            comBoxProductName.Text      = "";
            */
        }

        
    }
}
