using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Registration_from
{
    public partial class Form1 : Form
    {
        DBConnect connect = new DBConnect();
        Registration reg = new Registration();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            connect.OpenDB();
            DisplayRegistration();
        }

        private void btnsubmit_Click_1(object sender, EventArgs e)
        {

            try
            {
                reg.firstname = txtFirstname.Text;
                reg.lastname = txtLastname.Text;
                reg.address = txtAddress.Text;
                reg.contactno = txtContactno.Text;
                connect.InsertRegistration(reg);
                MessageBox.Show("You have submitted successfully");
                DisplayRegistration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DisplayRegistration()
        {  
           connect.OpenDB();
            DataTable dt = new DataTable();
            dt = connect.ReadRegistrationrRecord();
            dgvregistration.DataSource = dt;

        }


        private void btncancel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
