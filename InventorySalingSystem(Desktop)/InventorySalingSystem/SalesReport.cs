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
    public partial class SalesReport : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-294PU2V\\SQLEXPRESS;Initial Catalog=InventoryManagementDb;User ID=sa;Password=masum005;Integrated Security=True");
        DataTable dt = new DataTable();
        public SalesReport()
        {
            InitializeComponent();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {

            String startdate;
            string enddate;
            int i = 0;
            int j = 0;
            startdate = dateTimePickerStart.Value.ToString();
            enddate = dateTimePickerEnd.Value.ToString();

            SqlDataAdapter sda = new SqlDataAdapter(@"Select * From [InventoryManagementDb].[dbo].[Sales2] where SaleDateTime>='" + startdate.ToString() + "' and SaleDateTime<='" + enddate.ToString() + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToInt32(dr["ProductQuantity"].ToString());
                j = j + Convert.ToInt32(dr["TotalPrice"].ToString());
            }

            quantityLevel.Text = i.ToString();
            totalpriceBtn.Text = j.ToString();
        }

      
    }
}
