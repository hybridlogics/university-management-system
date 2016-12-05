using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeSystem
{
    public partial class Sections : Form
    {
        public Sections()
        {
            InitializeComponent();
        }

        public string con_string = DBConnection.connectionstring;

        private void button3_Click(object sender, EventArgs e)
        {
            string CourseID, No_Days, StartTime, EndTime, Capacity;
            CourseID = textBox1.Text;
            No_Days = textBox2.Text;
            //StartTime = dateTimePicker1.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
//            StartTime = dateTimePicker1.Text;
            //EndTime = dateTimePicker2.Text.ToString();
            Capacity = textBox5.Text;

            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Insert into [Sections] values ( (Select CourseID from DepartmentInformation where CourseID = '" + CourseID + "'),'" + Convert.ToInt32(No_Days) + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + Capacity + "')";
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
