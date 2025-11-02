using Clinic___Patient_Management_System.VIEW;
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

namespace Clinic___Patient_Management_System
{
    public partial class LogIn : Form
    {
        string connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string query = "SELECT Role FROM tbl_users WHERE Username=@Username AND Password=@Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();

                  
                        HomeForm home = new HomeForm(); 
                        home.Show();

                        this.Hide();
                        txt_username.Clear();
                        txt_password.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_password.PasswordChar = '\0'; 
            }
            else
            {
                txt_password.PasswordChar = '*'; 
            }
        }
    }
}
