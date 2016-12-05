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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string con_string = DBConnection.connectionstring;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Assistant_Details2 Ass = new Assistant_Details2();
            Ass.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id, name, courses, assistant, phone, email, fax;
            id = textBox1.Text;
            name = textBox2.Text;
            courses = textBox3.Text;
            assistant = textBox4.Text;
            phone = textBox5.Text;
            fax = textBox6.Text;
            email = textBox7.Text;

            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Insert into [DeanDetails] (DeanID,DepartmentDean,CoursesTaught,GraduateAssistant,Phone,Fax,Deanemail)  values ('" + id + "','" + name + "','" + courses + "','" + assistant + "','" + phone + "','" + fax + "','" + email + "')";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
