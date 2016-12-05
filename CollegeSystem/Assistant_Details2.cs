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
    public partial class Assistant_Details2 : Form
    {
        public Assistant_Details2()
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

            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = @"Insert into [GraduateAssistantDetails2]  values ( (Select GraduateAssistantID from GraduateAssistantDetails1 where GraduateAssistantID = '"+ Convert.ToInt32(id)+"') ,'" + name + "','" + courses + "','" + assistant + "','" + Convert.ToInt32( phone )+ "')";
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
            Gratuate_Assistant1 ass = new Gratuate_Assistant1();
            ass.Show();
        }
    }
}
