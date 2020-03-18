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
    public partial class transfer : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = WADEY; Initial Catalog = dotnet; Integrated Security = True");
        public transfer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int facc, tacc, amount;
            string tdate;

            facc = int.Parse(fracc.Text);
            tacc = int.Parse(toacc.Text);
            amount = int.Parse(tramount.Text);
            tdate = trdate.Text;

            // database Query , insert value to transfer Table
            try
            {

                string st = "insert into transfer(f_acc,to_acc,dates,amount) values('" + facc + "','" + tacc + "','" + tdate + "','" + amount + "')";

                SqlDataAdapter cmdtrinsert = new SqlDataAdapter(st, con);
                DataTable dttrinsert = new DataTable();
                cmdtrinsert.Fill(dttrinsert);

                MessageBox.Show("Transfer SuccessFull");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // update query to decrease from account table

            try
            {

                string stup = "update accounts set balance = balance - '" + amount + "' where accno = '" + facc + "' ";
                SqlDataAdapter fromupdate = new SqlDataAdapter(stup, con);
                DataTable frdt = new DataTable();
                fromupdate.Fill(frdt);

                MessageBox.Show("From Account Table Updated");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // update query to increase To account table

            try
            {

                string stup = "update accounts set balance = balance + '" + amount + "' where accno = '" + tacc + "' ";
                SqlDataAdapter toupdate = new SqlDataAdapter(stup, con);
                DataTable todt = new DataTable();
                toupdate.Fill(todt);

                MessageBox.Show(" To Account Table Updated");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
