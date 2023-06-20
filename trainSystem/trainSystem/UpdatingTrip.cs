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

namespace trainSystem
{
    public partial class UpdatingTrip : Form
    {
        private void displayTrips()
        {
            SqlConnection sqlConnection = new("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            String query = "select * from TRIP where TRAINID in(select TRAINID from TRAIN where NUMOFSEATS = AVAILABLESEATS)";
            // which will excute the query
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            // data structure to get items from the database
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        private void displayTrain()
        {
            SqlConnection sqlConnection = new("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            String query = "select * from train where TRAINID not in (select TRAINID from TRIP)";
            // which will excute the query
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            // data structure to get items from the database
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            sqlConnection.Close();
        }
        public UpdatingTrip()
        {
            InitializeComponent();
        }
        //check that we can update num of seats without any problems
        private bool checkSeats(String query)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True"))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void UpdatingTrip_Load(object sender, EventArgs e)
        {
            displayTrips();
            displayTrain();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sub 1 from train available seats
            String query2 = "update TRIP set ORIGIN = '" + textBox1.Text + "', DESTINATION = '" + textBox2.Text + "'  , DATE = '" + textBox3.Text + "', DURATION = '" + textBox4.Text + "', PRICE = '" + textBox5.Text + "' ,TRAINID = '" + textBox6.Text + "' where TRIPID = '"+ textBox7.Text + "'";
            //getting the train info and check them
            if (checkSeats("select * from TRIP where TRAINID in(select TRAINID from TRAIN where NUMOFSEATS = AVAILABLESEATS)"))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = query2;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Updated successfully");
                    displayTrips();
                    displayTrain();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("incorrect Trip id , please choose train id only from the screen");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query2 = "delete from TRIP where TRIPID = '" + int.Parse(textBox7.Text) + "'";
            //getting the train info and check them
            if (checkSeats("select * from TRIP where TRAINID in(select TRAINID from TRAIN where NUMOFSEATS = AVAILABLESEATS)"))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = query2;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("An Trip is deleted successfully");
                    displayTrips();
                    displayTrain();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("this train is booked by trip, u can't delete it");
            }
        }
    }
}
