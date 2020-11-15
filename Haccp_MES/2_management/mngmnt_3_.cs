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
    public partial class mngmnt_1_inputProduct : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public mngmnt_1_inputProduct()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dtHead = new DataTable();

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            conn.Open();
            dtHead.Clear();
            string orderInfoHeadQuery = "SELECT input_idx, DATE_FORMAT(input_date, '%Y-%m-%d') as 'input_date', com_name, mat_name,  mat_price * input_count as 'input_totprc', input_admin " +
                "FROM manage_input, info_material, info_warehouse, info_company " +
                "WHERE manage_input.mat_no = info_material.mat_no AND manage_input.ware_no = info_warehouse.ware_no AND info_company.com_no = info_material.com_no " + 
                "AND input_date BETWEEN @DATETIME1 AND @DATETIME2 " +
                "ORDER BY input_idx;";
            cmd = new MySqlCommand(orderInfoHeadQuery, conn);

            // 날짜 포맷팅이 안먹히는듯... 
            // 11월 30일로 설정하면 11월 30일 오전 00시 00분까지 컷팅되므로 11월 30일 오전 11시 정보는 read 불가함...
            // 이부분 처리해야함 ... !!! 
            cmd.Parameters.AddWithValue("@DATETIME1", dtPicker1.Value.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@DATETIME2", dtPicker2.Value.Date.ToString("yyyy-MM-dd"));
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            mngmnt_1_1_insertData dlg = new mngmnt_1_1_insertData();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                btnSelect_Click(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string[] updateDatas = new string[4] {txt_input_inspec.Text, txt_input_count.Text, txt_input_admin.Text, txt_input_etc.Text};
            var input_idx = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);

            // 수정 사항 중, 수량값이 변화히면? -> 그에 따라 input_totprc 값도 변화해야한다.
            // 하지만, totprc의 값은 컬럼으로 저장되지 않고 가져올때 계산하여 값을 반환하므로 추가적인 수정은 필요없으므로 쿼리로 처리한다.

            string UpdateQuery = "UPDATE manage_input " + 
                "SET input_inspec=@INPUT_INSPEC, input_count=@INPUT_COUNT, input_admin=@INPUT_ADMIN, input_etc=@INPUT_ETC " + 
                "WHERE input_idx=@INPUT_IDX;";
            cmd = new MySqlCommand(UpdateQuery, conn);
            cmd.Parameters.AddWithValue("@INPUT_INSPEC", updateDatas[0]);
            cmd.Parameters.AddWithValue("@INPUT_COUNT", Convert.ToInt32(updateDatas[1]));
            cmd.Parameters.AddWithValue("@INPUT_ADMIN", updateDatas[2]);
            cmd.Parameters.AddWithValue("@INPUT_ETC", updateDatas[3]);
            cmd.Parameters.AddWithValue("@INPUT_IDX", input_idx);

            if(cmd.ExecuteNonQuery() == 0) 
            {
                MessageBox.Show("Update Error 발생.");
            }
            conn.Close();

            btnSelect_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drRow in gridManageInputHead.Rows)
            {
                bool isChecked = Convert.ToBoolean(drRow.Cells[0].Value);

                if (isChecked)
                    gridManageInputHead.Rows.Remove(drRow);
            }

            foreach (DataRow drRow in dtHead.Rows)
            {
                if(drRow.RowState == DataRowState.Deleted)
                {
                    string deleteQuery = "DELETE FROM manage_input WHERE input_idx=@INPUT_IDX";
                    conn.Open();
                    cmd = new MySqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@INPUT_IDX", drRow["input_idx", DataRowVersion.Original]);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void mngmnt_1_inputProduct_Load(object sender, EventArgs e)
        {
            conn.Open();
            
            string orderInfoHeadQuery = "SELECT input_idx, DATE_FORMAT(input_date, '%Y-%m-%d') as 'input_date', com_name, mat_name,  mat_price * input_count as 'input_totprc', input_admin " + 
                "FROM manage_input, info_material, info_warehouse, info_company " + 
                "WHERE manage_input.mat_no = info_material.mat_no AND manage_input.ware_no = info_warehouse.ware_no AND info_company.com_no = info_material.com_no " + "" +
                "ORDER BY input_idx;";
            cmd = new MySqlCommand(orderInfoHeadQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageInputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageInputHead.Rows.Count.ToString();

            conn.Close();

            gridManageInputHead_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
        }


        private void gridManageInput_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);

                Point pt = e.CellBounds.Location;

                int nChkBoxWidth = 10;
                int nChkBoxHeight = 10;
                int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
                int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;

                pt.X += offsetx;
                pt.Y += offsety;

                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);
                cb.FlatStyle = FlatStyle.Flat;
                
                ((DataGridView)sender).Controls.Add(cb);
                
                e.Handled = true;
            }
        }


        private void gvSheetListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ckbox = sender as CheckBox;

            if(ckbox.CheckState == CheckState.Checked) 
            {
                for (int i = 0; i < gridManageInputHead.Rows.Count; i++)
                {
                    gridManageInputHead.Rows[i].Cells[0].Value = true;
                }
            } 
            else 
            {
                for (int i = 0; i < gridManageInputHead.Rows.Count; i++)
                {
                    gridManageInputHead.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void gridManageInputHead_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;

            view.SelectedRows[0].Cells[0].Value = !Convert.ToBoolean(view.SelectedRows[0].Cells[0].Value);
        }

        private void gridManageInputHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var input_idx = Convert.ToInt32(gridManageInputHead.CurrentRow.Cells[1].Value);
            DataTable dtBody = new DataTable();
            conn.Open();

            string orderInfoBodyQuery = "SELECT info_material.mat_no, mat_name, mat_type, mat_spec, input_inspec, mat_price, input_count,  mat_price * input_count as 'input_totprc', ware_name, input_admin,  input_etc " +
                "FROM manage_input, info_material, info_warehouse " +
                "WHERE manage_input.mat_no = info_material.mat_no AND manage_input.ware_no = info_warehouse.ware_no AND input_idx = @INPUT_IDX";
            cmd = new MySqlCommand(orderInfoBodyQuery, conn);
            cmd.Parameters.AddWithValue("@INPUT_IDX", input_idx);
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

    }
}
