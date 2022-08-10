using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stu_info
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DisplayData();
            string connetionString = null;
            SqlConnection connection;
            connetionString = @"Data Source=DESKTOP-1SAGJQ9\SQLEXPRESS;Initial Catalog=StudentEnroll;User ID=sa;Password=8990$$";
            connection = new SqlConnection(connetionString);

            connection.Open();
        }
        private void DisplayData()
        {
            string connetionString = null;
            SqlConnection connection;
            connetionString = @"Data Source=DESKTOP-1SAGJQ9\SQLEXPRESS;Initial Catalog=StudentEnroll;User ID=sa;Password=8990$$";
            connection = new SqlConnection(connetionString);
            SqlDataAdapter adapt;
            connection.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT *FROM StudentDetails;", connection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            NewMethod();
            this.Close();
        }

        private void NewMethod()
        {
             
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection connection;
            connetionString = @"Data Source=DESKTOP-1SAGJQ9\SQLEXPRESS;Initial Catalog=StudentEnroll;User ID=sa;Password=8990$$";
            connection = new SqlConnection(connetionString);
            SqlDataAdapter adapt;
            connection.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from StudentDetails", connection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }
    }
}
