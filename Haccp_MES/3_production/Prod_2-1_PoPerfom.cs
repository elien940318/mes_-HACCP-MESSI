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
    public partial class Prod_2_1_PoPerfom : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;

        public Prod_2_1_PoPerfom()
        {
            InitializeComponent();
        }

        private void Prod_2_1_PoPerfom_Load(object sender, EventArgs e)
        {
            AddToComboBox();
        }

        // 콤보박스 초기화
        private void AddToComboBox()
        {
            // cbxOdrNo: 작업지시번호
            // cbxWHS: 창고번호 콤보박스
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            conn.Open();

            #region 작업지시번호
            cmd = new MySqlCommand("select mngodr_no from production_mngodr order by mngodr_no", conn);
            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxOdrNo.Items.Add(rw[0].ToString());  // 콤보박스에 품목코드 넣기
            }
            #endregion

            #region 창고코드
            dt.Rows.Clear(); // dt에 있는 기존행 삭제

            cmd = new MySqlCommand("select ware_no from info_warehouse where ware_name = '제품창고'", conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow rw in dt.Rows)
            {

                cbxWHS.Items.Add(rw[1].ToString());  // 콤보박스에 창고코드 넣기
            }
            #endregion

            conn.Close();
        }

        // 작업지시번호 콤보박스 클릭시
        private void cbxOdrNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbxOdrNo.SelectedItem.ToString(); // 선택한 작업지시번호 값

            string qry = "select a.mngodr_date, a.mngodr_count, b.mat_name " +
                         "from (select * from production_mngodr where mngodr_no = "+ item + ") a, info_material b " +
                         "where a.mat_no = b.mat_no;";

            conn.Open();
            cmd = new MySqlCommand(qry, conn);
        
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                RecDate.Value = Convert.ToDateTime(rd[0].ToString());
                OdrCount.Text = rd[1].ToString();
                txtName.Text = rd[2].ToString();
            }
            conn.Close();
        }

        // 저장버튼
        private void button1_Click(object sender, EventArgs e)
        {
           // 초기세팅값
            if(txtGood.Text ==  "" && txtBad.Text == "" && OdrCount.Text == "")
            {
                txtGood.Text = txtBad.Text = OdrCount.Text = "0";
            }
            int OdrCnt = Convert.ToInt32(OdrCount.Text);
            int Sum = Convert.ToInt32(txtGood.Text) + Convert.ToInt32(txtBad.Text);
            string onum = cbxOdrNo.Text;
            
            // 입력 다 안하고 저장하면 막아라고 알려줘라
            if (OdrCnt != Sum)
            {
                MessageBox.Show("양품 및 불량수량의 합은 지시수량과 동일해야 합니다.", "주의", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(cbxOdrNo.Text == "" || txtGood.Text == "" || txtBad.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("미입력된 항목이 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (ChkOrderNo(onum) == true) // 작업지시번호가 중복이면
                {
                    MessageBox.Show("이미 등록된 작업지시번호가 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ChkOrderNo(onum) == false) // 작업지시번호가 중복이 아니면
                {
                    conn.Open();
                    string qry = "insert into production_prodrecod(mngodr_no, prodrecod_date, prodrecod_good, prodrecod_err, ware_no) values('" + cbxOdrNo.Text + "','" + RecDate.Value.ToShortDateString() + "'," + txtGood.Text + ",'" + txtBad.Text + "','" + cbxWHS.Text + "')";
                    cmd = new MySqlCommand(qry, conn);
                    if (cmd.ExecuteNonQuery() != -1)
                    {
                        MessageBox.Show("정상적으로 등록되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("등록에 실패했습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();

                    Prod_2_PerformanceMng p2pm = (Prod_2_PerformanceMng)this.Owner;
                    p2pm.GridViewFill();

                    this.Close();
                }
            }
           
        }

        // 닫기버튼
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 수량 입력란에 문자 입력 못하게 막음
        private void txtGood_KeyPress(object sender, KeyPressEventArgs e)
        {
            //문자나 한글 입력 막음
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtBad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        //창고 콤보박스 눌렀을때
        private void cbxWHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbxWHS.SelectedItem.ToString(); // 선택한 값
            // 위에껄로 커리 만들자
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

        //작업지시 중복검사 
        private bool ChkOrderNo(string num)
        {
            string qry = "select mngodr_no from production_prodrecod where mngodr_no ='" + num + "'";
            string odrnum = "";

            conn.Open();
            cmd = new MySqlCommand(qry, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                odrnum = rd[0].ToString();
            }
            conn.Close();

            if(num == odrnum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
