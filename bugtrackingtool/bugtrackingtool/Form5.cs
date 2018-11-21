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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();
            string sql = "select Username, Password, Email, type, Gender from bugregister";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                ListViewItem lvt = new ListViewItem(drd["Username"].ToString());
                lvt.SubItems.Add(drd["Password"].ToString());
                lvt.SubItems.Add(drd["Email"].ToString());
                lvt.SubItems.Add(drd["type"].ToString());
                lvt.SubItems.Add(drd["Gender"].ToString());
                listView1.Items.Add(lvt);
            }

            connection.Close();

            string file = Application.StartupPath;
            FileSyntaxModeProvider fsmp;
            if (Directory.Exists(file))
            {

                fsmp = new FileSyntaxModeProvider(file);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
                richTextBox1.SetHighlighting("C/C++");

            }
        }

        private void handleProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Visible = false;

        }

      

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void bugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost; database=bugtrackingregister; username=root; password = "); //setting up a profile to establish connection between c# and mysql
            connection.Open();

            String sql = "Insert into bugrecord(Project_name, Line_num_start, Line_num_end, Class_name, Method, Issued_date, Description, Source_file, Image) values" + "('" + textBox7.Text + "','" + textBox11.Text + "', '" +
            textBox9.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','" + textBox8.Text + "','" + richTextBox1.Text + "','" + textBox10.Text + "','" + pictureBox1.Image + "')";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEditorControl2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string imagelocation12 = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png| All Files(*.*)|*.*";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imagelocation12 = dialog.FileName;
                pictureBox1.ImageLocation = imagelocation12;
            }

        }
    }
}
