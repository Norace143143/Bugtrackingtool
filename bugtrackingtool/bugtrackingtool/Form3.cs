using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using MySql.Data.MySqlClient;

namespace bugtrackingtool
{
    public partial class Form3 : Form
    {
        public string[] collecteddata = new string[5];
        public Form3(string username, string password)
        {
            InitializeComponent();

            string file = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(file))
            {

                fsmp = new FileSyntaxModeProvider(file);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                r3.SetHighlighting("C/C++");

            }


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

            //MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            string sql1 = "select Project_name, Issued_date, Description from bugrecord";
            MySqlCommand cmd1 = new MySqlCommand(sql1, connection);
            MySqlDataReader drd = cmd1.ExecuteReader();
            while (drd.Read())
            {
                ListViewItem lvt = new ListViewItem(drd["Project_name"].ToString());
                lvt.SubItems.Add(drd["Issued_date"].ToString());
                lvt.SubItems.Add(drd["Description"].ToString());
                listView12.Items.Add(lvt);
            }
            connection.Close();
            /*
              connection.Open();
              string sql2 = "select Project_name, Issued_date, Description, Fixed_date from bugrecord b," +
                  " solvebug s where b.Project_name = s.Project_name";
              MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
              MySqlDataReader drd1 = cmd2.ExecuteReader();
              while (drd1.Read())
              {
                  ListViewItem lvt1 = new ListViewItem(drd1["Project_name"].ToString());
                  lvt1.SubItems.Add(drd1["Issued_date"].ToString());
                  lvt1.SubItems.Add(drd1["Description"].ToString());
                  lvt1.SubItems.Add(drd1["Fixed_date"].ToString());
                  listView3.Items.Add(lvt1);
              }
              connection.Close();
              */

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
            textBox9.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','"+ textBox8.Text+"','"+ r3.Text+ "','"+ textBox10.Text+"','"+ pictureBox1 .Image+ "')";
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
                profilepicture.ImageLocation = imagelocation1;
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
