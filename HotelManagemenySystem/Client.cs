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
    public partial class Client : Form
    {
        string str = "Data Source=.;Initial Catalog=Hotel;Integrated Security=True";
        string query = "";
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public Client()
        {
            InitializeComponent();
        }
        public void AfficherDgv()
        {
            cnx = new SqlConnection(str);
            query = "select * from Client ";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cnx.Close();
            dgv.DataSource = dt;
        }
        private void picDown_Click(object sender, EventArgs e)
        {
            Login voi = new Login();
            voi.Show();
            this.Hide();
        }

        private void txtClientPhone_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            AfficherDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = string.Format("insert into Client values('{0}','{1}','{2}')", txtClientName.Text, txtPhone.Text, cmbCountry.Text);
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            int nb = cmd.ExecuteNonQuery();
            cnx.Close();
            if (nb == 1)
            {
                AfficherDgv();
                MessageBox.Show("Client Successfully Added");
            }
            else
                MessageBox.Show("wrong");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = string.Format("update Client set ClientName='{0}',ClientPhone='{1}',ClientCountry ='{2}' where ClientId={3}", txtClientName.Text, txtPhone.Text, cmbCountry.Text, txtClientId.Text);
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            int nb = cmd.ExecuteNonQuery();
            cnx.Close();
            if (nb == 1)
            {
                AfficherDgv();
                MessageBox.Show("Client Successfully Updated");
            }
            else
                MessageBox.Show("wrong");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cnx = new SqlConnection(str);
                query = string.Format("delete from Client where ClientId={0}", txtClientId.Text);
                cmd = new SqlCommand(query, cnx);
                cnx.Open();
                int nb = cmd.ExecuteNonQuery();
                cnx.Close();
                if (nb == 1)
                {
                    AfficherDgv();
                    MessageBox.Show("Client Successfully Deleted");
                }
                else
                    MessageBox.Show("wrong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtClientId.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtClientName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtPhone.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            cmbCountry.Text = dgv.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtClientId.Text = "";
            txtClientName.Text = "";
            txtPhone.Text = "";
            cmbCountry.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AfficherDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = "select * from Client where ClientName = '" + txtRechercher.Text + "'";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cnx.Close();
            dgv.DataSource = dt;
        }

        private void picStaff_Click(object sender, EventArgs e)
        {
            Staff sf = new Staff();
            sf.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Staff sf = new Staff();
            sf.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.Show();
            this.Hide();
        }

        private void picClient_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.Show();
            this.Hide();
        }

        private void picRoom_Click(object sender, EventArgs e)
        {
            Room rm = new Room();
            rm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Room rm = new Room();
            rm.Show();
            this.Hide();
        }

        private void picRes_Click(object sender, EventArgs e)
        {
            Reservation ri = new Reservation();
            ri.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Reservation ri = new Reservation();
            ri.Show();
            this.Hide();
        }
    }
}
