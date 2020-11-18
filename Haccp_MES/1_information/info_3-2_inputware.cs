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
            conn.Open();
            for (int i = 0; i < gridInsertWarehouseInput.Rows.Count; i++)
            {

                string input_query = "INSERT INTO info_warehouse (ware_name, ware_type, ware_use, ware_etc) VALUES ('" + gridInsertWarehouseInput.Rows[i].Cells["ware_name"].Value + "','" + gridInsertWarehouseInput.Rows[i].Cells["ware_type"].Value + "','"
                                    + gridInsertWarehouseInput.Rows[i].Cells["ware_use"].Value + "','" + gridInsertWarehouseInput.Rows[i].Cells["ware_etc"].Value  + "');";
                cmd = new MySqlCommand(input_query, conn);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("저장완료");
            gridInsertWarehouseInput.Rows.Clear();
            conn.Close();
        }
    }
}
