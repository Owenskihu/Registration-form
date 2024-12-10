using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            btnsubmit.Enabled = true;
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
            connect.CloseDB();



        }


        private void btncancel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnsubmit.Enabled = true;
            btnUpdate.Enabled = false;
            connect.OpenDB();
            DisplayRegistration();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvregistration.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete?",
                        "delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string regid = dgvregistration.CurrentRow.Cells[0].Value.ToString();
                        connect.DeletingRegistration(regid);
                        MessageBox.Show("Registration has been deleteded");
                        DisplayRegistration();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ClearFields()
        {
            txtAddress.Clear();
            txtContactno.Clear();
            txtLastname.Clear();
            txtFirstname.Clear();
            txtFirstname.Focus();
            txtRegid.Clear();
        }

        private void dgvregistration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvregistration_DoubleClick(object sender, EventArgs e)
        {
            txtRegid.Text = dgvregistration.CurrentRow.Cells[0].Value.ToString();
            txtFirstname.Text = dgvregistration.CurrentRow.Cells[1].Value.ToString();
            txtLastname.Text = dgvregistration.CurrentRow.Cells[2].Value.ToString();
            txtAddress.Text = dgvregistration.CurrentRow.Cells[3].Value.ToString();
            txtContactno.Text = dgvregistration.CurrentRow.Cells[4].Value.ToString();
            btnsubmit.Enabled = false;
            btnUpdate.Enabled = true;




        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                reg.firstname = txtFirstname.Text;
                reg.lastname = txtLastname.Text;
                reg.address = txtAddress.Text;
                reg.contactno = txtContactno.Text;
                reg.regid = int.Parse(txtRegid.Text);
                connect.UpdateRegistration(reg);
                reg.regid = 0;
                MessageBox.Show("Registration has been updated.");
                DisplayRegistration();
                ClearFields();
                btnsubmit.Enabled = true;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

      
    }
    
}
