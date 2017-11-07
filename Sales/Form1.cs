using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sales
{
    public partial class Form1 : Form
    {




        SqlConnection conn = new SqlConnection(@"server=DESKTOP-T85R8UC\SQLEXPRESS;DataBase=Sales;Integrated Security=true");

        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
           
            
        }

    

 

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Users where UserName = '" + textUserName.Text + "'", conn);
                dr = cmd.ExecuteReader();

                if (textUserName.Text == "" || textPassword.Text == "")
                {
                    MessageBox.Show("You must enter your userName And Password","Login",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

                dr.Read();
                Form2 f = new Form2(textUserName.Text);
                if (dr["UserName"].ToString() == textUserName.Text && dr["UserPassword"].ToString() == textPassword.Text)
                {


                    this.Hide();
                    f.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Access Denied, password or username is incorrect", "SignIn", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SignIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                conn.Close();
                dr.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Want To exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }


         


        }

       
    }

        
    

