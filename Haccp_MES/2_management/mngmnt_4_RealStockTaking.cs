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
            // 아 무 일 도 없 었 다 !
        }

        private void btnChangedHistory_Click(object sender, EventArgs e)
        {
            // 그리드 뷰 청소
            dtHead.Clear();
            dtHead.Columns.Clear();

            gridManageStockHead.Columns.Clear();
            gridManageStockHead.DataSource = null;

            // 그리드 뷰 칼럼 재설정
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
                    "DATE_FORMAT(stocktake_date,'%Y-%m-%d') as 'realStock_date' " +
                "FROM manage_realstocktake, info_warehouse, info_material " +
                "WHERE manage_realstocktake.ware_no = info_warehouse.ware_no " +
                    "AND manage_realstocktake.mat_no = info_material.mat_no " +
                "ORDER BY stocktake_no;";

            cmd = new MySqlCommand(StockHeadQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageStockHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageStockHead.Rows.Count.ToString();

            conn.Close();

            //수정버튼 비활성화
            btnUpdate.Visible = false;

            //검색이 가능해진 항목들 되살리기
            label17.Visible = true;
            label18.Visible = true;
            label7.Visible = true;
            dtPicker1.Visible = true;
            dtPicker2.Visible = true;
            comBoxStockTakeType.Visible = true;
        }

        private void btnSelectNow_Click(object sender, EventArgs e)
        {
            // 그리드 뷰 청소
            dtHead.Clear();
            dtHead.Columns.Clear();

            gridManageStockHead.Columns.Clear();
            gridManageStockHead.DataSource = null;

            // 그리드 뷰 칼럼 재설정
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

            //수정버튼 활성화
            btnUpdate.Visible = true;

            // 검색이 불가능한 항목들 숨기기
            label17.Visible = false;
            label18.Visible = false;
            label7.Visible = false;
            dtPicker1.Visible = false;
            dtPicker2.Visible = false;
            comBoxStockTakeType.Visible = false;
        }
        // 셀 클릭
        private void gridManageStockHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridManageStockHead.ColumnCount == 6) // 현 재고량 확인중인 경우
            {
                // 수정이 가능하므로 수량변경,실사타입 설정,메모 가능
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
            else if (gridManageStockHead.ColumnCount == 9) // 재고실사내역 확인중인 경우
            {
                // 수정이 가능하므로 수량변경,실사타입 설정,메모 불가능
                comBoxRealStockTakeType.Enabled = false;
                txtChangeCount.Enabled = false;
                txtMemo.Enabled = false;

                // 검색에 필요한 값을 얻기 위해 그리드 뷰에서 값 가져옴.
                var stockTake_id = Convert.ToInt32(gridManageStockHead.CurrentRow.Cells[0].Value);
                var stocktake_type = gridManageStockHead.CurrentRow.Cells[5].Value.ToString();
                
                //그리드 뷰 유지하면서 새로운 데이터 받기 위함
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

                //상세내역의 패널들에 값들을 넣어주는 과정
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
            else
            {
                MessageBox.Show("버그 발견!");
            }

        }
        // 추가 / 차감 항목 변할때
        private void comBoxRealStockTakeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 빈칸일 때 설정해주지 않으면 에러뜸.
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
            // 빈칸일 때 설정해주지 않으면 에러뜸.
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

        // 수정버튼 클릭, 트리거를 사용하여 재고실사관리에서 수정되면 실제 재고에도 반영되도록 함
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbl_wareHouse_Code.Text != "" && lbl_mat_Code.Text != "" && comBoxRealStockTakeType.SelectedItem != null && lbl_mat_Count.Text != "" && txtChangeCount.Text != "")
            {
                conn.Open();
                string insertRealStockQuery = "INSERT INTO manage_realstocktake" +
                    "(ware_no, mat_no, stocktake_type, stocktake_beforecount, stocktake_changecount, user_id, stocktake_date, memo) " +
                    "VALUES(@WARE_NO, @MAT_NO, @TYPE, @BEFORE, @CHANGE, 'admin', now(), @MEMO);";

                cmd = new MySqlCommand(insertRealStockQuery, conn);

                cmd.Parameters.AddWithValue("@WARE_NO"  , Convert.ToInt32(lbl_wareHouse_Code.Text));
                cmd.Parameters.AddWithValue("@MAT_NO"   , Convert.ToInt32(lbl_mat_Code.Text));
                cmd.Parameters.AddWithValue("@TYPE"     , comBoxRealStockTakeType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@BEFORE"   , Convert.ToInt32(lbl_mat_Count.Text));
                cmd.Parameters.AddWithValue("@CHANGE"   , Convert.ToInt32(txtChangeCount.Text));
                cmd.Parameters.AddWithValue("@MEMO"     , txtMemo.Text.ToString());

                // cmd의 쿼리문을 던져줌과 동시에 반영여부 파악
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("수정에러 발생");
                }
                else
                {
                    MessageBox.Show("실사내역이 반영되었습니다.");
                }
                conn.Close();

                btnChangedHistory_Click(sender, e);
            }
        }
        // 조건검색 클릭
        private void btnSelectCondition_Click(object sender, EventArgs e)
        {
            if (gridManageStockHead.ColumnCount == 9) // 변경 내역 조회중인 상황
            {
                dtHead.Clear();
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
                        "DATE_FORMAT(stocktake_date,'%Y-%m-%d') as 'realStock_date' " +
                    "FROM manage_realstocktake, info_warehouse, info_material " +
                    "WHERE manage_realstocktake.ware_no = info_warehouse.ware_no " +
                        "AND manage_realstocktake.mat_no = info_material.mat_no ";
                if (txtSelectWarehouseCode.Text != "")
                {
                    StockHeadQuery += "AND manage_realstocktake.ware_no like @WARE_NO ";
                }
                if (txtSelectWarehouseName.Text != "")
                {
                    StockHeadQuery += "AND ware_name like @WARE_NAME ";
                }
                if (txtMatCode.Text != "")
                {
                    StockHeadQuery += "AND manage_realstocktake.mat_no like @MAT_NO ";
                }
                if (txtMatName.Text != "")
                {
                    StockHeadQuery += "AND mat_name like @MAT_NAME ";
                }
                if (comBoxMatType.Text != "")
                {
                    StockHeadQuery += "AND mat_type like @MAT_TYPE ";
                }
                if (comBoxStockTakeType.Text != "")
                {
                    StockHeadQuery += "AND stocktake_type like @STOCKTAKE_TYPE ";
                }
                StockHeadQuery += 
                    "AND stocktake_date BETWEEN @DATETIME1 AND @DATETIME2 "+
                    "GROUP BY manage_realstocktake.ware_no, manage_realstocktake.mat_no " +
                    "ORDER BY manage_realstocktake.ware_no;";

                cmd = new MySqlCommand(StockHeadQuery, conn);

                cmd.Parameters.AddWithValue("@WARE_NO"          , "%" + txtSelectWarehouseCode.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@WARE_NAME"        , "%" + txtSelectWarehouseName.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@MAT_NO"           , "%" + txtMatCode.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@MAT_NAME"         , "%" + txtMatName.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@MAT_TYPE"         , "%" + comBoxMatType.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@STOCKTAKE_TYPE"   , "%" + comBoxStockTakeType.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@DATETIME1", dtPicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@DATETIME2", dtPicker2.Value.AddDays(1).ToString("yyyy-MM-dd"));

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtHead);

                gridManageStockHead.DataSource = dtHead;
                lblHeadCount.Text = gridManageStockHead.Rows.Count.ToString();

                conn.Close();
            }
            else if (gridManageStockHead.ColumnCount == 6) // 현 재고 조회중인 상황
            {
                dtHead.Clear();
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
                     "AND manage_curmat.mat_no = info_material.mat_no ";
                if (txtSelectWarehouseCode.Text != "")
                {
                    StockHeadQuery += "AND manage_curmat.ware_no like @WARE_NO ";
                }
                if (txtSelectWarehouseName.Text != "")
                {
                    StockHeadQuery += "AND ware_name like @WARE_NAME ";
                }
                if (txtMatCode.Text != "")
                {
                    StockHeadQuery += "AND manage_curmat.mat_no like @MAT_NO ";
                }
                if (txtMatName.Text != "")
                {
                    StockHeadQuery += "AND mat_name like @MAT_NAME ";
                }
                if (comBoxMatType.Text != "")
                {
                    StockHeadQuery += "AND mat_type like @MAT_TYPE ";
                }
                StockHeadQuery +=
                 "GROUP BY manage_curmat.ware_no, manage_curmat.mat_no " +
                 "ORDER BY manage_curmat.ware_no;";

                cmd = new MySqlCommand(StockHeadQuery, conn);

                cmd.Parameters.AddWithValue("@WARE_NO", "%" + txtSelectWarehouseCode.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@WARE_NAME", "%" + txtSelectWarehouseName.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@MAT_NO", "%" + txtMatCode.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@MAT_NAME", "%" + txtMatName.Text.ToString() + "%");
                cmd.Parameters.AddWithValue("@MAT_TYPE", "%" + comBoxMatType.Text.ToString() + "%");

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtHead);

                gridManageStockHead.DataSource = dtHead;
                lblHeadCount.Text = gridManageStockHead.Rows.Count.ToString();

                conn.Close();
            }
            else
            {
                MessageBox.Show("세상에 이런 일이!");
            }
        }
        // 조건삭제 클릭
        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            // 조건들 모두 비움
            txtSelectWarehouseCode.Text = "";
            txtSelectWarehouseName.Text = "";
            txtMatCode.Text = "";
            txtMatName.Text = "";
            comBoxMatType.Text = "";
            comBoxStockTakeType.Text = "";
            // 달력 시작과 끝 설정
            string datetimeset = "2020-01-01";
            dtPicker1.Value = Convert.ToDateTime(datetimeset);
            dtPicker2.Value = DateTime.Now;
        }
    }
}
