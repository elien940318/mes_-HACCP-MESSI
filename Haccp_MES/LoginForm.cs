using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Haccp_MES
{
    // EventHandler는 밖에다가...
    public delegate void EventHandler(string userName);

    public partial class LoginForm : Form
    {
        MySqlConnection conn;
        //MySqlDataAdapter adapter;
        DataTable dt;

        //RegisterForm rgForm;

        public event EventHandler loginHandler;

        public LoginForm()
        {
            InitializeComponent();

            
            conn = new MySqlConnection(DatabaseInfo.DBConnectStr());
            dt = new DataTable();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            string loginQuery = "SELECT user_id, user_name, user_pw FROM info_user WHERE user_id=@username AND user_pw=@password";
            MySqlCommand cmd = new MySqlCommand(loginQuery, conn);

            if (inputCheck())
            {   
                cmd.Parameters.AddWithValue("@username", txtID.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                dt.Load(cmd.ExecuteReader());

                if (dt.Rows.Count == 1)
                {
                    //MessageBox.Show("로그인 성공.");
                    
                    MainInstance.Instance.ID        = (string)dt.Rows[0].ItemArray[0];
                    MainInstance.Instance.Username  = (string)dt.Rows[0].ItemArray[1];

                    DialogResult = DialogResult.OK;
                    loginHandler(MainInstance.Instance.Username);
                }
                else
                {
                    MessageBox.Show("로그인 정보가 명확하지 않습니다.");
                }
            }
            conn.Close();
        }

        public bool inputCheck()
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("아이디를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();

                return false;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("비밀번호를 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();

                return false;
            }


            return true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Dispose();
            DialogResult = DialogResult.Cancel;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //rgForm = new RegisterForm();
            //rgForm.ShowDialog();
        }
    }
}
