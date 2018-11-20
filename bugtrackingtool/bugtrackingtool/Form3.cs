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
    public partial class Form3 : Form
    {
        public string[] collecteddata = new string[5];
        public Form3(string username, string password)
        {
            InitializeComponent();
            string profileuser = username;
            MessageBox.Show(profileuser);
            string profilepass = password;
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            string sql = "select * from bugregister where Username ='" + profileuser + "' and 	Password = '" + profilepass + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                collecteddata[0] = dr["Id"].ToString();
                textBox1.Text += collecteddata[0];
                collecteddata[1] = dr["Username"].ToString();
                textBox2.Text += collecteddata[1];
                collecteddata[2] = dr["Email"].ToString();
                textBox3.Text += collecteddata[2];
                collecteddata[3] = dr["type"].ToString();
                textBox4.Text += collecteddata[3];
                collecteddata[4] = dr["Gender"].ToString();
                textBox5.Text += collecteddata[4];
            }
            connection.Close();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelprofile.Visible = true;
            panel1.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             


        }

        private void bugReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panelprofile.Visible = false;
            panel1.Visible = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png| All Files(*.*)|*.*";

                if(dialog.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    

                    MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password=");
                    connection.Open();
                    string sql1 = "update profilepixcollector set Profilepix ='"+ imagelocation+"'where Username='"+ collecteddata[1]+"'";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, connection);
                    try
                    {
                        if(cmd1.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("uploaded");
                        }
                        else
                        {
                            MessageBox.Show("Not uploaded");

                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    connection.Close();

                    profilepicture.ImageLocation = imagelocation;

                }
            }
            catch (Exception )
            {
                MessageBox.Show("error occored", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void profilepicture_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();

            String sql = "Insert into bugrecord(Project_name, Line_num_start, Line_num_end, Class_name, Method, Issued_date, Description, Source_file, Image) values" + "('" + textBox7.Text + "','" + textBox11.Text + "', '" +
            textBox9.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','"+ textBox8.Text+"','"+ textBox14.Text+ "','"+ textBox10.Text+"','"+ pictureBox1 .Image+ "')";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("inserted");
                }
                else
                {
                    MessageBox.Show("not inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string imagelocation1 = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png| All Files(*.*)|*.*";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imagelocation1 = dialog.FileName;
            }


        }
    }
}
