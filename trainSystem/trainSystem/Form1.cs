using System.Data;
using System.Data.SqlClient;

namespace trainSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=Asem;Initial Catalog=Train System;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT BOOKING.CLIENTID, TRIP.TRIPID FROM BOOKING, TRIP WHERE BOOKING.TRIPID = TRIP.TRIPID AND TRIP.DATE < GETDATE()";
                    DataTable dataTable = new DataTable();

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    string insertQuery = "INSERT INTO CLIENTTRIP (CLIENTID, TRIPID) SELECT @ColumnA, @ColumnB WHERE NOT EXISTS (SELECT * FROM CLIENTTRIP WHERE CLIENTID = @ColumnA AND TRIPID = @ColumnB)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@ColumnA", row["CLIENTID"]);
                            command.Parameters.AddWithValue("@ColumnB", row["TRIPID"]);

                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}