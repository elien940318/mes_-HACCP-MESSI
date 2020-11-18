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
    public partial class Prod_2_PerformanceMng : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;

        public Prod_2_PerformanceMng()
        {
            InitializeComponent();
        }

        private void Prod_2_PerformanceMng_Load(object sender, EventArgs e)
        {
            AddToComboBox();
            GridViewFill();
        }


        // 콤보박스 초기 설정 함수
        private void AddToComboBox()
        {
            // cbxRecNo : 작업실적번호 콤보박스
            // cbxOdrNo : 작업지시번호 콤보박스
            // cbxMatCode : 품목코드 콤보박스
            // cbxWareHouse: 창고번호 콤보박스
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            conn.Open();

            #region 작업실적코드
            cmd = new MySqlCommand("SELECT prodrecod_no FROM production_prodrecod", conn);
            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();

            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxRecNo.Items.Add(rw[0].ToString());  // 콤보박스에 작업실적코드 넣기
            }
            #endregion

            #region 작업지시번호
            dt.Rows.Clear(); // dt에 있는 저장된 행들(데이터) 

            cmd = new MySqlCommand("select mngodr_no from production_mngodr", conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxOdrNo.Items.Add(rw[1].ToString());  // 콤보박스에 품목코드 넣기
            }
            #endregion

            #region 품목코드
            dt.Rows.Clear(); // dt에 있는 기존행 삭제

            cmd = new MySqlCommand("select mat_no from info_material", conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxMatCode.Items.Add(rw[2].ToString());  // 콤보박스에 창고코드 넣기
            }
            #endregion

            #region 창고코드
            dt.Rows.Clear(); // dt에 있는 기존행 삭제

            cmd = new MySqlCommand("select ware_no from info_warehouse", conn);
            // cmd = new MySqlCommand("select ware_no from info_warehouse where ware_name like '" + "%대기%'", conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxWareHouse.Items.Add(rw[3].ToString());  // 콤보박스에 창고코드 넣기
            }
            #endregion

            conn.Close();
        }

        // 그리드뷰 초기 설정
        private void GridViewFill()
        {
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            conn.Open();

            string qry = "select a.prodrecod_no as 'WkRecNo', a.mngodr_no as 'WorkNo', a.prodrecod_date as 'RecDate', c.mat_name as 'Mname', c.mat_spec as 'Mspec', b.mngodr_count as 'OrderQTY', a.prodrecod_good as 'GoodItem', a.prodrecod_err as 'badITEM', a.ware_no as 'WareHS' " +
                         "from production_prodrecod a, production_mngodr b, info_material c " +
                         "where a.mngodr_no = b.mngodr_no AND b.mat_no = c.mat_no";

            cmd = new MySqlCommand(qry, conn);
            adapter = new MySqlDataAdapter(cmd);

            dt = new DataTable();
            adapter.Fill(dt);
            gridManageInputHead.DataSource = dt;

            conn.Close(); 
        }

        // 새로고침버튼
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 그룹박스 내 입력된 값 지우기
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

            GridViewFill();

        }

        //품목코드 콤보박스 선택시
        private void cbxMatCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbxMatCode.SelectedItem.ToString(); // 선택한 값
            
            // 위에껄로 커리 만들자
            string qry = "SELECT mat_name FROM info_material WHERE mat_no =" + item + "";

            conn.Open();
            cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox1.Text = rd[0].ToString();
            }
            conn.Close();
        }

        // 보관창고 콤보박스 선택시
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

        // 조회버튼
        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();

            string qry = "select a.prodrecod_no as 'WkRecNo', a.mngodr_no as 'WorkNo', a.prodrecod_date as 'RecDate', c.mat_name as 'Mname', c.mat_spec as 'Mspec', b.mngodr_count as 'OrderQTY', a.prodrecod_good as 'GoodItem', a.prodrecod_err as 'badITEM', a.ware_no as 'WareHS' " +
                         "from production_prodrecod a, production_mngodr b, info_material c " +
                         "where a.mngodr_no = b.mngodr_no AND b.mat_no = c.mat_no";


            if (cbxRecNo.Text != "")
            {
                qry += " AND a.prodrecod_no = " + cbxRecNo.Text + "";
            }
            if (cbxOdrNo.Text != "")
            {
                qry += " AND a.mngodr_no = " + cbxOdrNo.Text + "";
            }
            if (cbxMatCode.Text != "")
            {
                qry += " AND c.mat_no = " + cbxMatCode.Text + "";
            }
            if (cbxWareHouse.Text != "")
            {
                qry += " AND a.ware_no = " + cbxWareHouse.Text + "";
            }
            if (wkStartDate.Text != "" || wkEndDate.Text != "")
            {
                // qry += " AND a.mngodr_date BETWEEN '" + wkStartDate.Value.Date.ToString("yyyy-MM-dd") + "' AND '" + wkEndDate.Value.Date.ToString("yyyy-MM-dd") + "'";
                qry += " AND DATE(a.prodrecod_date) BETWEEN '" + wkStartDate.Value.Date.ToString() + "' AND '" + wkEndDate.Value.Date.ToString() + "'";
            }


            cmd = new MySqlCommand(qry, conn);
            adapter = new MySqlDataAdapter(cmd);

            dt = new DataTable();
            adapter.Fill(dt);
            gridManageInputHead.DataSource = dt;

            conn.Close(); // 일단 불러왔으니 DB는 닫자
        }
    }
}
