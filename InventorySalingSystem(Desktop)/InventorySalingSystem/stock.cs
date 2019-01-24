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
    public partial class stock : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-294PU2V\\SQLEXPRESS;Initial Catalog=InventoryManagementDb;User ID=sa;Password=masum005;Integrated Security=True");
        DataTable dt = new DataTable();
        public stock()
        {
            InitializeComponent();
        }

        private void buttonSerchStyle_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            SqlDataAdapter sda = new SqlDataAdapter("Select StyleName,Dsp,ProductQuantity From [InventoryManagementDb].[dbo].[Products] where StyleName like '%" + textBoxSerchStyle.Text+"%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

           

          
        }

        private void stock_Load(object sender, EventArgs e)
        {

        }
    }
}
