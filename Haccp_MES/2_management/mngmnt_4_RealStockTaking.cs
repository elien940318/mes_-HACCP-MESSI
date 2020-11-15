using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Haccp_MES._2_management
{
    public partial class mngmnt_4_RealStockTaking : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public mngmnt_4_RealStockTaking()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dtHead = new DataTable();
        }

        private void mngmnt_4_RealStockTaking_Load(object sender, EventArgs e)
        {

        }

        private void btnChangedHistory_Click(object sender, EventArgs e)
        {
            dtHead.Clear();

            gridManageStockHead.Columns.Clear();
            gridManageStockHead.DataSource = null;
            gridManageStockHead.ColumnCount = 9;

            gridManageStockHead.Columns[0].HeaderText = "실사 번호";
            gridManageStockHead.Columns[0].DataPropertyName = "realStock_index";
            gridManageStockHead.Columns[1].HeaderText = "창고코드";
            gridManageStockHead.Columns[1].DataPropertyName = "realStock_wareHouseCode";
            gridManageStockHead.Columns[2].HeaderText = "창고명";
            gridManageStockHead.Columns[2].DataPropertyName = "realStock_wareHouseName";
            gridManageStockHead.Columns[3].HeaderText = "품목코드";
            gridManageStockHead.Columns[3].DataPropertyName = "realStock_matCode";
            gridManageStockHead.Columns[4].HeaderText = "품목명";
            gridManageStockHead.Columns[4].DataPropertyName = "realStock_matName";
            gridManageStockHead.Columns[5].HeaderText = "실사유형";
            gridManageStockHead.Columns[5].DataPropertyName = "realStock_takeType";
            gridManageStockHead.Columns[6].HeaderText = "변경수량";
            gridManageStockHead.Columns[6].DataPropertyName = "realStock_takeCount";
            gridManageStockHead.Columns[7].HeaderText = "날짜";
            gridManageStockHead.Columns[7].DataPropertyName = "realStock_date";
            gridManageStockHead.Columns[8].HeaderText = "관리자";
            gridManageStockHead.Columns[8].DataPropertyName = "realStock_adminName";

            gridManageStockHead.ReadOnly = true;

            conn.Open();


            string StockHeadQuery =
                "SELECT stocktake_no as 'realStock_index', " +
                    "manage_realstocktake.ware_no as 'realStock_wareHouseCode', " +
                    "ware_name as 'realStock_wareHouseName', " +
                    "manage_realstocktake.mat_no as 'realStock_matCode', " +
                    "mat_name as 'realStock_matName', " +
                    "stocktake_type as 'realStock_takeType', " +
                    "stocktake_changecount as 'realStock_takeCount', " +
                    "user_id as 'realStock_adminName', " +
                    "stocktake_date as 'realStock_date' " +
                "FROM manage_realstocktake, info_warehouse, info_material " +
                "WHERE manage_realstocktake.ware_no = info_warehouse.ware_no " +
                    "AND manage_realstocktake.mat_no = info_material.mat_no " +
                "GROUP BY manage_realstocktake.ware_no, manage_realstocktake.mat_no " +
                "ORDER BY manage_realstocktake.ware_no;";

            cmd = new MySqlCommand(StockHeadQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageStockHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageStockHead.Rows.Count.ToString();

            conn.Close();

            btnUpdate.Visible = false;
        }

        private void btnSelectNow_Click(object sender, EventArgs e)
        {
            dtHead.Clear();

            gridManageStockHead.Columns.Clear();
            gridManageStockHead.DataSource = null;
            gridManageStockHead.ColumnCount = 6;

            gridManageStockHead.Columns[0].HeaderText = "창고코드";
            gridManageStockHead.Columns[0].DataPropertyName = "stock_wareHouseCode";
            gridManageStockHead.Columns[1].HeaderText = "창고명";
            gridManageStockHead.Columns[1].DataPropertyName = "stock_wareHouseName";
            gridManageStockHead.Columns[2].HeaderText = "품목코드";
            gridManageStockHead.Columns[2].DataPropertyName = "stock_matCode";
            gridManageStockHead.Columns[3].HeaderText = "품목명";
            gridManageStockHead.Columns[3].DataPropertyName = "stock_matName";
            gridManageStockHead.Columns[4].HeaderText = "수량";
            gridManageStockHead.Columns[4].DataPropertyName = "stock_count";
            gridManageStockHead.Columns[5].HeaderText = "수불단위";
            gridManageStockHead.Columns[5].DataPropertyName = "stock_matSpec";

            gridManageStockHead.ReadOnly = true;

            conn.Open();
            

            string StockHeadQuery = 
                "SELECT manage_curmat.ware_no as 'stock_wareHouseCode', " +
                    "info_warehouse.ware_name as 'stock_wareHouseName', " +
                    "manage_curmat.mat_no as 'stock_matCode', " +
                    "info_material.mat_name as 'stock_matName', " +
                    "manage_curmat.curmat_count as 'stock_count', " +
                    "info_material.mat_spec as 'stock_matSpec' " +
                "FROM manage_curmat, info_warehouse, info_material " +
                "WHERE manage_curmat.ware_no = info_warehouse.ware_no " +
                    "AND manage_curmat.mat_no = info_material.mat_no " +
                "GROUP BY manage_curmat.ware_no, manage_curmat.mat_no " +
                "ORDER BY manage_curmat.ware_no;";

            cmd = new MySqlCommand(StockHeadQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageStockHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageStockHead.Rows.Count.ToString();

            conn.Close();

            btnUpdate.Visible = true;
        }
        // 셀 클릭
        private void gridManageStockHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnUpdate.Visible == true)
            {
                comBoxRealStockTakeType.Enabled = true;
                txtChangeCount.Enabled = true;
                txtMemo.Enabled = true;

                lbl_wareHouse_Code.Text = gridManageStockHead.CurrentRow.Cells[0].Value.ToString();
                lbl_wareHouse_Name.Text = gridManageStockHead.CurrentRow.Cells[1].Value.ToString();
                lbl_mat_Code.Text       = gridManageStockHead.CurrentRow.Cells[2].Value.ToString();
                lbl_mat_Name.Text       = gridManageStockHead.CurrentRow.Cells[3].Value.ToString();
                lbl_mat_Count.Text      = gridManageStockHead.CurrentRow.Cells[4].Value.ToString();
                lbl_mat_Spec.Text       = gridManageStockHead.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                comBoxRealStockTakeType.Enabled = false;
                txtChangeCount.Enabled = false;
                txtMemo.Enabled = false;

                var stockTake_id = Convert.ToInt32(gridManageStockHead.CurrentRow.Cells[0].Value);
                var ware_id = Convert.ToInt32(gridManageStockHead.CurrentRow.Cells[1].Value);
                var mat_id = Convert.ToInt32(gridManageStockHead.CurrentRow.Cells[3].Value);
                var stocktake_type = gridManageStockHead.CurrentRow.Cells[5].Value.ToString();
                DataTable dtBody = new DataTable();

                conn.Open();

                string StockBodyQuery =
                "SELECT manage_realstocktake.ware_no, " +
                    "ware_name, " +
                    "mat_spec, " +
                    "manage_realstocktake.mat_no, " +
                    "mat_name, " +
                    "stocktake_beforecount, " +
                    "stocktake_type, " +
                    "stocktake_changecount, " +
                    "if(@STOCKTAKE_TYPE = '추가', stocktake_beforecount + stocktake_changecount, stocktake_beforecount - stocktake_changecount), " +
                    "memo "+
                "FROM manage_realstocktake, info_warehouse, info_material " +
                "WHERE manage_realstocktake.ware_no = info_warehouse.ware_no " +
                    "AND manage_realstocktake.mat_no = info_material.mat_no " +
                    "AND stocktake_no = @STOCKTAKE_ID "+
                "GROUP BY manage_realstocktake.ware_no, manage_realstocktake.mat_no " +
                "ORDER BY manage_realstocktake.ware_no;";

                cmd = new MySqlCommand(StockBodyQuery, conn);

                cmd.Parameters.AddWithValue("@STOCKTAKE_ID", stockTake_id);
                cmd.Parameters.AddWithValue("@STOCKTAKE_TYPE", stocktake_type);

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtBody);

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
                    else if (item is ComboBox)
                    {
                        ((ComboBox)item).SelectedItem = dtBody.Rows[0].ItemArray[i].ToString();
                        i++;
                    }
                    else if (item is TextBox)
                    {
                        ((TextBox)item).Text = dtBody.Rows[0].ItemArray[i].ToString();
                        i++;
                    }
                }

                conn.Close();
            }

        }
        // 추가 / 차감 변할때
        private void comBoxRealStockTakeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtChangeCount.Text == "")
            {
                lbl_after_takedCount.Text = lbl_mat_Count.Text;
            }
            else
            {
                if (comBoxRealStockTakeType.SelectedItem.ToString() == "추가")
                {
                    lbl_after_takedCount.Text = (Convert.ToInt32(lbl_mat_Count.Text) + Convert.ToInt32(txtChangeCount.Text)).ToString();
                }
                else if (comBoxRealStockTakeType.SelectedItem.ToString() == "차감")
                {
                    lbl_after_takedCount.Text = (Convert.ToInt32(lbl_mat_Count.Text) - Convert.ToInt32(txtChangeCount.Text)).ToString();
                    if (Convert.ToInt32(lbl_after_takedCount.Text) < 0)
                    {
                        MessageBox.Show("현재 수량보다 많이 차감할 수는 없습니다.");
                    }
                }
            }
        }
        // 추가 / 차감 갯수 변할때
        private void txtChangeCount_TextChanged(object sender, EventArgs e)
        {
            if (txtChangeCount.Text == "")
            {
                lbl_after_takedCount.Text = lbl_mat_Count.Text;
            }
            else
            {
                if (comBoxRealStockTakeType.SelectedItem.ToString() == "추가")
                {
                    lbl_after_takedCount.Text = (Convert.ToInt32(lbl_mat_Count.Text) + Convert.ToInt32(txtChangeCount.Text)).ToString();
                }
                else if (comBoxRealStockTakeType.SelectedItem.ToString() == "차감")
                {
                    lbl_after_takedCount.Text = (Convert.ToInt32(lbl_mat_Count.Text) - Convert.ToInt32(txtChangeCount.Text)).ToString();
                    if (Convert.ToInt32(lbl_after_takedCount.Text) < 0)
                    {
                        MessageBox.Show("현재 수량보다 많이 차감할 수는 없습니다.");
                    }
                }
            }
        }

        // 수정버튼 클릭

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        // 조건검색 클릭
        private void btnSelectCondition_Click(object sender, EventArgs e)
        {

        }
        // 조건삭제 클릭
        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            txtSelectWarehouseCode.Text = "";
            txtSelectWarehouseName.Text = "";
            txtMatCode.Text = "";
            txtMatName.Text = "";
            comBoxMatType.Text = "";
            comBoxStockTakeType.Text = "";
        }
    }
}
