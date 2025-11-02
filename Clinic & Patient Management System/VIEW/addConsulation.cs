using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class addConsulation : Form
    {
        public addConsulation()
        {
            InitializeComponent();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            btn_addPatient.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
