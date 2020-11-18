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

            #region ColumnChart: 생산량
            conn.Open();
            string getProductionCapacityQuery =
                "SELECT tmp2.sequential_day, " +
                "       CASE WHEN tmp1.capacity IS NULL " +
                "       THEN '0' " +
                "       ELSE tmp1.capacity END " +
                "       AS capacity " + 
                "FROM " +
                "       (SELECT DATE_FORMAT(mngodr_date, '%Y-%m-%d') AS 'day', " +
                "               SUM(mngodr_count) as 'capacity' FROM production_mngodr GROUP BY day ORDER BY day) " +
                "       as tmp1 " +
                "       RIGHT JOIN " +
                "       (SELECT DATE_FORMAT(NOW() - INTERVAL seq.seq DAY, '%Y-%m-%d') AS sequential_day " +
                "       FROM " +
                "           (SELECT A.N + 5*(B.N + 5*(C.N + 5*(D.N + 5*(E.N + 5*(F.N))))) AS seq " +
                "           FROM    (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS A " +
                "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS B " +
                "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS C " +
                "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS D " +
                "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS E " +
                "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS F )" +
                "           AS seq " +
                "       WHERE seq.seq <= 30 ORDER BY sequential_day) " +
                "       as tmp2 " +
                "ON tmp1.day = tmp2.sequential_day " +
                "ORDER BY tmp2.sequential_day ASC ";

            cmd = new MySqlCommand(getProductionCapacityQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow drRow in dt.Rows)
            {
                chart1.Series[0].Points.Add(Convert.ToInt32(drRow[1]));
            }

            conn.Close();
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
            
            dt = new DataTable();
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
