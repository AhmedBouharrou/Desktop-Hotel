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
    public partial class Staff : Form
    {
        string str = "Data Source=.;Initial Catalog=Hotel;Integrated Security=True";
        string query = "";
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public Staff()
        {
            InitializeComponent();
        }
        public void AfficherDgv()
        {
            cnx = new SqlConnection(str);
            query = "select * from Staff ";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cnx.Close();
            dgv.DataSource = dt;
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            AfficherDgv();
        }

        private void picDown_Click(object sender, EventArgs e)
        {
            Login voi = new Login();
            voi.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = string.Format("insert into Staff values('{0}','{1}','{2}','{3}')", txtStaffName.Text, txtStaffPhone.Text, cmbGender.Text, txtPass.Text);
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            int nb = cmd.ExecuteNonQuery();
            cnx.Close();
            if (nb == 1)
            {
                AfficherDgv();
                MessageBox.Show("Staff Successfully Added");
            }
            else
                MessageBox.Show("Introuvable");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = string.Format("update Staff set StaffName='{0}',StaffPhone='{1}',Gender ='{2}', StaffPassword='{3}' where StaffId={4}", txtStaffName.Text, txtStaffPhone.Text, cmbGender.Text, txtPass.Text, txtStaffId.Text);
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            int nb = cmd.ExecuteNonQuery();
            cnx.Close();
            if (nb == 1)
            {
                AfficherDgv();
                MessageBox.Show("Staff Successfully Updated");
            }
            else
                MessageBox.Show("wrong");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cnx = new SqlConnection(str);
                query = string.Format("delete from Staff where StaffId={0}", txtStaffId.Text);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStaffId.Text = "";
            txtStaffName.Text = "";
            txtStaffPhone.Text = "";
            cmbGender.Text = "";
            txtPass.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = "select * from Staff where StaffName = '" + txtRechercher.Text + "'";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cnx.Close();
            dgv.DataSource = dt;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStaffId.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtStaffName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtStaffPhone.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            cmbGender.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            txtPass.Text = dgv.CurrentRow.Cells[4].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Staff sf = new Staff();
            sf.Show();
            this.Hide();
        }

        private void picStaff_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AfficherDgv();
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

        private void label6_Click(object sender, EventArgs e)
        {
            Reservation ri = new Reservation();
            ri.Show();
            this.Hide();
        }

        private void picRes_Click(object sender, EventArgs e)
        {
            Reservation ri = new Reservation();
            ri.Show();
            this.Hide();
        }
    }
}
