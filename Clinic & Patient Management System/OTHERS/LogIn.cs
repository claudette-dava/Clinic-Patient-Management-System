using Clinic___Patient_Management_System.PRESENTER;
using Clinic___Patient_Management_System.VIEW;
using Clinic___Patient_Management_System.VIEW.Interfaces;
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
    public partial class LogIn : Form, ILoginView
    {
        private readonly LoginPresenter _presenter;

        public LogIn()
        {
            InitializeComponent();
            _presenter = new LoginPresenter(this);
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
            button1.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.Login();
        }
        public string Username => txt_username.Text.Trim();
        public string Password => txt_password.Text.Trim();

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OpenHomeForm()
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
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

      
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
