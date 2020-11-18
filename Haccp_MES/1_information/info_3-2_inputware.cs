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
    public partial class info_3_2_inputware : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;


        public info_3_2_inputware()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_3_2_inputware_Load(object sender, EventArgs e)
        {
            gridInsertWarehouseInput.Rows.Add();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridInsertWarehouseInput.Rows.Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridInsertWarehouseInput.Rows.Count; i++)
            {
                gridInsertWarehouseInput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (gridInsertWarehouseInput.Rows[i].Selected == true)
                {
                    gridInsertWarehouseInput.Rows.Remove(gridInsertWarehouseInput.Rows[i]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool shit = true;
            conn.Open();
            for (int i = 0; i < gridInsertWarehouseInput.Rows.Count; i++)
            {

                if (gridInsertWarehouseInput.Rows[i].Cells["ware_name"].Value != null && gridInsertWarehouseInput.Rows[i].Cells["ware_type"].Value != null)
                {
                    string input_query = "INSERT INTO info_warehouse (ware_name, ware_type, ware_use, ware_etc) VALUES (@WARE_NAME, @WARE_TYPE, @WARE_USE, @WARE_ETC);";

                    cmd = new MySqlCommand(input_query, conn);

                    cmd.Parameters.AddWithValue("@WARE_NAME", gridInsertWarehouseInput.Rows[i].Cells["ware_name"].Value.ToString());
                    cmd.Parameters.AddWithValue("@WARE_TYPE", gridInsertWarehouseInput.Rows[i].Cells["ware_type"].Value.ToString());

                    if (gridInsertWarehouseInput.Rows[i].Cells["ware_use"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@WARE_USE", gridInsertWarehouseInput.Rows[i].Cells["ware_use"].Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@WARE_use", "");
                    }

                    if (gridInsertWarehouseInput.Rows[i].Cells["ware_etc"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@WARE_ETC", gridInsertWarehouseInput.Rows[i].Cells["ware_etc"].Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@WARE_ETC", "");
                    }

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("값을 입력해주세요!");
                    shit = false;
                    break;
                }
            }
            if (shit)
            {
                MessageBox.Show("저장완료");
            }
            gridInsertWarehouseInput.Rows.Clear();
            conn.Close();
        }
    }
}
