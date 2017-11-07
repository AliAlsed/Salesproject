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
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-T85R8UC\SQLEXPRESS;DataBase=Sales;Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommandBuilder scb;
        DataSet DataSets;
         

        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try { dataGridView1.Rows.Clear(); }
                catch { }



                if (conn.State == 0)
                    conn.Open();


                SqlDataAdapter sda;

                DataTable dt;
                dt = new DataTable();
                sda = new SqlDataAdapter("select P.ProductName,P.ProductQuantity,P.ProductPrice,P.Product_Less_Required,C.CategoryName From Product as P,Category as C where P.CategoryName=C.CategoryName And P.ProductName like('" + textBox1.Text + "%" + "') ", conn);

                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else
            {
                MessageBox.Show("You Must Enter Product Name","Product List",MessageBoxButtons.OK,MessageBoxIcon.Information);


            }
            
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible= false;
            groupBox3.Visible=false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panel1.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            groupBox3.Visible=false;
            panel2.Visible = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
             try{
            if (conn.State == 0)
                conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Product (ProductName, ProductPrice,ProductQuantity,Product_Less_Required,CategoryName) VALUES ( '" + textBox2.Text + "','" + Convert.ToInt32(textBox3.Text) + "','" + Convert.ToInt32(textBox4.Text) + "', '" + Convert.ToInt32(textBox5.Text) + "','" +textBox6.Text+ "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Add","Added Product",MessageBoxButtons.OK,MessageBoxIcon.Information);
            conn.Close();
}
finally{
textBox2.Text="";
textBox3.Text="";
textBox4.Text="";
textBox5.Text="";
textBox6.Text="";                           



}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panel2.Visible = false;

            }
        }

       

      

        private void button10_Click(object sender, EventArgs e)
        {
            if(conn.State==0){
               conn.Open();
             }
            if(textBox11.Text!=""){
              SqlCommand cmd = new SqlCommand("Update Product SET  ProductQuantity=ProductQuantity + '" + Convert.ToInt32(textBox14.Text) + "' where Product_Id='"+Convert.ToInt32(textBox11.Text)+"'", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Add","Added Buffer",MessageBoxButtons.OK,MessageBoxIcon.Information);
            conn.Close();
               


               }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                   if(conn.State==0)
            {
                conn.Open();
            }
                DataSets = new DataSet();
                if (textBox11.Text != "")
                {

             try{
                    
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text="";
                    textBox11.DataBindings.Clear();
                    textBox12.DataBindings.Clear();
                    textBox13.DataBindings.Clear();
                      sda = new SqlDataAdapter("Select Product_Id , ProductName , ProductQuantity From Product Where Product_Id= '" + Convert.ToInt32(textBox11.Text) + "'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    textBox11.DataBindings.Add("Text", dt, "Product_Id");
                    textBox12.DataBindings.Add("Text", dt, "ProductName");
                    textBox13.DataBindings.Add("Text", dt, "ProductQuantity");

}
catch { 
              MessageBox.Show("you Enter unKnown Product Id", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
               
}
}
}


private void button6_Click_1(object sender, EventArgs e)
{
            panel1.Visible = false;
            panel2.Visible= false;
            groupBox3.Visible=true;
}

private void button12_Click(object sender, EventArgs e)
{
      Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
}

private void button11_Click(object sender, EventArgs e)
{
     DialogResult result = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                groupBox3.Visible = false;

            }
}

private void Form3_Load(object sender, EventArgs e)
{

}



}
        }

        


      




    



