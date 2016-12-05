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
    public partial class Department_Information : Form
    {
        public Department_Information()
        {
            InitializeComponent();
        }

        public string con_string = DBConnection.connectionstring;

        private void button3_Click(object sender, EventArgs e)
        {
            string DepartmentID, courseID, couseName, ProfessorName, TermOffered, GradePoint, BuildingLocation, CategoryOfCourse;
            DepartmentID = textBox1.Text;
            courseID = textBox8.Text;
            couseName = textBox2.Text;
            ProfessorName = textBox3.Text;
            TermOffered = textBox4.Text;
            GradePoint = textBox5.Text;
            BuildingLocation = textBox6.Text;
            CategoryOfCourse = textBox7.Text;
            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Insert into [DepartmentInformation]  values ( (Select DepartmentID from Departments where DepartmentID = '" + Convert.ToInt32(DepartmentID) + "'),'" + courseID + "','" + couseName + "','" + ProfessorName + "','" + TermOffered + "','" + Convert.ToInt32(GradePoint) + "','" + BuildingLocation + "','" + CategoryOfCourse + "')";
                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader dt = sda.ExecuteReader();
                while (dt.Read())
                {
                    //   MessageBox.Show(dt.GetString(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Department dep = new Department();
            dep.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
