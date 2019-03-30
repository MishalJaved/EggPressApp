using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;


namespace EggspressApplication
{
    public partial class Reports : Form
    {
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2H5KOKN;Initial Catalog=EPMS;Integrated Security=True");
        private string userType = "";
        public Reports(string type)
        {
            InitializeComponent();
            this.userType = type;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ePMSDataSet16.Sale_tbl' table. You can move, or remove it, as needed.
            this.sale_tblTableAdapter6.Fill(this.ePMSDataSet16.Sale_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet15.Purchase2_tbl' table. You can move, or remove it, as needed.
            this.purchase2_tblTableAdapter3.Fill(this.ePMSDataSet15.Purchase2_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet14.Sale_tbl' table. You can move, or remove it, as needed.
            this.sale_tblTableAdapter5.Fill(this.ePMSDataSet14.Sale_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet13.Sale_tbl' table. You can move, or remove it, as needed.
            this.sale_tblTableAdapter4.Fill(this.ePMSDataSet13.Sale_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet11.Sale_tbl' table. You can move, or remove it, as needed.
            this.sale_tblTableAdapter3.Fill(this.ePMSDataSet11.Sale_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet10.Purchase2_tbl' table. You can move, or remove it, as needed.
            this.purchase2_tblTableAdapter2.Fill(this.ePMSDataSet10.Purchase2_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet9.Purchase2_tbl' table. You can move, or remove it, as needed.
            this.purchase2_tblTableAdapter1.Fill(this.ePMSDataSet9.Purchase2_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet8.Expense1_tbl' table. You can move, or remove it, as needed.
            this.expense1_tblTableAdapter1.Fill(this.ePMSDataSet8.Expense1_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet7.Sale_tbl' table. You can move, or remove it, as needed.
            this.sale_tblTableAdapter2.Fill(this.ePMSDataSet7.Sale_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet6.Sale_tbl' table. You can move, or remove it, as needed.
            this.sale_tblTableAdapter1.Fill(this.ePMSDataSet6.Sale_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet5.Salesman_tbl' table. You can move, or remove it, as needed.
            this.salesman_tblTableAdapter.Fill(this.ePMSDataSet5.Salesman_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet4.Sale_tbl' table. You can move, or remove it, as needed.
            this.sale_tblTableAdapter.Fill(this.ePMSDataSet4.Sale_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet3.Purchase2_tbl' table. You can move, or remove it, as needed.
            this.purchase2_tblTableAdapter.Fill(this.ePMSDataSet3.Purchase2_tbl);
            // TODO: This line of code loads data into the 'ePMSDataSet2.Expense1_tbl' table. You can move, or remove it, as needed.
            this.expense1_tblTableAdapter.Fill(this.ePMSDataSet2.Expense1_tbl);

            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.Customer_Report_Pnl.Visible = false;

            this.dataGridView3.Visible = false;//profit loss expense report datagridview
            this.dataGridView5.Visible = false;//profit loss Purchase report datagridview
            this.dataGridView6.Visible = false;//profit loss Sale report datagridview

            //Populate comboBox foR Farm Name (PURCHASE REPORT).................
            {
                conn.Open();
                cmd = new SqlCommand("select Farm_name from Purchase2_tbl", conn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    comboBox7.Items.Add(dr1["Farm_name"].ToString());
                    comboBox2.Items.Add(dr1["Farm_name"].ToString());
                }
                conn.Close();
            }

            //Populate comboBox foR Salesman (Sales Report).................
            {
                conn.Open();
                cmd = new SqlCommand("select Salesman from Salesman_tbl", conn);
                SqlDataReader dr3 = cmd.ExecuteReader();
                while (dr3.Read())
                {

                    comboBox4.Items.Add(dr3["Salesman"].ToString());
                    comboBox11.Items.Add(dr3["Salesman"].ToString());
                }
                conn.Close();
            }
            //Populate comboBox foR Customer Name (Customer REPORT).................
            {
                conn.Open();
                cmd = new SqlCommand("select partyName from Sale_tbl", conn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                while (dr1.Read())
                {
                    CR_custname.Items.Add(dr1["partyName"].ToString());
                }
                conn.Close();
            }
        }

        private void ExportToPDF_Click(object sender, EventArgs e)
        {
            //Export to PDF EXPENSE DATA...................................
            ExportgridtoPDF_ExpenseReport(dataGridView1, "Expense1_tbl");
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void expense1tblBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Export to PDF PURCHASE DATA....................................
            ExportgridtoPDF_Purchase_Report(dataGridView2, "Purchase2_tbl");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportgridtoPDF_SaleReport(dataGridView4, "Sale_tbl");
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Purchase
            this.panel2.Visible = true;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        //Prfit loss Report Button.....................................................
        private void button5_Click(object sender, EventArgs e)
        {

            // this.panel2.Visible = false;
            // this.panel4.Visible = false;
            //this.panel5.Visible = false;
            this.panel3.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {//sales

            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel5.Visible = false;
            this.panel4.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {//expense

            // this.panel2.Visible = false;
            //this.panel3.Visible = false;
            //this.panel4.Visible = false;
            this.panel5.Visible = true;
        }
        //GPBOX2 disable..................................................
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = false;
        }
        //GPBOX2 disable..................................................
        private void dateTimePicker1_MouseHover(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = false;
        }
        //GPBOX2 disable..................................................
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = false;
        }
        //GPBOX2 disable..................................................
        private void dateTimePicker2_MouseHover(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = false;
        }
        //GPBOX2 enable..................................................
        private void dateTimePicker2_MouseLeave(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = true;
        }
        //GPBOX2 enable..................................................
        private void dateTimePicker1_MouseLeave(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;
        }//Expense Report Code ends here..........................................
        //.........................................................................................................

        private void SEARCH_Click(object sender, EventArgs e)
        {
            { //Data retrieving by Date................................
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Expense1_tbl where Date between '" + dateTimePicker1.Value.ToString() + "'and'" + dateTimePicker2.Value.ToString() + "'", conn);
                DataTable sd = new DataTable();
                sda.Fill(sd);
                dataGridView1.DataSource = sd;
                int Sum_NetExpense = Convert.ToInt32(sd.Compute("SUM(totalAmount)", string.Empty));
                this.textBox10.Text = Sum_NetExpense.ToString();
                conn.Close();

            }
            //Data retrieving by ID................................
            {
                if (textBox1.Text != "" && comboBox3.Text == "")
                {
                    conn.Open();
                    cmd = new SqlCommand("Select * from Expense1_tbl where Exp_ID=@Exp_ID", conn);
                    cmd.Parameters.AddWithValue("@Exp_ID", textBox1.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;

                    int Sum_NetExpense = Convert.ToInt32(dt.Compute("SUM(totalAmount)", string.Empty));
                    this.textBox10.Text = Sum_NetExpense.ToString();
                    conn.Close();
                    ClearData();
                }
            }
            //Data retrieving by type in expense report................................
            {
                if (comboBox3.Text != "" && textBox1.Text == "")
                {
                    conn.Open();
                    cmd = new SqlCommand("Select * from Expense1_tbl where Type=@Type", conn);
                    cmd.Parameters.AddWithValue("@Type", comboBox3.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                    int Sum_NetExpense = Convert.ToInt32(dt.Compute("SUM(totalAmount)", string.Empty));
                    this.textBox10.Text = Sum_NetExpense.ToString();
                    conn.Close();
                    ClearData();
                }
            }
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            menu m = new menu(userType);
            this.Hide();
            m.ShowDialog();
        }
        private void ClearData()
        {
            this.textBox1.Text = "";
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            this.comboBox4.Text = "";
            this.comboBox5.Text = "";
            this.CR_custname.Text = "";
        }

        //.........................................................................................................
        //PURCHASE Report Code starts here..........................................
        private void button8_Click(object sender, EventArgs e)
        {

            { //Data retrieving by Date in purchase report................................
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Purchase2_tbl where Date between '" + dateTimePicker3.Value.ToString() + "'and'" + dateTimePicker4.Value.ToString() + "'", conn);
                DataTable sd = new DataTable();
                sda.Fill(sd);
                dataGridView2.DataSource = sd;

                //Calculating Total.................................................
                int Sum_NetUnit = Convert.ToInt32(sd.Compute("SUM(Units)", string.Empty));
                this.textBox2.Text = Sum_NetUnit.ToString();
                int sum_disc = Convert.ToInt32(sd.Compute("SUM(Discount)", string.Empty));
                this.textBox3.Text = sum_disc.ToString();
                int Sum_NetAmount = Convert.ToInt32(sd.Compute("SUM(TotalAmount)", string.Empty));
                this.textBox4.Text = Sum_NetAmount.ToString();
                int Sum_QtyDmg = Convert.ToInt32(sd.Compute("SUM(QtyDamage)", string.Empty));
                this.textBox5.Text = Sum_QtyDmg.ToString();
                int Sum_DmgAmount = Convert.ToInt32(sd.Compute("SUM(DamageAmount)", string.Empty));
                this.textBox8.Text = Sum_DmgAmount.ToString();
                int TotalPurchaseAmount = Convert.ToInt32(textBox4.Text) - Convert.ToInt32(textBox8.Text);
                this.textBox9.Text = TotalPurchaseAmount.ToString();

                conn.Close();

            }
            //Data retrieving by type in purchase report................................
            {
                if (comboBox1.Text != "" && comboBox2.Text == "")
                {
                    conn.Open();
                    cmd = new SqlCommand("Select * from Purchase2_tbl where Type=@Type", conn);
                    cmd.Parameters.AddWithValue("@Type", comboBox1.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;

                    //Calculating Total.................................................
                    int Sum_NetUnit = Convert.ToInt32(dt.Compute("SUM(Units)", string.Empty));
                    this.textBox2.Text = Sum_NetUnit.ToString();
                    int sum_disc = Convert.ToInt32(dt.Compute("SUM(Discount)", string.Empty));
                    this.textBox3.Text = sum_disc.ToString();
                    int Sum_NetAmount = Convert.ToInt32(dt.Compute("SUM(TotalAmount)", string.Empty));
                    this.textBox4.Text = Sum_NetAmount.ToString();
                    int Sum_QtyDmg = Convert.ToInt32(dt.Compute("SUM(QtyDamage)", string.Empty));
                    this.textBox5.Text = Sum_QtyDmg.ToString();
                    int Sum_DmgAmount = Convert.ToInt32(dt.Compute("SUM(DamageAmount)", string.Empty));
                    this.textBox8.Text = Sum_DmgAmount.ToString();
                    int TotalPurchaseAmount = Convert.ToInt32(textBox4.Text) - Convert.ToInt32(textBox8.Text);
                    this.textBox9.Text = TotalPurchaseAmount.ToString();

                    conn.Close();
                    ClearData();
                }

            }
            {   //Data retrieving by Farm Name in purchase report................................
                if (comboBox2.Text != "" && comboBox1.Text == "")
                {
                    conn.Open();
                    cmd = new SqlCommand("Select * from Purchase2_tbl where Farm_name=@Farm_name", conn);
                    cmd.Parameters.AddWithValue("@Farm_name", comboBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;

                    //Calculating Total.................................................
                    int Sum_NetUnit = Convert.ToInt32(dt.Compute("SUM(Units)", string.Empty));
                    this.textBox2.Text = Sum_NetUnit.ToString();
                    int sum_disc = Convert.ToInt32(dt.Compute("SUM(Discount)", string.Empty));
                    this.textBox3.Text = sum_disc.ToString();
                    int Sum_NetAmount = Convert.ToInt32(dt.Compute("SUM(TotalAmount)", string.Empty));
                    this.textBox4.Text = Sum_NetAmount.ToString();
                    int Sum_QtyDmg = Convert.ToInt32(dt.Compute("SUM(QtyDamage)", string.Empty));
                    this.textBox5.Text = Sum_QtyDmg.ToString();
                    int Sum_DmgAmount = Convert.ToInt32(dt.Compute("SUM(DamageAmount)", string.Empty));
                    this.textBox8.Text = Sum_DmgAmount.ToString();
                    int TotalPurchaseAmount = Convert.ToInt32(textBox4.Text) - Convert.ToInt32(textBox8.Text);
                    this.textBox9.Text = TotalPurchaseAmount.ToString();

                    conn.Close();
                    ClearData();
                }
            }



        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = false;
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = false;
        }

        private void dateTimePicker3_MouseHover(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = false;
        }

        private void dateTimePicker3_MouseLeave(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = true;
        }

        private void dateTimePicker4_MouseHover(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = false;
        }

        private void dateTimePicker4_MouseLeave(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.groupBox4.Enabled = false;
            this.textBox11.Text = this.comboBox1.Text;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            this.groupBox4.Enabled = true;
        }

        // Data Export to PDF (PURCHASE REPORT)..................................................................
        public void ExportgridtoPDF_Purchase_Report(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);


            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                    PdfWriter.GetInstance(pdfdoc, stream);

                    Paragraph pghead = new Paragraph("EggPress Application");
                    pghead.Alignment = Element.ALIGN_CENTER;
                    pghead.Font.Size = 24;
                    Paragraph Reportname = new Paragraph("Monthly Purchase Report");
                    Reportname.Alignment = Element.ALIGN_CENTER;
                    Reportname.Font.Size = 20;
                    Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                    date.Alignment = Element.ALIGN_LEFT;
                    date.Font.Size = 16;
                    Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline = new Paragraph("\n");
                    Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Chunk c1 = new Chunk("|\nNet Units of Egg:   ");
                    Chunk c2 = new Chunk("|\t\tNet Discount:   ");
                    Chunk c3 = new Chunk("|\t\tNet Amount:   ");
                    Chunk c4 = new Chunk("|\t\tQuantity Damage:   ");
                    Chunk c5 = new Chunk("\nDamage Amount:   ");
                    Paragraph line3 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline3 = new Paragraph("\n");
                    Chunk c6 = new Chunk("Total Purchase Amount:   ");
                    Chunk c7 = new Chunk("\nType of Egg   ");
                    Paragraph line4 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    pdfdoc.Open();

                    pdfdoc.Add(pghead);
                    pdfdoc.Add(Reportname);
                    pdfdoc.Add(date);
                    pdfdoc.Add(line1);
                    pdfdoc.Add(breakline);
                    pdfdoc.Add(c7);
                    pdfdoc.Add(new Phrase(this.textBox11.Text.Trim()));
                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(line2);
                    pdfdoc.Add(c1);
                    pdfdoc.Add(new Phrase(this.textBox2.Text.Trim()));
                    pdfdoc.Add(c2);
                    pdfdoc.Add(new Phrase(this.textBox3.Text.Trim()));
                    pdfdoc.Add(c3);
                    pdfdoc.Add(new Phrase(this.textBox4.Text.Trim()));
                    pdfdoc.Add(c4);
                    pdfdoc.Add(new Phrase(this.textBox5.Text.Trim()));
                    pdfdoc.Add(c5);
                    pdfdoc.Add(new Phrase(this.textBox8.Text.Trim()));
                    pdfdoc.Add(line3);
                    pdfdoc.Add(breakline3);
                    pdfdoc.Add(c6);
                    pdfdoc.Add(new Phrase(this.textBox9.Text.Trim()));
                    pdfdoc.Add(line4);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        // Data Export to PDF (EXPENSE REPORT)..................................................................
        public void ExportgridtoPDF_ExpenseReport(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);


            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                    PdfWriter.GetInstance(pdfdoc, stream);

                    Paragraph pghead = new Paragraph("EggPress Application");
                    pghead.Alignment = Element.ALIGN_CENTER;
                    pghead.Font.Size = 24;
                    Paragraph Reportname = new Paragraph("Monthly Expense Report");
                    Reportname.Alignment = Element.ALIGN_CENTER;
                    Reportname.Font.Size = 20;
                    Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                    date.Alignment = Element.ALIGN_LEFT;
                    date.Font.Size = 16;
                    Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline = new Paragraph("\n");
                    Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Chunk c1 = new Chunk("\nExpense Type:   ");

                    Paragraph line3 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Chunk c2 = new Chunk("Total Purchase Amount:   ");

                    pdfdoc.Open();
                    pdfdoc.Add(pghead);
                    pdfdoc.Add(Reportname);
                    pdfdoc.Add(date);
                    pdfdoc.Add(line1);
                    pdfdoc.Add(c1);
                    pdfdoc.Add(new Phrase(this.textBox6.Text.Trim()));
                    pdfdoc.Add(breakline);
                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(line2);
                    pdfdoc.Add(c2);
                    pdfdoc.Add(new Phrase(this.textBox10.Text.Trim()));
                    pdfdoc.Add(line3);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        // Data Export to PDF (Sale REPORT)..................................................................
        public void ExportgridtoPDF_SaleReport(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);


            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                    PdfWriter.GetInstance(pdfdoc, stream);


                    Paragraph pghead = new Paragraph("EggPress Application");
                    pghead.Alignment = Element.ALIGN_CENTER;
                    pghead.Font.Size = 24;
                    Paragraph Reportname = new Paragraph("Monthly Sale Report");
                    Reportname.Alignment = Element.ALIGN_CENTER;
                    Reportname.Font.Size = 20;
                    Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                    date.Alignment = Element.ALIGN_LEFT;
                    date.Font.Size = 16;
                    Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline = new Paragraph("\n");
                    Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Chunk c1 = new Chunk("|\nNet Units of Egg:   ");
                    Chunk c2 = new Chunk("|\t\tNet Discount:   ");
                    Chunk c3 = new Chunk("|\t\tNet Amount:   ");
                    Chunk c4 = new Chunk("|\t\tCash Recieve:   ");
                    Chunk c5 = new Chunk("\nTotal Balance:   ");
                    Chunk c7 = new Chunk("\nType of Egg:   ");
                    Chunk c6 = new Chunk("\nSalesman:   ");
                    Paragraph line4 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    pdfdoc.Open();

                    pdfdoc.Add(pghead);
                    pdfdoc.Add(Reportname);
                    pdfdoc.Add(date);
                    pdfdoc.Add(line1);
                    pdfdoc.Add(breakline);
                    pdfdoc.Add(c6);
                    pdfdoc.Add(new Phrase(this.textBox12.Text.Trim()));
                    pdfdoc.Add(c7);
                    pdfdoc.Add(new Phrase(this.textBox14.Text.Trim()));
                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(line2);
                    pdfdoc.Add(c1);
                    pdfdoc.Add(new Phrase(this.textBox15.Text.Trim()));
                    pdfdoc.Add(c2);
                    pdfdoc.Add(new Phrase(this.textBox16.Text.Trim()));
                    pdfdoc.Add(c3);
                    pdfdoc.Add(new Phrase(this.textBox17.Text.Trim()));
                    pdfdoc.Add(c4);
                    pdfdoc.Add(new Phrase(this.textBox18.Text.Trim()));
                    pdfdoc.Add(c5);
                    pdfdoc.Add(new Phrase(this.textBox19.Text.Trim()));
                    pdfdoc.Add(line4);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        // Data Export to PDF (Customer REPORT)..................................................................
        public void ExportgridtoPDF_CustomerReport(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);


            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                    PdfWriter.GetInstance(pdfdoc, stream);


                    Paragraph pghead = new Paragraph("EggPress Application");
                    pghead.Alignment = Element.ALIGN_CENTER;
                    pghead.Font.Size = 24;
                    Paragraph Reportname = new Paragraph("Monthly Customer Report");
                    Reportname.Alignment = Element.ALIGN_CENTER;
                    Reportname.Font.Size = 20;
                    Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                    date.Alignment = Element.ALIGN_LEFT;
                    date.Font.Size = 16;
                    Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline = new Paragraph("\n");
                    Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Chunk c1 = new Chunk("|\nNet Units of Egg:   ");
                    Chunk c2 = new Chunk("|\t\tNet Discount:   ");
                    Chunk c3 = new Chunk("|\t\tNet Amount:   ");
                    Chunk c4 = new Chunk("|\t\tCash Recieve:   ");
                    Chunk c5 = new Chunk("\nTotal Balance:   ");
                  
                    Paragraph line4 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    pdfdoc.Open();

                    pdfdoc.Add(pghead);
                    pdfdoc.Add(Reportname);
                    pdfdoc.Add(date);
                    pdfdoc.Add(line1);
                    pdfdoc.Add(breakline);
                   
                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(line2);
                    pdfdoc.Add(c1);
                    pdfdoc.Add(new Phrase(this.textBox25.Text.Trim()));
                    pdfdoc.Add(c2);
                    pdfdoc.Add(new Phrase(this.textBox24.Text.Trim()));
                    pdfdoc.Add(c3);
                    pdfdoc.Add(new Phrase(this.textBox23.Text.Trim()));
                    pdfdoc.Add(c4);
                    pdfdoc.Add(new Phrase(this.textBox22.Text.Trim()));
                    pdfdoc.Add(c5);
                    pdfdoc.Add(new Phrase(this.textBox21.Text.Trim()));
                    pdfdoc.Add(line4);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }
        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox6.Text = this.comboBox3.Text;   //reflecting Expense type
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Text = comboBox2.Text; // Reflecting farm name
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.groupBox8.Enabled = false;
            this.textBox12.Text = comboBox4.Text;

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.groupBox8.Enabled = false;
            this.textBox14.Text = comboBox5.Text;
        }

        //Groupbox 7 deisable(Sales REport)...........................................................
        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            this.groupBox7.Enabled = false;
        }

        private void dateTimePicker5_MouseHover(object sender, EventArgs e)
        {
            this.groupBox7.Enabled = false;
        }

        private void dateTimePicker5_Leave(object sender, EventArgs e)
        {
            this.groupBox7.Enabled = true;
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            this.groupBox7.Enabled = false;
        }

        private void dateTimePicker6_MouseHover(object sender, EventArgs e)
        {
            this.groupBox7.Enabled = false;
        }

        private void dateTimePicker6_Leave(object sender, EventArgs e)
        {
            this.groupBox7.Enabled = true;
        }

        //Groupbox 8 deisable(Sales REport)...........................................................
        private void comboBox4_MouseHover(object sender, EventArgs e)
        {
            this.groupBox8.Enabled = false;
        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            this.groupBox8.Enabled = true;
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            this.groupBox8.Enabled = true;
        }

        private void comboBox5_MouseHover(object sender, EventArgs e)
        {
            this.groupBox8.Enabled = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {//sale
            this.panel4.Visible = true;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel5.Visible = false;
        }

        //SaleReport Search data code.....................................................
        private void button10_Click(object sender, EventArgs e)
        {
            { //Data retrieving by Date................................
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from Sale_tbl where Date between '" + dateTimePicker5.Value.ToString() + "'and'" + dateTimePicker6.Value.ToString() + "'", conn);
                DataTable sd = new DataTable();
                sda.Fill(sd);
                dataGridView4.DataSource = sd;

                int sum = sd.AsEnumerable().Sum(row => row.Field<int>("Units"));
                this.textBox15.Text = sum.ToString();
                int sum_disc = sd.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                this.textBox16.Text = sum_disc.ToString();
                int sum_tamount = sd.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                this.textBox17.Text = sum_tamount.ToString();
                int sum_cashrec = sd.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                this.textBox18.Text = sum_cashrec.ToString();
                int sum_balance = sd.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                this.textBox19.Text = sum_balance.ToString();
                conn.Close();


            }
            //Data retrieving by Salesman................................
            {
                if (comboBox4.Text != "" && comboBox5.Text == "")
                {
                    conn.Open();
                    cmd = new SqlCommand("Select * from Sale_tbl where Salesman=@Salesman", conn);
                    cmd.Parameters.AddWithValue("@Salesman", comboBox4.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView4.DataSource = dt;

                    int sum = dt.AsEnumerable().Sum(row => row.Field<int>("Units"));
                    this.textBox15.Text = sum.ToString();
                    int sum_disc = dt.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                    this.textBox16.Text = sum_disc.ToString();
                    int sum_tamount = dt.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                    this.textBox17.Text = sum_tamount.ToString();
                    int sum_cashrec = dt.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                    this.textBox18.Text = sum_cashrec.ToString();
                    int sum_balance = dt.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                    this.textBox19.Text = sum_balance.ToString();
                    conn.Close();
                    ClearData();
                }
            }
            //Data retrieving by type in Sale report................................
            {
                if (comboBox5.Text != "" && comboBox4.Text == "")
                {
                    conn.Open();
                    cmd = new SqlCommand("Select * from Sale_tbl where Type=@Type", conn);
                    cmd.Parameters.AddWithValue("@Type", comboBox5.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView4.DataSource = dt;
                    int sum = dt.AsEnumerable().Sum(row => row.Field<int>("Units"));
                    this.textBox15.Text = sum.ToString();
                    int sum_disc = dt.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                    this.textBox16.Text = sum_disc.ToString();
                    int sum_tamount = dt.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                    this.textBox17.Text = sum_tamount.ToString();
                    int sum_cashrec = dt.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                    this.textBox18.Text = sum_cashrec.ToString();
                    int sum_balance = dt.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                    this.textBox19.Text = sum_balance.ToString();


                    conn.Close();
                    ClearData();
                }
            }
        }

        //Profit Loss Statement......................................................................................
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView3.Visible == true)
            {
                // Expense Data Retrieve..........................................
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Expense1_tbl where Type=@Type and Date between '" + dateTimePicker7.Value.ToString() + "'and'" + dateTimePicker8.Value.ToString() + "'", conn);
                cmd.Parameters.AddWithValue("@Type", comboBox6.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView4.DataSource = dt;
                int sum_totalexpense = dt.AsEnumerable().Sum(row => row.Field<int>("totalAmount"));
                this.label42.Text = sum_totalexpense.ToString();
                conn.Close();
            }

            if (dataGridView5.Visible == true)
            {
                // Purchase Data Retrieve..........................................
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Purchase2_tbl where Farm_name=@Farm_name and Date between '" + dateTimePicker7.Value.ToString() + "'and'" + dateTimePicker8.Value.ToString() + "'", conn);
                cmd.Parameters.AddWithValue("@Farm_name", comboBox7.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView5.DataSource = dt;
                int sum_eggunit = dt.AsEnumerable().Sum(row => row.Field<int>("Units"));
                this.label44.Text = sum_eggunit.ToString();
                int sum_disc = dt.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                this.label48.Text = sum_disc.ToString();
                int sum_Dmgamt = dt.AsEnumerable().Sum(row => row.Field<int>("DamageAmount"));
                this.label49.Text = sum_Dmgamt.ToString();
                int sum_totalpuchase = dt.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                this.label50.Text = sum_totalpuchase.ToString();
                conn.Close();
            }
            if (dataGridView5.Visible == true)
            {
                // Purchase Data Retrieve..........................................
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Purchase2_tbl where Type=@Type and Date between '" + dateTimePicker7.Value.ToString() + "'and'" + dateTimePicker8.Value.ToString() + "'", conn);
                cmd.Parameters.AddWithValue("@Type", comboBox10.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView5.DataSource = dt;
                int sum_eggunit = dt.AsEnumerable().Sum(row => row.Field<int>("Units"));
                this.label58.Text = sum_eggunit.ToString();
                int sum_disc = dt.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                this.label53.Text = sum_disc.ToString();
                int sum_Dmgamt = dt.AsEnumerable().Sum(row => row.Field<int>("DamageAmount"));
                this.label52.Text = sum_Dmgamt.ToString();
                int sum_totalpuchase = dt.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                this.label60.Text = sum_totalpuchase.ToString();
                conn.Close();
            }

            if (dataGridView6.Visible == true)
            {
                // Purchase Data Retrieve..........................................
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sale_tbl where Type=@Type and Date between '" + dateTimePicker7.Value.ToString() + "'and'" + dateTimePicker8.Value.ToString() + "'", conn);
                cmd.Parameters.AddWithValue("@Type", comboBox12.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView5.DataSource = dt;
                int sum_eggunit = dt.AsEnumerable().Sum(row => row.Field<int>("Units"));
                this.label76.Text = sum_eggunit.ToString();
                int sum_disc = dt.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                this.label71.Text = sum_disc.ToString();
                int sum_saleamount = dt.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                this.label70.Text = sum_saleamount.ToString();
                int sum_totalcashR = dt.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                this.label69.Text = sum_totalcashR.ToString();
                int sum_Balance = dt.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                this.label79.Text = sum_Balance.ToString();

                conn.Close();

            }
            if (dataGridView6.Visible == true)
            {

                // Purchase Data Retrieve..........................................
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Sale_tbl where Salesman=@Salesman and Date between '" + dateTimePicker7.Value.ToString() + "'and'" + dateTimePicker8.Value.ToString() + "'", conn);
                cmd.Parameters.AddWithValue("@Salesman", comboBox11.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView5.DataSource = dt;
                int sum_eggunit = dt.AsEnumerable().Sum(row => row.Field<int>("Units"));
                this.label67.Text = sum_eggunit.ToString();
                int sum_disc = dt.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                this.label63.Text = sum_disc.ToString();
                int sum_saleamount = dt.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                this.label64.Text = sum_saleamount.ToString();
                int sum_totalcashR = dt.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                this.label62.Text = sum_totalcashR.ToString();
                int sum_Balance = dt.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                this.label51.Text = sum_Balance.ToString();
                conn.Close();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView3.Visible = true;//Expense Report PF
            this.dataGridView5.Visible = false;//Purchase Report PF
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView3.Visible = false;//Expense Report PF
            this.dataGridView5.Visible = true;//Purchase Report PF
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView3.Visible = false;//Expense Report PF
            this.dataGridView5.Visible = true;//Purchase Report PF
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView6.Visible = true;//Sales Report PF
            this.dataGridView3.Visible = false;//Expense Report PF
            this.dataGridView5.Visible = false;//Purchase Report PF
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView6.Visible = true;//Sales Report PF
            this.dataGridView3.Visible = false;//Expense Report PF
            this.dataGridView5.Visible = false;//Purchase Report PF
        }

        //Customer Rreport Search Cde...................................................................
        private void CR_Report_btn_Click(object sender, EventArgs e)
        {
            { //Data retrieving by Date................................
                if (dateTimePicker9.Text != "" | dateTimePicker10.Text != "")
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select * from Sale_tbl where Date between '" + dateTimePicker9.Value.ToString() + "'and'" + dateTimePicker10.Value.ToString() + "'", conn);
                    DataTable sd = new DataTable();
                    sda.Fill(sd);
                    dataGridView7.DataSource = sd;

                    int sum = sd.AsEnumerable().Sum(row => row.Field<int>("Units"));
                    this.textBox25.Text = sum.ToString();
                    int sum_disc = sd.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                    this.textBox24.Text = sum_disc.ToString();
                    int sum_tamount = sd.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                    this.textBox23.Text = sum_tamount.ToString();
                    int sum_cashrec = sd.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                    this.textBox22.Text = sum_cashrec.ToString();
                    int sum_balance = sd.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                    this.textBox21.Text = sum_balance.ToString();
                    conn.Close();
                }
                {
                    if (dateTimePicker9.Text != "" && CR_custname.Text != "" | dateTimePicker10.Text != "")
                    {
                        conn.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select * from Sale_tbl where Date between '" + dateTimePicker9.Value.ToString() + "'and'" + dateTimePicker10.Value.ToString() + "'and partyName='" + CR_custname + "'", conn);

                        DataTable sd = new DataTable();
                        sda.Fill(sd);
                        dataGridView7.DataSource = sd;

                        int sum = sd.AsEnumerable().Sum(row => row.Field<int>("Units"));
                        this.textBox25.Text = sum.ToString();
                        int sum_disc = sd.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                        this.textBox24.Text = sum_disc.ToString();
                        int sum_tamount = sd.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                        this.textBox23.Text = sum_tamount.ToString();
                        int sum_cashrec = sd.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                        this.textBox22.Text = sum_cashrec.ToString();
                        int sum_balance = sd.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                        this.textBox21.Text = sum_balance.ToString();
                        conn.Close();
                    }
                }

            }
           //Data retrieving by Customer Name in Sale report................................
            {
            
                    if (CR_custname.Text != "")
                    {
                        {
                            conn.Open();
                            cmd = new SqlCommand("Select * from Sale_tbl where partyName=@partyName", conn);
                            cmd.Parameters.AddWithValue("@partyName", CR_custname.Text);

                            SqlDataReader dr = cmd.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView7.DataSource = dt;
                            int sum = dt.AsEnumerable().Sum(row => row.Field<int>("Units"));
                            this.textBox25.Text = sum.ToString();
                            int sum_disc = dt.AsEnumerable().Sum(row => row.Field<int>("Discount"));
                            this.textBox24.Text = sum_disc.ToString();
                            int sum_tamount = dt.AsEnumerable().Sum(row => row.Field<int>("TotalAmount"));
                            this.textBox23.Text = sum_tamount.ToString();
                            int sum_cashrec = dt.AsEnumerable().Sum(row => row.Field<int>("CashRecieve"));
                            this.textBox22.Text = sum_cashrec.ToString();
                            int sum_balance = dt.AsEnumerable().Sum(row => row.Field<int>("Balance"));
                            this.textBox21.Text = sum_balance.ToString();
                            conn.Close();
                            ClearData();
                        }
                        {
                            /* int i=0;
                             int[] j = 0;
                             conn.Open();
                             cmd = new SqlCommand("Select * from Sale_tbl where partyName=@partyName", conn);
                             cmd.Parameters.AddWithValue("@partyName", CR_custname.Text);
                             SqlDataReader dr = cmd.ExecuteReader();
                             if (dr.Read())
                             {
                                 for (i = 0; i <= dataGridView7.Rows.Count; i++)
                                 {
                                     j[i] = (dr["Type"].ToString());
                                 }
                             }
                             conn.Close();*/
                            //textBox13.Text = dataGridView7.(1, dataGridView7.SelectedRows(0).Index).Value
                            //  DataGridViewRow row = this.dataGridView7.Rows[e.RowIndex];
                            // this.textBox13.Text = dataGridView7.Rows(0).cells(1);
                            //  this.textBox13 = Convert.ToInt32(dataGridView7.Rows[0]["RoleID"].ToString());


                        }
                    }
                }
            }

        private void ExpPDF_CR_btn_Click(object sender, EventArgs e)
        {
            ExportgridtoPDF_CustomerReport(dataGridView7, "Sale_tbl");
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Customer_Report_Pnl.Visible = true;
            
        }
    }
    }
