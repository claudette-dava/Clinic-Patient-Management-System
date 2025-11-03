using Clinic___Patient_Management_System.PRESENTER;
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
using Clinic___Patient_Management_System.VIEW;

namespace Clinic___Patient_Management_System.VIEW
{
    public partial class Appointment : Form, IAppointmentView
    {
        private readonly AppointmentPresenter _presenter;
        public Appointment()
        {
            InitializeComponent();
            _presenter = new AppointmentPresenter(this);
            txt_searchAppointment.Text = "   Search";
            txt_searchAppointment.ForeColor = Color.Gray;
            _presenter.LoadAppointments();
        }

        private void txt_searchAppointment_Enter(object sender, EventArgs e)
        {
            if (txt_searchAppointment.Text == "   Search")
            {
                txt_searchAppointment.Text = "   "; // remove placeholder
                txt_searchAppointment.ForeColor = Color.Black; // set text color to black
            }
        }

        private void txt_searchAppointment_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_searchAppointment.Text))
            {
                txt_searchAppointment.Text = "   Search"; // restore placeholder
                txt_searchAppointment.ForeColor = Color.Gray; // make it gray again
            }
        }
        public void DisplayAppointments(DataTable appointments)
        {
            dgv_appointmentRecord.Rows.Clear();

            foreach (DataRow row in appointments.Rows)
            {
                int appointmentID = Convert.ToInt32(row["AppointmentID"]);
                int scheduleID = Convert.ToInt32(row["ScheduleID"]);
                int timeslotID = Convert.ToInt32(row["TimeSlotID"]);

                string doctorName = row["DoctorName"].ToString();
                string patientName = row["PatientName"].ToString();
                string scheduleDate = Convert.ToDateTime(row["ScheduleDate"]).ToShortDateString();

                TimeSpan startTS = (TimeSpan)row["StartTime"];
                TimeSpan endTS = (TimeSpan)row["EndTime"];
                string startTime = DateTime.Today.Add(startTS).ToString("h:mm tt");
                string endTime = DateTime.Today.Add(endTS).ToString("h:mm tt");

                string status = row["Status"].ToString();

                // ✅ Match the actual column order of your DataGridView
                dgv_appointmentRecord.Rows.Add(
                    appointmentID,    // Appointment ID
                    patientName,      // Patient Name
                    doctorName,       // Doctor Name
                    scheduleID,       // Schedule ID (hidden)
                    timeslotID,       // TimeSlot ID (hidden)
                    scheduleDate,     // Appointment Date
                    startTime,        // Start Time
                    endTime,          // End Time
                    status,           // Status
                    "Edit",           // Edit column
                    "Delete" ,         // Delete column
                    "View", 
                    "Pay"
                );
            }

            // Hide ID columns safely
            if (dgv_appointmentRecord.Columns.Contains("scheduleID"))
                dgv_appointmentRecord.Columns["scheduleID"].Visible = false;

            if (dgv_appointmentRecord.Columns.Contains("timeSlotID"))
                dgv_appointmentRecord.Columns["timeSlotID"].Visible = false;
        }


        private void btn_addAppointment_Click(object sender, EventArgs e)
        {

        }

        private void dgv_appointmentRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgv_appointmentRecord.Columns[e.ColumnIndex].Name;

            
            if (columnName == "AddConsultation")
            {
                string status = dgv_appointmentRecord.Rows[e.RowIndex].Cells["status"].Value.ToString();

              
                if (status != "Scheduled")
                {
                    MessageBox.Show("Consultation can only be added for scheduled appointments.",
                        "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                int appointmentID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["AppointmentID"].Value);
                int scheduleID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["ScheduleID"].Value);
                int timeslotID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["TimeSlotID"].Value);
                string doctorName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["DoctorName"].Value.ToString();
                string patientName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["patientID"].Value.ToString();
                string scheduleDate = dgv_appointmentRecord.Rows[e.RowIndex].Cells["date"].Value.ToString();

             
                int doctorID = GetDoctorID(appointmentID);
                int patientID = GetPatientID(appointmentID);

                addConsulation frm = new addConsulation(
                    appointmentID,
                    doctorID,
                    patientID,
                    doctorName,
                    patientName,
                    scheduleDate
                );

              
                frm.ConsultationSaved += () =>
                {
                    UpdateAppointmentStatus(appointmentID, "Completed");
                    _presenter.LoadAppointments(); // refresh grid after update
                };

                frm.ShowDialog();
            }

        
            else if (columnName == "Payment")
            {
                string status = dgv_appointmentRecord.Rows[e.RowIndex].Cells["Status"].Value.ToString();

              
                if (status != "Completed")
                {
                    MessageBox.Show("Only completed consultations can proceed to payment.",
                        "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int appointmentID = Convert.ToInt32(dgv_appointmentRecord.Rows[e.RowIndex].Cells["AppointmentID"].Value);
                string patientName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["patientID"].Value.ToString();
                string doctorName = dgv_appointmentRecord.Rows[e.RowIndex].Cells["DoctorName"].Value.ToString();
                string appointmentDate = dgv_appointmentRecord.Rows[e.RowIndex].Cells["date"].Value.ToString();

                int doctorID = GetDoctorID(appointmentID);
                int patientID = GetPatientID(appointmentID);

                addPayment frm = new addPayment(appointmentID, patientID, doctorID, patientName, doctorName, appointmentDate);
                frm.PaymentSaved += () => _presenter.LoadAppointments();
                frm.ShowDialog();
            }
        }
        private int GetDoctorID(int appointmentID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DoctorID FROM tbl_appointment WHERE AppointmentID = @id", con);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int GetPatientID(int appointmentID)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatientID FROM tbl_appointment WHERE AppointmentID = @id", con);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private void UpdateAppointmentStatus(int appointmentID, string newStatus)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=CJ-PC;Initial Catalog=Clinic_and_Patient_db;Integrated Security=True;"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tbl_appointment SET Status = @status WHERE AppointmentID = @id", con);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
