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
    public partial class Prod_1_1_WorkOrders : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;



        public Prod_1_1_WorkOrders()
        {
            InitializeComponent();
            wkDate.MaxDate = DateTime.Now;
        }

        private void Prod_1_1_WorkOrders_Load(object sender, EventArgs e)
        {
            AddToComboBox();
        }

        // 콤보박스 초기화
        private void AddToComboBox()
        {
            // cbxITEM: 품목번호 콤보박스
            // cbxWHS: 창고번호 콤보박스
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            conn.Open();

            #region 품목코드
            cmd = new MySqlCommand("select mat_no from info_material where mat_type = '제품'", conn);
            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxITEM.Items.Add(rw[0].ToString());  // 콤보박스에 품목코드 넣기
            }
            #endregion

            #region 창고코드
            dt.Rows.Clear(); // dt에 있는 기존행 삭제

            cmd = new MySqlCommand("select ware_no from info_warehouse where ware_name = '검사대기창고'", conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxWHS.Items.Add(rw[1].ToString());  // 콤보박스에 창고코드 넣기
            }
            #endregion

            conn.Close();
        }

        //지시품목 콤보박스 클릭시
        private void cbxITEM_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 품목명 출력
            string item = cbxITEM.SelectedItem.ToString(); // 선택한 값
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
            #endregion
            

            Pop_WorkOrder_Count PWC = new Pop_WorkOrder_Count();
            PWC.Owner = this;
            PWC.ShowDialog();
            PWC.Dispose();

        }

        //입고창고 콤보박스 클릭시
        private void cbxWHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbxWHS.SelectedItem.ToString(); // 선택한 값
           
            string qry = "SELECT ware_name FROM info_warehouse WHERE ware_no =" + item + "";

            conn.Open();
            cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox3.Text = rd[0].ToString();
            }
            conn.Close();
        }

        // 닫기버튼
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 저장버튼
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string qry = "insert into production_mngodr(mngodr_date, mat_no, mngodr_count, user_id, ware_no) values('" + wkDate.Value.ToShortDateString() + "'," + cbxITEM.Text + ","+ textBox2.Text +",'"+ txtAdmin.Text +"',"+ cbxWHS.Text +")";
            cmd = new MySqlCommand(qry, conn);
            if(cmd.ExecuteNonQuery() != -1)
            {
                MessageBox.Show("정상적으로 등록되었습니다.","알림", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("등록에 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();

            // 그리드뷰 리셋
            Prod_1_WorkOrders p1w = (Prod_1_WorkOrders)this.Owner;
            p1w.ResetTopGridView();

            this.Close();
            
        }
    }
}
