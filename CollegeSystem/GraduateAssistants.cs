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
    public partial class GraduateAssistants : Form
    {
        public GraduateAssistants()
        {
            InitializeComponent();
        }
        public string con_string = DBConnection.connectionstring;
        private void glassButton1_Click(object sender, EventArgs e)
        {
            int count = 0;
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                string query = "Select * from GraduateAssistantDetails2";
                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader dt = sda.ExecuteReader();
                while (dt.Read())
                {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[count].Clone();
                        row.Cells[0].Value = dt.GetInt32(0).ToString();
                        row.Cells[1].Value = dt.GetString(1);
                        row.Cells[2].Value = dt.GetString(2);
                        row.Cells[3].Value = dt.GetString(3);
                        row.Cells[4].Value = dt.GetInt32(4).ToString();
                        dataGridView1.Rows.Add(row);
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
