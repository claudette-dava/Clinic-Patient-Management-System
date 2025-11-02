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
    public partial class Consultation : Form
    {
        public Consultation()
        {
            InitializeComponent();


            txt_searchConsultation.Text = "   Search";
            txt_searchConsultation.ForeColor = Color.Gray;
        }

        private void txt_searchConsultation_Enter(object sender, EventArgs e)
        {
            if (txt_searchConsultation.Text == "   Search")
            {
                txt_searchConsultation.Text = "   "; // remove placeholder
                txt_searchConsultation.ForeColor = Color.Black; // set text color to black
            }
        }

        private void txt_searchConsultation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchConsultation.Text))
            {
                txt_searchConsultation.Text = "   Search"; // restore placeholder
                txt_searchConsultation.ForeColor = Color.Gray; // make it gray again
            }
        }

        private void btn_addConsultation_Click(object sender, EventArgs e)
        {
            addConsulation addCon = new addConsulation();
            addCon.ShowDialog();

        }
    }
}
