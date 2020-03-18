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
    public partial class accountcreation : Form
    {


        SqlConnection con = new SqlConnection(@"Data Source = WADEY; Initial Catalog = dotnet; Integrated Security = True");
        public accountcreation()
        {
            InitializeComponent();
        }

        public void custId()
        {

            /* string query = ("select max(custid) from customer ");
             SqlDataAdapter log = new SqlDataAdapter(query, conn);
             DataTable dt = new DataTable();
             log.Fill(dt);
                 if (label14.Text == " ")
                 {
                 label14.Text = "1000" ;
                 }
                 else
                 {
                    *//* string a;
                    // a = int.Parse(label14.Text.ToString());
                     a = a + 1;
                     label14.Text = a.ToString();*//*
                 }*/

        }

        private void accountcreation_Load(object sender, EventArgs e)
        {
            /* custId();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string  cuid,fname, lname, stret, citi, stat, phon, datee, emails, acctype, des, bal;
           // int accNo;

            cuid = Id.Text;
            fname = firstname.Text;
            lname = lastname.Text;
            stret = street.Text;
            citi = city.Text;
            stat = state.Text;
            phon = phone.Text;
            datee = date.Text;
            emails = email.Text;

            // Account Info 

            /*accNo = Int32.Parse(accountno.Text);
            acctype = accounttype.Text;
            des = description.Text;
            bal = balance.Text;


            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction transacrtion;
            transacrtion = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = transacrtion;

            try
            {
                cmd.CommandText = "insert into customer(custid,firstname,lastname,street,city,state,phone,date,email) values ('" + cuid + "','" + fname + "'," +
                    "'" + lname + "','" + stret + "','" + citi + "','" + stat + "','" + phon + "','" + datee + "','" + emails + "'";

                cmd.ExecuteNonQuery();


                cmd.CommandText = "insert into account(accno,custid,accountype,description,balance) values('" + accNo + "','" + cuid + "', '" + acctype + "', '" + des + "', '" + bal + "') ";
                cmd.ExecuteNonQuery();

                transacrtion.Commit();

                MessageBox.Show("Registration Successful");
            }
            catch (Exception ex)
            {
                transacrtion.Rollback();
                MessageBox.Show(ex.ToString());

            }*/
            if (cuid != " " && fname != " " && lname != " " && phon != " " && emails != " ")
            {

                SqlDataAdapter save = new SqlDataAdapter(@"insert into customer(custid,firstname,lastname,street,city,state,phone,date,email)
                         values ('" + cuid + "','" + fname + "','" + lname + "','" + stret + "','" + citi + "','" + stat + "'," +
                            "'" + phon + "','" + datee + "','" + emails + "') ", con);

                /* SqlDataAdapter saves = new SqlDataAdapter(@"insert into account(accno,accountype,description,balance)
                              values ('" + accNo + "','" + acctype + "','" + des + "','" + bal + "') ", conn);*/

                DataTable dtsave = new DataTable();

                // DataTable dtrsaves = new DataTable();
                // saves.Fill(dtrsaves);

                save.Fill(dtsave);
                MessageBox.Show("Successfully  Register");
            }
            else
            {
                MessageBox.Show("Please Filll the Required Field");
            }



        }

        private void save_Click(object sender, EventArgs e)
        {
            string cuid, acctype, des;
            int accNo, bal;
       

            accNo = int.Parse(accountno.Text);
            cuid = cid.Text;
            acctype = accounttype.Text;
            des = description.Text;
            bal = int.Parse(balance.Text);
            

            if (accNo != ' ' && cuid != " " && acctype != " ")
            {
                try
                {
                    SqlDataAdapter saves = new SqlDataAdapter(@"insert into accounts(accno,custid,accountype,description,balance)
                        values ('" + accNo + "','" + cuid + "','" + acctype + "','" + des + "','" + bal + "') ", con);

                    DataTable dtrsaves = new DataTable();
                    saves.Fill(dtrsaves);
                    MessageBox.Show("Registration Successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Filll the Required Field");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }

       
    }
}
   
    

