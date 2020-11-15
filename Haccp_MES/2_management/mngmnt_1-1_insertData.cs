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
using Haccp_MES;
using System.Threading;

namespace Haccp_MES._2_management
{
    public partial class mngmnt_1_1_insertData : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        DataTable dtwareList;
        DataTable dtcomList;

        Dictionary<string, int> dictCompany;
        Dictionary<string, int> dictWarehouse;

        public DataGridViewRow childVal { get; set; }

        public mngmnt_1_1_insertData()
        {
            Thread thread = new Thread(() => {
                conn = new MySqlConnection(DatabaseInfo.DBConnectStr());

                conn.Open();

                string selectWarelistQuery = "SELECT ware_name, ware_no FROM info_warehouse";
                cmd = new MySqlCommand(selectWarelistQuery, conn);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtwareList);

                dictWarehouse = dtwareList.AsEnumerable().ToDictionary<DataRow, string, int>
                    (row => Convert.ToString(row[0]), row => Convert.ToInt32(row[1]));
                col_ware_no.DataSource = dtwareList;
                col_ware_no.DisplayMember = "ware_name";
                col_ware_no.ValueMember = "ware_name";



                string selectComlistQuery = "SELECT com_name, com_no FROM info_company";
                cmd = new MySqlCommand(selectComlistQuery, conn);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtcomList);

                dictCompany = dtcomList.AsEnumerable().ToDictionary<DataRow, string, int>
                    (row => Convert.ToString(row[0]), row => Convert.ToInt32(row[1]));
                col_com_no.DataSource = dtcomList;
                col_com_no.DisplayMember = "com_name";
                col_com_no.ValueMember = "com_name";

                conn.Close();
            });

            dtwareList = new DataTable();
            dtcomList = new DataTable();

            thread.Start();
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("mat_no", typeof(int)));
            dt.Columns.Add(new DataColumn("mat_name", typeof(string)));
            dt.Columns.Add(new DataColumn("mat_type", typeof(string)));
            dt.Columns.Add(new DataColumn("mat_price", typeof(int)));
            dt.Columns.Add(new DataColumn("input_count", typeof(int)));
            dt.Columns.Add(new DataColumn("input_inspec", typeof(string)));
            dt.Columns.Add(new DataColumn("ware_name", typeof(string)));
            dt.Columns.Add(new DataColumn("com_name", typeof(string)));
            dt.Columns.Add(new DataColumn("input_admin", typeof(string)));
            dt.Columns.Add(new DataColumn("input_etc", typeof(string)));
            thread.Join();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridInsertManageInput.CurrentRow != null) {
                gridInsertManageInput.Rows.Remove(gridInsertManageInput.CurrentRow);
            }
        }

        private void btnLoadMaterialList_Click(object sender, EventArgs e)
        {
            mngmnt_1_2_materialList dlg = new mngmnt_1_2_materialList();
            dlg.Owner = this;

            
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                DataRow row = dt.NewRow();
                row["mat_no"] = Convert.ToInt32(childVal.Cells[0].Value);
                row["mat_name"] = Convert.ToString(childVal.Cells[1].Value);
                row["mat_type"] = Convert.ToString(childVal.Cells[2].Value);
                row["mat_price"] = Convert.ToInt32(childVal.Cells[4].Value);
                row["input_count"] = 0;
                row["input_inspec"] = "";
                row["ware_name"] = "";
                row["com_name"] = "";
                row["input_admin"] = "";
                row["input_etc"] = "";
                dt.Rows.Add(row);

                gridInsertManageInput.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                //((mngmnt_1_inputProduct)(this.Owner)).InsertValues = dt;                
                foreach (DataRow dtRow in dt.Rows)
                {
                    conn.Open();
                    string InsertQuery =
                        "INSERT INTO manage_input(input_date, mat_no, input_count, input_admin, input_inspec, ware_no, input_etc) " +
                        "VALUES (NOW(), @MAT_NO, @INPUT_COUNT, @INPUT_ADMIN, @INPUT_INSPEC, @WARE_NO, @INPUT_ETC);" +
                        "INSERT INTO manage_curmat VALUES(@WARE_NO, @MAT_NO, @INPUT_COUNT) ON DUPLICATE KEY UPDATE curmat_count = curmat_count + @INPUT_COUNT;";
                    cmd = new MySqlCommand(InsertQuery, conn);
                    
                    cmd.Parameters.AddWithValue("@MAT_NO",          Convert.ToInt32(dtRow["mat_no"]));
                    cmd.Parameters.AddWithValue("@INPUT_COUNT",     Convert.ToInt32(dtRow["input_count"]));
                    cmd.Parameters.AddWithValue("@INPUT_ADMIN",     Convert.ToString(dtRow["input_admin"]));
                    cmd.Parameters.AddWithValue("@INPUT_INSPEC",    Convert.ToString(dtRow["input_inspec"]));
                    cmd.Parameters.AddWithValue("@WARE_NO",         dictWarehouse[Convert.ToString(dtRow["ware_name"])]);
                    cmd.Parameters.AddWithValue("@INPUT_ETC",       Convert.ToString(dtRow["input_etc"]));

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("INSERT Error 발생.");
                    }

                    conn.Close();
                }
                

                this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
