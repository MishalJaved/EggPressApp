using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace EggspressApplication
{
    public partial class expense : Form
    {
        SqlCommand cmd;
        //SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2H5KOKN;Initial Catalog=EPMS;Integrated Security=True");

        int ID = 0;

        private string userType = "";
        public expense(string type)
        {
            InitializeComponent();
            this.userType = type;
        }

        private void expense_Load(object sender, EventArgs e)
        {
            
            //View All Data of expense_table.........................
            conn.Open();
            cmd = new SqlCommand("Select * from Expense1_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            menu m = new menu(userType);
            this.Hide();
            m.ShowDialog();
        }

        private void save_Click(object sender, EventArgs e)
        {
           
            //Save Expense Detail....................
            conn.Open();
            cmd = new SqlCommand("insert into Expense1_tbl (Date,Month_year,Type,expDetail,totalAmount) values(@Date,@Month_year,@Type,@expDetail,@totalAmount)", conn);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM-yyyy";
            cmd.Parameters.AddWithValue("@Month_year",dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Type", type.Text);
            cmd.Parameters.AddWithValue("@expDetail", expDetail.Text);
            cmd.Parameters.AddWithValue("@totalAmount", totalAmount.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Expense Detail Saved Successfully!");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Delete selected detail................................ 
            conn.Open();
            cmd = new SqlCommand("Delete from Expense1_tbl where Exp_ID=@Exp_ID", conn);
            cmd.Parameters.AddWithValue("@Exp_ID", ID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been deleted ");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void update_Click(object sender, EventArgs e)
        {
            //Update Expense Data...................................
              conn.Open();
              cmd = new SqlCommand("Update Expense1_tbl set Date=@Date,Type=@Type,expDetail=@expDetail,totalAmount=@totalAmount where Exp_ID=@Exp_ID", conn);
              cmd.Parameters.AddWithValue("@Exp_ID", ID);
              cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
              cmd.Parameters.AddWithValue("@Type", type.Text);
              cmd.Parameters.AddWithValue("@expDetail", expDetail.Text);
            cmd.Parameters.AddWithValue("@totalAmount", totalAmount.Text);
            cmd.ExecuteNonQuery();
              MessageBox.Show("Selected Detail has been updates");
              conn.Close();
              DisplayData();
              ClearData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retrieve data on click...............
            if (e.RowIndex >= 0)
            {
               
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                ID = Convert.ToInt32(row.Cells["Exp_ID"].Value.ToString());
                dateTimePicker1.Text = row.Cells["Date"].Value.ToString();
                type.Text = row.Cells["Type"].Value.ToString();
                expDetail.Text = row.Cells["expDetail"].Value.ToString();
                totalAmount.Text = row.Cells["totalAmount"].Value.ToString();
            }
            //Show UPDATE and DELETE button on Datagridview Click.......................
            this.delete.Visible = true;
            this.update.Visible = true;
        }
       private void DisplayData()
        {
            //Refresh Data of Datagridview........................
            conn.Open();
            cmd = new SqlCommand("Select * from Expense1_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void ClearData()
        {
            this.dateTimePicker1.Text="";
            this.type.SelectedIndex = -1;
            this.expDetail.Text = "";
            this.totalAmount.Text = "";
            ID = 0;
        }
    }
}