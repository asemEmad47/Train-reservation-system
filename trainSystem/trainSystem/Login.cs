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

namespace trainSystem
{
    public partial class Login : Form
    {
        private String userName;
        private int ID;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private bool checkIdentity(String query , int check)
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
                            String name = (string)row["USERNAME"];
                            if (check == 0)
                                ID = (int)row["ADMINID"];
                            else
                                ID = (int)row["CLIENTID"];
                            userName= name;
                            break;
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
            String mail = textBox1.Text;
            String password = textBox2.Text;
            if (checkIdentity("select * from ADMIN where EMAIL = '"+mail+"'and PASSWORD ='"+password+"'" , 0))
            {
                AdminPage admin = new AdminPage(userName , ID);
                admin.Show();
                this.Hide();
            }
            else if(checkIdentity("select * from CLIENT where EMAIL = '" +mail+ "' and PASSWORD = '"+password+"'" , 1))
            {
                usePage userpage = new usePage(userName , ID);
                userpage.Show();
                this.Hide();

            }
            else
                MessageBox.Show("Invalid email or password please check them and try again");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
