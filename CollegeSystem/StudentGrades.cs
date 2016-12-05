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
    public partial class StudentGrades : Form
    {
        public StudentGrades()
        {
            InitializeComponent();
        }

        public string con_string = DBConnection.connectionstring;

        private void button3_Click(object sender, EventArgs e)
        {
            string studentID, CourseID, AcademicYear, Semester, Grade;
            studentID = textBox1.Text;
            CourseID = textBox2.Text;
            AcademicYear = textBox3.Text;
            Semester = textBox4.Text;
            Grade = textBox5.Text;

            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Insert into [Grades] values ((select StudentID from Students where StudentID = '" + studentID + "'), (Select CourseID from DepartmentInformation where CourseID = '" + CourseID + "'),'" + Convert.ToInt32( AcademicYear ) + "','" + Semester + "','" + Grade + "')";
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
