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
    public partial class purchase : Form
    {
        SqlCommand cmd;
       // SqlDataAdapter sda;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2H5KOKN;Initial Catalog=EPMS;Integrated Security=True");
        int P_ID=0;

        private string userType = "";
        public purchase(string type)
        {
            InitializeComponent();
            this.userType = type;
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

        private void perUnitDiscount_TextChanged(object sender, EventArgs e)
        {
            double amount = 0;
            double no_of_unit = 0;
            double per_unit_disc = 0;

            if (total.Text != "")
            {
                amount = Convert.ToDouble(total.Text);
            }

            if (units.Text != "")
            {
                no_of_unit = Convert.ToDouble(units.Text);
            }

            if (perUnitDiscount.Text != "")
            {
                per_unit_disc = Convert.ToDouble(perUnitDiscount.Text);
            }

            double disc = no_of_unit * per_unit_disc;
            double tamount = 0;

            if (disc > 0)
            {
                tamount = amount - disc;
                discount.Text = Convert.ToString(tamount);
                totalAmount.Text = Convert.ToString(disc);
            }
            else
            {
                discount.Text = Convert.ToString(tamount);
                totalAmount.Text = Convert.ToString(amount);
            }
        }

        private void damaged_TextChanged(object sender, EventArgs e)
        {
            double per_unit = 0;
            double dmg = 0;

            if (perUnitDiscount.Text != "")
            {
                per_unit = Convert.ToDouble(perUnitDiscount.Text);
            }

            if (damaged.Text != "")
            {
                dmg = Convert.ToDouble(damaged.Text);
            }

            double damount = dmg * per_unit;
            damagedAmount.Text = Convert.ToString(damount);
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

        private void perUnitDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void damaged_KeyPress(object sender, KeyPressEventArgs e)
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


        private void purchase_Load(object sender, EventArgs e)
        {
            //View All Data of purchase_table.........................
            conn.Open();
            cmd = new SqlCommand("Select * from Purchase2_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void save_Click(object sender, EventArgs e)
        {
            //Save Purchase Detail....................
            conn.Open();
            cmd = new SqlCommand("insert into Purchase2_tbl (Date,Month_year,Farm_name,Units,Type,PerUnit,Total,PerUnitDisc,Discount,TotalAmount,QtyDamage,DamageAmount) values(@Date,@Month_year,@Farm_name,@Units,@Type,@PerUnit,@Total,@PerUnitDisc,@Discount,@TotalAmount,@QtyDamage,@DamageAmount)", conn);
            cmd.Parameters.AddWithValue("@Date",dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Month_year",dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Farm_name",farmName.Text);
            cmd.Parameters.AddWithValue("@Units",units.Text);
            cmd.Parameters.AddWithValue("@Type",type.Text);
            cmd.Parameters.AddWithValue("@PerUnit",perUnit.Text);
            cmd.Parameters.AddWithValue("@Total",total.Text);
            cmd.Parameters.AddWithValue("@PerUnitDisc",perUnitDiscount.Text);
            cmd.Parameters.AddWithValue("@Discount",discount.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount.Text);
            cmd.Parameters.AddWithValue("@QtyDamage",damaged.Text);
            cmd.Parameters.AddWithValue("@DamageAmount",damagedAmount.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Purchase Detail Saved Successfully!");
            conn.Close();
            DisplayData();
            ClearData();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Delete selected detail................................ 
            conn.Open();
            cmd = new SqlCommand("Delete from Purchase2_tbl where ID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", P_ID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Data has been deleted ");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void update_Click(object sender, EventArgs e)
        {
            //Update Purchase Data...................................
            conn.Open();
            cmd = new SqlCommand("Update Purchase2_tbl set Date=@Date,Month_year=@Month_year,Farm_name=@Farm_name,Units=@Units,Type=@Type,PerUnit=@PerUnit,Total=@Total,PerUnitDisc=@PerUnitDisc,Discount=@Discount,TotalAmount=@TotalAmount,QtyDamage=@QtyDamage,DamageAmount=@DamageAmount where ID=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", P_ID);
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Month_year", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Farm_name", farmName.Text);
            cmd.Parameters.AddWithValue("@Units", units.Text);
            cmd.Parameters.AddWithValue("@Type", type.Text);
            cmd.Parameters.AddWithValue("@PerUnit", perUnit.Text);
            cmd.Parameters.AddWithValue("@Total", total.Text);
            cmd.Parameters.AddWithValue("@PerUnitDisc", perUnitDiscount.Text);
            cmd.Parameters.AddWithValue("@Discount", discount.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount.Text);
            cmd.Parameters.AddWithValue("@QtyDamage", damaged.Text);
            cmd.Parameters.AddWithValue("@DamageAmount", damagedAmount.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Selected Purchase Detail has been updates");
            conn.Close();
            DisplayData();
            ClearData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retrieve data on click...............
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                P_ID = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                dateTimePicker1.Text = row.Cells["Date"].Value.ToString();
                farmName.Text = row.Cells["Farm_name"].Value.ToString();
                units.Text = row.Cells["Units"].Value.ToString();
                type.Text = row.Cells["Type"].Value.ToString();
                perUnit.Text = row.Cells["PerUnit"].Value.ToString();
                total.Text = row.Cells["Total"].Value.ToString();
                perUnitDiscount.Text = row.Cells["PerUnitDisc"].Value.ToString();
                discount.Text = row.Cells["Discount"].Value.ToString();
                totalAmount.Text = row.Cells["TotalAmount"].Value.ToString();
                damaged.Text = row.Cells["QtyDamage"].Value.ToString();
                damagedAmount.Text = row.Cells["DamageAmount"].Value.ToString();

            }
            //Show UPDATE and DELETE button on Datagridview Click.......................
            this.update.Visible = true;
            this.delete.Visible = true;
        }
        private void DisplayData()
        {
            //Refresh Data of Datagridview........................
            conn.Open();
            cmd = new SqlCommand("Select * from Purchase2_tbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void ClearData()
        {
            P_ID = 0;
            dateTimePicker1.Text = "";
            farmName.Text = "";
            units.Text = "";
            type.SelectedIndex = -1;
            perUnit.Text ="";
            total.Text = "";
            perUnitDiscount.Text ="";
            discount.Text = "";
            totalAmount.Text = "";
            damaged.Text = "";
            damagedAmount.Text ="";
        }
    }
}
