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
    public partial class info_3_WareHouseMng : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public info_3_WareHouseMng()
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
            string fillCombo = "SELECT * FROM info_warehouse;";
            cmd = new MySqlCommand(fillCombo, conn);
            MySqlDataReader myreader;
            try
            {
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string wno = myreader.GetString("ware_no");
                    cbWareNo.Items.Add(wno);
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
            string fillcombo = "SELECT * FROM info_warehouse GROUP BY ware_type;";
            cmd = new MySqlCommand(fillcombo, conn);
            MySqlDataReader myreader;
            try
            {
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string wtype = myreader.GetString("ware_type");
                    cbWareType.Items.Add(wtype);
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
            string warehouseInfoHeadQuery = "SELECT * FROM info_warehouse;";
            cmd = new MySqlCommand(warehouseInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }



        private void info_3_WareHouseMng_Load(object sender, EventArgs e)
        {
            conn.Open();
            string warehouseInfoHeadQuery = "SELECT * FROM info_warehouse;";
            cmd = new MySqlCommand(warehouseInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();

            if (gridManageInputHead.Rows.Count != 0)
                gridManageInputHead_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string warehouseInfoHeadQuery = "SELECT * FROM info_warehouse;";
            cmd = new MySqlCommand(warehouseInfoHeadQuery, conn);

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
            string warehouseInfoHeadQuery = "SELECT * FROM info_warehouse WHERE ware_name LIKE '" + txtWareName.Text +
                                          "' OR ware_type LIKE '" + cbWareType.SelectedItem + "' OR ware_no LIKE '" +
                                          cbWareNo.SelectedItem + "' OR ware_use LIKE '" + cbWareUse.Text +"';";

            cmd = new MySqlCommand(warehouseInfoHeadQuery, conn);

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
            info_3_2_inputware newform = new info_3_2_inputware();
            newform.Show();
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
                    int wn = Convert.ToInt32(gridManageInputHead.Rows[i].Cells["ware_no"].Value);
                    string delete_query = "DELETE FROM info_warehouse WHERE ware_no = @WARE_NO;";
                    cmd = new MySqlCommand(delete_query, conn);
                    cmd.Parameters.AddWithValue("@WARE_NO", wn);
                    cmd.ExecuteNonQuery();
                }
                i++;
            }
            conn.Close();
            MessageBox.Show("삭제완료");
            renew();
        }

        private void gridManageInputHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var ware_no = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);
            DataTable dtBody = new DataTable();
            conn.Open();

            string warehouseInfoBodyQuery = "SELECT * FROM info_warehouse WHERE ware_no=@WARE_NO;";
            cmd = new MySqlCommand(warehouseInfoBodyQuery, conn);
            cmd.Parameters.AddWithValue("@WARE_NO", ware_no);
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

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string[] updateDatas = new string[4] { txt_ware_name.Text, txt_ware_type.Text, txt_ware_use.Text, txt_ware_etc.Text};
            var ware_no = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);


            string UpdateQuery = "UPDATE info_warehouse SET ware_name=@WARE_NAME, ware_type=@WARE_TYPE, ware_use=@WARE_USE, ware_etc=@WARE_ETC WHERE ware_no=@WARE_NO;";
            cmd = new MySqlCommand(UpdateQuery, conn);
            cmd.Parameters.AddWithValue("@WARE_NAME", updateDatas[0]);
            cmd.Parameters.AddWithValue("@WARE_TYPE", updateDatas[1]);
            cmd.Parameters.AddWithValue("@WARE_USE", updateDatas[2]);
            cmd.Parameters.AddWithValue("@WARE_ETC", updateDatas[3]);
            cmd.Parameters.AddWithValue("@WARE_NO", ware_no);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Update Error 발생.");
            }
            conn.Close();

            btnSelect_Click(sender, e);
        }

    }
}
