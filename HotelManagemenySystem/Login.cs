using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagemenySystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("data source=.; initial catalog=Hotel ; integrated security=true");
            string query = string.Format("select * from Staff where StaffName='{0}' and StaffPassword='{1}'", txtUN.Text, txtPass.Text);
            SqlCommand cmd = new SqlCommand(query, cnx);
            cnx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Client cli = new Client();
                cli.Show();
            }
            else
            {
                MessageBox.Show("wrong Username or Password");
            }
        }
    }
}
