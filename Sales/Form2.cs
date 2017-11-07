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
    public partial class Form2 : Form
    {
       
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-T85R8UC\SQLEXPRESS;DataBase=Sales;Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommandBuilder scb;
        DataSet DataSets;
        public Form2()
        {
            this.Close();
          
        }
        public Form2(String qs)
        {
            conn.Open();
     

        
            InitializeComponent();
    

            label4.Text = qs;
            label6.Text = DateTime.Now.ToString("h:mm:ss tt")+"    "+DateTime.Now.ToString("dd/MM/yyy ");

  
            
         
            {



            }
        }

   

     
        private void label8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Want To exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panel3.Visible = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                
                cmd = new SqlCommand("select UserRole from Users where UserName = '" + label4.Text + "'", conn);
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {

                    if (dr["UserRole"].ToString() == "1")
                    {


                        panel3.Visible = true;





                    }



                    else
                    {
                        MessageBox.Show("Access Deny You Dont Have Permission To Access Settings", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    }



                }
            }
            finally
            {
                dr.Close();
            }
        }


        
        private void button12_Click(object sender, EventArgs e)
        {
            if (textUserName.Text != "" && textPassword.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("Insert into Users (UserName,UserPassword) Values('" + textUserName.Text + "','" + textPassword.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    DialogResult result = MessageBox.Show("Add Seccessfuly", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DialogResult.OK == result)
                    {
                        panel4.Visible = false;

                    }
                }
                catch (SqlException ex)
                {


                    MessageBox.Show("error" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You Must Enter UserName and Password","Add",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }


        private void button11_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            this.Hide();
            f.ShowDialog();
            
        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            
            this.Close();
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {   panel5.Visible=false;
            panel4.Visible = true;
            panel3.Visible = false;
            panel8.Visible=false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panel4.Visible = false;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            panel4.Visible = false;
            panel3.Visible = false;
            panel8.Visible=false;
            panel5.Visible = true;
            cmd = new SqlCommand("SELECT UserName From Users", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                String sName = dr.GetString(0);
                comboBox1.Items.Add(sName);
                
            }

          

            
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                dr.Close();
                cmd = new SqlCommand("Delete FROM Users Where UserName ='"+comboBox1.SelectedItem.ToString()+"'",conn);
                cmd.ExecuteNonQuery();
                

                DialogResult result = MessageBox.Show("DELETE Seccessfuly", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DialogResult.OK == result)
                {
                    panel4.Visible = false;

                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panel5.Visible = false;

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel5.Visible=false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel8.Visible = true;
        }
         private void button3_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            this.Hide();
            f.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox9.Text != "")
            {
                textBox8.DataBindings.Clear();
                textBox9.DataBindings.Clear();
                DataSets.Clear();

                SqlCommand SavInto = new SqlCommand();

                SavInto.Connection = conn;
                SavInto.CommandType = CommandType.Text;

                SavInto.CommandText = "UPDATE  Users SET UserName= '" + textBox8.Text + "' , UserPassword= '" + textBox9.Text + "', UserRole= '"+textBox1.Text +"'WHERE User_ID ='" + Convert.ToInt32(textBox7.Text) + "'";


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

        private void button21_Click(object sender, EventArgs e)
        {
                     DataSets = new DataSet();
       
            if (textBox7.Text != "")
            {
                textBox7.DataBindings.Clear();
                textBox8.DataBindings.Clear();
                textBox9.DataBindings.Clear();
                textBox1.DataBindings.Clear();
                sda = new SqlDataAdapter("SELECT * From Users Where User_ID='"+Convert.ToInt32(textBox7.Text)+"'",conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                textBox7.DataBindings.Add("Text",dt,"User_ID");
                textBox8.DataBindings.Add("Text", dt, "UserName");
                textBox9.DataBindings.Add("Text", dt, "UserPassword");
                textBox1.DataBindings.Add("Text", dt, "UserRole");

               
       
                
                     



                   

                   

                }
                else
                {
                    MessageBox.Show("Error");


                }
            }

        

        private void button22_Click(object sender, EventArgs e)
        {
        panel8.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form5 f = new Form5();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTransact f = new FormTransact();
            this.Hide();
            f.ShowDialog();
        }

      

      

   

      
        }
        

      

     
      

    


}












        
    
    
    

       
    

