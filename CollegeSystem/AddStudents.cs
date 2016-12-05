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

namespace CollegeSystem
{
    public partial class AddStudents : Form
    {
        public AddStudents()
        {
            InitializeComponent();
        }
        public string con_string = DBConnection.connectionstring;
        private void glassButton2_Click(object sender, EventArgs e)
        {
            string Depid, Firstname,Lastname,StdID,Section, stdAdress, City, State, Postcode, GraduateYear, Contact;
            Depid = textBox1.Text;
            Firstname = textBox2.Text;
            Lastname = textBox3.Text;
            StdID = textBox4.Text;
            Section = textBox5.Text;
            stdAdress = textBox6.Text;
            City = textBox7.Text;
            State = textBox11.Text;
            Postcode = textBox8.Text;
            GraduateYear = textBox9.Text;
            Contact = textBox10.Text;
            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = @"Insert into [Students]  values ( (Select DepartmentID from Departments where DepartmentID = '" + Convert.ToInt32(Depid) + "') ,'" + Firstname + "','" + Lastname + "','" + StdID + "','" + Section + "','" + stdAdress + "','" + City + "','" + State + "','" + Postcode + "','" + GraduateYear + "','" + Contact + "')";
                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader dt = sda.ExecuteReader();
                MessageBox.Show("Data Saved Successfully ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
