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
    public partial class Deposit : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source = WADEY; Initial Catalog = dotnet; Integrated Security = True");
        public Deposit()
        {
            InitializeComponent();   
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //con.Open();
            int acc, bal;
            string  depos, datee;

         

            // Info 

            acc = int.Parse(txacc.Text);
            datee = txdate.Text;
            depos = txdeposit.Text;
            bal = int.Parse(txbalance.Text);
            
            

            // database Query And connection insert value to trasaction
            try
            {
                
                string st = "insert into transactionss(accno,date,deposit,balance) values('" + acc + "','" + datee + "','" + depos + "','"+bal+"')";


                SqlDataAdapter cmdinsert = new SqlDataAdapter(st, con);
                DataTable dtinsert = new DataTable();
                cmdinsert.Fill(dtinsert);

                MessageBox.Show("Deposit SuccessFull");
                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // update query to set balance after deposit 

            try
            {

                string stup = "update accounts set balance = balance + '"+ depos + "' where accno = '" + acc+"' ";
                SqlDataAdapter cmdupdate = new SqlDataAdapter(stup, con);
                DataTable dtupdate = new DataTable();
                cmdupdate.Fill(dtupdate);

                MessageBox.Show("update SuccessFull");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string str = "select * from accounts where accno = '" + txacc.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txbalance.Text = dr[4].ToString();

                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

       
    }
}
