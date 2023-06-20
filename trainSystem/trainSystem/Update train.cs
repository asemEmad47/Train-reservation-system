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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace trainSystem
{
    public partial class Update_train : Form
    {
        public Update_train()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void displayTrain()
        {
            SqlConnection sqlConnection = new("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            String query = "select * from train";
            // which will excute the query
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            // data structure to get items from the database
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
        private void Update_train_Load(object sender, EventArgs e)
        {
            displayTrain();
        }
        //check that we can update num of seats without any problems
        //check for knowing that this is update or delete
        private bool checkSeats(String query , int check)
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
                            //to check that it is deleting
                            if (check != 0)
                                return true;
                            int avialableSeats = (int)row["AVAILABLESEATS"];
                            int numOfSeats = (int)row["NUMOFSEATS"];
                                //checking that the new capacity > num of booked seats
                            if (numOfSeats-avialableSeats > int.Parse(textBox2.Text))
                            {
                                MessageBox.Show("Number of booked seats is bigger than the new size, update is failed");
                                return false;
                            }
                        }
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
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //sub 1 from train available seats
            String query2 = "update TRAIN set AVAILABLESEATS = '"+int.Parse(textBox2.Text)+ "' -(NUMOFSEATS-AVAILABLESEATS) ,NUMOFSEATS ='" + int.Parse(textBox2.Text) + "'  where TRAINID = '" + int.Parse(textBox1.Text)+"' ";
            //getting the train info and check them
            if (checkSeats("select AVAILABLESEATS ,NUMOFSEATS from TRAIN where TRAINID = '" + int.Parse(textBox1.Text)+"'" , 0))
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
                    displayTrain();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("incorrect id , please choose train id only from the screen");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                return;
            }
            String query2 = "delete from TRAIN where TRAINID = '" + int.Parse(textBox1.Text) + "'";
            //getting the train info and check them
            if (checkSeats("select * from train where TRAINID not in(select TRAINID from trip) and TRAINID = '" + int.Parse(textBox1.Text)+"'" , 1))
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
                    MessageBox.Show("An train is deleted successfully");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
