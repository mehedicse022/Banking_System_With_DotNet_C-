using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace login
{
    public partial class Form1 : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source = WADEY; Initial Catalog = dotnet; Integrated Security = True");
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = ("select * from admins where username='"+textBox1.Text +"' and password ='"+textBox2.Text+"' ");
            SqlDataAdapter log = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            log.Fill(dt);
            if (dt.Rows.Count == 1 )
            {
                string queryuplogin = ("update admins set status='1' where status = '0' and username='" + textBox1.Text + "' ");
                SqlDataAdapter upd = new SqlDataAdapter(queryuplogin, conn);
                DataTable dtup = new DataTable();
                upd.Fill(dtup);
                this.Hide();
                Main mainpage = new Main();
                mainpage.Show();

            }
            else
            {
                MessageBox.Show("Please Check Your UserName and Password ");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            try
            {
                if (username.Text != " " && password.Text != " ")
                {
                    if (Regex.IsMatch(email.Text, pattern))
                    {

                        SqlDataAdapter reg = new SqlDataAdapter(@"insert into admins(username,email,password)
                        values ('" + username.Text + "','" + email.Text + "','" + password.Text + "') ", conn);
                        DataTable dtl = new DataTable();
                        reg.Fill(dtl);
                        MessageBox.Show("Successfully  Register");
                       
                    }
                    else
                    {
                        MessageBox.Show("Please Input Valied  Email");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UserName or Email or Password Invalid");
            }

        }
    }
}
