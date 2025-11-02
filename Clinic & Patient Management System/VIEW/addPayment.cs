using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class addPayment : Form
    {
        public addPayment()
        {
            InitializeComponent();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            btn_addPayment.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
        }

        private void btn_addPayment_Click(object sender, EventArgs e)
        {
            string selectConsultationID = PatientConsultation();
            if (selectConsultationID == null) return;
            this.Close();

            //wala pang receipt number

            string selectPaymentStatus = PaymentStatus();
            if (selectPaymentStatus == null) return;
            this.Close();

            string selectPaymentMethod = PaymentMethod();
            if (selectPaymentMethod == null) return;

            string amount = txt_amount.Text.Trim();
            if (!PaymentAmount(amount))
            {
                MessageBox.Show("Invalid amount. Please enter a valid amount.", "Validation error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string PatientConsultation()
        {
            if (cmb_patient.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a patient.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return cmb_patient.SelectedItem.ToString();
        }

        //RECEIPT NUMBER

        private string PaymentStatus()
        {
            if (cmb_paymentStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return cmb_paymentStatus.SelectedItem.ToString();
        }
        private string PaymentMethod()
        {
            if (cmb_paymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return cmb_paymentMethod.SelectedItem.ToString();
        }

        private bool PaymentAmount(string amount) 
        {
            return Regex.IsMatch(amount, @"^\d + (\.\d{ 1,2})?$"); 
        } 
    }
}
