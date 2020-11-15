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
    public partial class info_2_itemMng : Form
    {
        public info_2_itemMng()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            info_2_2_inputitem info = new info_2_2_inputitem();
            info.ShowDialog();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            info_2_2_inputitem newForm = new info_2_2_inputitem();
            newForm.Show();
        }
    }
}
