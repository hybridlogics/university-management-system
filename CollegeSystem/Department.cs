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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        public string con_string = DBConnection.connectionstring;

        private void button3_Click(object sender, EventArgs e)
        {
            string DepartmentID, DepartmentName, DepartmentDescription, DepartmentDean, schoolName, LevelOfEducation;
            DepartmentID = textBox1.Text;
            DepartmentName = textBox2.Text;
            DepartmentDescription = textBox3.Text;
            DepartmentDean = textBox4.Text;
            schoolName = textBox5.Text;
            LevelOfEducation = textBox6.Text;
            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Insert into [Departments]  values ('" + Convert.ToInt32(DepartmentID) + "','" + DepartmentName + "','" + DepartmentDescription + "', (Select DepartmentDean from DeanDetails where DepartmentDean = '" + DepartmentDean + "'),'" + schoolName + "','" + LevelOfEducation + "')";
                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader dt = sda.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
