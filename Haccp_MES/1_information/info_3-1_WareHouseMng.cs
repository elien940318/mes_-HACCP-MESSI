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
    public partial class info_3_WareHouseMng : Form
    {
        public info_3_WareHouseMng()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            info_3_2_inputware newForm = new info_3_2_inputware();
            newForm.Show();
        }
    }
}
