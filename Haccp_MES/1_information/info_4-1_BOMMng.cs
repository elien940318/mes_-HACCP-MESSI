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
    public partial class info_4_1_BOMMng : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public info_4_1_BOMMng()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dtHead = new DataTable();
            fillcombo();
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
                    cbMatNo.Items.Add(mno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void info_4_1_BOMMng_Load(object sender, EventArgs e)
        {
            conn.Open();
            string matInfoHeadQuery = "SELECT mat_no, mat_name, mat_etc FROM info_material WHERE mat_type = '제품';";
            cmd = new MySqlCommand(matInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();

            if (gridManageInputHead.Rows.Count != 0)
                gridManageInputHead_CellContentClick(new object(), new DataGridViewCellEventArgs(0, 0));
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string bomInfoHeadQuery = "SELECT mat_no, mat_name, mat_etc FROM info_material WHERE mat_type = '제품';";
            cmd = new MySqlCommand(bomInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string matInfoHeadQuery = "SELECT mat_no, mat_name, mat_etc FROM info_material WHERE mat_type = '제품' ";

            if(txtMatName.Text != "")
            {
                matInfoHeadQuery += "AND mat_name LIKE @MAT_NAME ";
            }
            if(cbMatNo.Text != "")
            {
                matInfoHeadQuery += "AND mat_no LIKE @MAT_NO ";
            }
            matInfoHeadQuery += "ORDER BY mat_no;";

            cmd = new MySqlCommand(matInfoHeadQuery, conn);

            cmd.Parameters.AddWithValue("@MAT_NAME", "%" + txtMatName.Text.ToString() + "%");
            cmd.Parameters.AddWithValue("@MAT_NO", cbMatNo.Text.ToString());

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();


            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show(" Error 발생.");
            }
            conn.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            info_4_2_inputBOM newform = new info_4_2_inputBOM();
            newform.Show();
        }

        private void gridManageInputHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var bom_no = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);
            DataTable dtBody = new DataTable();
            conn.Open();

            string bomInfoBodyQuery = "SELECT info_bom.bom_parent_no as 'bom_finish_no', (select mat_name from info_material where mat_no=@BOM_P_NO) as 'mat_finished_name', info_material.mat_name as 'mat_material_name', bom_count, info_material.mat_etc as 'mat_etc'" +
                                            "FROM (select * from info_bom where bom_parent_no = @BOM_P_NO AND bom_no != @BOM_P_NO) info_bom, info_material " +
                                            "WHERE info_material.mat_no = info_bom.bom_no;";
            cmd = new MySqlCommand(bomInfoBodyQuery, conn);
            cmd.Parameters.AddWithValue("@BOM_P_NO", bom_no);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtBody);

            gridBOMinfo.DataSource = dtBody;
            conn.Close();
        }

       
    }
}
