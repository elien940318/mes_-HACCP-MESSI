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

namespace Haccp_MES._1_information
{
    public partial class info_4_2_inputBOM : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public info_4_2_inputBOM()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dtHead = new DataTable();
            fillcombo();
            fillcombo1();
        }

        void fillcombo()
        {
            conn.Open();
            string fillCombo = "SELECT * FROM info_material WHERE mat_type = '제품';";
            cmd = new MySqlCommand(fillCombo, conn);
            MySqlDataReader myreader;
            try
            {
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string mno = myreader.GetString("mat_no");
                    cbProNo.Items.Add(mno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        void fillcombo1()
        {
            conn.Open();
            string fillCombo = "SELECT * FROM info_material WHERE mat_type != '제품';";
            cmd = new MySqlCommand(fillCombo, conn);
            MySqlDataReader myreader;
            try
            {
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string mno = myreader.GetString("mat_no");
                    cbMatNo.Items.Add(mno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        public void openHead(object sender, EventArgs e)
        {
            dtHead.Clear();
            conn.Open();
            string matInfoHeadQuery = "SELECT * FROM info_bom;";
            cmd = new MySqlCommand(matInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridSelectBOM.DataSource = dtHead;

            conn.Close();
        }

        private void info_4_2_inputBOM_Load(object sender, EventArgs e)
        {
            openHead(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbMatNo.Text != "" && cbProNo.Text != "" && txtBomCount.Text != "")
            {
                DataTable dtCheck = new DataTable();

                conn.Open();

                string checkquery = "SELECT * FROM info_bom WHERE bom_no=@BOM_NO AND bom_parent_no = @BOM_PARENT;";

                cmd = new MySqlCommand(checkquery, conn);

                cmd.Parameters.AddWithValue("@BOM_NO", Convert.ToInt32(cbMatNo.Text));
                cmd.Parameters.AddWithValue("@BOM_PARENT", Convert.ToInt32(cbProNo.Text));

                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtCheck);

                int checkrows = Convert.ToInt32(dtCheck.Rows.Count);
                if (checkrows < 1)
                {
                    string input_query = "INSERT INTO info_bom (bom_no, bom_parent_no, bom_count) VALUES (@BOM_NO,@BOM_PARENT,@BOM_COUNT);";

                    cmd = new MySqlCommand(input_query, conn);

                    cmd.Parameters.AddWithValue("@BOM_NO", Convert.ToInt32(cbMatNo.Text));
                    cmd.Parameters.AddWithValue("@BOM_PARENT", Convert.ToInt32(cbProNo.Text));
                    cmd.Parameters.AddWithValue("@BOM_COUNT", Convert.ToInt32(txtBomCount.Text));

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("저장완료");
                    }
                    else
                    {
                        MessageBox.Show("오류발생");
                    }
                }
                else
                {
                    MessageBox.Show("제품에 이미 재료 BOM이 등록되어 있습니다. 수정기능을 이용하세요.");
                }
                conn.Close();

                openHead(sender, e);
            }
            else
            {
                MessageBox.Show("값을 입력해주세요.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow drRow in gridSelectBOM.Rows)
            {
                bool isChecked = Convert.ToBoolean(drRow.Cells[0].Value);

                conn.Open();

                if (isChecked)
                {
                    int bpn = Convert.ToInt32(gridSelectBOM.Rows[i].Cells["bom_parent_no"].Value);
                    int bn = Convert.ToInt32(gridSelectBOM.Rows[i].Cells["bom_no"].Value);
                    int bc = Convert.ToInt32(gridSelectBOM.Rows[i].Cells["bom_count"].Value);

                    string update_query = "UPDATE info_bom SET bom_count = @BOM_COUNT WHERE bom_parent_no = @BOM_PARENT_NO AND bom_no = @BOM_NO;";


                    cmd = new MySqlCommand(update_query, conn);

                    cmd.Parameters.AddWithValue("@BOM_PARENT_NO", bpn);
                    cmd.Parameters.AddWithValue("@BOM_NO", bn);
                    cmd.Parameters.AddWithValue("@BOM_COUNT", bc);

                    cmd.ExecuteNonQuery();
                }

                i++;
                conn.Close();
            }
            MessageBox.Show("수정완료");

            openHead(sender, e);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            conn.Open();
            foreach (DataGridViewRow drRow in gridSelectBOM.Rows)
            {
                bool isChecked = Convert.ToBoolean(drRow.Cells[0].Value);
                if (isChecked)
                {
                    int bpn = Convert.ToInt32(gridSelectBOM.Rows[i].Cells["bom_parent_no"].Value);
                    int bn = Convert.ToInt32(gridSelectBOM.Rows[i].Cells["bom_no"].Value);

                    string update_query = "DELETE FROM info_bom WHERE bom_parent_no = @BOM_PARENT_NO AND bom_no = @BOM_NO;";
                    cmd = new MySqlCommand(update_query, conn);
                    cmd.Parameters.AddWithValue("@BOM_PARENT_NO", bpn);
                    cmd.Parameters.AddWithValue("@BOM_NO", bn);
                    cmd.ExecuteNonQuery();
                }
                i++;
            }
            conn.Close();
            MessageBox.Show("삭제완료");

            openHead(sender, e);
        }
    }
}