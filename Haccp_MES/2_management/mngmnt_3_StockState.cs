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
        private void mngmnt_3_StockState_Load(object sender, EventArgs e)
        {
            itemBoxDeleteAndFill();
        }
        // 콤보박스의 내용물 채워주는 메소드
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
        // 전체 조회 버튼 클릭
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string StockHeadQuery = "SELECT manage_curmat.ware_no as 'stock_wareHouseCode', info_warehouse.ware_name as 'stock_wareHouseName', manage_curmat.mat_no as 'stock_matCode', info_material.mat_name as 'stock_matName', info_material.mat_type as 'stock_matType', manage_curmat.curmat_count as 'stock_count', info_material.mat_spec as 'stock_matSpec' " + //, (select mat_name from info_material where mat_no in (select mat_no from info_material, info_bom where bom_parent_no = mat_no)) as 'stock_ProductName' " +
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
        // 조건 검색 버튼 클릭
        private void btnSelectCondition_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();

            string ConStockHeadQuery =
                "SELECT manage_curmat.ware_no as 'stock_wareHouseCode', info_warehouse.ware_name as 'stock_wareHouseName', manage_curmat.mat_no as 'stock_matCode', info_material.mat_name as 'stock_matName', info_material.mat_type as 'stock_matType', manage_curmat.curmat_count as 'stock_count', info_material.mat_spec as 'stock_matSpec' " + //, (select mat_name from info_material where mat_no in (select mat_no from info_material, info_bom where bom_parent_no = mat_no)) as 'stock_ProductName' " +
                "FROM manage_curmat, info_warehouse, info_material, info_bom " +
                "WHERE manage_curmat.ware_no = info_warehouse.ware_no " +
                    "AND manage_curmat.mat_no = info_material.mat_no " +
                    "AND info_bom.bom_no = info_material.mat_no ";

            // 조건 검색을 위해 조건항목이 채워져있는지 여부를 파악하는 부분
            // like '%%' 는 %% 사이의 단어가 포함된 결과값을 찾아준다
            if (txtSelectWarehouseCode.Text != "")
            {
                ConStockHeadQuery += "AND manage_curmat.ware_no like @WARE_NO ";
            }
            if (txtSelectWarehouseName.Text != "")
            {
                ConStockHeadQuery += "AND ware_name like @WARE_NAME ";
            }
            if (txtMatCode.Text != "")
            {
                ConStockHeadQuery += "AND manage_curmat.mat_no like @MAT_NO ";
            }
            if (txtMatName.Text != "")
            {
                ConStockHeadQuery += "AND mat_name like @MAT_NAME ";
            }
            if (comBoxMatType.Text != "")
            {
                ConStockHeadQuery += "AND mat_type like @MAT_TYPE ";
            }
            
                ConStockHeadQuery += "GROUP BY manage_curmat.ware_no, manage_curmat.mat_no " +
                                     "ORDER BY manage_curmat.ware_no;";

            cmd = new MySqlCommand(ConStockHeadQuery, conn);

            // @ABC 같은 형식의 단어에 대신 들어갈 값을 넣어주는 부분
            cmd.Parameters.AddWithValue("@WARE_NO"      , "%" + txtSelectWarehouseCode.Text.ToString() + "%");
            cmd.Parameters.AddWithValue("@WARE_NAME"    , "%" + txtSelectWarehouseName.Text.ToString() + "%");
            cmd.Parameters.AddWithValue("@MAT_NO"       , "%" + txtMatCode.Text.ToString() + "%");
            cmd.Parameters.AddWithValue("@MAT_NAME"     , "%" + txtMatName.Text.ToString() + "%");
            cmd.Parameters.AddWithValue("@MAT_TYPE"     , "%" + comBoxMatType.Text.ToString() + "%");

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }
        // 조건 삭제 버튼 클릭
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
            txtMatCode.Text             = "";
            txtMatName.Text             = "";
            comBoxMatType.Text          = "";
            comBoxProductName.Text      = "";
            */
        }

        // 그리드 뷰 내의 셀을 클릭
        private void gridManageInputHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 어떤 재료가 들어가는 제품이 하나인지, 둘 이상인지 파악하기 위한 과정
            lbl_product_Name.FlatStyle = FlatStyle.Flat;
            lbl_product_Name.Text = "";

            var ware_id = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[0].Value);
            var mat_id  = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[2].Value);
            
            DataTable dtBody = new DataTable();
            DataTable dtCheck = new DataTable();
            DataTable dtPro = new DataTable();

            conn.Open();
            string CheckQuery = "SELECT bom_parent_no FROM info_bom WHERE bom_no = @MAT_ID ";

            cmd = new MySqlCommand(CheckQuery, conn);
            cmd.Parameters.AddWithValue("@MAT_ID", mat_id);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtCheck);

            int CheckRows = Convert.ToInt32(dtCheck.Rows.Count);

            // 이 재료가 들어가는 제품이 하나 이상일 경우 각각의 제품들의 이름을 가져오기 위함
            if (CheckRows > 1)
            {
                for (int k = 0; k < CheckRows; k++)
                {
                    string productQuery = "SELECT mat_name FROM info_material WHERE mat_no = " + dtCheck.Rows[k][0] + ";";
                    cmd = new MySqlCommand(productQuery, conn);
                    adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dtPro);
                    lbl_product_Name.Text += dtPro.Rows[k][0] + " ";
                }
            }
            
            string StockBodyQuery =
                "SELECT manage_curmat.ware_no as 'stock_wareHouseCode', info_warehouse.ware_name as 'stock_wareHouseName', info_material.mat_spec as 'stock_matSpec', manage_curmat.mat_no as 'stock_matCode', info_material.mat_name as 'stock_matName', manage_curmat.curmat_count as 'stock_count', info_material.mat_type as 'stock_matType' ";
            
            // 이 재료가 들어가는 제품이 유일할 경우 ex) 멸치분말 -> 멸치국수 유일함
            if (CheckRows == 1)
            {
                StockBodyQuery += ", (select mat_name from info_material where mat_no = (select bom_parent_no from info_bom where bom_no = @MAT_ID)) as 'stock_ProductName'"; //, (select mat_name from info_material where mat_no in (select mat_no from info_material, info_bom where bom_parent_no = mat_no)) as 'stock_ProductName' " +
                lbl_product_Name.FlatStyle = FlatStyle.Standard;
            }
            StockBodyQuery += ", info_material.mat_etc as 'stock_matEtc' " +
                "FROM manage_curmat, info_warehouse, info_material, info_bom " +
                "WHERE manage_curmat.ware_no = info_warehouse.ware_no " +
                "AND manage_curmat.mat_no = info_material.mat_no " +
                "AND info_bom.bom_no = info_material.mat_no " +
                "AND manage_curmat.ware_no = @WARE_ID " +
                "AND manage_curmat.mat_no = @MAT_ID;";

            cmd = new MySqlCommand(StockBodyQuery, conn);

            cmd.Parameters.AddWithValue("@WARE_ID", ware_id);
            cmd.Parameters.AddWithValue("@MAT_ID", mat_id);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtBody);

            // 상세내역에 정보들을 기입하는 과정
            int i = 0;
            foreach (var item in tblLayOutPnlBody.Controls)
            {
                if (item is Label)
                {
                    if (((Label)item).FlatStyle == FlatStyle.Standard)
                    {
                            ((Label)item).Text = dtBody.Rows[0].ItemArray[i].ToString();
                            i++;
                    }
                }
            }
            conn.Close();
        }
    }
}
