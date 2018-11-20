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
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            string rdtype ="";
            string sql = "select Username, Password, type from bugregister where Username = '"+textBox1.Text+"' and Password = '"+ textBox3.Text+"'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                rdtype = rd["type"].ToString();
            }
                      

            if ( rdtype.Equals("Tester")   )
            {
                MessageBox.Show("login in as Tester");
                Form3 f3= new Form3(textBox1.Text, textBox3.Text);
                f3.Show();
                Visible = false;
            }else if (rdtype.Equals("Programmer"))
            {
                MessageBox.Show("login in as Programmer");
                Form4 f4 = new Form4(textBox1.Text, textBox3.Text);
                f4.Show();
                Visible = false;

            }else if (rdtype.Equals("Developer"))
            {
                MessageBox.Show("login in as Developer");
                Form5 f5 = new Form5();
                f5.Show();
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
            Form2 f2 = new Form2();
            f2.Show();
            Visible = false;

        }
    }
}
