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

namespace Haccp_MES
{
    public partial class Home : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;

        public Home()
        {
            InitializeComponent();
        }
        //문혁 테스트
        private void Home_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dt = new DataTable();
            #region 차트1 테스용
            chart1.Series[0].Points.Add(110);
            chart1.Series[0].Points.Add(30);
            chart1.Series[0].Points.Add(80);
            chart1.Series[0].Points.Add(160);
            chart1.Series[0].Points.Add(50);
            chart1.Series[0].Points.Add(48);
            chart1.Series[0].Points.Add(68);
            chart1.Series[0].Points.Add(99);
            chart1.Series[0].Points.Add(36);
            #endregion

            #region 차트2 테스용
            chart2.Series[0].Points.Add(10);
            chart2.Series[0].Points.Add(80);
            chart2.Series[0].Points.Add(30);
            chart2.Series[0].Points.Add(60);
            chart2.Series[0].Points.Add(100);
            chart2.Series[0].Points.Add(20);
            chart2.Series[0].Points.Add(70);
            chart2.Series[0].Points.Add(10);
            chart2.Series[0].Points.Add(40);
            #endregion

            #region PieChart: 생산률

            conn.Open();
            // 오늘 기준 한달전까지의 총 양품수량 / 총 불량품 수량 가져옵니다...
            string getProductionRateQuery = 
                "SELECT COUNT(prodrecod_good), COUNT(prodrecod_err) FROM production_prodrecod " +
                "WHERE prodrecod_date BETWEEN DATE_ADD(NOW(), INTERVAL-1 MONTH) AND NOW();";
            cmd = new MySqlCommand(getProductionRateQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            dt.Clear();
            adapter.Fill(dt);
            conn.Close();

            chartProductionRate.Series[0].Points.AddXY("양품", Convert.ToInt32(dt.Rows[0][0]));
            chartProductionRate.Series[0].Points[0].Color = Color.SkyBlue;
            chartProductionRate.Series[0].Points[0].IsValueShownAsLabel = false;
            chartProductionRate.Series[0].Points.AddXY("불량품", Convert.ToInt32(dt.Rows[0][1]));
            chartProductionRate.Series[0].Points[1].Color = Color.OrangeRed;
            chartProductionRate.Series[0].Points[0].IsValueShownAsLabel = false;
            chartProductionRate.Series[0].IsValueShownAsLabel = false;

            #endregion

            #region 차트4 테스용
            chart4.Series[0].Points.Add(60);
            chart4.Series[0].Points.Add(62);
            chart4.Series[0].Points.Add(76);
            chart4.Series[0].Points.Add(70);
            chart4.Series[0].Points.Add(30);
            chart4.Series[0].Points.Add(60);
            chart4.Series[0].Points.Add(50);
            chart4.Series[0].Points.Add(40);
            chart4.Series[0].Points.Add(20);
            #endregion

        }
    }
}
