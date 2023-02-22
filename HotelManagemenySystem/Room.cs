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
    public partial class Room : Form
    {
        string str = "Data Source=.;Initial Catalog=Hotel;Integrated Security=True";
        string query = "";
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public Room()
        {
            InitializeComponent();
        }
        public void AfficherDgv()
        {
            cnx = new SqlConnection(str);
            query = "select * from Room ";
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cnx.Close();
            dgv.DataSource = dt;
        }
        private void Room_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            AfficherDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string isFree;
            if (rdYes.Checked == true)
            {
                isFree = "free";
            }
            else
            {
                isFree = "busy";
            }
            cnx = new SqlConnection(str);
            query = string.Format("insert into Room values('{0}')",isFree);
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            int nb = cmd.ExecuteNonQuery();
            cnx.Close();
            if (nb == 1)
            {
                AfficherDgv();
                MessageBox.Show("Room Successfully Added");
            }
            else
                MessageBox.Show("Introuvable");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string isFree;
            if (rdYes.Checked == true)
            {
                isFree = "free";
            }
            else
            {
                isFree = "busy";
            }
            cnx = new SqlConnection(str);
            query = string.Format("update Room set RoomFree='{0}' where RoomId={1}", isFree, txtRoomId.Text);
            cmd = new SqlCommand(query, cnx);
            cnx.Open();
            int nb = cmd.ExecuteNonQuery();
            cnx.Close();
            if (nb == 1)
            {
                AfficherDgv();
                MessageBox.Show("Room Successfully Updated");
            }
            else
                MessageBox.Show("Introuvable");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cnx = new SqlConnection(str);
                query = string.Format("delete from Room where RoomId={0}", txtRoomId.Text);
                cmd = new SqlCommand(query, cnx);
                cnx.Open();
                int nb = cmd.ExecuteNonQuery();
                cnx.Close();
                if (nb == 1)
                {
                    AfficherDgv();
                    MessageBox.Show("Room Successfully Deleted");
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
            txtRoomId.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AfficherDgv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cnx = new SqlConnection(str);
            query = "select * from Room where RoomId = '" + txtRechercher.Text + "'";
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomId.Text = dgv.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
