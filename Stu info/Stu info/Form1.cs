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
using System.Windows.Input;

namespace Stu_info
{

    public partial class Form1 : Form
    {
        public string celval = "";

        public Form1()

        {


            InitializeComponent();
            DisplayData();
            string connetionString = null;
            SqlConnection connection;
            connetionString = @"Data Source=DESKTOP-1SAGJQ9\SQLEXPRESS;Initial Catalog=StudentEnroll;User ID=sa;Password=8990$$";
            connection = new SqlConnection(connetionString);

            connection.Open();
        }

        //Display Data in DataGridView  
        private void DisplayData()
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter your first name!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (txtLastName.Text == "" || txtLastName.Text == null)
            {
                MessageBox.Show("Please enter your last name!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtRollNo.Text == "" || txtRollNo.Text == null)
            {
                MessageBox.Show("Please enter your Roll No!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Department.Text == "" || Department.Text == null)
            {
                MessageBox.Show("Please enter your Department!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAddress.Text == "" || txtAddress.Text == null)
            {
                MessageBox.Show("Please enter your Address!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPhoneNumber.Text == "" || txtPhoneNumber.Text == null)
            {
                MessageBox.Show("Please enter your Phone NUmber!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {
                    string connetionString = null;
                    SqlConnection connection;
                    SqlCommand command;
                    string query = "insert into StudentDetails (FirstName,Lastname,RollNumber,Department,DateofBirth,Address,PhoneNumber,DateofJoin,DateofComplete) values( '" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtRollNo.Text + "','" + Department.Text + "','" + dob.Value + "','" + txtAddress.Text + "','" + txtPhoneNumber.Text + "','" + datejoin.Value + "','" + dateComplete.Value + "')";

                    connetionString = @"Data Source=DESKTOP-1SAGJQ9\SQLEXPRESS;Initial Catalog=StudentEnroll;User ID=sa;Password=8990$$";
                    connection = new SqlConnection(connetionString);
                    try
                    {

                        connection.Open();
                        command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        command.Dispose();
                        connection.Close();
                        MessageBox.Show(" Student Details Submitted Succesfuly !!");
                        DisplayData();
                    }

                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);
                    }


                }

                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

            }
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

        private void btnclear_Click(object sender, EventArgs e)
        {

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtRollNo.Text = "";
            Department.Text = "";
            dob.Text = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
            datejoin.Text = "";
            dateComplete.Text = "";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

        private void myDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                celval = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }


        private void delete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("Do You Want delete selected Row?",
          "Important",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    string connetionString = null;
                    SqlConnection connection;
                    SqlCommand command;
                    connetionString = @"Data Source=DESKTOP-1SAGJQ9\SQLEXPRESS;Initial Catalog=StudentEnroll;User ID=sa;Password=8990$$";
                    connection = new SqlConnection(connetionString);

                    string query1 = "delete StudentDetails where id='" + celval + "'";
                    connection.Open();
                    command = new SqlCommand(query1, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                    MessageBox.Show(" Student Details Deleted Succesfuly !!");
                    DisplayData();
                }
                else
                {

                    MessageBox.Show("Please select a row");
                }
            }

            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }



        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRollNo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Department.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dob.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            datejoin.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            dateComplete.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do You Want update selected Row?",
              "Important",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    string connetionString = null;
                    SqlConnection connection;
                    SqlCommand command;
                    connetionString = @"Data Source=DESKTOP-1SAGJQ9\SQLEXPRESS;Initial Catalog=StudentEnroll;User ID=sa;Password=8990$$"; connection = new SqlConnection(connetionString);

                    string query = "update StudentDetails set FirstName='" + txtFirstName.Text + "',Lastname='" + txtLastName.Text + "',RollNumber='" + txtRollNo.Text + "',Department='" + Department.Text + "',DateofBirth='" + dob.Text + "',Address= '" + txtAddress.Text + "',PhoneNumber='" + txtPhoneNumber.Text + "',DateofJoin='" + datejoin.Text + "',DateofComplete= '" + dateComplete.Text + "' where id='" + celval + "'";
                    connection.Open();

                    command = new SqlCommand(query, connection);

                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                    MessageBox.Show(" Student Details Updated Succesfuly !!");
                    DisplayData();
                }
                else
                {

                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Show();
        }



    }
}






