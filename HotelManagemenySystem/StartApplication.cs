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
    public partial class StartApplication : Form
    {
        int startpoint = 0;
        public StartApplication()
        {
            InitializeComponent();
        }

        private void StartApplication_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            sflachBar.Value = startpoint;
            if (sflachBar.Value == 100)
            {
                sflachBar.Value = 0;
                timer1.Stop();
                Login voi = new Login();
                voi.Show();
                this.Hide();
            }
        }
    }
}
