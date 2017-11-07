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
    public partial class Form5 : Form
    {
         static SqlConnection conn =new SqlConnection(@"server=DESKTOP-T85R8UC\SQLEXPRESS;DataBase=Sales;Integrated Security=true");
         SqlCommand cmd;
         SqlDataReader dr;
         
        public Form5()
        {
            InitializeComponent();
        }
         
        private void Form5_Load(object sender, EventArgs e)
        {
               try{ 
                 //dr=new SqlDataReader();
                     if (conn.State == 0)
                conn.Open();
                cmd = new SqlCommand("SELECT CustomerName From Customer", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                String sName = dr.GetString(0);
                comboBox1.Items.Add(sName);
                
            }
} finally{dr.Close();}
              dataGridView2.Visible = false;
            panel2.Visible = false;
             for (int i = 0; i < 20; i++)
             {
                 dataGridView1.Rows.Add();
                 if (i % 2 == 0)
                 { dataGridView1.Rows [i].DefaultCellStyle.BackColor = Color.FromArgb(223, 223, 223); }
                 else
                 { dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255); }

             }
             dataGridView1.Enabled = true;
             dataGridView1[1, 2].Style.BackColor = Color.FromKnownColor(KnownColor.BurlyWood);
        }         
        int CurRow;
         
              public void show1( )
        {
          SqlConnection conn=new SqlConnection(@"server=DESKTOP-T85R8UC\SQLEXPRESS;DataBase=Sales;Integrated Security=true");
            if (conn.State == 0)
                conn.Open();

            dataGridView2.Visible = true;
            panel2.Visible = true;

            SqlDataAdapter sda;

            DataTable dt;



            sda = new SqlDataAdapter("SELECT  Product_Id,ProductName,ProductPrice FROM Product ",  conn);
            dt = new DataTable();

            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].HeaderText = " Product id";
            dataGridView2.Columns[1].HeaderText = " Product Name";
            dataGridView2.Columns[2].HeaderText = " Price ";
            dataGridView2.Columns[0].Width = 60;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].Width = 75;
           
        }
      


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
             if (e.ColumnIndex == 2 && dataGridView1[2,e.RowIndex].Value ==null)
            {
                show1();
                CurRow = e.RowIndex;


                dataGridView2.Visible = true ;
                panel2.Visible = true;
            }


            if (dataGridView1[3, e.RowIndex].Value != null && dataGridView1[4, e.RowIndex].Value != null && (e.ColumnIndex == 4 || e.ColumnIndex == 5))
            {
                dataGridView1[5, e.RowIndex].Value =Convert .ToInt64( dataGridView1[3, e.RowIndex].Value) * Convert .ToInt64 ( dataGridView1[4, e.RowIndex].Value);

                double sum = 0;
                for (int i = 0; i <= CurRow; i++)
                    sum += Convert.ToInt64(dataGridView1[5, i].Value);
                textBox1.Text = sum.ToString();
            
            
            }
}     

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              dataGridView1[0, CurRow].Value = CurRow + 1;

            dataGridView1[1, CurRow].Value = dataGridView2[0, e.RowIndex].Value;
            dataGridView1[2, CurRow].Value = dataGridView2[1, e.RowIndex].Value;
            dataGridView1[4, CurRow].Value = dataGridView2[2, e.RowIndex].Value;
            dataGridView1[3, CurRow].Value = 1;
            dataGridView1[5, CurRow].Value = dataGridView2[2, e.RowIndex].Value ;

           


            dataGridView2.Visible =false ;
            panel2.Visible = false ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
                 int cc = CurRow;
             string[,] sss = new string[9, cc+1 ];
             if (conn.State == 0){
                conn.Open();
}
                for (int i = 0; i <= cc; i++)
            {
              
               cmd = new SqlCommand("select ProductQuantity,Product_Less_Required from product where ProductName = '" + dataGridView1[2, i].Value + "'", conn);
              dr = cmd.ExecuteReader();
               dr.Read();
              if(Convert.ToInt32(dr["ProductQuantity"].ToString())<=Convert.ToInt32(dataGridView1[3, i].Value)){
               MessageBox.Show("we dont have this Quantity from "+dataGridView1[2, i].Value,"Sell",MessageBoxButtons.OK,MessageBoxIcon.Information);
               dr.Close();}
               else if (Convert.ToInt32(dr["ProductQuantity"].ToString())<=Convert.ToInt32(dr["Product_Less_Required"].ToString())){
                 MessageBox.Show("we dont have this product  "+dataGridView1[2, i].Value+" in Inventory","Sell",MessageBoxButtons.OK,MessageBoxIcon.Information);
                 dr.Close();
               }
   else if (Convert.ToInt32(dr["ProductQuantity"].ToString())-Convert.ToInt32(dataGridView1[3, i].Value)<=Convert.ToInt32(dr["Product_Less_Required"].ToString())){
                 MessageBox.Show("we dont have this product  "+dataGridView1[2, i].Value+" in Inventory","Sell",MessageBoxButtons.OK,MessageBoxIcon.Information);
                 dr.Close();
               }
              else{
              
             dr.Close();
                if (conn.State == 0){
                conn.Open();}

                cmd = new SqlCommand("Update Product Set ProductQuantity=ProductQuantity-'"+Convert.ToInt32(dataGridView1[3, i].Value)+"'Where ProductName='"+dataGridView1[2, i].Value+"'", conn);
                cmd.ExecuteNonQuery();
                                 if(comboBox1.Text!=""&&dataGridView1[2, i].Value.ToString()!=""&&dataGridView1[5, i].Value.ToString()!="")
                                    {
                                 cmd = new SqlCommand("INSERT INTO Trans(Customename,productname,cost) VALUES ( '" + comboBox1.Text+ "','" + dataGridView1[2, i].Value+ "','" + dataGridView1[5, i].Value + "')", conn);
                                  cmd.ExecuteNonQuery();
                                    }
                
             
                sss[0, i] = dataGridView1[0, i].Value.ToString();

                sss[1, i] = dataGridView1[1, i].Value.ToString();

                sss[2, i] =   dataGridView1[2, i].Value.ToString();
                sss[3, i] =    dataGridView1[3, i].Value.ToString ();
                sss[4, i] = dataGridView1[4, i].Value.ToString ();
                sss[5, i] =  dataGridView1[5, i].Value.ToString ();
               
                
                

                sss[6, i] = dateTimePicker1.Text ;

                
                sss[7, i] = textBox1.Text;

               


            



                         
                              









                         
          
       /*Form fff = new Form6(sss,cc +1); 
 fff.ShowDialog();*/    

}

}           
  

}       

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormTransact f = new FormTransact();
            this.Hide();
            f.ShowDialog();
        }
        }
    
}

