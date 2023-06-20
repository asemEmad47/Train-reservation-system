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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace trainSystem
{
    public partial class AddingTrain : Form
    {
        private int ID;
        public AddingTrain(int iD)
        {
            InitializeComponent();
            ID = iD;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numOFSeats = int.Parse(textBox1.Text);
            //inserting items into train
            String query = "INSERT INTO TRAIN(ADMINID, NUMOFSEATS, AVAILABLESEATS) VALUES('" + ID + "','" + numOFSeats + "' , '" + numOFSeats + "'); SELECT CAST(scope_identity() AS int);";
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.CommandText = query;

                // Execute the query and retrieve the inserted ID
                int insertedID = Convert.ToInt32(sqlCommand.ExecuteScalar());

                sqlConnection.Close();
                for(int i = 0;i<numOFSeats;i++)
                {
                    // adding seats for every train
                    String query2 = "insert into SEAT(TRAINID) values('" + insertedID + "')";
                    try
                    {
                        SqlConnection sqlConnection2 = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                        SqlCommand sqlCommand2 = new SqlCommand();
                        sqlCommand2.Connection = sqlConnection2;
                        sqlConnection2.Open();
                        sqlCommand2.CommandText = query2;
                        sqlCommand2.ExecuteNonQuery();
                        sqlConnection2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MessageBox.Show("Train is added successfully");
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddingTrain_Load(object sender, EventArgs e)
        {

        }
    }
}
