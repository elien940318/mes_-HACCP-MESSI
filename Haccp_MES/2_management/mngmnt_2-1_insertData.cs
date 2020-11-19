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

namespace Haccp_MES._2_management
{
    public partial class mngmnt_2_1_insertData : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        
        DataTable dt;
        DataTable dtwareList;
        DataTable dtcomList;

        Dictionary<string, int> dictWarehouse;
        Dictionary<string, int> dictCompany;

        public DataGridViewRow childVal { get; set; }

        public mngmnt_2_1_insertData()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());            
            dtwareList = new DataTable();
            dtcomList = new DataTable();

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("mat_no", typeof(int)));
            dt.Columns.Add(new DataColumn("mat_name", typeof(string)));
            dt.Columns.Add(new DataColumn("mat_type", typeof(string)));
            dt.Columns.Add(new DataColumn("mat_price", typeof(int)));
            dt.Columns.Add(new DataColumn("output_count", typeof(int)));
            dt.Columns.Add(new DataColumn("ware_name", typeof(string)));
            dt.Columns.Add(new DataColumn("com_name", typeof(string)));
            dt.Columns.Add(new DataColumn("output_admin", typeof(string)));
            dt.Columns.Add(new DataColumn("output_etc", typeof(string)));
        }

        private void mngmnt_2_1_insertData_Load(object sender, EventArgs e)
        {
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridInsertManageInput.CurrentRow != null) {
                gridInsertManageInput.Rows.Remove(gridInsertManageInput.CurrentRow);
            }
        }

        private void btnLoadMaterialList_Click(object sender, EventArgs e)
        {
            mngmnt_2_2_materialList dlg = new mngmnt_2_2_materialList();
            dlg.Owner = this;

            
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                DataRow row = dt.NewRow();
                row["mat_no"] = Convert.ToInt32(childVal.Cells[0].Value);
                row["mat_name"] = Convert.ToString(childVal.Cells[1].Value);
                row["mat_type"] = Convert.ToString(childVal.Cells[2].Value);
                row["mat_price"] = Convert.ToInt32(childVal.Cells[4].Value);
                row["output_count"] = 0;
                row["ware_name"] = "";
                row["com_name"] = "";
                row["output_admin"] = MainInstance.Instance.Username;
                row["output_etc"] = "";
                dt.Rows.Add(row);

                gridInsertManageInput.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {           
                foreach (DataRow dtRow in dt.Rows)
                {
                    conn.Open();

                    string SelectQuery =
                        "SELECT * FROM manage_curmat WHERE mat_no=@MAT_NO AND ware_no=@WARE_NO;";

                    cmd = new MySqlCommand(SelectQuery, conn);
                    cmd.Parameters.AddWithValue("@MAT_NO",          Convert.ToInt32(dtRow["mat_no"]));
                    cmd.Parameters.AddWithValue("@WARE_NO",         dictWarehouse[Convert.ToString(dtRow["ware_name"])]);

                    DataTable temp = new DataTable();
                    adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(temp);


                    // 해당하는 제품이 해당하는 창고 내에 존재하는지?
                    if (temp.Rows.Count == 0) // 존재하지 않음
                        MessageBox.Show("해당 제품이 창고에 존재하지 않습니다!!!");
                    else // 존재함
                    {
                        string UpdateQuery =
                            "INSERT INTO manage_output(mat_no, output_count, ware_no, output_admin, com_no, output_etc) " +
                            "SELECT @MAT_NO, @OUTPUT_COUNT, @WARE_NO, @OUTPUT_ADMIN, @COM_NO, @OUTPUT_ETC " + 
                            "FROM DUAL " +
                            "WHERE EXISTS (SELECT * FROM manage_curmat WHERE mat_no=@MAT_NO AND ware_no=@WARE_NO AND curmat_count >= @OUTPUT_COUNT)";

                        cmd = new MySqlCommand(UpdateQuery, conn);
                        cmd.Parameters.AddWithValue("@MAT_NO", Convert.ToInt32(dtRow["mat_no"]));
                        cmd.Parameters.AddWithValue("@OUTPUT_COUNT", Convert.ToInt32(dtRow["output_count"]));
                        cmd.Parameters.AddWithValue("@OUTPUT_ADMIN", Convert.ToString(dtRow["output_admin"]));
                        cmd.Parameters.AddWithValue("@WARE_NO", dictWarehouse[Convert.ToString(dtRow["ware_name"])]);
                        cmd.Parameters.AddWithValue("@COM_NO",  dictCompany[Convert.ToString(dtRow["com_name"])]);
                        cmd.Parameters.AddWithValue("@OUTPUT_ETC", Convert.ToString(dtRow["output_etc"]));

                        // 제품의 수량이 충분한지?
                        if(cmd.ExecuteNonQuery() == 0) // 충분하지 않음
                            MessageBox.Show("해당 제품의 수량이 부족합니다!!!");
                        else // 충분함 -> 수량만큼 제품 차감해야함
                        {   
                            string UpdateCurmatQuery =
                                "UPDATE manage_curmat SET curmat_count = curmat_count - @OUTPUT_COUNT " +
                                "WHERE ware_no = @WARE_NO AND mat_no = @MAT_NO;";
                            cmd = new MySqlCommand(UpdateCurmatQuery, conn);
                            cmd.Parameters.AddWithValue("@OUTPUT_COUNT", Convert.ToInt32(dtRow["output_count"]));
                            cmd.Parameters.AddWithValue("@WARE_NO", dictWarehouse[Convert.ToString(dtRow["ware_name"])]);
                            cmd.Parameters.AddWithValue("@MAT_NO", Convert.ToInt32(dtRow["mat_no"]));
                            // 해당 창고에 제품 수량 차감
                            cmd.ExecuteNonQuery();
                        }
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
