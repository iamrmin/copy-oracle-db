using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace copyoracle
{
    public partial class Source_data : Form
    {
        public Source_data()
        {
            InitializeComponent();
        }

        OracleConnection Sconn = new OracleConnection("Data Source=student;User ID=" + copy.suname + "; password =" + copy.spwd + ";Unicode=True");        

        private void Source_data_Load(object sender, EventArgs e)
        {
            try
            {
                Sconn.Open();
                DataSet Sds = new DataSet();
                OracleDataAdapter Sadpt = new OracleDataAdapter("select * from tab", Sconn);
                Sadpt.Fill(Sds, "tables");
                for (int i = 0; i < Sds.Tables["tables"].Rows.Count; i++)
                {
                    treeView1.Nodes.Add(Sds.Tables["tables"].Rows[i].ItemArray[0].ToString(), Sds.Tables["tables"].Rows[i].ItemArray[0].ToString(),0);
                }
                Sconn.Close();
                Sds.Dispose();
                this.TopMost = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OracleDataAdapter adpt = new OracleDataAdapter("select * from "+ treeView1.SelectedNode.Text,Sconn);
                DataSet ds = new DataSet();
                adpt.Fill(ds,"tb");
                dataGridView1.DataSource = ds.Tables["tb"];
                ds.Dispose();
                Sconn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}