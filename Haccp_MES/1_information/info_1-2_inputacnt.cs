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
    public partial class info_1_2_inputacnt : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        public info_1_2_inputacnt()
        {
            InitializeComponent();
            gridInsertMangeInput.Rows.Add();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridInsertMangeInput.Rows.Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridInsertMangeInput.Rows.Count; i++)
            {
                gridInsertMangeInput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (gridInsertMangeInput.Rows[i].Selected == true)
                {
                    gridInsertMangeInput.Rows.Remove(gridInsertMangeInput.Rows[i]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            conn.Open();
            for (int i = 0; i < gridInsertMangeInput.Rows.Count; i++)
              {
                
                string input_query = "INSERT INTO info_company (com_type, com_name, com_licenseno, com_phoneno, com_rep_name) VALUES ('" + gridInsertMangeInput.Rows[i].Cells["com_type"].Value + "','" + gridInsertMangeInput.Rows[i].Cells["com_name"].Value + "','"
                                    + gridInsertMangeInput.Rows[i].Cells["com_licenseno"].Value + "','" + gridInsertMangeInput.Rows[i].Cells["com_phoneno"].Value + "','" + gridInsertMangeInput.Rows[i].Cells["com_rep_name"].Value + "');";
                cmd = new MySqlCommand(input_query, conn);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("저장완료,");
            gridInsertMangeInput.Rows.Clear();
            conn.Close();


        }
    }
}
