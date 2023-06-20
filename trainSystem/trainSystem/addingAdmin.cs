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
    public partial class addingAdmin : Form
    {
        public addingAdmin()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void addingAdmin_Load(object sender, EventArgs e)
        {

        }
        private bool checkUniuqe(String mail, String name)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True"))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    String query = "select * from CLIENT";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            String rowUserName = (string)row["USERNAME"];
                            String rowMail = (string)row["EMAIL"];
                            if (name.Trim().Equals(rowUserName.Trim().ToLower()))
                            {
                                MessageBox.Show("This user name is used before, try anotherone");
                                return false;
                            }
                            else if (mail.Trim().Equals(rowMail.Trim().ToLower()))
                            {
                                MessageBox.Show("This Mail is used before, try anotherone");
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This Email or user name has used before, check them and try agian");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String mail = textBox1.Text;
            String userName = textBox2.Text;
            String password = textBox3.Text;
            String password2 = textBox4.Text;
            if (!password.Equals(password2))
            {
                MessageBox.Show("Passwords are not matching");
                return;
            }
            if (checkUniuqe(mail, userName))
            {
                String query = "insert into ADMIN(email,username,password) values('" + mail + "','" + userName + "','" + password + "');";
                try
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=Asem;Initial Catalog=\"Train System\";Integrated Security=True");
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.CommandText = query;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Registerd successfully");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
    }
}
