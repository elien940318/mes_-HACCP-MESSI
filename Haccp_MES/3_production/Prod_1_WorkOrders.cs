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

namespace Haccp_MES._3_production
{
    public partial class Prod_1_WorkOrders : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        DataTable dt2;


        public Prod_1_WorkOrders()
        {
            InitializeComponent();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Prod_1_WorkOrders_Load(object sender, EventArgs e)
        {
            AddToComboBox();
            TopGridViewFill();
        
        }

        // 상단 그리드뷰에서 행을 하나 클릭하면 아래 그리드뷰엔 뭐가 나오게요?
        private void gridManageInputHead_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            // 행에서 4번째 열에 있는 값인 모품목 코드를 가져온다.
            // 행에서 8번째 열에 있는 지시수량을 가져온다.
            string ParentNum = gridManageInputHead.CurrentRow.Cells[3].Value.ToString();
            string OrderCnt = gridManageInputHead.CurrentRow.Cells[7].Value.ToString();

            conn.Open();

          
           string qry = "select c.mat_no as 'SubMat_no', c.mat_name as 'subMat_name', c.mat_type as 'Mtype', d.bom_count as 'unitUse', (d.bom_count * "+OrderCnt+ ") as 'RealUsed' " +
                "from (select * from info_material a,(select bom_no from info_bom where bom_no != "+ParentNum+" AND bom_parent_no = "+ParentNum+ ") b where a.mat_no = b.bom_no) c, info_bom d " +
                "where c.bom_no = d.bom_no AND d.bom_parent_no = "+ParentNum;


            cmd = new MySqlCommand(qry, conn);
            adapter = new MySqlDataAdapter(cmd);

            dt2 = new DataTable();
            adapter.Fill(dt2);
            dataGridView1.DataSource = dt2;

            conn.Close(); 
        }

        
       // 상단 그리드뷰 초기 설정 함수
        private void TopGridViewFill()
        {
  
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            conn.Open();

            string qry = "SELECT a.mngodr_no as 'WorkNo', a.mngodr_date as 'WorkDate', a.mat_no as 'Mcode', b.mat_name as 'Mname', b.mat_type as 'Mtype', b.mat_spec as 'Mspec', a.mngodr_count as 'Work_count', a.user_id as 'Manager', a.ware_no as 'WareNo'" +
                         "FROM production_mngodr a, info_material b " +
                         "WHERE a.mat_no = b.mat_no order by a.mngodr_no";

            cmd = new MySqlCommand(qry, conn);
            adapter = new MySqlDataAdapter(cmd);

            dt = new DataTable();
            adapter.Fill(dt);
            gridManageInputHead.DataSource = dt;

            conn.Close(); // 일단 불러왔으니 DB는 닫자
        }

        // 콤보박스 초기 설정 함수
        private void AddToComboBox( )
        {
            // cbxWorkNo : 작업지시번호 콤보박스
            // cbxMatCode: 품목번호 콤보박스
            // cbxWareHouse: 창고번호 콤보박스
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            conn.Open();

            #region 작업지시코드
            cmd = new MySqlCommand("SELECT mngodr_no FROM production_mngodr", conn);
            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            
            adapter.Fill(dt);
                    
            foreach (DataRow rw in dt.Rows)
            {
              
                cbxWorkNo.Items.Add(rw[0].ToString());  // 콤보박스에 작업지시코드 넣기
            }
            #endregion

            #region 품목코드
            dt.Rows.Clear(); // dt에 있는 저장된 행들(데이터) 

            cmd = new MySqlCommand("select mat_no from info_material where mat_type = '제품'", conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxMatCode.Items.Add(rw[1].ToString());  // 콤보박스에 품목코드 넣기
            }
            #endregion

            #region 창고코드
            dt.Rows.Clear(); // dt에 있는 기존행 삭제

            cmd = new MySqlCommand("select ware_no from info_warehouse", conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxWareHouse.Items.Add(rw[2].ToString());  // 콤보박스에 창고코드 넣기
            }
            #endregion

            conn.Close();
        }

        // 품목코드 콤보박스 클릭시
        private void cbxMatCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            string item = cbxMatCode.SelectedItem.ToString(); // 선택한 값
            // 위에껄로 커리 만들자
            string qry = "SELECT mat_name FROM info_material WHERE mat_no =" + item + "";

            conn.Open();
            cmd = new MySqlCommand(qry,conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox1.Text = rd[0].ToString();
            }
            conn.Close();

        }
        
        // 보관창고 콤보박스 클릭시
        private void cbxWareHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbxWareHouse.SelectedItem.ToString(); // 선택한 값
            // 위에껄로 커리 만들자
            string qry = "SELECT ware_name FROM info_warehouse WHERE ware_no =" + item + "";

            conn.Open();
            cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox2.Text = rd[0].ToString();
            }
            conn.Close();
        }

        // 조회
        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();

            string qry = "SELECT a.mngodr_no as 'WorkNo', a.mngodr_date as 'WorkDate', a.mat_no as 'Mcode', b.mat_name as 'Mname', b.mat_type as 'Mtype', b.mat_spec as 'Mspec', a.mngodr_count as 'Work_count', a.user_id as 'Manager', a.ware_no as 'WareNo'" +
                        "FROM production_mngodr a, info_material b " +
                        "WHERE a.mat_no = b.mat_no ";


            if (cbxWorkNo.Text != "")
            {
                qry += " AND a.mngodr_no = " + cbxWorkNo.Text + "";
            }
            if (cbxMatCode.Text != "")
            {
                qry += " AND b.mat_no = " + cbxMatCode.Text + "";
            }
            if (cbxWareHouse.Text != "")
            {
                qry += " AND a.ware_no = " + cbxWareHouse.Text + "";
            }
            if (wkStartDate.Text != "" || wkEndDate.Text != "")
            {
                // qry += " AND a.mngodr_date BETWEEN '" + wkStartDate.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + wkEndDate.Value.Date.ToString("yyyy-MM-dd") + "'";
                qry += " AND DATE(a.mngodr_date) BETWEEN '" + wkStartDate.Value.Date.ToString() + "' AND '" + wkEndDate.Value.Date.ToString() + "'";
            }


            cmd = new MySqlCommand(qry, conn);
            adapter = new MySqlDataAdapter(cmd);

            dt = new DataTable();
            adapter.Fill(dt);
            gridManageInputHead.DataSource = dt;

            conn.Close(); // 일단 불러왔으니 DB는 닫자
        }

        // 새로고침
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //그룹박스 내의 검색 조건들을 한 번에 지워주는 기능.
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
                //else if (item is DateTimePicker)
                //{
                //    ((DateTimePicker)item).Text = "";
                //}
            }

            TopGridViewFill();
        }

        // 등록
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Prod_1_1_WorkOrders PopUp = new Prod_1_1_WorkOrders();
            PopUp.Owner = this;
            PopUp.ShowDialog();
        }

        // 리셋
        public void ResetTopGridView()
        {
            TopGridViewFill();
        }
    }
}
