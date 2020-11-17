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

        private void info_4_2_inputBOM_Load(object sender, EventArgs e)
        {
            conn.Open();
            string matInfoHeadQuery = "SELECT * FROM info_bom;";
            cmd = new MySqlCommand(matInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridSelectBOM.DataSource = dtHead;

            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dtCheck = new DataTable();
            conn.Open();
            string checkquery = "SELECT * FROM info_bom WHERE bom_parent_no = @BOM_PARENT";
            string input_query = "INSERT INTO info_bom (bom_no, bom_parent_no, bom_count) VALUES (" + cbMatNo.SelectedItem.ToString() + "," + cbProNo.SelectedItem.ToString() + ","
                                    + txtBomCount.Text + ");";
            cmd = new MySqlCommand(checkquery, conn);
            cmd.Parameters.AddWithValue("@BOM_PARENT", cbProNo.SelectedItem.ToString());

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtCheck);

            int checkrows = Convert.ToInt32(dtCheck.Rows.Count);
            if (checkrows < 3)
            {
                cmd = new MySqlCommand(input_query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("저장완료");
            }
            else
            {
                MessageBox.Show("제품코드는 이미 BOM이 등록되어 있습니다. 수정기능을 이용하세요.");
            }
            conn.Open();
            dtHead.Clear();
            string matInfoHeadQuery = "SELECT * FROM info_bom;";
            cmd = new MySqlCommand(matInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridSelectBOM.DataSource = dtHead;

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow drRow in gridSelectBOM.Rows)
            {
                bool isChecked = Convert.ToBoolean(drRow.Cells[0].Value);

                if (isChecked)
                    gridSelectBOM.Rows.Remove(drRow);
            }

            foreach (DataRow drRow in dtHead.Rows)
            {
                if (drRow.RowState == DataRowState.Deleted)
                {
                    string input_query = "UPDATE info_bom SET bom_count=" + gridSelectBOM.CurrentRow.Cells["bom_count"].Value + " WHERE bom_parent_no = @BOM_P_NO AND bom_no = @BOM_NO;";
                    conn.Open();
                    cmd = new MySqlCommand(input_query, conn);
                    cmd.Parameters.AddWithValue("@BOM_P_NO", drRow["bom_parent_no", DataRowVersion.Original]);
                    cmd.Parameters.AddWithValue("@BOM_NO", drRow["bom_no", DataRowVersion.Original]);
                    cmd.ExecuteNonQuery();
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Update Error 발생.");
                    }
                    MessageBox.Show("저장완료");
                    conn.Close();
                }
            }
            conn.Open();
            dtHead.Clear();
            string matInfoHeadQuery = "SELECT * FROM info_bom;";
            cmd = new MySqlCommand(matInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridSelectBOM.DataSource = dtHead;

            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drRow in gridSelectBOM.Rows)
            {
                bool isChecked = Convert.ToBoolean(drRow.Cells[0].Value);

                if (isChecked)
                    gridSelectBOM.Rows.Remove(drRow);
            }

            foreach (DataRow drRow in dtHead.Rows)
            {
                if (drRow.RowState == DataRowState.Deleted)
                {
                    string deleteQuery = "DELETE FROM info_bom WHERE bom_parent_no=@BOM_P_NO AND bom_no=@BOM_NO";
                    conn.Open();
                    cmd = new MySqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@BOM_P_NO", drRow["bom_parent_no", DataRowVersion.Original]);
                    cmd.Parameters.AddWithValue("@BOM_NO", drRow["bom_no", DataRowVersion.Original]);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            conn.Open();
            dtHead.Clear();
            string matInfoHeadQuery = "SELECT * FROM info_bom;";
            cmd = new MySqlCommand(matInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridSelectBOM.DataSource = dtHead;

            conn.Close();
        }
    }
}
