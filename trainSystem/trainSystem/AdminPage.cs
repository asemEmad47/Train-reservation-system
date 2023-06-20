using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trainSystem
{
    public partial class AdminPage : Form
    {
        private String userName;
        private int ID;
        public AdminPage(String name , int id)
        {
            InitializeComponent();
            ID = id;
            userName = name;
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            label4.Text = "Welcome " + userName + " !";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //return to form
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //open adding train form
            AddingTrain adding = new AddingTrain(ID);
            adding.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //open adding trip form
            AddingTRIP addingtrip = new AddingTRIP(ID);
            addingtrip.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_train update= new Update_train();
            update.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdatingTrip update = new UpdatingTrip();
            update.Show(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addingAdmin addingAdmin= new addingAdmin();
            addingAdmin.Show();
        }
    }
}
