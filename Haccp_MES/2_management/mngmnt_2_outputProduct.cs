using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haccp_MES._2_management
{
    public partial class mngmnt_2_outputProduct : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dtHead;

        public mngmnt_2_outputProduct()
        {
            InitializeComponent();
            
            dtHead = new DataTable();

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {                        
            conn.Open();
            dtHead.Clear();
            string orderInfoHeadQuery = "SELECT output_idx, DATE_FORMAT(output_date, '%Y-%m-%d') as 'output_date', com_name, mat_name,  mat_price * output_count as 'output_totprc', output_admin " +
                "FROM manage_output, info_material, info_warehouse, info_company " +
                "WHERE manage_output.mat_no = info_material.mat_no AND manage_output.ware_no = info_warehouse.ware_no AND info_company.com_no = info_material.com_no " + 
                "AND output_date BETWEEN @DATETIME1 AND @DATETIME2 " +
                "ORDER BY output_idx;";
            cmd = new MySqlCommand(orderInfoHeadQuery, conn);

            cmd.Parameters.AddWithValue("@DATETIME1", dtPicker1.Value.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@DATETIME2", dtPicker2.Value.AddDays(1).ToString("yyyy-MM-dd"));
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtHead);

            gridManageoutputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageoutputHead.Rows.Count.ToString();

            conn.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //mngmnt_2_1_insertData dlg = new mngmnt_2_1_insertData();

            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    btnSelect_Click(sender, e);
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string[] updateDatas = new string[3] { txt_output_count.Text, txt_output_admin.Text, txt_output_etc.Text };
            var output_idx = Convert.ToInt32(gridManageoutputHead.CurrentRow.Cells[1].Value);

            // 수정 사항 중, 수량값이 변화히면? -> 그에 따라 output_totprc 값도 변화해야한다.
            // 하지만, totprc의 값은 컬럼으로 저장되지 않고 가져올때 계산하여 값을 반환하므로 추가적인 수정은 필요없으므로 쿼리로 처리한다.

            string UpdateQuery =
                "UPDATE manage_curmat SET curmat_count = curmat_count - (SELECT output_count FROM manage_output WHERE output_idx=@OUTPUT_IDX) + @OUTPUT_COUNT " +
                "WHERE ware_no = (SELECT ware_no FROM manage_output WHERE output_idx=@OUTPUT_IDX) AND mat_no = (SELECT mat_no FROM manage_output WHERE output_idx=@OUTPUT_IDX); " +
                "UPDATE manage_output " +
                "SET output_count=@output_COUNT, output_admin=@output_ADMIN, output_etc=@output_ETC " +
                "WHERE output_idx=@output_IDX;";
            cmd = new MySqlCommand(UpdateQuery, conn);
            cmd.Parameters.AddWithValue("@OUTPUT_COUNT", Convert.ToInt32(updateDatas[0]));
            cmd.Parameters.AddWithValue("@OUTPUT_ADMIN", updateDatas[1]);
            cmd.Parameters.AddWithValue("@OUTPUT_ETC", updateDatas[2]);
            cmd.Parameters.AddWithValue("@OUTPUT_IDX", output_idx);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Update Error 발생.");
            }
            conn.Close();

            btnSelect_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drRow in gridManageoutputHead.Rows)
            {
                bool isChecked = Convert.ToBoolean(drRow.Cells[0].Value);

                if (isChecked)
                    gridManageoutputHead.Rows.Remove(drRow);
            }

            foreach (DataRow drRow in dtHead.Rows)
            {
                if(drRow.RowState == DataRowState.Deleted)
                {
                    string deleteQuery = "DELETE FROM manage_output WHERE output_idx=@output_IDX";
                    conn.Open();
                    cmd = new MySqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@output_IDX", drRow["output_idx", DataRowVersion.Original]);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void mngmnt_2_outputProduct_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(() => {
                conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
                conn.Open();

                string orderInfoHeadQuery = "SELECT output_idx, DATE_FORMAT(output_date, '%Y-%m-%d') as 'output_date', com_name, mat_name,  mat_price * output_count as 'output_totprc', output_admin " +
                    "FROM manage_output, info_material, info_warehouse, info_company " +
                    "WHERE manage_output.mat_no = info_material.mat_no AND manage_output.ware_no = info_warehouse.ware_no AND info_company.com_no = manage_output.com_no " + "" +
                    "ORDER BY output_idx;";
                cmd = new MySqlCommand(orderInfoHeadQuery, conn);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dtHead);

                conn.Close();
            });
            t.Start();

            gridManageoutputHead.DataSource = dtHead;
            lblHeadCount.Text = gridManageoutputHead.Rows.Count.ToString();

            t.Join();

            if (gridManageoutputHead.Rows.Count != 0)
                gridManageoutputHead_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
        }


        private void gridManageoutput_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                for (int i = 0; i < gridManageoutputHead.Rows.Count; i++)
                {
                    gridManageoutputHead.Rows[i].Cells[0].Value = true;
                }
            } 
            else 
            {
                for (int i = 0; i < gridManageoutputHead.Rows.Count; i++)
                {
                    gridManageoutputHead.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void gridManageoutputHead_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;

            view.SelectedRows[0].Cells[0].Value = !Convert.ToBoolean(view.SelectedRows[0].Cells[0].Value);
        }

        private void gridManageoutputHead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var output_idx = Convert.ToInt32(gridManageoutputHead.CurrentRow.Cells[1].Value);
            DataTable dtBody = new DataTable();
            conn.Open();

            string orderInfoBodyQuery = "SELECT info_material.mat_no, mat_name, mat_type, mat_spec, mat_price, output_count,  mat_price * output_count as 'output_totprc', ware_name, output_admin,  output_etc " +
                "FROM manage_output, info_material, info_warehouse " +
                "WHERE manage_output.mat_no = info_material.mat_no AND manage_output.ware_no = info_warehouse.ware_no AND output_idx = @output_IDX";
            cmd = new MySqlCommand(orderInfoBodyQuery, conn);
            cmd.Parameters.AddWithValue("@output_IDX", output_idx);
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
