using Clinic___Patient_Management_System.PRESENTER;
using Clinic___Patient_Management_System.VIEW.Interfaces;
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
using static Clinic___Patient_Management_System.MODEL.DoctorModel;
using static Clinic___Patient_Management_System.MODEL.PatientModel;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class addPayment : Form, IAddPaymentView
    {
        private readonly AddPaymentPresenter _presenter;
        public event Action PaymentSaved;

        public int AppointmentID { get; private set; }
        public int PatientID { get; private set; }
        public int DoctorID { get; private set; }

        public decimal Amount => decimal.TryParse(txt_amount.Text, out decimal val) ? val : 0;
        public string PaymentMethod => cmb_method.SelectedItem?.ToString() ?? "";
        public string Status => cmb_status.SelectedItem?.ToString() ?? "Pending";
        public string Notes => txt_notes.Text;

        public addPayment(int appointmentId, int patientId, int doctorId, string patientName, string doctorName, string appointmentDate)
        {
            _presenter = new AddPaymentPresenter(this);
            InitializeComponent();
            panel1.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");
            btn_addPayment.BackColor = (Color)new ColorConverter().ConvertFromString("#2596be");

            txt_patientName.Text = patientName;
            txt_doctorName.Text = doctorName;
            txt_appointmentDate.Text = appointmentDate;

            // 💾 Store IDs for database use
            AppointmentID = appointmentId;
            PatientID = patientId;
            DoctorID = doctorId;

            // 🧾 Populate combo boxes
            LoadPaymentMethods();
            LoadStatuses();

            // Make read-only fields unselectable
            txt_patientName.TabStop = false;
            txt_doctorName.TabStop = false;
            txt_appointmentDate.TabStop = false;
        }


        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CloseForm() => this.Close();

        // 👇 This helper safely triggers the PaymentSaved event
        public void NotifyPaymentSaved()
        {
            PaymentSaved?.Invoke();
        }

        private void btn_addPayment_Click(object sender, EventArgs e)
        {
            _presenter.SavePayment();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadPaymentMethods()
        {
            cmb_method.Items.Clear();
            cmb_method.Items.AddRange(new string[]
            {
                "Cash",
                "GCash",
                "Credit Card",
                "Debit Card",
                "Bank Transfer"
            });
            cmb_method.SelectedIndex = 0;
        }

        private void LoadStatuses()
        {
            cmb_status.Items.Clear();
            cmb_status.Items.AddRange(new string[]
            {
                "Paid",
                "Pending"
            });
            cmb_status.SelectedIndex = 0;
        }
    }
}
