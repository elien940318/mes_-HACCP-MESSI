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
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
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

            #region 차트3 테스트용
            chart3.Series[0].Points.Add(60);
            chart3.Series[0].Points.Add(10);
            chart3.Series[0].Points.Add(40);
            chart3.Series[0].Points.Add(80);
            chart3.Series[0].Points.Add(20);
            chart3.Series[0].Points.Add(30);
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
