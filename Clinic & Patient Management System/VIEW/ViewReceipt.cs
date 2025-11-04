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

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class ViewReceipt : Form
    {
        private readonly int _paymentID;
        private readonly string _connection = @"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;";
        public ViewReceipt(int paymentID)
        {
            InitializeComponent();
            _paymentID = paymentID;
            LoadPaymentDetails();

        }
        private void LoadPaymentDetails()
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                con.Open();
                string query = @"
                    SELECT 
                        p.PaymentID,
                        pr.Name AS PatientName,
                        d.Name AS DoctorName,
                        a.ScheduleDate AS AppointmentDate,
                        p.PaymentDate,
                        p.Amount,
                        p.PaymentMethod,
                        p.Status,
                        p.Notes
                    FROM tbl_payment p
                    INNER JOIN tbl_appointment a ON p.AppointmentID = a.AppointmentID
                    INNER JOIN tbl_patientRecord pr ON p.PatientID = pr.PatientID
                    INNER JOIN tbl_doctor d ON p.DoctorID = d.DoctorID
                    WHERE p.PaymentID = @PaymentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", _paymentID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["PaymentID"]);
                            string year = DateTime.Now.Year.ToString();
                            lbl_receiptNumber.Text = $"CNX-{year}-{id:D5}";
                            lbl_date.Text = Convert.ToDateTime(reader["PaymentDate"]).ToShortDateString();
                            lbl_patientName.Text = reader["PatientName"].ToString();
                            lbl_doctorName.Text = reader["DoctorName"].ToString();
                            lbl_appointmentDate.Text = Convert.ToDateTime(reader["AppointmentDate"]).ToShortDateString();
                            lbl_paymentDate.Text = Convert.ToDateTime(reader["PaymentDate"]).ToShortDateString();
                            lbl_paymentMethod.Text = reader["PaymentMethod"].ToString();
                            lbl_status.Text = reader["Status"].ToString();
                            lbl_amount.Text = $"₱{Convert.ToDecimal(reader["Amount"]):N2}";
                            lbl_notes.Text = reader["Notes"]?.ToString() ?? "None";
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
