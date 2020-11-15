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
    public partial class info_1_1_accountmng : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public info_1_1_accountmng()
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
            string fillCombo = "SELECT * FROM info_company;";
            cmd = new MySqlCommand(fillCombo, conn);
            MySqlDataReader myreader;
            try
            {
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string cno = myreader.GetString("com_no");
                    cbComNo.Items.Add(cno);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        void fillcombo1()
        {
            conn.Open();
            string fillcombo = "SELECT * FROM info_company GROUP BY com_type;";
            cmd = new MySqlCommand(fillcombo, conn);
            MySqlDataReader myreader;
            try
            {
                myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string ctype = myreader.GetString("com_type");
                    cbComType.Items.Add(ctype);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }


        //신규 버튼 누르면 창띄우기
        private void btnInsert_Click(object sender, EventArgs e)
        {
            info_1_2_inputacnt newForm = new info_1_2_inputacnt();
            newForm.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string companyInfoHeadQuery = "SELECT * FROM info_company;";
            cmd = new MySqlCommand(companyInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }

        private void info_1_1_accountmng_Load(object sender, EventArgs e)
        {
            conn.Open();
            string companyInfoHeadQuery = "SELECT * FROM info_company;";
            cmd = new MySqlCommand(companyInfoHeadQuery, conn);

            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();

            if (gridManageInputHead.Rows.Count != 0)
                gridManageInputHead_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string companyInfoHeadQuery = "SELECT * FROM info_company WHERE com_name LIKE '" + txtComName.Text +
                                          "' OR com_type LIKE '" + cbComType.SelectedItem + "' OR com_no LIKE '" +
                                          cbComNo.SelectedItem + "';";
            cmd = new MySqlCommand(companyInfoHeadQuery, conn);

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



        private void gridManageInputHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var com_no = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);
            DataTable dtBody = new DataTable();
            conn.Open();

            string companyInfoBodyQuery = "SELECT * FROM info_company WHERE com_no=@COM_NO;";
            cmd = new MySqlCommand(companyInfoBodyQuery, conn);
            cmd.Parameters.AddWithValue("@COM_NO", com_no);
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
            string[] updateDatas = new string[3] { txtcom_type.Text, txtcom_phone.Text, txtcom_rep_name.Text };
            var com_no = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);


            string UpdateQuery = "UPDATE info_company SET com_type=@COM_TYPE, com_phoneno=@COM_PHONE, com_rep_name=@COM_REP_NAME WHERE com_no=@COM_NO;";
            cmd = new MySqlCommand(UpdateQuery, conn);
            cmd.Parameters.AddWithValue("@COM_TYPE", updateDatas[0]);
            cmd.Parameters.AddWithValue("@COM_PHONE", updateDatas[1]);
            cmd.Parameters.AddWithValue("@COM_REP_NAME", updateDatas[2]);
            cmd.Parameters.AddWithValue("@COM_NO", com_no);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Update Error 발생.");
            }
            conn.Close();

            btnSelect_Click(sender, e);
        }
    }
}
