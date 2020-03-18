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

namespace login
{
    public partial class Main : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source = WADEY; Initial Catalog = dotnet; Integrated Security = True");


        public Main()
        {
            InitializeComponent();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            Withdraw with = new Withdraw();
            with.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string queryup = ("update admins set status = '0' where status = '1' ");
            SqlDataAdapter exit = new SqlDataAdapter(queryup, conn);
            DataTable dtexit = new DataTable();
            exit.Fill(dtexit);
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            accountcreation acc = new accountcreation();
            acc.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            accountcreation acc = new accountcreation();
            acc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Deposit dp = new Deposit();
            dp.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            transfer tr = new transfer();
            tr.Show();
        }
    }
}
