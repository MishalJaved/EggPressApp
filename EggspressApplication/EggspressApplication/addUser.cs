using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace EggspressApplication
{
    public partial class addUser : Form
    {
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2H5KOKN;Initial Catalog=EPMS;Integrated Security=True");

        private string userType = "";
        public addUser(string type)
        {
            InitializeComponent();
            this.userType = type;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            menu m = new menu(userType);
            this.Hide();
            m.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            //Save user add.........
            conn.Open();
            cmd = new SqlCommand("insert into AddUser_tbl (name,address) values(@name,@address)", conn);
            cmd.Parameters.AddWithValue("@name", this.name.Text);
            cmd.Parameters.AddWithValue("@address", this.address.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Added Successfully!");
            conn.Close();
            DisplayData();
            ClearData();
        }


        private void addUser_Load(object sender, EventArgs e)
        {
            {
               
                //View All Data Of Customer.............................
                conn.Open();
                cmd = new SqlCommand("Select * from AddUser_tbl", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retrieve data on click...............
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                name.Text = row.Cells["name"].Value.ToString();
                address.Text = row.Cells["address"].Value.ToString();
            }
        }
        private void DisplayData()
        {
            //Refresh Data of Datagridview........................
            conn.Open();
            cmd = new SqlCommand("Select * from AddUser_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void ClearData()
        {
            name.Text = "";
            address.Text = "";
        }
    }
}
