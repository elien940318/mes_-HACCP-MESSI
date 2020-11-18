using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Haccp_MES._3_production
{
    public partial class Pop_WorkOrder_Count : Form
    {

        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;

        string selectedCode; // 콤보박스에서 선택한 품목코드

        public Pop_WorkOrder_Count( )
        {
            InitializeComponent();
           
        }

        private void Pop_WorkOrder_Count_Load(object sender, EventArgs e)
        {
            Prod_1_1_WorkOrders p11w = (Prod_1_1_WorkOrders)this.Owner;
            this.textBox1.Text = p11w.textBox1.Text;  // 이전 창에서 품목명 가져오기
            selectedCode = p11w.cbxITEM.Text; // 이전 창에서 품목코드 가져오기

            GridViewFill();
        }

        // 그리드뷰 데이터 불러오기
        private void GridViewFill()
        {
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            conn.Open();

          
            string qry = "select d.mat_no as 'SubMat_no', d.mat_name as 'subMat_name', c.curmat_count as 'NowStock', d.bom_count as 'UnitCnt', (d.bom_count * 0) as 'Needs' " +
                         "from manage_curmat c,(select a.mat_no, a.mat_name, b.bom_count " +
                                               "from info_material a,(select bom_no, bom_count " +
                                                                      "from info_bom " +
                                                                      "where bom_no != " + selectedCode + " AND bom_parent_no = " + selectedCode + ") b " +
                                               "where a.mat_no = b.bom_no) d " +
                          "where c.mat_no = d.mat_no";


            cmd = new MySqlCommand(qry, conn);
            adapter = new MySqlDataAdapter(cmd);

            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;

            conn.Close(); 
        }

        // 숫자외 입력막기
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자와 백스페이스를 제외한 나머지를 바로 처리
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))   
            {
                e.Handled = true;
            }

        }

        // 지시수량 칸에 숫자를 입력하면...
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            // 입력창이 비어있는 것도 아니면서 값이 0도 아니면
            if (txtQty.Text != "" & txtQty.Text != "0") 
            {
                btnOk.Enabled = true;

                //int realQty;  // 현재고량
                //int unitQty;  // 단위소요량
                //int NeedQty;  // 필요소요량

                double realQty;  // 현재고량
                double unitQty;  // 단위소요량
                double NeedQty;  // 필요소요량

                int k = (int)dataGridView2.Rows.Count;  // 그리드뷰에 출력된 행의 갯수

                for (int i = 0; i < k; i++)
                {
                    //realQty = (int)dataGridView2.Rows[i].Cells[2].Value; // 현재고량
                    //unitQty = (int)dataGridView2.Rows[i].Cells[3].Value; // 단위소요량
                    //NeedQty = unitQty * Convert.ToInt32(txtQty.Text); // 필요소요량

                    realQty = (int)dataGridView2.Rows[i].Cells[2].Value; // 현재고량
                    unitQty = (double)dataGridView2.Rows[i].Cells[3].Value; // 단위소요량
                    NeedQty = unitQty * Convert.ToDouble(txtQty.Text); // 필요소요량

                    dataGridView2.Rows[i].Cells[4].Value = NeedQty;

                    if (realQty < NeedQty) // 실제 재고수량 보다 필요수량이 더 많다면
                    {
                        dataGridView2.Rows[i].Cells[4].Value = realQty - NeedQty;
                        dataGridView2.Rows[i].Cells[4].Style.ForeColor = Color.DarkRed;

                        btnOk.Enabled = false; // 마이너스 하나라도 있으면 확인버튼 비활성화
                    }
                    
                }
            }
            // 입력창이 공백이거나 0이 입력된 상태면
            else if (txtQty.Text == "" || txtQty.Text == "0") 
            {
                btnOk.Enabled = false;

                int k = (int)dataGridView2.Rows.Count;  // 그리드뷰에 출력된 행의 갯수
                for (int i = 0; i < k; i++)
                {
                    dataGridView2.Rows[i].Cells[4].Value = 0;
                }
            }
        }

        // 확인버튼
        private void btnOk_Click(object sender, EventArgs e)
        {
            Prod_1_1_WorkOrders p11w = (Prod_1_1_WorkOrders)this.Owner;

            p11w.textBox2.Text = this.txtQty.Text; // 지시수량을 이전 폼에 넘겨줌

            this.Close(); // 팝업창 닫기
        }

      
    }
}
