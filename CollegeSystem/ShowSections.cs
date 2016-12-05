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
    public partial class ShowSections : Form
    {
        public ShowSections()
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
                string query = "Select * from Sections";
                SqlCommand sda = new SqlCommand(query, con);
                SqlDataReader dt = sda.ExecuteReader();
                while (dt.Read())
                {
                    if (dt.GetString(0) != null)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[count].Clone();
                        row.Cells[0].Value = dt.GetString(0);
                        row.Cells[1].Value = dt.GetInt32(1).ToString();
                        row.Cells[2].Value = dt.GetTimeSpan(2);
                        row.Cells[3].Value = dt.GetTimeSpan(3);
                        row.Cells[4].Value = dt.GetInt32(4).ToString();
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
