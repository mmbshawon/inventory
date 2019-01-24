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
    public partial class GenerateBill : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-294PU2V\\SQLEXPRESS;Initial Catalog=InventoryManagementDb;User ID=sa;Password=masum005;Integrated Security=True");
        int j;
        int total = 0;
        public GenerateBill()
        {
            InitializeComponent();
        }

        public void GetValue(int i)
        {
            j = i;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();
            SqlDataAdapter sda = new SqlDataAdapter("select * from Sales2 Where Id=" + j + " ", conn);
            DataTable dt = new DataTable();
            sda.Fill(ds.DataTable1);

            total = 0;
            foreach (DataRow dr2 in dt.Rows)
            {
                total = total + Convert.ToInt32(dr2["TotalPrice"].ToString());

            }

            CrystalReport1 myReport1 = new CrystalReport1();
            myReport1.SetDataSource(ds);
            myReport1.SetParameterValue("TotalPrice", total.ToString());
            crystalReportViewer1.ReportSource = myReport1;
        }
    }
}
