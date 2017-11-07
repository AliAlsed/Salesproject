using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*namespace Sale
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            
        }

        public Form6(string[,] s, int x )
        {
            InitializeComponent();
            this.DataSet1.table1.Clear();

            for (int i = 0; i < x; i++)
            {
                DataRow ro = this.DataSet1.Tables["table1"].NewRow();

                
                    ro["f1"] = s[0, i];
                     ro["f2"] = s[1, i];
                    ro["f3"] = s[2, i];
                    ro["f4"  ] = s[3, i];
                    ro["f5"  ] = s[4, i];
                    ro["f6" ] = s[5, i];
                    ro["f7"] = s[6, i];
                    ro["f8"] = s[7, i];
                this.DataSet1.Tables["table1"].Rows.Add(ro);

            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
 
            this.reportViewer1.RefreshReport();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.reportViewer1.LocalReport.ReleaseSandboxAppDomain();


            }
            catch { }
            reportViewer1.Dispose();


            this.Dispose();
        }
    }
}*/