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
    public partial class usePage : Form
    {
        private String userName;
        private int ID;
        public usePage(String Name, int iD)
        {
            userName = Name;
            InitializeComponent();
            ID = iD;
         }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void usePage_Load(object sender, EventArgs e)
        {
            label4.Text = "Welcome " + userName + " !";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            BOOKING book= new BOOKING(ID);
            book.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            usersBooking users = new usersBooking(ID);
            users.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updatingClientInfo updating = new updatingClientInfo(ID);
            updating.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            History history = new History(ID);
            history.Show();
        }
    }
}
