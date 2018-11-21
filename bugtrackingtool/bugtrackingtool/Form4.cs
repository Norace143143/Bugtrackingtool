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
    public partial class Form4 : Form
    {
        public Form4(string username, string pass)
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            string sql = "select Project_name, Issued_date, Description	from bugrecord";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                ListViewItem lvt = new ListViewItem(drd["Project_name"].ToString());
                lvt.SubItems.Add(drd["Issued_date"].ToString());
                lvt.SubItems.Add(drd["Description"].ToString());
                listView1.Items.Add(lvt);
            }

            connection.Close();


            string file = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(file))
            {

                fsmp = new FileSyntaxModeProvider(file);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                richTextBox2.SetHighlighting("C/C++");

            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            string sql = "insert into solvebug(	Project_name, Author_name, Fixed_date, Code) values " + "('" + textBox6.Text + "','" + textBox7.Text + "', '" +
            textBox8.Text + "','" + richTextBox2.Text + "')"; ;
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
