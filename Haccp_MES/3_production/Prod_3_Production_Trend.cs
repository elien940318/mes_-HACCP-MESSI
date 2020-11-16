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

namespace Haccp_MES._3_production
{
    public partial class Prod_3_Production_Trend : Form
    {
        public Prod_3_Production_Trend()
        {
            InitializeComponent();
        }

        private void Prod_3_Production_Trend_Load(object sender, EventArgs e)
        {
            string constring = "datasource=175.200.94.253;port=3306;Database=mes;username=messi;password=haccp";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand("select * from database.production_prodrecod", conDataBase);
            MySqlDataReader myReader;

            myReader = cmdDataBase.ExecuteReader();

            chart1.Series["기간별 생산 현황"].XValueMember = "날짜";
            chart1.Series["기간별 생산 현황"].YValueMembers = "생산량";

            chart1.Series["기간별 생산 현황"].LegendText = "양품";
            chart1.Series["기간별 생산 현황"].LegendText = "불량품";

            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;

            chart1.DataBind();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
        }
    }
}
