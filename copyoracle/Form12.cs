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
    public partial class Form12 : Form
    {
        copy cp = new copy();
        public Form12()
        {
            InitializeComponent();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                copy.suname = txtsuser.Text;
                copy.spwd = txtspwd.Text;

                OracleConnection conn = new OracleConnection(cp.sconstr);
                conn.Open();
                OracleDataAdapter adpt = new OracleDataAdapter("select * from tab", cp.sconstr);
                DataSet ds = new DataSet();
                adpt.Fill(ds, "tables");

                copy.duname = txtduser.Text;
                copy.dpwd = txtdpwd.Text;
                OracleConnection conn2 = new OracleConnection(cp.dconstr);
                conn2.Open();
                OracleCommand comm2 = new OracleCommand();
                comm2.Connection = conn2;
                for (int i = 0; i < ds.Tables["tables"].Rows.Count; i++)
                {
                    OracleCommand command = new OracleCommand("grant select on " + ds.Tables["tables"].Rows[i].ItemArray[0] + " to " + txtduser.Text, conn);
                    command.ExecuteNonQuery();
                    comm2.CommandText = "create table " + ds.Tables["tables"].Rows[i].ItemArray[0] + " as select * from " + txtsuser.Text + "." + ds.Tables["tables"].Rows[i].ItemArray[0] + "";
                    comm2.ExecuteNonQuery();
                }
                conn.Close();
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            copy.spwd = txtspwd.Text;
            copy.suname = txtsuser.Text;
            Source_data sd = new Source_data();
            sd.Text = txtsuser.Text + " Tables";
            sd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            copy.dpwd = txtdpwd.Text;
            copy.duname = txtduser.Text;
            Source_data sd = new Source_data();
            sd.Text = txtduser.Text + " Tables";
            sd.Show();
        }
    }
}