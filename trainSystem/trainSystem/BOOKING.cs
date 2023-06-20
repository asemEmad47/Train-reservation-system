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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace trainSystem
{
    public partial class BOOKING : Form
    {
        private int ID;
        private int trainID;
        public BOOKING(int iD)
        {
            InitializeComponent();
            ID = iD;
        }
        private void displayTrips()
        {
            SqlConnection sqlConnection = new("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            String query = "SELECT TRIP.TRIPID,TRIP.ORIGIN,TRIP.DESTINATION,TRIP.DURATION,TRIP.PRICE,TRIP.Date,TRIP.TRAINID, TRAIN.AVAILABLESEATS FROM TRIP JOIN TRAIN ON TRIP.TRAINID = TRAIN.TRAINID and TRIP.DATE < GETDATE()";
            // which will excute the query
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            // data structure to get items from the database
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        private void BOOKING_Load(object sender, EventArgs e)
        {
            displayTrips();
        }
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
                        foreach (DataRow row in dataTable.Rows)
                        {
                            trainID = (int)row["TRAINID"];
                            return true;
                        }
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
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("")|| textBox2.Text.Equals(""))
            { return; }
            int tripID = int.Parse(textBox1.Text);
            int numOfSeats = int.Parse(textBox2.Text);
            //add booking info in booking
            string query2 = "insert into Booking(CLIENTID,TRIPID) values('" + ID + "','" + tripID + "')";
            // Declare a variable to store the booking ID
            int bookingID = -1;
            // Getting the train info and checking the seats
            if (checkSeats("select TRIP.TRAINID,TRAIN.AVAILABLESEATS from TRIP join TRAIN on TRIP.TRAINID = TRAIN.TRAINID where TRAIN.AVAILABLESEATS > '"+ numOfSeats+"' and TRIPID = '"+tripID+"' and TRIP.DATE < GETDATE()"))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = query2;
                    sqlCommand.ExecuteNonQuery();
                    // Retrieve the booking ID
                    sqlCommand.CommandText = "SELECT SCOPE_IDENTITY()";
                    bookingID = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //booking seats
                try
                {
                    string query = "UPDATE TOP(" + numOfSeats + ") seat SET BOOKINGID = '" + bookingID + "' WHERE TRAINID = '" + trainID + "'";
                    SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = query;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //sub bookings from available seats
                try
                {
                    string query = "UPDATE TRAIN SET AVAILABLESEATS = AVAILABLESEATS - '"+numOfSeats+"' where TRAINID = '"+trainID+"'";
                    SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = query;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("Booked successfully");
                displayTrips();
            }
            else
            {
                MessageBox.Show("Incorrect Trip ID or number of seats. Please check them from the table and try again.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
