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
    public partial class Gratuate_Assistant1 : Form
    {
        public Gratuate_Assistant1()
        {
            InitializeComponent();
        }

        public string con_string = DBConnection.connectionstring;

        private void button3_Click(object sender, EventArgs e)
        {
            string id, name, courses, assistant, phone, email, fax;
            id = textBox1.Text;
            name = textBox2.Text;
            courses = textBox3.Text;
            assistant = textBox4.Text;
            phone = textBox5.Text;
            email = textBox6.Text;
            fax = textBox7.Text;
            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Insert into [GraduateAssistantDetails1]  values ('" + id + "','" + Convert.ToInt32(name) + "','" +Convert.ToInt32(courses) + "','" + assistant + "','" + phone + "','"+email+"','"+fax+"')";
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
            Department_Information dp = new Department_Information();
            dp.Visible = true;
            dp.Show();
        }
    }
}
