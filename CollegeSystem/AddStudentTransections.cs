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
    public partial class AddStudentTransections : Form
    {
        public AddStudentTransections()
        {
            InitializeComponent();
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public string con_string = "Data Source = DESKTOP-AR9P6I5\\MARWAT1;Initial Catalog= CollegesystemDB1;Integrated Security=True";
        private void glassButton2_Click(object sender, EventArgs e)
        {
            string Transectionid, Stdname, PostDate,  TransectionDesc;
            float Amount;
            Transectionid = textBox1.Text;
            Stdname = textBox2.Text;
//            PostDate = textBox3.Text;
            Amount = Convert.ToSingle( textBox3.Text); 
            TransectionDesc = textBox6.Text;

            try
            {

                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = @"Insert into [Student_Transactions]  values ( '" + Transectionid + "' ,( Select StudentID from Students where StudentID =  '" + Stdname + "'),'" + dateTimePicker1.Value.Date + "','" + Amount + "','" + TransectionDesc + "')";
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
    }
}
