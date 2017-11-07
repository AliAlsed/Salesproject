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
    public partial class FormTransact : Form
    {
            SqlConnection conn = new SqlConnection(@"server=DESKTOP-T85R8UC\SQLEXPRESS;DataBase=Sales;Integrated Security=true");
            SqlDataAdapter sda;
            DataTable dt;
        public FormTransact()
        {
            InitializeComponent();
        }
          public void RowsColor()
        {
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
             
                if (i%2==0)
                {
 dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(223, 223, 223); 

                }
                else
                {
                 dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);;
                }
    dataGridView1[1, 2].Style.BackColor = Color.FromKnownColor(KnownColor.BurlyWood);
            }
              dataGridView1.Columns[0].HeaderText = " Transaction id";
            dataGridView1.Columns[1].HeaderText = " Customer Name";
            dataGridView1.Columns[2].HeaderText = " Product ";
            dataGridView1.Columns[3].HeaderText = " Cost ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
              
        
        
                 if (conn.State == 0)
                    conn.Open();


                SqlDataAdapter sda;

                DataTable dt;
                dt = new DataTable();
                sda = new SqlDataAdapter("select Trans_id,Customename,productname,cost From Trans", conn);

                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                 RowsColor();
    }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

      
}
}