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
    public partial class SectionsCapacityWise : Form
    {
        public SectionsCapacityWise()
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
                string query = "Select * from Sections where Capacity > '30'";
                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader dt = sda.ExecuteReader();
                while (dt.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[count].Clone();
                    row.Cells[0].Value = dt.GetString(0);
                    row.Cells[1].Value = dt.GetInt32(1).ToString();
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
