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
    public partial class info_2_itemMng : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public info_2_itemMng()
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
            string fillCombo = "SELECT * FROM info_material;";
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

        void fillcombo1()
        {
            conn.Open();
            string fillcombo = "SELECT * FROM info_material GROUP BY mat_type;";
            cmd = new MySqlCommand(fillcombo, conn);
            MySqlDataReader myreader;
            try
            {
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string mtype = myreader.GetString("mat_type");
                    cbMatType.Items.Add(mtype);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        public void renew()
        {
            conn.Open();
            dtHead.Clear();
            string materialInfoHeadQuery = "SELECT * FROM info_material;";
            cmd = new MySqlCommand(materialInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            info_2_2_inputitem newForm = new info_2_2_inputitem();
            newForm.Show();
        }



        private void btnSelect_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string materialInfoHeadQuery = "SELECT * FROM info_material;";
            cmd = new MySqlCommand(materialInfoHeadQuery, conn);

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
            string materialInfoHeadQuery = "SELECT * FROM info_material WHERE mat_name LIKE '" + txtMatName.Text +
                                          "' OR mat_type LIKE '" + cbMatType.SelectedItem + "' OR mat_no LIKE '" +
                                          cbMatNo.SelectedItem + "';";

            cmd = new MySqlCommand(materialInfoHeadQuery, conn);

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

        private void info_2_itemMng_Load(object sender, EventArgs e)
        {
            conn.Open();
            string materialInfoHeadQuery = "SELECT * FROM info_material;";
            cmd = new MySqlCommand(materialInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();

            if (gridManageInputHead.Rows.Count != 0)
                gridManageInputHead_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void gridManageInputHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var mat_no = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);
            DataTable dtBody = new DataTable();
            conn.Open();

            string materialInfoBodyQuery = "SELECT * FROM info_material WHERE mat_no=@MAT_NO;";
            cmd = new MySqlCommand(materialInfoBodyQuery, conn);
            cmd.Parameters.AddWithValue("@MAT_NO", mat_no);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtBody);

            int i = 0;
            foreach (var item in tblLyoutPnl.Controls)
            {

                if (item is Label)
                {
                    if (((Label)item).FlatStyle == FlatStyle.Standard)
                    {
                        ((Label)item).Text = dtBody.Rows[0].ItemArray[i].ToString();
                        i++;
                    }
                }
                else if (item is TextBox)
                {
                    ((TextBox)item).Text = dtBody.Rows[0].ItemArray[i].ToString();
                    i++;
                }
            }

            conn.Close();

        }

        private void gridManageInputHead_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;

            view.SelectedRows[0].Cells[0].Value = !Convert.ToBoolean(view.SelectedRows[0].Cells[0].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string[] updateDatas = new string[5] { txtmat_name.Text, txtmat_type.Text, txtmat_spec.Text, txt_matprice.Text, txtmat_etc.Text };
            var mat_no = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);


            string UpdateQuery = "UPDATE info_material SET mat_name=@MAT_NAME, mat_type=@MAT_TYPE, mat_spec=@MAT_SPEC, mat_price=@MAT_PRICE, mat_etc=@MAT_ETC WHERE mat_no=@MAT_NO;";
            cmd = new MySqlCommand(UpdateQuery, conn);
            cmd.Parameters.AddWithValue("@MAT_NAME", updateDatas[0]);
            cmd.Parameters.AddWithValue("@MAT_TYPE", updateDatas[1]);
            cmd.Parameters.AddWithValue("@MAT_SPEC", updateDatas[2]);
            cmd.Parameters.AddWithValue("@MAT_PRICE", updateDatas[3]);
            cmd.Parameters.AddWithValue("@MAT_ETC", updateDatas[4]);
            cmd.Parameters.AddWithValue("@MAT_NO", mat_no);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Update Error 발생.");
            }
            conn.Close();

            btnSelect_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = 0;
            conn.Open();
            foreach (DataGridViewRow drRow in gridManageInputHead.Rows)
            {
                bool isChecked = Convert.ToBoolean(drRow.Cells[0].Value);
                if (isChecked)
                {
                    int mn = Convert.ToInt32(gridManageInputHead.Rows[i].Cells["mat_no"].Value);
                    string delete_query = "DELETE FROM info_material WHERE mat_no = @MAT_NO;";
                    cmd = new MySqlCommand(delete_query, conn);
                    cmd.Parameters.AddWithValue("@MAT_NO", mn);
                    cmd.ExecuteNonQuery();
                }
                i++;
            }
            conn.Close();
            MessageBox.Show("삭제완료");
            renew();
        }
    }
}
