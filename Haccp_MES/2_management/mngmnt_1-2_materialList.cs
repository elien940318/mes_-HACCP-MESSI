using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haccp_MES._2_management
{
    public partial class mngmnt_1_2_materialList : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;


        public mngmnt_1_2_materialList()
        {
            InitializeComponent();
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dt = new DataTable();
        }

        private void mngmnt_1_2_materialList_Load(object sender, EventArgs e)
        {
            conn.Open();

            string orderInfoHeadQuery = "SELECT mat_no, mat_name, mat_type, mat_spec, mat_price, mat_etc " + "" +
                "FROM info_material " + 
                "WHERE NOT mat_type IN ('제품');";
            cmd = new MySqlCommand(orderInfoHeadQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);

            gridSelectInfoMaterial.DataSource = dt;
            conn.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void gridSelectInfoMaterial_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridSelectInfoMaterial.CurrentRow != null)
            {
                ((mngmnt_1_1_insertData)(this.Owner)).childVal = gridSelectInfoMaterial.CurrentRow;
                this.DialogResult = DialogResult.OK;
            }
            else
                this.DialogResult = DialogResult.Cancel;
            
            this.Close();
        }
    }
}
