using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Form1 Dean = new Form1();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Gratuate_Assistant1 Dean = new Gratuate_Assistant1();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Assistant_Details2 Dean = new Assistant_Details2();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Department Dean = new Department();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton8_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Department_Information Dean = new Department_Information();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton7_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Sections Dean = new Sections();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AddStudents Dean = new AddStudents();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            StudentGrades Dean = new StudentGrades();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton20_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            AddStudentTransections Dean = new AddStudentTransections();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton19_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Employees Dean = new Employees();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton16_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            SectionsCapacityWise Dean = new SectionsCapacityWise();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton15_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            ProffesorOFDepartment Dean = new ProffesorOFDepartment();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton14_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            StudentsTransection Dean = new StudentsTransection();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton13_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            StudentListBasedOnGrades Dean = new StudentListBasedOnGrades();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton12_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            EmployeesExperience Dean = new EmployeesExperience();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton11_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            ShowSections Dean = new ShowSections();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton10_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            ShowEmployees Dean = new ShowEmployees();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton9_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            ShoqDepartmentDetails Dean = new ShoqDepartmentDetails();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton18_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            GraduateAssistants Dean = new GraduateAssistants();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton17_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Deans_Data Dean = new Deans_Data();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton22_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            CompleteStudentsRecord Dean = new CompleteStudentsRecord();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void glassButton21_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Grades Dean = new Grades();
            Dean.TopLevel = false;
            panel3.Controls.Add(Dean);
            Dean.Show();
            Dean.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
    }
}
