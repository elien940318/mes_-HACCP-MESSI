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
using System.Windows.Forms.DataVisualization.Charting;

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

            Label[] lbllist = new Label[4]{ lblInputCount, lblOrderCount, lblRateCount, lblOutputCount};



            #region Graph

                #region ColumnChart: 생산량
                conn.Open();
            // 주석 부분
            /*string getProductionCapacityQuery =
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
               "           (SELECT A.N + 5*(B.N + 5*(C.N + 5*(D.N + 5*(E.N)))) AS seq " +
               "           FROM    (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS A " +
               "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS B " +
               "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS C " +
               "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS D " +
               "                   JOIN (SELECT 0 AS N UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4) AS E )" +
               "           AS seq " +
               "       WHERE seq.seq <= 14 ORDER BY sequential_day) " +
               "       as tmp2 " +
               "ON tmp1.day = tmp2.sequential_day " +
               "ORDER BY tmp2.sequential_day ASC ";*/

            string getProductionCapacityQuery = "SELECT DATE_FORMAT(prodrecod_date, '%y-%m-%d') AS 'date', sum(prodrecod_good) AS 'prodrecod_good', sum(prodrecod_err) AS 'prodrecod_err' FROM production_prodrecod GROUP BY date ORDER BY date ASC;";

            cmd = new MySqlCommand(getProductionCapacityQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            chartProductionCapacity.DataSource = data;

            chartProductionCapacity.Series[0].XValueMember = "date";
            chartProductionCapacity.Series[0].YValueMembers = "prodrecod_good";
            chartProductionCapacity.Series[1].YValueMembers = "prodrecod_err";
            chartProductionCapacity.Series[0].LegendText = "생산량";
            chartProductionCapacity.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 1;
            chartProductionCapacity.DataBind();




            //주석
            /* Series s = chartProductionCapacity.Series[0];
            s.XValueMember = "sequential_day";
            s.XValueType = ChartValueType.DateTime;
            s.YValueMembers = "capacity";

            chartProductionCapacity.DataSource = dt;
            chartProductionCapacity.DataBind();

            Axis ax = chartProductionCapacity.ChartAreas[0].AxisX;
            ax.LabelStyle.Format = "DD";
            ax.IntervalType = DateTimeIntervalType.Days;
            ax.Interval = 1;*/

            conn.Close();
            #endregion

            #region PieChart: 생산률

            conn.Open();
            // 오늘 기준 한달전까지의 총 양품수량 / 총 불량품 수량 가져옵니다...
            string getProductionRateQuery =
                "SELECT SUM(prodrecod_good), SUM(prodrecod_err) FROM production_prodrecod " +
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

            #endregion
        }

    }
}
