using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tabSample
{
    public partial class Form1 : Form
    {
        private SqlConnection myConn = null;
        SqlDataAdapter dataAdapter = null;
        DataSet dataSet = null;
        SqlCommandBuilder commandBuilder = null;
        ListView lv = null;
        string connString = "";

        public Form1()
        {
            InitializeComponent();
            myConn = new SqlConnection();
            connString = ConfigurationManager.ConnectionStrings["ConnStringSampleTabControl"].ConnectionString;
            myConn.ConnectionString = connString;



        }

        private void button_startQuery_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBox_queryText.Text))
            {
                if (!comboBox_queryText.Items.Contains(comboBox_queryText.Text))
                    comboBox_queryText.Items.Add(comboBox_queryText.Text);
            }
            

            try
            {
                SqlConnection myConn = new SqlConnection(connString);
                dataSet = new DataSet();
                string queryText = comboBox_queryText.Text;
                dataAdapter = new SqlDataAdapter(queryText, myConn);
                dataGridView1.DataSource = null;
                commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataSet, "table_1");
                dataGridView1.DataSource = dataSet.Tables["table_1"];
                lv = new ListView();

                


            }
            catch (Exception ex) {  }
            finally { }








        }
    }
}
