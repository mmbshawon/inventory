using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySalingSystem
{
    public partial class Sales : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-294PU2V\\SQLEXPRESS;Initial Catalog=InventoryManagementDb;User ID=sa;Password=masum005;Integrated Security=True");
        DataTable dt = new DataTable();
        int total = 0;
        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            conn.Open();
            dt.Clear();
            dt.Columns.Add("StyleName");
            dt.Columns.Add("ProductPrice");
            dt.Columns.Add("ProductQuantity");
            dt.Columns.Add("SaleDateTime");
            dt.Columns.Add("TotalPrice");

        }
        private void textBoxStyleName_KeyUp_1(object sender, KeyEventArgs e)
        {
            listBoxShow.Visible = true;
            listBoxShow.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [InventoryManagementDb].[dbo].[Products] Where StyleName Like ('%" + textBoxStyleName.Text + "%') ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBoxShow.Items.Add(dr["StyleName"].ToString());
            }
        }

        private void listBoxShow_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.listBoxShow.SelectedIndex = this.listBoxShow.SelectedIndex;
                }

                if (e.KeyCode == Keys.Up)
                {
                    this.listBoxShow.SelectedIndex = this.listBoxShow.SelectedIndex;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    textBoxStyleName.Text = listBoxShow.SelectedItem.ToString();
                    listBoxShow.Visible = false;
                    textBoxPrice.Focus();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void textBoxPrice_Enter_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select top 1 * From [InventoryManagementDb].[dbo].[Products] Where StyleName='" + textBoxStyleName.Text + "' order by Id desc ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBoxPrice.Text = dr["Dsp"].ToString();

            }
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {

            try
            {
                textBoxTotalPrice.Text = Convert.ToString(Convert.ToInt32(textBoxPrice.Text) * Convert.ToInt32(textBoxQuantity.Text));
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            int stock = 0;
            SqlDataAdapter sda = new SqlDataAdapter("Select [StyleName],[Dsp],[ProductQuantity] From [InventoryManagementDb].[dbo].[Products] Where StyleName='" + textBoxStyleName.Text + "'", conn);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                stock = Convert.ToInt32(dr1["ProductQuantity"].ToString());
            }

            if (Convert.ToInt32(textBoxQuantity.Text) > stock)
            {
                MessageBox.Show("Out of Products!", "Stock In/Out", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Check if Product are available or not into Product Table
            }

           else
            {
                DataRow dr = dt.NewRow(); //Add Product details into temporary datagridview
                dr["StyleName"] = textBoxStyleName.Text;
                dr["ProductPrice"] = textBoxPrice.Text;
                dr["ProductQuantity"] = textBoxQuantity.Text;
                dr["TotalPrice"] = textBoxTotalPrice.Text;
                dr["SaleDateTime"] = saleDateTimePicker.Value.ToString();
                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;

                total = total + Convert.ToInt32(dr["TotalPrice"].ToString());
                label7.Text = total.ToString();
            }
            textBoxStyleName.Clear();
            textBoxQuantity.Clear();
            textBoxPrice.Clear();
            textBoxTotalPrice.Clear();
           
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            string SaleId = "";
            SqlDataAdapter sdc = new SqlDataAdapter("select top 1 * from Sales2 order by Id desc", conn);
            DataTable dt2 = new DataTable();
            sdc.Fill(dt2);
            foreach(DataRow dr1 in dt2.Rows)
            {
                SaleId = dr1["Id"].ToString();
            }
            foreach (DataRow dr in dt.Rows)
            {
                int quantity = 0;
                int totalprice = 0;
                string pname = ""; //Insert Sells Product details into sells_Item Table
                SqlDataAdapter sdp = new SqlDataAdapter("Insert into [InventoryManagementDb].[dbo].[Sales2] values ('" + dr["StyleName"] + "','" + dr["ProductPrice"] + "','" + dr["ProductQuantity"] + "','" + dr["TotalPrice"] + "','" + dr["SaleDateTime"] + "')", conn);
                DataTable dt3 = new DataTable();
                sdp.Fill(dt3);

                quantity = Convert.ToInt32(dr["ProductQuantity"].ToString());
                totalprice = Convert.ToInt32(dr["TotalPrice"].ToString());
                pname = dr["StyleName"].ToString(); //Decrease product from Product Table
                SqlDataAdapter sdp1 = new SqlDataAdapter("Update [InventoryManagementDb].[dbo].[Products] set ProductQuantity = ProductQuantity - '" + quantity + "'  where StyleName ='" + pname + "'", conn);
                DataTable dt4 = new DataTable();
                sdp1.Fill(dt4);

            }

            dt.Clear();
            dataGridView1.DataSource = dt;
            label7.Text = "";
            MessageBox.Show("Record inserted seccessfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GenerateBill gb1 = new GenerateBill();
            gb1.GetValue(Convert.ToInt32(SaleId.ToString()));
            gb1.Show();

        }

        private void textBoxStyleName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Down)
            {
                listBoxShow.Focus();
                listBoxShow.SelectedIndex = 0;
            }
        }
    }
}
