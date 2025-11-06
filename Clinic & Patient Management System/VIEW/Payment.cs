using Clinic___Patient_Management_System.PRESENTER;
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
    public partial class Payment : Form, IPaymentView
    {
        private readonly PaymentPresenter _presenter;
        public Payment()
        {
            InitializeComponent();
            _presenter = new PaymentPresenter(this);

            txt_searchPayment.Text = "   Search";
            txt_searchPayment.ForeColor = Color.Gray;
            _presenter.LoadPayments();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#013797");
        }
        public void DisplayPayments(DataTable payments)
        {
            dgv_paymentRecord.Rows.Clear();

            foreach (DataRow row in payments.Rows)
            {
                int paymentID = Convert.ToInt32(row["PaymentID"]);
                string patientName = row["PatientName"].ToString();
                string doctorName = row["DoctorName"].ToString();
                string appointmentDate = Convert.ToDateTime(row["AppointmentDate"]).ToShortDateString();
                string paymentDate = Convert.ToDateTime(row["PaymentDate"]).ToShortDateString();
                string method = row["PaymentMethod"].ToString();
                string status = row["Status"].ToString();
                string notes = row["Notes"]?.ToString() ?? "";
                decimal amount = Convert.ToDecimal(row["Amount"]);

                dgv_paymentRecord.Rows.Add(
                    paymentID,              // Receipt No.
                    patientName,            // Patient Name
                    doctorName,             // Doctor Name
                    appointmentDate,        // Appointment Date
                    paymentDate,            // Payment Date
                    $"₱{amount:N2}",        // Formatted amount
                    method,                 // Payment Method
                    status,                 // Status
                    notes,                  // Notes
                    "View",                 // View button
                    "Delete"                // Delete button
                );
            }

            // Optional: visually highlight status
            foreach (DataGridViewRow row in dgv_paymentRecord.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                if (status == "Paid")
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                else if (status == "Pending")
                    row.Cells["Status"].Style.ForeColor = Color.DarkOrange;
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgv_paymentRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgv_paymentRecord.Columns[e.ColumnIndex].Name;

            if (columnName == "View")
            {
                int paymentID = Convert.ToInt32(dgv_paymentRecord.Rows[e.RowIndex].Cells["PaymentID"].Value);
                ViewReceipt frm = new ViewReceipt(paymentID);
                frm.ShowDialog();
            }
            else if (columnName == "Delete")
            {
                int paymentID = Convert.ToInt32(dgv_paymentRecord.Rows[e.RowIndex].Cells["PaymentID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this payment record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _presenter.DeletePayment(paymentID);
                    _presenter.LoadPayments(); 
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
