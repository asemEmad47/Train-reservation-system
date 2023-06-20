using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trainSystem
{
    public partial class AddingTRIP : Form
    {
        private int ID;
        public AddingTRIP(int id)
        {
            InitializeComponent();
            ID = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void displayTrains()
        {
            SqlConnection sqlConnection = new("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            // selecting trains which are not booked by a trip and having a seat
            String query = "select * from train where TRAINID not in(select TRAINID from TRIP) and AVAILABLESEATS >0";
            // which will excute the query
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            // data structure to get items from the database
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        private void AddingTRIP_Load(object sender, EventArgs e)
        {
            displayTrains();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //inserting a trip
            String query = "insert into TRIP(ADMINID,DESTINATION,ORIGIN,DATE , PRICE,TRAINID,duration) values('" + ID + "','" + textBox2.Text + "' , '" + textBox1.Text + "' , '" + textBox3.Text + "','" + textBox5.Text + "' , '" + textBox6.Text + "' , '" + textBox4.Text + "');";
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = query;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("An TRIP added successfully");
                // empty fields
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                displayTrains();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
