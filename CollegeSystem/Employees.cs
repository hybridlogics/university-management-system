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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        public string con_string = DBConnection.connectionstring;

        private void button3_Click(object sender, EventArgs e)
        {
            string EmployeeID, EmployeeName, EmployeeSalary, DempartmentID, Experience;
            EmployeeID = textBox1.Text;
            EmployeeName = textBox2.Text;
            EmployeeSalary = textBox3.Text;
            DempartmentID = textBox4.Text;
            Experience = textBox5.Text;

            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Insert into [Employees] values ('" + EmployeeID + "','" + EmployeeName + "','" + EmployeeSalary + "',(Select DepartmentID from Departments where DepartmentID =  '" + DempartmentID + "'),'" + Experience + "')";
                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader dt = sda.ExecuteReader();
                while (dt.Read())
                {
                    //   MessageBox.Show(dt.GetString(1));
                }
                MessageBox.Show("Data Saved Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
