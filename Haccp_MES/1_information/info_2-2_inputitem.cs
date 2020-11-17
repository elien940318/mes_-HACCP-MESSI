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
    public partial class info_2_2_inputitem : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        public info_2_2_inputitem()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void info_2_2_inputitem_Load(object sender, EventArgs e)
        {
            gridInsertProductInput.Rows.Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridInsertProductInput.Rows.Count; i++)
            {
                gridInsertProductInput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (gridInsertProductInput.Rows[i].Selected == true)
                {
                    gridInsertProductInput.Rows.Remove(gridInsertProductInput.Rows[i]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool shit = true;
            conn.Open();
            for (int i = 0; i < gridInsertProductInput.Rows.Count; i++)
            {

                if (gridInsertProductInput.Rows[i].Cells["mat_name"].Value != null && gridInsertProductInput.Rows[i].Cells["mat_type"].Value != null)
                {
                    string input_query = "INSERT INTO info_material (mat_name, mat_type, mat_spec, mat_price, mat_etc) VALUES (@MAT_NAME, @MAT_TYPE, @MAT_SPEC, @MAT_PRICE, @MAT_ETC);";

                    cmd = new MySqlCommand(input_query, conn);

                    cmd.Parameters.AddWithValue("@MAT_NAME", gridInsertProductInput.Rows[i].Cells["mat_name"].Value.ToString());
                    cmd.Parameters.AddWithValue("@MAT_TYPE", gridInsertProductInput.Rows[i].Cells["mat_type"].Value.ToString());

                    if (gridInsertProductInput.Rows[i].Cells["mat_spec"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@MAT_SPEC", gridInsertProductInput.Rows[i].Cells["mat_spec"].Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MAT_SPEC", "");
                    }

                    if (gridInsertProductInput.Rows[i].Cells["mat_price"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@MAT_PRICE", Convert.ToInt32(gridInsertProductInput.Rows[i].Cells["mat_price"].Value));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MAT_PRICE", "0");
                    }

                    if (gridInsertProductInput.Rows[i].Cells["mat_etc"].Value != null)
                    {
                        cmd.Parameters.AddWithValue("@MAT_ETC", gridInsertProductInput.Rows[i].Cells["mat_etc"].Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MAT_ETC", "");
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
            gridInsertProductInput.Rows.Clear();
            conn.Close();


        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridInsertProductInput.Rows.Add();
        }
    }
}
