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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();

            txt_searchPayment.Text = "   Search";
            txt_searchPayment.ForeColor = Color.Gray;
        }

        private void txt_searchPayment_Enter(object sender, EventArgs e)
        {
            if (txt_searchPayment.Text == "   Search")
            {
                txt_searchPayment.Text = "   "; // remove placeholder
                txt_searchPayment.ForeColor = Color.Black; // set text color to black
            }
        }

        private void txt_searchPayment_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchPayment.Text))
            {
                txt_searchPayment.Text = "   Search"; // restore placeholder
                txt_searchPayment.ForeColor = Color.Gray; // make it gray again
            }
        }

        private void btn_addPayment_Click(object sender, EventArgs e)
        {
          
        }
    }
}
