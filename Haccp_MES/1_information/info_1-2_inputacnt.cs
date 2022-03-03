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

//
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

            bool shit = true;
            conn.Open();
            for (int i = 0; i < gridInsertMangeInput.Rows.Count; i++)
            {

                if (gridInsertMangeInput.Rows[i].Cells["com_type"].Value != null && gridInsertMangeInput.Rows[i].Cells["com_name"].Value != null)
                {
                    string input_query = "INSERT INTO info_company (com_type, com_name, com_licenseno, com_phoneno, com_rep_name) VALUES (@COM_TYPE, @COM_NAME, @COM_LICENSENO, @COM_PHONENO, @COM_REP_NAME);";

                    cmd = new MySqlCommand(input_query, conn);

                    cmd.Parameters.AddWithValue("@COM_TYPE", gridInsertMangeInput.Rows[i].Cells["com_type"].Value.ToString());
                    cmd.Parameters.AddWithValue("@COM_NAME", gridInsertMangeInput.Rows[i].Cells["com_name"].Value.ToString());

                    if (gridInsertMangeInput.Rows[i].Cells["com_licenseno"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@COM_LICENSENO", gridInsertMangeInput.Rows[i].Cells["com_licenseno"].Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@COM_LICENSENO", "");
                    }

                    if (gridInsertMangeInput.Rows[i].Cells["com_phoneno"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@COM_PHONENO", Convert.ToString(gridInsertMangeInput.Rows[i].Cells["com_phoneno"].Value));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@COM_PHONENO", "0");
                    }

                    if (gridInsertMangeInput.Rows[i].Cells["com_rep_name"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@COM_REP_NAME", gridInsertMangeInput.Rows[i].Cells["com_rep_name"].Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@COM_REP_NAME", "");
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
            gridInsertMangeInput.Rows.Clear();
            conn.Close();


        }

        private void info_1_2_inputacnt_Load(object sender, EventArgs e)
        {

        }
    }
}
