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
    public partial class History : Form
    {
        private int ID;
        public History(int iD)
        {
            InitializeComponent();
            ID = iD;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void History_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            String query = "SELECT TRIP.TRIPID,TRIP.ORIGIN,TRIP.DESTINATION,TRIP.DURATION,TRIP.PRICE,TRIP.Date from TRIP where TRIPID in(select TRIPID from CLIENTTRIP where CLIENTID = '"+ID+"')";
            // which will excute the query
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            // data structure to get items from the database
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();
        }
    }
}
