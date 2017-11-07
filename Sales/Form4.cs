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

    public partial class Form4 : Form
    {

        SqlConnection conn = new SqlConnection(@"server=DESKTOP-T85R8UC\SQLEXPRESS;DataBase=Sales;Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommandBuilder scb;
        DataSet DataSets;
        public Form4()
        {
            InitializeComponent();
        }  
        private void button2_Click(object sender, EventArgs e)
        {
             try{
            if (conn.State == 0)
                conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customer (CustomerName, CustomerTele,Customer_Address) VALUES ( '" + textBox1.Text + "','" + Convert.ToInt64(textBox2.Text) + "','" + textBox3.Text + "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Add","Added Customer",MessageBoxButtons.OK,MessageBoxIcon.Information);
            conn.Close();
} finally{
textBox1.Text="";
textBox2.Text="";
textBox3.Text="";
}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panel1.Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible=false;
            groupBox2.Visible=false;
            groupBox3.Visible=false;
            panel1.Visible = true;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text!="" && textBox7.Text !="")
            {
                textBox4.DataBindings.Clear();
                textBox5.DataBindings.Clear();
                textBox6.DataBindings.Clear();
                textBox7.DataBindings.Clear();
                DataSets.Clear();

                SqlCommand SavInto = new SqlCommand();

                SavInto.Connection = conn;
                SavInto.CommandType = CommandType.Text;

                SavInto.CommandText = "UPDATE  Customer SET CustomerName= '" + textBox5.Text + "', CustomerTele= '" + textBox6.Text + "',Customer_Address= '"+textBox7.Text+"'WHERE Customer_Id ='" + Convert.ToInt32(textBox4.Text) + "'";



                if (conn.State == 0)
                    conn.Open();
                SavInto.ExecuteNonQuery();




                MessageBox.Show("Update");
            }
            else
            {
                MessageBox.Show("Error");

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                DataSets = new DataSet();

                if (textBox4.Text != "")
                {

                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox4.DataBindings.Clear();
                    textBox5.DataBindings.Clear();
                    textBox6.DataBindings.Clear();
                    textBox7.DataBindings.Clear();

                    
                    sda = new SqlDataAdapter("SELECT * From Customer Where Customer_Id= '" + Convert.ToInt32(textBox4.Text) + "'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    textBox4.DataBindings.Add("Text", dt, "Customer_Id");
                    textBox5.DataBindings.Add("Text", dt, "CustomerName");
                    textBox6.DataBindings.Add("Text", dt, "CustomerTele");
                    textBox7.DataBindings.Add("Text", dt, "Customer_Address");
                }

            }
        }
   
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
            groupBox2.Visible=false;
            groupBox3.Visible=false;
            groupBox1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                groupBox1.Visible = false;

            }
        }

  



        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
             groupBox1.Visible=false;
            groupBox2.Visible=true;
            groupBox3.Visible=false;
            panel1.Visible = false;
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {   
            dt=new DataTable();
            try { dataGridView1.Rows.Clear();}
            catch { }
            sda = new SqlDataAdapter("Select C.CustomerName,D.Debit_Amount,D.Debit_Last_Date From Customer as C ,Debit as D Where C.Customer_Id=D.Customer_Id And C.CustomerName LIKE ('" + textBox8.Text + "%" + "')", conn);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                groupBox2.Visible = false;

            }
        }

     

     

    

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
                 if (e.KeyCode == Keys.Enter)
            {
                   if(conn.State==0)
            {
                conn.Open();
            }
                DataSets = new DataSet();
                if (textBox12.Text != "")
                {
                  try{
                    textBox13.Text = "";
                     dt = new DataTable();
                    textBox12.DataBindings.Clear();
                    textBox13.DataBindings.Clear();
                      sda = new SqlDataAdapter("Select Customer_Id , CustomerName  From Customer Where Customer_Id= '" + Convert.ToInt32(textBox12.Text) + "'", conn);
                    sda.Fill(dt);
                     textBox12.DataBindings.Add("Text", dt, "Customer_Id");
                    textBox13.DataBindings.Add("Text", dt, "CustomerName");
        }
catch(SqlException ex) { 
              MessageBox.Show("you Enter unKnown Customer Id"+ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
}

 }
}

        private void button13_Click(object sender, EventArgs e)
        {
                   if(conn.State==0)
            {
                conn.Open();
            }
            if(textBox12.Text!=""&&textBox13.Text!=""&&textBox14.Text!="")
{
            try{      
                cmd = new SqlCommand("Insert into Debit (Customer_Id,Debit_Amount,Debit_Last_Date) Values('" + Convert.ToInt32(textBox12.Text) + "','" + Convert.ToInt32(textBox14.Text) + "','" + Convert.ToString(dateTimePicker1.Text) + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Add", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Add unSeccessfuly" + ex.Message, "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

}
        }

        private void button12_Click(object sender, EventArgs e)
        {
             groupBox1.Visible=false;
            groupBox2.Visible=false;
            groupBox3.Visible=true;
            panel1.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
                  DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                groupBox3.Visible = false;

            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
              Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }
}
}