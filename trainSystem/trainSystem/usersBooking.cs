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
    public partial class usersBooking : Form
    {
        private int ID;
        private void displayBookings()
        {
            SqlConnection sqlConnection = new("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            String query = "SELECT BOOKING.*, TRIP.* FROM BOOKING JOIN TRIP ON BOOKING.TRIPID = TRIP.TRIPID and BOOKING.CLIENTID = '"+ID+"'";
            // which will excute the query
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            // data structure to get items from the database
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
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
        public usersBooking(int iD)
        {
            InitializeComponent();
            ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
                return;
            string connectionString = "Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True"; 
            string queryString = "SELECT COUNT(BOOKINGID) FROM SEAT WHERE BOOKINGID = @BookingID";
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@BookingID", int.Parse(textBox1.Text));

            
                try
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Handle any potential exceptions that might occur during the query execution.
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            String query2 = "delete from SEAT where BOOKINGID = '" + int.Parse(textBox1.Text) + "' ; delete from BOOKING where BOOKINGID = '"+ int.Parse(textBox1.Text) + "';update Train set AVAILABLESEATS = AVAILABLESEATS + '"+count+"'";
            //getting the train info and check them
            if (checkSeats("select * from BOOKING where CLIENTID = '"+ID+"'"))
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
                    MessageBox.Show("A booking is deleted successfully");
                    displayBookings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("there is no booking with that id");
            }

        }

        private void usersBooking_Load(object sender, EventArgs e)
        {
            displayBookings();
        }
    }
}
