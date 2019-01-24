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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-294PU2V\\SQLEXPRESS;Initial Catalog=InventoryManagementDb;User ID=sa;Password=masum005;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM [InventoryManagementDb].[dbo].[Users] Where UserName='" + userNameTextBox.Text + "' and Password = '" + passwordTextBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else {
                MessageBox.Show("Invalid User or Password","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.Clear();
                passwordTextBox.Clear();
            }
        }

        
    }
}
