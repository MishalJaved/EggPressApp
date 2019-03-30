using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EggspressApplication
{
    public partial class menu : Form
    {
        private string userType = "";
        public menu(string type)
        {
            InitializeComponent();
            this.userType = type;
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sales s = new sales(userType);
            this.Hide();
            s.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            purchase p = new purchase(userType);
            this.Hide();
            p.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            expense exp = new expense(userType);
            this.Hide();
            exp.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            addUser au = new addUser(userType);
            this.Hide();
            au.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Reports rp = new Reports(userType);
            this.Hide();
            rp.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
