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
    public partial class sales : Form
    {
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2H5KOKN;Initial Catalog=EPMS;Integrated Security=True");
        private string userType = "";
        int S_ID = 0;
        public sales(string type)
        {
            InitializeComponent();
            this.userType = type;
        }

        private void sales_Load(object sender, EventArgs e)
        {
            //View All Data of Sale_table.........................
            conn.Open();
            cmd = new SqlCommand("Select * from Sale_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();

            //Populate comboBox foR CustomerName.................
            {
                conn.Open();
                cmd = new SqlCommand("select name from AddUser_tbl", conn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {

                    partyName.Items.Add(dr1["name"].ToString());
                }
                conn.Close();
            }

            //Populate comboBox foR area.................
            {
                conn.Open();
                cmd = new SqlCommand("select address from AddUser_tbl", conn);
                SqlDataReader dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {

                    area.Items.Add(dr2["address"].ToString());
                }
                conn.Close();
            }

            //Populate comboBox foR Salesman.................
            {
                conn.Open();
                cmd = new SqlCommand("select Salesman from Salesman_tbl", conn);
                SqlDataReader dr3 = cmd.ExecuteReader();
                while (dr3.Read())
                {

                    salesman.Items.Add(dr3["Salesman"].ToString());
                }
                conn.Close();
                DisplayData();
                ClearData();
            }
        }

        private void units_TextChanged(object sender, EventArgs e)
        {
            double per_units = 0;
            double no_of_units = 0;

            if (perUnit.Text != "")
            {
                per_units = Convert.ToDouble(perUnit.Text);
            }

            if (units.Text != "")
            {
                no_of_units = Convert.ToDouble(units.Text);
            }

            double amount = no_of_units * per_units;
            total.Text = Convert.ToString(amount);
        }

        private void perUnit_TextChanged(object sender, EventArgs e)
        {
            double no_of_units = 0;
            double per_unit = 0;

            if (units.Text != "")
            {
                no_of_units = Convert.ToDouble(units.Text);
            }

            if (perUnit.Text != "")
            {
                per_unit = Convert.ToDouble(perUnit.Text);
            }

            double amount = no_of_units * per_unit;
            total.Text = Convert.ToString(amount);
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
            double amount = 0;
            double disc = 0;

            if (discount.Text != "")
            {
                disc = Convert.ToDouble(discount.Text);
            }

            if (total.Text != "")
            {
                amount = Convert.ToDouble(total.Text);
            }

            double tamount = amount - disc;
            totalAmount.Text = Convert.ToString(tamount);
        }

        private void cashRecieve_TextChanged(object sender, EventArgs e)
        {
            double tamount = 0;
            double cash = 0;

            if (cashRecieve.Text != "")
            {
                cash = Convert.ToDouble(cashRecieve.Text);
            }

            if (totalAmount.Text != "")
            {
                tamount = Convert.ToDouble(totalAmount.Text);
            }

            double bal = tamount - cash;
            balance.Text = Convert.ToString(bal);
        }

        private void units_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void perUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void cashRecieve_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
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
            //Save Sales Detail....................
            conn.Open();
            cmd = new SqlCommand("insert into Sale_tbl (Date,Month_year,PartyName,Area,Units,Type,PerUnit,Salesman,Total,Discount,TotalAmount,CashRecieve,Balance) values(@Date,@Month_year,@PartyName,@Area,@Units,@Type,@PerUnit,@Salesman,@Total,@Discount,@TotalAmount,@CashRecieve,@Balance)", conn);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Month_year", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@PartyName", partyName.Text);
            cmd.Parameters.AddWithValue("@Area", area.Text);
            cmd.Parameters.AddWithValue("@Units", units.Text);
            cmd.Parameters.AddWithValue("@Type", type.Text);
            cmd.Parameters.AddWithValue("@PerUnit", perUnit.Text);
            cmd.Parameters.AddWithValue("@Salesman", salesman.Text);
            cmd.Parameters.AddWithValue("@Total", total.Text);
            cmd.Parameters.AddWithValue("@Discount", discount.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount.Text);
            cmd.Parameters.AddWithValue("@CashRecieve", cashRecieve.Text);
            cmd.Parameters.AddWithValue("@Balance", balance.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sales Detail Saved Successfully!");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void update_Click(object sender, EventArgs e)
        {
            //Update Sales Data...................................
            conn.Open();
            cmd = new SqlCommand("Update Sale_tbl set Date=@Date,Month_year=@Month_year,PartyName=@PartyName,Area=@Area,Units=@Units,Type=@Type,PerUnit=@PerUnit,Salesman=@Salesman,Total=@Total,Discount=@Discount,TotalAmount=@TotalAmount,CashRecieve=@CashRecieve,Balance=@Balance where ID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", S_ID);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Month_year", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@PartyName", partyName.Text);
            cmd.Parameters.AddWithValue("@Area", area.Text);
            cmd.Parameters.AddWithValue("@Units", units.Text);
            cmd.Parameters.AddWithValue("@Type", type.Text);
            cmd.Parameters.AddWithValue("@PerUnit", perUnit.Text);
            cmd.Parameters.AddWithValue("@Salesman", salesman.Text);
            cmd.Parameters.AddWithValue("@Total", total.Text);
            cmd.Parameters.AddWithValue("@Discount", discount.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount.Text);
            cmd.Parameters.AddWithValue("@CashRecieve", cashRecieve.Text);
            cmd.Parameters.AddWithValue("@Balance", balance.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Detail has been updates");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Delete selected detail................................ 
            conn.Open();
            cmd = new SqlCommand("Delete from Sale_tbl where ID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", S_ID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been deleted ");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //Add Salesman....................
            conn.Open();
            cmd = new SqlCommand("insert into Salesman_tbl (Salesman)values(@Salesman)", conn);
            cmd.Parameters.AddWithValue("@Salesman", this.addSalesman.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Salesman added Successfully!");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retrieve data on click...............
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                S_ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                dateTimePicker1.Text = row.Cells["Date"].Value.ToString();
                partyName.Text = row.Cells["PartyName"].Value.ToString();
                area.Text = row.Cells["Area"].Value.ToString();
                units.Text = row.Cells["Units"].Value.ToString();
                type.Text = row.Cells["Type"].Value.ToString();
                perUnit.Text = row.Cells["PerUnit"].Value.ToString();
                salesman.Text = row.Cells["Salesman"].Value.ToString();
                total.Text = row.Cells["Total"].Value.ToString();
                discount.Text = row.Cells["Discount"].Value.ToString();
                totalAmount.Text = row.Cells["TotalAmount"].Value.ToString();
                cashRecieve.Text = row.Cells["CashRecieve"].Value.ToString();
                balance.Text = row.Cells["Balance"].Value.ToString();
            }
            //Show UPDATE and DELETE button on Datagridview Click.......................
            this.delete.Visible = true;
            this.update.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void DisplayData()
        {
            //Refresh Data of Datagridview........................
            conn.Open();
            cmd = new SqlCommand("Select * from Sale_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void ClearData()
        {
            S_ID = 0;
            dateTimePicker1.Text ="";
            partyName.SelectedIndex = -1;
            area.SelectedIndex = -1;
            units.Text = "";
            type.SelectedIndex = -1;
            perUnit.Text = "";
            salesman.SelectedIndex = -1;
            total.Text = "";
            discount.Text = "";
            totalAmount.Text = "";
            cashRecieve.Text = "";
            balance.Text = "";
            addSalesman.Text = "";
        }
    }
}
