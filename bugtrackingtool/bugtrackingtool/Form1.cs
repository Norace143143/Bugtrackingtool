using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bugtrackingtool
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Connection made between sql database and c# 
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            //Connection has been opened
            connection.Open();
            //declaring variable to store type 
            string rdtype ="";
            //select sql query 
            string sql = "select Username, Password, type from bugregister where Username = '"+textBox1.Text+"' and Password = '"+ textBox3.Text+"'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            //read data from database
            MySqlDataReader rd = cmd.ExecuteReader();
            //storing type using while loop
            while (rd.Read())
            {
                rdtype = rd["type"].ToString();
            }
                      
            //checking the value 
            if ( rdtype.Equals("Tester")   )
            {
                MessageBox.Show("login in as Tester");
                //Making the object of form3
                Form3 f3= new Form3(textBox1.Text, textBox3.Text);
                //displaying the window
                f3.Show();
                //setting the visible of form3
                Visible = false;
            }else if (rdtype.Equals("Programmer"))
            {
                MessageBox.Show("login in as Programmer");
                //Making the object of form4
                Form4 f4 = new Form4(textBox1.Text, textBox3.Text);
                //displaying the window
                f4.Show();
                //setting the visible of form4
                Visible = false;

            }else if (rdtype.Equals("Developer"))
            {
                MessageBox.Show("login in as Developer");
                //Making the object of form5
                Form5 f5 = new Form5();
                //displaying the window
                f5.Show();
                //setting the visible of form5
                Visible = false;
            }
            else
            {
                MessageBox.Show("wrong");
            }
        }    

        private void button3_Click(object sender, EventArgs e)
        {
              this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Making the object of form2
            Form2 f2 = new Form2();
            //displaying the window
            f2.Show();
            //setting the visible of form2
            Visible = false;

        }
    }
}
