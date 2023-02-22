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
    public partial class Reservation : Form
    {
        string str = "Data Source=.;Initial Catalog=Hotel;Integrated Security=True";
        string query = "";
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public Reservation()
        {
            InitializeComponent();
        }

        private void picDown_Click(object sender, EventArgs e)
        {
            Login voi = new Login();
            voi.Show();
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
        public void AfficherDgv()
        {
            cnx = new SqlConnection(str);
            query = "select * from Reservation ";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cnx.Close();
            dgv.DataSource = dt;
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

            cnx = new SqlConnection(str);
            query = "select ClientId from Client";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
                cmbClientId.Items.Add(dr["ClientId"].ToString());
            cnx.Close();


            cnx = new SqlConnection(str);
            query = "select RoomId from Room";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
                cmbRoomId.Items.Add(dr["RoomId"].ToString());
            cnx.Close();


            lblDate.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            AfficherDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cnx = new SqlConnection(str);
                query = string.Format("insert into Reservation values({0},{1},'{2}','{3}')", cmbClientId.Text, cmbRoomId.Text, dtpIn.Value, dtpOut.Value);
                cmd = new SqlCommand(query, cnx);
                cnx.Open();
                int nb = cmd.ExecuteNonQuery();
                cnx.Close();
                if (nb == 1)
                {
                    AfficherDgv();
                    MessageBox.Show("Reservation Successfully Added");
                }
                else
                    MessageBox.Show("Introuvable");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AfficherDgv();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cnx = new SqlConnection(str);
                query = string.Format("update Reservation set ClientId={0},RoomId={1},DateIn='{2}',DateOut='{3}' where ReservationId={4}", cmbClientId.Text, cmbRoomId.Text, dtpIn.Value, dtpOut.Value, txtReservationId.Text);
                cmd = new SqlCommand(query, cnx);
                cnx.Open();
                int nb = cmd.ExecuteNonQuery();
                cnx.Close();
                if (nb == 1)
                {
                    AfficherDgv();
                    MessageBox.Show("Reservation Successfully Updated");
                }
                else
                    MessageBox.Show("Introuvable");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cnx = new SqlConnection(str);
                query = string.Format("delete from Reservation where ReservationId={0}", txtReservationId.Text);
                cmd = new SqlCommand(query, cnx);
                cnx.Open();
                int nb = cmd.ExecuteNonQuery();
                cnx.Close();
                if (nb == 1)
                {
                    AfficherDgv();
                    MessageBox.Show("Reservation Successfully Deleted");
                }
                else
                    MessageBox.Show("Introuvable");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReservationId.Text = "";
            cmbClientId.Text = "";
            cmbRoomId.Text = "";
            dtpIn.Text = "";
            dtpOut.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = "select * from Reservation where ReservationId = '" + txtRechercher.Text + "'";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cnx.Close();
            dgv.DataSource = dt;
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

        private void label4_Click(object sender, EventArgs e)
        {
            Room rm = new Room();
            rm.Show();
            this.Hide();
        }

        private void picRoom_Click(object sender, EventArgs e)
        {
            Room rm = new Room();
            rm.Show();
            this.Hide();
        }
    }
}
