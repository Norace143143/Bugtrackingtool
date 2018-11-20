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
        }

        private void handleProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // panel1.Visible = true;

        }

      

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }
    }
}
